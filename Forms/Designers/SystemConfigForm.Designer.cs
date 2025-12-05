namespace StudentManagementSystem.Forms
{
    partial class SystemConfigForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTablespace = new System.Windows.Forms.TabPage();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.tabSession = new System.Windows.Forms.TabPage();
            this.tabResource = new System.Windows.Forms.TabPage();
            this.dgvTablespace = new System.Windows.Forms.DataGridView();
            this.btnRefreshTablespace = new System.Windows.Forms.Button();
            this.groupBoxTablespaceInfo = new System.Windows.Forms.GroupBox();
            this.lblTablespaceInfo = new System.Windows.Forms.Label();
            this.dgvProfile = new System.Windows.Forms.DataGridView();
            this.btnRefreshProfile = new System.Windows.Forms.Button();
            this.groupBoxProfileDetail = new System.Windows.Forms.GroupBox();
            this.lblProfileDetail = new System.Windows.Forms.Label();
            // Profile Management controls
            this.groupBoxProfileManage = new System.Windows.Forms.GroupBox();
            this.txtProfileName = new System.Windows.Forms.TextBox();
            this.lblProfileName = new System.Windows.Forms.Label();
            this.numProfFailedLogin = new System.Windows.Forms.NumericUpDown();
            this.lblProfFailedLogin = new System.Windows.Forms.Label();
            this.numProfLockTime = new System.Windows.Forms.NumericUpDown();
            this.lblProfLockTime = new System.Windows.Forms.Label();
            this.numProfSessions = new System.Windows.Forms.NumericUpDown();
            this.lblProfSessions = new System.Windows.Forms.Label();
            this.numProfIdleTime = new System.Windows.Forms.NumericUpDown();
            this.lblProfIdleTime = new System.Windows.Forms.Label();
            this.numProfConnectTime = new System.Windows.Forms.NumericUpDown();
            this.lblProfConnectTime = new System.Windows.Forms.Label();
            this.btnCreateProfile = new System.Windows.Forms.Button();
            this.btnUpdateProfile = new System.Windows.Forms.Button();
            this.btnDeleteProfile = new System.Windows.Forms.Button();
            this.lstUsersForProfile = new System.Windows.Forms.CheckedListBox();
            this.lblSelectUsers = new System.Windows.Forms.Label();
            this.btnApplyProfileToUsers = new System.Windows.Forms.Button();
            this.dgvSession = new System.Windows.Forms.DataGridView();
            this.btnRefreshSession = new System.Windows.Forms.Button();
            this.btnKillSession = new System.Windows.Forms.Button();
            this.groupBoxSessionInfo = new System.Windows.Forms.GroupBox();
            this.lblSessionInfo = new System.Windows.Forms.Label();
            this.dgvResource = new System.Windows.Forms.DataGridView();
            this.btnRefreshResource = new System.Windows.Forms.Button();
            this.groupBoxResourceInfo = new System.Windows.Forms.GroupBox();
            this.lblResourceInfo = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabTablespace.SuspendLayout();
            this.tabProfile.SuspendLayout();
            this.tabSession.SuspendLayout();
            this.tabResource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablespace)).BeginInit();
            this.groupBoxTablespaceInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfile)).BeginInit();
            this.groupBoxProfileDetail.SuspendLayout();
            this.groupBoxProfileManage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numProfFailedLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProfLockTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProfSessions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProfIdleTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProfConnectTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSession)).BeginInit();
            this.groupBoxSessionInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResource)).BeginInit();
            this.groupBoxResourceInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTablespace);
            this.tabControl.Controls.Add(this.tabProfile);
            this.tabControl.Controls.Add(this.tabSession);
            this.tabControl.Controls.Add(this.tabResource);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1200, 700);
            this.tabControl.TabIndex = 0;
            // 
            // tabTablespace
            // 
            this.tabTablespace.Controls.Add(this.groupBoxTablespaceInfo);
            this.tabTablespace.Controls.Add(this.btnRefreshTablespace);
            this.tabTablespace.Controls.Add(this.dgvTablespace);
            this.tabTablespace.Location = new System.Drawing.Point(4, 26);
            this.tabTablespace.Name = "tabTablespace";
            this.tabTablespace.Padding = new System.Windows.Forms.Padding(10);
            this.tabTablespace.Size = new System.Drawing.Size(1192, 670);
            this.tabTablespace.TabIndex = 0;
            this.tabTablespace.Text = "Tablespace";
            this.tabTablespace.UseVisualStyleBackColor = true;
            // 
            // dgvTablespace
            // 
            this.dgvTablespace.AllowUserToAddRows = false;
            this.dgvTablespace.AllowUserToDeleteRows = false;
            this.dgvTablespace.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTablespace.BackgroundColor = System.Drawing.Color.White;
            this.dgvTablespace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablespace.Location = new System.Drawing.Point(10, 10);
            this.dgvTablespace.Name = "dgvTablespace";
            this.dgvTablespace.ReadOnly = true;
            this.dgvTablespace.RowHeadersWidth = 51;
            this.dgvTablespace.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTablespace.Size = new System.Drawing.Size(1172, 400);
            this.dgvTablespace.TabIndex = 0;
            // 
            // btnRefreshTablespace
            // 
            this.btnRefreshTablespace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefreshTablespace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshTablespace.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefreshTablespace.ForeColor = System.Drawing.Color.White;
            this.btnRefreshTablespace.Location = new System.Drawing.Point(10, 420);
            this.btnRefreshTablespace.Name = "btnRefreshTablespace";
            this.btnRefreshTablespace.Size = new System.Drawing.Size(120, 40);
            this.btnRefreshTablespace.TabIndex = 1;
            this.btnRefreshTablespace.Text = "Làm mới";
            this.btnRefreshTablespace.UseVisualStyleBackColor = false;
            this.btnRefreshTablespace.Click += new System.EventHandler(this.btnRefreshTablespace_Click);
            // 
            // groupBoxTablespaceInfo
            // 
            this.groupBoxTablespaceInfo.Controls.Add(this.lblTablespaceInfo);
            this.groupBoxTablespaceInfo.Location = new System.Drawing.Point(10, 470);
            this.groupBoxTablespaceInfo.Name = "groupBoxTablespaceInfo";
            this.groupBoxTablespaceInfo.Size = new System.Drawing.Size(1172, 190);
            this.groupBoxTablespaceInfo.TabIndex = 2;
            this.groupBoxTablespaceInfo.TabStop = false;
            this.groupBoxTablespaceInfo.Text = "Thông tin chi tiết";
            // 
            // lblTablespaceInfo
            // 
            this.lblTablespaceInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTablespaceInfo.Location = new System.Drawing.Point(3, 22);
            this.lblTablespaceInfo.Name = "lblTablespaceInfo";
            this.lblTablespaceInfo.Size = new System.Drawing.Size(1166, 165);
            this.lblTablespaceInfo.TabIndex = 0;
            this.lblTablespaceInfo.Text = "Chọn một tablespace để xem chi tiết...";
            // 
            // tabProfile
            // 
            this.tabProfile.Controls.Add(this.groupBoxProfileManage);
            this.tabProfile.Controls.Add(this.groupBoxProfileDetail);
            this.tabProfile.Controls.Add(this.btnRefreshProfile);
            this.tabProfile.Controls.Add(this.dgvProfile);
            this.tabProfile.Location = new System.Drawing.Point(4, 26);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Padding = new System.Windows.Forms.Padding(10);
            this.tabProfile.Size = new System.Drawing.Size(1192, 670);
            this.tabProfile.TabIndex = 1;
            this.tabProfile.Text = "Profile";
            this.tabProfile.UseVisualStyleBackColor = true;
            // 
            // dgvProfile
            // 
            this.dgvProfile.AllowUserToAddRows = false;
            this.dgvProfile.AllowUserToDeleteRows = false;
            this.dgvProfile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProfile.BackgroundColor = System.Drawing.Color.White;
            this.dgvProfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProfile.Location = new System.Drawing.Point(10, 10);
            this.dgvProfile.Name = "dgvProfile";
            this.dgvProfile.ReadOnly = true;
            this.dgvProfile.RowHeadersWidth = 51;
            this.dgvProfile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProfile.Size = new System.Drawing.Size(580, 250);
            this.dgvProfile.TabIndex = 0;
            this.dgvProfile.SelectionChanged += new System.EventHandler(this.dgvProfile_SelectionChanged);
            // 
            // btnRefreshProfile
            // 
            this.btnRefreshProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefreshProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshProfile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefreshProfile.ForeColor = System.Drawing.Color.White;
            this.btnRefreshProfile.Location = new System.Drawing.Point(10, 265);
            this.btnRefreshProfile.Name = "btnRefreshProfile";
            this.btnRefreshProfile.Size = new System.Drawing.Size(120, 35);
            this.btnRefreshProfile.TabIndex = 1;
            this.btnRefreshProfile.Text = "Làm mới";
            this.btnRefreshProfile.UseVisualStyleBackColor = false;
            this.btnRefreshProfile.Click += new System.EventHandler(this.btnRefreshProfile_Click);
            // 
            // groupBoxProfileDetail
            // 
            this.groupBoxProfileDetail.Controls.Add(this.lblProfileDetail);
            this.groupBoxProfileDetail.Location = new System.Drawing.Point(10, 305);
            this.groupBoxProfileDetail.Name = "groupBoxProfileDetail";
            this.groupBoxProfileDetail.Size = new System.Drawing.Size(580, 355);
            this.groupBoxProfileDetail.TabIndex = 2;
            this.groupBoxProfileDetail.TabStop = false;
            this.groupBoxProfileDetail.Text = "Chi tiết Profile đã chọn";
            // 
            // lblProfileDetail
            // 
            this.lblProfileDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProfileDetail.Location = new System.Drawing.Point(3, 22);
            this.lblProfileDetail.Name = "lblProfileDetail";
            this.lblProfileDetail.Size = new System.Drawing.Size(574, 330);
            this.lblProfileDetail.TabIndex = 0;
            this.lblProfileDetail.Text = "Chọn một profile để xem chi tiết...";
            // 
            // groupBoxProfileManage - Quản lý Profile
            // 
            this.groupBoxProfileManage.Controls.Add(this.lblProfileName);
            this.groupBoxProfileManage.Controls.Add(this.txtProfileName);
            this.groupBoxProfileManage.Controls.Add(this.lblProfFailedLogin);
            this.groupBoxProfileManage.Controls.Add(this.numProfFailedLogin);
            this.groupBoxProfileManage.Controls.Add(this.lblProfLockTime);
            this.groupBoxProfileManage.Controls.Add(this.numProfLockTime);
            this.groupBoxProfileManage.Controls.Add(this.lblProfSessions);
            this.groupBoxProfileManage.Controls.Add(this.numProfSessions);
            this.groupBoxProfileManage.Controls.Add(this.lblProfIdleTime);
            this.groupBoxProfileManage.Controls.Add(this.numProfIdleTime);
            this.groupBoxProfileManage.Controls.Add(this.lblProfConnectTime);
            this.groupBoxProfileManage.Controls.Add(this.numProfConnectTime);
            this.groupBoxProfileManage.Controls.Add(this.btnCreateProfile);
            this.groupBoxProfileManage.Controls.Add(this.btnUpdateProfile);
            this.groupBoxProfileManage.Controls.Add(this.btnDeleteProfile);
            this.groupBoxProfileManage.Controls.Add(this.lblSelectUsers);
            this.groupBoxProfileManage.Controls.Add(this.lstUsersForProfile);
            this.groupBoxProfileManage.Controls.Add(this.btnApplyProfileToUsers);
            this.groupBoxProfileManage.Location = new System.Drawing.Point(600, 10);
            this.groupBoxProfileManage.Name = "groupBoxProfileManage";
            this.groupBoxProfileManage.Size = new System.Drawing.Size(582, 650);
            this.groupBoxProfileManage.TabIndex = 3;
            this.groupBoxProfileManage.TabStop = false;
            this.groupBoxProfileManage.Text = "Quản lý Profile";
            // 
            // lblProfileName
            // 
            this.lblProfileName.AutoSize = true;
            this.lblProfileName.Location = new System.Drawing.Point(15, 30);
            this.lblProfileName.Name = "lblProfileName";
            this.lblProfileName.Size = new System.Drawing.Size(100, 19);
            this.lblProfileName.Text = "Tên Profile:";
            // 
            // txtProfileName
            // 
            this.txtProfileName.Location = new System.Drawing.Point(200, 27);
            this.txtProfileName.Name = "txtProfileName";
            this.txtProfileName.Size = new System.Drawing.Size(200, 25);
            this.txtProfileName.TabIndex = 0;
            this.txtProfileName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // lblProfFailedLogin
            // 
            this.lblProfFailedLogin.AutoSize = true;
            this.lblProfFailedLogin.Location = new System.Drawing.Point(15, 65);
            this.lblProfFailedLogin.Name = "lblProfFailedLogin";
            this.lblProfFailedLogin.Size = new System.Drawing.Size(130, 19);
            this.lblProfFailedLogin.Text = "Đăng nhập sai tối đa:";
            // 
            // numProfFailedLogin
            // 
            this.numProfFailedLogin.Location = new System.Drawing.Point(200, 62);
            this.numProfFailedLogin.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numProfFailedLogin.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numProfFailedLogin.Name = "numProfFailedLogin";
            this.numProfFailedLogin.Size = new System.Drawing.Size(80, 25);
            this.numProfFailedLogin.TabIndex = 1;
            this.numProfFailedLogin.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lblProfLockTime
            // 
            this.lblProfLockTime.AutoSize = true;
            this.lblProfLockTime.Location = new System.Drawing.Point(15, 100);
            this.lblProfLockTime.Name = "lblProfLockTime";
            this.lblProfLockTime.Size = new System.Drawing.Size(120, 19);
            this.lblProfLockTime.Text = "Thời gian khóa (phút):";
            // 
            // numProfLockTime
            // 
            this.numProfLockTime.Location = new System.Drawing.Point(200, 97);
            this.numProfLockTime.Maximum = new decimal(new int[] { 10080, 0, 0, 0 });
            this.numProfLockTime.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numProfLockTime.Name = "numProfLockTime";
            this.numProfLockTime.Size = new System.Drawing.Size(80, 25);
            this.numProfLockTime.TabIndex = 2;
            this.numProfLockTime.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // lblProfSessions
            // 
            this.lblProfSessions.AutoSize = true;
            this.lblProfSessions.Location = new System.Drawing.Point(15, 135);
            this.lblProfSessions.Name = "lblProfSessions";
            this.lblProfSessions.Size = new System.Drawing.Size(130, 19);
            this.lblProfSessions.Text = "Số session tối đa:";
            // 
            // numProfSessions
            // 
            this.numProfSessions.Location = new System.Drawing.Point(200, 132);
            this.numProfSessions.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numProfSessions.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numProfSessions.Name = "numProfSessions";
            this.numProfSessions.Size = new System.Drawing.Size(80, 25);
            this.numProfSessions.TabIndex = 3;
            this.numProfSessions.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // lblProfIdleTime
            // 
            this.lblProfIdleTime.AutoSize = true;
            this.lblProfIdleTime.Location = new System.Drawing.Point(15, 170);
            this.lblProfIdleTime.Name = "lblProfIdleTime";
            this.lblProfIdleTime.Size = new System.Drawing.Size(130, 19);
            this.lblProfIdleTime.Text = "Idle timeout (phút):";
            // 
            // numProfIdleTime
            // 
            this.numProfIdleTime.Location = new System.Drawing.Point(200, 167);
            this.numProfIdleTime.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            this.numProfIdleTime.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numProfIdleTime.Name = "numProfIdleTime";
            this.numProfIdleTime.Size = new System.Drawing.Size(80, 25);
            this.numProfIdleTime.TabIndex = 4;
            this.numProfIdleTime.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // lblProfConnectTime
            // 
            this.lblProfConnectTime.AutoSize = true;
            this.lblProfConnectTime.Location = new System.Drawing.Point(15, 205);
            this.lblProfConnectTime.Name = "lblProfConnectTime";
            this.lblProfConnectTime.Size = new System.Drawing.Size(130, 19);
            this.lblProfConnectTime.Text = "Kết nối tối đa (phút):";
            // 
            // numProfConnectTime
            // 
            this.numProfConnectTime.Location = new System.Drawing.Point(200, 202);
            this.numProfConnectTime.Maximum = new decimal(new int[] { 10080, 0, 0, 0 });
            this.numProfConnectTime.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numProfConnectTime.Name = "numProfConnectTime";
            this.numProfConnectTime.Size = new System.Drawing.Size(80, 25);
            this.numProfConnectTime.TabIndex = 5;
            this.numProfConnectTime.Value = new decimal(new int[] { 480, 0, 0, 0 });
            // 
            // btnCreateProfile
            // 
            this.btnCreateProfile.Location = new System.Drawing.Point(200, 245);
            this.btnCreateProfile.Name = "btnCreateProfile";
            this.btnCreateProfile.Size = new System.Drawing.Size(100, 30);
            this.btnCreateProfile.TabIndex = 6;
            this.btnCreateProfile.Text = "Tạo mới";
            this.btnCreateProfile.UseVisualStyleBackColor = true;
            this.btnCreateProfile.Click += new System.EventHandler(this.btnCreateProfile_Click);
            // 
            // btnUpdateProfile
            // 
            this.btnUpdateProfile.Location = new System.Drawing.Point(310, 245);
            this.btnUpdateProfile.Name = "btnUpdateProfile";
            this.btnUpdateProfile.Size = new System.Drawing.Size(100, 30);
            this.btnUpdateProfile.TabIndex = 7;
            this.btnUpdateProfile.Text = "Cập nhật";
            this.btnUpdateProfile.UseVisualStyleBackColor = true;
            this.btnUpdateProfile.Click += new System.EventHandler(this.btnUpdateProfile_Click);
            // 
            // btnDeleteProfile
            // 
            this.btnDeleteProfile.Location = new System.Drawing.Point(420, 245);
            this.btnDeleteProfile.Name = "btnDeleteProfile";
            this.btnDeleteProfile.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteProfile.TabIndex = 8;
            this.btnDeleteProfile.Text = "Xóa";
            this.btnDeleteProfile.UseVisualStyleBackColor = true;
            this.btnDeleteProfile.Click += new System.EventHandler(this.btnDeleteProfile_Click);
            // 
            // lblSelectUsers
            // 
            this.lblSelectUsers.AutoSize = true;
            this.lblSelectUsers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSelectUsers.Location = new System.Drawing.Point(15, 295);
            this.lblSelectUsers.Name = "lblSelectUsers";
            this.lblSelectUsers.Size = new System.Drawing.Size(200, 19);
            this.lblSelectUsers.Text = "Chọn Users để áp dụng Profile:";
            // 
            // lstUsersForProfile
            // 
            this.lstUsersForProfile.CheckOnClick = true;
            this.lstUsersForProfile.FormattingEnabled = true;
            this.lstUsersForProfile.Location = new System.Drawing.Point(15, 320);
            this.lstUsersForProfile.Name = "lstUsersForProfile";
            this.lstUsersForProfile.Size = new System.Drawing.Size(550, 270);
            this.lstUsersForProfile.TabIndex = 9;
            // 
            // btnApplyProfileToUsers
            // 
            this.btnApplyProfileToUsers.Location = new System.Drawing.Point(15, 600);
            this.btnApplyProfileToUsers.Name = "btnApplyProfileToUsers";
            this.btnApplyProfileToUsers.Size = new System.Drawing.Size(250, 30);
            this.btnApplyProfileToUsers.TabIndex = 10;
            this.btnApplyProfileToUsers.Text = "Áp dụng Profile cho Users đã chọn";
            this.btnApplyProfileToUsers.UseVisualStyleBackColor = true;
            this.btnApplyProfileToUsers.Click += new System.EventHandler(this.btnApplyProfileToUsers_Click);
            // 
            // tabSession
            // 
            this.tabSession.Controls.Add(this.groupBoxSessionInfo);
            this.tabSession.Controls.Add(this.btnKillSession);
            this.tabSession.Controls.Add(this.btnRefreshSession);
            this.tabSession.Controls.Add(this.dgvSession);
            this.tabSession.Location = new System.Drawing.Point(4, 26);
            this.tabSession.Name = "tabSession";
            this.tabSession.Padding = new System.Windows.Forms.Padding(10);
            this.tabSession.Size = new System.Drawing.Size(1192, 670);
            this.tabSession.TabIndex = 2;
            this.tabSession.Text = "Session";
            this.tabSession.UseVisualStyleBackColor = true;
            // 
            // dgvSession
            // 
            this.dgvSession.AllowUserToAddRows = false;
            this.dgvSession.AllowUserToDeleteRows = false;
            this.dgvSession.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSession.BackgroundColor = System.Drawing.Color.White;
            this.dgvSession.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSession.Location = new System.Drawing.Point(10, 10);
            this.dgvSession.Name = "dgvSession";
            this.dgvSession.ReadOnly = true;
            this.dgvSession.RowHeadersWidth = 51;
            this.dgvSession.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSession.Size = new System.Drawing.Size(1172, 400);
            this.dgvSession.TabIndex = 0;
            // 
            // btnRefreshSession
            // 
            this.btnRefreshSession.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefreshSession.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshSession.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefreshSession.ForeColor = System.Drawing.Color.White;
            this.btnRefreshSession.Location = new System.Drawing.Point(10, 420);
            this.btnRefreshSession.Name = "btnRefreshSession";
            this.btnRefreshSession.Size = new System.Drawing.Size(120, 40);
            this.btnRefreshSession.TabIndex = 1;
            this.btnRefreshSession.Text = "Làm mới";
            this.btnRefreshSession.UseVisualStyleBackColor = false;
            this.btnRefreshSession.Click += new System.EventHandler(this.btnRefreshSession_Click);
            // 
            // btnKillSession
            // 
            this.btnKillSession.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnKillSession.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKillSession.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKillSession.ForeColor = System.Drawing.Color.White;
            this.btnKillSession.Location = new System.Drawing.Point(140, 420);
            this.btnKillSession.Name = "btnKillSession";
            this.btnKillSession.Size = new System.Drawing.Size(140, 40);
            this.btnKillSession.TabIndex = 2;
            this.btnKillSession.Text = "Kill Session";
            this.btnKillSession.UseVisualStyleBackColor = false;
            this.btnKillSession.Click += new System.EventHandler(this.btnKillSession_Click);
            // 
            // groupBoxSessionInfo
            // 
            this.groupBoxSessionInfo.Controls.Add(this.lblSessionInfo);
            this.groupBoxSessionInfo.Location = new System.Drawing.Point(10, 470);
            this.groupBoxSessionInfo.Name = "groupBoxSessionInfo";
            this.groupBoxSessionInfo.Size = new System.Drawing.Size(1172, 190);
            this.groupBoxSessionInfo.TabIndex = 3;
            this.groupBoxSessionInfo.TabStop = false;
            this.groupBoxSessionInfo.Text = "Thông tin Session";
            // 
            // lblSessionInfo
            // 
            this.lblSessionInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSessionInfo.Location = new System.Drawing.Point(3, 22);
            this.lblSessionInfo.Name = "lblSessionInfo";
            this.lblSessionInfo.Size = new System.Drawing.Size(1166, 165);
            this.lblSessionInfo.TabIndex = 0;
            this.lblSessionInfo.Text = "Chọn một session để xem chi tiết...";
            // 
            // tabResource
            // 
            this.tabResource.Controls.Add(this.groupBoxResourceInfo);
            this.tabResource.Controls.Add(this.btnRefreshResource);
            this.tabResource.Controls.Add(this.dgvResource);
            this.tabResource.Location = new System.Drawing.Point(4, 26);
            this.tabResource.Name = "tabResource";
            this.tabResource.Padding = new System.Windows.Forms.Padding(10);
            this.tabResource.Size = new System.Drawing.Size(1192, 670);
            this.tabResource.TabIndex = 3;
            this.tabResource.Text = "Resource";
            this.tabResource.UseVisualStyleBackColor = true;
            // 
            // dgvResource
            // 
            this.dgvResource.AllowUserToAddRows = false;
            this.dgvResource.AllowUserToDeleteRows = false;
            this.dgvResource.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResource.BackgroundColor = System.Drawing.Color.White;
            this.dgvResource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResource.Location = new System.Drawing.Point(10, 10);
            this.dgvResource.Name = "dgvResource";
            this.dgvResource.ReadOnly = true;
            this.dgvResource.RowHeadersWidth = 51;
            this.dgvResource.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResource.Size = new System.Drawing.Size(1172, 400);
            this.dgvResource.TabIndex = 0;
            // 
            // btnRefreshResource
            // 
            this.btnRefreshResource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefreshResource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshResource.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefreshResource.ForeColor = System.Drawing.Color.White;
            this.btnRefreshResource.Location = new System.Drawing.Point(10, 420);
            this.btnRefreshResource.Name = "btnRefreshResource";
            this.btnRefreshResource.Size = new System.Drawing.Size(120, 40);
            this.btnRefreshResource.TabIndex = 1;
            this.btnRefreshResource.Text = "Làm mới";
            this.btnRefreshResource.UseVisualStyleBackColor = false;
            this.btnRefreshResource.Click += new System.EventHandler(this.btnRefreshResource_Click);
            // 
            // groupBoxResourceInfo
            // 
            this.groupBoxResourceInfo.Controls.Add(this.lblResourceInfo);
            this.groupBoxResourceInfo.Location = new System.Drawing.Point(10, 470);
            this.groupBoxResourceInfo.Name = "groupBoxResourceInfo";
            this.groupBoxResourceInfo.Size = new System.Drawing.Size(1172, 190);
            this.groupBoxResourceInfo.TabIndex = 2;
            this.groupBoxResourceInfo.TabStop = false;
            this.groupBoxResourceInfo.Text = "Thông tin Resource";
            // 
            // lblResourceInfo
            // 
            this.lblResourceInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResourceInfo.Location = new System.Drawing.Point(3, 22);
            this.lblResourceInfo.Name = "lblResourceInfo";
            this.lblResourceInfo.Size = new System.Drawing.Size(1166, 165);
            this.lblResourceInfo.TabIndex = 0;
            this.lblResourceInfo.Text = "Thông tin tài nguyên hệ thống...";
            // 
            // SystemConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SystemConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu hình Hệ thống - Tablespace, Profile, Session, Resource";
            this.Load += new System.EventHandler(this.SystemConfigForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabTablespace.ResumeLayout(false);
            this.tabProfile.ResumeLayout(false);
            this.tabSession.ResumeLayout(false);
            this.tabResource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablespace)).EndInit();
            this.groupBoxTablespaceInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfile)).EndInit();
            this.groupBoxProfileDetail.ResumeLayout(false);
            this.groupBoxProfileManage.ResumeLayout(false);
            this.groupBoxProfileManage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numProfFailedLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProfLockTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProfSessions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProfIdleTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProfConnectTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSession)).EndInit();
            this.groupBoxSessionInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResource)).EndInit();
            this.groupBoxResourceInfo.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabTablespace;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.TabPage tabSession;
        private System.Windows.Forms.TabPage tabResource;
        private System.Windows.Forms.DataGridView dgvTablespace;
        private System.Windows.Forms.Button btnRefreshTablespace;
        private System.Windows.Forms.GroupBox groupBoxTablespaceInfo;
        private System.Windows.Forms.Label lblTablespaceInfo;
        private System.Windows.Forms.DataGridView dgvProfile;
        private System.Windows.Forms.Button btnRefreshProfile;
        private System.Windows.Forms.GroupBox groupBoxProfileDetail;
        private System.Windows.Forms.Label lblProfileDetail;
        // Profile Management controls
        private System.Windows.Forms.GroupBox groupBoxProfileManage;
        private System.Windows.Forms.TextBox txtProfileName;
        private System.Windows.Forms.Label lblProfileName;
        private System.Windows.Forms.NumericUpDown numProfFailedLogin;
        private System.Windows.Forms.Label lblProfFailedLogin;
        private System.Windows.Forms.NumericUpDown numProfLockTime;
        private System.Windows.Forms.Label lblProfLockTime;
        private System.Windows.Forms.NumericUpDown numProfSessions;
        private System.Windows.Forms.Label lblProfSessions;
        private System.Windows.Forms.NumericUpDown numProfIdleTime;
        private System.Windows.Forms.Label lblProfIdleTime;
        private System.Windows.Forms.NumericUpDown numProfConnectTime;
        private System.Windows.Forms.Label lblProfConnectTime;
        private System.Windows.Forms.Button btnCreateProfile;
        private System.Windows.Forms.Button btnUpdateProfile;
        private System.Windows.Forms.Button btnDeleteProfile;
        private System.Windows.Forms.CheckedListBox lstUsersForProfile;
        private System.Windows.Forms.Label lblSelectUsers;
        private System.Windows.Forms.Button btnApplyProfileToUsers;
        private System.Windows.Forms.DataGridView dgvSession;
        private System.Windows.Forms.Button btnRefreshSession;
        private System.Windows.Forms.Button btnKillSession;
        private System.Windows.Forms.GroupBox groupBoxSessionInfo;
        private System.Windows.Forms.Label lblSessionInfo;
        private System.Windows.Forms.DataGridView dgvResource;
        private System.Windows.Forms.Button btnRefreshResource;
        private System.Windows.Forms.GroupBox groupBoxResourceInfo;
        private System.Windows.Forms.Label lblResourceInfo;
    }
}
