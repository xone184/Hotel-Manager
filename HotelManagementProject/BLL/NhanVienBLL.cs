using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhanVienBLL
    {
        private QLKSDataContext _qLKSDataContext;
        public NhanVienBLL()
        {
            _qLKSDataContext = new QLKSDataContext();
        }

        public List<nhanvien> GetNhanVienList()
        {
            try
            {
                var nhanvienList = (from p in _qLKSDataContext.nhanviens select p).ToList();

                return nhanvienList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<nhanvien> TimKiemNhanVien(string str)
        {
            try
            {
                var nhanvienList = (from p in _qLKSDataContext.nhanviens where p.ten_nhanvien.Contains(str) select p).ToList();

                return nhanvienList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public string GetIdNhanVienByTen(string ten)
        {
            var tenLoaiPhong = (from nv in _qLKSDataContext.nhanviens
                                where nv.ten_nhanvien == ten.Trim()
                                select nv.id_nhanvien).FirstOrDefault();
            return tenLoaiPhong;
        }


        public void XoaNhanVien(string id_nhanvien)
        {
            var nhanvienToRemove = _qLKSDataContext.nhanviens.SingleOrDefault(dv => dv.id_nhanvien == id_nhanvien);
            if (nhanvienToRemove != null)
            {
                _qLKSDataContext.nhanviens.DeleteOnSubmit(nhanvienToRemove);
                _qLKSDataContext.SubmitChanges();
            }
        }

        public void CapNhatNhanVien(string id_nhanvien, string ten_nhanvien, DateTime ngaysinh_nhanvien, string sdt_nhanvien, string gioitinh_nhanvien, string email_nhanvien)
        {
            var nhanvienToUpdate = _qLKSDataContext.nhanviens.SingleOrDefault(dv => dv.id_nhanvien == id_nhanvien);
            if (nhanvienToUpdate != null)
            {
                nhanvienToUpdate.ten_nhanvien = ten_nhanvien;
                nhanvienToUpdate.ngay_sinh = ngaysinh_nhanvien;
                nhanvienToUpdate.sdt = sdt_nhanvien;
                nhanvienToUpdate.gioi_tinh = gioitinh_nhanvien;
                nhanvienToUpdate.email = email_nhanvien;

                _qLKSDataContext.SubmitChanges();
            }
        }

        public void ThemNhanVien(string ten, DateTime ngaysinh, string sdt, string gioitinh, string email)
        {
            _qLKSDataContext.Them_Nhan_Vien(ten, ngaysinh, sdt, gioitinh, email);
            _qLKSDataContext.SubmitChanges();
        }

    }
}
