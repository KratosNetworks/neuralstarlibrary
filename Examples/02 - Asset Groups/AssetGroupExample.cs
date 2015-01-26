using System;
using System.Collections.Generic;
using System.Text;

using AiMetrix.BusinessObject;
using AiMetrix.BusinessObject.Security;
using AiMetrix.BusinessObject.Inventory;

namespace AssetGroupExample
{
    public class AssetGroupExample
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
        public void AddGroup()
        {
            try {
                Start();

                AssetGroup testGroup = new AssetGroup();
                testGroup.Name = "Test Group";
                testGroup.ParentGroupID = Guid.Empty;  //no parent group id for the top level group
                testGroup.ScopeType = AiMetrix.BusinessObject.Enums.ScopeTypes.Public.ToString();
                testGroup.Save();

                Console.WriteLine("Group ID: {0}", testGroup.ID.ToString());
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }

        public void AddNSObjectsToGroup()
        {
            try {
                Start();

                AssetGroup testGroup2 = new AssetGroup();
                testGroup2.Name = "Test Group 2";
                testGroup2.ParentGroupID = Guid.Empty;  //no parent group id for the top level group
                testGroup2.ScopeType = AiMetrix.BusinessObject.Enums.ScopeTypes.Public.ToString();
                
                // First Save to fill in the testGroup2 ID
                testGroup2.Save();

                InventoryListVueItems items = InventoryListVueItems.GetInventory(1, 65, "DisplayName", "test%", "", true, false, null, false, false);
                
                if (items.Count > 0) {
                    foreach (InventoryListVueItem item in items) {
                        testGroup2.AddObject(0, item.NSObjectID);
                    }
                }

                testGroup2.Save();
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }

        public void AddNSObjectsToExistingGroup()
        {
            try {
                Start();

                // Get them all
                // AssetGroups.Get();

                AssetGroups groups = AssetGroups.Get("Test Group");

                if (groups.Count > 0) {
                    AssetGroup group = groups[0];

                    InventoryListVueItems items = InventoryListVueItems.GetInventory(1, 65, "DisplayName", "test%", "", true, false, null, false, false);

                    if (items.Count > 0) {
                        foreach (InventoryListVueItem item in items) {
                            group.AddObject(0, item.NSObjectID);
                        }
                    }

                    group.Save();
                }
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }

        public void DeleteGroup()
        {
            try {
                Start();
                
                AssetGroups groups = AssetGroups.Get("Test Group");

                if (groups.Count > 0) {
                    AssetGroup group = groups[0];
                    group.Delete();
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