using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace HotelManagementProject
{
    public partial class frmLogin : Form
    {
        //private Timer opacityTimer = new Timer();
        public static string tentaikhoan = "";
        public static string tendangnhap = "";
        public static string quyen = "";
        TaiKhoanBLL tk;
        private Timer opacityTimer = new Timer();

        public frmLogin()
        {
            InitializeComponent();
            tk = new TaiKhoanBLL();
            this.Opacity = 0;
            opacityTimer.Interval = 5;
            opacityTimer.Tick += new EventHandler(OnTimerTick);
            opacityTimer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (this.Opacity < 1.0)
                this.Opacity += 0.09;
            else
                opacityTimer.Stop();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void picVisible_Click(object sender, EventArgs e)
        {
            picHidden.Visible = true;
            picVisible.Visible = false;
            txtPassword.PasswordChar = '\0';
        }

        private void picHidden_Click(object sender, EventArgs e)
        {
            picHidden.Visible = false;
            picVisible.Visible = true;
            txtPassword.PasswordChar = '*';
        }

        public void Login()
        {
            string username = tk.GetTenDangNhap(txtUsername.Text.Trim());
            string password = tk.GetMatKhau(txtUsername.Text.Trim());

            if (txtUsername.Text.Equals(string.Empty))
                MessageBox.Show("Chưa nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (txtPassword.Text.Equals(string.Empty))
                    MessageBox.Show("Chưa nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (!(username.Equals(txtUsername.Text.Trim()) && password.Equals(txtPassword.Text.Trim())))
                    {
                        MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        tendangnhap = txtUsername.Text.Trim();
                        tentaikhoan = tk.GetTenTaiKhoan(txtUsername.Text.Trim());
                        quyen = tk.GetQuyen(txtUsername.Text.Trim());
                        txtUsername.Text = ""; txtPassword.Text = "";
                        MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Program.mainForm = new FrmMain();
                        Program.mainForm.Show();
                        this.Visible = false;
                    }
                }
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Login();
            
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Login();
        }
    }
}
