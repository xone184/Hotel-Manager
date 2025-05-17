using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;

namespace BLL
{
    public class TaiKhoanBLL
    {
        private QLKSDataContext _qLKSDataContext;
        public TaiKhoanBLL()
        {
            _qLKSDataContext = new QLKSDataContext();
        }
        public List<TaiKhoanDTO> getListAccount()
        {
            var taiKhoanList = (from tk in _qLKSDataContext.taikhoans
                                join nv in _qLKSDataContext.nhanviens on tk.id_nhanvien equals nv.id_nhanvien
                                select new TaiKhoanDTO
                                {
                                    idtk = tk.id_taikhoan,
                                    idnv = tk.id_nhanvien,
                                    tennv = nv.ten_nhanvien,
                                    username = tk.ten_dang_nhap,
                                    password = HashPassword(tk.mat_khau),
                                    quyen = tk.quyen
                                }).ToList();

            return taiKhoanList;
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
        public string GetTenDangNhap(string tendangnhap)
        {
            var account = _qLKSDataContext.taikhoans.FirstOrDefault(nv => nv.ten_dang_nhap == tendangnhap);

            if (account != null)
            {
                return account.ten_dang_nhap;
            }
            else
            {
                return "Không tìm thấy tài khoản";
            }
        }
        public string GetMatKhau(string tendangnhap)
        {
            var account = _qLKSDataContext.taikhoans.FirstOrDefault(nv => nv.ten_dang_nhap == tendangnhap);

            if (account != null)
            {
                return account.mat_khau;
            }
            else
            {
                return "Không tìm thấy tài khoản";
            }
        }
        public int CheckHoatDong(string tendangnhap)
        {
            var account = _qLKSDataContext.taikhoans.FirstOrDefault(nv => nv.ten_dang_nhap == tendangnhap);

            if (account != null)
            {
                return int.Parse(account.hoat_dong.ToString().Trim());
            }
            else
            {
                return 0;
            }
        }
        public bool CheckTaiKhoanTonTai(string tendangnhap)
        {
            var account = _qLKSDataContext.taikhoans.FirstOrDefault(nv => nv.ten_dang_nhap == tendangnhap);
            if (account == null)
                return false;
            else
                return true;
        }
        public string GetTenTaiKhoan(string tendangnhap)
        {
            var query = from t in _qLKSDataContext.taikhoans
                        join n in _qLKSDataContext.nhanviens on t.id_nhanvien equals n.id_nhanvien
                        where t.ten_dang_nhap == tendangnhap
                        select n.ten_nhanvien;

            string tenNhanVien = query.FirstOrDefault();

            return tenNhanVien;
        }
        public string GetQuyen(string username)
        {
            var query = from t in _qLKSDataContext.taikhoans
                        where t.ten_dang_nhap == username
                        select t.quyen;

            return query.FirstOrDefault().ToString();
        }
        public List<string> GetListTenNhanVien()
        {
            var query = from t in _qLKSDataContext.nhanviens
                        select t.ten_nhanvien;

            return query.ToList();
        }
        public string GetIdNhanVien(string tennv)
        {
            var query = from t in _qLKSDataContext.nhanviens
                        where t.ten_nhanvien == tennv
                        select t.id_nhanvien;

            return query.FirstOrDefault().ToString();
        }
        public int ThemTaiKhoan(string idnv, string username, string quyen)
        {
            if (_qLKSDataContext.taikhoans.Any(tk => tk.id_nhanvien == idnv))
            {
                return 0;
            }
            else
            {
                taikhoan taiKhoanMoi = new taikhoan
                {
                    id_nhanvien = idnv,
                    ten_dang_nhap = username,
                    mat_khau = "123",
                    hoat_dong = 1,
                    quyen = quyen
                };

                _qLKSDataContext.taikhoans.InsertOnSubmit(taiKhoanMoi);
                _qLKSDataContext.SubmitChanges();
                return 1;
            }
        }
        public void XoaTaiKhoan(int id)
        {
            var taiKhoanXoa = _qLKSDataContext.taikhoans.SingleOrDefault(tk => tk.id_taikhoan == id);
            _qLKSDataContext.taikhoans.DeleteOnSubmit(taiKhoanXoa);
            _qLKSDataContext.SubmitChanges();
        }
        public void SuaTaiKhoan(int idTaiKhoan, string newTenDangNhap, string quyen)
        {
            var taiKhoanSua = _qLKSDataContext.taikhoans.SingleOrDefault(tk => tk.id_taikhoan == idTaiKhoan);
            taiKhoanSua.ten_dang_nhap = newTenDangNhap;
            taiKhoanSua.quyen = quyen;
            _qLKSDataContext.SubmitChanges();
        }
        public void ResetPassword(int idTaiKhoan)
        {
            var taiKhoanSua = _qLKSDataContext.taikhoans.SingleOrDefault(tk => tk.id_taikhoan == idTaiKhoan);
            taiKhoanSua.mat_khau = "123";
            _qLKSDataContext.SubmitChanges();
        }
        public void ChangePassword(string user, string pass)
        {
            var acc = _qLKSDataContext.taikhoans.SingleOrDefault(tk => tk.ten_dang_nhap == user);
            acc.mat_khau = pass;
            _qLKSDataContext.SubmitChanges();
        }
    }
}
