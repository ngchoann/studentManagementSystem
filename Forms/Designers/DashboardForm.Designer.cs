namespace StudentManagementSystem.Forms
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnMACSystem;
        private System.Windows.Forms.Button btnAuditingSystem;
        private System.Windows.Forms.Button btnBackupRecovery;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnMACSystem = new System.Windows.Forms.Button();
            this.btnAuditingSystem = new System.Windows.Forms.Button();
            this.btnBackupRecovery = new System.Windows.Forms.Button();
            this.btnSystemConfig = new System.Windows.Forms.Button();
            this.btnQuanLyDiem = new System.Windows.Forms.Button();
            this.btnQuanLyHocPhan = new System.Windows.Forms.Button();
            this.btnQuanLyLop = new System.Windows.Forms.Button();
            this.btnQuanLyGiaoVien = new System.Windows.Forms.Button();
            this.btnQuanLySinhVien = new System.Windows.Forms.Button();
            this.panelStats = new System.Windows.Forms.Panel();
            this.groupBoxStats = new System.Windows.Forms.GroupBox();
            this.lblTotalHocPhan = new System.Windows.Forms.Label();
            this.lblTotalLop = new System.Windows.Forms.Label();
            this.lblTotalGiaoVien = new System.Windows.Forms.Label();
            this.lblTotalSinhVien = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.groupBoxStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.Control;
            this.panelTop.Controls.Add(this.btnLogout);
            this.panelTop.Controls.Add(this.lblUserInfo);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 80);
            this.panelTop.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.SystemColors.Control;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLogout.Location = new System.Drawing.Point(1050, 25);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(120, 35);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Dang xuat";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUserInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUserInfo.Location = new System.Drawing.Point(850, 50);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(320, 25);
            this.lblUserInfo.TabIndex = 1;
            this.lblUserInfo.Text = "Nguoi dung: Admin";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HE THONG QUAN LY SINH VIEN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.Control;
            this.panelMenu.Controls.Add(this.btnBackupRecovery);
            this.panelMenu.Controls.Add(this.btnAuditingSystem);
            this.panelMenu.Controls.Add(this.btnMACSystem);
            this.panelMenu.Controls.Add(this.btnSystemConfig);
            this.panelMenu.Controls.Add(this.btnQuanLyDiem);
            this.panelMenu.Controls.Add(this.btnQuanLyHocPhan);
            this.panelMenu.Controls.Add(this.btnQuanLyLop);
            this.panelMenu.Controls.Add(this.btnQuanLyGiaoVien);
            this.panelMenu.Controls.Add(this.btnQuanLySinhVien);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 80);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(250, 520);
            this.panelMenu.TabIndex = 1;
            // 
            // btnMACSystem
            // 
            this.btnMACSystem.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnMACSystem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMACSystem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMACSystem.Location = new System.Drawing.Point(10, 320);
            this.btnMACSystem.Name = "btnMACSystem";
            this.btnMACSystem.Size = new System.Drawing.Size(230, 40);
            this.btnMACSystem.TabIndex = 8;
            this.btnMACSystem.Text = "MAC Security System";
            this.btnMACSystem.UseVisualStyleBackColor = true;
            this.btnMACSystem.Click += new System.EventHandler(this.btnMACSystem_Click);
            // 
            // btnAuditingSystem
            // 
            this.btnAuditingSystem.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnAuditingSystem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAuditingSystem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAuditingSystem.Location = new System.Drawing.Point(10, 370);
            this.btnAuditingSystem.Name = "btnAuditingSystem";
            this.btnAuditingSystem.Size = new System.Drawing.Size(230, 40);
            this.btnAuditingSystem.TabIndex = 7;
            this.btnAuditingSystem.Text = "Auditing & Logging";
            this.btnAuditingSystem.UseVisualStyleBackColor = true;
            this.btnAuditingSystem.Click += new System.EventHandler(this.btnAuditingSystem_Click);
            // 
            // btnBackupRecovery
            // 
            this.btnBackupRecovery.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnBackupRecovery.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBackupRecovery.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBackupRecovery.Location = new System.Drawing.Point(10, 420);
            this.btnBackupRecovery.Name = "btnBackupRecovery";
            this.btnBackupRecovery.Size = new System.Drawing.Size(230, 40);
            this.btnBackupRecovery.TabIndex = 6;
            this.btnBackupRecovery.Text = "Backup & Recovery";
            this.btnBackupRecovery.UseVisualStyleBackColor = true;
            this.btnBackupRecovery.Click += new System.EventHandler(this.btnBackupRecovery_Click);
            // 
            // btnSystemConfig
            // 
            this.btnSystemConfig.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnSystemConfig.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSystemConfig.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSystemConfig.Location = new System.Drawing.Point(10, 270);
            this.btnSystemConfig.Name = "btnSystemConfig";
            this.btnSystemConfig.Size = new System.Drawing.Size(230, 40);
            this.btnSystemConfig.TabIndex = 5;
            this.btnSystemConfig.Text = "Quan ly Profile";
            this.btnSystemConfig.UseVisualStyleBackColor = true;
            this.btnSystemConfig.Click += new System.EventHandler(this.btnSystemConfig_Click);
            // 
            // btnQuanLyDiem
            // 
            this.btnQuanLyDiem.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnQuanLyDiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnQuanLyDiem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnQuanLyDiem.Location = new System.Drawing.Point(10, 170);
            this.btnQuanLyDiem.Name = "btnQuanLyDiem";
            this.btnQuanLyDiem.Size = new System.Drawing.Size(230, 40);
            this.btnQuanLyDiem.TabIndex = 4;
            this.btnQuanLyDiem.Text = "Quan ly Diem";
            this.btnQuanLyDiem.UseVisualStyleBackColor = true;
            this.btnQuanLyDiem.Click += new System.EventHandler(this.btnQuanLyDiem_Click);
            // 
            // btnQuanLyHocPhan
            // 
            this.btnQuanLyHocPhan.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnQuanLyHocPhan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnQuanLyHocPhan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnQuanLyHocPhan.Location = new System.Drawing.Point(10, 120);
            this.btnQuanLyHocPhan.Name = "btnQuanLyHocPhan";
            this.btnQuanLyHocPhan.Size = new System.Drawing.Size(230, 40);
            this.btnQuanLyHocPhan.TabIndex = 3;
            this.btnQuanLyHocPhan.Text = "Quan ly Hoc phan";
            this.btnQuanLyHocPhan.UseVisualStyleBackColor = true;
            this.btnQuanLyHocPhan.Click += new System.EventHandler(this.btnQuanLyHocPhan_Click);
            // 
            // btnQuanLyLop
            // 
            this.btnQuanLyLop.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnQuanLyLop.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnQuanLyLop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnQuanLyLop.Location = new System.Drawing.Point(10, 220);
            this.btnQuanLyLop.Name = "btnQuanLyLop";
            this.btnQuanLyLop.Size = new System.Drawing.Size(230, 40);
            this.btnQuanLyLop.TabIndex = 2;
            this.btnQuanLyLop.Text = "Quan ly Lop";
            this.btnQuanLyLop.UseVisualStyleBackColor = true;
            this.btnQuanLyLop.Click += new System.EventHandler(this.btnQuanLyLop_Click);
            // 
            // btnQuanLyGiaoVien
            // 
            this.btnQuanLyGiaoVien.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnQuanLyGiaoVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnQuanLyGiaoVien.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnQuanLyGiaoVien.Location = new System.Drawing.Point(10, 70);
            this.btnQuanLyGiaoVien.Name = "btnQuanLyGiaoVien";
            this.btnQuanLyGiaoVien.Size = new System.Drawing.Size(230, 40);
            this.btnQuanLyGiaoVien.TabIndex = 1;
            this.btnQuanLyGiaoVien.Text = "Quan ly Giao vien";
            this.btnQuanLyGiaoVien.UseVisualStyleBackColor = true;
            this.btnQuanLyGiaoVien.Click += new System.EventHandler(this.btnQuanLyGiaoVien_Click);
            // 
            // btnQuanLySinhVien
            // 
            this.btnQuanLySinhVien.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnQuanLySinhVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnQuanLySinhVien.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnQuanLySinhVien.Location = new System.Drawing.Point(10, 20);
            this.btnQuanLySinhVien.Name = "btnQuanLySinhVien";
            this.btnQuanLySinhVien.Size = new System.Drawing.Size(230, 40);
            this.btnQuanLySinhVien.TabIndex = 0;
            this.btnQuanLySinhVien.Text = "Quan ly Sinh vien";
            this.btnQuanLySinhVien.UseVisualStyleBackColor = true;
            this.btnQuanLySinhVien.Click += new System.EventHandler(this.btnQuanLySinhVien_Click);
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.SystemColors.Control;
            this.panelStats.Controls.Add(this.groupBoxStats);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStats.Location = new System.Drawing.Point(250, 80);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(950, 520);
            this.panelStats.TabIndex = 2;
            // 
            // groupBoxStats
            // 
            this.groupBoxStats.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxStats.Controls.Add(this.lblTotalHocPhan);
            this.groupBoxStats.Controls.Add(this.lblTotalLop);
            this.groupBoxStats.Controls.Add(this.lblTotalGiaoVien);
            this.groupBoxStats.Controls.Add(this.lblTotalSinhVien);
            this.groupBoxStats.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBoxStats.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBoxStats.Location = new System.Drawing.Point(30, 30);
            this.groupBoxStats.Name = "groupBoxStats";
            this.groupBoxStats.Size = new System.Drawing.Size(880, 450);
            this.groupBoxStats.TabIndex = 0;
            this.groupBoxStats.TabStop = false;
            this.groupBoxStats.Text = "Thong ke tong quan";
            // 
            // lblTotalHocPhan
            // 
            this.lblTotalHocPhan.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalHocPhan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalHocPhan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalHocPhan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotalHocPhan.Location = new System.Drawing.Point(450, 220);
            this.lblTotalHocPhan.Name = "lblTotalHocPhan";
            this.lblTotalHocPhan.Size = new System.Drawing.Size(280, 100);
            this.lblTotalHocPhan.TabIndex = 3;
            this.lblTotalHocPhan.Text = "Tong Hoc phan: 0";
            this.lblTotalHocPhan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalLop
            // 
            this.lblTotalLop.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalLop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalLop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalLop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotalLop.Location = new System.Drawing.Point(150, 220);
            this.lblTotalLop.Name = "lblTotalLop";
            this.lblTotalLop.Size = new System.Drawing.Size(280, 100);
            this.lblTotalLop.TabIndex = 2;
            this.lblTotalLop.Text = "Tong Lop: 1";
            this.lblTotalLop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalGiaoVien
            // 
            this.lblTotalGiaoVien.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalGiaoVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalGiaoVien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalGiaoVien.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotalGiaoVien.Location = new System.Drawing.Point(450, 80);
            this.lblTotalGiaoVien.Name = "lblTotalGiaoVien";
            this.lblTotalGiaoVien.Size = new System.Drawing.Size(280, 100);
            this.lblTotalGiaoVien.TabIndex = 1;
            this.lblTotalGiaoVien.Text = "Tong Giao vien: 0";
            this.lblTotalGiaoVien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalSinhVien
            // 
            this.lblTotalSinhVien.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalSinhVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalSinhVien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalSinhVien.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotalSinhVien.Location = new System.Drawing.Point(150, 80);
            this.lblTotalSinhVien.Name = "lblTotalSinhVien";
            this.lblTotalSinhVien.Size = new System.Drawing.Size(280, 100);
            this.lblTotalSinhVien.TabIndex = 0;
            this.lblTotalSinhVien.Text = "Tong Sinh vien: 0";
            this.lblTotalSinhVien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelTop);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Sinh viên";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.panelStats.ResumeLayout(false);
            this.groupBoxStats.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnSystemConfig;
        private System.Windows.Forms.Button btnQuanLyDiem;
        private System.Windows.Forms.Button btnQuanLyHocPhan;
        private System.Windows.Forms.Button btnQuanLyLop;
        private System.Windows.Forms.Button btnQuanLyGiaoVien;
        private System.Windows.Forms.Button btnQuanLySinhVien;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.GroupBox groupBoxStats;
        private System.Windows.Forms.Label lblTotalHocPhan;
        private System.Windows.Forms.Label lblTotalLop;
        private System.Windows.Forms.Label lblTotalGiaoVien;
        private System.Windows.Forms.Label lblTotalSinhVien;
    }
}

