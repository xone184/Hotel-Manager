using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ThietBiBLL
    {
        private QLKSDataContext _qLKSDataContext;
        public ThietBiBLL()
        {
            _qLKSDataContext = new QLKSDataContext();
        }
        public List<thietbi> GetThietBiList()
        {
            try
            {
                var thietbiList = (from p in _qLKSDataContext.thietbis select p).ToList();

                return thietbiList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public void XoaThietBi(string id_thietbi)
        {

            var thietbiToRemove = _qLKSDataContext.thietbis.SingleOrDefault(tb => tb.id_thietbi == id_thietbi);
            if (thietbiToRemove != null)
            {
                _qLKSDataContext.thietbis.DeleteOnSubmit(thietbiToRemove);
                _qLKSDataContext.SubmitChanges();
            }
        }

        public void ThemThietBi(string tentb, int gia)
        {
            _qLKSDataContext.Them_Thiet_Bi(tentb, gia);
            _qLKSDataContext.SubmitChanges();
        }
        public void CapNhatThietBi(string id_thietbi, string ten_thietbi, int gia)
        {
            var dichvuToUpdate = _qLKSDataContext.thietbis.SingleOrDefault(dv => dv.id_thietbi == id_thietbi);
            if (dichvuToUpdate != null)
            {
                dichvuToUpdate.ten_thietbi = ten_thietbi;
                dichvuToUpdate.gia = gia;
                _qLKSDataContext.SubmitChanges();
            }
        }


        public string LayIDThietBiByTenThietBi(string tenThietBi)
        {
            try
            {
                var idThietBi = _qLKSDataContext.thietbis
                    .Where(dv => dv.ten_thietbi == tenThietBi)
                    .Select(dv => dv.id_thietbi)
                    .FirstOrDefault();

                return idThietBi;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public int LayGiaByTenThietBi(string tenThietBi)
        {
            try
            {
                var giatb = _qLKSDataContext.thietbis
                    .Where(tb => tb.ten_thietbi == tenThietBi)
                    .Select(tb => tb.gia)
                    .FirstOrDefault();

                return giatb;
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

        public List<ThietBiDTO> GetHoaDonList_TenHoaDon(string id_DatPhong)
        {
            try
            {
                var hoadonList = (from p in _qLKSDataContext.thietbis
                                  where p.ten_thietbi == id_DatPhong
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
    }
}
