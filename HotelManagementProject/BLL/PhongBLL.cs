using System.Collections.Generic;
using System.Data.Linq;
using System;
using System.Linq;
using DTO;
using System.Runtime.Remoting.Contexts;

namespace BLL
{
    public class PhongBLL
    {
        private QLKSDataContext _qLKSDataContext;
        private readonly PhongDTO _phongDTO;

        public PhongBLL()
        {
            _qLKSDataContext = new QLKSDataContext();
            _phongDTO = new PhongDTO();
        }
        public List<phong> GetPhongList()
        {
            try
            {
                var phongList = (from p in _qLKSDataContext.phongs
                                 select p).ToList();

                return phongList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<PhongDTO1> GetPhongDTO1()
        {
            var query = from ph in _qLKSDataContext.phongs
                        join lp in _qLKSDataContext.loaiphongs on ph.id_loaiphong equals lp.id_loaiphong
                        select new PhongDTO1
                        {
                            Idphong = ph.id_phong,
                            Loaiphong = lp.ten_loai,
                            Sotang = ph.id_tang,
                            Tenphong = ph.ten,
                            Trangthai = ph.trang_thai,
                            Gia = ph.gia
                        };

            return query.ToList();
        }

        public void XoaPhong(string id_phong)
        {
            var phongToRemove = _qLKSDataContext.phongs.SingleOrDefault(dv => dv.id_phong == id_phong);
            if (phongToRemove != null)
            {
                _qLKSDataContext.phongs.DeleteOnSubmit(phongToRemove);
                _qLKSDataContext.SubmitChanges();
            }
        }
        public void ThemPhong(int id_loaiphong, int id_tang, string tenphong, string trangthai, int gia)
        {
            _qLKSDataContext.Them_Phong(id_loaiphong, id_tang, tenphong, trangthai, gia);
            _qLKSDataContext.SubmitChanges();
        }
        public void CapNhatPhong(string id_phong, int id_loaiphong, int id_tang, string tenphong, string trangthai, int gia)
        {
            var phongToUpdate = _qLKSDataContext.phongs.SingleOrDefault(dv => dv.id_phong == id_phong);
            if (phongToUpdate != null)
            {
                phongToUpdate.id_phong = id_phong;
                phongToUpdate.id_loaiphong = id_loaiphong;
                phongToUpdate.id_tang = id_tang;
                phongToUpdate.trang_thai = trangthai;
                phongToUpdate.ten = tenphong;
                phongToUpdate.gia = gia;
                _qLKSDataContext.SubmitChanges();
            }
        }
        public List<PhongDTO1> TimKiemPhong(string timkiem)
        {
            var query = from p in _qLKSDataContext.phongs
                        where p.id_phong == timkiem || p.ten == timkiem
                        select new PhongDTO1
                        {
                            Idphong = p.id_phong,
                            Loaiphong = p.id_loaiphong.ToString(),
                            Sotang = p.id_tang,
                            Tenphong = p.ten,
                            Trangthai = p.trang_thai,
                            Gia = p.gia
                        };

            return query.ToList();
        }


        public List<PhongDTO> GetPhongListCoTenLoaiPhong()
        {
            try
            {
                var phongList = (from p in _qLKSDataContext.phongs
                                 join lp in _qLKSDataContext.loaiphongs on p.id_loaiphong equals lp.id_loaiphong
                                 select new PhongDTO
                                 {
                                     IdPhong = p.id_phong,
                                     TenLoaiPhong = lp.ten_loai,
                                     SoTang = p.id_tang,
                                     TenPhong = p.ten,
                                     TrangThai = p.trang_thai
                                 }).ToList();

                return phongList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<PhongDTO> GetPhongListCoTenLoaiPhongTheoTrangThai(string trangthai)
        {
            try
            {
                var phongList = (from p in _qLKSDataContext.phongs
                                 join lp in _qLKSDataContext.loaiphongs on p.id_loaiphong equals lp.id_loaiphong
                                 where p.trang_thai == trangthai
                                 select new PhongDTO
                                 {
                                     IdPhong = p.id_phong,
                                     TenLoaiPhong = lp.ten_loai,
                                     SoTang = p.id_tang,
                                     TenPhong = p.ten,
                                     TrangThai = p.trang_thai
                                 }).ToList();

                return phongList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<PhongDTO> GetPhongListCoTenLoaiPhongTheoSoTang(int sotang)
        {
            try
            {
                var phongList = (from p in _qLKSDataContext.phongs
                                 join lp in _qLKSDataContext.loaiphongs on p.id_loaiphong equals lp.id_loaiphong
                                 where p.id_tang == sotang
                                 select new PhongDTO
                                 {
                                     IdPhong = p.id_phong,
                                     TenLoaiPhong = lp.ten_loai,
                                     SoTang = p.id_tang,
                                     TenPhong = p.ten,
                                     TrangThai = p.trang_thai
                                 }).ToList();

                return phongList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }


        public void UpdatePhongTrangThai(string idPhong, string newTrangThai)
        {
            var phongToUpdate = _qLKSDataContext.phongs.SingleOrDefault(p => p.id_phong == idPhong);

            if (phongToUpdate != null)
            {
                phongToUpdate.trang_thai = newTrangThai;
                _qLKSDataContext.SubmitChanges();
            }
        }
        public string GetIdPhongFromRoomPanel(string str)
        {
            return str;
        }
        public string GetTenLoaiPhong(string idPhong)
        {
            var tenLoaiPhong = (from p in _qLKSDataContext.phongs
                                join lp in _qLKSDataContext.loaiphongs on p.id_loaiphong equals lp.id_loaiphong
                                where p.id_phong == idPhong
                                select lp.ten_loai).FirstOrDefault();

            return tenLoaiPhong;
        }
        public string GetTenPhongByIdPhong(string idPhong)
        {
            try
            {
                var tenPhong = (from phong in _qLKSDataContext.phongs
                                where phong.id_phong == idPhong
                                select phong.ten).FirstOrDefault();

                return tenPhong;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<ThietBiDTO> GetHoaDonList_MaHoaDon(string id_DatPhong)
        {
            try
            {
                var hoadonList = (from p in _qLKSDataContext.thietbis
                                  where p.id_thietbi == id_DatPhong
                                  select new ThietBiDTO
                                  {
                                      Id_TB = p.id_thietbi,
                                      Ten_TB = p.ten_thietbi,
                                      Gia_TB = p.gia
                                  }).ToList();

                return hoadonList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<PhongDTO1> GetHoaDonList_IDHoaDon(string id_DatPhong)
        {
            try
            {
                var hoadonList = (from p in _qLKSDataContext.phongs
                                  where p.id_phong == id_DatPhong
                                  select new PhongDTO1
                                  {
                                      Idphong = p.id_phong,
                                      Loaiphong = p.id_loaiphong.ToString(),
                                      Sotang = p.id_tang,
                                      Tenphong = p.ten,
                                      Trangthai = p.trang_thai,
                                      Gia = p.gia
                                      
                                       
                                  }).ToList();

                return hoadonList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<PhongDTO1> GetHoaDonList_TenHoaDon(string id_DatPhong)
        {
            try
            {
                var hoadonList = (from p in _qLKSDataContext.phongs
                                  where p.ten == id_DatPhong
                                  select new PhongDTO1
                                  {
                                      Idphong = p.id_phong,
                                      Loaiphong = p.id_loaiphong.ToString(),
                                      Sotang = p.id_tang,
                                      Tenphong = p.ten,
                                      Trangthai = p.trang_thai,
                                      Gia = p.gia


                                  }).ToList();

                return hoadonList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<PhongDTO1> GetHoaDonList_TTHoaDon(string id_DatPhong)
        {
            try
            {
                var hoadonList = (from p in _qLKSDataContext.phongs
                                  where p.trang_thai == id_DatPhong
                                  select new PhongDTO1
                                  {
                                      Idphong = p.id_phong,
                                      Loaiphong = p.id_loaiphong.ToString(),
                                      Sotang = p.id_tang,
                                      Tenphong = p.ten,
                                      Trangthai = p.trang_thai,
                                      Gia = p.gia


                                  }).ToList();

                return hoadonList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<PhongDTO1> GetHoaDonList_TangHoaDon(int id_DatPhong)
        {
            try
            {
                var hoadonList = (from p in _qLKSDataContext.phongs
                                  where p.id_tang == id_DatPhong
                                  select new PhongDTO1
                                  {
                                      Idphong = p.id_phong,
                                      Loaiphong = p.id_loaiphong.ToString(),
                                      Sotang = p.id_tang,
                                      Tenphong = p.ten,
                                      Trangthai = p.trang_thai,
                                      Gia = p.gia


                                  }).ToList();

                return hoadonList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<PhongDTO1> GetHoaDonList_LoaiHoaDon(int id_DatPhong)
        {
            try
            {
                var hoadonList = (from p in _qLKSDataContext.phongs
                                  where p.id_loaiphong == id_DatPhong
                                  select new PhongDTO1
                                  {
                                      Idphong = p.id_phong,
                                      Loaiphong = p.id_loaiphong.ToString(),
                                      Sotang = p.id_tang,
                                      Tenphong = p.ten,
                                      Trangthai = p.trang_thai,
                                      Gia = p.gia


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
