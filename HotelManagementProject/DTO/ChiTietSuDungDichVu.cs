using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietSuDungDichVu
    {
        string iddatphong, tendichvu;
        DateTime ngaythue;
        int soluong;
        float tongtiendv;

        public string Iddatphong { get => iddatphong; set => iddatphong = value; }
        public string Tendichvu { get => tendichvu; set => tendichvu = value; }
        public DateTime Ngaythue { get => ngaythue; set => ngaythue = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public float Tongtiendv { get => tongtiendv; set => tongtiendv = value; }
    }
}
