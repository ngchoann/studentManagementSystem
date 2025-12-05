using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Forms
{
    public partial class MainDashboard : Form
    {
        private readonly OracleEncryptionService _encryptionService;
        private readonly int _userId;
        private readonly string _username;
        private readonly string _role;
        private readonly Dictionary<string, string> _aesKeys;
        private bool _isUnlocked = false;

        public MainDashboard(int userId, string username, string role, string decryptedAESKeysData)
        {
            _userId = userId;
            _username = username;
            _role = role;
            _encryptionService = new OracleEncryptionService();
            _aesKeys = ParseAESKeysData(decryptedAESKeysData);

            InitializeComponent();
            LockUI();
            UnlockUI();
        }

        private Dictionary<string, string> ParseAESKeysData(string aesKeysData)
        {
            var keys = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(aesKeysData)) return keys;

            string[] pairs = aesKeysData.Split('|', StringSplitOptions.RemoveEmptyEntries);
            foreach (string pair in pairs)
            {
                string[] parts = pair.Split('=', 2);
                if (parts.Length == 2) keys[parts[0]] = parts[1];
            }
            return keys;
        }

        private void LockUI()
        {
            _isUnlocked = false;
            pnlMain.Enabled = false;
            menuStrip.Enabled = false;
            pnlLocked.Visible = true;
            pnlLocked.BringToFront();
            this.Opacity = 0.7;
            lblStatus.Text = "Giao diện đang bị khóa";
        }

        private void UnlockUI()
        {
            _isUnlocked = true;
            pnlMain.Enabled = true;
            menuStrip.Enabled = true;
            pnlLocked.Visible = false;
            this.Opacity = 1.0;
            lblStatus.Text = "Giao diện đã mở khóa - Có " + _aesKeys.Count + " bảng dữ liệu";
        }

        private void BtnLoadData_Click(object? sender, EventArgs e)
        {
            if (!_isUnlocked)
            {
                MessageBox.Show("Giao diện đang bị khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblStatus.Text = "Đang tải và giải mã dữ liệu...";
            if (_aesKeys.ContainsKey("ENCRYPTED_DATA"))
            {
                string aesKey = _aesKeys["ENCRYPTED_DATA"];
                var result = _encryptionService.DecryptAndGetData(_userId, aesKey);
                if (result.IsSuccess)
                {
                    dgvData.DataSource = ParseDecryptedData(result.DecryptedData);
                    lblStatus.Text = "Đã tải " + dgvData.Rows.Count + " bản ghi";
                }
                else
                {
                    lblStatus.Text = "Lỗi: " + result.ErrorMessage;
                }
            }
            else
            {
                lblStatus.Text = "Không tìm thấy AES key";
            }
        }

        private DataTable ParseDecryptedData(string data)
        {
            var table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Dữ liệu", typeof(string));
            table.Columns.Add("Mô tả", typeof(string));
            table.Columns.Add("Ngày tạo", typeof(string));

            if (string.IsNullOrEmpty(data)) return table;

            string[] records = data.Split('~', StringSplitOptions.RemoveEmptyEntries);
            foreach (string record in records)
            {
                string[] fields = record.Split('|', 4);
                if (fields.Length >= 4)
                {
                    DataRow row = table.NewRow();
                    row[0] = int.Parse(fields[0]);
                    row[1] = fields[1];
                    row[2] = fields[2];
                    row[3] = fields[3];
                    table.Rows.Add(row);
                }
            }
            return table;
        }

        private void BtnAddData_Click(object? sender, EventArgs e)
        {
            if (!_isUnlocked) return;
            string data = Microsoft.VisualBasic.Interaction.InputBox("Nhập dữ liệu cần mã hóa:", "Thêm dữ liệu mới", "");
            if (!string.IsNullOrEmpty(data))
            {
                string description = Microsoft.VisualBasic.Interaction.InputBox("Nhập mô tả:", "Mô tả dữ liệu", "");
                var result = _encryptionService.EncryptAndSaveData(_userId, data, description);
                if (result.IsSuccess)
                {
                    lblStatus.Text = "Đã lưu dữ liệu với ID: " + result.DataId;
                    BtnLoadData_Click(sender, e);
                }
                else
                {
                    lblStatus.Text = "Lỗi: " + result.ErrorMessage;
                }
            }
        }

        private void MnuViewData_Click(object? sender, EventArgs e) { BtnLoadData_Click(sender, e); }
        private void MnuAddData_Click(object? sender, EventArgs e) { BtnAddData_Click(sender, e); }

        private void MnuExportKey_Click(object? sender, EventArgs e)
        {
            if (_role != "ADMIN")
            {
                MessageBox.Show("Chỉ Admin mới có quyền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Export private key sẽ được thực hiện khi tạo user mới.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MnuCreateUser_Click(object? sender, EventArgs e)
        {
            if (_role != "ADMIN")
            {
                MessageBox.Show("Chỉ Admin mới có quyền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            new CreateUserForm(_encryptionService).ShowDialog();
        }

        private void MnuAbout_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Hệ thống Quản lý Mã hóa\n\nUser: " + _username + "\nRole: " + _role + "\nAES Keys: " + _aesKeys.Count + "\n\nRSA-2048 + AES-256", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MnuLogout_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _aesKeys.Clear();
            base.OnFormClosing(e);
        }
    }
}
