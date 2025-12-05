using System;
using System.Windows.Forms;
using System.Drawing;
using Oracle.ManagedDataAccess.Client;

namespace StudentManagementSystem.Forms
{
    public partial class StudentPersonalInfoForm : Form
    {
        private string _username;
        
        public StudentPersonalInfoForm(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private void StudentPersonalInfoForm_Load(object sender, EventArgs e)
        {
            LoadPersonalInfo();
        }

        private void LoadPersonalInfo()
        {
            try
            {
                // Kết nối database để lấy thông tin thật
                string connectionString = "User Id=ADMIN_MASTER;Password=123;Data Source=localhost:1521/orcl21pdb1;";
                
                using (var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(connectionString))
                {
                    connection.Open();
                    
                    // Set context cho VPD
                    using (var contextCmd = new Oracle.ManagedDataAccess.Client.OracleCommand(
                        $"BEGIN DBMS_SESSION.SET_CONTEXT('CUSTOM_SECURITY_CTX', 'USER_ROLE', 'STUDENT'); " +
                        $"DBMS_SESSION.SET_CONTEXT('CUSTOM_SECURITY_CTX', 'USER_ID', '{_username}'); END;", connection))
                    {
                        contextCmd.ExecuteNonQuery();
                    }
                    
                    // Query đơn giản với các cột có thật trong database
                    string query = @"
                        SELECT masv, tensv, 'Sinh viên' as vai_tro,
                               'Khoa CNTT' as khoa, 'Đang học' as trang_thai
                        FROM sinhvien
                        WHERE masv = :username OR LOWER(tensv) LIKE '%' || LOWER(:username) || '%'
                        AND ROWNUM = 1";
                    
                    using (var command = new Oracle.ManagedDataAccess.Client.OracleCommand(query, connection))
                    {
                        command.Parameters.Add(":username", _username);
                        
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Chỉ hiển thị thông tin cơ bản
                                lblMaSV.Text = reader["masv"]?.ToString() ?? "N/A";
                                lblTenSV.Text = reader["tensv"]?.ToString() ?? "N/A";
                                lblVaiTro.Text = reader["vai_tro"]?.ToString() ?? "Sinh viên";
                                lblKhoa.Text = reader["khoa"]?.ToString() ?? "Khoa CNTT";
                                lblTrangThai.Text = reader["trang_thai"]?.ToString() ?? "Đang học";
                            }
                            else
                            {
                                // Không tìm thấy thông tin sinh viên
                                SetNoDataFound();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải thông tin từ cơ sở dữ liệu: {ex.Message}", 
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetNoDataFound();
            }
        }
        
        private void SetNoDataFound()
        {
            lblMaSV.Text = "Không tìm thấy";
            lblTenSV.Text = _username;
            lblVaiTro.Text = "Sinh viên";
            lblKhoa.Text = "Khoa CNTT";
            lblTrangThai.Text = "N/A";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}