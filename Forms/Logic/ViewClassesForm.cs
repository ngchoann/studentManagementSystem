using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace StudentManagementSystem.Forms
{
    public partial class ViewClassesForm : Form
    {
        private string connectionString;
        
        public ViewClassesForm()
        {
            InitializeComponent();
            // Sử dụng connection string giống như các form khác
            connectionString = "User Id=ADMIN_MASTER;Password=123;Data Source=localhost:1521/orcl21pdb1;";
        }

        private void ViewClassesForm_Load(object sender, EventArgs e)
        {
            LoadClassData();
        }

        private void LoadClassData()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    
                    // Set context cho VPD
                    using (var contextCmd = new OracleCommand(
                        "BEGIN DBMS_SESSION.SET_CONTEXT('CUSTOM_SECURITY_CTX', 'USER_ROLE', 'STUDENT'); END;", connection))
                    {
                        try
                        {
                            contextCmd.ExecuteNonQuery();
                        }
                        catch
                        {
                            // Bỏ qua lỗi context nếu không set được
                        }
                    }
                    
                    string query = @"
                        SELECT 
                            l.malop as ""Mã Lớp"",
                            l.tenlop as ""Tên Lớp"", 
                            NVL(gv.tengv, 'Chưa phân công') as ""Giảng Viên"",
                            COUNT(sv.masv) as ""Số Sinh Viên""
                        FROM lop l
                        LEFT JOIN giaovien gv ON l.magv = gv.magv
                        LEFT JOIN sinhvien sv ON l.malop = sv.lop_id
                        GROUP BY l.malop, l.tenlop, gv.tengv
                        ORDER BY l.tenlop";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            
                            if (dataTable.Rows.Count > 0)
                            {
                                dataGridViewClasses.DataSource = dataTable;
                            }
                            else
                            {
                                // Không có dữ liệu trong database
                                ShowNoDataMessage();
                            }
                            
                            // Tùy chỉnh hiển thị
                            dataGridViewClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dataGridViewClasses.ReadOnly = true;
                            dataGridViewClasses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải dữ liệu từ cơ sở dữ liệu: {ex.Message}\n\n" +
                    "Vui lòng kiểm tra:\n" +
                    "1. Kết nối Oracle Database\n" +
                    "2. Thông tin đăng nhập\n" +
                    "3. Dữ liệu trong bảng LOP, GIAOVIEN, SINHVIEN", 
                    "Lỗi kết nối Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ShowNoDataMessage();
            }
        }

        private void ShowNoDataMessage()
        {
            DataTable emptyTable = new DataTable();
            emptyTable.Columns.Add("Thông báo", typeof(string));
            emptyTable.Rows.Add("Không có dữ liệu lớp trong hệ thống");
            dataGridViewClasses.DataSource = emptyTable;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadClassData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}