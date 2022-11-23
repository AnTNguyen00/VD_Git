using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class HoaDonBan_DALBLL
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();

        int thanhTien, VAT, tongTien;

        public int tinhTienHDB(int gia, int soLuong)
        {
            return thanhTien = soLuong * gia;
        }

        public int tinhVAT(int thanh_Tien)
        {
            VAT = thanhTien * 10 / 100;
            return VAT;
        }

        public int tinhThanhTien(int thanh_Tien, int vat)
        {
            tongTien = thanh_Tien + vat;
            return tongTien;
        }


        #region Load dữ liệu hóa đơn bán
        public IQueryable load_HDB()
        {
            var hdb = from hoadonban in QLNPP_PS.HOADONBANs select new { hoadonban.MAHDB, hoadonban.NGAYLAPBAN };
            return hdb;
        }

        public List<HOADONBAN> getHDB()
        {
            return QLNPP_PS.HOADONBANs.Select(k => k).ToList<HOADONBAN>();
        }

        public List<HOADONBAN> load_VAT(string mhd)
        {
            List<HOADONBAN> sp = new List<HOADONBAN>();
            var DVT = (from vat in QLNPP_PS.HOADONBANs
                       where vat.MAHDB == mhd
                       select vat).ToList();
            sp.AddRange(DVT);
            return sp;
        }

        public IQueryable load_MAHDB(string maHDB)
        {
            return (from hdb in QLNPP_PS.HOADONBANs.Where(t => t.MAHDB.Contains(maHDB)) select new { hdb.MAHDB, hdb.NGAYLAPBAN });
        }

        #endregion

        #region Load dữ liệu CT hóa đơn bán
        public IQueryable load_CTHDB(string mahd)
        {
            return (from cthoadonban in QLNPP_PS.CHITIETHOADONBANs
                    join sp in QLNPP_PS.SANPHAMs on cthoadonban.MASP equals sp.MASP
                    where cthoadonban.MAHDB == mahd
                    select new { cthoadonban.MASP, sp.TENSANPHAM, sp.DVT, sp.DONGIASP, cthoadonban.SOLUONGBAN, cthoadonban.THANHTIENBAN });
        }

        #endregion

        #region Xóa CT hóa đơn bán
        public void xoa_CTHDB(string maHD, string maSP)
        {
            CHITIETHOADONBAN cthdb = QLNPP_PS.CHITIETHOADONBANs.Where(t => t.MAHDB == maHD && t.MASP == maSP).FirstOrDefault();
            QLNPP_PS.CHITIETHOADONBANs.DeleteOnSubmit(cthdb);
            QLNPP_PS.SubmitChanges();
        }

        #endregion

        #region Xóa hóa đơn

        public int xoa_HDB(string maHD)
        {
            try
            {
                var hd = QLNPP_PS.HOADONBANs.Where(t => t.MAHDB == maHD).Single();

                QLNPP_PS.HOADONBANs.DeleteOnSubmit(hd);
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
