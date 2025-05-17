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
using BLL;
using System.Globalization;

namespace HotelManagementProject
{

    public partial class frmCustomer : Form
    {
        KhachHangBLL khbll;
        private BindingList<khachhang> datakhachhang = new BindingList<khachhang>();
        private Timer opacityTimer = new Timer();

        public frmCustomer()
        {
            khbll = new KhachHangBLL();
            InitializeComponent();
            this.Opacity = 0;
            opacityTimer.Interval = 5;
            opacityTimer.Tick += new EventHandler(OnTimerTick);
            opacityTimer.Start();
            txtSdt.KeyPress += new KeyPressEventHandler(txtSdt_KeyPress);
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            cboFind.SelectedIndex = 0;

        }
        private void OnTimerTick(object sender, EventArgs e)
        {
            if (this.Opacity < 1.0)
                this.Opacity += 0.1;
            else
                opacityTimer.Stop();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            LoadTableKhachHang();
            rdNam.Checked = true;
        }

        public void LoadTableKhachHang()
        {
            List<khachhang> dataFromDatabase = khbll.GetKhachHangList();
            tblKhachHang.DataSource = dataFromDatabase;
            tblKhachHang.Columns[0].HeaderText = "Mã Khách Hàng";
            tblKhachHang.Columns[1].HeaderText = "Tên Khách Hang";
            tblKhachHang.Columns[2].HeaderText = "Ngày Sinh";
            tblKhachHang.Columns[3].HeaderText = "Địa chỉ";
            tblKhachHang.Columns[4].HeaderText = "Số điện thoại";
            tblKhachHang.Columns[5].HeaderText = "CMND";
            tblKhachHang.Columns[6].HeaderText = "Giới tính";

            tblKhachHang.AllowUserToResizeRows = false;
        }


        private void tblKhachHang_Click(object sender, EventArgs e)
        {
            if (tblKhachHang.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = tblKhachHang.SelectedRows[0];
                txtTen.Text = selectedRow.Cells[1].Value.ToString();
                DateTime ngaySinh = Convert.ToDateTime(selectedRow.Cells[2].Value);
                dateNgaySinh.Text = ngaySinh.ToShortDateString(); txtDiaChi.Text = selectedRow.Cells[3].Value.ToString();
                txtSdt.Text = selectedRow.Cells[4].Value.ToString();
                txtCmnd.Text = selectedRow.Cells[5].Value.ToString();

                string gioiTinh = selectedRow.Cells[6].Value.ToString();
                if (gioiTinh == "Nam")
                {
                    rdNam.Checked = true;
                    rdNu.Checked = false;
                }
                else if (gioiTinh == "Nữ")
                {
                    rdNam.Checked = false;
                    rdNu.Checked = true;
                }
                else
                {
                    rdNam.Checked = false;
                    rdNu.Checked = false;
                }
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
            }


        }

        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // Kiểm tra độ dài của số điện thoại
            if (txtSdt.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        private void btnThem_Click_1(object sender, EventArgs e)
        {

            txtTen.Text = string.Empty; txtDiaChi.Text = string.Empty; txtSdt.Text = string.Empty; txtCmnd.Text = string.Empty;
            txtTen.Focus();
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                int i = tblKhachHang.CurrentRow.Index;
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    khbll.XoaKhachHang(tblKhachHang.Rows[i].Cells[0].Value.ToString().Trim());
                    LoadTableKhachHang();
                }
                txtTen.Text = string.Empty; dateNgaySinh.Text = string.Empty; txtDiaChi.Text = string.Empty; txtSdt.Text = string.Empty; txtCmnd.Text = string.Empty;

            }
            catch (Exception)
            {
                MessageBox.Show("Khách hàng " + txtTen.Text + " đã có hóa đơn, Không được xóa");
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string ngaySinhText = dateNgaySinh.Text.Trim();
                DateTime ngaySinh;

                if (!DateTime.TryParseExact(ngaySinhText, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaySinh))
                {
                    MessageBox.Show("Ngày sinh không hợp lệ. Vui lòng nhập theo định dạng dd/MM/yyyy.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int tuoi = DateTime.Now.Year - ngaySinh.Year;

                if (tuoi < 18)
                {
                    MessageBox.Show("Khách hàng phải đủ 18 tuổi trở lên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (rdNam.Checked)
                {
                    khbll.ThemKhachHang(txtTen.Text.Trim(), ngaySinh, txtDiaChi.Text.Trim(), txtSdt.Text.Trim(), txtCmnd.Text.Trim(), rdNam.Text);
                }
                else if (rdNu.Checked)
                {
                    khbll.ThemKhachHang(txtTen.Text.Trim(), ngaySinh, txtDiaChi.Text.Trim(), txtSdt.Text.Trim(), txtCmnd.Text.Trim(), rdNu.Text);
                }

                string phoneNumber = txtSdt.Text.Trim();

                if (phoneNumber.Length != 10 || !phoneNumber.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập 10 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoadTableKhachHang();
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật lại khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            int i = tblKhachHang.CurrentRow.Index;

            if (result == DialogResult.Yes)
            {
                string ngaySinhText = dateNgaySinh.Text.Trim();
                DateTime ngaySinh;

                if (!DateTime.TryParseExact(ngaySinhText, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaySinh))
                {
                    MessageBox.Show("Ngày sinh không hợp lệ. Vui lòng nhập theo định dạng dd/MM/yyyy.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int tuoi = DateTime.Now.Year - ngaySinh.Year;

                if (tuoi < 18)
                {
                    MessageBox.Show("Khách hàng phải đủ 18 tuổi trở lên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (rdNu.Checked)
                {
                    khbll.CapNhatKhachHang(tblKhachHang.Rows[i].Cells[0].Value.ToString().Trim(), txtTen.Text.Trim(), ngaySinh, txtDiaChi.Text.Trim(), txtSdt.Text.Trim(), txtCmnd.Text.Trim(), rdNu.Text);
                    LoadTableKhachHang();
                }

                if (rdNam.Checked)
                {
                    khbll.CapNhatKhachHang(tblKhachHang.Rows[i].Cells[0].Value.ToString().Trim(), txtTen.Text.Trim(), ngaySinh, txtDiaChi.Text.Trim(), txtSdt.Text.Trim(), txtCmnd.Text.Trim(), rdNam.Text);
                    LoadTableKhachHang();
                }

                string phoneNumber = txtSdt.Text.Trim();

                if (phoneNumber.Length != 10 || !phoneNumber.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập 10 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.customerForm = new frmCustomer();
            Program.customerForm.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.mainForm = new FrmMain();
            Program.mainForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboFind.Text == "Mã Khách Hàng")
                tblKhachHang.DataSource = khbll.GetHoaDonList_MaHoaDon(txtFind.Text.Trim());
            if (cboFind.Text == "Tên Khách Hàng")
                tblKhachHang.DataSource = khbll.GetHoaDonList_TenHoaDon(txtFind.Text.Trim());
            if (cboFind.Text == "Số Điện Thoại")
                tblKhachHang.DataSource = khbll.GetHoaDonList_sdtHoaDon(txtFind.Text.Trim());
            if (cboFind.Text == "CMND")
                tblKhachHang.DataSource = khbll.GetHoaDonList_CmndHoaDon(txtFind.Text.Trim());

        }
    }
}
