using System;
using System.Collections.Generic;
using System.Text;

using AiMetrix.BusinessObject;
using AiMetrix.BusinessObject.Security;
using AiMetrix.BusinessObject.Inventory;
using AiMetrix.BusinessObject.UI;
using AiMetrix.BusinessObject.Performance;

using AiMetrix.BusinessObject.Events;

namespace Inventory
{
    public class InventoryExample
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
        public void AddInventory_Basic()
        {
            try {
                Start();

                Guid nsobjectID = NSObject.Create("Test");
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }

        public void AddInventory_100Objects()
        {
            try
            {
                Start();

                for (int i = 1; i <= 100; i++)
                {
                    // Simple Example
                    NSObject.Create("Test Object " + i.ToString());

                    // Creation by classification type example
                    // NSObject.CreateByClassificationType(997074204, "Test Object " + i.ToString());

                    NSObject.CreateByIPAddress("10.1.1." + i.ToString(), "Test Object " + i.ToString());
                    
                    Console.WriteLine("Creating Test Object " + i.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            }
            finally
            {
                Stop();
            }
        }

        public void AddInventory_CreateWithClassification()
        {
            try {
                Start();

                Guid nsobjectID = NSObject.CreateByIPAddress("10.1.1.1","Test With Classification");
                
                string classficationType = "Router";
                ClassificationTypes cts = ClassificationTypes.Get(classficationType);
                ClassificationType ct = cts[0];

                NSObject.SetClassificationType(nsobjectID, ct.ID);
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }

        public void EditInventory()
        {
            try {
                Start();

                // Find NSObject by IP Address
                NSObjects nsobjects = NSObjects.GetAllByIPAddressKeys("10.1.1.1");

                if (nsobjects.Count > 0) {
                    Console.WriteLine("Setting Last Discovered");

                    NSObject nsobj = nsobjects[0];

                    // One of a few set methods
                    NSObject.SetLastDiscovered(nsobj.NSObjectID, DateTime.Now);
                }
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }

        public void DeleteInventory()
        {
            try {
                Start();

                NSObjects nsobjects = NSObjects.GetAllByIPAddressKeys("10.1.1.1");

                if (nsobjects.Count > 0) {
                    NSObject nsobj = nsobjects[0];

                    nsobj.Delete();
                    //NSObject.Delete(nsobj.NSObjectID);
                }
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }

        public void CreateClassificationType()
        {
            try {
                Start();

                ClassificationType classificationType = new ClassificationType();
                classificationType.Name = "Delete Me";
                classificationType.Save();

                // Set a breakpoint to checkout the classificationType variable. ID should be filled in
                NSObjects nsobjects = NSObjects.GetAllByIPAddressKeys("10.1.1.1");

                if (nsobjects.Count > 0) {
                    NSObject.SetClassificationType(nsobjects[0].NSObjectID, classificationType.ID);
                }
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }

        public void DeleteClassificationType()
        {
            try {
                Start();

                ClassificationType.Delete(-1221234864);
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }

        public void CreateCustomObject()
        {
            try {
                Start();

                Guid nsobjectID = NSObject.CreateByIPAddress("10.1.1.2", "Test 2");

                ClassificationTypes cts = ClassificationTypes.Get("Test Objects");

                if (cts.Count > 0) {
                    ClassificationType ct = cts[0];
                    NSObject.SetClassificationType(nsobjectID, ct.ID);
                }

                string objectClass = "SolarwindsDatabaseID";
                string objectName = "123456789-2";

                CustomObject cobj = new CustomObject();
                cobj.NSObjectID = nsobjectID;
                cobj.ClassName = objectClass;
                cobj.ObjectName = objectName;
                cobj.Save();

                CustomObjects foundCustomObjects = CustomObjects.GetByClassName(objectClass, objectName, NSNodes.GetMe().NetworkDomainID);

                if (foundCustomObjects.Count > 0) {

                    CustomObject foundCustomObject = foundCustomObjects[0];

                    if (foundCustomObject.NSObjectID == nsobjectID) {
                        Console.WriteLine("Objects match!");
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }

        public void CreateCustomAttribute()
        {
            try {
                Start();

                string objectClass = "SolarwindsDatabaseID";
                string objectName = "123456789-2";

                CustomObjects foundCustomObjects = CustomObjects.GetByClassName(objectClass, objectName, NSNodes.GetMe().NetworkDomainID);

                if (foundCustomObjects.Count > 0) {
                    CustomObject foundCustomObject = foundCustomObjects[0];

                    CustomAttribute customAttribute = new CustomAttribute();
                    customAttribute.Category = "Cool Properties";
                    customAttribute.DisplayAsFilterAttribute = false;
                    customAttribute.Hidden = false;
                    customAttribute.Name = "Really Cool Property";
                    customAttribute.Value = "Blue 42";
                    customAttribute.NSObjectID = foundCustomObject.NSObjectID;
                    customAttribute.Save();
                }
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }

        public void SearchNSObjectGet()
        {
            try {
                Start();

                ClassificationTypes cts = ClassificationTypes.Get("Test Objects");

                if (cts.Count > 0) {
                    ClassificationType ct = cts[0];
                    NSObjects objs = NSObjects.GetByClassificationType(ct.ID);

                    Console.WriteLine(String.Format("Found objects: {0}...", objs.Count));
                }
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }

        public void Search_InventoryListVueItems()
        {
            try {
                Start();

                //InventoryListVueItems.GetByAssetGroup
                //InventoryListVueItems.GetByMap
                //InventoryListVueItems items = InventoryListVueItems.GetInventory(1, 200, "DisplayName", "test%", "", true, false, null, false, false);

                NSObjects objs = NSObjects.GetByDisplayNameKeys("test%");


                

                Console.WriteLine("Object Count: " + objs.Count);

                //if (items.Count > 0) {
                //    Console.WriteLine(String.Format("Found objects: {0}...", items.Count));
                //}
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }

        public void GetNetworkVitals()
        {
            try {
                Start();

                InventoryListVueItems items = InventoryListVueItems.GetInventory(1, 65, "DisplayName", "test%", "", true, false, null, false, false);
                List<Guid> nsobjectIDList = new List<Guid>();

                if (items.Count > 0) {
                    foreach (InventoryListVueItem item in items) {
                        nsobjectIDList.Add(item.NSObjectID);
                    }

                    NetworkVitals vitals = NetworkVitals.GetByNSObjectList(nsobjectIDList);

                    foreach(NetworkVital vital in vitals) {
                        Console.WriteLine("{0} has {1} availability", vital.DisplayName, (vital.Availability.HasValue ? vital.Availability.Value : 0));
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }

        public void SetAvailability()
        {
            try {
                Start();

                NSObjects objs = NSObjects.GetByDisplayName("Test With Classification");

                if (objs.Count > 0) {
                    NSObject nsobj = objs[0];
                    long metricID = 6035663820632218227;   // Custom.Availability

                    MeasurementCollector measurementCollector = new MeasurementCollector();
                    //measurementCollector.AddPointMeasurement(nsobj.NSObjectID, metricID, 600, 1, DateTime.Now); // Up
                    measurementCollector.AddPointMeasurement(nsobj.NSObjectID, metricID, 600, 0, DateTime.Now); // Down
                    measurementCollector.Save();
                }
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }

        public void SetObjectToGroup()
        {
            try {
                Start();

                SecurityGroup sgroup = SecurityGroup.Get(null, "Operations");
                SecurityItems items = SecurityItems.Get(AuthorizationItemType.Object, sgroup.Id, 1, 200, "test%");

                foreach(SecurityItem item in items) {
                    item.Read = true;
                    item.Write = false;
                }

                items.Save();
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }

        public void CreateAction()
        {
            try
            {
                ActionType atype = new ActionType();
                atype.ActionTypeName = "TextLogFile";
                atype.AssemblyName = "TextFileLog.dll";
                atype.ParameterTemplate = "<ParameterTemplate></ParameterTemplate>";
                atype.Parameters = new List<ActionType.ActionParameter>();
                atype.Parameters.Add(new ActionType.ActionParameter("param1", "param1", "2", "some description", false));
                atype.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            }
        }
        #endregion
    }
}