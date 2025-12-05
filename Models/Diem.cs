using System;
namespace StudentManagementSystem.Models
{
    public class Diem
    {
        public string MaDiem { get; set; } = "";
        public string MaSV { get; set; } = "";
        public string MaHP { get; set; } = "";
        public decimal? DiemGiuaKy { get; set; }
        public decimal? DiemCuoiKy { get; set; }
        public decimal? DiemKhac { get; set; }
        public decimal? DiemTongKet { get; set; }
        public string? MaKQ { get; set; }
        public DateTime? NgayNhap { get; set; }
        public string? NguoiNhap { get; set; }
    }
}
