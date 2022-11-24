using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class PhanQuyen_DALBLL
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();

        #region Load dữ liệu phân quyền cho trang chủ
        public List<PHANQUYEN> load_QuyenChuaCo(string maNhomQuyen)
        {
            List<PHANQUYEN> pq = new List<PHANQUYEN>();
            var DMMH = (from dm in QLNPP_PS.PHANQUYENs
                        where (dm.MANHOMNV == maNhomQuyen && dm.COQUYEN == false)
                        select dm).ToList();
            pq.AddRange(DMMH);
            return pq;
        }

        #endregion

    }
}
