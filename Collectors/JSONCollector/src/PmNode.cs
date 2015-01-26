/************************************************************************/
/* Copyright 2004-2009 SYS Technologies, Inc.  All rights reserved.     */
/*               SYS Technologies, Inc. - Proprietary                   */
/* This software contains information of SYS Technologies and is not    */
/* to be disclosed or used except in accordance with applicable         */
/* agreements. Use of this DOPPLER VUE software is governed as          */
/* expressly authorized in the relevant agreement between               */
/* SYS Technologies and the customer, as well as copyright laws and     */
/* international treaties. Unauthorized distribution or duplication     */
/* will result in severe criminal penalties.                            */
/*               SYS Technologies, Inc. - Proprietary                   */
/************************************************************************/

using System;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Dynamic;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

using AiMetrix.PmManager;
using AiMetrix.Common;
using AiMetrix.BusinessObject;
using AiMetrix.BusinessObject.Inventory;
using AiMetrix.BusinessObject.Performance;

namespace AiMetrix.JSONPoller
{
    public class PmNode : AiMetrix.PmManager.PmNodeBase
    {
        #region Private Variables
        private const string MOD_NAME = "AiMetrix.JSONPoller.PmNode::";
        #endregion

        #region Private Methods
        private bool RetrieveJSONPackage()
        {
            try {
                string json = "";
                JObject jobj = JsonConvert.DeserializeObject<JObject>(json);
            } catch {
                return false;
            }

            return true;
        }
        #endregion

        #region Public Methods
        public override bool CollectData()
        {
            try {
                if (Abort) {
                    return false;
                }

                if (!IsInitialized) {
                    throw new ApplicationException("This instance has not been successfully Initialized.");
                }

                if (Abort) {
                    return false;
                }
                
                // Start of Collection and Processing
                bool CountAsFailure = false;

                lock (this.Measurements) {
                    this.Measurements.Clear();
                }

                if (this.Measurements.Count > 0) {
                    Logger.LogInfo(LogHeader + NodeName + " contained [" + this.Measurements.Count.ToString() + "] after calling Measurements.Clear().");
                }

                this.SampleDateTime = DateTime.Now;
                this.NEDateTime = DateTime.Now;

                PmMeasurement Meas = null;

                if (!RetrieveJSONPackage()) {
                    CountAsFailure = true;
                }

                if (CountAsFailure) {
                    Failures++;
                }

                //Logger.LogDebug(LogHeader + "Leaving CollectData for Node [" + this.NodeName + "].");
                return true;
            } catch (Exception ex) {
                string ErrorMessage = ex.Message.ToString();
                this.ErrorMsg = ErrorMessage;
                Logger.LogError(MOD_NAME, "CollectData()", LogHeader, ex);
                return false;
            }
        }

        public override void PublishCollectTime()
        {
        }
        #endregion
    }
}