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
    public partial class frmBookingOnline : Form
    {
        DatPhongOnlineBLL dpobll;
        string id;
        public frmBookingOnline()
        {
            InitializeComponent();
            dpobll = new DatPhongOnlineBLL();
            LoadData();
            comboBox1.SelectedIndex = 0;
        }
        public void LoadData()
        {
            tblDatPhongOnline.DataSource = dpobll.LoadData();
            tblDatPhongOnline.Columns[0].HeaderText = "Mã đặt phòng online";
            tblDatPhongOnline.Columns[1].HeaderText = "Tên khách hàng";
            tblDatPhongOnline.Columns[2].HeaderText = "Ngày sinh";
            tblDatPhongOnline.Columns[3].HeaderText = "Địa chỉ";
            tblDatPhongOnline.Columns[4].HeaderText = "SĐT";
            tblDatPhongOnline.Columns[5].HeaderText = "CCCD";
            tblDatPhongOnline.Columns[6].HeaderText = "Giới tính";
        }

        private void tblDatPhongOnline_Click(object sender, EventArgs e)
        {
            if (tblDatPhongOnline != null && tblDatPhongOnline.Rows.Count > 0)
            {
                int i = tblDatPhongOnline.CurrentRow.Index;
                id = tblDatPhongOnline.Rows[i].Cells[0].Value.ToString();
                lblTenKH.Text = tblDatPhongOnline.Rows[i].Cells[1].Value.ToString();
                lblTenKH1.Text = tblDatPhongOnline.Rows[i].Cells[1].Value.ToString();
                lblNgaySinh.Text = tblDatPhongOnline.Rows[i].Cells[2].Value.ToString();
                lblDiaChi.Text = tblDatPhongOnline.Rows[i].Cells[3].Value.ToString();
                lblSDT.Text = tblDatPhongOnline.Rows[i].Cells[4].Value.ToString();
                lblSDT1.Text = tblDatPhongOnline.Rows[i].Cells[4].Value.ToString();
                lblCccd.Text = tblDatPhongOnline.Rows[i].Cells[5].Value.ToString();
                lblGioiTinh.Text = tblDatPhongOnline.Rows[i].Cells[6].Value.ToString();
                lblPhongMuonDat.Text = dpobll.getIdPhong(int.Parse(id));
                lblSoNguoiO.Text = dpobll.getSoNguoiO(int.Parse(id));
                lblCheckIn.Text = dpobll.getCheckIn(int.Parse(id));
                lblCheckOut.Text = dpobll.getCheckOut(int.Parse(id));
                lblTienDatCoc.Text = dpobll.tinhTienDatCoc(lblPhongMuonDat.Text).ToString("N0");
                lblThongBao.Text = string.Empty;
                txtTienDatCoc.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Chưa có dữ liệu");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lblSDT.Text == string.Empty)
                MessageBox.Show("Chưa chọn khách hàng");
            else
            {
                if (dpobll.checkKhachHangTonTai(lblCccd.Text))
                    lblThongBao.Text = "Khách hàng đã tồn tại" + "\nTiến hành checkin cho khách hàng";
                else
                {
                    dpobll.themKhachHang(lblTenKH.Text, DateTime.Parse(lblNgaySinh.Text), lblDiaChi.Text, lblSDT.Text, lblCccd.Text, lblGioiTinh.Text);
                    lblThongBao.Text = "Thêm thông tin thành công" + "\nTiến hành checkin cho khách hàng";
                }
                panel1.Visible = true;
            }
        }

        private void label7_Click(object sender, EventArgs e) { this.Dispose(); }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (txtTienDatCoc.Text == string.Empty)
                MessageBox.Show("Chưa nhập tiền đặt cọc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (txtTienDatCoc.Text.Equals(lblTienDatCoc.Text.Replace(",", "")))
                {
                    string idkh = dpobll.getIdKhachHang(lblCccd.Text);
                    string idnv = dpobll.getIdNhanVien(frmLogin.tendangnhap);
                    lblTenKH1.Text = idkh;
                    lblSDT1.Text = idnv;
                    dpobll.checkInOnline(idnv, idkh, lblPhongMuonDat.Text, DateTime.Parse(lblCheckIn.Text), DateTime.Parse(lblCheckOut.Text),
                        int.Parse(lblSoNguoiO.Text), comboBox1.Text, double.Parse(txtTienDatCoc.Text));
                    dpobll.UpdateTrangThaiPhong(lblPhongMuonDat.Text.Trim());
                    dpobll.DeleteDatPhongOnline(int.Parse(id));
                    MessageBox.Show("Check in thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                    Program.mainForm.Close();
                    Program.mainForm = new FrmMain();
                    Program.mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Nhập đúng tiền đặt cọc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
