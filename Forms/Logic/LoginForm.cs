using System;
using System.Windows.Forms;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        private readonly OracleEncryptionService _encryptionService = new();
        private readonly AuditService _auditService = new();

        public LoginForm() => InitializeComponent();

        private void TxtPassword_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) BtnLogin_Click(sender, e);
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                btnLogin.Enabled = false;
                btnLogin.Text = "Đang xác thực...";

                string username = txtUsername.Text.Trim(), password = txtPassword.Text;
                if (string.IsNullOrEmpty(username)) { lblMessage.Text = "Nhập tên đăng nhập"; return; }
                if (string.IsNullOrEmpty(password)) { lblMessage.Text = "Nhập mật khẩu"; return; }

                var (isValid, userId, role, message) = _encryptionService.AuthenticateUser(username, password);
                if (!isValid)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = message;
                    _auditService.LogApplicationEvent(username, "APP_LOGIN_FAILED", "LoginForm", $"Failed: {message}");
                    return;
                }

                // Thiết lập kết nối cho DAL để các form khác sử dụng
                DAL.OracleConnection.Instance.Connect("ADMIN_MASTER", "123", "localhost:1521/orcl21pdb1");

                lblMessage.ForeColor = System.Drawing.Color.Green;
                _auditService.LogApplicationEvent(username, "APP_LOGIN", "LoginForm", $"Login OK: {role}");

                this.Hide();
                Form nextForm = role.ToUpper() == "STUDENT"
                    ? new DashboardForm(username, role, false)
                    : new UploadKeyForm(userId, username, password, role);

                nextForm.FormClosed += (s, args) => { this.Show(); txtPassword.Clear(); lblMessage.Text = ""; };
                nextForm.Show();
            }
            catch (Exception ex) { lblMessage.ForeColor = System.Drawing.Color.Red; lblMessage.Text = $"Lỗi: {ex.Message}"; }
            finally { btnLogin.Enabled = true; btnLogin.Text = "Đăng nhập"; }
        }

        protected override void OnFormClosing(FormClosingEventArgs e) => Application.Exit();
    }
}
