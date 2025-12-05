using System;
namespace StudentManagementSystem.Models
{
    public class GiaoVien
    {
        public string MaGV { get; set; } = "";
        public string HoTen { get; set; } = "";
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; } = "";
        public string Email { get; set; } = "";
        public string SoDienThoai { get; set; } = "";
        public string DiaChi { get; set; } = "";
        public string ChuyenMon { get; set; } = "";
        public DateTime? NgayVaoLam { get; set; }
        public int TrangThai { get; set; } = 1;
    }
}
