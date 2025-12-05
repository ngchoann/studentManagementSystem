namespace StudentManagementSystem.Forms
{
    partial class HocPhanForm
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
            this.dgvHocPhan = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.chkTrangThai = new System.Windows.Forms.CheckBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.txtNamHoc = new System.Windows.Forms.TextBox();
            this.numHocKy = new System.Windows.Forms.NumericUpDown();
            this.numSoTC = new System.Windows.Forms.NumericUpDown();
            this.cboMaGV = new System.Windows.Forms.ComboBox();
            this.txtTenHP = new System.Windows.Forms.TextBox();
            this.txtMaHP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHocKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTC)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHocPhan
            // 
            this.dgvHocPhan.AllowUserToAddRows = false;
            this.dgvHocPhan.AllowUserToDeleteRows = false;
            this.dgvHocPhan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHocPhan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHocPhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHocPhan.Location = new System.Drawing.Point(12, 250);
            this.dgvHocPhan.Name = "dgvHocPhan";
            this.dgvHocPhan.ReadOnly = true;
            this.dgvHocPhan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHocPhan.Size = new System.Drawing.Size(1060, 390);
            this.dgvHocPhan.TabIndex = 0;
            this.dgvHocPhan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHocPhan_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnLamMoi);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.chkTrangThai);
            this.groupBox1.Controls.Add(this.txtMoTa);
            this.groupBox1.Controls.Add(this.txtNamHoc);
            this.groupBox1.Controls.Add(this.numHocKy);
            this.groupBox1.Controls.Add(this.numSoTC);
            this.groupBox1.Controls.Add(this.cboMaGV);
            this.groupBox1.Controls.Add(this.txtTenHP);
            this.groupBox1.Controls.Add(this.txtMaHP);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1060, 225);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thong tin hoc phan";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ma HP:";
            // 
            // txtMaHP
            // 
            this.txtMaHP.Location = new System.Drawing.Point(120, 32);
            this.txtMaHP.Name = "txtMaHP";
            this.txtMaHP.Size = new System.Drawing.Size(200, 23);
            this.txtMaHP.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ten hoc phan:";
            // 
            // txtTenHP
            // 
            this.txtTenHP.Location = new System.Drawing.Point(120, 67);
            this.txtTenHP.Name = "txtTenHP";
            this.txtTenHP.Size = new System.Drawing.Size(400, 23);
            this.txtTenHP.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Giao vien:";
            // 
            // cboMaGV
            // 
            this.cboMaGV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaGV.FormattingEnabled = true;
            this.cboMaGV.Location = new System.Drawing.Point(120, 102);
            this.cboMaGV.Name = "cboMaGV";
            this.cboMaGV.Size = new System.Drawing.Size(300, 23);
            this.cboMaGV.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(550, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "So tin chi:";
            // 
            // numSoTC
            // 
            this.numSoTC.Location = new System.Drawing.Point(640, 32);
            this.numSoTC.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numSoTC.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoTC.Name = "numSoTC";
            this.numSoTC.Size = new System.Drawing.Size(80, 23);
            this.numSoTC.TabIndex = 7;
            this.numSoTC.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(550, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Hoc ky:";
            // 
            // numHocKy
            // 
            this.numHocKy.Location = new System.Drawing.Point(640, 67);
            this.numHocKy.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            this.numHocKy.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numHocKy.Name = "numHocKy";
            this.numHocKy.Size = new System.Drawing.Size(80, 23);
            this.numHocKy.TabIndex = 9;
            this.numHocKy.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(550, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Nam hoc:";
            // 
            // txtNamHoc
            // 
            this.txtNamHoc.Location = new System.Drawing.Point(640, 102);
            this.txtNamHoc.Name = "txtNamHoc";
            this.txtNamHoc.Size = new System.Drawing.Size(150, 23);
            this.txtNamHoc.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(820, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Mo ta:";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(870, 32);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(170, 93);
            this.txtMoTa.TabIndex = 13;
            // 
            // chkTrangThai
            // 
            this.chkTrangThai.AutoSize = true;
            this.chkTrangThai.Checked = true;
            this.chkTrangThai.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrangThai.Location = new System.Drawing.Point(640, 137);
            this.chkTrangThai.Name = "chkTrangThai";
            this.chkTrangThai.Size = new System.Drawing.Size(100, 19);
            this.chkTrangThai.TabIndex = 14;
            this.chkTrangThai.Text = "Dang hoat dong";
            this.chkTrangThai.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(120, 175);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.TabIndex = 15;
            this.btnThem.Text = "Them";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(240, 175);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 35);
            this.btnSua.TabIndex = 16;
            this.btnSua.Text = "Sua";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(360, 175);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 35);
            this.btnXoa.TabIndex = 17;
            this.btnXoa.Text = "Xoa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(480, 175);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 35);
            this.btnLamMoi.TabIndex = 18;
            this.btnLamMoi.Text = "Lam moi";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // HocPhanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 651);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvHocPhan);
            this.Name = "HocPhanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quan ly Hoc phan";
            this.Load += new System.EventHandler(this.HocPhanForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHocKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTC)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvHocPhan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.CheckBox chkTrangThai;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.TextBox txtNamHoc;
        private System.Windows.Forms.NumericUpDown numHocKy;
        private System.Windows.Forms.NumericUpDown numSoTC;
        private System.Windows.Forms.ComboBox cboMaGV;
        private System.Windows.Forms.TextBox txtTenHP;
        private System.Windows.Forms.TextBox txtMaHP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
