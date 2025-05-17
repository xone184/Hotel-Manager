using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    public class ThongKeDatPhongBLL
    {
        readonly QLKSDataContext context;
        public ThongKeDatPhongBLL()
        {
            context = new QLKSDataContext();
        }
        public List<HoaDonDTO> GetHoaDonList()
        {
            try
            {
                var hoadonList = (from p in context.datphongs
                                  where p.trang_thai == "Đã thanh toán"
                                  select new HoaDonDTO
                                  {
                                      IdDatPhong = p.id_datphong,
                                      IdNhanVien = p.id_nhanvien,
                                      IdKhachHang = p.id_khachhang,
                                      IdPhong = p.id_phong,
                                      CheckIn = p.check_in,
                                      CheckOut = p.check_out,
                                      DatCoc = (double)p.dat_coc,
                                      TienPhong = (double)p.tien_phong,
                                      PhuThuCheckIn = (double)p.phu_thu_checkin,
                                      PhuThuCheckOut = (double)p.phu_thu_checkout,
                                      TongTienDichVu = (double)p.tong_tien_dv,
                                      TongTienThucPham = (double)p.tong_tien_tb,
                                      TongTienHoaDon = (double)p.tong_tien_hoa_don,
                                      TongTien = (double)p.tong_tien,
                                      SoNguoiO = (int)p.so_nguoi_o,
                                      Loai = p.loai,
                                      TrangThai = p.trang_thai
                                  }).ToList();

                return hoadonList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public int SoLuongHoaDonTheoThang(int thang)
        {
            int count = context.datphongs
                    .Where(dp => dp.check_in.Month == thang)
                    .Count();
            return count;
        }
        public decimal TongTienTheoThang(int nam)
        {
            decimal totalRevenue = context.datphongs
                    .Where(dp => dp.check_in.Month == nam && dp.trang_thai == "Đã thanh toán")
                    .Sum(dp => (decimal?)dp.tong_tien_hoa_don) ?? 0;

            return totalRevenue;
        }
        public List<DatPhongTheoThang> LayPhongDuocDatNhieuHon1TheoThang(int month)
        {
            try
            {
                var result = from dp in context.datphongs
                             where dp.check_in.Month == month
                             group dp by dp.id_phong into g
                             where g.Count() > 1
                             select new DatPhongTheoThang
                             {
                                 RoomId = g.Key,
                                 TotalBookings = g.Count()
                             };

                return result.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw ex;
            }
        }
        public int SoLuongHoaDonTheoQuy(int quy)
        {
            int result = 0;

            try
            {
                result = context.datphongs
                    .Where(dp => dp.check_in.Month >= (quy - 1) * 3 + 1 && dp.check_in.Month <= quy * 3)
                    .Count();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return result;
        }
        public decimal TongTienTheoQuy(int quy)
        {
            decimal totalRevenue = context.datphongs
                    .Where(dp => dp.check_in.Month >= (quy - 1) * 3 + 1 && dp.check_in.Month <= quy * 3 && dp.trang_thai == "Đã thanh toán")
                    .Sum(dp => (decimal?)dp.tong_tien_hoa_don) ?? 0;

            return totalRevenue;
        }
        public List<DatPhongTheoThang> LayPhongDuocDatNhieuHon1TheoQuy(int quy)
        {
            try
            {
                var result = from dp in context.datphongs
                             let quarter = (dp.check_in.Month - 1) / 3 + 1
                             where quarter == quy
                             group dp by dp.id_phong into g
                             where g.Count() > 1
                             select new DatPhongTheoThang
                             {
                                 RoomId = g.Key,
                                 TotalBookings = g.Count()
                             };

                return result.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw ex;
            }
        }
        public int SoLuongHoaDonTheoNam(int nam)
        {
            int count = context.datphongs
                    .Where(dp => dp.check_in.Year == nam)
                    .Count();
            return count;
        }
        public decimal TongTienTheoNam(int nam)
        {
            decimal totalRevenue = context.datphongs
                    .Where(dp => dp.check_in.Year == nam && dp.trang_thai == "Đã thanh toán")
                    .Sum(dp => (decimal?)dp.tong_tien_hoa_don) ?? 0;

            return totalRevenue;
        }
        public List<DatPhongTheoThang> LayPhongDuocDatNhieuHon1TheoNam(int nam)
        {
            try
            {
                var result = from dp in context.datphongs
                             where dp.check_in.Year == nam
                             group dp by dp.id_phong into g
                             where g.Count() > 1
                             select new DatPhongTheoThang
                             {
                                 RoomId = g.Key,
                                 TotalBookings = g.Count()
                             };

                return result.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw ex;
            }
        }
    }
}
