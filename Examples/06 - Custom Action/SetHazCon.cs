using System;
using System.Collections;

using AiMetrix.BusinessObject.Events;
using AiMetrix.BusinessObject.Inventory;

namespace SetHazConExample
{
    public class SetHazCon
    {
        public object Main(Hashtable parameters)
        {
            int hazcon = (int)parameters["hazcon"];
            Guid authServicesID = NSObjects.GetByDisplayName("Authorization Services")[0].NSObjectID;
            Guid unifiedComsID = NSObjects.GetByDisplayName("Unified Communications Services")[0].NSObjectID;
            StateTypes stypes = StateTypes.Get("Hazardous Condition Status");

            if (stypes.Count > 0) {
                long hazconStateTypeID = stypes[0].StateTypeID;

                StateTypeValues hazconValues = StateTypeValues.Get(hazconStateTypeID);

                StateTypeNSObject.Save(authServicesID, hazconStateTypeID, hazconValues[hazcon].StateTypeValueID, hazconValues[1].StateTypeValueDescriptor);
                StateTypeNSObject.Save(unifiedComsID, hazconStateTypeID, hazconValues[hazcon].StateTypeValueID, hazconValues[1].StateTypeValueDescriptor);
            }

            return null;
        }
    }
}