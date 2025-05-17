using AllControl;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.UI.WebControls;
using System.Windows.Forms;
using DTO;

namespace HotelManagementProject
{
    public partial class FrmMain : Form
    {
        PhongBLL phongBLL;

        RoomPanel panelroom;
        private Timer opacityTimer = new Timer();

        public static string idphongfrmMain, trangthaifrmMain, tennvfrmMain;

        public FrmMain()
        {
            InitializeComponent();
            InitializeBtnFromLabel();
            phongBLL = new PhongBLL();
            label4.Text = frmLogin.tentaikhoan;
            DesignLayoutFormMain();
            DesignLayoutFormMain_Layout_DangSuDung();
            DesignLayoutFormMain_Layout_ConTrong();
            DesignLayoutFormMain_Layout_DangDonDep();

            DesignLayoutPanel_Tang1();
            DesignLayoutPanel_Tang2();
            DesignLayoutPanel_Tang3();
            this.Opacity = 0;
            opacityTimer.Interval = 5;
            opacityTimer.Tick += new EventHandler(OnTimerTick);
            opacityTimer.Start();
            if (frmLogin.quyen.Equals("staff"))
            {
                label5.Text = "Nhân Viên";
                label15.Visible = false;
                btnQLHoaDon.Visible = false;
                btnQLNhanVien.Visible = false;
                btnQLQuyen.Visible = false;
                btnThongKeDoanhThu.Visible = false;
            }
            if (frmLogin.quyen.Equals("admin"))
            {
                label5.Text = "Quản Lý";
            }    
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (this.Opacity < 1.0)
                this.Opacity += 0.1;
            else
                opacityTimer.Stop();
        }

        public void InitializeBtnFromLabel()
        {
            //--------------------------------------------------
            btnXemDonDatPhong.MouseEnter += (sender, e) =>
            {
                btnXemDonDatPhong.BackColor = Color.DarkGreen;
            };
            btnXemDonDatPhong.MouseLeave += (sender, e) =>
            {
                btnXemDonDatPhong.BackColor = Color.Green;
            };
            //--------------------------------------------------
            btnQLKhachHang.MouseEnter += (sender, e) =>
            {
                btnQLKhachHang.BackColor = Color.DarkGreen;
            };
            btnQLKhachHang.MouseLeave += (sender, e) =>
            {
                btnQLKhachHang.BackColor = Color.Green;
            };
            //--------------------------------------------------
            btnQLDichVu.MouseEnter += (sender, e) =>
            {
                btnQLDichVu.BackColor = Color.DarkGreen;
            };
            btnQLDichVu.MouseLeave += (sender, e) =>
            {
                btnQLDichVu.BackColor = Color.Green;
            };
            //--------------------------------------------------
            btnQLThietBi.MouseEnter += (sender, e) =>
            {
                btnQLThietBi.BackColor = Color.DarkGreen;
            };
            btnQLThietBi.MouseLeave += (sender, e) =>
            {
                btnQLThietBi.BackColor = Color.Green;
            };
            //--------------------------------------------------
            btnQLPhong.MouseEnter += (sender, e) =>
            {
                btnQLPhong.BackColor = Color.DarkGreen;
            };
            btnQLPhong.MouseLeave += (sender, e) =>
            {
                btnQLPhong.BackColor = Color.Green;
            };
            //--------------------------------------------------
            btnQLHoaDon.MouseEnter += (sender, e) =>
            {
                btnQLHoaDon.BackColor = Color.DarkGreen;
            };
            btnQLHoaDon.MouseLeave += (sender, e) =>
            {
                btnQLHoaDon.BackColor = Color.Green;
            };
            //--------------------------------------------------
            btnQLNhanVien.MouseEnter += (sender, e) =>
            {
                btnQLNhanVien.BackColor = Color.DarkGreen;
            };
            btnQLNhanVien.MouseLeave += (sender, e) =>
            {
                btnQLNhanVien.BackColor = Color.Green;
            };
            //--------------------------------------------------
            btnQLQuyen.MouseEnter += (sender, e) =>
            {
                btnQLQuyen.BackColor = Color.DarkGreen;
            };
            btnQLQuyen.MouseLeave += (sender, e) =>
            {
                btnQLQuyen.BackColor = Color.Green;
            };
            //--------------------------------------------------
            btnThongKeDoanhThu.MouseEnter += (sender, e) =>
            {
                btnThongKeDoanhThu.BackColor = Color.DarkGreen;
            };
            btnThongKeDoanhThu.MouseLeave += (sender, e) =>
            {
                btnThongKeDoanhThu.BackColor = Color.Green;
            };
            //--------------------------------------------------
            btnDoiMatKhau.MouseEnter += (sender, e) =>
            {
                btnDoiMatKhau.BackColor = Color.DarkGreen;
            };
            btnDoiMatKhau.MouseLeave += (sender, e) =>
            {
                btnDoiMatKhau.BackColor = Color.Green;
            };
            //--------------------------------------------------
            btnThoat.MouseEnter += (sender, e) =>
            {
                btnThoat.BackColor = Color.DarkGreen;
            };
            btnThoat.MouseLeave += (sender, e) =>
            {
                btnThoat.BackColor = Color.Green;
            };

        }

