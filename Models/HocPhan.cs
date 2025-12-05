namespace StudentManagementSystem.Models
{
    public class HocPhan
    {
        public string MaHP { get; set; } = "";
        public string TenHP { get; set; } = "";
        public string? MaGV { get; set; }
        public string? MaSoTC { get; set; }
        public int HocKy { get; set; }
        public string NamHoc { get; set; } = "";
        public string MoTa { get; set; } = "";
        public int TrangThai { get; set; } = 1;
    }
}
