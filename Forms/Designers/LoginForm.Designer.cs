namespace StudentManagementSystem.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Text = "Đăng nhập hệ thống";
            this.Size = new System.Drawing.Size(400, 300);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            lblTitle = new System.Windows.Forms.Label { Text = "HỆ THỐNG MÃ HÓA", Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(80, 20), Size = new System.Drawing.Size(240, 30), TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
            lblUsername = new System.Windows.Forms.Label { Text = "Tên đăng nhập:", Location = new System.Drawing.Point(50, 70), Size = new System.Drawing.Size(100, 20) };
            txtUsername = new System.Windows.Forms.TextBox { Location = new System.Drawing.Point(50, 95), Size = new System.Drawing.Size(300, 25), Font = new System.Drawing.Font("Segoe UI", 10F) };
            lblPassword = new System.Windows.Forms.Label { Text = "Mật khẩu:", Location = new System.Drawing.Point(50, 130), Size = new System.Drawing.Size(100, 20) };
            txtPassword = new System.Windows.Forms.TextBox { Location = new System.Drawing.Point(50, 155), Size = new System.Drawing.Size(300, 25), Font = new System.Drawing.Font("Segoe UI", 10F), PasswordChar = '*' };
            txtPassword.KeyPress += TxtPassword_KeyPress;
            btnLogin = new System.Windows.Forms.Button { Text = "Đăng nhập", Location = new System.Drawing.Point(150, 195), Size = new System.Drawing.Size(100, 35),
                BackColor = System.Drawing.Color.FromArgb(0, 120, 215), ForeColor = System.Drawing.Color.White, FlatStyle = System.Windows.Forms.FlatStyle.Flat };
            btnLogin.Click += BtnLogin_Click;
            lblMessage = new System.Windows.Forms.Label { Location = new System.Drawing.Point(50, 240), Size = new System.Drawing.Size(300, 20),
                ForeColor = System.Drawing.Color.Red, TextAlign = System.Drawing.ContentAlignment.MiddleCenter };

            this.Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, lblUsername, txtUsername, lblPassword, txtPassword, btnLogin, lblMessage });
        }

        private System.Windows.Forms.TextBox txtUsername = null!;
        private System.Windows.Forms.TextBox txtPassword = null!;
        private System.Windows.Forms.Button btnLogin = null!;
        private System.Windows.Forms.Label lblTitle = null!;
        private System.Windows.Forms.Label lblUsername = null!;
        private System.Windows.Forms.Label lblPassword = null!;
        private System.Windows.Forms.Label lblMessage = null!;
    }
}