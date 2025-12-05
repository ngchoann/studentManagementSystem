namespace StudentManagementSystem.Forms
{
    partial class MainDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _aesKeys?.Clear();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Text = "Hệ thống Quản lý - " + _username + " (" + _role + ")";
            this.Size = new System.Drawing.Size(1000, 700);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            // Menu
            menuStrip = new System.Windows.Forms.MenuStrip();
            var mnuData = new System.Windows.Forms.ToolStripMenuItem("Dữ liệu");
            mnuData.DropDownItems.Add("Xem dữ liệu", null, MnuViewData_Click);
            mnuData.DropDownItems.Add("Thêm dữ liệu", null, MnuAddData_Click);

            var mnuAdmin = new System.Windows.Forms.ToolStripMenuItem("Quản trị");
            mnuAdmin.DropDownItems.Add("Tạo user mới", null, MnuCreateUser_Click);
            mnuAdmin.DropDownItems.Add("Export Private Key", null, MnuExportKey_Click);

            var mnuHelp = new System.Windows.Forms.ToolStripMenuItem("Trợ giúp");
            mnuHelp.DropDownItems.Add("Thông tin", null, MnuAbout_Click);
            mnuHelp.DropDownItems.Add("Đăng xuất", null, MnuLogout_Click);

            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] { mnuData, mnuAdmin, mnuHelp });
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);

            // Main Panel
            pnlMain = new System.Windows.Forms.Panel();
            pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlMain.Padding = new System.Windows.Forms.Padding(10);

            var lblWelcome = new System.Windows.Forms.Label();
            lblWelcome.Text = "Chào mừng " + _username + "!\nVai trò: " + _role;
            lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblWelcome.Location = new System.Drawing.Point(20, 40);
            lblWelcome.Size = new System.Drawing.Size(500, 50);
            lblWelcome.ForeColor = System.Drawing.Color.DarkGreen;
            pnlMain.Controls.Add(lblWelcome);

            // Buttons
            var btnLoadData = new System.Windows.Forms.Button();
            btnLoadData.Text = "Tải dữ liệu";
            btnLoadData.Location = new System.Drawing.Point(20, 100);
            btnLoadData.Size = new System.Drawing.Size(120, 30);
            btnLoadData.Click += BtnLoadData_Click;
            pnlMain.Controls.Add(btnLoadData);

            var btnAddData = new System.Windows.Forms.Button();
            btnAddData.Text = "Thêm dữ liệu";
            btnAddData.Location = new System.Drawing.Point(150, 100);
            btnAddData.Size = new System.Drawing.Size(120, 30);
            btnAddData.Click += BtnAddData_Click;
            pnlMain.Controls.Add(btnAddData);

            // DataGridView
            dgvData = new System.Windows.Forms.DataGridView();
            dgvData.Location = new System.Drawing.Point(20, 150);
            dgvData.Size = new System.Drawing.Size(800, 350);
            dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvData.ReadOnly = true;
            dgvData.AllowUserToAddRows = false;
            pnlMain.Controls.Add(dgvData);

            // Status
            lblStatus = new System.Windows.Forms.Label();
            lblStatus.Location = new System.Drawing.Point(20, 510);
            lblStatus.Size = new System.Drawing.Size(800, 30);
            lblStatus.ForeColor = System.Drawing.Color.Blue;
            pnlMain.Controls.Add(lblStatus);

            this.Controls.Add(pnlMain);

            // Locked Panel
            pnlLocked = new System.Windows.Forms.Panel();
            pnlLocked.BackColor = System.Drawing.Color.FromArgb(200, 128, 128, 128);
            pnlLocked.Dock = System.Windows.Forms.DockStyle.Fill;
            var lblLocked = new System.Windows.Forms.Label();
            lblLocked.Text = "HỆ THỐNG BỊ KHÓA\nVui lòng upload private key";
            lblLocked.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblLocked.ForeColor = System.Drawing.Color.Red;
            lblLocked.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblLocked.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlLocked.Controls.Add(lblLocked);
            this.Controls.Add(pnlLocked);
            pnlLocked.BringToFront();
        }

        // Controls
        private System.Windows.Forms.MenuStrip menuStrip = null!;
        private System.Windows.Forms.Panel pnlMain = null!;
        private System.Windows.Forms.Panel pnlLocked = null!;
        private System.Windows.Forms.Label lblStatus = null!;
        private System.Windows.Forms.DataGridView dgvData = null!;
    }
}
