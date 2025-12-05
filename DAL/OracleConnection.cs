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
                using var cmd = new OracleCommand(
                    "SELECT GRANTED_ROLE FROM USER_ROLE_PRIVS WHERE GRANTED_ROLE IN ('ROLE_ADMIN','ROLE_GIAOVIEN','ROLE_SINHVIEN')", conn);
                var r = cmd.ExecuteScalar()?.ToString() ?? "";
                if (r.Contains("ADMIN")) return "ADMIN";
                if (r.Contains("GIAOVIEN")) return "GIAOVIEN";
                if (r.Contains("SINHVIEN")) return "SINHVIEN";
            }
            catch { }
            return user.StartsWith("ADMIN", StringComparison.OrdinalIgnoreCase) ? "ADMIN" :
                   user.StartsWith("GV", StringComparison.OrdinalIgnoreCase) ? "GIAOVIEN" :
                   user.StartsWith("SV", StringComparison.OrdinalIgnoreCase) ? "SINHVIEN" : "UNKNOWN";
        }

        public Oracle.ManagedDataAccess.Client.OracleConnection GetConnection() =>
            string.IsNullOrEmpty(_connStr) ? throw new Exception("Chưa kết nối!") : new(_connStr);

        public void Disconnect() => _connStr = _user = _role = "";
    }
}
