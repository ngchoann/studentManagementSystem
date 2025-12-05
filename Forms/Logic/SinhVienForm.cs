using System;
using System.Linq;
using System.Windows.Forms;
using StudentManagementSystem.DAL;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Forms
{
    public partial class SinhVienForm : Form
    {
        private readonly SinhVienRepository _repo = new();
        private readonly LopRepository _lopRepo = new();
        private readonly string _role, _username;
        private readonly bool _isPersonalView;

        public SinhVienForm() : this("ADMIN", "", false) { }

        public SinhVienForm(string role, string username = "", bool isPersonalView = false)
        {
            InitializeComponent();
            _role = role;
            _username = username;
            _isPersonalView = isPersonalView;
            txtMaSV.ReadOnly = true;
            txtMaSV.BackColor = System.Drawing.Color.LightGray;
            txtMaSV.Text = "(Tự động)";
        }

        private void SinhVienForm_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadLopComboBox();
            SetPermissions();
        }

        private void LoadData()
        {
            try
            {
                var list = _repo.GetAll();
                if (_isPersonalView && !string.IsNullOrEmpty(_username))
                {
                    list = list.Where(s => s.OracleUsername == _username).ToList();
                    btnThem.Visible = false;
                    btnXoa.Visible = false;
                    btnSua.Text = "Cập nhật";
                    Text = "Thông tin cá nhân - " + _username;
                }
                dgvSinhVien.DataSource = list;
                SetColumnHeaders();
            }
            catch (Exception ex) { ShowError("Lỗi load dữ liệu", ex); }
        }

        private void SetColumnHeaders()
        {
            if (dgvSinhVien.Columns.Count == 0) return;
            var headers = new[] { ("MaSV", "Mã SV"), ("HoTen", "Họ tên"), ("NgaySinh", "Ngày sinh"),
                ("GioiTinh", "Giới tính"), ("Email", "Email"), ("SoDienThoai", "Số ĐT"),
                ("DiaChi", "Địa chỉ"), ("MaLop", "Mã lớp"), ("NgayNhapHoc", "Ngày nhập học"), ("TrangThai", "Trạng thái") };
            foreach (var (col, header) in headers)
                if (dgvSinhVien.Columns.Contains(col)) dgvSinhVien.Columns[col].HeaderText = header;
        }

        private void LoadLopComboBox()
        {
            try
            {
                cboMaLop.DataSource = _lopRepo.GetAll();
                cboMaLop.DisplayMember = "TenLop";
                cboMaLop.ValueMember = "MaLop";
                cboMaLop.SelectedIndex = -1;
            }
            catch (Exception ex) { ShowError("Lỗi load lớp", ex); }
        }

        private void SetPermissions()
        {
            bool isAdmin = _role == "ADMIN";
            bool isStudent = _role is "STUDENT" or "SINHVIEN";
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = isAdmin;
            if (isStudent)
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvSinhVien.Rows[e.RowIndex];
            txtMaSV.Text = row.Cells["MaSV"].Value?.ToString() ?? "";
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
            dtpNgaySinh.Value = GetDate(row.Cells["NgaySinh"].Value);
            cboGioiTinh.Text = row.Cells["GioiTinh"].Value?.ToString() ?? "";
            txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
            txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value?.ToString() ?? "";
            txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString() ?? "";
            cboMaLop.SelectedValue = row.Cells["MaLop"].Value?.ToString() ?? "";
            dtpNgayNhapHoc.Value = GetDate(row.Cells["NgayNhapHoc"].Value);
        }

        private static DateTime GetDate(object? val) => val != null && val != DBNull.Value ? Convert.ToDateTime(val) : DateTime.Now;

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            if (!ValidateField(txtUsername, "tên đăng nhập") || !ValidateField(txtPassword, "mật khẩu")) return;
            if (_repo.Insert(CreateSinhVien(), txtUsername.Text.Trim(), txtPassword.Text.Trim(), _username))
            { LoadData(); ClearInputs(); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) || txtMaSV.Text == "(Tự động)")
            { ShowWarning("Vui lòng chọn sinh viên!"); return; }
            if (!ValidateInput()) return;
            if (_repo.Update(CreateSinhVien(), _username))
            { ShowInfo("Cập nhật thành công!"); LoadData(); ClearInputs(); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text)) { ShowWarning("Vui lòng chọn sinh viên!"); return; }
            if (MessageBox.Show($"Xóa sinh viên {txtMaSV.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                if (_repo.Delete(txtMaSV.Text.Trim(), _username)) { ShowInfo("Xóa thành công!"); LoadData(); ClearInputs(); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { ClearInputs(); LoadData(); }

        private SinhVien CreateSinhVien() => new()
        {
            MaSV = txtMaSV.Text.Trim(),
            HoTen = txtHoTen.Text.Trim(),
            NgaySinh = dtpNgaySinh.Value,
            GioiTinh = cboGioiTinh.Text,
            Email = txtEmail.Text.Trim(),
            SoDienThoai = txtSoDienThoai.Text.Trim(),
            DiaChi = txtDiaChi.Text.Trim(),
            MaLop = cboMaLop.SelectedValue?.ToString() ?? "",
            NgayNhapHoc = dtpNgayNhapHoc.Value,
            TrangThai = 1
        };

        private bool ValidateInput() =>
            ValidateField(txtHoTen, "họ tên") &&
            ValidateCombo(cboGioiTinh, "giới tính") &&
            ValidateCombo(cboMaLop, "lớp");

        private bool ValidateField(TextBox txt, string name)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            { ShowWarning($"Vui lòng nhập {name}!"); txt.Focus(); return false; }
            return true;
        }

        private bool ValidateCombo(ComboBox cbo, string name)
        {
            if (cbo.SelectedValue == null && string.IsNullOrWhiteSpace(cbo.Text))
            { ShowWarning($"Vui lòng chọn {name}!"); cbo.Focus(); return false; }
            return true;
        }

        private void ClearInputs()
        {
            txtMaSV.Text = "(Tự động)";
            txtHoTen.Clear(); txtEmail.Clear(); txtSoDienThoai.Clear(); txtDiaChi.Clear();
            txtUsername.Clear(); txtPassword.Clear();
            cboGioiTinh.SelectedIndex = cboMaLop.SelectedIndex = -1;
            dtpNgaySinh.Value = dtpNgayNhapHoc.Value = DateTime.Now;
        }

        private static void ShowWarning(string msg) => MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private static void ShowInfo(string msg) => MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private static void ShowError(string title, Exception ex) => MessageBox.Show($"{title}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
