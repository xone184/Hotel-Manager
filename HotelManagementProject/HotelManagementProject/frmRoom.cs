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
using DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelManagementProject
{
    public partial class frmRoom : Form
    {
        PhongBLL pbll;
        LoaiPhongBLL lpBLL;
        private BindingList<phong> dataphong = new BindingList<phong>();

        public frmRoom()
        {
            pbll = new PhongBLL();
            lpBLL = new LoaiPhongBLL();
            InitializeComponent();

            cboFind.SelectedIndex = 0;
        }



        private void frmRoom_Load(object sender, EventArgs e)
        {
            LoadTablePhong(); LoadDataForCboKhachHang();
        }

        private void LoadDataForCboKhachHang()
        {
            cbxTenLoaiPhong.DataSource = lpBLL.GetTenLoaiPhongList();
        }

        public void LoadTablePhong()
        {
            List<PhongDTO1> dataFromDatabase = pbll.GetPhongDTO1();
            tblPhong.DataSource = dataFromDatabase;
            tblPhong.Columns[0].HeaderText = "ID Phòng";
            tblPhong.Columns[1].HeaderText = "ID Loại Phòng";
            tblPhong.Columns[2].HeaderText = "Tên Phòng";
            tblPhong.Columns[3].HeaderText = "Trạng Thái";
            tblPhong.Columns[4].HeaderText = "ID Tầng";
            tblPhong.Columns[5].HeaderText = "Giá";

            tblPhong.AllowUserToResizeRows = false;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTenPhong.Text = string.Empty; txtSoTang.Text = string.Empty; txtGiaPhong.Text = string.Empty;
            txtTenPhong.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int i = tblPhong.CurrentRow.Index;
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                pbll.XoaPhong(tblPhong.Rows[i].Cells[0].Value.ToString().Trim());
                LoadTablePhong();
            }
            txtTenPhong.Text = string.Empty; txtSoTang.Text = string.Empty; txtGiaPhong.Text = string.Empty;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                pbll.ThemPhong(lpBLL.GetIdLoaiPhongByTen(cbxTenLoaiPhong.Text), int.Parse(txtSoTang.Text.Trim()), txtTenPhong.Text.Trim(), cbxTrangThai.Text, int.Parse(txtGiaPhong.Text.Trim()));
                LoadTablePhong();
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật lại khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            int i = tblPhong.CurrentRow.Index;
            if (result == DialogResult.Yes)
            {
                pbll.CapNhatPhong(tblPhong.Rows[i].Cells[0].Value.ToString().Trim(), lpBLL.GetIdLoaiPhongByTen(cbxTenLoaiPhong.Text), int.Parse(txtSoTang.Text.Trim()), txtTenPhong.Text.Trim(), cbxTrangThai.Text, int.Parse(txtGiaPhong.Text.Trim()));
                LoadTablePhong();
            }
        }
        private void tblPhong_Click(object sender, EventArgs e)
        {
            if (tblPhong.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = tblPhong.SelectedRows[0];
                string selectedValue = selectedRow.Cells[1].Value.ToString();
                cbxTenLoaiPhong.SelectedItem = selectedValue;
                txtTenPhong.Text = selectedRow.Cells[2].Value.ToString();

                string selectedValue1 = selectedRow.Cells[3].Value.ToString();
                cbxTrangThai.SelectedItem = selectedValue1;

                txtSoTang.Text = selectedRow.Cells[4].Value.ToString();
                txtGiaPhong.Text = selectedRow.Cells[5].Value.ToString();

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.mainForm = new FrmMain();
            Program.mainForm.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.roomForm = new frmRoom();
            Program.roomForm.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (cboFind.Text == "Mã Phòng")
                tblPhong.DataSource = pbll.GetHoaDonList_MaHoaDon(txtFind.Text.Trim());
            if (cboFind.Text == "Tên Phòng")
                tblPhong.DataSource = pbll.GetHoaDonList_TenHoaDon(txtFind.Text.Trim());
            if (cboFind.Text == "Mã Loại Phòng")
                tblPhong.DataSource = pbll.GetHoaDonList_LoaiHoaDon(int.Parse(txtFind.Text.Trim()));
            if (cboFind.Text == "Số Tầng")
                tblPhong.DataSource = pbll.GetHoaDonList_TangHoaDon(int.Parse(txtFind.Text.Trim()));
            if (cboFind.Text == "Trạng Thái")
                tblPhong.DataSource = pbll.GetHoaDonList_TTHoaDon(txtFind.Text.Trim());
            
        }
    }
}
