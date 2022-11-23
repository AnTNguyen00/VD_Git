using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class CTTB_DALBLL
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();

        #region Load dữ liệu CTTB - CTTL
        public List<CTTB_CTTL> getTBTL()
        {
            return QLNPP_PS.CTTB_CTTLs.Select(k => k).ToList<CTTB_CTTL>();
        }

        public IQueryable load_TBTL()
        {
            var tbtl = from cttb_cttl in QLNPP_PS.CTTB_CTTLs
                     select new
                     {
                         cttb_cttl.MACT,
                         cttb_cttl.TENCT,
                         cttb_cttl.SOSUAT,
                         cttb_cttl.MASP,
                         cttb_cttl.NGAYBD,
                         cttb_cttl.NGAYKT,
                         cttb_cttl.DIEMDAT,
                         cttb_cttl.HINHANH
                       
                     };
            return tbtl;
        }
        #endregion

        #region Load dữ liệu CTTB - CTTL theo đăng ký CTTB - CTTL
        public IQueryable load_TenTBTL()
        {
            var tbtl = from cttb_cttl in QLNPP_PS.CTTB_CTTLs
                       select new
                       {
                           cttb_cttl.MACT,
                           cttb_cttl.TENCT,
                           cttb_cttl.SOSUAT,
                           cttb_cttl.MASP,
                           cttb_cttl.NGAYBD,
                           cttb_cttl.NGAYKT,
                           cttb_cttl.DIEMDAT,
                           cttb_cttl.HINHANH

                       };
            return tbtl;
        }

        #endregion

        #region thêm xóa sửa CTTB - CTTL
        public int insert_CTTB(string mact, string tenct, int sosuat, string masp,DateTime ngaybd, DateTime ngaykt, decimal diemdat, string hinhanh)
        {
            CTTB_CTTL TBTL = new CTTB_CTTL
            {
                MACT = mact,
                TENCT = tenct,
                SOSUAT = sosuat,
                MASP = masp,
                NGAYBD = ngaybd,
                NGAYKT = ngaykt,
                DIEMDAT = diemdat,
                HINHANH = hinhanh,

            };
            try
            {
                QLNPP_PS.CTTB_CTTLs.InsertOnSubmit(TBTL);
                QLNPP_PS.SubmitChanges();
                return 1;
            }

            catch
            {
                return 0;
            }
        }

        public int delete_CTTB(string MaCT)
        {
            try
            {
                var TBTL = QLNPP_PS.CTTB_CTTLs.Where(t => t.MACT == MaCT).Single();

                QLNPP_PS.CTTB_CTTLs.DeleteOnSubmit(TBTL);
                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int update_CTTB(string mact, string tenct, int sosuat, string masp, DateTime ngaybd, DateTime ngaykt, decimal diemdat, string hinhanh)
        {
            try
            {
                CTTB_CTTL TBTL = QLNPP_PS.CTTB_CTTLs.Where(t => t.MACT == mact).FirstOrDefault();
                TBTL.MACT = mact;
                TBTL.TENCT = tenct;
                TBTL.SOSUAT = sosuat;
                TBTL.MASP = masp;
                TBTL.NGAYBD = ngaybd;
                TBTL.NGAYKT = ngaykt;
                TBTL.DIEMDAT = diemdat;
                TBTL.HINHANH = hinhanh;

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
