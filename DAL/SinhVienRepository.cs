using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.DAL
{
    public class SinhVienRepository : BaseRepository
    {
        private static SinhVien Map(OracleDataReader r) => new()
        {
            MaSV = S(r["MaSV"]), HoTen = S(r["HoTen"]), NgaySinh = D(r["NgaySinh"]), GioiTinh = S(r["GioiTinh"]),
            Email = S(r["Email"]), SoDienThoai = S(r["SoDienThoai"]), DiaChi = S(r["DiaChi"]), MaLop = S(r["MaLop"]),
            NgayNhapHoc = D(r["NgayNhapHoc"]), TrangThai = I(r["TrangThai"]), OracleUsername = S(r["OracleUsername"])
        };

        public List<SinhVien> GetAll() => Query("SELECT * FROM SINHVIEN ORDER BY MASV", Map);
        public SinhVien? GetById(string id) => QueryOne("SELECT * FROM SINHVIEN WHERE MASV=:a", Map, c => c.Parameters.Add(":a", id));

        public bool Insert(SinhVien s, string user, string pwd, string performedBy = "ADMIN_MASTER")
        {
            try
            {
                using var conn = Conn(); conn.Open();
                Compile(conn, "ADMIN_MASTER.TRG_AUDIT_SINHVIEN");
                CreateOracleUser(conn, user, pwd, "TS_SINHVIEN", "PROFILE_SINHVIEN", "ROLE_SINHVIEN");
                Log(performedBy, "INSERT", "SINHVIEN", $"Inserted: {s.HoTen}, User={user}");

                var sql = @"INSERT INTO ADMIN_MASTER.SinhVien(HoTen,NgaySinh,GioiTinh,Email,SoDienThoai,DiaChi,MaLop,NgayNhapHoc,TrangThai,OracleUsername)
                    VALUES(:a,:b,:c,:d,:e,:f,:g,:h,:i,:j)";
                using var cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":a", s.HoTen); cmd.Parameters.Add(":b", N(s.NgaySinh)); cmd.Parameters.Add(":c", s.GioiTinh);
                cmd.Parameters.Add(":d", s.Email); cmd.Parameters.Add(":e", s.SoDienThoai); cmd.Parameters.Add(":f", s.DiaChi);
                cmd.Parameters.Add(":g", s.MaLop); cmd.Parameters.Add(":h", N(s.NgayNhapHoc)); cmd.Parameters.Add(":i", s.TrangThai);
                cmd.Parameters.Add(":j", user);
                try { cmd.ExecuteNonQuery(); }
                catch (OracleException ox) when (ox.Number == 4098)
                {
                    Compile(conn, "ADMIN_MASTER.TRG_AUDIT_SINHVIEN");
                    cmd.ExecuteNonQuery();
                }

                InsertUsers(conn, user, pwd, "STUDENT");
                Ok($"Thêm sinh viên thành công!\nUsername: {user}\nPassword: {pwd}");
                return true;
            }
            catch (OracleException ox) when (ox.Number == 4098)
            {
                Err("Trigger không hợp lệ. Chạy: ALTER TRIGGER ADMIN_MASTER.TRG_AUDIT_SINHVIEN COMPILE"); return false;
            }
            catch (Exception ex) { Err("Lỗi thêm sinh viên", ex); return false; }
        }

        public bool Update(SinhVien s, string performedBy = "")
        {
            Log(string.IsNullOrEmpty(performedBy) ? Environment.UserName : performedBy, "UPDATE", "SINHVIEN", $"Updated: {s.MaSV}");
            return Exec(@"UPDATE ADMIN_MASTER.SinhVien SET HoTen=:a,NgaySinh=:b,GioiTinh=:c,Email=:d,SoDienThoai=:e,
                DiaChi=:f,MaLop=:g,NgayNhapHoc=:h,TrangThai=:i WHERE MaSV=:j", c =>
            {
                c.Parameters.Add(":a", s.HoTen); c.Parameters.Add(":b", N(s.NgaySinh)); c.Parameters.Add(":c", s.GioiTinh);
                c.Parameters.Add(":d", s.Email); c.Parameters.Add(":e", s.SoDienThoai); c.Parameters.Add(":f", s.DiaChi);
                c.Parameters.Add(":g", s.MaLop); c.Parameters.Add(":h", N(s.NgayNhapHoc)); c.Parameters.Add(":i", s.TrangThai);
                c.Parameters.Add(":j", s.MaSV);
            });
        }

        public bool Delete(string id, string performedBy = "")
        {
            Log(string.IsNullOrEmpty(performedBy) ? Environment.UserName : performedBy, "DELETE", "SINHVIEN", $"Deleted: {id}");
            return ExecWithConn(conn =>
            {
                using (var cmd = new OracleCommand("DELETE FROM SINHVIEN WHERE MASV=:a", conn))
                { cmd.Parameters.Add(":a", id); cmd.ExecuteNonQuery(); }
                using (var cmd = new OracleCommand($"BEGIN EXECUTE IMMEDIATE 'DROP USER {id} CASCADE'; EXCEPTION WHEN OTHERS THEN NULL; END;", conn))
                { cmd.ExecuteNonQuery(); }
            });
        }
    }
}
