using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Forms
{
    public partial class BackupRecoveryForm : Form
    {
        private TabControl tabControl = null!;
        private TextBox txtBackupPath = null!;
        private TextBox txtRestoreFile = null!;
        private ComboBox cboTableAction = null!;
        private Button btnBackup = null!;
        private Button btnRestore = null!;
        private RichTextBox rtbOutput = null!;
        private Label lblStatus = null!;
        private ProgressBar progressBar = null!;

        public BackupRecoveryForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Size = new Size(950, 700);
            this.Text = "Backup & Recovery - Sao lưu và Phục hồi dữ liệu";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 9F);

            // Status bar at bottom
            var statusPanel = new Panel
            {
                Height = 35,
                Dock = DockStyle.Bottom,
                BackColor = Color.FromArgb(240, 240, 240)
            };

            lblStatus = new Label
            {
                Text = "Sẵn sàng",
                Location = new Point(10, 8),
                AutoSize = true
            };

            progressBar = new ProgressBar
            {
                Location = new Point(500, 6),
                Size = new Size(200, 20),
                Visible = false,
                Style = ProgressBarStyle.Marquee
            };

            statusPanel.Controls.AddRange(new Control[] { lblStatus, progressBar });
            this.Controls.Add(statusPanel);

            // Output panel at bottom (above status)
            rtbOutput = new RichTextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 9.5F),
                ReadOnly = true,
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.LightGreen,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Tab control at top
            tabControl = new TabControl
            {
                Dock = DockStyle.Top,
                Height = 180,
                Font = new Font("Segoe UI", 10F)
            };

            // === BACKUP TAB ===
            var tabBackup = new TabPage("Sao lưu (Backup)");
            tabBackup.Padding = new Padding(15);

            var lblBackupTitle = new Label
            {
                Text = "Sao lưu toàn bộ dữ liệu (Data Pump Export)",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };

            var lblBackupPath = new Label
            {
                Text = "Thư mục lưu:",
                Location = new Point(10, 50),
                AutoSize = true
            };

            txtBackupPath = new TextBox
            {
                Location = new Point(120, 47),
                Size = new Size(450, 25),
                Text = @"D:\BMCSDL\Backup"
            };

            var btnBrowseBackup = new Button
            {
                Text = "Chọn...",
                Location = new Point(580, 46),
                Size = new Size(70, 26)
            };
            btnBrowseBackup.Click += (s, e) =>
            {
                using var dlg = new FolderBrowserDialog { SelectedPath = txtBackupPath.Text };
                if (dlg.ShowDialog() == DialogResult.OK) txtBackupPath.Text = dlg.SelectedPath;
            };

            btnBackup = new Button
            {
                Text = "Chạy Backup",
                Location = new Point(120, 90),
                Size = new Size(150, 35),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnBackup.Click += BtnBackup_Click;

            tabBackup.Controls.AddRange(new Control[] { lblBackupTitle, lblBackupPath, txtBackupPath, btnBrowseBackup, btnBackup });

            // === RESTORE TAB ===
            var tabRestore = new TabPage("Phục hồi (Restore)");
            tabRestore.Padding = new Padding(15);

            var lblRestoreTitle = new Label
            {
                Text = "Phục hồi dữ liệu từ file backup (Data Pump Import)",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };

            var lblRestoreFile = new Label
            {
                Text = "File backup (.dmp):",
                Location = new Point(10, 50),
                AutoSize = true
            };

            txtRestoreFile = new TextBox
            {
                Location = new Point(130, 47),
                Size = new Size(440, 25),
                Text = ""
            };

            var btnBrowseRestore = new Button
            {
                Text = "Chọn...",
                Location = new Point(580, 46),
                Size = new Size(70, 26)
            };
            btnBrowseRestore.Click += (s, e) =>
            {
                using var dlg = new OpenFileDialog
                {
                    Filter = "Oracle Dump Files (*.dmp)|*.dmp|All Files (*.*)|*.*",
                    InitialDirectory = @"D:\BMCSDL\Backup"
                };
                if (dlg.ShowDialog() == DialogResult.OK) txtRestoreFile.Text = dlg.FileName;
            };

            var lblAction = new Label
            {
                Text = "Nếu bảng đã có dữ liệu:",
                Location = new Point(10, 90),
                AutoSize = true
            };

            cboTableAction = new ComboBox
            {
                Location = new Point(170, 87),
                Size = new Size(200, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboTableAction.Items.AddRange(new[] { "TRUNCATE - Xóa sạch rồi import", "APPEND - Thêm vào", "SKIP - Bỏ qua", "REPLACE - Thay thế" });
            cboTableAction.SelectedIndex = 0;

            btnRestore = new Button
            {
                Text = "Chạy Restore",
                Location = new Point(400, 85),
                Size = new Size(150, 35),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnRestore.Click += BtnRestore_Click;

            tabRestore.Controls.AddRange(new Control[] { lblRestoreTitle, lblRestoreFile, txtRestoreFile, btnBrowseRestore, lblAction, cboTableAction, btnRestore });

            tabControl.TabPages.Add(tabBackup);
            tabControl.TabPages.Add(tabRestore);

            this.Controls.Add(rtbOutput);
            this.Controls.Add(tabControl);
        }

        private async void BtnBackup_Click(object? sender, EventArgs e)
        {
            try
            {
                SetRunning(true, "Đang thực hiện backup...");
                rtbOutput.Clear();

                string? scriptPath = FindScript("backup_all_data.ps1");
                if (string.IsNullOrEmpty(scriptPath))
                    throw new InvalidOperationException("Không tìm thấy file backup_all_data.ps1");

                string target = string.IsNullOrWhiteSpace(txtBackupPath.Text) ? @"D:\BMCSDL\Backup" : txtBackupPath.Text.Trim();

                var result = await SimpleBackupRunner.RunAsync(scriptPath, target, AppendOutput);

                lblStatus.Text = result.Code == 0
                    ? $"Backup hoàn tất lúc {DateTime.Now:HH:mm:ss}"
                    : $"Backup hoàn tất với mã {result.Code}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Backup thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Lỗi: {ex.Message}";
            }
            finally
            {
                SetRunning(false);
            }
        }

        private async void BtnRestore_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRestoreFile.Text) || !File.Exists(txtRestoreFile.Text))
            {
                MessageBox.Show("Vui lòng chọn file backup (.dmp) hợp lệ!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn restore từ file:\n{txtRestoreFile.Text}\n\nDữ liệu hiện tại có thể bị ghi đè!",
                "Xác nhận Restore",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                SetRunning(true, "Đang thực hiện restore...");
                rtbOutput.Clear();

                string? scriptPath = FindScript("restore_all_data.ps1");
                if (string.IsNullOrEmpty(scriptPath))
                    throw new InvalidOperationException("Không tìm thấy file restore_all_data.ps1");

                string tableAction = cboTableAction.SelectedItem?.ToString()?.Split(' ')[0] ?? "TRUNCATE";

                var result = await SimpleBackupRunner.RunRestoreAsync(scriptPath, txtRestoreFile.Text, tableAction, AppendOutput);

                lblStatus.Text = result.Code == 0
                    ? $"Restore hoàn tất lúc {DateTime.Now:HH:mm:ss}"
                    : $"Restore hoàn tất với mã {result.Code}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Restore thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Lỗi: {ex.Message}";
            }
            finally
            {
                SetRunning(false);
            }
        }

        private void AppendOutput(string line)
        {
            if (rtbOutput.InvokeRequired)
                rtbOutput.BeginInvoke(() => { rtbOutput.AppendText(line + "\n"); rtbOutput.ScrollToCaret(); });
            else
            { rtbOutput.AppendText(line + "\n"); rtbOutput.ScrollToCaret(); }
        }

        private void SetRunning(bool running, string? status = null)
        {
            btnBackup.Enabled = !running;
            btnRestore.Enabled = !running;
            progressBar.Visible = running;
            if (status != null) lblStatus.Text = status;
            if (!running && status == null) lblStatus.Text = "Sẵn sàng";
        }

        private static string? FindScript(string scriptName)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var dir = new DirectoryInfo(baseDir);

            for (int i = 0; i < 6 && dir != null; i++)
            {
                string candidate = Path.Combine(dir.FullName, "OracleScripts", scriptName);
                if (File.Exists(candidate)) return candidate;
                dir = dir.Parent;
            }
            return null;
        }
    }
}