        string str;
        private void DesignLayoutFormMain()
        {
            List<PhongDTO> phongList = new List<PhongDTO>();
            phongList = phongBLL.GetPhongListCoTenLoaiPhong();
            flowLayoutPanel_All.AutoScroll = true;

            foreach (PhongDTO phong in phongList)
            {
                str = phong.TenPhong;
                string idphong = phong.IdPhong;
                string tenphong = phong.TenPhong.ToUpper();
                string loaiphong = phong.TenLoaiPhong;
                string sotang = phong.SoTang.ToString();
                string trangthai = phong.TrangThai;
                panelroom = new RoomPanel(tenphong, sotang, loaiphong, trangthai, idphong);
                flowLayoutPanel_All.Controls.Add(panelroom);
                Button btn3 = panelroom.Controls.Find("btnDonPhongConTrong", true).FirstOrDefault() as Button;
                if (btn3 != null)
                    btn3.Click += btn_Click;
                Button btn4 = panelroom.Controls.Find("btnHuyDonPhongConTrong", true).FirstOrDefault() as Button;
                if (btn4 != null)
                    btn4.Click += btn_Click;
                Button btn5 = panelroom.Controls.Find("btnCheckIn", true).FirstOrDefault() as Button;
                if (btn5 != null)
                    btn5.Click += (sender, e) =>
                    {
                        idphongfrmMain = idphong;
                        trangthaifrmMain = trangthai;
                        frmBooking frm = new frmBooking();
                        frm.Show();
                        this.Visible = false;
                        //MessageBox.Show(idphong);
                    };
                Button btn6 = panelroom.Controls.Find("btnCheckOut", true).FirstOrDefault() as Button;
                if (btn6 != null)
                    btn6.Click += (sender, e) =>
                    {
                        idphongfrmMain = idphong;
                        trangthaifrmMain = trangthai;
                        frmBooking frm = new frmBooking();
                        frm.Show();
                        this.Visible = false;
                        //MessageBox.Show(idphong);
                    };
                Button btn7 = panelroom.Controls.Find("btnDonPhongDangSuDung", true).FirstOrDefault() as Button;
                if (btn7 != null)
                    btn7.Click += btn_Click;
                Button btn8 = panelroom.Controls.Find("btnHuyDonPhongDangSuDung", true).FirstOrDefault() as Button;
                if (btn8 != null)
                    btn8.Click += btn_Click;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Visible = false;
                Program.loginForm = new frmLogin();
                Program.loginForm.Show();
            }
        }

        private void btnQLKhachHang_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.customerForm = new frmCustomer();
            Program.customerForm.Show();
        }

