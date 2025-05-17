using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    public class DatPhongOnlineBLL
    {
        QLKSDataContext context;
        public DatPhongOnlineBLL()
        {
            context = new QLKSDataContext();
        }
        public List<DatPhongOnlineDTO> LoadData()
        {
            var query = from datphongonline in context.datphongonlines
                        select new DatPhongOnlineDTO
                        {
                            id = datphongonline.id_datphong,
                            tenkh = datphongonline.ten_khachhang,
                            ngaysinh = DateTime.Parse(datphongonline.ngay_sinh.ToString()).ToString("dd/MM/yyyy"),
                            diachi = datphongonline.dia_chi,
                            sdt = datphongonline.sdt,
                            cmnd = datphongonline.cmnd,
                            gioitinh = datphongonline.gioi_tinh
                        };
            return query.ToList();
        }
        public string getIdPhong(int id)
        {
            var query = from dp in context.datphongonlines where dp.id_datphong == id select dp.id_phong;
            return query.FirstOrDefault().ToString();
        }
        public string getSoNguoiO(int id)
        {
            var query = from dp in context.datphongonlines where dp.id_datphong == id select dp.so_nguoi_o;
            return query.FirstOrDefault().ToString();
        }
        public string getCheckIn(int id)
        {
            var query = from dp in context.datphongonlines where dp.id_datphong == id select dp.check_in;
            return query.FirstOrDefault().ToString();
        }
        public string getCheckOut(int id)
        {
            var query = from dp in context.datphongonlines where dp.id_datphong == id select dp.check_out;
            return query.FirstOrDefault().ToString();
        }
        public string getIdKhachHang(string cccd)
        {
            var query = from dp in context.khachhangs where dp.cmnd == cccd.Trim() select dp.id_khachhang;
            return query.FirstOrDefault().ToString();
        }
        public string getIdNhanVien(string tentk)
        {
            var query = from tk in context.taikhoans where tk.ten_dang_nhap.Trim() == tentk select tk.id_nhanvien;
            var result = query.FirstOrDefault();
            return result != null ? result.ToString() : null;
        }
        public bool checkKhachHangTonTai(string cccd)
        {
            var query = context.khachhangs.FirstOrDefault(kh => kh.cmnd == cccd);
            if (query == null)
                return false;
            return true;
        }
        public void themKhachHang(string tenkh, DateTime ngaysinh, string diachi, string sdt, string cccd, string gioitinh)
        {
            context.Them_Khach_Hang(tenkh, ngaysinh, diachi, sdt, cccd, gioitinh);
            context.SubmitChanges();
        }
        public void checkInOnline(string idnv, string idkh, string idphong, DateTime checkin, DateTime checkout,
            int songuoio, string loai, double datcoc)
        {
            context.Dat_Phong(idnv, idkh, idphong, checkin, checkout, songuoio, loai, datcoc);
            context.SubmitChanges();
        }
        public decimal tinhTienDatCoc(string idPhong)
        {
            var query = from dp in context.datphongonlines
                        where dp.id_phong == idPhong
                        join ph in context.phongs on dp.id_phong equals ph.id_phong
                        select new
                        {
                            dp.check_in,
                            dp.check_out,
                            ph.gia
                        };

            var bookingInfo = query.FirstOrDefault();

            if (bookingInfo != null)
            {
                int numberOfDays = (bookingInfo.check_out - bookingInfo.check_in).Days;
                decimal totalAmount = (numberOfDays * bookingInfo.gia) / 2;
                return totalAmount;
            }
            else
                return 0;
        }
        public void UpdateTrangThaiPhong(string id)
        {
            context.Update_TrangThaiPhong_1(id);
            context.SubmitChanges();
        }
        public void DeleteDatPhongOnline(int id)
        {
            var bookingToDelete = context.datphongonlines.SingleOrDefault(dp => dp.id_datphong == id);

            if (bookingToDelete != null)
            {
                context.datphongonlines.DeleteOnSubmit(bookingToDelete);
                context.SubmitChanges();
            }
        }
    }
}
