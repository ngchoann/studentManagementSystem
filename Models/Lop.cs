namespace StudentManagementSystem.Models
{
    public class Lop
    {
        public string MaLop { get; set; } = "";
        public string TenLop { get; set; } = "";
        public string Khoa { get; set; } = "";
        public string NienKhoa { get; set; } = "";
        public string? MaGVCN { get; set; }
        public int SiSo { get; set; }
        public int TrangThai { get; set; } = 1;
    }
}
