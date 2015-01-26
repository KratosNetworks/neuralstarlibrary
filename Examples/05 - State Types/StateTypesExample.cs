using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using AiMetrix.BusinessObject.Security;
using AiMetrix.BusinessObject.Inventory;
using AiMetrix.BusinessObject.Events;

namespace StateTypesExample
{
    public class StateTypesExample
    {
        #region Private Variables
        User.SessionStatus _status;
        #endregion

        #region Private Methods
        private void Start()
        {
            _status = User.Login("a", "a");

            if (_status == User.SessionStatus.Valid) {
                Console.WriteLine("Login Successful");
            } else {
                Console.WriteLine("Was not able to login");
            }
        }

        private void Stop()
        {
            if (_status == User.SessionStatus.Valid) {
                Console.WriteLine("Logging out...");
                User.Logout();
            }
        }
        #endregion

        #region Public Methods
        public void CreateStateTypes()
        {
            try {
                Start();

                Guid authServicesID = NSObject.Create("Authorization Services");
                Guid unifiedComsID = NSObject.Create("Unified Communications Services");

                // Let's create the state type "descriptor"
                long hazconStateTypeID = StateType.Save("Hazardous Condition Status");

                // Let's assign the potential values for that state type
                StateTypeValue.Save(hazconStateTypeID, 0.ToString(), "Good", Color.Green.ToArgb());
                StateTypeValue.Save(hazconStateTypeID, 1.ToString(), "At Risk", Color.Yellow.ToArgb());
                StateTypeValue.Save(hazconStateTypeID, 2.ToString(), "Down", Color.Red.ToArgb());

                // Let's assign that new state type to our objects
                StateTypeNSObject.Save(authServicesID, hazconStateTypeID, "0", "Authorization Services has a hazcon status of 'Good'");
                StateTypeNSObject.Save(unifiedComsID, hazconStateTypeID, "0", "Unified Communcation Services has a hazcon status of 'Good'");
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }

        public void SetStateTypes()
        {
            try {
                Start();

                Guid authServicesID = NSObjects.GetByDisplayName("Authorization Services")[0].NSObjectID;
                Guid unifiedComsID = NSObjects.GetByDisplayName("Unified Communications Services")[0].NSObjectID;
                StateTypes stypes = StateTypes.Get("Hazardous Condition Status");

                if (stypes.Count > 0) {
                    long hazconStateTypeID = stypes[0].StateTypeID;

                    StateTypeValues hazconValues = StateTypeValues.Get(hazconStateTypeID);

                    StateTypeNSObject.Save(authServicesID, hazconStateTypeID, hazconValues[1].StateTypeValueID, hazconValues[1].StateTypeValueDescriptor);
                    StateTypeNSObject.Save(unifiedComsID, hazconStateTypeID, hazconValues[1].StateTypeValueID, hazconValues[1].StateTypeValueDescriptor);
                }
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }
        #endregion
    }
}
