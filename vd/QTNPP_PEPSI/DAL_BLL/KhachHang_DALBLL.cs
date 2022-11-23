using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class KhachHang_DALBLL
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();

        #region Load dữ liệu khách hàng theo hóa đơn bán
        public IQueryable load_TenKH()
        {
            var kh = from KhachHang in QLNPP_PS.KHACHHANGs select new { KhachHang.MAKH, KhachHang.HOTENKH };
            return kh;
        }

        public IQueryable load_TenKH1(string maHDB)
        {
            var khach = from kh in QLNPP_PS.KHACHHANGs
                        join hdb in QLNPP_PS.HOADONBANs
                            on kh.MAKH equals hdb.MAKH
                        where hdb.MAHDB == maHDB
                        select new { kh.HOTENKH, kh.MAKH };
            return khach;
        }

        public List<KHACHHANG> load_DiaChi(string maKH)
        {
            List<KHACHHANG> dc = new List<KHACHHANG>();
            var diachi = (from dchi in QLNPP_PS.KHACHHANGs
                          where dchi.MAKH == maKH
                          select dchi).ToList();
            dc.AddRange(diachi);
            return dc;
        }


        #endregion

        #region Load dữ liệu khách hàng theo hóa đơn xuất
        public IQueryable load_TenKH2()
        {
            var kh = from KhachHang in QLNPP_PS.KHACHHANGs select new { KhachHang.MAKH, KhachHang.HOTENKH };
            return kh;
        }

        public IQueryable load_TenKH3(string maPX)
        {
            var khach = from kh in QLNPP_PS.KHACHHANGs
                        join px in QLNPP_PS.PHIEUXUATHANGs
                            on kh.MAKH equals px.MAKH
                        where px.MAPX == maPX
                        select new { kh.HOTENKH, kh.MAKH };
            return khach;
        }

        #endregion

        #region Thêm xóa sửa khách hàng
        public bool insertKhachHang(string maKH, string maQH, string tenKH, string loaiKH, string ngaySinh, string gioiTinh, string diaChi, string sDT)
        {
            try
            {
                KHACHHANG khachhang = new KHACHHANG();
                khachhang.MAKH = maKH;
                khachhang.MAQUANHUYEN = maQH;
                khachhang.HOTENKH = tenKH;
                khachhang.LOAIKHACHHANG = loaiKH;
                khachhang.NGAYSINHKH = Convert.ToDateTime(ngaySinh);
                khachhang.GIOITINHKH = gioiTinh;
                khachhang.DIACHIKH = diaChi;
                khachhang.SODIENTHOAIKH = sDT;
                QLNPP_PS.KHACHHANGs.InsertOnSubmit(khachhang);
                QLNPP_PS.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteKhachHang(string maKH)
        {
            try
            {
                KHACHHANG khachhang = QLNPP_PS.KHACHHANGs.Where(t => t.MAKH == maKH).FirstOrDefault();
                QLNPP_PS.KHACHHANGs.DeleteOnSubmit(khachhang);
                QLNPP_PS.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updateKhachHang(string maKH, string maQH, string tenKH, string loaiKH, string ngaySinh, string gioiTinh, string diaChi, string sDT)
        {
            KHACHHANG khachhang = QLNPP_PS.KHACHHANGs.Where(k => k.MAKH == maKH).FirstOrDefault();
            if (khachhang != null)
            {
                khachhang.MAKH = maKH;
                khachhang.MAQUANHUYEN = maQH;
                khachhang.HOTENKH = tenKH;
                khachhang.LOAIKHACHHANG = loaiKH;
                khachhang.NGAYSINHKH = Convert.ToDateTime(ngaySinh);
                khachhang.GIOITINHKH = gioiTinh;
                khachhang.DIACHIKH = diaChi;
                khachhang.SODIENTHOAIKH = sDT;
                QLNPP_PS.SubmitChanges();
                return true;
            }
            return false;
        }
        #endregion
    }
}
