using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DichVuBLL
    {

        private QLKSDataContext _qLKSDataContext;
        public DichVuBLL()
        {
            _qLKSDataContext = new QLKSDataContext();
        }
        public List<dichvu> GetDichVuList()
        {
            try
            {
                var dichvuList = (from p in _qLKSDataContext.dichvus select p).ToList();

                return dichvuList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public void XoaDichVu(string id_dichvu)
        {
            var dichvuToRemove = _qLKSDataContext.dichvus.SingleOrDefault(dv => dv.id_dichvu == id_dichvu);
            if (dichvuToRemove != null)
            {
                _qLKSDataContext.dichvus.DeleteOnSubmit(dichvuToRemove);
                _qLKSDataContext.SubmitChanges();
            }
        }
        public void ThemDichVu(string tendv, int gia)
        {
            _qLKSDataContext.Them_Dich_Vu(tendv, gia);
            _qLKSDataContext.SubmitChanges();
        }
        public void CapNhatDichVu(string id_dichvu, string ten_dichvu, int gia)
        {
            var dichvuToUpdate = _qLKSDataContext.dichvus.SingleOrDefault(dv => dv.id_dichvu == id_dichvu);
            if (dichvuToUpdate != null)
            {
                dichvuToUpdate.ten_dichvu = ten_dichvu;
                dichvuToUpdate.gia = gia;
                _qLKSDataContext.SubmitChanges();
            }
        }
        public List<dichvu> TimKiemDichVu(string timkiem)
        {
            var query = from dv in _qLKSDataContext.dichvus
                        where dv.id_dichvu == timkiem || dv.ten_dichvu == timkiem
                        select dv;

            return query.ToList();
        }
        public string LayIDDichVuByTenDichVu(string tenDichVu)
        {
            try
            {
                var idDichVu = _qLKSDataContext.dichvus
                    .Where(dv => dv.ten_dichvu == tenDichVu)
                    .Select(dv => dv.id_dichvu)
                    .FirstOrDefault();

                return idDichVu;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public int LayGiaByTenDichVu(string tenDichVu)
        {
            try
            {
                var giadv = _qLKSDataContext.dichvus
                    .Where(dv => dv.ten_dichvu == tenDichVu)
                    .Select(dv => dv.gia)
                    .FirstOrDefault();

                return giadv;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<DichVuDTO> GetHoaDonList_MaHoaDon(string id_DatPhong)
        {
            try
            {
                var hoadonList = (from p in _qLKSDataContext.dichvus
                                  where p.id_dichvu == id_DatPhong
                                  select new DichVuDTO
                                  {
                                      Id_DV = p.id_dichvu,
                                      Ten_DV = p.ten_dichvu,
                                      Gia_DV = p.gia
                                  }).ToList();

                return hoadonList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<DichVuDTO> GetHoaDonList_TenHoaDon(string id_DatPhong)
        {
            try
            {
                var hoadonList = (from p in _qLKSDataContext.dichvus
                                  where p.ten_dichvu == id_DatPhong
                                  select new DichVuDTO
                                  {
                                      Id_DV = p.id_dichvu,
                                      Ten_DV = p.ten_dichvu,
                                      Gia_DV = p.gia
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
