using System;
using System.Linq;
using System.Windows.Forms;
using StudentManagementSystem.Services;
using OracleCmd = Oracle.ManagedDataAccess.Client.OracleCommand;

namespace StudentManagementSystem.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly string _username, _role;
        private readonly bool _hasAccess;
        private readonly AuditService _audit = new();

        public DashboardForm(string username, string role, bool hasManagementAccess = true)
        {
            InitializeComponent();
            _username = username;
            _role = role;
            _hasAccess = hasManagementAccess;
        }

        private void LoadStatistics()
        {
            if (_role != "ADMIN") { HideStatsForNonAdmin(); return; }
            try
            {
                using var conn = new Oracle.ManagedDataAccess.Client.OracleConnection("User Id=ADMIN_MASTER;Password=123;Data Source=localhost:1521/orcl21pdb1;");
                conn.Open();
                lblTotalSinhVien.Text = $"Sinh viên: {GetCount(conn, "SINHVIEN")}";
                lblTotalGiaoVien.Text = $"Giáo viên: {GetCount(conn, "GIAOVIEN")}";
                lblTotalLop.Text = $"Lớp: {GetCount(conn, "LOP")}";
                lblTotalHocPhan.Text = $"Học phần: {GetCount(conn, "HOCPHAN")}";
            }
            catch { lblTotalSinhVien.Text = lblTotalGiaoVien.Text = lblTotalLop.Text = lblTotalHocPhan.Text = "Lỗi DB"; }
        }

        private static string GetCount(Oracle.ManagedDataAccess.Client.OracleConnection conn, string table)
        {
            try { using var cmd = new OracleCmd($"SELECT COUNT(*) FROM {table}", conn); return cmd.ExecuteScalar()?.ToString() ?? "N/A"; }
            catch { return "N/A"; }
        }

        private void HideStatsForNonAdmin()
        {
            lblTotalSinhVien.Visible = lblTotalGiaoVien.Visible = lblTotalLop.Visible = lblTotalHocPhan.Visible = false;
            var lbl = new Label
            {
                Text = _role is "STUDENT" or "SINHVIEN" ? "Chào sinh viên!" : "Chào giáo viên!",
                Font = new System.Drawing.Font("Segoe UI", 12F), Location = new System.Drawing.Point(400, 300), Size = new System.Drawing.Size(400, 40)
            };
            Controls.Add(lbl);
        }

        private bool CheckAccess(string action)
        {
            if (!_hasAccess && _role == "ADMIN")
            {
                _audit.LogApplicationEvent(_username, "ACCESS_DENIED", action, "Need Private Key");
                MessageBox.Show("Upload Private Key để có quyền!", "Cần xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnQuanLySinhVien_Click(object sender, EventArgs e)
        {
            _audit.LogApplicationEvent(_username, "STUDENT_MGMT_ACCESS", "StudentManagement", "Access");
            if (_role is "STUDENT" or "SINHVIEN") { new StudentPersonalInfoForm(_username).ShowDialog(); return; }
            if (!CheckAccess("StudentManagement")) return;
            new SinhVienForm(_role, _username, false).ShowDialog();
            LoadStatistics();
        }

        private void btnQuanLyGiaoVien_Click(object sender, EventArgs e)
        {
            if (!CheckAccess("TeacherManagement")) return;
            new GiaoVienForm().ShowDialog();
            LoadStatistics();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            lblUserInfo.Text = $"Người dùng: {_username} ({GetRoleName(_role)})";
            _audit.LogApplicationEvent(_username, "DASHBOARD_LOAD", "Dashboard", $"Role: {_role}");
            ConfigureMenuByRole();
            LoadStatistics();
        }

        private string GetRoleName(string role) => role switch
        {
            "ADMIN" => "Quản trị viên",
            "TEACHER" or "GIAOVIEN" => "Giáo viên",
            "STUDENT" or "SINHVIEN" => "Sinh viên",
            _ => "Người dùng"
        };

        private void ConfigureMenuByRole()
        {
            Text += _hasAccess ? " - Full Access" : " - Read-Only";
            bool isStudent = _role is "STUDENT" or "SINHVIEN";
            bool isTeacher = _role is "TEACHER" or "GIAOVIEN";
            bool isAdmin = _role == "ADMIN";

            if (isStudent)
            {
                // hide non-student buttons and build a denser, symmetric menu for students
                btnQuanLyGiaoVien.Visible = btnSystemConfig.Visible = btnMACSystem.Visible = btnAuditingSystem.Visible = btnBackupRecovery.Visible = false;
                btnQuanLySinhVien.Text = "Thong tin ca nhan"; btnQuanLyDiem.Text = "Xem diem cua toi";
                btnQuanLyHocPhan.Text = "📋 Dang ky hoc phan"; btnQuanLyLop.Text = "Xem cac lop";
                BuildStudentMenuLayout();
            }
            else if (isTeacher)
            {
                btnQuanLyGiaoVien.Text = "Xem Giao vien"; btnQuanLyLop.Text = "Xem Lop";
                btnSystemConfig.Visible = btnMACSystem.Visible = btnAuditingSystem.Visible = btnBackupRecovery.Visible = false;
                btnQuanLySinhVien.Text = _hasAccess ? "Quan ly Sinh vien" : "Xem Sinh vien (Read-only)";
                btnQuanLyDiem.Text = _hasAccess ? "Quan ly Diem" : "Xem Diem (Read-only)";
            }
            else if (isAdmin)
            {
                btnSystemConfig.Visible = btnMACSystem.Visible = btnAuditingSystem.Visible = btnBackupRecovery.Visible = true;
                if (_hasAccess)
                {
                    btnQuanLySinhVien.Text = "Quan ly Sinh vien"; btnQuanLyGiaoVien.Text = "Quan ly Giao vien";
                    btnQuanLyLop.Text = "Quan ly Lop"; btnQuanLyHocPhan.Text = "Quan ly Hoc phan"; btnQuanLyDiem.Text = "Quan ly Diem";
                }
                else
                {
                    btnQuanLySinhVien.Text = "Xem Sinh vien (Read-only)"; btnQuanLyGiaoVien.Text = "Xem Giao vien (Read-only)";
                    btnQuanLyLop.Text = "Xem Lop (Read-only)"; btnQuanLyHocPhan.Text = "Xem Hoc phan (Read-only)"; btnQuanLyDiem.Text = "Xem Diem (Read-only)";
                    btnSystemConfig.Enabled = btnMACSystem.Enabled = btnAuditingSystem.Enabled = btnBackupRecovery.Enabled = false;
                    AddUploadKeyButton();
                }
            }
        }

        private void BuildStudentMenuLayout()
        {
            // We'll create a compact layout: [btn1] - small spacer - [btn2] - flexible filler - [btn3] - small spacer - [btn4]
            // This ensures the gap between 1->2 equals gap between 3->4.
            tlpMenu.SuspendLayout();
            tlpMenu.Controls.Clear();
            tlpMenu.RowStyles.Clear();
            tlpMenu.ColumnCount = 1;

            // Define rows so the gap above and below the registration button is equal
            tlpMenu.RowCount = 7;
            // Use absolute row heights for consistent button heights
            float btnHeight = 48F; // desired button height
            float btnRow = btnHeight + 12F; // include vertical margins (~6 top + 6 bottom)
            tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, btnRow)); // 0: btn1 (Thong tin ca nhan)
            tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F)); // 1: spacer (above Dang ky)
            tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, btnRow)); // 2: btn2 (Dang ky hoc phan)
            tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F)); // 3: spacer (below Dang ky) - equal to above
            tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, btnRow)); // 4: btn3 (Xem diem cua toi)
            tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F)); // 5: spacer (between Diem and Lop)
            tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, btnRow)); // 6: btn4 (Xem cac lop)

            // Add controls in order
            tlpMenu.Controls.Add(btnQuanLySinhVien, 0, 0);
            tlpMenu.Controls.Add(btnQuanLyHocPhan, 0, 2);
            tlpMenu.Controls.Add(btnQuanLyDiem, 0, 4);
            tlpMenu.Controls.Add(btnQuanLyLop, 0, 6);

            // Ensure buttons fill available cell width and have consistent margins
            // ensure consistent column padding and disable AutoSize so widths are controlled by the layout
            tlpMenu.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            btnQuanLySinhVien.AutoSize = false; btnQuanLyHocPhan.AutoSize = false; btnQuanLyDiem.AutoSize = false; btnQuanLyLop.AutoSize = false;
            btnQuanLySinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            btnQuanLyHocPhan.Dock = System.Windows.Forms.DockStyle.Fill;
            btnQuanLyDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            btnQuanLyLop.Dock = System.Windows.Forms.DockStyle.Fill;

            var m = new System.Windows.Forms.Padding(6);
            btnQuanLySinhVien.Margin = m; btnQuanLyHocPhan.Margin = m; btnQuanLyDiem.Margin = m; btnQuanLyLop.Margin = m;

            // enforce fixed button height so none expand vertically
            int fixedHeight = 48;
            btnQuanLySinhVien.Height = fixedHeight; btnQuanLyHocPhan.Height = fixedHeight; btnQuanLyDiem.Height = fixedHeight; btnQuanLyLop.Height = fixedHeight;

            // normalize text alignment so visual widths feel consistent
            btnQuanLySinhVien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            btnQuanLyHocPhan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            btnQuanLyDiem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            btnQuanLyLop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            tlpMenu.ResumeLayout();
            // enforce a hard fixed width for all student menu buttons (no autosize)
            const int fixedWidth = 220; // px — hard-coded button width
            this.BeginInvoke((Action)(() =>
            {
                try
                {
                    foreach (var b in new[] { btnQuanLySinhVien, btnQuanLyHocPhan, btnQuanLyDiem, btnQuanLyLop })
                    {
                        b.AutoSize = false;
                        b.Dock = System.Windows.Forms.DockStyle.None;
                        b.MinimumSize = new System.Drawing.Size(fixedWidth, 0);
                        b.MaximumSize = new System.Drawing.Size(fixedWidth, int.MaxValue);
                        b.Width = fixedWidth;
                        // centre the button horizontally inside the table cell
                        b.Anchor = System.Windows.Forms.AnchorStyles.None;
                    }
                    tlpMenu.PerformLayout();
                }
                catch { }
            }));
        }

        private void AddUploadKeyButton()
        {
            var btn = new Button { Text = "Upload Private Key", Size = new System.Drawing.Size(180, 35), Location = new System.Drawing.Point(10, 10) };
            btn.Click += (s, e) =>
            {
                var form = new UploadKeyForm(1, _username, "123", _role);
                if (form.ShowDialog() == DialogResult.OK && form.UploadSuccess)
                { new DashboardForm(_username, _role, true).Show(); Close(); }
            };
            Controls.Add(btn);
        }

        private void btnQuanLyLop_Click(object sender, EventArgs e)
        {
            if (_role is "STUDENT" or "SINHVIEN") { new ViewClassesForm().ShowDialog(); return; }
            if (!CheckAccess("ClassManagement")) return;
            new LopForm().ShowDialog();
            LoadStatistics();
        }

        private void btnQuanLyHocPhan_Click(object sender, EventArgs e)
        {
            // Sinh viên mở form đăng ký học phần
            if (_role is "STUDENT" or "SINHVIEN") 
            { 
                new DangKyHocPhanForm().ShowDialog(); 
                return; 
            }
            if (!CheckAccess("CourseManagement")) return;
            new HocPhanForm().ShowDialog();
            LoadStatistics();
        }

        private void btnQuanLyDiem_Click(object sender, EventArgs e)
        {
            if (!CheckAccess("GradeManagement")) return;
            new DiemForm().ShowDialog();
            LoadStatistics();
        }

        private void btnSystemConfig_Click(object sender, EventArgs e)
        {
            if (!CheckAccess("SystemConfig")) return;
            new SystemConfigForm().ShowDialog();
        }

        private void btnMACSystem_Click(object sender, EventArgs e)
        {
            if (!CheckAccess("MACSystem")) return;
            new MACSecurityForm().ShowDialog();
        }

        private void btnAuditingSystem_Click(object sender, EventArgs e)
        {
            if (!CheckAccess("AuditSystem")) return;
            new AuditingSystemForm().ShowDialog();
        }

        private void btnBackupRecovery_Click(object sender, EventArgs e)
        {
            if (!CheckAccess("BackupRecovery")) return;
            new BackupRecoveryForm().ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _audit.LogApplicationEvent(_username, "APP_LOGOUT", "Dashboard", "Logout");
                Close();
                new LoginForm().Show();
            }
        }
    }
}
