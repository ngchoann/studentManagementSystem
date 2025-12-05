using System;
using System.IO;
using System.Windows.Forms;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Forms
{
    public partial class CreateUserForm : Form
    {
        private readonly OracleEncryptionService _svc;

        public CreateUserForm(OracleEncryptionService svc) { _svc = svc; InitializeComponent(); }

        private void BtnCreate_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!ValidateField(txtUsername, "tên đăng nhập") || !ValidateField(txtPassword, "mật khẩu")) return;
                if (cboRole.SelectedItem == null) { SetStatus("Chọn vai trò", false); return; }
                if (_svc.UserExists(txtUsername.Text.Trim())) { SetStatus("Tên đã tồn tại", false); return; }

                progressBar.Visible = true; progressBar.Style = ProgressBarStyle.Marquee;
                btnCreate.Enabled = btnCancel.Enabled = false;
                SetStatus("Đang tạo user...", true);
                Application.DoEvents();

                var (ok, userId, privateKey, err) = _svc.CreateNewUserWithKeys(txtUsername.Text.Trim(), txtPassword.Text, cboRole.SelectedItem.ToString()!);
                progressBar.Visible = false;

                if (ok)
                {
                    string path = SaveKey(privateKey, $"{txtUsername.Text.Trim()}_private_key.pem");
                    SetStatus($"User ID: {userId}", true);
                    MessageBox.Show($"Tạo thành công!\nUser ID: {userId}\nPrivate key: {path}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsername.Clear(); txtPassword.Clear(); cboRole.SelectedIndex = 1;
                }
                else SetStatus($"{err}", false);
            }
            catch (Exception ex) { progressBar.Visible = false; SetStatus($"{ex.Message}", false); }
            finally { btnCreate.Enabled = btnCancel.Enabled = true; }
        }

        private void SetStatus(string msg, bool ok)
        {
            lblStatus.ForeColor = ok ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            lblStatus.Text = msg;
        }

        private bool ValidateField(TextBox txt, string name)
        {
            if (string.IsNullOrWhiteSpace(txt.Text)) { SetStatus($"Nhập {name}", false); txt.Focus(); return false; }
            return true;
        }

        private static string SaveKey(string key, string name)
        {
            string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "PrivateKeys");
            Directory.CreateDirectory(dir);
            string path = Path.Combine(dir, name);
            File.WriteAllText(path, key, System.Text.Encoding.UTF8);
            return path;
        }

        private void BtnCancel_Click(object? sender, EventArgs e) => Close();
    }
}
