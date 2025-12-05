using System;
using System.Windows.Forms;
using StudentManagementSystem.DAL;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Forms
{
    public partial class HocPhanForm : Form
    {
        private readonly HocPhanRepository _repo = new();
        private readonly string _role = "ADMIN";

        public HocPhanForm()
        {
            InitializeComponent();
            txtMaHP.ReadOnly = true;
            txtMaHP.BackColor = System.Drawing.Color.LightGray;
            txtMaHP.Text = "(Tu dong)";
            LoadGiaoVienCombo();
        }

        private void HocPhanForm_Load(object sender, EventArgs e)
        {
            LoadData();
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = _role == "ADMIN";
        }

        private void LoadData()
        {
            try
            {
                dgvHocPhan.DataSource = _repo.GetAll();
                SetColumnHeaders();
            }
            catch (Exception ex) { ShowError("Loi load du lieu", ex); }
        }

        private void SetColumnHeaders()
        {
            if (dgvHocPhan.Columns.Count == 0) return;
            var headers = new[] { ("MaHP", "Ma HP"), ("TenHP", "Ten hoc phan"), ("MaGV", "Ma GV"),
                ("MaSoTC", "Ma so TC"), ("HocKy", "Hoc ky"), ("NamHoc", "Nam hoc"),
                ("MoTa", "Mo ta"), ("TrangThai", "Trang thai") };
            foreach (var (col, header) in headers)
                if (dgvHocPhan.Columns.Contains(col)) dgvHocPhan.Columns[col].HeaderText = header;
            if (dgvHocPhan.Columns.Contains("MaSoTC"))
                dgvHocPhan.Columns["MaSoTC"].Visible = false;
        }

        private void LoadGiaoVienCombo()
        {
            try
            {
                cboMaGV.Items.Clear();
                cboMaGV.Items.Add("");
                var gvRepo = new GiaoVienRepository();
                foreach (var gv in gvRepo.GetAll())
                    cboMaGV.Items.Add(gv.MaGV + " - " + gv.HoTen);
                cboMaGV.SelectedIndex = 0;
            }
            catch { }
        }

        private void dgvHocPhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvHocPhan.Rows[e.RowIndex];
            txtMaHP.Text = row.Cells["MaHP"].Value?.ToString() ?? "";
            txtTenHP.Text = row.Cells["TenHP"].Value?.ToString() ?? "";
            var maGV = row.Cells["MaGV"].Value?.ToString() ?? "";
            SelectComboItem(cboMaGV, maGV);
            numSoTC.Value = GetSoTC(row.Cells["MaSoTC"].Value?.ToString());
            numHocKy.Value = Convert.ToInt32(row.Cells["HocKy"].Value ?? 1);
            txtNamHoc.Text = row.Cells["NamHoc"].Value?.ToString() ?? "";
            txtMoTa.Text = row.Cells["MoTa"].Value?.ToString() ?? "";
            chkTrangThai.Checked = Convert.ToInt32(row.Cells["TrangThai"].Value ?? 1) == 1;
        }

        private int GetSoTC(string? maSoTC)
        {
            if (string.IsNullOrEmpty(maSoTC)) return 3;
            try
            {
                using var conn = OracleConnection.Instance.GetConnection();
                conn.Open();
                using var cmd = new Oracle.ManagedDataAccess.Client.OracleCommand(
                    "SELECT SoTC FROM ADMIN_MASTER.SOTINCHI WHERE MaSoTC = :ma", conn);
                cmd.Parameters.Add(":ma", maSoTC);
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 3;
            }
            catch { return 3; }
        }

        private string? GetMaSoTCFromSoTC(int soTC)
        {
            try
            {
                using var conn = OracleConnection.Instance.GetConnection();
                conn.Open();
                using var cmd = new Oracle.ManagedDataAccess.Client.OracleCommand(
                    "SELECT MaSoTC FROM ADMIN_MASTER.SOTINCHI WHERE SoTC = :sotc", conn);
                cmd.Parameters.Add(":sotc", soTC);
                var result = cmd.ExecuteScalar();
                return result?.ToString();
            }
            catch { return null; }
        }

        private static void SelectComboItem(ComboBox cbo, string value)
        {
            if (string.IsNullOrEmpty(value)) { cbo.SelectedIndex = 0; return; }
            for (int i = 0; i < cbo.Items.Count; i++)
            {
                if (cbo.Items[i].ToString()?.StartsWith(value) == true)
                {
                    cbo.SelectedIndex = i;
                    return;
                }
            }
            cbo.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            if (_repo.Insert(CreateHocPhan()))
            { ShowInfo("Them thanh cong!"); LoadData(); ClearInputs(); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaHP.Text == "(Tu dong)" || string.IsNullOrWhiteSpace(txtMaHP.Text)) 
            { ShowWarning("Chon hoc phan!"); return; }
            if (!ValidateInput()) return;
            if (_repo.Update(CreateHocPhan()))
            { ShowInfo("Cap nhat thanh cong!"); LoadData(); ClearInputs(); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHP.Text == "(Tu dong)" || string.IsNullOrWhiteSpace(txtMaHP.Text)) 
            { ShowWarning("Chon hoc phan!"); return; }
            if (MessageBox.Show("Xoa hoc phan " + txtMaHP.Text + "?", "Xac nhan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                if (_repo.Delete(txtMaHP.Text.Trim())) { ShowInfo("Xoa thanh cong!"); LoadData(); ClearInputs(); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e) => ClearInputs();

        private HocPhan CreateHocPhan()
        {
            var maGV = cboMaGV.SelectedIndex > 0 ? cboMaGV.Text.Split('-')[0].Trim() : null;
            var maSoTC = GetMaSoTCFromSoTC((int)numSoTC.Value);
            
            return new HocPhan
            {
                MaHP = txtMaHP.Text.Trim() == "(Tu dong)" ? "" : txtMaHP.Text.Trim(),
                TenHP = txtTenHP.Text.Trim(),
                MaGV = maGV,
                MaSoTC = maSoTC,
                HocKy = (int)numHocKy.Value,
                NamHoc = txtNamHoc.Text.Trim(),
                MoTa = txtMoTa.Text.Trim(),
                TrangThai = chkTrangThai.Checked ? 1 : 0
            };
        }

        private bool ValidateInput() =>
            ValidateField(txtTenHP, "ten hoc phan") &&
            ValidateField(txtNamHoc, "nam hoc");

        private bool ValidateField(TextBox txt, string name)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            { ShowWarning("Nhap " + name + "!"); txt.Focus(); return false; }
            return true;
        }

        private void ClearInputs()
        {
            txtMaHP.Text = "(Tu dong)";
            txtTenHP.Clear(); txtNamHoc.Clear(); txtMoTa.Clear();
            cboMaGV.SelectedIndex = 0;
            numSoTC.Value = 3;
            numHocKy.Value = 1;
            chkTrangThai.Checked = true;
        }

        private static void ShowWarning(string msg) => MessageBox.Show(msg, "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private static void ShowInfo(string msg) => MessageBox.Show(msg, "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private static void ShowError(string title, Exception ex) => MessageBox.Show(title + ": " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
