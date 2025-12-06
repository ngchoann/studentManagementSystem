using Oracle.ManagedDataAccess.Client;
using System;

namespace StudentManagementSystem.DAL
{
    public class OracleConnection
    {
        private static OracleConnection? _instance;
        private string _connStr = "", _user = "", _role = "";

        private OracleConnection() { }
        public static OracleConnection Instance => _instance ??= new();
        public string CurrentUser => _user;
        public string CurrentRole => _role;
        public string ConnectionString => _connStr;

        public bool Connect(string user, string pwd, string ds)
        {
            try
            {
                _connStr = $"User Id={user};Password={pwd};Data Source={ds};";
                using var conn = new Oracle.ManagedDataAccess.Client.OracleConnection(_connStr);
                conn.Open();
                _user = user;
                _role = GetRole(conn, user);
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        private static string GetRole(Oracle.ManagedDataAccess.Client.OracleConnection conn, string user)
        {
            try
            {
                // Kiểm tra trong bảng USERS trước
                using var cmdUsers = new OracleCommand(
                    "SELECT ROLE FROM ADMIN_MASTER.USERS WHERE UPPER(USERNAME) = UPPER(:u)", conn);
                cmdUsers.Parameters.Add(":u", user);
                var roleFromUsers = cmdUsers.ExecuteScalar()?.ToString() ?? "";
                if (!string.IsNullOrEmpty(roleFromUsers))
                {
                    if (roleFromUsers.Contains("ADMIN")) return "ADMIN";
                    if (roleFromUsers.Contains("TEACHER") || roleFromUsers.Contains("GIAOVIEN")) return "GIAOVIEN";
                    if (roleFromUsers.Contains("STUDENT") || roleFromUsers.Contains("SINHVIEN")) return "SINHVIEN";
                }
                
                // Fallback: kiểm tra trong bảng GIAOVIEN hoặc SINHVIEN
                using var cmdGV = new OracleCommand(
                    "SELECT COUNT(*) FROM ADMIN_MASTER.GIAOVIEN WHERE UPPER(ORACLEUSERNAME) = UPPER(:u)", conn);
                cmdGV.Parameters.Add(":u", user);
                if (Convert.ToInt32(cmdGV.ExecuteScalar()) > 0) return "GIAOVIEN";
                
                using var cmdSV = new OracleCommand(
                    "SELECT COUNT(*) FROM ADMIN_MASTER.SINHVIEN WHERE UPPER(ORACLEUSERNAME) = UPPER(:u)", conn);
                cmdSV.Parameters.Add(":u", user);
                if (Convert.ToInt32(cmdSV.ExecuteScalar()) > 0) return "SINHVIEN";
            }
            catch { }
            
            // Fallback cuối: dựa vào username
            return user.Equals("ADMIN_MASTER", StringComparison.OrdinalIgnoreCase) ? "ADMIN" :
                   user.StartsWith("GV", StringComparison.OrdinalIgnoreCase) ? "GIAOVIEN" :
                   user.StartsWith("SV", StringComparison.OrdinalIgnoreCase) ? "SINHVIEN" : "UNKNOWN";
        }

        public Oracle.ManagedDataAccess.Client.OracleConnection GetConnection() =>
            string.IsNullOrEmpty(_connStr) ? throw new Exception("Chưa kết nối!") : new(_connStr);

        public void Disconnect() => _connStr = _user = _role = "";
    }
}
