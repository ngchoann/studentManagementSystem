using System;
using System.Windows.Forms;
using StudentManagementSystem.DAL;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Forms
{
    public partial class LopForm : Form
    {
        private readonly LopRepository _repo = new();
        private readonly GiaoVienRepository _gvRepo = new();
        private readonly string _role = "ADMIN";

        public LopForm() => InitializeComponent();

        private void LopForm_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadGiaoVienComboBox();
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = _role == "ADMIN";
        }

        private void LoadData()
        {
            try
            {
                dgvLop.DataSource = _repo.GetAll();
                SetColumnHeaders();
            }
            catch (Exception ex) { ShowError("Lỗi load dữ liệu", ex); }
        }

        private void SetColumnHeaders()
        {
            if (dgvLop.Columns.Count == 0) return;
            var headers = new[] { ("MaLop", "Mã lớp"), ("TenLop", "Tên lớp"), ("Khoa", "Khoa"),
                ("NienKhoa", "Niên khóa"), ("MaGVCN", "GVCN"), ("SiSo", "Sĩ số"), ("TrangThai", "Trạng thái") };
            foreach (var (col, header) in headers)
                if (dgvLop.Columns.Contains(col)) dgvLop.Columns[col].HeaderText = header;
        }

        private void LoadGiaoVienComboBox()
        {
            try
            {
                cboMaGVCN.DataSource = _gvRepo.GetAll();
                cboMaGVCN.DisplayMember = "HoTen";
                cboMaGVCN.ValueMember = "MaGV";
                cboMaGVCN.SelectedIndex = -1;
            }
            catch (Exception ex) { ShowError("Lỗi load GV", ex); }
        }

        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvLop.Rows[e.RowIndex];
            txtMaLop.Text = row.Cells["MaLop"].Value?.ToString() ?? "";
            txtTenLop.Text = row.Cells["TenLop"].Value?.ToString() ?? "";
            txtKhoa.Text = row.Cells["Khoa"].Value?.ToString() ?? "";
            txtNienKhoa.Text = row.Cells["NienKhoa"].Value?.ToString() ?? "";
            cboMaGVCN.SelectedValue = row.Cells["MaGVCN"].Value?.ToString() ?? "";
            numSiSo.Value = Convert.ToInt32(row.Cells["SiSo"].Value ?? 0);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            if (_repo.Insert(CreateLop()))
            { ShowInfo("Thêm lớp thành công!"); LoadData(); ClearInputs(); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text)) { ShowWarning("Chọn lớp!"); return; }
            if (!ValidateInput()) return;
            if (_repo.Update(CreateLop()))
            { ShowInfo("Cập nhật thành công!"); LoadData(); ClearInputs(); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text)) { ShowWarning("Chọn lớp!"); return; }
            if (MessageBox.Show($"Xóa lớp {txtMaLop.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                if (_repo.Delete(txtMaLop.Text.Trim())) { ShowInfo("Xóa thành công!"); LoadData(); ClearInputs(); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e) => ClearInputs();

        private Lop CreateLop() => new()
        {
            MaLop = txtMaLop.Text.Trim(),
            TenLop = txtTenLop.Text.Trim(),
            Khoa = txtKhoa.Text.Trim(),
            NienKhoa = txtNienKhoa.Text.Trim(),
            MaGVCN = cboMaGVCN.SelectedValue?.ToString() ?? "",
            SiSo = (int)numSiSo.Value,
            TrangThai = 1
        };

        private bool ValidateInput() =>
            ValidateField(txtMaLop, "mã lớp") && ValidateField(txtTenLop, "tên lớp");

        private bool ValidateField(TextBox txt, string name)
        {
            if (string.IsNullOrWhiteSpace(txt.Text)) { ShowWarning($"Nhập {name}!"); txt.Focus(); return false; }
            return true;
        }

        private void ClearInputs()
        {
            txtMaLop.Clear(); txtTenLop.Clear(); txtKhoa.Clear(); txtNienKhoa.Clear();
            cboMaGVCN.SelectedIndex = -1; numSiSo.Value = 0;
        }

        private static void ShowWarning(string msg) => MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private static void ShowInfo(string msg) => MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private static void ShowError(string title, Exception ex) => MessageBox.Show($"{title}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
