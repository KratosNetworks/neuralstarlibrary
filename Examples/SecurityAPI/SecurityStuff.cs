using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AiMetrix.BusinessObject;
using AiMetrix.BusinessObject.Security;

namespace SecurityAPI
{
    public partial class SecurityStuff : UserControl
    {
        public SecurityStuff()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User.SessionStatus loginStatus = User.Login("a", "a");

            MessageBox.Show(loginStatus.ToString());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            bool success = User.Logout();
        }

        #region SecurityGroups
        private void btnGetSecurityGroups_Click(object sender, EventArgs e)
        {
            GenericList list = GenericList.GetSecurityGroups();

            foreach (GenericNameValuePair item in list)
            {
                Console.WriteLine("group id = " + item.Key + " group name = " + item.Value);
            }

        }

        private void btnCreateSecurityGroup_Click(object sender, EventArgs e)
        {
            SecurityGroup newGroup = SecurityGroup.Create();
            newGroup.Name = "mySpecialGroup";
            newGroup.Save();

            int newGroupID = newGroup.Id;

        }

        private void btnEditGroupProperties_Click(object sender, EventArgs e)
        {
            //get the groups
            int securityGroupID = GetGroupId("operations");
           

            if (securityGroupID != 0)
            {
                SecurityGroup ops = SecurityGroup.Get(securityGroupID);

                ops.CanAddDeleteMaps = false;
                ops.CanSeeDiscoveryHeader = false;
                ops.CanSeeMetricsHeader = false;
                ops.CanSeeNetOpsHeader = false;
                ops.CanSeePreferencesHeader = false;
                ops.CanSeeReportsHeader = false;

                ops.Save();

            }
        }

        #endregion SecurityGroup

        #region SecurityUser

        private void btnGetSecurityUsers_Click(object sender, EventArgs e)
        {
            //To get names and Id only
            //SecurityUserList list = SecurityUserList.GetUserList(null);
            SecurityUserList list = SecurityUserList.Get(null, 1, 5000, "%");
            foreach (SecurityUser user in list)
            {
                Console.WriteLine("ID = " + user.Id.ToString() + "Username = " + user.UserName + " group = " + user.GroupName);
            }
        }

        private void btnCreateNSDAUser_Click(object sender, EventArgs e)
        {
            bool success = User.CreateNewUser("test", "test", GetGroupId("administrator"), false);
        }

        private void btnCreateWindowsUser_Click(object sender, EventArgs e)
        {
            bool success = User.AddWindowsUser("kratos\rosalind.franks", GetGroupId("administrator"));
        }

        private void btnResetUsersPassword_Click(object sender, EventArgs e)
        {
            User.ResetPassword(GetUserId("test"), "t", false);
        }

        private void btnEditUserGroup_Click(object sender, EventArgs e)
        {
            User.UpdateGroup(GetUser("test"), GetGroupId("operations"));
        }

        private void btnContactInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnForceUserLogout_Click(object sender, EventArgs e)
        {
            Guid sessionID = Guid.NewGuid();
            //Get UserList.
            //loop through end all sessions that have specific groupID or all sessions logged in
            bool success = User.EndUserSession(sessionID);
        }

        #endregion SecurityUser


        #region permissions

        private void btnObjectPermissions_Click(object sender, EventArgs e)
        {
            SecurityItems objects = SecurityItems.Get(AuthorizationItemType.Object, GetGroupId("operations"));

            foreach (SecurityItem obj in objects)
            {
                if (obj.Description.Equals("Interface", StringComparison.InvariantCultureIgnoreCase))
                    obj.Read = false;
            }

            try
            {
                objects.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (objects.IsDirty)
            {
                MessageBox.Show("Update permissions for operations failed.");
            }
        }

        private void btnMapPermissions_Click(object sender, EventArgs e)
        {
            SecurityMaps maps = SecurityMaps.Get(GetGroupId("operations"));

            foreach(SecurityMap map in maps)
            {
                if(map.Name.StartsWith("10."))
                    map.DisplayInTree = true;
            }

            try
            {
                maps.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (maps.IsDirty)
            {
                MessageBox.Show("Update permissions for operations failed.");
            }
        }

        private void btnGroupPermissions_Click(object sender, EventArgs e)
        {
            SecurityAssetGroups  groups = SecurityAssetGroups.Get(GetGroupId("operations"));

            foreach (SecurityAssetGroup invGroup in groups)
            {
                Console.WriteLine(invGroup.Name);
                if (invGroup.Name.StartsWith("Location/E"))
                    invGroup.Read = false;
                else if (invGroup.Name.Contains("Office"))
                {
                    invGroup.DisplayInTree = false;
                }

            }

            try
            {
                groups.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (groups.IsDirty)
            {
                MessageBox.Show("Update permissions for operations failed.");
            }
        }

        private void btnCustomViewPermissions_Click(object sender, EventArgs e)
        {
            SecurityCustomViews views = SecurityCustomViews.Get(GetGroupId("operations"));

            foreach(SecurityCustomView view in views)
            {
                view.Write = false;
                view.ReadInNeuralStarClient = true;
                view.ReadInSQMClient = false;
            }

            try
            {
                views.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (views.IsDirty)
            {
                MessageBox.Show("Update permissions for operations failed.");
            }
        }

        #endregion permissions

        #region helpers

        private int GetGroupId(string securityGroupName)
        {
            GenericList list = GenericList.GetSecurityGroups();

            int securityGroupID = 0;
            foreach (GenericNameValuePair item in list)
            {
                if (item.Value.Equals(securityGroupName, StringComparison.InvariantCultureIgnoreCase))
                {
                    securityGroupID = int.Parse(item.Key);
                    break;
                }
            }

            return securityGroupID;
        }

        private long GetUserId(string securityUsername)
        {
            long userId = 0;

            SecurityUser user = GetUser(securityUsername);

            if (user != null)
                userId = user.Id;

            return userId;
        }

        private SecurityUser GetUser(string securityUsername)
        {

            SecurityUserList list = SecurityUserList.Get(null, 1, 5000, "%");

            SecurityUser user = list.Where(x => x.UserName.ToUpper() == securityUsername.ToUpper()).FirstOrDefault();

            return user;
        }

        #endregion helpers

        private void btnObjectFilter_Click(object sender, EventArgs e)
        {
            int securityGroupID = GetGroupId("operations");
            Filter objFilter = new Filter();
            objFilter.ScopeType = "group";
            objFilter.FilterName = "Operations-View Object Filter";
            objFilter.FilterSecurityGroupID = securityGroupID;
            objFilter.FilterType = Enums.FilterType.SecurityObject.ToString();
            objFilter.IncludeAllChildren = true;

            Filter.Condition condition = new Filter.Condition();
            condition.Attribute = "DisplayName";
            condition.Criteria = "BeginsIn";
            condition.Value = "10.244.200";
            
            objFilter.ConditionsList.Add(condition);

            objFilter.Save();

            try
            {
                AiMetrix.BusinessObject.Security.SecurityGroup.ApplySecurityObjectPermissions(securityGroupID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
