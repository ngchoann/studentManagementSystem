using System.Collections.Generic;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.DAL
{
    public class HocPhanRepository : BaseRepository
    {
        private static HocPhan Map(Oracle.ManagedDataAccess.Client.OracleDataReader r) => new()
        {
            MaHP = S(r["MaHP"]), TenHP = S(r["TenHP"]), MaGV = S(r["MaGV"]), MaSoTC = S(r["MaSoTC"]),
            HocKy = I(r["HocKy"]), NamHoc = S(r["NamHoc"]), MoTa = S(r["MoTa"]), TrangThai = I(r["TrangThai"])
        };

        public List<HocPhan> GetAll() => Query("SELECT * FROM ADMIN_MASTER.HOCPHAN ORDER BY MAHP", Map);

        public List<HocPhan> Search(string kw) => Query(
            @"SELECT * FROM ADMIN_MASTER.HocPhan WHERE UPPER(MaHP) LIKE :k OR UPPER(TenHP) LIKE :k 
              OR UPPER(MaGV) LIKE :k OR UPPER(NamHoc) LIKE :k ORDER BY MaHP", Map,
            c => c.Parameters.Add(":k", $"%{kw.ToUpper()}%"));

        private string GenerateNewMaHP()
        {
            using var conn = OracleConnection.Instance.GetConnection();
            conn.Open();
            using var cmd = new Oracle.ManagedDataAccess.Client.OracleCommand(
                "SELECT 'HP' || LPAD(NVL(MAX(TO_NUMBER(SUBSTR(MaHP,3))),0)+1, 4, '0') FROM ADMIN_MASTER.HocPhan WHERE REGEXP_LIKE(MaHP, '^HP[0-9]+$')", conn);
            var result = cmd.ExecuteScalar();
            return result?.ToString() ?? "HP0001";
        }

        public bool Insert(HocPhan h)
        {
            if (string.IsNullOrEmpty(h.MaHP)) h.MaHP = GenerateNewMaHP();
            return Exec(
                "INSERT INTO ADMIN_MASTER.HocPhan(MaHP,TenHP,MaGV,MaSoTC,HocKy,NamHoc,MoTa,TrangThai) VALUES(:a,:b,:c,:d,:e,:f,:g,:h)", c =>
                {
                    c.Parameters.Add(":a", h.MaHP); c.Parameters.Add(":b", h.TenHP); c.Parameters.Add(":c", N(h.MaGV));
                    c.Parameters.Add(":d", N(h.MaSoTC)); c.Parameters.Add(":e", h.HocKy); c.Parameters.Add(":f", h.NamHoc);
                    c.Parameters.Add(":g", h.MoTa); c.Parameters.Add(":h", h.TrangThai);
                });
        }

        public bool Update(HocPhan h) => Exec(
            "UPDATE ADMIN_MASTER.HocPhan SET TenHP=:a,MaGV=:b,MaSoTC=:c,HocKy=:d,NamHoc=:e,MoTa=:f,TrangThai=:g WHERE MaHP=:h", c =>
            {
                c.Parameters.Add(":a", h.TenHP); c.Parameters.Add(":b", N(h.MaGV)); c.Parameters.Add(":c", N(h.MaSoTC));
                c.Parameters.Add(":d", h.HocKy); c.Parameters.Add(":e", h.NamHoc); c.Parameters.Add(":f", h.MoTa);
                c.Parameters.Add(":g", h.TrangThai); c.Parameters.Add(":h", h.MaHP);
            });

        public bool Delete(string id) => Exec("DELETE FROM ADMIN_MASTER.HocPhan WHERE MaHP=:a", c => c.Parameters.Add(":a", id));
    }
}

