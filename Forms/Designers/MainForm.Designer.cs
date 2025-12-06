namespace StudentManagementSystem.Forms
{
    partial class MainForm
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

        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSinhVien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGiaoVien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLop = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHocPhan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDiem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDangKyHP = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRole = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHeThong,
            this.menuQuanLy});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1000, 24);
            this.menuStrip.TabIndex = 0;
            // 
            // menuHeThong
            // 
            this.menuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDangXuat,
            this.menuThoat});
            this.menuHeThong.Name = "menuHeThong";
            this.menuHeThong.Size = new System.Drawing.Size(72, 20);
            this.menuHeThong.Text = "Hệ thống";
            // 
            // menuDangXuat
            // 
            this.menuDangXuat.Name = "menuDangXuat";
            this.menuDangXuat.Size = new System.Drawing.Size(180, 22);
            this.menuDangXuat.Text = "Đăng xuất";
            this.menuDangXuat.Click += new System.EventHandler(this.menuDangXuat_Click);
            // 
            // menuThoat
            // 
            this.menuThoat.Name = "menuThoat";
            this.menuThoat.Size = new System.Drawing.Size(180, 22);
            this.menuThoat.Text = "Thoát";
            this.menuThoat.Click += new System.EventHandler(this.menuThoat_Click);
            // 
            // menuQuanLy
            // 
            this.menuQuanLy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSinhVien,
            this.menuGiaoVien,
            this.menuLop,
            this.menuHocPhan,
            this.menuDiem,
            this.menuDangKyHP});
            this.menuQuanLy.Name = "menuQuanLy";
            this.menuQuanLy.Size = new System.Drawing.Size(60, 20);
            this.menuQuanLy.Text = "Quản lý";
            // 
            // menuSinhVien
            // 
            this.menuSinhVien.Name = "menuSinhVien";
            this.menuSinhVien.Size = new System.Drawing.Size(180, 22);
            this.menuSinhVien.Text = "Sinh viên";
            this.menuSinhVien.Click += new System.EventHandler(this.menuSinhVien_Click);
            // 
            // menuGiaoVien
            // 
            this.menuGiaoVien.Name = "menuGiaoVien";
            this.menuGiaoVien.Size = new System.Drawing.Size(180, 22);
            this.menuGiaoVien.Text = "Giáo viên";
            this.menuGiaoVien.Click += new System.EventHandler(this.menuGiaoVien_Click);
            // 
            // menuLop
            // 
            this.menuLop.Name = "menuLop";
            this.menuLop.Size = new System.Drawing.Size(180, 22);
            this.menuLop.Text = "Lớp";
            this.menuLop.Click += new System.EventHandler(this.menuLop_Click);
            // 
            // menuHocPhan
            // 
            this.menuHocPhan.Name = "menuHocPhan";
            this.menuHocPhan.Size = new System.Drawing.Size(180, 22);
            this.menuHocPhan.Text = "Học phần";
            this.menuHocPhan.Click += new System.EventHandler(this.menuHocPhan_Click);
            // 
            // menuDiem
            // 
            this.menuDiem.Name = "menuDiem";
            this.menuDiem.Size = new System.Drawing.Size(180, 22);
            this.menuDiem.Text = "Điểm";
            this.menuDiem.Click += new System.EventHandler(this.menuDiem_Click);
            // 
            // menuDangKyHP
            // 
            this.menuDangKyHP.Name = "menuDangKyHP";
            this.menuDangKyHP.Size = new System.Drawing.Size(180, 22);
            this.menuDangKyHP.Text = "📋 Đăng ký học phần";
            this.menuDangKyHP.Visible = false;
            this.menuDangKyHP.Click += new System.EventHandler(this.menuDangKyHP_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblUser,
            this.lblRole});
            this.statusStrip.Location = new System.Drawing.Point(0, 578);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1000, 22);
            this.statusStrip.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(58, 17);
            this.lblStatus.Text = "Sẵn sàng";
            // 
            // lblUser
            // 
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(84, 17);
            this.lblUser.Spring = true;
            this.lblUser.Text = "User: ";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRole
            // 
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(36, 17);
            this.lblRole.Text = "Role:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Sinh viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuHeThong;
        private System.Windows.Forms.ToolStripMenuItem menuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem menuThoat;
        private System.Windows.Forms.ToolStripMenuItem menuQuanLy;
        private System.Windows.Forms.ToolStripMenuItem menuSinhVien;
        private System.Windows.Forms.ToolStripMenuItem menuGiaoVien;
        private System.Windows.Forms.ToolStripMenuItem menuLop;
        private System.Windows.Forms.ToolStripMenuItem menuHocPhan;
        private System.Windows.Forms.ToolStripMenuItem menuDiem;
        private System.Windows.Forms.ToolStripMenuItem menuDangKyHP;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblUser;
        private System.Windows.Forms.ToolStripStatusLabel lblRole;
    }
}
