using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HoaDonBLL
    {
        private QLKSDataContext _qLKSDataContext;
        public HoaDonBLL()
        {
            _qLKSDataContext = new QLKSDataContext();
        }
        public List<HoaDonDTO> GetHoaDonList()
        {
            try
            {
                var hoadonList = (from p in _qLKSDataContext.datphongs
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

        public List<HoaDonDTO> GetHoaDonListTrangThai(string trangthai)
        {
            try
            {
                var hoadonList = (from p in _qLKSDataContext.datphongs
                                  where p.trang_thai == trangthai
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

        public List<HoaDonDTO> GetHoaDonList_MaHoaDon(string id_DatPhong)
        {
            try
            {
                var hoadonList = (from p in _qLKSDataContext.datphongs
                                  where p.id_datphong == id_DatPhong
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

        public List<HoaDonDTO> GetHoaDonList_TenKH(string tenKhachHang)
        {
            try
            {
                var hoadonList = (from p in _qLKSDataContext.datphongs
                                  join kh in _qLKSDataContext.khachhangs on p.id_khachhang equals kh.id_khachhang
                                  where kh.ten_khachhang == tenKhachHang
                                  select new HoaDonDTO
                                  {
                                      IdDatPhong = p.id_datphong,
                                      IdNhanVien = p.id_nhanvien,
                                      IdKhachHang = p.id_khachhang,
                                      IdPhong = p.id_phong,
                                      CheckIn = p.check_in,
                                      CheckOut = p.check_out,
                                      DatCoc = (float)p.dat_coc,
                                      TienPhong = (float)p.tien_phong,
                                      PhuThuCheckIn = (float)p.phu_thu_checkin,
                                      PhuThuCheckOut = (float)p.phu_thu_checkout,
                                      TongTienDichVu = (float)p.tong_tien_dv,
                                      TongTienThucPham = (float)p.tong_tien_tb,
                                      TongTienHoaDon = (float)p.tong_tien_hoa_don,
                                      TongTien = (float)p.tong_tien,
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

        public List<HoaDonDTO> GetHoaDonList_TenNV(string tenNhanVien)
        {
            try
            {
                var hoadonList = (from p in _qLKSDataContext.datphongs
                                  join nv in _qLKSDataContext.nhanviens on p.id_nhanvien equals nv.id_nhanvien
                                  where nv.ten_nhanvien == tenNhanVien
                                  select new HoaDonDTO
                                  {
                                      IdDatPhong = p.id_datphong,
                                      IdNhanVien = p.id_nhanvien,
                                      IdKhachHang = p.id_khachhang,
                                      IdPhong = p.id_phong,
                                      CheckIn = p.check_in,
                                      CheckOut = p.check_out,
                                      DatCoc = (float)p.dat_coc,
                                      TienPhong = (float)p.tien_phong,
                                      PhuThuCheckIn = (float)p.phu_thu_checkin,
                                      PhuThuCheckOut = (float)p.phu_thu_checkout,
                                      TongTienDichVu = (float)p.tong_tien_dv,
                                      TongTienThucPham = (float)p.tong_tien_tb,
                                      TongTienHoaDon = (float)p.tong_tien_hoa_don,
                                      TongTien = (float)p.tong_tien,
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

        public List<HoaDonDTO> GetHoaDonList_TenPhong(string tenPhong)
        {
            try
            {
                var hoadonList = (from p in _qLKSDataContext.datphongs
                                  join ph in _qLKSDataContext.phongs on p.id_phong equals ph.id_phong
                                  where ph.ten == tenPhong
                                  select new HoaDonDTO
                                  {
                                      IdDatPhong = p.id_datphong,
                                      IdNhanVien = p.id_nhanvien,
                                      IdKhachHang = p.id_khachhang,
                                      IdPhong = p.id_phong,
                                      CheckIn = p.check_in,
                                      CheckOut = p.check_out,
                                      DatCoc = (float)p.dat_coc,
                                      TienPhong = (float)p.tien_phong,
                                      PhuThuCheckIn = (float)p.phu_thu_checkin,
                                      PhuThuCheckOut = (float)p.phu_thu_checkout,
                                      TongTienDichVu = (float)p.tong_tien_dv,
                                      TongTienThucPham = (float)p.tong_tien_tb,
                                      TongTienHoaDon = (float)p.tong_tien_hoa_don,
                                      TongTien = (float)p.tong_tien,
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
        //KhachHang
        public string LayTenTuKhachHang(string id_KhachHang)
        {
            var khachhang = (from kh in _qLKSDataContext.khachhangs
                       where kh.id_khachhang ==id_KhachHang.Trim()
                       select kh.ten_khachhang).FirstOrDefault();
            return khachhang;
        }

        public DateTime LayNgaySinhTuKhachHang(string id_KhachHang)
        {
            var ngaysinh = (from kh in _qLKSDataContext.khachhangs
                             where kh.id_khachhang == id_KhachHang.Trim()
                             select kh.ngay_sinh).FirstOrDefault();
            return ngaysinh;
        }

        public string LayDiaChiTuKhachHang(string id_KhachHang)
        {
            var khachhang = (from kh in _qLKSDataContext.khachhangs
                             where kh.id_khachhang == id_KhachHang.Trim()
                             select kh.dia_chi).FirstOrDefault();
            return khachhang;
        }

        public string LaySDTTuKhachHang(string id_KhachHang)
        {
            var khachhang = (from kh in _qLKSDataContext.khachhangs
                             where kh.id_khachhang == id_KhachHang.Trim()
                             select kh.sdt).FirstOrDefault();
            return khachhang;
        }

        public string LayCMNDTuKhachHang(string id_KhachHang)
        {
            var khachhang = (from kh in _qLKSDataContext.khachhangs
                             where kh.id_khachhang == id_KhachHang.Trim()
                             select kh.cmnd).FirstOrDefault();
            return khachhang;
        }

        public string LayGioiTinhTuKhachHang(string id_KhachHang)
        {
            var khachhang = (from kh in _qLKSDataContext.khachhangs
                             where kh.id_khachhang == id_KhachHang.Trim()
                             select kh.gioi_tinh).FirstOrDefault();
            return khachhang;
        }
        //KhachHang

        //NhanVien
        public string LayTenTuNhanVien(string id_NhanVien)
        {
            var nhanvien = (from kh in _qLKSDataContext.nhanviens
                             where kh.id_nhanvien == id_NhanVien.Trim()
                             select kh.ten_nhanvien).FirstOrDefault();
            return nhanvien;
        }

        public DateTime LayNgaySinhTuNhanVien(string id_NhanVien)
        {
            var ngaysinh = (from kh in _qLKSDataContext.nhanviens
                            where kh.id_nhanvien == id_NhanVien.Trim()
                            select kh.ngay_sinh).FirstOrDefault();
            return ngaysinh;
        }

        public string LaySdtTuNhanVien(string id_NhanVien)
        {
            var nhanvien = (from kh in _qLKSDataContext.nhanviens
                            where kh.id_nhanvien == id_NhanVien.Trim()
                            select kh.sdt).FirstOrDefault();
            return nhanvien;
        }

        public string LayGioiTinhTuNhanVien(string id_NhanVien)
        {
            var nhanvien = (from kh in _qLKSDataContext.nhanviens
                            where kh.id_nhanvien == id_NhanVien.Trim()
                            select kh.gioi_tinh).FirstOrDefault();
            return nhanvien;
        }

        public string LayEmailTuNhanVien(string id_NhanVien)
        {
            var nhanvien = (from kh in _qLKSDataContext.nhanviens
                            where kh.id_nhanvien == id_NhanVien.Trim()
                            select kh.email).FirstOrDefault();
            return nhanvien;
        }
        //NhanVien

        //DichVu
        public List<ChiTietSuDungDichVu> LayDichVu(string id_datphong)
        {
            try
            {
                var hoadondichvuList = (from p in _qLKSDataContext.datphongs
                                        join ct in _qLKSDataContext.chitietsudungdvs on p.id_datphong equals ct.id_datphong
                                        join dv in _qLKSDataContext.dichvus on ct.id_dichvu equals dv.id_dichvu
                                        where p.id_datphong == id_datphong
                                        select new ChiTietSuDungDichVu
                                        {
                                            Iddatphong = p.id_datphong,
                                            Tendichvu = dv.ten_dichvu,
                                            Ngaythue = DateTime.Parse(ct.ngay_thue.ToString()),
                                            Soluong = (int)ct.so_luong,
                                            Tongtiendv = (float)ct.tong_tien_dv
                                        }).ToList();

                return hoadondichvuList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        //ThietBi
        public List<ChiTietSuDungThietBi> LayThietBi(string id_datphong)
        {
            try
            {
                var chitietthietbiList = (from p in _qLKSDataContext.datphongs
                                          join ct in _qLKSDataContext.chitietsudungtbs on p.id_datphong equals ct.id_datphong
                                          join tb in _qLKSDataContext.thietbis on ct.id_thietbi equals tb.id_thietbi
                                          where p.id_datphong == id_datphong
                                          select new ChiTietSuDungThietBi
                                          {
                                              Iddatphong = p.id_datphong,
                                              Tenthietbi = tb.ten_thietbi,
                                              Ngaythue = DateTime.Parse(ct.ngay_thue.ToString()),
                                              Soluong = (int)ct.so_luong,
                                              Tongtientb = (float)ct.tong_tien_tb
                                          }).ToList();

                return chitietthietbiList;
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
    }
}
