using System; using System.IO; using System.Text;

namespace StudentManagementSystem.Utilities
{
    public static class FileHelper
    {
        static string DefaultDir => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "PrivateKeys");

        public static string WritePrivateKeyFile(string content, string name, string? dir = null)
        {
            if (string.IsNullOrEmpty(content)) throw new ArgumentException("Private key content không được rỗng");
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("File name không được rỗng");
            dir ??= DefaultDir;
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            if (!name.EndsWith(".pem", StringComparison.OrdinalIgnoreCase)) name += ".pem";
            var path = Path.Combine(dir, name);
            File.WriteAllText(path, content, Encoding.UTF8);
            return path;
        }

        public static string ReadPrivateKeyFile(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("File path không được rỗng");
            if (!File.Exists(path)) throw new FileNotFoundException($"File không tồn tại: {path}");
            var content = File.ReadAllText(path, Encoding.UTF8);
            if (string.IsNullOrWhiteSpace(content)) throw new InvalidDataException("File private key trống hoặc không hợp lệ");
            return content;
        }

        public static bool IsValidPrivateKeyFile(string path)
        {
            try { var c = File.Exists(path) ? File.ReadAllText(path, Encoding.UTF8) : ""; return c.Contains("-----BEGIN") && c.Contains("-----END") && (c.Contains("PRIVATE KEY") || c.Contains("RSA PRIVATE KEY")); }
            catch { return false; }
        }

        public static string GeneratePrivateKeyFileName(string user, string role)
        {
            try { var t = DateTime.Now.ToString("yyyyMMdd_HHmmss"); return $"{user.Replace(" ", "_").Replace(".", "_")}_{role}_{t}_private_key.pem"; }
            catch { return $"user_{DateTime.Now:yyyyMMdd_HHmmss}_private_key.pem"; }
        }

        public static string GetFileInfo(string path)
        {
            try { if (!File.Exists(path)) return "File không tồn tại"; var f = new FileInfo(path); return $"Kích thước: {f.Length} bytes\nNgày tạo: {f.CreationTime:dd/MM/yyyy HH:mm:ss}\nNgày sửa: {f.LastWriteTime:dd/MM/yyyy HH:mm:ss}"; }
            catch (Exception ex) { return $"Lỗi đọc thông tin file: {ex.Message}"; }
        }

        public static bool DeletePrivateKeyFile(string path)
        {
            try { if (File.Exists(path)) { var data = new byte[new FileInfo(path).Length]; new Random().NextBytes(data); File.WriteAllBytes(path, data); File.Delete(path); } return true; }
            catch { return false; }
        }
    }
}