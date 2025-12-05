namespace StudentManagementSystem.Forms
{
    partial class DiemForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvDiem = new System.Windows.Forms.DataGridView();
            btnLoad = new System.Windows.Forms.Button();
            lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgvDiem).BeginInit();
            SuspendLayout();

            lblInfo.AutoSize = true;
            lblInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblInfo.Location = new System.Drawing.Point(150, 17);
            lblInfo.Size = new System.Drawing.Size(400, 19);
            lblInfo.Text = "Dữ liệu điểm (VPD Policy)";

            dgvDiem.AllowUserToAddRows = false;
            dgvDiem.AllowUserToDeleteRows = false;
            dgvDiem.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvDiem.Location = new System.Drawing.Point(12, 50);
            dgvDiem.ReadOnly = true;
            dgvDiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvDiem.Size = new System.Drawing.Size(960, 530);

            btnLoad.Location = new System.Drawing.Point(12, 12);
            btnLoad.Size = new System.Drawing.Size(120, 30);
            btnLoad.Text = "Tải dữ liệu";
            btnLoad.Click += btnLoad_Click;

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(984, 592);
            Controls.Add(lblInfo);
            Controls.Add(btnLoad);
            Controls.Add(dgvDiem);
            Text = "Quản lý Điểm";
            Load += DiemForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDiem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvDiem = null!;
        private System.Windows.Forms.Button btnLoad = null!;
        private System.Windows.Forms.Label lblInfo = null!;
    }
}
