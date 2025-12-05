using System;
using Oracle.ManagedDataAccess.Client;

namespace StudentManagementSystem.Services
{
    public class AuditService
    {
        private const string Conn = "Data Source=localhost:1521/orcl21pdb1;User Id=ADMIN_MASTER;Password=123;";

        public void LogLoginEvent(string user, string action, string comments = "", bool success = true)
        {
            try
            {
                using var c = new OracleConnection(Conn); c.Open();
                using var cmd = new OracleCommand("BEGIN ADMIN_MASTER.log_audit_event(:u,:a,NULL,:c); END;", c);
                cmd.Parameters.Add(":u", user); cmd.Parameters.Add(":a", action);
                cmd.Parameters.Add(":c", comments + (success ? " - SUCCESS" : " - FAILED"));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"Audit failed: {ex.Message}"); }
        }

        public void LogApplicationEvent(string user, string action, string obj = "", string comments = "")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(action)) return;
                var a = action.ToUpper();
                var n = a.Contains("LOGIN") ? "LOGIN" : a.Contains("LOGOUT") ? "LOGOUT" :
                        a.Contains("INSERT") ? "INSERT" : a.Contains("UPDATE") ? "UPDATE" :
                        a.Contains("DELETE") ? "DELETE" : "";
                if (n == "") return;

                using var c = new OracleConnection(Conn); c.Open();
                using var cmd = new OracleCommand(@"INSERT INTO ADMIN_MASTER.AUDIT_LOGS(audit_id,username,action_type,object_name,terminal,os_user,ip_address,program,comments)
                    VALUES(ADMIN_MASTER.audit_logs_seq.NEXTVAL,:u,:a,:o,:t,:os,'127.0.0.1','StudentManagementSystem',:c)", c);
                cmd.Parameters.Add(":u", user); cmd.Parameters.Add(":a", n); cmd.Parameters.Add(":o", obj ?? "");
                cmd.Parameters.Add(":t", Environment.MachineName); cmd.Parameters.Add(":os", Environment.UserName);
                cmd.Parameters.Add(":c", comments);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"Audit failed: {ex.Message}"); }
        }
    }
}