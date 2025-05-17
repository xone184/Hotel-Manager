namespace DTO
{
    public class PhongDTO
    {
        string idPhong, tenLoaiPhong, tenPhong, trangThai;
        int soTang;

        public string IdPhong { get => idPhong; set => idPhong = value; }
        public string TenLoaiPhong { get => tenLoaiPhong; set => tenLoaiPhong = value; }
        public int SoTang { get => soTang; set => soTang = value; }
        public string TenPhong { get => tenPhong; set => tenPhong = value; }  
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}