        private void btnQLDichVu_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.serviceForm = new frmService();
            Program.serviceForm.Show();
        }

        private void btnQLThietBi_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.deviceForm = new frmDevice();
            Program.deviceForm.Show();
        }

        private void btnQLPhong_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.roomForm = new frmRoom();
            Program.roomForm.Show();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            flowLayoutPanel_All.Visible = false;
            flowLayoutPanel_DangDonDep.Visible = true;
            flowLayoutPanel_DangSuDung.Visible = false;
            flowLayoutPanel_ConTrong.Visible = false;
            flowLayoutPanel_All.Visible = false;
            panel_Tang1.Visible = false;
            panel_Tang2.Visible = false;
            panel_Tang3.Visible = false;

        }
        private void DesignLayoutFormMain_Layout_DangDonDep()
        {
            List<PhongDTO> phongList = new List<PhongDTO>();
            phongList = phongBLL.GetPhongListCoTenLoaiPhongTheoTrangThai("Đang dọn phòng");
            flowLayoutPanel_DangDonDep.AutoScroll = true;

            foreach (PhongDTO phong in phongList)
            {
                str = phong.TenPhong;
                string idphong = phong.IdPhong;
                string tenphong = phong.TenPhong.ToUpper();
                string loaiphong = phong.TenLoaiPhong;
                string sotang = phong.SoTang.ToString();
                string trangthai = phong.TrangThai;
                panelroom = new RoomPanel(tenphong, sotang, loaiphong, trangthai, idphong);
                flowLayoutPanel_DangDonDep.Controls.Add(panelroom);
                Button btn3 = panelroom.Controls.Find("btnDonPhongConTrong", true).FirstOrDefault() as Button;
                if (btn3 != null)
                    btn3.Click += btn_Click;
                Button btn4 = panelroom.Controls.Find("btnHuyDonPhongConTrong", true).FirstOrDefault() as Button;
                if (btn4 != null)
                    btn4.Click += btn_Click;
                Button btn5 = panelroom.Controls.Find("btnCheckIn", true).FirstOrDefault() as Button;
                if (btn5 != null)
                    btn5.Click += (sender, e) =>
                    {
                        idphongfrmMain = idphong;
                        frmBooking frm = new frmBooking();
                        frm.Show();
                        this.Visible = false;
                        //MessageBox.Show(idphong);
                    };
                Button btn6 = panelroom.Controls.Find("btnCheckOut", true).FirstOrDefault() as Button;
                if (btn6 != null)
                    btn6.Click += (sender, e) =>
                    {
                        idphongfrmMain = idphong;
                        trangthaifrmMain = trangthai;
                        frmBooking frm = new frmBooking();
                        frm.Show();
                        this.Visible = false;
                        //MessageBox.Show(idphong);
                    };
                Button btn7 = panelroom.Controls.Find("btnDonPhongDangSuDung", true).FirstOrDefault() as Button;
                if (btn7 != null)
                    btn7.Click += btn_Click;
                Button btn8 = panelroom.Controls.Find("btnHuyDonPhongDangSuDung", true).FirstOrDefault() as Button;
                if (btn8 != null)
                    btn8.Click += btn_Click;
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            flowLayoutPanel_All.Visible = false;
            flowLayoutPanel_DangDonDep.Visible = false;
            flowLayoutPanel_DangSuDung.Visible = true;
            flowLayoutPanel_ConTrong.Visible = false;
            flowLayoutPanel_All.Visible = false;
            panel_Tang1.Visible = false;
            panel_Tang2.Visible = false;
            panel_Tang3.Visible = false;
        }

        private void DesignLayoutFormMain_Layout_DangSuDung()
        {
            List<PhongDTO> phongList = new List<PhongDTO>();
            phongList = phongBLL.GetPhongListCoTenLoaiPhongTheoTrangThai("Đang sử dụng");
            flowLayoutPanel_DangSuDung.AutoScroll = true;

            foreach (PhongDTO phong in phongList)
            {
                str = phong.TenPhong;
                string idphong = phong.IdPhong;
                string tenphong = phong.TenPhong.ToUpper();
                string loaiphong = phong.TenLoaiPhong;
                string sotang = phong.SoTang.ToString();
                string trangthai = phong.TrangThai;
                panelroom = new RoomPanel(tenphong, sotang, loaiphong, trangthai, idphong);
                flowLayoutPanel_DangSuDung.Controls.Add(panelroom);
                Button btn3 = panelroom.Controls.Find("btnDonPhongConTrong", true).FirstOrDefault() as Button;
                if (btn3 != null)
                    btn3.Click += btn_Click;
                Button btn4 = panelroom.Controls.Find("btnHuyDonPhongConTrong", true).FirstOrDefault() as Button;
                if (btn4 != null)
                    btn4.Click += btn_Click;
                Button btn5 = panelroom.Controls.Find("btnCheckIn", true).FirstOrDefault() as Button;
                if (btn5 != null)
                    btn5.Click += (sender, e) =>
                    {
                        idphongfrmMain = idphong;
                        frmBooking frm = new frmBooking();
                        frm.Show();
                        this.Visible = false;
                        //MessageBox.Show(idphong);
                    };
                Button btn6 = panelroom.Controls.Find("btnCheckOut", true).FirstOrDefault() as Button;
                if (btn6 != null)
                    btn6.Click += (sender, e) =>
                    {
                        idphongfrmMain = idphong;
                        trangthaifrmMain = trangthai;
                        frmBooking frm = new frmBooking();
                        frm.Show();
                        this.Visible = false;
                        //MessageBox.Show(idphong);
                    };
                Button btn7 = panelroom.Controls.Find("btnDonPhongDangSuDung", true).FirstOrDefault() as Button;
                if (btn7 != null)
                    btn7.Click += btn_Click;
                Button btn8 = panelroom.Controls.Find("btnHuyDonPhongDangSuDung", true).FirstOrDefault() as Button;
                if (btn8 != null)
                    btn8.Click += btn_Click;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            flowLayoutPanel_All.Visible = false;
            flowLayoutPanel_DangDonDep.Visible = false;
            flowLayoutPanel_DangSuDung.Visible = false;
            flowLayoutPanel_ConTrong.Visible = true;
            flowLayoutPanel_All.Visible = false;
            panel_Tang1.Visible = false;
            panel_Tang2.Visible = false;
            panel_Tang3.Visible = false;

        }
        private void DesignLayoutFormMain_Layout_ConTrong()
        {
            List<PhongDTO> phongList = new List<PhongDTO>();
            phongList = phongBLL.GetPhongListCoTenLoaiPhongTheoTrangThai("Còn trống");
            flowLayoutPanel_ConTrong.AutoScroll = true;

            foreach (PhongDTO phong in phongList)
            {
                str = phong.TenPhong;
                string idphong = phong.IdPhong;
                string tenphong = phong.TenPhong.ToUpper();
                string loaiphong = phong.TenLoaiPhong;
                string sotang = phong.SoTang.ToString();
                string trangthai = phong.TrangThai;
                panelroom = new RoomPanel(tenphong, sotang, loaiphong, trangthai, idphong);
                flowLayoutPanel_ConTrong.Controls.Add(panelroom);
                Button btn3 = panelroom.Controls.Find("btnDonPhongConTrong", true).FirstOrDefault() as Button;
                if (btn3 != null)
                    btn3.Click += btn_Click;
                Button btn4 = panelroom.Controls.Find("btnHuyDonPhongConTrong", true).FirstOrDefault() as Button;
                if (btn4 != null)
                    btn4.Click += btn_Click;
                Button btn5 = panelroom.Controls.Find("btnCheckIn", true).FirstOrDefault() as Button;
                if (btn5 != null)
                    btn5.Click += (sender, e) =>
                    {
                        idphongfrmMain = idphong;
                        frmBooking frm = new frmBooking();
                        frm.Show();
                        this.Visible = false;
                        //MessageBox.Show(idphong);
                    };
                Button btn6 = panelroom.Controls.Find("btnCheckOut", true).FirstOrDefault() as Button;
                if (btn6 != null)
                    btn6.Click += (sender, e) =>
                    {
                        idphongfrmMain = idphong;
                        trangthaifrmMain = trangthai;
                        frmBooking frm = new frmBooking();
                        frm.Show();
                        this.Visible = false;
                        //MessageBox.Show(idphong);
                    };
                Button btn7 = panelroom.Controls.Find("btnDonPhongDangSuDung", true).FirstOrDefault() as Button;
                if (btn7 != null)
                    btn7.Click += btn_Click;
                Button btn8 = panelroom.Controls.Find("btnHuyDonPhongDangSuDung", true).FirstOrDefault() as Button;
                if (btn8 != null)
                    btn8.Click += btn_Click;
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {
            flowLayoutPanel_All.Visible = false;
            flowLayoutPanel_DangDonDep.Visible = false;
            flowLayoutPanel_DangSuDung.Visible = false;
            flowLayoutPanel_ConTrong.Visible = false;
            flowLayoutPanel_All.Visible = true;
            panel_Tang1.Visible = false;
            panel_Tang2.Visible = false;
            panel_Tang3.Visible = false;
        }

        private void label31_Click(object sender, EventArgs e)
        {
            flowLayoutPanel_All.Visible = false;
            flowLayoutPanel_DangDonDep.Visible = false;
            flowLayoutPanel_DangSuDung.Visible = false;
            flowLayoutPanel_ConTrong.Visible = false;
            flowLayoutPanel_All.Visible = false;
            panel_Tang1.Visible = true;
            panel_Tang2.Visible = false;
            panel_Tang3.Visible = false;
        }

        private void DesignLayoutPanel_Tang1()
        {
            List<PhongDTO> phongList = new List<PhongDTO>();
            phongList = phongBLL.GetPhongListCoTenLoaiPhongTheoSoTang(1);
            flowLayoutPanel_Tang1.AutoScroll = true;

            foreach (PhongDTO phong in phongList)
            {
                str = phong.TenPhong;
                string idphong = phong.IdPhong;
                string tenphong = phong.TenPhong.ToUpper();
                string loaiphong = phong.TenLoaiPhong;
                string sotang = phong.SoTang.ToString();
                string trangthai = phong.TrangThai;
                panelroom = new RoomPanel(tenphong, sotang, loaiphong, trangthai, idphong);
                flowLayoutPanel_Tang1.Controls.Add(panelroom);
                Button btn3 = panelroom.Controls.Find("btnDonPhongConTrong", true).FirstOrDefault() as Button;
                if (btn3 != null)
                    btn3.Click += btn_Click;
                Button btn4 = panelroom.Controls.Find("btnHuyDonPhongConTrong", true).FirstOrDefault() as Button;
                if (btn4 != null)
                    btn4.Click += btn_Click;
                Button btn5 = panelroom.Controls.Find("btnCheckIn", true).FirstOrDefault() as Button;
                if (btn5 != null)
                    btn5.Click += (sender, e) =>
                    {
                        idphongfrmMain = idphong;
                        frmBooking frm = new frmBooking();
                        frm.Show();
                        this.Visible = false;
                        //MessageBox.Show(idphong);
                    };
                Button btn6 = panelroom.Controls.Find("btnCheckOut", true).FirstOrDefault() as Button;
                if (btn6 != null)
                    btn6.Click += (sender, e) =>
                    {
                        idphongfrmMain = idphong;
                        trangthaifrmMain = trangthai;
                        frmBooking frm = new frmBooking();
                        frm.Show();
                        this.Visible = false;
                        //MessageBox.Show(idphong);
                    };
                Button btn7 = panelroom.Controls.Find("btnDonPhongDangSuDung", true).FirstOrDefault() as Button;
                if (btn7 != null)
                    btn7.Click += btn_Click;
                Button btn8 = panelroom.Controls.Find("btnHuyDonPhongDangSuDung", true).FirstOrDefault() as Button;
                if (btn8 != null)
                    btn8.Click += btn_Click;
            }
        }

        private void DesignLayoutPanel_Tang2()
        {
            List<PhongDTO> phongList = new List<PhongDTO>();
            phongList = phongBLL.GetPhongListCoTenLoaiPhongTheoSoTang(2);
            flowLayoutPanel_Tang2.AutoScroll = true;

            foreach (PhongDTO phong in phongList)
            {
                str = phong.TenPhong;
                string idphong = phong.IdPhong;
                string tenphong = phong.TenPhong.ToUpper();
                string loaiphong = phong.TenLoaiPhong;
                string sotang = phong.SoTang.ToString();
                string trangthai = phong.TrangThai;
                panelroom = new RoomPanel(tenphong, sotang, loaiphong, trangthai, idphong);
                flowLayoutPanel_Tang2.Controls.Add(panelroom);
                Button btn3 = panelroom.Controls.Find("btnDonPhongConTrong", true).FirstOrDefault() as Button;
                if (btn3 != null)
                    btn3.Click += btn_Click;
                Button btn4 = panelroom.Controls.Find("btnHuyDonPhongConTrong", true).FirstOrDefault() as Button;
                if (btn4 != null)
                    btn4.Click += btn_Click;
                Button btn5 = panelroom.Controls.Find("btnCheckIn", true).FirstOrDefault() as Button;
                if (btn5 != null)
                    btn5.Click += (sender, e) =>
                    {
                        idphongfrmMain = idphong;
                        frmBooking frm = new frmBooking();
                        frm.Show();
                        this.Visible = false;
                        //MessageBox.Show(idphong);
                    };
                Button btn6 = panelroom.Controls.Find("btnCheckOut", true).FirstOrDefault() as Button;
                if (btn6 != null)
                    btn6.Click += (sender, e) =>
                    {
                        idphongfrmMain = idphong;
                        trangthaifrmMain = trangthai;
                        frmBooking frm = new frmBooking();
                        frm.Show();
                        this.Visible = false;
                        //MessageBox.Show(idphong);
                    };
                Button btn7 = panelroom.Controls.Find("btnDonPhongDangSuDung", true).FirstOrDefault() as Button;
                if (btn7 != null)
                    btn7.Click += btn_Click;
                Button btn8 = panelroom.Controls.Find("btnHuyDonPhongDangSuDung", true).FirstOrDefault() as Button;
                if (btn8 != null)
                    btn8.Click += btn_Click;
            }
        }

        private void label29_Click_1(object sender, EventArgs e)
        {
            flowLayoutPanel_All.Visible = false;
            flowLayoutPanel_DangDonDep.Visible = false;
            flowLayoutPanel_DangSuDung.Visible = false;
            flowLayoutPanel_ConTrong.Visible = false;
            flowLayoutPanel_All.Visible = false;
            panel_Tang1.Visible = false;
            panel_Tang2.Visible = true;
            panel_Tang3.Visible = false;
        }

        private void label27_Click(object sender, EventArgs e)
        {
            flowLayoutPanel_All.Visible = false;
            flowLayoutPanel_DangDonDep.Visible = false;
            flowLayoutPanel_DangSuDung.Visible = false;
            flowLayoutPanel_ConTrong.Visible = false;
            flowLayoutPanel_All.Visible = false;
            panel_Tang1.Visible = false;
            panel_Tang2.Visible = false;
            panel_Tang3.Visible = true;
        }
        private void DesignLayoutPanel_Tang3()
        {
            List<PhongDTO> phongList = new List<PhongDTO>();
            phongList = phongBLL.GetPhongListCoTenLoaiPhongTheoSoTang(3);
            flowLayoutPanel_Tang3.AutoScroll = true;

            foreach (PhongDTO phong in phongList)
            {
                str = phong.TenPhong;
                string idphong = phong.IdPhong;
                string tenphong = phong.TenPhong.ToUpper();
                string loaiphong = phong.TenLoaiPhong;
                string sotang = phong.SoTang.ToString();
                string trangthai = phong.TrangThai;
                panelroom = new RoomPanel(tenphong, sotang, loaiphong, trangthai, idphong);
                flowLayoutPanel_Tang3.Controls.Add(panelroom);
                Button btn3 = panelroom.Controls.Find("btnDonPhongConTrong", true).FirstOrDefault() as Button;
                if (btn3 != null)
                    btn3.Click += btn_Click;
                Button btn4 = panelroom.Controls.Find("btnHuyDonPhongConTrong", true).FirstOrDefault() as Button;
                if (btn4 != null)
                    btn4.Click += btn_Click;
                Button btn5 = panelroom.Controls.Find("btnCheckIn", true).FirstOrDefault() as Button;
                if (btn5 != null)
                    btn5.Click += (sender, e) =>
                    {
                        idphongfrmMain = idphong;
                        frmBooking frm = new frmBooking();
                        frm.Show();
                        this.Visible = false;
                        //MessageBox.Show(idphong);
                    };
                Button btn6 = panelroom.Controls.Find("btnCheckOut", true).FirstOrDefault() as Button;
                if (btn6 != null)
                    btn6.Click += (sender, e) =>
                    {
                        idphongfrmMain = idphong;
                        trangthaifrmMain = trangthai;
                        frmBooking frm = new frmBooking();
                        frm.Show();
                        this.Visible = false;
                        //MessageBox.Show(idphong);
                    };
                Button btn7 = panelroom.Controls.Find("btnDonPhongDangSuDung", true).FirstOrDefault() as Button;
                if (btn7 != null)
                    btn7.Click += btn_Click;
                Button btn8 = panelroom.Controls.Find("btnHuyDonPhongDangSuDung", true).FirstOrDefault() as Button;
                if (btn8 != null)
                    btn8.Click += btn_Click;
            }
        }

        private void btnQLHoaDon_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.billForm = new frmBill();
            Program.billForm.Show();
        }

        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.staffForm = new frmStaff();
            Program.staffForm.Show();
        }

        private void btnThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            tennvfrmMain = label4.Text;
            frmChooseForStatistic frm = new frmChooseForStatistic();
            frm.ShowDialog();
        }

        private void btnXemDonDatPhong_Click(object sender, EventArgs e)
        {
            Program.bookingOnlineForm = new frmBookingOnline();
            Program.bookingOnlineForm.ShowDialog();
        }

        private void btnQLQuyen_Click(object sender, EventArgs e)
        {
            Program.accountForm = new frmAccount();
            Program.accountForm.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel_Tang3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            Program.changePasswordForm = new frmChangePassword();
            Program.changePasswordForm.ShowDialog();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.mainForm = new FrmMain();
            Program.mainForm.Show();
        }

        //private void btnHuyDonPhongDangSuDung_Click(object sender, EventArgs e)
        //{
        //    this.Visible = false;
        //    Program.mainForm = new FrmMain();
        //    Program.mainForm.Show();
        //}

        //private void btnDonPhongDangSuDung_Click(object sender, EventArgs e)
        //{
        //    this.Visible = false;
        //    Program.mainForm = new FrmMain();
        //    Program.mainForm.Show();
        //}

        //private void btnHuyDonPhong_Click(object sender, EventArgs e)
        //{
        //    this.Visible = false;
        //    Program.mainForm = new FrmMain();
        //    Program.mainForm.Show();
        //}

        //private void btnDonPhong_Click(object sender, EventArgs e)
        //{
        //    this.Visible = false;
        //    Program.mainForm = new FrmMain();
        //    Program.mainForm.Show();
        //}
    }
}
