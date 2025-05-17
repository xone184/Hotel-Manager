using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ThongKeThietBiBLL
    {
        QLKSDataContext context;
        public ThongKeThietBiBLL()
        {
            context = new QLKSDataContext();
        }
        public List<ChiTietSuDungThietBi> GetThongTinSuDungThietBi()
        {
            var query = from ctsd in context.chitietsudungtbs
                        join tb in context.thietbis on ctsd.id_thietbi equals tb.id_thietbi
                        select new ChiTietSuDungThietBi
                        {
                            Iddatphong = ctsd.id_datphong,
                            Tenthietbi = tb.ten_thietbi,
                            Ngaythue = (DateTime)ctsd.ngay_thue,
                            Soluong = (int)ctsd.so_luong,
                            Tongtientb = (float)ctsd.tong_tien_tb
                        };
            return query.ToList();
        }

        public int SoLuongHoaDonTheoThang(int thang)
        {
            int count = context.chitietsudungtbs
                    .Where(dp => dp.ngay_thue.Value.Month == thang)
                    .Count();
            return count;
        }
        public decimal TongTienTheoThang(int nam)
        {
            decimal totalRevenue = context.chitietsudungtbs
                    .Where(dp => dp.ngay_thue.Value.Month == nam)
                    .Sum(dp => (decimal?)dp.tong_tien_tb) ?? 0;

            return totalRevenue;
        }
        public int SoLuongHoaDonTheoQuy(int quy)
        {
            int result = 0;

            try
            {
                result = context.chitietsudungtbs
                    .Where(dp => dp.ngay_thue.Value.Month >= (quy - 1) * 3 + 1 && dp.ngay_thue.Value.Month <= quy * 3)
                    .Count();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return result;
        }
        public decimal TongTienTheoQuy(int quy)
        {
            decimal totalRevenue = context.chitietsudungtbs
                    .Where(dp => dp.ngay_thue.Value.Month >= (quy - 1) * 3 + 1 && dp.ngay_thue.Value.Month <= quy * 3)
                    .Sum(dp => (decimal?)dp.tong_tien_tb) ?? 0;

            return totalRevenue;
        }
        public int SoLuongHoaDonTheoNam(int nam)
        {
            int count = context.chitietsudungtbs
                    .Where(dp => dp.ngay_thue.Value.Year == nam)
                    .Count();
            return count;
        }
        public decimal TongTienTheoNam(int nam)
        {
            decimal totalRevenue = context.chitietsudungtbs
                    .Where(dp => dp.ngay_thue.Value.Year == nam)
                    .Sum(dp => (decimal?)dp.tong_tien_tb) ?? 0;

            return totalRevenue;
        }
        //------------------------------
        public string TenThietBiDuocDatNhieuNhat(int thang)
        {
            var query = from chiTiet in context.chitietsudungtbs
                        where chiTiet.ngay_thue.Value.Month == thang
                        group chiTiet by chiTiet.id_thietbi into grp
                        orderby grp.Sum(x => x.so_luong) descending
                        select grp.Key;

            string idThietBiNhieuNhat = query.FirstOrDefault();

            return idThietBiNhieuNhat ?? "Không có dữ liệu";
        }
        public string LaySoLuongThietBiNhieuNhat(int thang)
        {
            var query = from chiTiet in context.chitietsudungtbs
                        where chiTiet.ngay_thue.Value.Month == thang
                        group chiTiet by chiTiet.id_thietbi into grp
                        orderby grp.Sum(x => x.so_luong) descending
                        select grp.Sum(x => x.so_luong);

            return query.FirstOrDefault().ToString() ?? "Không có dữ liệu";

        }
        public string TenThietBiDuocDatItNhat(int thang)
        {
            var query = from chiTiet in context.chitietsudungtbs
                        where chiTiet.ngay_thue.Value.Month == thang
                        group chiTiet by chiTiet.id_thietbi into grp
                        orderby grp.Sum(x => x.so_luong) ascending
                        select grp.Key;

            string idThietBiNhieuNhat = query.FirstOrDefault();

            return idThietBiNhieuNhat ?? "Không có dữ liệu";
        }
        public string LaySoLuongThietBiItNhat(int thang)
        {
            var query = from chiTiet in context.chitietsudungtbs
                        where chiTiet.ngay_thue.Value.Month == thang
                        group chiTiet by chiTiet.id_thietbi into grp
                        orderby grp.Sum(x => x.so_luong) ascending
                        select grp.Sum(x => x.so_luong);

            return query.FirstOrDefault().ToString() ?? "Không có dữ liệu";

        }
        //------------------------------
        public string TenThietBiDuocDatNhieuNhatTheoQuy(int quy)
        {
            var query = from chiTiet in context.chitietsudungtbs
                        where chiTiet.ngay_thue.Value.Month >= (quy - 1) * 3 + 1 && chiTiet.ngay_thue.Value.Month <= quy * 3
                        group chiTiet by chiTiet.id_thietbi into grp
                        orderby grp.Sum(x => x.so_luong) descending
                        select grp.Key;

            string idThietBiNhieuNhat = query.FirstOrDefault();

            return idThietBiNhieuNhat ?? "Không có dữ liệu";
        }
        public string LaySoLuongThietBiNhieuNhatTheoQuy(int quy)
        {
            var query = from chiTiet in context.chitietsudungtbs
                        where chiTiet.ngay_thue.Value.Month >= (quy - 1) * 3 + 1 && chiTiet.ngay_thue.Value.Month <= quy * 3
                        group chiTiet by chiTiet.id_thietbi into grp
                        orderby grp.Sum(x => x.so_luong) descending
                        select grp.Sum(x => x.so_luong);

            return query.FirstOrDefault().ToString() ?? "Không có dữ liệu";

        }
        public string TenThietBiDuocDatItNhatTheoQuy(int quy)
        {
            var query = from chiTiet in context.chitietsudungtbs
                        where chiTiet.ngay_thue.Value.Month >= (quy - 1) * 3 + 1 && chiTiet.ngay_thue.Value.Month <= quy * 3
                        group chiTiet by chiTiet.id_thietbi into grp
                        orderby grp.Sum(x => x.so_luong) ascending
                        select grp.Key;

            string idThietBiNhieuNhat = query.FirstOrDefault();

            return idThietBiNhieuNhat ?? "Không có dữ liệu";
        }
        public string LaySoLuongThietBiItNhatTheoQuy(int quy)
        {
            var query = from chiTiet in context.chitietsudungtbs
                        where chiTiet.ngay_thue.Value.Month >= (quy - 1) * 3 + 1 && chiTiet.ngay_thue.Value.Month <= quy * 3
                        group chiTiet by chiTiet.id_thietbi into grp
                        orderby grp.Sum(x => x.so_luong) ascending
                        select grp.Sum(x => x.so_luong);

            return query.FirstOrDefault().ToString() ?? "Không có dữ liệu";

        }
        //----------------------------
        public string TenThietBiDuocDatNhieuNhatTheoNam(int nam)
        {
            var query = from chiTiet in context.chitietsudungtbs
                        where chiTiet.ngay_thue.Value.Year == nam
                        group chiTiet by chiTiet.id_thietbi into grp
                        orderby grp.Sum(x => x.so_luong) descending
                        select grp.Key;

            string idThietBiNhieuNhat = query.FirstOrDefault();

            return idThietBiNhieuNhat ?? "Không có dữ liệu";
        }
        public string LaySoLuongThietBiNhieuNhatTheoNam(int nam)
        {
            var query = from chiTiet in context.chitietsudungtbs
                        where chiTiet.ngay_thue.Value.Year == nam
                        group chiTiet by chiTiet.id_thietbi into grp
                        orderby grp.Sum(x => x.so_luong) descending
                        select grp.Sum(x => x.so_luong);

            return query.FirstOrDefault().ToString() ?? "Không có dữ liệu";

        }
        public string TenThietBiDuocDatItNhatTheoNam(int nam)
        {
            var query = from chiTiet in context.chitietsudungtbs
                        where chiTiet.ngay_thue.Value.Year == nam
                        group chiTiet by chiTiet.id_thietbi into grp
                        orderby grp.Sum(x => x.so_luong) ascending
                        select grp.Key;

            string idThietBiNhieuNhat = query.FirstOrDefault();

            return idThietBiNhieuNhat ?? "Không có dữ liệu";
        }
        public string LaySoLuongThietBiItNhatTheoNam(int nam)
        {
            var query = from chiTiet in context.chitietsudungtbs
                        where chiTiet.ngay_thue.Value.Year == nam
                        group chiTiet by chiTiet.id_thietbi into grp
                        orderby grp.Sum(x => x.so_luong) ascending
                        select grp.Sum(x => x.so_luong);

            return query.FirstOrDefault().ToString() ?? "Không có dữ liệu";

        }
    }
}
