using BLL;
using DTO;
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
    public partial class frmBill : Form
    {
        HoaDonBLL hdbll;
        private BindingList<datphong> datahoadon = new BindingList<datphong>();
        public frmBill()
        {
            hdbll = new HoaDonBLL();

            InitializeComponent();
            cboFind.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
        }

        public void loadtablehoadon()
        {
            List<HoaDonDTO> dataFromDatabase = hdbll.GetHoaDonList();
            tblHoaDon.DataSource = dataFromDatabase;
            tblHoaDon.Columns[0].HeaderText = "Mã Hóa Đơn";
            tblHoaDon.Columns[1].HeaderText = "Mã Nhân Viên";
            tblHoaDon.Columns[2].HeaderText = "Mã Khách Hàng";
            tblHoaDon.Columns[3].HeaderText = "Mã Phòng";
            tblHoaDon.Columns[4].HeaderText = "Check-In";
            tblHoaDon.Columns[5].HeaderText = "Check-Out";
            tblHoaDon.Columns[6].HeaderText = "Tiền Đặt Cọc";
            tblHoaDon.Columns[7].HeaderText = "Tiền Phòng";
            tblHoaDon.Columns[8].HeaderText = "Phụ Thu Check-In";
            tblHoaDon.Columns[9].HeaderText = "Phụ Thu Check-Out";
            tblHoaDon.Columns[10].HeaderText = "Tổng Tiền Dịch Vụ";
            tblHoaDon.Columns[11].HeaderText = "Tổng Tiền Thiết Bị";
            tblHoaDon.Columns[12].HeaderText = "Tổng Tiền Hóa Đơn";
            tblHoaDon.Columns[13].HeaderText = "Tiền Thanh Toán";
            tblHoaDon.Columns[14].HeaderText = "Số Người Ở";
            tblHoaDon.Columns[15].HeaderText = "Loại Thuê";
            tblHoaDon.Columns[16].HeaderText = "Trạng Thái";

            tblHoaDon.AllowUserToResizeRows = false;
        }

        public void loadtablehoadontheotrangthai(string trangthai)
        {
            List<HoaDonDTO> dataFromDatabase = hdbll.GetHoaDonListTrangThai(trangthai);
            tblHoaDon.DataSource = dataFromDatabase;
            tblHoaDon.Columns[0].HeaderText = "Mã Hóa Đơn";
            tblHoaDon.Columns[1].HeaderText = "Mã Nhân Viên";
            tblHoaDon.Columns[2].HeaderText = "Mã Khách Hàng";
            tblHoaDon.Columns[3].HeaderText = "Mã Phòng";
            tblHoaDon.Columns[4].HeaderText = "Check-In";
            tblHoaDon.Columns[5].HeaderText = "Check-Out";
            tblHoaDon.Columns[6].HeaderText = "Tiền Đặt Cọc";
            tblHoaDon.Columns[7].HeaderText = "Tiền Phòng";
            tblHoaDon.Columns[8].HeaderText = "Phụ Thu Check-In";
            tblHoaDon.Columns[9].HeaderText = "Phụ Thu Check-Out";
            tblHoaDon.Columns[10].HeaderText = "Tổng Tiền Dịch Vụ";
            tblHoaDon.Columns[11].HeaderText = "Tổng Tiền Thiết Bị";
            tblHoaDon.Columns[12].HeaderText = "Tổng Tiền Hóa Đơn";
            tblHoaDon.Columns[13].HeaderText = "Tiền Thanh Toán";
            tblHoaDon.Columns[14].HeaderText = "Số Người Ở";
            tblHoaDon.Columns[15].HeaderText = "Loại Thuê";
            tblHoaDon.Columns[16].HeaderText = "Trạng Thái";

            tblHoaDon.AllowUserToResizeRows = false;
        }



        private void frmBill_Load(object sender, EventArgs e)
        {
            loadtablehoadon();
        }




        private void btnFindBill_Click(object sender, EventArgs e)
        {
            if (cboFind.Text == "Mã Hóa Đơn")
                tblHoaDon.DataSource = hdbll.GetHoaDonList_MaHoaDon(txtFind.Text);
            if (cboFind.Text == "Tên Khách Hàng")
                tblHoaDon.DataSource = hdbll.GetHoaDonList_TenKH(txtFind.Text.Trim());
            if (cboFind.Text == "Tên Nhân Viên")
                tblHoaDon.DataSource = hdbll.GetHoaDonList_TenNV(txtFind.Text.Trim());
            if (cboFind.Text == "Tên Phòng")
                tblHoaDon.DataSource = hdbll.GetHoaDonList_TenPhong(txtFind.Text.Trim());
            if (txtFind.Text == string.Empty)
                loadtablehoadon();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboFind.Text == "Mã Hóa Đơn")
                tblHoaDon.DataSource = hdbll.GetHoaDonList_MaHoaDon(txtFind.Text);
            if (cboFind.Text == "Tên Khách Hàng")
                tblHoaDon.DataSource = hdbll.GetHoaDonList_TenKH(txtFind.Text.Trim());
            if (cboFind.Text == "Tên Nhân Viên")
                tblHoaDon.DataSource = hdbll.GetHoaDonList_TenNV(txtFind.Text.Trim());
            if (cboFind.Text == "Tên Phòng")
                tblHoaDon.DataSource = hdbll.GetHoaDonList_TenPhong(txtFind.Text.Trim());
            if (txtFind.Text == string.Empty)
                loadtablehoadon();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            if (txtFind.Text == string.Empty)
                loadtablehoadon();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.billForm = new frmBill();
            Program.billForm.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.mainForm = new FrmMain();
            Program.mainForm.Show();
        }

        private void tblHoaDon_Click(object sender, EventArgs e)
        {
            if (tblHoaDon != null && tblHoaDon.Rows.Count > 0)
            {
                
                int i = tblHoaDon.CurrentRow.Index;
                txtTenKH.Text = hdbll.LayTenTuKhachHang(tblHoaDon.Rows[i].Cells[2].Value.ToString());
                dateNgaySinhKH.Value = hdbll.LayNgaySinhTuKhachHang(tblHoaDon.Rows[i].Cells[2].Value.ToString());
                txtDiaChiKH.Text = hdbll.LayDiaChiTuKhachHang(tblHoaDon.Rows[i].Cells[2].Value.ToString());
                txtSdtKH.Text = hdbll.LaySDTTuKhachHang(tblHoaDon.Rows[i].Cells[2].Value.ToString());
                txtCmndKH.Text = hdbll.LayCMNDTuKhachHang(tblHoaDon.Rows[i].Cells[2].Value.ToString());
                txtGtKH.Text = hdbll.LayGioiTinhTuKhachHang(tblHoaDon.Rows[i].Cells[2].Value.ToString());

                txtTenNV.Text = hdbll.LayTenTuNhanVien(tblHoaDon.Rows[i].Cells[1].Value.ToString());
                dateNgaySinhNV.Value = hdbll.LayNgaySinhTuNhanVien(tblHoaDon.Rows[i].Cells[1].Value.ToString());
                txtSdtNV.Text = hdbll.LaySdtTuNhanVien(tblHoaDon.Rows[i].Cells[1].Value.ToString());
                txtGtNV.Text = hdbll.LayGioiTinhTuNhanVien(tblHoaDon.Rows[i].Cells[1].Value.ToString());
                txtEmailNV.Text = hdbll.LayEmailTuNhanVien(tblHoaDon.Rows[i].Cells[1].Value.ToString());


                dataDV.DataSource = hdbll.LayDichVu(tblHoaDon.Rows[i].Cells[0].Value.ToString());
                dataDV.Columns[0].HeaderText = "Mã Hóa Đơn";
                dataDV.Columns[1].HeaderText = "Tên Dịch Vụ";
                dataDV.Columns[2].HeaderText = "Ngày Thuê";
                dataDV.Columns[3].HeaderText = "Số Lượng";
                dataDV.Columns[4].HeaderText = "Tổng Tiền";

                dataTB.DataSource = hdbll.LayThietBi(tblHoaDon.Rows[i].Cells[0].Value.ToString());
                dataTB.Columns[0].HeaderText = "Mã Hóa Đơn";
                dataTB.Columns[1].HeaderText = "Tên Thiết Bị";
                dataTB.Columns[2].HeaderText = "Ngày Thuê";
                dataTB.Columns[3].HeaderText = "Số Lượng";
                dataTB.Columns[4].HeaderText = "Tổng Tiền";

                panel1.Visible = true;
            }
            else
            {
                MessageBox.Show("Chưa có dữ liệu");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                loadtablehoadontheotrangthai(comboBox1.Text);
            if (comboBox1.SelectedIndex == 1)
                loadtablehoadontheotrangthai(comboBox1.Text);
        }
    }
}
