namespace StudentManagementSystem.Forms
{
    partial class MACSecurityForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                connection?.Close();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Size = new System.Drawing.Size(1000, 700);
            this.Text = "MAC Security Management System";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            tabControl = new System.Windows.Forms.TabControl();
            tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl.Font = new System.Drawing.Font("Segoe UI", 9F);

            CreateUserClearancesTab();
            CreatePoliciesTab();
            CreateAuditTab();
            CreateSecurityLevelsTab();

            this.Controls.Add(tabControl);

            lblStatus = new System.Windows.Forms.Label();
            lblStatus.Text = "Ready";
            lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblStatus.BackColor = System.Drawing.Color.LightGray;
            lblStatus.Padding = new System.Windows.Forms.Padding(5);
            lblStatus.Height = 25;
            this.Controls.Add(lblStatus);
        }

        private void CreateUserClearancesTab()
        {
            var tab = new System.Windows.Forms.TabPage("User Security Clearances");
            var panel = new System.Windows.Forms.Panel();
            panel.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Padding = new System.Windows.Forms.Padding(10);

            var controlsPanel = new System.Windows.Forms.Panel();
            controlsPanel.Height = 80;
            controlsPanel.Dock = System.Windows.Forms.DockStyle.Top;

            var lblUser = new System.Windows.Forms.Label();
            lblUser.Text = "User:";
            lblUser.Location = new System.Drawing.Point(10, 15);
            lblUser.Size = new System.Drawing.Size(40, 20);

            cmbUsers = new System.Windows.Forms.ComboBox();
            cmbUsers.Location = new System.Drawing.Point(60, 12);
            cmbUsers.Size = new System.Drawing.Size(150, 25);
            cmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cmbUsers.SelectedIndexChanged += CmbUsers_SelectedIndexChanged;

            var lblLevel = new System.Windows.Forms.Label();
            lblLevel.Text = "Security Level:";
            lblLevel.Location = new System.Drawing.Point(230, 15);
            lblLevel.Size = new System.Drawing.Size(80, 20);

            cmbSecurityLevels = new System.Windows.Forms.ComboBox();
            cmbSecurityLevels.Location = new System.Drawing.Point(320, 12);
            cmbSecurityLevels.Size = new System.Drawing.Size(120, 25);
            cmbSecurityLevels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            btnSetClearance = new System.Windows.Forms.Button();
            btnSetClearance.Text = "Set Clearance";
            btnSetClearance.Location = new System.Drawing.Point(460, 12);
            btnSetClearance.Size = new System.Drawing.Size(100, 25);
            btnSetClearance.BackColor = System.Drawing.Color.LightBlue;
            btnSetClearance.Click += BtnSetClearance_Click;

            btnRefresh = new System.Windows.Forms.Button();
            btnRefresh.Text = "Refresh";
            btnRefresh.Location = new System.Drawing.Point(580, 12);
            btnRefresh.Size = new System.Drawing.Size(80, 25);
            btnRefresh.BackColor = System.Drawing.Color.LightGreen;
            btnRefresh.Click += delegate { LoadUserClearances(); };

            controlsPanel.Controls.Add(lblUser);
            controlsPanel.Controls.Add(cmbUsers);
            controlsPanel.Controls.Add(lblLevel);
            controlsPanel.Controls.Add(cmbSecurityLevels);
            controlsPanel.Controls.Add(btnSetClearance);
            controlsPanel.Controls.Add(btnRefresh);

            dgvUserClearances = new System.Windows.Forms.DataGridView();
            dgvUserClearances.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvUserClearances.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvUserClearances.ReadOnly = true;
            dgvUserClearances.AllowUserToAddRows = false;
            dgvUserClearances.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvUserClearances.CellClick += DgvUserClearances_CellClick;

            panel.Controls.Add(dgvUserClearances);
            panel.Controls.Add(controlsPanel);
            tab.Controls.Add(panel);
            tabControl.TabPages.Add(tab);
        }

        private void CreatePoliciesTab()
        {
            var tab = new System.Windows.Forms.TabPage("MAC Table Policies");
            var panel = new System.Windows.Forms.Panel();
            panel.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Padding = new System.Windows.Forms.Padding(10);

            var controlsPanel = new System.Windows.Forms.Panel();
            controlsPanel.Height = 80;
            controlsPanel.Dock = System.Windows.Forms.DockStyle.Top;

            var lblTable = new System.Windows.Forms.Label();
            lblTable.Text = "Table Name:";
            lblTable.Location = new System.Drawing.Point(10, 15);
            lblTable.Size = new System.Drawing.Size(70, 20);

            txtTableName = new System.Windows.Forms.TextBox();
            txtTableName.Location = new System.Drawing.Point(90, 12);
            txtTableName.Size = new System.Drawing.Size(120, 25);

            var lblPolicy = new System.Windows.Forms.Label();
            lblPolicy.Text = "Policy Name:";
            lblPolicy.Location = new System.Drawing.Point(230, 15);
            lblPolicy.Size = new System.Drawing.Size(70, 20);

            txtPolicyName = new System.Windows.Forms.TextBox();
            txtPolicyName.Location = new System.Drawing.Point(310, 12);
            txtPolicyName.Size = new System.Drawing.Size(120, 25);

            btnCreatePolicy = new System.Windows.Forms.Button();
            btnCreatePolicy.Text = "Create Policy";
            btnCreatePolicy.Location = new System.Drawing.Point(450, 12);
            btnCreatePolicy.Size = new System.Drawing.Size(100, 25);
            btnCreatePolicy.BackColor = System.Drawing.Color.LightBlue;
            btnCreatePolicy.Click += BtnCreatePolicy_Click;

            btnDropPolicy = new System.Windows.Forms.Button();
            btnDropPolicy.Text = "Drop Policy";
            btnDropPolicy.Location = new System.Drawing.Point(570, 12);
            btnDropPolicy.Size = new System.Drawing.Size(100, 25);
            btnDropPolicy.BackColor = System.Drawing.Color.LightCoral;
            btnDropPolicy.Click += BtnDropPolicy_Click;

            controlsPanel.Controls.Add(lblTable);
            controlsPanel.Controls.Add(txtTableName);
            controlsPanel.Controls.Add(lblPolicy);
            controlsPanel.Controls.Add(txtPolicyName);
            controlsPanel.Controls.Add(btnCreatePolicy);
            controlsPanel.Controls.Add(btnDropPolicy);

            dgvTablePolicies = new System.Windows.Forms.DataGridView();
            dgvTablePolicies.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvTablePolicies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvTablePolicies.ReadOnly = true;
            dgvTablePolicies.AllowUserToAddRows = false;
            dgvTablePolicies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            panel.Controls.Add(dgvTablePolicies);
            panel.Controls.Add(controlsPanel);
            tab.Controls.Add(panel);
            tabControl.TabPages.Add(tab);
        }

        private void CreateAuditTab()
        {
            var tab = new System.Windows.Forms.TabPage("MAC Audit Log");
            var panel = new System.Windows.Forms.Panel();
            panel.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Padding = new System.Windows.Forms.Padding(10);

            dgvAuditLog = new System.Windows.Forms.DataGridView();
            dgvAuditLog.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvAuditLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvAuditLog.ReadOnly = true;
            dgvAuditLog.AllowUserToAddRows = false;
            dgvAuditLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            panel.Controls.Add(dgvAuditLog);
            tab.Controls.Add(panel);
            tabControl.TabPages.Add(tab);
        }

        private void CreateSecurityLevelsTab()
        {
            var tab = new System.Windows.Forms.TabPage("Security Levels");
            var panel = new System.Windows.Forms.Panel();
            panel.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Padding = new System.Windows.Forms.Padding(10);

            var txtInfo = new System.Windows.Forms.RichTextBox();
            txtInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            txtInfo.ReadOnly = true;
            txtInfo.Font = new System.Drawing.Font("Consolas", 10F);
            txtInfo.Text = "MAC SECURITY LEVELS HIERARCHY\r\n\r\n" +
                "Level 4: TOP_SECRET (40) - Full access, Admin\r\n" +
                "Level 3: SECRET (30) - Access to SECRET and below\r\n" +
                "Level 2: CONFIDENTIAL (20) - Access to CONFIDENTIAL and PUBLIC\r\n" +
                "Level 1: PUBLIC (10) - Public data only\r\n\r\n" +
                "RULES:\r\n" +
                "• No Read Up: Cannot read higher classifications\r\n" +
                "• No Write Down: Cannot declassify data\r\n\r\n" +
                "STATUS: MAC Policies Active";

            panel.Controls.Add(txtInfo);
            tab.Controls.Add(panel);
            tabControl.TabPages.Add(tab);
        }

        private Oracle.ManagedDataAccess.Client.OracleConnection connection = null!;
        private System.Windows.Forms.DataGridView dgvUserClearances = null!;
        private System.Windows.Forms.DataGridView dgvTablePolicies = null!;
        private System.Windows.Forms.DataGridView dgvAuditLog = null!;
        private System.Windows.Forms.TabControl tabControl = null!;
        private System.Windows.Forms.ComboBox cmbSecurityLevels = null!;
        private System.Windows.Forms.ComboBox cmbUsers = null!;
        private System.Windows.Forms.TextBox txtTableName = null!;
        private System.Windows.Forms.TextBox txtPolicyName = null!;
        private System.Windows.Forms.Button btnSetClearance = null!;
        private System.Windows.Forms.Button btnCreatePolicy = null!;
        private System.Windows.Forms.Button btnDropPolicy = null!;
        private System.Windows.Forms.Button btnRefresh = null!;
        private System.Windows.Forms.Label lblStatus = null!;
    }
}
