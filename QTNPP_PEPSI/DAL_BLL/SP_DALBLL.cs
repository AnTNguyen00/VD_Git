using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class SP_DALBLL
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();

        #region Load dữ liệu sản phẩm theo CTTB - CTTL
        public IQueryable load_TenSP()
        {
            var sp = from sanpham in QLNPP_PS.SANPHAMs
                     select new
                     {
                         sanpham.MASP,
                         sanpham.MALOAISANPHAM,
                         sanpham.MAHSX,
                         sanpham.MAXUATXU,
                         sanpham.TENSANPHAM,
                         sanpham.HINHSP,
                         sanpham.THANHPHAN,
                         sanpham.CONGDUNG,
                         sanpham.BAOQUAN,
                         sanpham.GHICHUSP,
                         sanpham.DVT,
                         sanpham.SOLOSP,
                         sanpham.NGAYSANXUAT,
                         sanpham.HANSUDUNG,
                         sanpham.DONGIASP,
                         sanpham.SOLUONGTON
                     };
            return sp;
        }

        #endregion
    }
}
