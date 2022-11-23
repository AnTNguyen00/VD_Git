using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class HoaDonXuat_DALBLL
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();

        #region Load dữ liệu hóa đơn xuất
        public IQueryable load_HDX()
        {
            var px = from phieuxuathang in QLNPP_PS.PHIEUXUATHANGs select new { phieuxuathang.MAPX, phieuxuathang.NGAYXUAT };
            return px;
        }

        public IQueryable load_MAHDX(string maPX)
        {
            return (from px in QLNPP_PS.PHIEUXUATHANGs.Where(t => t.MAPX.Contains(maPX)) select new { px.MAPX, px.NGAYXUAT });
        }

        public List<PHIEUXUATHANG> getHDX()
        {
            return QLNPP_PS.PHIEUXUATHANGs.Select(k => k).ToList<PHIEUXUATHANG>();
        }

        public List<string> load_GhiChu(string maPX)
        {
            List<string> px = new List<string>();
            var ghichu = (from gc in QLNPP_PS.PHIEUXUATHANGs
                          where gc.MAPX == maPX
                          select gc.GHICHUX).ToList();
            px.AddRange(ghichu);
            return px;
        }

        public List<bool?> load_TrangThai(string maPX)
        {
            List<bool?> px = new List<bool?>();
            var trangthai = (from tt in QLNPP_PS.PHIEUXUATHANGs
                             where tt.MAPX == maPX
                             select tt.TRANGTHAI).ToList();
            px.AddRange(trangthai);
            return px;
        }

        #endregion

        #region Load dữ liệu CT hóa đơn xuất
        public IQueryable load_CTHDX(string maPX)
        {
            return (from ctphieuxuat in QLNPP_PS.CHITIETPHIEUXUATs
                    join sp in QLNPP_PS.SANPHAMs on ctphieuxuat.MASP equals sp.MASP
                    where ctphieuxuat.MAPX == maPX
                    select new { ctphieuxuat.MASP, sp.TENSANPHAM, sp.DVT, ctphieuxuat.DONGIABAN, ctphieuxuat.SOLUONGNHAP, ctphieuxuat.THANHTIEN });
        }

        #endregion

        #region Xóa sửa hóa đơn xuất
        public int xoa_HDX(string maPX)
        {
            try
            {
                var px = QLNPP_PS.PHIEUXUATHANGs.Where(t => t.MAPX == maPX).Single();

                QLNPP_PS.PHIEUXUATHANGs.DeleteOnSubmit(px);
                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public void sua_HDX(string maPX, string ghiChu, bool trangThai)
        {
            PHIEUXUATHANG pxh = QLNPP_PS.PHIEUXUATHANGs.Where(t => t.MAPX == maPX).FirstOrDefault();
            pxh.GHICHUX = ghiChu;
            pxh.TRANGTHAI = trangThai;
            QLNPP_PS.SubmitChanges();
        }

        #endregion

        #region Xóa CT hóa đơn xuất
        public void xoa_CTHDX(string maPX, string maSP)
        {
            CHITIETPHIEUXUAT ctpx = QLNPP_PS.CHITIETPHIEUXUATs.Where(t => t.MAPX == maPX && t.MASP == maSP).FirstOrDefault();
            QLNPP_PS.CHITIETPHIEUXUATs.DeleteOnSubmit(ctpx);
            QLNPP_PS.SubmitChanges();
        }

        #endregion
    }
}
