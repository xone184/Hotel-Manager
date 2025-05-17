using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementProject
{
    public partial class frmAccount : Form
    {
        TaiKhoanBLL tkbll;
        public frmAccount()
        {
            InitializeComponent();
            tkbll = new TaiKhoanBLL();
            LoadData();
            LoadCboNhanVien();
            cboQuyen.SelectedIndex = 1;
        }
        public void LoadData()
        {
            tblTaiKhoan.DataSource = tkbll.getListAccount();
        }
        public void LoadCboNhanVien()
        {
            cboNhanVien.DataSource = tkbll.GetListTenNhanVien();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result = tkbll.ThemTaiKhoan(tkbll.GetIdNhanVien(cboNhanVien.Text), txtTenDangNhap.Text, cboQuyen.Text);
            if (result == 0)
                MessageBox.Show("Nhân viên: " + cboNhanVien.Text + " đã có tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == 1)
            {
                MessageBox.Show("Thêm tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }    
        }

        private void tblTaiKhoan_Click(object sender, EventArgs e)
        {
            int i = tblTaiKhoan.CurrentRow.Index;
            cboNhanVien.Text = tblTaiKhoan.Rows[i].Cells[2].Value.ToString();
            txtTenDangNhap.Text = tblTaiKhoan.Rows[i].Cells[3].Value.ToString();
            cboQuyen.Text = tblTaiKhoan.Rows[i].Cells[5].Value.ToString();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            cboNhanVien.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cboNhanVien.Enabled = true;
            cboNhanVien.SelectedIndex = 0;
            cboQuyen.SelectedIndex = 1;
            txtTenDangNhap.Text = string.Empty;
            LoadData();
            button1.Enabled = true; button2.Enabled = false; button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int i = tblTaiKhoan.CurrentRow.Index;
                tkbll.XoaTaiKhoan(int.Parse(tblTaiKhoan.Rows[i].Cells[0].Value.ToString()));
                LoadData();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int i = tblTaiKhoan.CurrentRow.Index;
                tkbll.SuaTaiKhoan(int.Parse(tblTaiKhoan.Rows[i].Cells[0].Value.ToString()), txtTenDangNhap.Text, cboQuyen.Text);
                LoadData();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có reset mật khẩu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int i = tblTaiKhoan.CurrentRow.Index;
                tkbll.ResetPassword(int.Parse(tblTaiKhoan.Rows[i].Cells[0].Value.ToString()));
                LoadData();
            }
        }
    }
}
