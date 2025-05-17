using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietDichVuBLL
    {
        public QLKSDataContext qLKSDataContext;
        public ChiTietDichVuBLL()
        {
            qLKSDataContext = new QLKSDataContext();
        }
        public List<ChiTietSuDungDichVu> GetThongTinSuDungDichVu_DaCoDV(string iddatphong)
        {
            var query = from ctsd in qLKSDataContext.chitietsudungdvs
                        join dv in qLKSDataContext.dichvus on ctsd.id_dichvu equals dv.id_dichvu
                        where ctsd.id_datphong == iddatphong.Trim()
                        select new ChiTietSuDungDichVu
                        {
                            Iddatphong = ctsd.id_datphong,
                            Tendichvu = dv.ten_dichvu,
                            Ngaythue = (DateTime)ctsd.ngay_thue,
                            Soluong = (int)ctsd.so_luong,
                            Tongtiendv = (float)ctsd.tong_tien_dv
                        };

            return query.ToList();
        }
        public List<ChiTietSuDungDichVu> GetThongTinSuDungDichVu()
        {
            var query = from ctsd in qLKSDataContext.chitietsudungdvs
                        join dv in qLKSDataContext.dichvus on ctsd.id_dichvu equals dv.id_dichvu
                        select new ChiTietSuDungDichVu
                        {
                            Iddatphong = ctsd.id_datphong,
                            Tendichvu = dv.ten_dichvu,
                            Ngaythue = (DateTime)ctsd.ngay_thue,
                            Soluong = (int)ctsd.so_luong,
                            Tongtiendv = (float)ctsd.tong_tien_dv
                        };

            return query.ToList();
        }
        public void ThemChiTietDichVu(string idhoadon, string iddv, DateTime thoigian, int soluong)
        {
            qLKSDataContext.Them_chi_tiet_su_dung_dv(idhoadon, iddv, thoigian, soluong);
            qLKSDataContext.SubmitChanges();
        }
        public double TinhTongTienDichVuTheoIDDatPhong(string idDatPhong)
        {
            try
            {
                var tongTienDichVu = qLKSDataContext.chitietsudungdvs
                    .Where(ct => ct.id_datphong == idDatPhong)
                    .Sum(ct => ct.tong_tien_dv ?? 0.0);

                return (double)tongTienDichVu;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public int DemSoLuongIDDatPhongTrongChiTietSuDungDichVu(string idDatPhong)
        {
            try
            {
                var soLuong = qLKSDataContext.chitietsudungdvs
                    .Count(ct => ct.id_datphong == idDatPhong);

                return soLuong;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public void XoaChiTietSuDungDichVu(string mahd, string madv)
        {
            try
            {
                qLKSDataContext.Xoa_chi_tiet_su_dung_dv(mahd, madv);
                qLKSDataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public void SuaSoLuongChiTietSuDungDichVu(string idDatPhong, string idDichVu, int soLuongMoi)
        {
            try
            {
                qLKSDataContext.Capnhat_chi_tiet_su_dung_dv(idDatPhong, idDichVu, soLuongMoi);
                qLKSDataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<HoaDonSuDungDichVuDTO> LayThongTinHoaDonDichVu(string iddatphong)
        {
            var query = from chiTiet in qLKSDataContext.chitietsudungdvs
                        join dichvu in qLKSDataContext.dichvus on chiTiet.id_dichvu equals dichvu.id_dichvu
                        where chiTiet.id_datphong == iddatphong
                        select new HoaDonSuDungDichVuDTO
                        {
                            TenDichVu = dichvu.ten_dichvu,
                            SoLuong = (int)chiTiet.so_luong,
                            GiaDichVu = (int)dichvu.gia,
                            NgayThue = (DateTime)chiTiet.ngay_thue
                        };

            return query.ToList();
        }



    }
}
