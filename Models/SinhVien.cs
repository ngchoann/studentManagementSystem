using System;
namespace StudentManagementSystem.Models
{
    public class SinhVien
    {
        public string MaSV { get; set; } = "";
        public string HoTen { get; set; } = "";
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; } = "";
        public string Email { get; set; } = "";
        public string SoDienThoai { get; set; } = "";
        public string DiaChi { get; set; } = "";
        public string MaLop { get; set; } = "";
        public DateTime? NgayNhapHoc { get; set; }
        public int TrangThai { get; set; } = 1;
        public string? OracleUsername { get; set; }
    }
}
