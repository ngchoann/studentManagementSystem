namespace StudentManagementSystem.Forms
{
    partial class CreateUserForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Text = "Tạo User Mới"; Size = new System.Drawing.Size(450, 350);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle; MaximizeBox = false;

            lblTitle = new System.Windows.Forms.Label { Text = "TẠO USER MỚI", Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(140, 20), Size = new System.Drawing.Size(170, 25), ForeColor = System.Drawing.Color.DarkBlue };
            lblUsername = new System.Windows.Forms.Label { Text = "Tên đăng nhập:", Location = new System.Drawing.Point(30, 70), Size = new System.Drawing.Size(100, 20) };
            txtUsername = new System.Windows.Forms.TextBox { Location = new System.Drawing.Point(140, 67), Size = new System.Drawing.Size(250, 25) };
            lblPassword = new System.Windows.Forms.Label { Text = "Mật khẩu:", Location = new System.Drawing.Point(30, 110), Size = new System.Drawing.Size(100, 20) };
            txtPassword = new System.Windows.Forms.TextBox { Location = new System.Drawing.Point(140, 107), Size = new System.Drawing.Size(250, 25), PasswordChar = '*' };
            lblRole = new System.Windows.Forms.Label { Text = "Vai trò:", Location = new System.Drawing.Point(30, 150), Size = new System.Drawing.Size(100, 20) };
            cboRole = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(140, 147), Size = new System.Drawing.Size(250, 25), DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            cboRole.Items.AddRange(new object[] { "ADMIN", "TEACHER" }); cboRole.SelectedIndex = 1;
            btnCreate = new System.Windows.Forms.Button { Text = "Tạo User", Location = new System.Drawing.Point(120, 190), Size = new System.Drawing.Size(120, 35),
                BackColor = System.Drawing.Color.Green, ForeColor = System.Drawing.Color.White, FlatStyle = System.Windows.Forms.FlatStyle.Flat };
            btnCreate.Click += BtnCreate_Click;
            btnCancel = new System.Windows.Forms.Button { Text = "Hủy", Location = new System.Drawing.Point(260, 190), Size = new System.Drawing.Size(80, 35) };
            btnCancel.Click += BtnCancel_Click;
            progressBar = new System.Windows.Forms.ProgressBar { Location = new System.Drawing.Point(30, 240), Size = new System.Drawing.Size(380, 20), Visible = false };
            lblStatus = new System.Windows.Forms.Label { Location = new System.Drawing.Point(30, 270), Size = new System.Drawing.Size(380, 40) };

            Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, lblUsername, txtUsername, lblPassword, txtPassword, lblRole, cboRole, btnCreate, btnCancel, progressBar, lblStatus });
        }

        private System.Windows.Forms.Label lblTitle = null!, lblUsername = null!, lblPassword = null!, lblRole = null!, lblStatus = null!;
        private System.Windows.Forms.TextBox txtUsername = null!, txtPassword = null!;
        private System.Windows.Forms.ComboBox cboRole = null!;
        private System.Windows.Forms.Button btnCreate = null!, btnCancel = null!;
        private System.Windows.Forms.ProgressBar progressBar = null!;
    }
}