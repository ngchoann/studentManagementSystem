using System;
using System.Windows.Forms;
using StudentManagementSystem.Forms;

namespace StudentManagementSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Hiển thị form đăng nhập
            Application.Run(new LoginForm());
        }
    }
}
