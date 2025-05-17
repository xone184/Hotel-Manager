using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class KhachHangBLL
    {
        private QLKSDataContext _qLKSDataContext;
        public KhachHangBLL()
        {
            _qLKSDataContext = new QLKSDataContext();
        }
        public List<khachhang> GetKhachHangList()
        {
            try
            {
                var khachhangList = (from p in _qLKSDataContext.khachhangs select p).ToList();

                return khachhangList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<string> GetTenKhachHangList()
        {
            try
            {
                var tenKhachHangList = _qLKSDataContext.khachhangs
                    .Select(kh => kh.ten_khachhang)
                    .ToList();
                return tenKhachHangList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }


        public void XoaKhachHang(string id_khachhang)
        {
            var khachhangToRemove = _qLKSDataContext.khachhangs.SingleOrDefault(dv => dv.id_khachhang == id_khachhang);
            if (khachhangToRemove != null)
            {
                _qLKSDataContext.khachhangs.DeleteOnSubmit(khachhangToRemove);
                _qLKSDataContext.SubmitChanges();
            }
        }

        public void ThemKhachHang(string ten, DateTime ngaysinh, string diachi, string sdt, string cmnd, string gioitinh)
        {
            _qLKSDataContext.Them_Khach_Hang(ten, ngaysinh, diachi, sdt, cmnd, gioitinh);
            _qLKSDataContext.SubmitChanges();
        }

        public void CapNhatKhachHang(string id_khachhang, string ten, DateTime ngaysinh, string diachi, string sdt, string cmnd, string gioitinh)
        {
            var khachhangToUpdate = _qLKSDataContext.khachhangs.SingleOrDefault(kh => kh.id_khachhang == id_khachhang);
            if (khachhangToUpdate != null)
            {
                khachhangToUpdate.ten_khachhang = ten;
                khachhangToUpdate.ngay_sinh = ngaysinh;
                khachhangToUpdate.dia_chi = diachi;
                khachhangToUpdate.sdt = sdt;
                khachhangToUpdate.cmnd = cmnd;
                khachhangToUpdate.gioi_tinh = gioitinh;
                _qLKSDataContext.SubmitChanges();
            }
        }
        public List<khachhang> TimKiemKhachHang(string timkiem)
        {
            var query = from kh in _qLKSDataContext.khachhangs
                        where kh.id_khachhang == timkiem || kh.ten_khachhang == timkiem
                        select kh;

            return query.ToList();
        }
        public string GetTenKhachHangByCMND(string cmnd)
        {
            try
            {
                var tenKhachHang = (from kh in _qLKSDataContext.khachhangs
                                    where kh.cmnd == cmnd
                                    select kh.ten_khachhang).FirstOrDefault();
                return tenKhachHang;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public string GetIdKHByTen(string ten)
        {
            var sdt = (from kh in _qLKSDataContext.khachhangs
                       where kh.ten_khachhang == ten.Trim()
                       select kh.id_khachhang).FirstOrDefault();
            return sdt;
        }
        public DateTime GetNgaySinhByTen(string ten)
        {
            var ngaysinh = (from kh in _qLKSDataContext.khachhangs where kh.ten_khachhang == ten.Trim()
                                select kh.ngay_sinh).FirstOrDefault();
            return ngaysinh;
        }
        public string GetSdtByTen(string ten)
        {
            var sdt = (from kh in _qLKSDataContext.khachhangs
                                where kh.ten_khachhang == ten.Trim()
                                select kh.sdt).FirstOrDefault();
            return sdt;
        }
        public string GetCccdByTen(string ten)
        {
            var cccd = (from kh in _qLKSDataContext.khachhangs
                                where kh.ten_khachhang == ten.Trim()
                                select kh.cmnd).FirstOrDefault();
            return cccd;
        }
        public string GetGioiTinhByTen(string ten)
        {
            var gioitinh = (from kh in _qLKSDataContext.khachhangs
                        where kh.ten_khachhang == ten.Trim()
                        select kh.gioi_tinh).FirstOrDefault();
            return gioitinh;
        }

        public List<KhachHangDTO> GetHoaDonList_MaHoaDon(string id_DatPhong)
        {
            try
            {
                var hoadonList = (from p in _qLKSDataContext.khachhangs
                                  where p.id_khachhang == id_DatPhong
                                  select new KhachHangDTO
                                  {
                                      Id_KH = p.id_khachhang,
                                      Ten_KH = p.ten_khachhang,
                                      NgaySinh = p.ngay_sinh,
                                      diachi = p.dia_chi,
                                      sdt = p.sdt,
                                      cmnd = p.cmnd,
                                      gioitinh = p.gioi_tinh
                                  }).ToList();

                return hoadonList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<KhachHangDTO> GetHoaDonList_TenHoaDon(string id_DatPhong)
        {
            try
            {
                var hoadonList = (from p in _qLKSDataContext.khachhangs
                                  where p.ten_khachhang == id_DatPhong
                                  select new KhachHangDTO
                                  {
                                      Id_KH = p.id_khachhang,
                                      Ten_KH = p.ten_khachhang,
                                      NgaySinh = p.ngay_sinh,
                                      diachi = p.dia_chi,
                                      sdt = p.sdt,
                                      cmnd = p.cmnd,
                                      gioitinh = p.gioi_tinh
                                  }).ToList();

                return hoadonList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<KhachHangDTO> GetHoaDonList_sdtHoaDon(string id_DatPhong)
        {
            try
            {
                var hoadonList = (from p in _qLKSDataContext.khachhangs
                                  where p.sdt == id_DatPhong
                                  select new KhachHangDTO
                                  {
                                      Id_KH = p.id_khachhang,
                                      Ten_KH = p.ten_khachhang,
                                      NgaySinh = p.ngay_sinh,
                                      diachi = p.dia_chi,
                                      sdt = p.sdt,
                                      cmnd = p.cmnd,
                                      gioitinh = p.gioi_tinh
                                  }).ToList();

                return hoadonList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<KhachHangDTO> GetHoaDonList_CmndHoaDon(string id_DatPhong)
        {
            try
            {
                var hoadonList = (from p in _qLKSDataContext.khachhangs
                                  where p.cmnd == id_DatPhong
                                  select new KhachHangDTO
                                  {
                                      Id_KH = p.id_khachhang,
                                      Ten_KH = p.ten_khachhang,
                                      NgaySinh = p.ngay_sinh,
                                      diachi = p.dia_chi,
                                      sdt = p.sdt,
                                      cmnd = p.cmnd,
                                      gioitinh = p.gioi_tinh
                                  }).ToList();

                return hoadonList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

    }
}
