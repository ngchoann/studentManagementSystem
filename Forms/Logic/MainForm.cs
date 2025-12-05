using System;
using System.Windows.Forms;
using StudentManagementSystem.DAL;

namespace StudentManagementSystem.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = $"User: {OracleConnection.Instance.CurrentUser}";
            lblRole.Text = $"Role: {OracleConnection.Instance.CurrentRole}";
            SetPermissionsByRole(OracleConnection.Instance.CurrentRole);
        }

        private void SetPermissionsByRole(string role)
        {
            switch (role)
            {
                case "ADMIN":
                    menuSinhVien.Enabled = menuGiaoVien.Enabled = menuLop.Enabled = menuHocPhan.Enabled = menuDiem.Enabled = true;
                    break;
                case "GIAOVIEN":
                    menuSinhVien.Enabled = menuLop.Enabled = menuHocPhan.Enabled = menuDiem.Enabled = true;
                    menuGiaoVien.Enabled = false;
                    break;
                case "SINHVIEN":
                    menuLop.Enabled = menuHocPhan.Enabled = menuDiem.Enabled = true;
                    menuSinhVien.Enabled = menuGiaoVien.Enabled = false;
                    break;
                default:
                    menuQuanLy.Enabled = false;
                    break;
            }
        }

        private void menuSinhVien_Click(object sender, EventArgs e) => OpenChildForm(new SinhVienForm());
        private void menuGiaoVien_Click(object sender, EventArgs e) => OpenChildForm(new GiaoVienForm());
        private void menuLop_Click(object sender, EventArgs e) => OpenChildForm(new LopForm());
        private void menuHocPhan_Click(object sender, EventArgs e) => OpenChildForm(new HocPhanForm());
        private void menuDiem_Click(object sender, EventArgs e) => OpenChildForm(new DiemForm());

        private void OpenChildForm(Form childForm)
        {
            foreach (Form form in this.MdiChildren)
                if (form.GetType() == childForm.GetType()) { form.Activate(); return; }
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void menuDangXuat_Click(object sender, EventArgs e)
        {
            OracleConnection.Instance.Disconnect();
            foreach (Form form in this.MdiChildren) form.Close();
            this.Hide();
            
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK) { this.Show(); MainForm_Load(sender, e); }
            else Application.Exit();
        }

        private void menuThoat_Click(object sender, EventArgs e) => Application.Exit();
    }
}
