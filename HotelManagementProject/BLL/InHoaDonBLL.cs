using DTO;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InHoaDonBLL
    {
        private QLKSDataContext _qLKSDataContext;
        public InHoaDonBLL()
        {
            _qLKSDataContext = new QLKSDataContext();
        }

        public List<XemHoaDonDTO> viewHoaDon(string idDatPhong)
        {
            var query = from dp in _qLKSDataContext.datphongs
                        join nv in _qLKSDataContext.nhanviens on dp.id_nhanvien equals nv.id_nhanvien
                        join kh in _qLKSDataContext.khachhangs on dp.id_khachhang equals kh.id_khachhang
                        join ph in _qLKSDataContext.phongs on dp.id_phong equals ph.id_phong
                        where dp.id_datphong == idDatPhong
                        select new XemHoaDonDTO
                        {
                            DatPhong = dp.id_datphong,
                            NhanVien = nv.ten_nhanvien,
                            KhachHang = kh.ten_khachhang,
                            Phong = ph.ten,
                            CheckIn = dp.check_in,
                            CheckOut = dp.check_out,
                            DatCoc = (float)dp.dat_coc,
                            TienPhong = (float)dp.tien_phong,
                            PhuThuCheckin = (float)dp.phu_thu_checkin,
                            PhuThuCheckout = (float)dp.phu_thu_checkout,
                            TongTienDV = (float)dp.tong_tien_dv,
                            TongTienTB = (float)dp.tong_tien_tb,
                            TongTienHoaDon = (float)dp.tong_tien_hoa_don,
                            TongTien = (float)dp.tong_tien
                        };

            return query.ToList();
        }

    }
}
