using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using StudentManagementSystem.Models;
using StudentManagementSystem.DAL;
using DBConnection = StudentManagementSystem.DAL.OracleConnection;

namespace StudentManagementSystem.Forms
{
    public partial class HocPhanDetailForm : Form
    {
        private HocPhanRepository _repository = new HocPhanRepository();
        private HocPhan? _currentHocPhan;
        private bool _isEditMode = false;

        public HocPhanDetailForm()
        {
            InitializeComponent();
            _isEditMode = false;
            this.Text = "Thêm Học phần";
        }

        public HocPhanDetailForm(HocPhan hocPhan)
        {
            InitializeComponent();
            _currentHocPhan = hocPhan;
            _isEditMode = true;
            this.Text = "Sửa Học phần";
            LoadData();
        }

        private void HocPhanDetailForm_Load(object sender, EventArgs e)
        {
            LoadGiaoVienComboBox();
            LoadSoTinChiComboBox();
            
            if (_isEditMode)
            {
                txtMaHP.ReadOnly = true;
                txtMaHP.BackColor = System.Drawing.Color.LightGray;
            }
        }

        private void LoadGiaoVienComboBox()
        {
            try
            {
                using (var conn = DBConnection.Instance.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT MaGV, HoTen FROM ADMIN_MASTER.GiaoVien ORDER BY MaGV";
                    
                    using (var cmd = new OracleCommand(sql, conn))
                    using (var adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        
                        cboGiaoVien.DisplayMember = "HoTen";
                        cboGiaoVien.ValueMember = "MaGV";
                        cboGiaoVien.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải giáo viên: {ex.Message}");
            }
        }

        private void LoadSoTinChiComboBox()
        {
            try
            {
                using (var conn = DBConnection.Instance.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT MaSoTC, SoTC FROM ADMIN_MASTER.SoTinChi ORDER BY SoTC";
                    
                    using (var cmd = new OracleCommand(sql, conn))
                    using (var adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        
                        cboSoTinChi.DisplayMember = "SoTC";
                        cboSoTinChi.ValueMember = "MaSoTC";
                        cboSoTinChi.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải số tín chỉ: {ex.Message}");
            }
        }

        private void LoadData()
        {
            if (_currentHocPhan != null)
            {
                txtMaHP.Text = _currentHocPhan.MaHP;
                txtTenHP.Text = _currentHocPhan.TenHP;
                cboGiaoVien.SelectedValue = _currentHocPhan.MaGV;
                cboSoTinChi.SelectedValue = _currentHocPhan.MaSoTC;
                numHocKy.Value = _currentHocPhan.HocKy;
                txtNamHoc.Text = _currentHocPhan.NamHoc;
                txtMoTa.Text = _currentHocPhan.MoTa;
                chkTrangThai.Checked = _currentHocPhan.TrangThai == 1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            var hocPhan = new HocPhan
            {
                MaHP = txtMaHP.Text.Trim(),
                TenHP = txtTenHP.Text.Trim(),
                MaGV = cboGiaoVien.SelectedValue?.ToString(),
                MaSoTC = cboSoTinChi.SelectedValue?.ToString(),
                HocKy = (int)numHocKy.Value,
                NamHoc = txtNamHoc.Text.Trim(),
                MoTa = txtMoTa.Text.Trim(),
                TrangThai = chkTrangThai.Checked ? 1 : 0
            };

            bool success = _isEditMode ? _repository.Update(hocPhan) : _repository.Insert(hocPhan);

            if (success)
            {
                MessageBox.Show(_isEditMode ? "Cập nhật thành công!" : "Thêm mới thành công!", 
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaHP.Text))
            {
                MessageBox.Show("Vui lòng nhập mã học phần!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHP.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenHP.Text))
            {
                MessageBox.Show("Vui lòng nhập tên học phần!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenHP.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNamHoc.Text))
            {
                MessageBox.Show("Vui lòng nhập năm học!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamHoc.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
