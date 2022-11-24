using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class HangSanXuat_DALBLL
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();

        #region Load dữ liệu hãng sản xuất
        public IQueryable load_HangSX()
        {
            var hangsx = from hsx in QLNPP_PS.HANGSANXUATs select new { hsx.MAHSX, hsx.TENHSX };
            return hangsx;
        }

        public List<HANGSANXUAT> getHangSX()
        {
            return QLNPP_PS.HANGSANXUATs.Select(k => k).ToList<HANGSANXUAT>();
        }

        #endregion

        #region Load dữ liệu hãng sản xuất theo sản phẩm
        public IQueryable load_TenHSX()
        {
            var hangsx = from hsx in QLNPP_PS.HANGSANXUATs select new { hsx.MAHSX, hsx.TENHSX };
            return hangsx;
        }

        #endregion

        #region Thêm xóa sửa hãng sản xuất

        public int them_HangSX(string maHangSX, string tenHangSX)
        {
            HANGSANXUAT hsx = new HANGSANXUAT { MAHSX = maHangSX, TENHSX = tenHangSX };
            try
            {
                QLNPP_PS.HANGSANXUATs.InsertOnSubmit(hsx);
                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int xoa_HangSX(string maHangSX)
        {
            try
            {
                var hsx = QLNPP_PS.HANGSANXUATs.Where(t => t.MAHSX == maHangSX).Single();

                QLNPP_PS.HANGSANXUATs.DeleteOnSubmit(hsx);
                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int sua_HangSX(string maHangSX, string tenHangSX)
        {
            try
            {
                HANGSANXUAT hsx = QLNPP_PS.HANGSANXUATs.Where(k => k.MAHSX == maHangSX).FirstOrDefault();
                hsx.TENHSX = tenHangSX;

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
