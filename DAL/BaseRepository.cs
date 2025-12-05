using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using StudentManagementSystem.Services;
using OraConn = Oracle.ManagedDataAccess.Client.OracleConnection;

namespace StudentManagementSystem.DAL
{
    public abstract class BaseRepository
    {
        protected const string ConnectionString = "User Id=ADMIN_MASTER;Password=123;Data Source=localhost:1521/orcl21pdb1;";
        protected static readonly AuditService Audit = new();

        protected static OraConn Conn() => new(ConnectionString);

        protected static void Log(string user, string action, string table, string comment)
        { try { Audit.LogApplicationEvent(user, action, table, comment); } catch { } }

        protected static void Err(string msg, Exception? ex = null) =>
            System.Windows.Forms.MessageBox.Show(ex != null ? $"{msg}: {ex.Message}" : msg, "Lỗi",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

        protected static void Ok(string msg) =>
            System.Windows.Forms.MessageBox.Show(msg, "Thành công",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

        protected static List<T> Query<T>(string sql, Func<OracleDataReader, T> map, Action<OracleCommand>? addParams = null)
        {
            var list = new List<T>();
            try
            {
                using var conn = Conn(); conn.Open();
                using var cmd = new OracleCommand(sql, conn);
                addParams?.Invoke(cmd);
                using var r = cmd.ExecuteReader();
                while (r.Read()) list.Add(map(r));
            }
            catch (Exception ex) { Err("Lỗi truy vấn", ex); }
            return list;
        }

        protected static T? QueryOne<T>(string sql, Func<OracleDataReader, T> map, Action<OracleCommand> addParams) where T : class
        {
            try
            {
                using var conn = Conn(); conn.Open();
                using var cmd = new OracleCommand(sql, conn);
                addParams(cmd);
                using var r = cmd.ExecuteReader();
                return r.Read() ? map(r) : null;
            }
            catch (Exception ex) { Err("Lỗi truy vấn", ex); return null; }
        }

        protected static bool Exec(string sql, Action<OracleCommand> addParams)
        {
            try
            {
                using var conn = Conn(); conn.Open();
                using var cmd = new OracleCommand(sql, conn);
                addParams(cmd);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) { Err("Lỗi thực thi", ex); return false; }
        }

        protected static bool ExecWithConn(Action<OraConn> action)
        {
            try { using var conn = Conn(); conn.Open(); action(conn); return true; }
            catch (Exception ex) { Err("Lỗi thực thi", ex); return false; }
        }

        protected static void CreateOracleUser(OraConn conn, string user, string pwd, string ts, string profile, string role)
        {
            var sql = $@"DECLARE v NUMBER; BEGIN SELECT COUNT(*) INTO v FROM DBA_USERS WHERE USERNAME='{user}';
                IF v=0 THEN EXECUTE IMMEDIATE 'CREATE USER {user} IDENTIFIED BY ""{pwd}"" DEFAULT TABLESPACE {ts} TEMPORARY TABLESPACE TEMP PROFILE {profile} QUOTA 10M ON {ts}';
                EXECUTE IMMEDIATE 'GRANT CONNECT TO {user}'; EXECUTE IMMEDIATE 'GRANT {role} TO {user}'; END IF; END;";
            using var cmd = new OracleCommand(sql, conn); cmd.ExecuteNonQuery();
        }

        protected static void InsertUsers(OraConn conn, string user, string pwd, string role)
        {
            var sql = @"INSERT INTO ADMIN_MASTER.USERS(USER_ID,USERNAME,PASSWORD_HASH,ROLE,IS_ACTIVE,CREATED_DATE)
                VALUES(SEQ_USER_ID.NEXTVAL,:u,RAWTOHEX(DBMS_CRYPTO.HASH(UTL_RAW.CAST_TO_RAW(:p),4)),:r,1,SYSDATE)";
            using var cmd = new OracleCommand(sql, conn);
            cmd.Parameters.Add(":u", user); cmd.Parameters.Add(":p", pwd); cmd.Parameters.Add(":r", role);
            cmd.ExecuteNonQuery();
        }

        protected static void Compile(OraConn conn, string trigger)
        { try { using var cmd = new OracleCommand($"BEGIN EXECUTE IMMEDIATE 'ALTER TRIGGER {trigger} COMPILE'; END;", conn); cmd.ExecuteNonQuery(); } catch { } }

        protected static string S(object? v) => v?.ToString() ?? "";
        protected static DateTime? D(object? v) => v != null && v != DBNull.Value ? Convert.ToDateTime(v) : null;
        protected static int I(object? v) => v != null && v != DBNull.Value ? Convert.ToInt32(v) : 0;
        protected static decimal? M(object? v) => v != null && v != DBNull.Value ? Convert.ToDecimal(v) : null;
        protected static object N(object? v) => v ?? DBNull.Value;
    }
}
