using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace StudentManagementSystem
{
    public partial class FileUploadForm : Form
    {
        private readonly string _connStr, _userId, _role;
        public bool UploadSuccess { get; private set; }
        public string ResultMessage { get; private set; } = "";

        public FileUploadForm(string connStr, string user, string role)
        {
            _connStr = connStr; _userId = user; _role = role;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Size = new System.Drawing.Size(500, 320); Text = "Upload Private Key";
            StartPosition = FormStartPosition.CenterParent; FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = MinimizeBox = false; BackColor = System.Drawing.Color.White;

            lblTitle = new Label { Text = "Private Key Required", Location = new System.Drawing.Point(20, 20), Size = new System.Drawing.Size(450, 25),
                Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.DarkBlue, TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
            lblInstruction = new Label { Text = $"Upload private key for: {_role}", Location = new System.Drawing.Point(20, 60), Size = new System.Drawing.Size(450, 40) };
            lblSelectedFile = new Label { Text = "Selected:", Location = new System.Drawing.Point(20, 120), Size = new System.Drawing.Size(100, 20), Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold) };
            txtFilePath = new TextBox { Location = new System.Drawing.Point(20, 145), Size = new System.Drawing.Size(350, 25), ReadOnly = true, BackColor = System.Drawing.Color.LightGray };
            btnBrowse = new Button { Text = "Browse...", Location = new System.Drawing.Point(380, 145), Size = new System.Drawing.Size(80, 25), BackColor = System.Drawing.Color.LightBlue, FlatStyle = FlatStyle.Flat };
            btnBrowse.Click += BtnBrowse_Click;
            progressBar = new ProgressBar { Location = new System.Drawing.Point(20, 190), Size = new System.Drawing.Size(450, 20), Visible = false };
            btnUpload = new Button { Text = "Upload", Location = new System.Drawing.Point(200, 230), Size = new System.Drawing.Size(100, 35), BackColor = System.Drawing.Color.Green, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat, Enabled = false };
            btnUpload.Click += BtnUpload_Click;
            btnCancel = new Button { Text = "Cancel", Location = new System.Drawing.Point(320, 230), Size = new System.Drawing.Size(80, 35), BackColor = System.Drawing.Color.Gray, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnCancel.Click += BtnCancel_Click;
            fileDialog = new OpenFileDialog { Filter = "PEM Files (*.pem)|*.pem|All Files (*.*)|*.*", Title = "Select Private Key" };

            Controls.AddRange(new Control[] { lblTitle, lblInstruction, lblSelectedFile, txtFilePath, btnBrowse, progressBar, btnUpload, btnCancel });
        }

        private Label lblTitle = null!, lblInstruction = null!, lblSelectedFile = null!;
        private TextBox txtFilePath = null!;
        private Button btnBrowse = null!, btnUpload = null!, btnCancel = null!;
        private ProgressBar progressBar = null!;
        private OpenFileDialog fileDialog = null!;

        private void BtnBrowse_Click(object? sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = fileDialog.FileName;
                lblSelectedFile.Text = $"Selected: {new FileInfo(fileDialog.FileName).Name}";
                btnUpload.Enabled = true;
            }
        }

        private async void BtnUpload_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilePath.Text)) return;
            btnUpload.Enabled = btnBrowse.Enabled = btnCancel.Enabled = false;
            progressBar.Visible = true; progressBar.Style = ProgressBarStyle.Marquee;

            try
            {
                string content = await File.ReadAllTextAsync(txtFilePath.Text);
                using var conn = new OracleConnection(_connStr);
                await conn.OpenAsync();
                using var cmd = new OracleCommand("SELECT ADMIN_MASTER.SIMPLE_PEM_VALIDATION(:u,:f,:c) FROM DUAL", conn);
                cmd.Parameters.Add("u", _userId);
                cmd.Parameters.Add("f", Path.GetFileName(txtFilePath.Text));
                cmd.Parameters.Add(new OracleParameter("c", OracleDbType.Clob) { Value = content });
                var result = (await cmd.ExecuteScalarAsync())?.ToString() ?? "ERROR:Unknown";
                ProcessResult(result);
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { btnUpload.Enabled = btnBrowse.Enabled = btnCancel.Enabled = true; progressBar.Visible = false; }
        }

        private void ProcessResult(string result)
        {
            var parts = result.Split(':');
            if (parts[0] == "SUCCESS")
            {
                UploadSuccess = true; ResultMessage = "Success!";
                MessageBox.Show(ResultMessage, "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK; Close();
            }
            else
            {
                UploadSuccess = false; ResultMessage = parts.Length > 1 ? parts[1] : "Failed";
                MessageBox.Show($"Failed: {ResultMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Continue without key? (Read-only)", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { DialogResult = DialogResult.Cancel; Close(); }
        }
    }
}
