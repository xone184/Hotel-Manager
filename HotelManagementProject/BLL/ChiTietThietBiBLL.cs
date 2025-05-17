using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietThietBiBLL
    {
        private QLKSDataContext qLKSDataContext;
        public ChiTietThietBiBLL()
        {
            qLKSDataContext = new QLKSDataContext();
        }
        public List<ChiTietSuDungThietBi> GetThongTinSuDungThietBi_DaCoTB(string iddatphong)
        {
            var query = from ctsd in qLKSDataContext.chitietsudungtbs
                        join dv in qLKSDataContext.thietbis on ctsd.id_thietbi equals dv.id_thietbi
                        where ctsd.id_datphong == iddatphong
                        select new ChiTietSuDungThietBi
                        {
                            Iddatphong = ctsd.id_datphong,
                            Tenthietbi = dv.ten_thietbi,
                            Ngaythue = (DateTime)ctsd.ngay_thue,
                            Soluong = (int)ctsd.so_luong,
                            Tongtientb = (float)ctsd.tong_tien_tb
                        };

            return query.ToList();
        }
        public List<ChiTietSuDungThietBi> GetThongTinSuDungThietBi()
        {
            var query = from ctsd in qLKSDataContext.chitietsudungtbs
                        join dv in qLKSDataContext.thietbis on ctsd.id_thietbi equals dv.id_thietbi
                        select new ChiTietSuDungThietBi
                        {
                            Iddatphong = ctsd.id_datphong,
                            Tenthietbi = dv.ten_thietbi,
                            Ngaythue = (DateTime)ctsd.ngay_thue,
                            Soluong = (int)ctsd.so_luong,
                            Tongtientb = (float)ctsd.tong_tien_tb
                        };

            return query.ToList();
        }

        public void ThemChiTietThietBi(string idhoadon, string idtb, DateTime thoigian, int soluong)
        {
            qLKSDataContext.Them_chi_tiet_su_dung_tb(idhoadon, idtb, thoigian, soluong);
            qLKSDataContext.SubmitChanges();
        }

        public double TinhTongTienThietBiTheoIDDatPhong(string idDatPhong)
        {
            try
            {
                var tongTienThietBi = qLKSDataContext.chitietsudungtbs
                    .Where(ct => ct.id_datphong == idDatPhong && ct.tong_tien_tb != null)
                    .Sum(ct => ct.tong_tien_tb ?? 0.0);

                return (double)tongTienThietBi;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public int DemSoLuongIDDatPhongTrongChiTietSuDungThietBi(string idDatPhong)
        {
            try
            {
                var soLuong = qLKSDataContext.chitietsudungtbs
                    .Count(ct => ct.id_datphong == idDatPhong);

                return soLuong;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public void XoaChiTietSuDungThietBi(string mahd, string matb)
        {
            try
            {
                qLKSDataContext.Xoa_chi_tiet_su_dung_tb(mahd, matb);
                qLKSDataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public void SuaSoLuongChiTietSuDungThietBi(string idDatPhong, string idThietBi, int soLuongMoi)
        {
            try
            {
                qLKSDataContext.Capnhat_chi_tiet_su_dung_tb(idDatPhong, idThietBi, soLuongMoi);
                qLKSDataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public List<HoaDonSuDungThietBiDTO> LayThongTinHoaDonThietBi(string iddatphong)
        {
            var query = from chiTiet in qLKSDataContext.chitietsudungtbs
                        join dichvu in qLKSDataContext.thietbis on chiTiet.id_thietbi equals dichvu.id_thietbi
                        where chiTiet.id_datphong == iddatphong
                        select new HoaDonSuDungThietBiDTO
                        {
                            TenThietBi = dichvu.ten_thietbi,
                            SoLuong = (int)chiTiet.so_luong,
                            GiaThietBi = (int)dichvu.gia,
                            NgayThue = (DateTime)chiTiet.ngay_thue
                        };

            return query.ToList();
        }
    }
}
