using System;
using System.Windows.Forms;
using StudentManagementSystem.DAL;

namespace StudentManagementSystem.Forms
{
    public partial class DiemForm : Form
    {
        private readonly DiemRepository _repo = new();
        private readonly string _role = "ADMIN";

        public DiemForm() => InitializeComponent();

        private void DiemForm_Load(object sender, EventArgs e) => LoadData();

        private void btnLoad_Click(object sender, EventArgs e) => LoadData();

        private void LoadData()
        {
            try
            {
                var list = _repo.GetAll();
                dgvDiem.DataSource = list;
                SetColumnHeaders();
                lblInfo.Text = $"Hiển thị {list.Count} bản ghi ({_role})";
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi: {ex.Message}"); }
        }

        private void SetColumnHeaders()
        {
            if (dgvDiem.Columns.Count == 0) return;
            var headers = new[] { ("MaDiem", "Mã điểm"), ("MaSV", "Mã SV"), ("MaHP", "Mã HP"),
                ("DiemGiuaKy", "Điểm GK"), ("DiemCuoiKy", "Điểm CK"), ("DiemKhac", "Điểm khác"),
                ("DiemTongKet", "Điểm TK"), ("MaKQ", "Mã KQ"), ("NgayNhap", "Ngày nhập"), ("NguoiNhap", "Người nhập") };
            foreach (var (col, header) in headers)
                if (dgvDiem.Columns.Contains(col)) dgvDiem.Columns[col].HeaderText = header;
        }
    }
}
