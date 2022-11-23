using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class TinhThanh_DALBLL
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();

        #region Load dữ liệu tỉnh thành
        public List<TINHTHANH> load_TinhThanh()
        {
            return QLNPP_PS.TINHTHANHs.Select(k => k).ToList<TINHTHANH>();
        }

        #endregion

        #region Thêm xóa tỉnh thành

        public bool them_TinhThanh(string maTT, string tenTT)
        {
            try
            {
                TINHTHANH tinhthanh = new TINHTHANH();
                tinhthanh.MATINHTHANH = maTT;
                tinhthanh.TENTINHTHANH = tenTT;
                QLNPP_PS.TINHTHANHs.InsertOnSubmit(tinhthanh);
                QLNPP_PS.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool xoa_TinhThanh(string maTT)
        {
            try
            {
                TINHTHANH tinhthanh = QLNPP_PS.TINHTHANHs.Where(t => t.MATINHTHANH == maTT).FirstOrDefault();
                QLNPP_PS.TINHTHANHs.DeleteOnSubmit(tinhthanh);
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
