using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class XuatXu_DALBLL
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();

        #region Load dữ liệu xuất xứ
        public IQueryable load_XuatXu()
        {
            var xuatxu = from xx in QLNPP_PS.XUATXUs select new { xx.MAXUATXU, xx.TENXUATXU, xx.LOAIXUATXU };
            return xuatxu;
        }

        public List<XUATXU> getXuatXu()
        {
            return QLNPP_PS.XUATXUs.Select(k => k).ToList<XUATXU>();
        }

        #endregion

        #region Load dữ liệu xuất xứ theo sản phẩm
        public IQueryable load_TenXuatXu()
        {
            var xuatxu = from xx in QLNPP_PS.XUATXUs select new { xx.MAXUATXU, xx.TENXUATXU, xx.LOAIXUATXU };
            return xuatxu;
        }

        #endregion

        #region Thêm xóa sửa xuất xứ

        public int them_XuatXu(string maXX, string tenXX, string loaiXX)
        {
            XUATXU xuatxu = new XUATXU { MAXUATXU = maXX, TENXUATXU = tenXX, LOAIXUATXU = loaiXX };
            try
            {
                QLNPP_PS.XUATXUs.InsertOnSubmit(xuatxu);
                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int xoa_XuatXu(string maXX)
        {
            try
            {
                var xuatxu = QLNPP_PS.XUATXUs.Where(t => t.MAXUATXU == maXX).Single();

                QLNPP_PS.XUATXUs.DeleteOnSubmit(xuatxu);
                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int sua_XuatXu(string maXX, string tenX, string loaiXX)
        {
            try
            {
                XUATXU xuatxu = QLNPP_PS.XUATXUs.Where(k => k.MAXUATXU == maXX).FirstOrDefault();
                xuatxu.TENXUATXU = tenX;
                xuatxu.LOAIXUATXU = loaiXX;

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
