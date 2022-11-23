using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class HoaDonNhap_DALBLL
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();

        #region Load dữ liệu hóa đơn nhập
        public IQueryable load_HDN()
        {
            var pn = from phieunhaphang in QLNPP_PS.PHIEUNHAPHANGs select new { phieunhaphang.MAPN, phieunhaphang.NGAYNHAP };
            return pn;
        }

        public IQueryable load_MAPN(string maPN)
        {
            return (from pn in QLNPP_PS.PHIEUNHAPHANGs.Where(t => t.MAPN.Contains(maPN)) select new { pn.MAPN, pn.NGAYNHAP });
        }

        public List<PHIEUNHAPHANG> getHDN()
        {
            return QLNPP_PS.PHIEUNHAPHANGs.Select(k => k).ToList<PHIEUNHAPHANG>();
        }

        public List<string> load_GhiChu(string maPN)
        {
            List<string> pn = new List<string>();
            var ghichu = (from gc in QLNPP_PS.PHIEUNHAPHANGs
                          where gc.MAPN == maPN
                          select gc.GHICHUN).ToList();
            pn.AddRange(ghichu);
            return pn;
        }

        public List<bool?> load_TrangThai(string maPN)
        {
            List<bool?> pn = new List<bool?>();
            var trangthai = (from gc in QLNPP_PS.PHIEUNHAPHANGs
                          where gc.MAPN == maPN
                          select gc.TRANGTHAI).ToList();
            pn.AddRange(trangthai);
            return pn;
        }

        #endregion

        #region Load dữ liệu CT hóa đơn nhập

        public IQueryable load_CTHDN(string maPN)
        {
            var ctpn = from ctphieunhap in QLNPP_PS.CHITIETPHIEUNHAPs
                       join sp in QLNPP_PS.SANPHAMs on ctphieunhap.MASP equals sp.MASP
                       where ctphieunhap.MAPN == maPN
                       select new
                       {
                           ctphieunhap.MASP,
                           sp.TENSANPHAM,
                           sp.DVT,
                           ctphieunhap.DONGIABAN,
                           ctphieunhap.SOLUONGNHAP,
                           ctphieunhap.THANHTIEN

                       };
            return ctpn;
        }

        #endregion

        #region Xóa hóa đơn nhập 
        public int xoa_HDN(string maPN)
        {
            try
            {
                var pn = QLNPP_PS.PHIEUNHAPHANGs.Where(t => t.MAPN == maPN).Single();

                QLNPP_PS.PHIEUNHAPHANGs.DeleteOnSubmit(pn);
                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        #endregion

        #region Xóa sửa CT hóa đơn nhập

        public void xoa_CTHDN(string maPN, string maSP)
        {
            CHITIETPHIEUNHAP ctpn = QLNPP_PS.CHITIETPHIEUNHAPs.Where(t => t.MAPN == maPN && t.MASP == maSP).FirstOrDefault();
            QLNPP_PS.CHITIETPHIEUNHAPs.DeleteOnSubmit(ctpn);
            QLNPP_PS.SubmitChanges();
        }

        public int sua_CTHDN(string maPN, string maSP, int SL, decimal donGia, decimal thanhTien)
        {
            try
            {
                CHITIETPHIEUNHAP ctpnt = QLNPP_PS.CHITIETPHIEUNHAPs.Where(t => t.MAPN == maPN && t.MASP == maSP).FirstOrDefault();

                ctpnt.MAPN = maPN;
                ctpnt.MASP = maSP;
                ctpnt.SOLUONGNHAP = SL;
                ctpnt.DONGIABAN = donGia;
                ctpnt.THANHTIEN = thanhTien;

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
