using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace StudentManagementSystem.Forms
{
    partial class DangKyHocPhanForm
    {
        private IContainer components = null!;
        private Label lblTitle;
        private Label lblInfo;
        private Label lblLeft;
        private Label lblRight;
        private DataGridView dgvLeft;
        private DataGridView dgvRight;
        private Button btnDangKy;
        private Button btnHuy;
        private Button btnRefresh;

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblInfo = new Label();
            lblLeft = new Label();
            lblRight = new Label();
            dgvLeft = new DataGridView();
            dgvRight = new DataGridView();
            btnDangKy = new Button();
            btnHuy = new Button();
            btnRefresh = new Button();
            panelButtons = new Panel();
            panelMain = new Panel();
            panelRight = new Panel();
            panelLeft = new Panel();
            ((ISupportInitialize)dgvLeft).BeginInit();
            ((ISupportInitialize)dgvRight).BeginInit();
            panelButtons.SuspendLayout();
            panelMain.SuspendLayout();
            panelRight.SuspendLayout();
            panelLeft.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1500, 60);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "ĐĂNG KÝ HỌC PHẦN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblInfo
            // 
            lblInfo.Dock = DockStyle.Top;
            lblInfo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblInfo.Location = new Point(0, 60);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(1500, 35);
            lblInfo.TabIndex = 2;
            lblInfo.Text = "Đang tải...";
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLeft
            // 
            lblLeft.Dock = DockStyle.Top;
            lblLeft.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblLeft.Location = new Point(10, 10);
            lblLeft.Name = "lblLeft";
            lblLeft.Size = new Size(709, 35);
            lblLeft.TabIndex = 1;
            lblLeft.Text = "HỌC PHẦN CÓ THỂ ĐĂNG KÝ";
            // 
            // lblRight
            // 
            lblRight.Dock = DockStyle.Top;
            lblRight.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblRight.Location = new Point(10, 10);
            lblRight.Name = "lblRight";
            lblRight.Size = new Size(711, 35);
            lblRight.TabIndex = 1;
            lblRight.Text = "HỌC PHẦN ĐÃ ĐĂNG KÝ";
            // 
            // dgvLeft
            // 
            dgvLeft.AllowUserToAddRows = false;
            dgvLeft.AllowUserToDeleteRows = false;
            dgvLeft.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLeft.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLeft.Dock = DockStyle.Fill;
            dgvLeft.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dgvLeft.Location = new Point(10, 45);
            dgvLeft.Name = "dgvLeft";
            dgvLeft.ReadOnly = true;
            dgvLeft.RowHeadersVisible = false;
            dgvLeft.RowHeadersWidth = 51;
            dgvLeft.RowTemplate.Height = 34;
            dgvLeft.ScrollBars = ScrollBars.Vertical;
            dgvLeft.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLeft.Size = new Size(709, 500);
            dgvLeft.TabIndex = 0;
            // 
            // dgvRight
            // 
            dgvRight.AllowUserToAddRows = false;
            dgvRight.AllowUserToDeleteRows = false;
            dgvRight.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRight.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRight.Dock = DockStyle.Fill;
            dgvRight.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dgvRight.Location = new Point(10, 45);
            dgvRight.Name = "dgvRight";
            dgvRight.ReadOnly = true;
            dgvRight.RowHeadersVisible = false;
            dgvRight.RowHeadersWidth = 51;
            dgvRight.RowTemplate.Height = 34;
            dgvRight.ScrollBars = ScrollBars.Vertical;
            dgvRight.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRight.Size = new Size(711, 500);
            dgvRight.TabIndex = 0;
            // 
            // btnDangKy
            // 
            btnDangKy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDangKy.Location = new Point(440, 13);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(150, 45);
            btnDangKy.TabIndex = 0;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.Click += BtnDangKy_Click;
            // 
            // btnHuy
            // 
            btnHuy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnHuy.Location = new Point(667, 12);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(150, 45);
            btnHuy.TabIndex = 1;
            btnHuy.Text = "Hủy đăng ký";
            btnHuy.Click += BtnHuy_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnRefresh.Location = new Point(866, 13);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(130, 45);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Làm mới";
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnDangKy);
            panelButtons.Controls.Add(btnHuy);
            panelButtons.Controls.Add(btnRefresh);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 690);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1500, 70);
            panelButtons.TabIndex = 1;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(panelRight);
            panelMain.Controls.Add(panelLeft);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 95);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(20);
            panelMain.Size = new Size(1500, 595);
            panelMain.TabIndex = 0;
            // 
            // panelRight
            // 
            panelRight.Controls.Add(dgvRight);
            panelRight.Controls.Add(lblRight);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(749, 20);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(10);
            panelRight.Size = new Size(731, 555);
            panelRight.TabIndex = 0;
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(dgvLeft);
            panelLeft.Controls.Add(lblLeft);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(20, 20);
            panelLeft.Name = "panelLeft";
            panelLeft.Padding = new Padding(10);
            panelLeft.Size = new Size(729, 555);
            panelLeft.TabIndex = 1;
            // 
            // DangKyHocPhanForm
            // 
            ClientSize = new Size(1500, 760);
            Controls.Add(panelMain);
            Controls.Add(panelButtons);
            Controls.Add(lblInfo);
            Controls.Add(lblTitle);
            Name = "DangKyHocPhanForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký học phần";
            Load += Form_Load;
            ((ISupportInitialize)dgvLeft).EndInit();
            ((ISupportInitialize)dgvRight).EndInit();
            panelButtons.ResumeLayout(false);
            panelMain.ResumeLayout(false);
            panelRight.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private Panel panelButtons;
        private Panel panelMain;
        private Panel panelRight;
        private Panel panelLeft;
    }
}
