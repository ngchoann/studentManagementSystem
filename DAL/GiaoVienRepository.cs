using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;
using StudentManagementSystem.Utilities;

namespace StudentManagementSystem.DAL
{
    public class GiaoVienRepository : BaseRepository
    {
        private readonly OracleEncryptionService _encryptionService = new();

        public List<GiaoVien> GetAll() => Query("SELECT * FROM GIAOVIEN ORDER BY MAGV", r => new GiaoVien
        {
            MaGV = S(r["MaGV"]), HoTen = S(r["HoTen"]), NgaySinh = D(r["NgaySinh"]),
            GioiTinh = S(r["GioiTinh"]), Email = S(r["Email"]), SoDienThoai = S(r["SoDienThoai"]),
            DiaChi = S(r["DiaChi"]), ChuyenMon = S(r["ChuyenMon"]), NgayVaoLam = D(r["NgayVaoLam"]), TrangThai = I(r["TrangThai"])
        });

        public bool Insert(GiaoVien g, string user, string pwd)
        {
            return ExecWithAdminConn(conn =>
            {
                // 1. Kiểm tra username đã tồn tại trong bảng USERS chưa
                using (var checkCmd = new OracleCommand("SELECT COUNT(*) FROM ADMIN_MASTER.USERS WHERE USERNAME = :u", conn))
                {
                    checkCmd.Parameters.Add(":u", user.ToUpper());
                    var count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                        throw new System.Exception($"Username '{user}' đã tồn tại! Vui lòng chọn username khác.");
                }

                // 2. Tạo Oracle user
                CreateOracleUser(conn, user, pwd, "TS_GIAOVIEN", "PROFILE_GIAOVIEN", "ROLE_GIAOVIEN");
                Log(user, "INSERT", "GIAOVIEN", $"Inserted: {g.HoTen}");

                // 3. Insert vào bảng GIAOVIEN
                var sql = @"INSERT INTO ADMIN_MASTER.GiaoVien(HoTen,NgaySinh,GioiTinh,Email,SoDienThoai,DiaChi,ChuyenMon,NgayVaoLam,TrangThai,OracleUsername)
                    VALUES(:a,:b,:c,:d,:e,:f,:g,:h,:i,:j)";
                using var cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":a", g.HoTen); cmd.Parameters.Add(":b", N(g.NgaySinh)); cmd.Parameters.Add(":c", g.GioiTinh);
                cmd.Parameters.Add(":d", g.Email); cmd.Parameters.Add(":e", g.SoDienThoai); cmd.Parameters.Add(":f", g.DiaChi);
                cmd.Parameters.Add(":g", g.ChuyenMon); cmd.Parameters.Add(":h", N(g.NgayVaoLam)); cmd.Parameters.Add(":i", g.TrangThai);
                cmd.Parameters.Add(":j", user);
                cmd.ExecuteNonQuery();

                // 4. Tạo RSA keys và lưu vào bảng USERS
                var (success, userId, privateKey, error) = _encryptionService.CreateNewUserWithKeys(user, pwd, "TEACHER");
                
                if (success && !string.IsNullOrEmpty(privateKey))
                {
                    // 5. Lưu private key vào file
                    var fileName = FileHelper.GeneratePrivateKeyFileName(user, "TEACHER");
                    var keyPath = FileHelper.WritePrivateKeyFile(privateKey, fileName);
                    
                    Ok($"Thêm giáo viên thành công!\n\nUsername: {user}\nPassword: {pwd}\n\nPrivate Key đã được lưu tại:\n{keyPath}\n\nGiáo viên cần upload file này khi đăng nhập!");
                }
                else
                {
                    // Fallback: Nếu không tạo được RSA, vẫn insert vào USERS bình thường
                    InsertUsers(conn, user, pwd, "TEACHER");
                    Ok($"Thêm giáo viên thành công!\n\nUsername: {user}\nPassword: {pwd}\n\n(Lưu ý: Không tạo được RSA key - {error})");
                }
            });
        }

        public bool Update(GiaoVien g) => Exec(
            @"UPDATE ADMIN_MASTER.GiaoVien SET HoTen=:a,NgaySinh=:b,GioiTinh=:c,Email=:d,SoDienThoai=:e,
              DiaChi=:f,ChuyenMon=:g,NgayVaoLam=:h,TrangThai=:i WHERE MaGV=:j", c =>
            {
                c.Parameters.Add(":a", g.HoTen); c.Parameters.Add(":b", N(g.NgaySinh)); c.Parameters.Add(":c", g.GioiTinh);
                c.Parameters.Add(":d", g.Email); c.Parameters.Add(":e", g.SoDienThoai); c.Parameters.Add(":f", g.DiaChi);
                c.Parameters.Add(":g", g.ChuyenMon); c.Parameters.Add(":h", N(g.NgayVaoLam));
                c.Parameters.Add(":i", g.TrangThai); c.Parameters.Add(":j", g.MaGV);
            });

        public bool Delete(string id) => Exec("DELETE FROM ADMIN_MASTER.GiaoVien WHERE MaGV=:a", c => c.Parameters.Add(":a", id));
    }
}

