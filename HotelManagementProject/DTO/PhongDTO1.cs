using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhongDTO1
    {
        string idphong, loaiphong, tenphong, trangthai;
        int sotang, gia;

        public string Idphong { get => idphong; set => idphong = value; }
        public string Loaiphong { get => loaiphong; set => loaiphong = value; }
        public string Tenphong { get => tenphong; set => tenphong = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
        public int Sotang { get => sotang; set => sotang = value; }
        public int Gia { get => gia; set => gia = value; }
    }
}
