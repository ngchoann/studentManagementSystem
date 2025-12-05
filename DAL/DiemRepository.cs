using System.Collections.Generic;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.DAL
{
    public class DiemRepository : BaseRepository
    {
        public List<Diem> GetAll() => Query("SELECT * FROM DIEM ORDER BY MADIEM", r => new Diem
        {
            MaDiem = S(r["MaDiem"]), MaSV = S(r["MaSV"]), MaHP = S(r["MaHP"]),
            DiemGiuaKy = M(r["DiemGiuaKy"]), DiemCuoiKy = M(r["DiemCuoiKy"]),
            DiemKhac = M(r["DiemKhac"]), DiemTongKet = M(r["DiemTongKet"]),
            MaKQ = S(r["MaKQ"]), NgayNhap = D(r["NgayNhap"]), NguoiNhap = S(r["NguoiNhap"])
        });

        public bool Insert(Diem d) => Exec(
            @"INSERT INTO ADMIN_MASTER.Diem(MaDiem,MaSV,MaHP,DiemGiuaKy,DiemCuoiKy,DiemKhac,DiemTongKet,MaKQ,NgayNhap,NguoiNhap)
              VALUES(:a,:b,:c,:d,:e,:f,:g,:h,SYSDATE,:i)", c =>
            {
                c.Parameters.Add(":a", d.MaDiem); c.Parameters.Add(":b", d.MaSV); c.Parameters.Add(":c", d.MaHP);
                c.Parameters.Add(":d", N(d.DiemGiuaKy)); c.Parameters.Add(":e", N(d.DiemCuoiKy));
                c.Parameters.Add(":f", N(d.DiemKhac)); c.Parameters.Add(":g", N(d.DiemTongKet));
                c.Parameters.Add(":h", N(d.MaKQ)); c.Parameters.Add(":i", OracleConnection.Instance.CurrentUser);
            });

        public bool Update(Diem d) => Exec(
            "UPDATE ADMIN_MASTER.Diem SET DiemGiuaKy=:a,DiemCuoiKy=:b,DiemKhac=:c,DiemTongKet=:d,MaKQ=:e WHERE MaDiem=:f", c =>
            {
                c.Parameters.Add(":a", N(d.DiemGiuaKy)); c.Parameters.Add(":b", N(d.DiemCuoiKy));
                c.Parameters.Add(":c", N(d.DiemKhac)); c.Parameters.Add(":d", N(d.DiemTongKet));
                c.Parameters.Add(":e", N(d.MaKQ)); c.Parameters.Add(":f", d.MaDiem);
            });

        public bool Delete(string id) => Exec("DELETE FROM ADMIN_MASTER.Diem WHERE MaDiem=:a", c => c.Parameters.Add(":a", id));
    }
}

