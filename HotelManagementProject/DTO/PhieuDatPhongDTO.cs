using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuDatPhongDTO
    {
        public string IdDatPhong { get; set; }
        public string TenPhong { get; set; }
        public string TenNhanVien { get; set; }
        public string TenKhachHang { get; set; }
        public string Loai { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int TongThoiGian { get; set; }
        public string TrangThai { get; set; }
    }

}
