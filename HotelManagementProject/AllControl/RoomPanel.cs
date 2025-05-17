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

namespace AllControl
{
    public partial class RoomPanel : UserControl
    {
        PhongBLL phongBLL;
        public string id_phong;
        public RoomPanel() { }
        public RoomPanel(string tenphong, string sotang, string loaiphong, string trangthai, string idphong)
        {
            InitializeComponent();
            phongBLL = new PhongBLL();
            id_phong = idphong;
            label1.Text.ToUpper();
            label1.Text = tenphong;
            label3.Text = sotang;
            label6.Text = loaiphong;
            label7.Text = trangthai;
            if (trangthai.Equals("Còn trống"))
            {
                tableLayoutPanel1.BackColor = Color.Green;
                tableLayoutPanel1.ForeColor = Color.White;
                btnCheckIn.Visible = true;
                btnCheckOut.Visible = false;
                btnDonPhongConTrong.Visible = true;
                btnHuyDonPhongConTrong.Visible = false;
                btnDonPhongDangSuDung.Visible = false;
                btnHuyDonPhongDangSuDung.Visible = false;
            }
            else if (trangthai.Equals("Đang sử dụng"))
            {
                tableLayoutPanel1.BackColor = Color.Red;
                tableLayoutPanel1.ForeColor = Color.White;
                btnCheckIn.Visible = false;
                btnCheckOut.Visible = true;
                btnDonPhongConTrong.Visible = false;
                btnHuyDonPhongConTrong.Visible = false;
                btnDonPhongDangSuDung.Visible = true;
                btnHuyDonPhongDangSuDung.Visible = false;
            }
            else if (trangthai.Equals("Đang dọn phòng"))
            {
                tableLayoutPanel1.BackColor = Color.Yellow;
                tableLayoutPanel1.ForeColor = Color.Black;
                btnCheckIn.Visible = false;
                btnCheckOut.Visible = false;
                btnDonPhongConTrong.Visible = false;
                btnHuyDonPhongConTrong.Visible = true;
                btnDonPhongDangSuDung.Visible = false;
                btnHuyDonPhongDangSuDung.Visible = false;
            }
            else if (trangthai.Equals("Dọn phòng đang dùng"))
            {
                tableLayoutPanel1.BackColor = Color.Yellow;
                tableLayoutPanel1.ForeColor = Color.Black;
                btnCheckIn.Visible = false;
                btnCheckOut.Visible = false;
                btnDonPhongConTrong.Visible = false;
                btnHuyDonPhongConTrong.Visible = false;
                btnDonPhongDangSuDung.Visible = false;
                btnHuyDonPhongDangSuDung.Visible = true;
            }
            btnDonPhongConTrong.Click += BtnDonPhongConTrong_Click;
            btnHuyDonPhongConTrong.Click += BtnHuyDonPhongConTrong_Click;
            btnDonPhongDangSuDung.Click += BtnDonPhongDangSuDung_Click;
            btnHuyDonPhongDangSuDung.Click += BtnHuyDonPhongDangSuDung_Click;
        }

        private void BtnHuyDonPhongDangSuDung_Click(object sender, EventArgs e)
        {
            phongBLL.UpdatePhongTrangThai(id_phong, "Đang sử dụng");
        }

        private void BtnDonPhongDangSuDung_Click(object sender, EventArgs e)
        {
            phongBLL.UpdatePhongTrangThai(id_phong, "Dọn phòng đang dùng");
        }

        private void BtnHuyDonPhongConTrong_Click(object sender, EventArgs e)
        {
            phongBLL.UpdatePhongTrangThai(id_phong, "Còn trống");
        }

        private void BtnDonPhongConTrong_Click(object sender, EventArgs e)
        {
            phongBLL.UpdatePhongTrangThai(id_phong, "Đang dọn phòng");
        }

        private Color borderColor;

        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }


        //phongBLL.UpdatePhongTrangThai(id_phong, "Dọn phòng đang dùng");
        //phongBLL.UpdatePhongTrangThai(id_phong, "Đang sử dụng");
        //phongBLL.UpdatePhongTrangThai(id_phong, "Đang dọn phòng");
        //phongBLL.UpdatePhongTrangThai(id_phong, "Còn trống");

        
    }
}
