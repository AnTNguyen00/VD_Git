using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class DK_CTTB_CTTL_DALBLL
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();

        #region Load dữ liệu đăng ký CTTB - CTTL
        public IQueryable load_DK_TBTL()
        {
            var dk_tbtl = from dk_cttb_cttl in QLNPP_PS.DK_CTTB_CTTLs
                       select new
                       {
                           dk_cttb_cttl.MACT,
                           dk_cttb_cttl.MAKH,
                           dk_cttb_cttl.NGAYDK,
                           dk_cttb_cttl.DIEMTL_THUC,
                           dk_cttb_cttl.TRANGTHAI

                       };
            return dk_tbtl;
        }

        public List<string> load_TrangThai(string maCT)
        {
            List<string> tbtl = new List<string>();
            var trangthai = (from tt in QLNPP_PS.DK_CTTB_CTTLs
                            where tt.MACT == maCT
                            select tt.TRANGTHAI).ToList();
            tbtl.AddRange(trangthai);
            return tbtl;
        }

        #endregion

        #region thêm xóa sửa đăng ký CTTB - CTTL

        public int insert_DK_CTTB(string mact, string makh,DateTime ngaydk, float diemtl_thuc, string trangthai)
        {
            DK_CTTB_CTTL DK_TBTL = new DK_CTTB_CTTL
            {
                MACT = mact,
                MAKH = makh,
                NGAYDK = ngaydk,
                DIEMTL_THUC = diemtl_thuc,
                TRANGTHAI = trangthai,

            };
            try
            {
                QLNPP_PS.DK_CTTB_CTTLs.InsertOnSubmit(DK_TBTL);
                QLNPP_PS.SubmitChanges();
                return 1;
            }

            catch
            {
                return 0;
            }
        }

        public int delete_DK_CTTB(string mact, string makh)
        {
            try
            {
                var DK_TBTL = QLNPP_PS.DK_CTTB_CTTLs.Where(t => t.MACT == mact && t.MAKH == makh).Single();

                QLNPP_PS.DK_CTTB_CTTLs.DeleteOnSubmit(DK_TBTL);
                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int update_DK_CTTB(string mact, string makh, DateTime ngaydk, float diemtl_thuc, string trangthai)
        {
            try
            {
                DK_CTTB_CTTL DK_TBTL = QLNPP_PS.DK_CTTB_CTTLs.Where(t => t.MACT == mact && t.MAKH == makh).FirstOrDefault();
                DK_TBTL.MACT = mact;
                DK_TBTL.MAKH = makh;
                DK_TBTL.NGAYDK = ngaydk;
                DK_TBTL.DIEMTL_THUC = diemtl_thuc;
                DK_TBTL.TRANGTHAI = trangthai;

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
