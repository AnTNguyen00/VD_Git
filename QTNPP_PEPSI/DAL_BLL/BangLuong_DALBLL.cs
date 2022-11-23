using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class BangLuong_DALBLL
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();

        #region Load dữ liệu bảng lương
        public IQueryable load_BangLuong()
        {
            var bluong = from bl in QLNPP_PS.BANGLUONGs select new { bl.MABANGLUONG, bl.MANV, bl.LUONGTHUCTE, bl.NGAYAPDUNG, bl.GHICHUBL };
            return bluong;
        }

        public IQueryable load_Ten(string ma)
        {
            var query = from c in QLNPP_PS.NHANVIENs
                        where c.MANV == ma
                        select c.HOTENNV;
            return query;
        }

        public IQueryable load_LuongCB(string ma)
        {
            var query = from c in QLNPP_PS.NHANVIENs
                        where c.MANV == ma
                        select c.MUCLUONGCOBAN;
            return query;
        }

        public IQueryable load_HeSoLuong(string ma)
        {
            var query = from c in QLNPP_PS.NHANVIENs
                        join ct in QLNPP_PS.CHITIETBACLUONGs
                         on c.MANV equals ct.MANV
                        join heso in QLNPP_PS.BACLUONGs
                         on ct.MABAC equals heso.MABAC
                        where c.MANV == ma
                        select heso.HESO;
            return query;
        }

        public IQueryable load_TuNgay(string ma)
        {
            var query = from c in QLNPP_PS.NHANVIENs
                        join ct in QLNPP_PS.CHITIETBACLUONGs
                         on c.MANV equals ct.MANV
                        where c.MANV == ma
                        select ct.TUNGAY;
            return query;
        }

        public IQueryable load_DenNgay(string ma)
        {
            var query = from c in QLNPP_PS.NHANVIENs
                        join ct in QLNPP_PS.CHITIETBACLUONGs
                         on c.MANV equals ct.MANV
                        where c.MANV == ma
                        select ct.DENNGAY;
            return query;
        }

        #endregion

        #region Thêm xóa sửa bảng lương

        public int insert_BangLuong(string maBL, string maNV, decimal luongTT, DateTime ngayApDung, string ghiChu)
        {
            BANGLUONG bl = new BANGLUONG { MABANGLUONG = maBL, MANV = maNV, LUONGTHUCTE = luongTT, NGAYAPDUNG = ngayApDung, GHICHUBL = ghiChu };
            try
            {
                QLNPP_PS.BANGLUONGs.InsertOnSubmit(bl);
                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int delete_BangLuong(string maBL)
        {
            try
            {
                var query = QLNPP_PS.BANGLUONGs.Where(p => p.MABANGLUONG == maBL).Single();
                
                QLNPP_PS.BANGLUONGs.DeleteOnSubmit(query);
                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int update_BangLuong(string maBL, DateTime ngayApDung, string ghiChu)
        {
            try
            {
                BANGLUONG bl = QLNPP_PS.BANGLUONGs.Where(p => p.MABANGLUONG == maBL).SingleOrDefault();
                bl.NGAYAPDUNG = ngayApDung;
                bl.GHICHUBL = ghiChu;

                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        #endregion
    }
}
