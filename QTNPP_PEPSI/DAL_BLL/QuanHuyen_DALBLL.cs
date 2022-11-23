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

        #region Load dữ liệu quận huyện

        public IQueryable load_QuanHuyen()
        {
            var quanhuyen = from qh in QLNPP_PS.QUANHUYENs select new { qh.MAQUANHUYEN, qh.TENQUANHUYEN, qh.MATINHTHANH };
            return quanhuyen;
        }

        public List<QUANHUYEN> getQuanHuyenLst()
        {
            return QLNPP_PS.QUANHUYENs.Select(k => k).ToList<QUANHUYEN>();
        }

        public IQueryable getQuanHuyen1(string maTinhThanh)
        {
            var quanhuyen = from qh in QLNPP_PS.QUANHUYENs where qh.MATINHTHANH == maTinhThanh select new { qh.MAQUANHUYEN, qh.MATINHTHANH, qh.TENQUANHUYEN };
            return quanhuyen;
        }

        #endregion

        #region Load dữ liệu quận huyện theo nhà cung cấp
        public IQueryable load_TenQuanHuyen()
        {
            var quanhuyen = from qh in QLNPP_PS.QUANHUYENs select new { qh.MAQUANHUYEN, qh.TENQUANHUYEN, qh.MATINHTHANH };
            return quanhuyen;
        }

        #endregion

        #region Thêm xóa quận huyện

        public bool insertQuanHuyen(string maQH, string maTT, string tenQH)
        {
            try
            {
                QUANHUYEN quanhuyen = new QUANHUYEN();
                quanhuyen.MAQUANHUYEN = maQH;
                quanhuyen.MATINHTHANH = maTT;
                quanhuyen.TENQUANHUYEN = tenQH;
                QLNPP_PS.QUANHUYENs.InsertOnSubmit(quanhuyen);
                QLNPP_PS.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteQuanHuyen(string maQH)
        {
            try
            {
                QUANHUYEN quanhuyen = QLNPP_PS.QUANHUYENs.Where(t => t.MAQUANHUYEN == maQH).FirstOrDefault();
                QLNPP_PS.QUANHUYENs.DeleteOnSubmit(quanhuyen);
                QLNPP_PS.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
