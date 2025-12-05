using System;
using System.IO;
using System.Windows.Forms;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Forms
{
    /// <summary>
    /// Form upload private key - Yêu cầu user upload file private key
    /// Gọi Oracle để decrypt AES keys và mở khóa giao diện
    /// </summary>
    public partial class UploadKeyForm : Form
    {
        private readonly OracleEncryptionService _encryptionService;
        private readonly int _userId;
        private readonly string _username;
        private readonly string _password;
        private readonly string _role;
        
        // Controls
        private Label lblTitle = null!;
        private Label lblInstruction = null!;
        private TextBox txtKeyFilePath = null!;
        private Button btnBrowse = null!;
        private Button btnUpload = null!;
        private Button btnCancel = null!;
        private Label lblStatus = null!;
        private ProgressBar progressBar = null!;

        // Decrypted AES keys data
        public string DecryptedAESKeys { get; private set; } = "";
        public bool UploadSuccess { get; private set; } = false;

        public UploadKeyForm(int userId, string username, string password, string role)
        {
            _userId = userId;
            _username = username;
            _password = password;
            _role = role;
            _encryptionService = new OracleEncryptionService();
            
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form properties
            this.Text = "Upload Private Key - Bảo mật hệ thống";
            this.Size = new System.Drawing.Size(500, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Title
            lblTitle = new Label();
            lblTitle.Text = "XÁC THỰC PRIVATE KEY";
            lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            lblTitle.Location = new System.Drawing.Point(100, 20);
            lblTitle.Size = new System.Drawing.Size(300, 25);
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.Controls.Add(lblTitle);

            // Instruction
            lblInstruction = new Label();
            lblInstruction.Text = $"Chào {_username} ({_role})\n\n" +
                                  "Để truy cập hệ thống, bạn cần upload file private key (.pem)\n" +
                                  "Private key sẽ được sử dụng để giải mã dữ liệu của bạn.\n\n" +
                                  "Vui lòng chọn file private key:";
            lblInstruction.Location = new System.Drawing.Point(30, 60);
            lblInstruction.Size = new System.Drawing.Size(440, 80);
            lblInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Controls.Add(lblInstruction);

            // File path textbox
            txtKeyFilePath = new TextBox();
            txtKeyFilePath.Location = new System.Drawing.Point(30, 150);
            txtKeyFilePath.Size = new System.Drawing.Size(340, 25);
            txtKeyFilePath.ReadOnly = true;
            txtKeyFilePath.BackColor = System.Drawing.Color.White;
            this.Controls.Add(txtKeyFilePath);

            // Browse button
            btnBrowse = new Button();
            btnBrowse.Text = "Chọn file...";
            btnBrowse.Location = new System.Drawing.Point(380, 148);
            btnBrowse.Size = new System.Drawing.Size(90, 29);
            btnBrowse.Click += BtnBrowse_Click;
            this.Controls.Add(btnBrowse);

            // Upload button
            btnUpload = new Button();
            btnUpload.Text = "Upload và Xác thực";
            btnUpload.Location = new System.Drawing.Point(150, 200);
            btnUpload.Size = new System.Drawing.Size(140, 35);
            btnUpload.BackColor = System.Drawing.Color.Green;
            btnUpload.ForeColor = System.Drawing.Color.White;
            btnUpload.FlatStyle = FlatStyle.Flat;
            btnUpload.Enabled = false;
            btnUpload.Click += BtnUpload_Click;
            this.Controls.Add(btnUpload);

            // Cancel button
            btnCancel = new Button();
            btnCancel.Text = "Hủy";
            btnCancel.Location = new System.Drawing.Point(300, 200);
            btnCancel.Size = new System.Drawing.Size(80, 35);
            btnCancel.Click += BtnCancel_Click;
            this.Controls.Add(btnCancel);

            // Progress bar
            progressBar = new ProgressBar();
            progressBar.Location = new System.Drawing.Point(30, 250);
            progressBar.Size = new System.Drawing.Size(440, 20);
            progressBar.Visible = false;
            this.Controls.Add(progressBar);

            // Status label
            lblStatus = new Label();
            lblStatus.Location = new System.Drawing.Point(30, 280);
            lblStatus.Size = new System.Drawing.Size(440, 40);
            lblStatus.ForeColor = System.Drawing.Color.Red;
            lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Controls.Add(lblStatus);

            this.ResumeLayout(false);
        }

        private void BtnBrowse_Click(object? sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Chọn Private Key File";
                    openFileDialog.Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        txtKeyFilePath.Text = openFileDialog.FileName;
                        btnUpload.Enabled = true;
                        lblStatus.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chọn file: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpload_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtKeyFilePath.Text))
                {
                    lblStatus.Text = "Vui lòng chọn file private key";
                    return;
                }

                if (!File.Exists(txtKeyFilePath.Text))
                {
                    lblStatus.Text = "File không tồn tại";
                    return;
                }

                // Show progress
                progressBar.Visible = true;
                progressBar.Style = ProgressBarStyle.Marquee;
                btnUpload.Enabled = false;
                btnBrowse.Enabled = false;
                lblStatus.ForeColor = System.Drawing.Color.Blue;
                lblStatus.Text = "Đang đọc và xác thực private key...";

                // Read private key content
                string privateKeyContent = File.ReadAllText(txtKeyFilePath.Text);

                if (string.IsNullOrWhiteSpace(privateKeyContent))
                {
                    throw new Exception("File private key trống hoặc không hợp lệ");
                }

                lblStatus.Text = "Đang xác thực private key với Oracle...";

                // SỬ DỤNG CRYPTO PACKAGE ĐỂ XÁC THỰC VÀ GIẢI MÃ AES KEY
                try
                {
                    var encryptionService = new Services.OracleEncryptionService();
                    
                    lblStatus.Text = "Đang xác thực private key và giải mã AES key...";
                    
                    // Gọi Oracle function để xác thực và giải mã AES key thực sự
                    var (isValid, userId, role, aesKey, message) = encryptionService.AuthenticateUserAndDecryptAES(
                        _username, _password, privateKeyContent);
                    
                    progressBar.Visible = false;
                    
                    if (isValid && !string.IsNullOrEmpty(aesKey))
                    {
                        // Private key hợp lệ - XÁC THỰC THÀNH CÔNG và đã giải mã AES key
                        DecryptedAESKeys = aesKey; // Lưu AES key đã giải mã
                        UploadSuccess = true;

                        lblStatus.ForeColor = System.Drawing.Color.Green;
                        lblStatus.Text = "✓ Private key được XÁC THỰC và AES key đã giải mã thành công!";

                        // Delay to show success message, then open Dashboard với full access
                        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                        timer.Interval = 1500;
                        timer.Tick += (s, args) =>
                        {
                            timer.Stop();
                            
                            // Mở Dashboard với full management access
                            var dashboard = new DashboardForm(_username, role, true); // true = hasManagementAccess
                            dashboard.Show();
                            
                            // Đóng form upload và login
                            this.Hide();
                            
                            // Tìm và đóng LoginForm
                            foreach (Form form in Application.OpenForms)
                            {
                                if (form is LoginForm)
                                {
                                    form.Hide();
                                    break;
                                }
                            }
                        };
                        timer.Start();
                    }
                    else
                    {
                        // Private key BỊ TỪ CHỐI bởi Oracle
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                        lblStatus.Text = $"✗ Oracle TỪ CHỐI private key: {message}";
                        UploadSuccess = false;
                    }
                }
                catch (Exception oracleEx)
                {
                    progressBar.Visible = false;
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = $"✗ LỖI Oracle validation: {oracleEx.Message}";
                    UploadSuccess = false;
                }
            }
            catch (Exception ex)
            {
                progressBar.Visible = false;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = $"✗ Lỗi: {ex.Message}";
                UploadSuccess = false;
            }
            finally
            {
                btnUpload.Enabled = true;
                btnBrowse.Enabled = true;
            }
        }

        private void OpenMainDashboard()
        {
            try
            {
                // Hide this form and open dashboard
                this.Hide();

                MainDashboard dashboard = new MainDashboard(_userId, _username, _role, DecryptedAESKeys);
                dashboard.FormClosed += (s, args) =>
                {
                    // When dashboard closes, close this form too
                    this.Close();
                };
                dashboard.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở dashboard: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!UploadSuccess)
            {
                DialogResult result = MessageBox.Show(
                    "Bạn chưa xác thực private key thành công.\nThoát sẽ đăng xuất khỏi hệ thống.\n\nBạn có chắc muốn thoát?", 
                    "Xác nhận thoát", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            base.OnFormClosing(e);
        }
    }
}