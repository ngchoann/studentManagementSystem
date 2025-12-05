namespace StudentManagementSystem.Forms
{
    partial class HocPhanDetailForm
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
            this.lblMaHP = new System.Windows.Forms.Label();
            this.txtMaHP = new System.Windows.Forms.TextBox();
            this.lblTenHP = new System.Windows.Forms.Label();
            this.txtTenHP = new System.Windows.Forms.TextBox();
            this.lblGiaoVien = new System.Windows.Forms.Label();
            this.cboGiaoVien = new System.Windows.Forms.ComboBox();
            this.lblSoTinChi = new System.Windows.Forms.Label();
            this.cboSoTinChi = new System.Windows.Forms.ComboBox();
            this.lblHocKy = new System.Windows.Forms.Label();
            this.numHocKy = new System.Windows.Forms.NumericUpDown();
            this.lblNamHoc = new System.Windows.Forms.Label();
            this.txtNamHoc = new System.Windows.Forms.TextBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.chkTrangThai = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numHocKy)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaHP
            // 
            this.lblMaHP.AutoSize = true;
            this.lblMaHP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaHP.Location = new System.Drawing.Point(20, 20);
            this.lblMaHP.Name = "lblMaHP";
            this.lblMaHP.Size = new System.Drawing.Size(110, 19);
            this.lblMaHP.TabIndex = 0;
            this.lblMaHP.Text = "Mã Học phần (*):";
            // 
            // txtMaHP
            // 
            this.txtMaHP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaHP.Location = new System.Drawing.Point(180, 17);
            this.txtMaHP.MaxLength = 50;
            this.txtMaHP.Name = "txtMaHP";
            this.txtMaHP.Size = new System.Drawing.Size(300, 25);
            this.txtMaHP.TabIndex = 1;
            // 
            // lblTenHP
            // 
            this.lblTenHP.AutoSize = true;
            this.lblTenHP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTenHP.Location = new System.Drawing.Point(20, 60);
            this.lblTenHP.Name = "lblTenHP";
            this.lblTenHP.Size = new System.Drawing.Size(114, 19);
            this.lblTenHP.TabIndex = 2;
            this.lblTenHP.Text = "Tên Học phần (*):";
            // 
            // txtTenHP
            // 
            this.txtTenHP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenHP.Location = new System.Drawing.Point(180, 57);
            this.txtTenHP.MaxLength = 200;
            this.txtTenHP.Name = "txtTenHP";
            this.txtTenHP.Size = new System.Drawing.Size(300, 25);
            this.txtTenHP.TabIndex = 3;
            // 
            // lblGiaoVien
            // 
            this.lblGiaoVien.AutoSize = true;
            this.lblGiaoVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGiaoVien.Location = new System.Drawing.Point(20, 100);
            this.lblGiaoVien.Name = "lblGiaoVien";
            this.lblGiaoVien.Size = new System.Drawing.Size(71, 19);
            this.lblGiaoVien.TabIndex = 4;
            this.lblGiaoVien.Text = "Giáo viên:";
            // 
            // cboGiaoVien
            // 
            this.cboGiaoVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGiaoVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboGiaoVien.FormattingEnabled = true;
            this.cboGiaoVien.Location = new System.Drawing.Point(180, 97);
            this.cboGiaoVien.Name = "cboGiaoVien";
            this.cboGiaoVien.Size = new System.Drawing.Size(300, 25);
            this.cboGiaoVien.TabIndex = 5;
            // 
            // lblSoTinChi
            // 
            this.lblSoTinChi.AutoSize = true;
            this.lblSoTinChi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSoTinChi.Location = new System.Drawing.Point(20, 140);
            this.lblSoTinChi.Name = "lblSoTinChi";
            this.lblSoTinChi.Size = new System.Drawing.Size(69, 19);
            this.lblSoTinChi.TabIndex = 6;
            this.lblSoTinChi.Text = "Số tín chỉ:";
            // 
            // cboSoTinChi
            // 
            this.cboSoTinChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSoTinChi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSoTinChi.FormattingEnabled = true;
            this.cboSoTinChi.Location = new System.Drawing.Point(180, 137);
            this.cboSoTinChi.Name = "cboSoTinChi";
            this.cboSoTinChi.Size = new System.Drawing.Size(150, 25);
            this.cboSoTinChi.TabIndex = 7;
            // 
            // lblHocKy
            // 
            this.lblHocKy.AutoSize = true;
            this.lblHocKy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHocKy.Location = new System.Drawing.Point(20, 180);
            this.lblHocKy.Name = "lblHocKy";
            this.lblHocKy.Size = new System.Drawing.Size(54, 19);
            this.lblHocKy.TabIndex = 8;
            this.lblHocKy.Text = "Học kỳ:";
            // 
            // numHocKy
            // 
            this.numHocKy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numHocKy.Location = new System.Drawing.Point(180, 178);
            this.numHocKy.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            this.numHocKy.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numHocKy.Name = "numHocKy";
            this.numHocKy.Size = new System.Drawing.Size(150, 25);
            this.numHocKy.TabIndex = 9;
            this.numHocKy.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblNamHoc
            // 
            this.lblNamHoc.AutoSize = true;
            this.lblNamHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNamHoc.Location = new System.Drawing.Point(20, 220);
            this.lblNamHoc.Name = "lblNamHoc";
            this.lblNamHoc.Size = new System.Drawing.Size(87, 19);
            this.lblNamHoc.TabIndex = 10;
            this.lblNamHoc.Text = "Năm học (*):";
            // 
            // txtNamHoc
            // 
            this.txtNamHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNamHoc.Location = new System.Drawing.Point(180, 217);
            this.txtNamHoc.MaxLength = 20;
            this.txtNamHoc.Name = "txtNamHoc";
            this.txtNamHoc.PlaceholderText = "VD: 2023-2024";
            this.txtNamHoc.Size = new System.Drawing.Size(150, 25);
            this.txtNamHoc.TabIndex = 11;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMoTa.Location = new System.Drawing.Point(20, 260);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(47, 19);
            this.lblMoTa.TabIndex = 12;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMoTa.Location = new System.Drawing.Point(180, 257);
            this.txtMoTa.MaxLength = 500;
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMoTa.Size = new System.Drawing.Size(300, 80);
            this.txtMoTa.TabIndex = 13;
            // 
            // chkTrangThai
            // 
            this.chkTrangThai.AutoSize = true;
            this.chkTrangThai.Checked = true;
            this.chkTrangThai.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkTrangThai.Location = new System.Drawing.Point(180, 350);
            this.chkTrangThai.Name = "chkTrangThai";
            this.chkTrangThai.Size = new System.Drawing.Size(92, 23);
            this.chkTrangThai.TabIndex = 14;
            this.chkTrangThai.Text = "Hoạt động";
            this.chkTrangThai.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(180, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(310, 390);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // HocPhanDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkTrangThai);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.txtNamHoc);
            this.Controls.Add(this.lblNamHoc);
            this.Controls.Add(this.numHocKy);
            this.Controls.Add(this.lblHocKy);
            this.Controls.Add(this.cboSoTinChi);
            this.Controls.Add(this.lblSoTinChi);
            this.Controls.Add(this.cboGiaoVien);
            this.Controls.Add(this.lblGiaoVien);
            this.Controls.Add(this.txtTenHP);
            this.Controls.Add(this.lblTenHP);
            this.Controls.Add(this.txtMaHP);
            this.Controls.Add(this.lblMaHP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HocPhanDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết Học phần";
            this.Load += new System.EventHandler(this.HocPhanDetailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numHocKy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblMaHP;
        private System.Windows.Forms.TextBox txtMaHP;
        private System.Windows.Forms.Label lblTenHP;
        private System.Windows.Forms.TextBox txtTenHP;
        private System.Windows.Forms.Label lblGiaoVien;
        private System.Windows.Forms.ComboBox cboGiaoVien;
        private System.Windows.Forms.Label lblSoTinChi;
        private System.Windows.Forms.ComboBox cboSoTinChi;
        private System.Windows.Forms.Label lblHocKy;
        private System.Windows.Forms.NumericUpDown numHocKy;
        private System.Windows.Forms.Label lblNamHoc;
        private System.Windows.Forms.TextBox txtNamHoc;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.CheckBox chkTrangThai;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
