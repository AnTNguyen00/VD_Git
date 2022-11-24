using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class LoaiKhachHang_DALBLL
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();

        #region Load dữ liệu loại khách hàng

        public IQueryable load_LoaiKH()
        {
            var loaikh = from lkh in QLNPP_PS.LOAIKHACHHANGs select new { lkh.LOAIKHACHHANG1,lkh.TENLOAIKH };
            return loaikh;
        }

        public List<LOAIKHACHHANG> getLoaiKH()
        {
            return QLNPP_PS.LOAIKHACHHANGs.Select(k => k).ToList<LOAIKHACHHANG>();
        }

        #endregion

        #region Load dữ liệu loại theo khách hàng
        public IQueryable load_TenLoaiKH()
        {
            var loaikh = from lkh in QLNPP_PS.LOAIKHACHHANGs select new { lkh.LOAIKHACHHANG1, lkh.TENLOAIKH };
            return loaikh;
        }
        #endregion

        #region Thêm xóa sửa loại khách hàng

        public int insert_LoaiKH(string maKH, string tenKH)
        {
            LOAIKHACHHANG lkh = new LOAIKHACHHANG { LOAIKHACHHANG1 = maKH, TENLOAIKH = tenKH };
            try
            {
                QLNPP_PS.LOAIKHACHHANGs.InsertOnSubmit(lkh);
                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int delete_LoaiKH(string maKH)
        {
            try
            {
                var lkh = QLNPP_PS.LOAIKHACHHANGs.Where(t => t.LOAIKHACHHANG1 == maKH).Single();

                QLNPP_PS.LOAIKHACHHANGs.DeleteOnSubmit(lkh);
                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int update_LoaiKH(string maLKH, string tenLKH)
        {
            try
            {
                LOAIKHACHHANG lkh = QLNPP_PS.LOAIKHACHHANGs.Where(k => k.LOAIKHACHHANG1 == maLKH).FirstOrDefault();
                lkh.TENLOAIKH = tenLKH;

                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        #endregion


        #region khu vực thử nghiệm

        ////---==============--////

        #endregion
    }
}
