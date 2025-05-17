using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietSuDungThietBi
    {
        string iddatphong, tenthietbi;
        DateTime ngaythue;
        int soluong;
        float tongtientb;

        public string Iddatphong { get => iddatphong; set => iddatphong = value; }
        public string Tenthietbi { get => tenthietbi; set => tenthietbi = value; }
        public DateTime Ngaythue { get => ngaythue; set => ngaythue = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public float Tongtientb { get => tongtientb; set => tongtientb = value; }
    }
}
