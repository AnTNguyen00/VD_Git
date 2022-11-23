using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class QuanHuyen_DALBLL
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();

        #region Load dữ liệu quận huyện theo khách hàng
        public IQueryable load_TenQuanHuyen()
        {
            var quanhuyen = from qh in QLNPP_PS.QUANHUYENs select new { qh.MAQUANHUYEN, qh.TENQUANHUYEN, qh.MATINHTHANH };
            return quanhuyen;
        }

        #endregion
    }
}
