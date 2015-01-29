namespace SecurityAPI
{
    partial class SecurityStuff
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnForceUserLogout = new System.Windows.Forms.Button();
            this.btnCreateSecurityGroup = new System.Windows.Forms.Button();
            this.btnCreateNSDAUser = new System.Windows.Forms.Button();
            this.btnCreateWindowsUser = new System.Windows.Forms.Button();
            this.btnResetUsersPassword = new System.Windows.Forms.Button();
            this.btnGetSecurityGroups = new System.Windows.Forms.Button();
            this.btnGetSecurityUsers = new System.Windows.Forms.Button();
            this.btnEditGroupProperties = new System.Windows.Forms.Button();
            this.SecurityGroupGroupBox = new System.Windows.Forms.GroupBox();
            this.SecurityUsersGroupBox = new System.Windows.Forms.GroupBox();
            this.btnContactInfo = new System.Windows.Forms.Button();
            this.btnEditUserGroup = new System.Windows.Forms.Button();
            this.PermissionsGroupBox = new System.Windows.Forms.GroupBox();
            this.btnObjectPermissions = new System.Windows.Forms.Button();
            this.btnMapPermissions = new System.Windows.Forms.Button();
            this.btnGroupPermissions = new System.Windows.Forms.Button();
            this.btnCustomViewPermissions = new System.Windows.Forms.Button();
            this.FilterGroupBox = new System.Windows.Forms.GroupBox();
            this.btnObjectFilter = new System.Windows.Forms.Button();
            this.SecurityGroupGroupBox.SuspendLayout();
            this.SecurityUsersGroupBox.SuspendLayout();
            this.PermissionsGroupBox.SuspendLayout();
            this.FilterGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(28, 23);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(28, 63);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnForceUserLogout
            // 
            this.btnForceUserLogout.Location = new System.Drawing.Point(6, 195);
            this.btnForceUserLogout.Name = "btnForceUserLogout";
            this.btnForceUserLogout.Size = new System.Drawing.Size(136, 23);
            this.btnForceUserLogout.TabIndex = 2;
            this.btnForceUserLogout.Text = "Force User Logout";
            this.btnForceUserLogout.UseVisualStyleBackColor = true;
            this.btnForceUserLogout.Click += new System.EventHandler(this.btnForceUserLogout_Click);
            // 
            // btnCreateSecurityGroup
            // 
            this.btnCreateSecurityGroup.Location = new System.Drawing.Point(6, 49);
            this.btnCreateSecurityGroup.Name = "btnCreateSecurityGroup";
            this.btnCreateSecurityGroup.Size = new System.Drawing.Size(188, 23);
            this.btnCreateSecurityGroup.TabIndex = 3;
            this.btnCreateSecurityGroup.Text = "Create SecurityGroup";
            this.btnCreateSecurityGroup.UseVisualStyleBackColor = true;
            this.btnCreateSecurityGroup.Click += new System.EventHandler(this.btnCreateSecurityGroup_Click);
            // 
            // btnCreateNSDAUser
            // 
            this.btnCreateNSDAUser.Location = new System.Drawing.Point(6, 48);
            this.btnCreateNSDAUser.Name = "btnCreateNSDAUser";
            this.btnCreateNSDAUser.Size = new System.Drawing.Size(136, 23);
            this.btnCreateNSDAUser.TabIndex = 4;
            this.btnCreateNSDAUser.Text = "Create NSDA User";
            this.btnCreateNSDAUser.UseVisualStyleBackColor = true;
            this.btnCreateNSDAUser.Click += new System.EventHandler(this.btnCreateNSDAUser_Click);
            // 
            // btnCreateWindowsUser
            // 
            this.btnCreateWindowsUser.Location = new System.Drawing.Point(6, 77);
            this.btnCreateWindowsUser.Name = "btnCreateWindowsUser";
            this.btnCreateWindowsUser.Size = new System.Drawing.Size(136, 23);
            this.btnCreateWindowsUser.TabIndex = 5;
            this.btnCreateWindowsUser.Text = "Create Windows User";
            this.btnCreateWindowsUser.UseVisualStyleBackColor = true;
            this.btnCreateWindowsUser.Click += new System.EventHandler(this.btnCreateWindowsUser_Click);
            // 
            // btnResetUsersPassword
            // 
            this.btnResetUsersPassword.Location = new System.Drawing.Point(6, 106);
            this.btnResetUsersPassword.Name = "btnResetUsersPassword";
            this.btnResetUsersPassword.Size = new System.Drawing.Size(136, 23);
            this.btnResetUsersPassword.TabIndex = 6;
            this.btnResetUsersPassword.Text = "Reset User\'s Password";
            this.btnResetUsersPassword.UseVisualStyleBackColor = true;
            this.btnResetUsersPassword.Click += new System.EventHandler(this.btnResetUsersPassword_Click);
            // 
            // btnGetSecurityGroups
            // 
            this.btnGetSecurityGroups.Location = new System.Drawing.Point(6, 20);
            this.btnGetSecurityGroups.Name = "btnGetSecurityGroups";
            this.btnGetSecurityGroups.Size = new System.Drawing.Size(188, 23);
            this.btnGetSecurityGroups.TabIndex = 7;
            this.btnGetSecurityGroups.Text = "Get SecurityGroups";
            this.btnGetSecurityGroups.UseVisualStyleBackColor = true;
            this.btnGetSecurityGroups.Click += new System.EventHandler(this.btnGetSecurityGroups_Click);
            // 
            // btnGetSecurityUsers
            // 
            this.btnGetSecurityUsers.Location = new System.Drawing.Point(6, 19);
            this.btnGetSecurityUsers.Name = "btnGetSecurityUsers";
            this.btnGetSecurityUsers.Size = new System.Drawing.Size(136, 23);
            this.btnGetSecurityUsers.TabIndex = 8;
            this.btnGetSecurityUsers.Text = "Get SecurityUsers";
            this.btnGetSecurityUsers.UseVisualStyleBackColor = true;
            this.btnGetSecurityUsers.Click += new System.EventHandler(this.btnGetSecurityUsers_Click);
            // 
            // btnEditGroupProperties
            // 
            this.btnEditGroupProperties.Location = new System.Drawing.Point(6, 78);
            this.btnEditGroupProperties.Name = "btnEditGroupProperties";
            this.btnEditGroupProperties.Size = new System.Drawing.Size(188, 23);
            this.btnEditGroupProperties.TabIndex = 9;
            this.btnEditGroupProperties.Text = "Edit Group Properties";
            this.btnEditGroupProperties.UseVisualStyleBackColor = true;
            this.btnEditGroupProperties.Click += new System.EventHandler(this.btnEditGroupProperties_Click);
            // 
            // SecurityGroupGroupBox
            // 
            this.SecurityGroupGroupBox.Controls.Add(this.btnGetSecurityGroups);
            this.SecurityGroupGroupBox.Controls.Add(this.btnEditGroupProperties);
            this.SecurityGroupGroupBox.Controls.Add(this.btnCreateSecurityGroup);
            this.SecurityGroupGroupBox.Location = new System.Drawing.Point(120, 23);
            this.SecurityGroupGroupBox.Name = "SecurityGroupGroupBox";
            this.SecurityGroupGroupBox.Size = new System.Drawing.Size(200, 115);
            this.SecurityGroupGroupBox.TabIndex = 10;
            this.SecurityGroupGroupBox.TabStop = false;
            this.SecurityGroupGroupBox.Text = "Security Groups";
            // 
            // SecurityUsersGroupBox
            // 
            this.SecurityUsersGroupBox.Controls.Add(this.btnContactInfo);
            this.SecurityUsersGroupBox.Controls.Add(this.btnEditUserGroup);
            this.SecurityUsersGroupBox.Controls.Add(this.btnGetSecurityUsers);
            this.SecurityUsersGroupBox.Controls.Add(this.btnCreateNSDAUser);
            this.SecurityUsersGroupBox.Controls.Add(this.btnForceUserLogout);
            this.SecurityUsersGroupBox.Controls.Add(this.btnResetUsersPassword);
            this.SecurityUsersGroupBox.Controls.Add(this.btnCreateWindowsUser);
            this.SecurityUsersGroupBox.Location = new System.Drawing.Point(340, 23);
            this.SecurityUsersGroupBox.Name = "SecurityUsersGroupBox";
            this.SecurityUsersGroupBox.Size = new System.Drawing.Size(149, 230);
            this.SecurityUsersGroupBox.TabIndex = 11;
            this.SecurityUsersGroupBox.TabStop = false;
            this.SecurityUsersGroupBox.Text = "Security Users";
            // 
            // btnContactInfo
            // 
            this.btnContactInfo.Location = new System.Drawing.Point(6, 164);
            this.btnContactInfo.Name = "btnContactInfo";
            this.btnContactInfo.Size = new System.Drawing.Size(136, 23);
            this.btnContactInfo.TabIndex = 10;
            this.btnContactInfo.Text = "Edit User\'s ContactInfo";
            this.btnContactInfo.UseVisualStyleBackColor = true;
            this.btnContactInfo.Click += new System.EventHandler(this.btnContactInfo_Click);
            // 
            // btnEditUserGroup
            // 
            this.btnEditUserGroup.Location = new System.Drawing.Point(6, 135);
            this.btnEditUserGroup.Name = "btnEditUserGroup";
            this.btnEditUserGroup.Size = new System.Drawing.Size(136, 23);
            this.btnEditUserGroup.TabIndex = 9;
            this.btnEditUserGroup.Text = "Edit User\'s Group";
            this.btnEditUserGroup.UseVisualStyleBackColor = true;
            this.btnEditUserGroup.Click += new System.EventHandler(this.btnEditUserGroup_Click);
            // 
            // PermissionsGroupBox
            // 
            this.PermissionsGroupBox.Controls.Add(this.btnCustomViewPermissions);
            this.PermissionsGroupBox.Controls.Add(this.btnGroupPermissions);
            this.PermissionsGroupBox.Controls.Add(this.btnMapPermissions);
            this.PermissionsGroupBox.Controls.Add(this.btnObjectPermissions);
            this.PermissionsGroupBox.Location = new System.Drawing.Point(120, 153);
            this.PermissionsGroupBox.Name = "PermissionsGroupBox";
            this.PermissionsGroupBox.Size = new System.Drawing.Size(200, 149);
            this.PermissionsGroupBox.TabIndex = 12;
            this.PermissionsGroupBox.TabStop = false;
            this.PermissionsGroupBox.Text = "Permissions";
            // 
            // btnObjectPermissions
            // 
            this.btnObjectPermissions.Location = new System.Drawing.Point(6, 19);
            this.btnObjectPermissions.Name = "btnObjectPermissions";
            this.btnObjectPermissions.Size = new System.Drawing.Size(188, 23);
            this.btnObjectPermissions.TabIndex = 0;
            this.btnObjectPermissions.Text = "Object Permissions";
            this.btnObjectPermissions.UseVisualStyleBackColor = true;
            this.btnObjectPermissions.Click += new System.EventHandler(this.btnObjectPermissions_Click);
            // 
            // btnMapPermissions
            // 
            this.btnMapPermissions.Location = new System.Drawing.Point(6, 50);
            this.btnMapPermissions.Name = "btnMapPermissions";
            this.btnMapPermissions.Size = new System.Drawing.Size(188, 23);
            this.btnMapPermissions.TabIndex = 1;
            this.btnMapPermissions.Text = "Map Permissions";
            this.btnMapPermissions.UseVisualStyleBackColor = true;
            this.btnMapPermissions.Click += new System.EventHandler(this.btnMapPermissions_Click);
            // 
            // btnGroupPermissions
            // 
            this.btnGroupPermissions.Location = new System.Drawing.Point(6, 81);
            this.btnGroupPermissions.Name = "btnGroupPermissions";
            this.btnGroupPermissions.Size = new System.Drawing.Size(188, 23);
            this.btnGroupPermissions.TabIndex = 2;
            this.btnGroupPermissions.Text = "Group Permissions";
            this.btnGroupPermissions.UseVisualStyleBackColor = true;
            this.btnGroupPermissions.Click += new System.EventHandler(this.btnGroupPermissions_Click);
            // 
            // btnCustomViewPermissions
            // 
            this.btnCustomViewPermissions.Location = new System.Drawing.Point(6, 112);
            this.btnCustomViewPermissions.Name = "btnCustomViewPermissions";
            this.btnCustomViewPermissions.Size = new System.Drawing.Size(188, 23);
            this.btnCustomViewPermissions.TabIndex = 3;
            this.btnCustomViewPermissions.Text = "Custom View Permissions";
            this.btnCustomViewPermissions.UseVisualStyleBackColor = true;
            this.btnCustomViewPermissions.Click += new System.EventHandler(this.btnCustomViewPermissions_Click);
            // 
            // FilterGroupBox
            // 
            this.FilterGroupBox.Controls.Add(this.btnObjectFilter);
            this.FilterGroupBox.Location = new System.Drawing.Point(340, 259);
            this.FilterGroupBox.Name = "FilterGroupBox";
            this.FilterGroupBox.Size = new System.Drawing.Size(149, 42);
            this.FilterGroupBox.TabIndex = 13;
            this.FilterGroupBox.TabStop = false;
            this.FilterGroupBox.Text = "Permission Filter";
            // 
            // btnObjectFilter
            // 
            this.btnObjectFilter.Location = new System.Drawing.Point(6, 14);
            this.btnObjectFilter.Name = "btnObjectFilter";
            this.btnObjectFilter.Size = new System.Drawing.Size(137, 23);
            this.btnObjectFilter.TabIndex = 1;
            this.btnObjectFilter.Text = "Object Permissions";
            this.btnObjectFilter.UseVisualStyleBackColor = true;
            this.btnObjectFilter.Click += new System.EventHandler(this.btnObjectFilter_Click);
            // 
            // SecurityStuff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FilterGroupBox);
            this.Controls.Add(this.PermissionsGroupBox);
            this.Controls.Add(this.SecurityUsersGroupBox);
            this.Controls.Add(this.SecurityGroupGroupBox);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnLogin);
            this.Name = "SecurityStuff";
            this.Size = new System.Drawing.Size(523, 321);
            this.SecurityGroupGroupBox.ResumeLayout(false);
            this.SecurityUsersGroupBox.ResumeLayout(false);
            this.PermissionsGroupBox.ResumeLayout(false);
            this.FilterGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnForceUserLogout;
        private System.Windows.Forms.Button btnCreateSecurityGroup;
        private System.Windows.Forms.Button btnCreateNSDAUser;
        private System.Windows.Forms.Button btnCreateWindowsUser;
        private System.Windows.Forms.Button btnResetUsersPassword;
        private System.Windows.Forms.Button btnGetSecurityGroups;
        private System.Windows.Forms.Button btnGetSecurityUsers;
        private System.Windows.Forms.Button btnEditGroupProperties;
        private System.Windows.Forms.GroupBox SecurityGroupGroupBox;
        private System.Windows.Forms.GroupBox SecurityUsersGroupBox;
        private System.Windows.Forms.Button btnContactInfo;
        private System.Windows.Forms.Button btnEditUserGroup;
        private System.Windows.Forms.GroupBox PermissionsGroupBox;
        private System.Windows.Forms.Button btnCustomViewPermissions;
        private System.Windows.Forms.Button btnGroupPermissions;
        private System.Windows.Forms.Button btnMapPermissions;
        private System.Windows.Forms.Button btnObjectPermissions;
        private System.Windows.Forms.GroupBox FilterGroupBox;
        private System.Windows.Forms.Button btnObjectFilter;
    }
}
