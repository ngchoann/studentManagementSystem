namespace StudentManagementSystem.Forms
{
    partial class StudentPersonalInfoForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelTop;
        private Label lblTitle;
        private Panel panelMain;
        private Label lblMaSVTitle, lblMaSV;
        private Label lblTenSVTitle, lblTenSV;
        private Label lblVaiTroTitle, lblVaiTro;
        private Label lblKhoaTitle, lblKhoa;
        private Label lblTrangThaiTitle, lblTrangThai;
        private Button btnClose;

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
            this.panelTop = new Panel();
            this.lblTitle = new Label();
            this.panelMain = new Panel();
            this.btnClose = new Button();

            // Labels
            this.lblMaSVTitle = new Label();
            this.lblMaSV = new Label();
            this.lblTenSVTitle = new Label();
            this.lblTenSV = new Label();
            this.lblVaiTroTitle = new Label();
            this.lblVaiTro = new Label();
            this.lblKhoaTitle = new Label();
            this.lblKhoa = new Label();
            this.lblTrangThaiTitle = new Label();
            this.lblTrangThai = new Label();

            this.panelTop.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(500, 50);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTitle.Text = "Thông Tin Cá Nhân";

            // panelMain
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Padding = new Padding(20);
            
            // Add all controls to panelMain
            this.panelMain.Controls.Add(this.lblMaSVTitle);
            this.panelMain.Controls.Add(this.lblMaSV);
            this.panelMain.Controls.Add(this.lblTenSVTitle);
            this.panelMain.Controls.Add(this.lblTenSV);
            this.panelMain.Controls.Add(this.lblVaiTroTitle);
            this.panelMain.Controls.Add(this.lblVaiTro);
            this.panelMain.Controls.Add(this.lblKhoaTitle);
            this.panelMain.Controls.Add(this.lblKhoa);
            this.panelMain.Controls.Add(this.lblTrangThaiTitle);
            this.panelMain.Controls.Add(this.lblTrangThai);
            this.panelMain.Controls.Add(this.btnClose);

            // Setup labels
            SetupLabel(lblMaSVTitle, "Mã sinh viên:", 30, 30, true);
            SetupLabel(lblMaSV, "", 180, 30, false);
            SetupLabel(lblTenSVTitle, "Họ và tên:", 30, 60, true);
            SetupLabel(lblTenSV, "", 180, 60, false);
            SetupLabel(lblVaiTroTitle, "Vai trò:", 30, 90, true);
            SetupLabel(lblVaiTro, "", 180, 90, false);
            SetupLabel(lblKhoaTitle, "Khoa:", 30, 120, true);
            SetupLabel(lblKhoa, "", 180, 120, false);
            SetupLabel(lblTrangThaiTitle, "Trạng thái:", 30, 150, true);
            SetupLabel(lblTrangThai, "", 180, 150, false);

            // btnClose
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(380, 200);
            this.btnClose.Size = new System.Drawing.Size(80, 35);
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 280);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Thông Tin Cá Nhân";
            this.Load += new System.EventHandler(this.StudentPersonalInfoForm_Load);

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
        }

        private void SetupLabel(Label label, string text, int x, int y, bool isTitle)
        {
            label.AutoSize = true;
            label.Font = new System.Drawing.Font("Segoe UI", 10F, isTitle ? System.Drawing.FontStyle.Regular : System.Drawing.FontStyle.Bold);
            label.ForeColor = isTitle ? System.Drawing.Color.FromArgb(52, 73, 94) : System.Drawing.Color.FromArgb(46, 125, 50);
            label.Location = new System.Drawing.Point(x, y);
            label.Text = text;
            label.Size = new System.Drawing.Size(200, 20);
        }
    }
}