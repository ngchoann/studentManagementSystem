using System;
using System.Windows.Forms;
using StudentManagementSystem.DAL;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Forms
{
    public partial class GiaoVienForm : Form
    {
        private readonly GiaoVienRepository _repo = new();
        private readonly string _role = "ADMIN";

        public GiaoVienForm()
        {
            InitializeComponent();
            txtMaGV.ReadOnly = true;
            txtMaGV.BackColor = System.Drawing.Color.LightGray;
            txtMaGV.Text = "(Tự động)";
        }

        private void GiaoVienForm_Load(object sender, EventArgs e)
        {
            LoadData();
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = _role == "ADMIN";
        }

        private void LoadData()
        {
            try
            {
                dgvGiaoVien.DataSource = _repo.GetAll();
                SetColumnHeaders();
            }
            catch (Exception ex) { ShowError("Lỗi load dữ liệu", ex); }
        }

        private void SetColumnHeaders()
        {
            if (dgvGiaoVien.Columns.Count == 0) return;
            var headers = new[] { ("MaGV", "Mã GV"), ("HoTen", "Họ tên"), ("NgaySinh", "Ngày sinh"),
                ("GioiTinh", "Giới tính"), ("Email", "Email"), ("SoDienThoai", "Số ĐT"),
                ("DiaChi", "Địa chỉ"), ("ChuyenMon", "Chuyên môn"), ("NgayVaoLam", "Ngày vào làm"), ("TrangThai", "Trạng thái") };
            foreach (var (col, header) in headers)
                if (dgvGiaoVien.Columns.Contains(col)) dgvGiaoVien.Columns[col].HeaderText = header;
        }

        private void dgvGiaoVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvGiaoVien.Rows[e.RowIndex];
            txtMaGV.Text = row.Cells["MaGV"].Value?.ToString() ?? "";
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
            dtpNgaySinh.Value = GetDate(row.Cells["NgaySinh"].Value);
            cboGioiTinh.Text = row.Cells["GioiTinh"].Value?.ToString() ?? "";
            txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
            txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value?.ToString() ?? "";
            txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString() ?? "";
            txtChuyenMon.Text = row.Cells["ChuyenMon"].Value?.ToString() ?? "";
            dtpNgayVaoLam.Value = GetDate(row.Cells["NgayVaoLam"].Value);
        }

        private static DateTime GetDate(object? val) => val != null && val != DBNull.Value ? Convert.ToDateTime(val) : DateTime.Now;

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            if (!ValidateField(txtUsername, "tên đăng nhập") || !ValidateField(txtPassword, "mật khẩu")) return;
            if (_repo.Insert(CreateGiaoVien(), txtUsername.Text.Trim(), txtPassword.Text.Trim()))
            { LoadData(); ClearInputs(); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaGV.Text)) { ShowWarning("Chọn giáo viên!"); return; }
            if (!ValidateInput()) return;
            if (_repo.Update(CreateGiaoVien()))
            { ShowInfo("Cập nhật thành công!"); LoadData(); ClearInputs(); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaGV.Text)) { ShowWarning("Chọn giáo viên!"); return; }
            if (MessageBox.Show($"Xóa giáo viên {txtMaGV.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                if (_repo.Delete(txtMaGV.Text.Trim())) { ShowInfo("Xóa thành công!"); LoadData(); ClearInputs(); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e) => ClearInputs();

        private GiaoVien CreateGiaoVien() => new()
        {
            MaGV = txtMaGV.Text.Trim(),
            HoTen = txtHoTen.Text.Trim(),
            NgaySinh = dtpNgaySinh.Value,
            GioiTinh = cboGioiTinh.Text,
            Email = txtEmail.Text.Trim(),
            SoDienThoai = txtSoDienThoai.Text.Trim(),
            DiaChi = txtDiaChi.Text.Trim(),
            ChuyenMon = txtChuyenMon.Text.Trim(),
            NgayVaoLam = dtpNgayVaoLam.Value,
            TrangThai = 1
        };

        private bool ValidateInput() =>
            ValidateField(txtHoTen, "họ tên") &&
            ValidateCombo(cboGioiTinh, "giới tính");

        private bool ValidateField(TextBox txt, string name, string? skip = null)
        {
            if (string.IsNullOrWhiteSpace(txt.Text) || (skip != null && txt.Text == skip))
            { ShowWarning($"Nhập {name}!"); txt.Focus(); return false; }
            return true;
        }

        private bool ValidateCombo(ComboBox cbo, string name)
        {
            if (string.IsNullOrWhiteSpace(cbo.Text))
            { ShowWarning($"Chọn {name}!"); cbo.Focus(); return false; }
            return true;
        }

        private void ClearInputs()
        {
            txtMaGV.Text = "(Tự động)";
            txtHoTen.Clear(); txtEmail.Clear(); txtSoDienThoai.Clear(); txtDiaChi.Clear();
            txtChuyenMon.Clear(); txtUsername.Clear(); txtPassword.Clear();
            cboGioiTinh.SelectedIndex = -1;
            dtpNgaySinh.Value = dtpNgayVaoLam.Value = DateTime.Now;
        }

        private static void ShowWarning(string msg) => MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private static void ShowInfo(string msg) => MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private static void ShowError(string title, Exception ex) => MessageBox.Show($"{title}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
