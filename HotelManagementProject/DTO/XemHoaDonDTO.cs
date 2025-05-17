using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class XemHoaDonDTO
    {
        public string DatPhong { get; set; }
        public string NhanVien { get; set; }
        public string KhachHang { get; set; }
        public string Phong { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public float DatCoc { get; set; }
        public float TienPhong { get; set; }
        public float PhuThuCheckin { get; set; }
        public float PhuThuCheckout { get; set; }
        public float TongTienDV { get; set; }
        public float TongTienTB { get; set; }
        public float TongTienHoaDon { get; set; }
        public float TongTien { get; set; }
    }

}
