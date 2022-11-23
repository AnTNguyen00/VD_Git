using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class BacLuong_DALBLL
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();

        #region Load dữ liệu bậc lương
        public IQueryable load_BacLuong()
        {
            var bacl = from bl in QLNPP_PS.BACLUONGs select bl;
            return bacl;
        }

        public IQueryable load_CTBacLuong()
        {
            var ctbac = from bacluong in QLNPP_PS.CHITIETBACLUONGs select new { bacluong.MABAC, bacluong.MANV, bacluong.TUNGAY, bacluong.DENNGAY };
            return ctbac;
        }

        public List<BACLUONG> getBacLuong()
        {
            return QLNPP_PS.BACLUONGs.Select(k => k).ToList<BACLUONG>();
        }

        #endregion

        #region Thêm xóa sửa bậc lương
        public int insert_Bac(string maBac, string tenBac, double heSo)
        {
            BACLUONG bac = new BACLUONG { MABAC = maBac, TENBAC = tenBac, HESO = heSo };
            try
            {
                QLNPP_PS.BACLUONGs.InsertOnSubmit(bac);
                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int delete_Bac(string maBac)
        {
            try
            {
                var bac = QLNPP_PS.BACLUONGs.Where(t => t.MABAC == maBac).Single();

                QLNPP_PS.BACLUONGs.DeleteOnSubmit(bac);
                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int update_Bac(string maBac, string tenBac, double heSo)
        {
            try
            {
                BACLUONG bac = QLNPP_PS.BACLUONGs.Where(t => t.MABAC == maBac).FirstOrDefault();
                bac.TENBAC = tenBac;
                bac.HESO = heSo;

                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region Thêm xóa sửa CT bậc lương

        public int insert_CTBac(string maBac, string maNV, DateTime tuNgay, DateTime denNgay)
        {
            CHITIETBACLUONG ctbac = new CHITIETBACLUONG { MABAC = maBac, MANV = maNV, TUNGAY = tuNgay, DENNGAY = denNgay };
            try
            {
                QLNPP_PS.CHITIETBACLUONGs.InsertOnSubmit(ctbac);
                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int delete_CTBac(string maBac, string maNV)
        {
            try
            {
                var ctbac = QLNPP_PS.CHITIETBACLUONGs.Where(t => t.MABAC == maBac && t.MANV == maNV).Single();

                QLNPP_PS.CHITIETBACLUONGs.DeleteOnSubmit(ctbac);
                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int update_CTBL(string maBac, string maNV, DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                CHITIETBACLUONG ctbac = QLNPP_PS.CHITIETBACLUONGs.Where(t => t.MABAC == maBac & t.MANV == maNV).FirstOrDefault();
                ctbac.TUNGAY = tuNgay;
                ctbac.DENNGAY = denNgay;

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
