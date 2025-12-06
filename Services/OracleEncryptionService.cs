using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace StudentManagementSystem.Services
{
    public class OracleEncryptionService
    {
        private const string Conn = "User Id=ADMIN_MASTER;Password=123;Data Source=localhost:1521/orcl21pdb1;";

        public (bool IsSuccess, int UserId, string Role, string ErrorMessage) AuthenticateUser(string user, string pwd)
        {
            try
            {
                using var c = new OracleConnection(Conn); c.Open();
                using var cmd = new OracleCommand("SELECT AUTHENTICATE_USER(:u,:p) FROM DUAL", c);
                cmd.Parameters.Add(":u", OracleDbType.Varchar2).Value = user;
                cmd.Parameters.Add(":p", OracleDbType.Varchar2).Value = pwd;
                var r = cmd.ExecuteScalar()?.ToString() ?? "";
                if (r.StartsWith("ERROR")) return (false, 0, "", r);
                if (r == "USER_NOT_FOUND") return (false, 0, "", "Tên đăng nhập không tồn tại");
                if (r == "INVALID_PASSWORD") return (false, 0, "", "Mật khẩu không đúng");
                if (r.Contains("|")) { var p = r.Split('|'); return (true, int.Parse(p[0]), p[1], ""); }
                return (false, 0, "", "Kết quả không hợp lệ");
            }
            catch (Exception ex) { return (false, 0, "", $"Lỗi DB: {ex.Message}"); }
        }

        public (bool IsSuccess, int UserId, string PrivateKey, string ErrorMessage) CreateNewUserWithKeys(string user, string pwd, string role)
        {
            try
            {
                using var c = new OracleConnection(Conn); c.Open();
                // Procedure: CREATE_USER_WITH_RSA_KEYS(p_username, p_password, p_role, p_private_key OUT, p_result OUT)
                using var cmd = new OracleCommand("BEGIN ADMIN_MASTER.CREATE_USER_WITH_RSA_KEYS(:u,:p,:r,:pk,:res); END;", c);
                cmd.Parameters.Add(":u", OracleDbType.Varchar2).Value = user;
                cmd.Parameters.Add(":p", OracleDbType.Varchar2).Value = pwd;
                cmd.Parameters.Add(":r", OracleDbType.Varchar2).Value = role;
                var pk = new OracleParameter(":pk", OracleDbType.Clob) { Direction = ParameterDirection.Output };
                var res = new OracleParameter(":res", OracleDbType.Varchar2, 500) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(pk); cmd.Parameters.Add(res);
                cmd.ExecuteNonQuery();
                
                var result = res.Value?.ToString() ?? "";
                if (result.StartsWith("SUCCESS|"))
                {
                    var userId = int.Parse(result.Split('|')[1]);
                    // Đọc CLOB đúng cách
                    var privateKey = "";
                    if (pk.Value != null && pk.Value != DBNull.Value)
                    {
                        var clob = (Oracle.ManagedDataAccess.Types.OracleClob)pk.Value;
                        privateKey = clob.Value;
                    }
                    return (true, userId, privateKey, "");
                }
                return (false, 0, "", result);
            }
            catch (Exception ex) { return (false, 0, "", $"Lỗi: {ex.Message}"); }
        }

        public (bool IsValid, int UserId, string Role, string AESKey, string Message) AuthenticateUserAndDecryptAES(string user, string pwd, string privateKey)
        {
            try
            {
                using var c = new OracleConnection(Conn); c.Open();
                using var cmd = new OracleCommand("SELECT AUTHENTICATE_AND_DECRYPT_AES(:u,:p,:k) FROM DUAL", c);
                cmd.Parameters.Add(":u", OracleDbType.Varchar2).Value = user;
                cmd.Parameters.Add(":p", OracleDbType.Varchar2).Value = pwd;
                cmd.Parameters.Add(":k", OracleDbType.Clob).Value = privateKey;
                var r = cmd.ExecuteScalar()?.ToString() ?? "ERROR";
                if (r.StartsWith("SUCCESS|")) { var p = r.Split('|'); return p.Length >= 4 ? (true, int.Parse(p[1]), p[2], p[3], "OK") : (false, 0, "", "", "Invalid"); }
                return (false, 0, "", "", r);
            }
            catch (Exception ex) { return (false, 0, "", "", $"Lỗi: {ex.Message}"); }
        }

        public (bool IsSuccess, string AESKeysData, string ErrorMessage) DecryptUserAESKeys(int userId, string privateKey)
        {
            try
            {
                using var c = new OracleConnection(Conn); c.Open();
                using var cmd = new OracleCommand("SELECT DECRYPT_USER_AES_KEYS(:id,:k) FROM DUAL", c);
                cmd.Parameters.Add(":id", OracleDbType.Int32).Value = userId;
                cmd.Parameters.Add(":k", OracleDbType.Clob).Value = privateKey;
                var r = cmd.ExecuteScalar()?.ToString() ?? "";
                if (r.StartsWith("SUCCESS|")) return (true, r[8..], "");
                if (r == "NO_KEYS_FOUND") return (false, "", "Không tìm thấy AES keys");
                return (false, "", r);
            }
            catch (Exception ex) { return (false, "", $"Lỗi: {ex.Message}"); }
        }

        public (bool IsSuccess, int DataId, string ErrorMessage) EncryptAndSaveData(int userId, string data, string? desc = null)
        {
            try
            {
                using var c = new OracleConnection(Conn); c.Open();
                using var cmd = new OracleCommand("SELECT ENCRYPT_AND_SAVE_DATA(:id,:d,:desc) FROM DUAL", c);
                cmd.Parameters.Add(":id", OracleDbType.Int32).Value = userId;
                cmd.Parameters.Add(":d", OracleDbType.Clob).Value = data;
                cmd.Parameters.Add(":desc", OracleDbType.Varchar2).Value = desc ?? (object)DBNull.Value;
                var r = cmd.ExecuteScalar()?.ToString() ?? "";
                return r.StartsWith("SUCCESS|") ? (true, int.Parse(r[8..]), "") : (false, 0, r);
            }
            catch (Exception ex) { return (false, 0, $"Lỗi: {ex.Message}"); }
        }   

        public (bool IsSuccess, string DecryptedData, string ErrorMessage) DecryptAndGetData(int userId, string aesKey)
        {
            try
            {
                using var c = new OracleConnection(Conn); c.Open();
                using var cmd = new OracleCommand("SELECT DECRYPT_AND_GET_DATA(:id,:k) FROM DUAL", c);
                cmd.Parameters.Add(":id", OracleDbType.Int32).Value = userId;
                cmd.Parameters.Add(":k", OracleDbType.Clob).Value = aesKey;
                var r = cmd.ExecuteScalar()?.ToString() ?? "";
                return r.StartsWith("ERROR") ? (false, "", r) : (true, r, "");
            }
            catch (Exception ex) { return (false, "", $"Lỗi: {ex.Message}"); }
        }

        public bool UserExists(string user)
        {
            try
            {
                using var c = new OracleConnection(Conn); c.Open();
                using var cmd = new OracleCommand("SELECT COUNT(*) FROM USERS WHERE USERNAME=:u AND IS_ACTIVE=1", c);
                cmd.Parameters.Add(":u", OracleDbType.Varchar2).Value = user;
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
            catch { return false; }
        }

        public (string Username, string Role) GetUserInfo(int userId)
        {
            try
            {
                using var c = new OracleConnection(Conn); c.Open();
                using var cmd = new OracleCommand("SELECT USERNAME,ROLE FROM USERS WHERE USER_ID=:id AND IS_ACTIVE=1", c);
                cmd.Parameters.Add(":id", OracleDbType.Int32).Value = userId;
                using var r = cmd.ExecuteReader();
                return r.Read() ? (r["USERNAME"].ToString() ?? "", r["ROLE"].ToString() ?? "") : ("", "");
            }
            catch { return ("", ""); }
        }
    }
}