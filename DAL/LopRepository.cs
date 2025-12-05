using System.Collections.Generic;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.DAL
{
    public class LopRepository : BaseRepository
    {
        public List<Lop> GetAll() => Query("SELECT * FROM LOP ORDER BY MALOP", r => new Lop
        {
            MaLop = S(r["MaLop"]), TenLop = S(r["TenLop"]), Khoa = S(r["Khoa"]),
            NienKhoa = S(r["NienKhoa"]), MaGVCN = S(r["MaGVCN"]), SiSo = I(r["SiSo"]), TrangThai = I(r["TrangThai"])
        });

        public bool Insert(Lop l) => Exec(
            "INSERT INTO ADMIN_MASTER.Lop(MaLop,TenLop,Khoa,NienKhoa,MaGVCN,SiSo,TrangThai) VALUES(:a,:b,:c,:d,:e,:f,:g)", c =>
            {
                c.Parameters.Add(":a", l.MaLop); c.Parameters.Add(":b", l.TenLop); c.Parameters.Add(":c", l.Khoa);
                c.Parameters.Add(":d", l.NienKhoa); c.Parameters.Add(":e", N(l.MaGVCN));
                c.Parameters.Add(":f", l.SiSo); c.Parameters.Add(":g", l.TrangThai);
            });

        public bool Update(Lop l) => Exec(
            "UPDATE ADMIN_MASTER.Lop SET TenLop=:a,Khoa=:b,NienKhoa=:c,MaGVCN=:d,SiSo=:e,TrangThai=:f WHERE MaLop=:g", c =>
            {
                c.Parameters.Add(":a", l.TenLop); c.Parameters.Add(":b", l.Khoa); c.Parameters.Add(":c", l.NienKhoa);
                c.Parameters.Add(":d", N(l.MaGVCN)); c.Parameters.Add(":e", l.SiSo);
                c.Parameters.Add(":f", l.TrangThai); c.Parameters.Add(":g", l.MaLop);
            });

        public bool Delete(string id) => Exec("DELETE FROM ADMIN_MASTER.Lop WHERE MaLop=:a", c => c.Parameters.Add(":a", id));
    }
}

