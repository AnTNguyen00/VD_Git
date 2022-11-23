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

        #region Load dữ liệu khách hàng
        public IQueryable load_KhachHang()
        {
            var kh = from k in QLNPP_PS.KHACHHANGs select new { k.MAKH, k.MAQUANHUYEN, k.HOTENKH, k.LOAIKHACHHANG, k.NGAYSINHKH, k.GIOITINHKH, k.DIACHIKH, k.SODIENTHOAIKH };
            return kh;
        }

        public List<KHACHHANG> getKhachHang()
        {
            return QLNPP_PS.KHACHHANGs.Select(k => k).ToList<KHACHHANG>();
        }

        public List<string> load_GioiTinh(string maKH)
        {
            List<string> kh = new List<string>();
            var gioitinh = (from gt in QLNPP_PS.KHACHHANGs
                          where gt.MAKH == maKH
                          select gt.GIOITINHKH).ToList();
            kh.AddRange(gioitinh);
            return kh;
        }

        #endregion

        #region Load dữ liệu khách hàng theo đăng ký CTTB - CTTL

        public IQueryable load_TenKH()
        {
            var kh = from k in QLNPP_PS.KHACHHANGs select new { k.MAKH, k.MAQUANHUYEN, k.HOTENKH, k.LOAIKHACHHANG, k.NGAYSINHKH, k.GIOITINHKH, k.DIACHIKH, k.SODIENTHOAIKH };
            return kh;
        }

        #endregion

        #region Thêm xóa sửa khách hàng
        public bool insert_KH(string maKH, string maQH, string tenKH, string loaiKH, string ngaySinh, string gioiTinh, string diaChi, string sDT)
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
        public bool delete_KH(string maKH)
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
        public bool update_KH(string maKH, string maQH, string tenKH, string loaiKH, string ngaySinh, string gioiTinh, string diaChi, string sDT)
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
