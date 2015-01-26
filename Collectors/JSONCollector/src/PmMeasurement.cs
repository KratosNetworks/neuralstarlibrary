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
using AiMetrix.Common;
using AiMetrix.Snmp;
using AiMetrix.BusinessObject;
using AiMetrix.PmManager;

namespace AiMetrix.JSONPoller
{
    /// <summary>
    /// Holds attributes of one HostMIB PM PmMeasurement
    /// </summary>
    public class PmMeasurement : AiMetrix.PmManager.PmMeasurementBase
    {
        public PmMeasurement()
            : base()
        {
        }

        public string GroupName { get; set; }
        public DateTime SampleDateTime { get; set; }
    }
}