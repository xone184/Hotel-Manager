using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonDTO
    {
        public string IdDatPhong { get; set; }
        public string IdNhanVien { get; set; }
        public string IdKhachHang { get; set; }
        public string IdPhong { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public double DatCoc { get; set; }
        public double TienPhong { get; set; }
        public double PhuThuCheckIn { get; set; }
        public double PhuThuCheckOut { get; set; }
        public double TongTienDichVu { get; set; }
        public double TongTienThucPham { get; set; }
        public double TongTienHoaDon { get; set; }
        public double TongTien { get; set; }
        public int SoNguoiO { get; set; }
        public string Loai { get; set; }
        public string TrangThai { get; set; } 
    }
}
