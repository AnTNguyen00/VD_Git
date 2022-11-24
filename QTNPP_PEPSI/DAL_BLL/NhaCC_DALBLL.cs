using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class NhaCC_DALBLL
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();

        #region Load dữ liệu nhà cung cấp

        public IQueryable load_NhaCC()
        {
            var nhacc = from ncc in QLNPP_PS.NHACUNGCAPs select new { ncc.MANCC, ncc.MAQUANHUYEN, ncc.TENNHACUNGCAP, ncc.DIACHI, ncc.SDT };
            return nhacc;
        }

        public List<NHACUNGCAP> getNhaCC()
        {
            return QLNPP_PS.NHACUNGCAPs.Select(k => k).ToList<NHACUNGCAP>();
        }

        #endregion

        #region Load dữ liệu nhà cung cấp theo hóa đơn nhập
        public IQueryable load_TenNCC()
        {
            var ncc = from Ncc in QLNPP_PS.NHACUNGCAPs select new { Ncc.MANCC, Ncc.TENNHACUNGCAP };
            return ncc;
        }

        public IQueryable load_TenNCC1(string maPN)
        {
            var ncc = from pn1 in QLNPP_PS.NHACUNGCAPs
                      join Hd in QLNPP_PS.PHIEUNHAPHANGs
                          on pn1.MANCC equals Hd.MANCC
                      where Hd.MAPN == maPN
                      select new { pn1.TENNHACUNGCAP, pn1.MANCC };
            return ncc;
        }

        #endregion

        #region Thêm xóa sửa nhà cung cấp

        public int them_NhaCC(string maNCC, string maQH, string tenNCC, string diaChi, string sDT)
        {
            NHACUNGCAP ncc = new NHACUNGCAP { MANCC = maNCC, MAQUANHUYEN = maQH, TENNHACUNGCAP = tenNCC, DIACHI = diaChi, SDT = sDT };
            try
            {
                QLNPP_PS.NHACUNGCAPs.InsertOnSubmit(ncc);
                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int xoa_NhaCC(string maNCC)
        {
            try
            {
                var ncc = QLNPP_PS.NHACUNGCAPs.Where(t => t.MANCC == maNCC).Single();

                QLNPP_PS.NHACUNGCAPs.DeleteOnSubmit(ncc);
                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int sua_NhaCC(string maNCC, string maQH, string tenNCC, string diaChi, string sDT)
        {
            try
            {
                NHACUNGCAP ncc = QLNPP_PS.NHACUNGCAPs.Where(k => k.MANCC == maNCC).FirstOrDefault();
                ncc.MAQUANHUYEN = maQH;
                ncc.TENNHACUNGCAP = tenNCC;
                ncc.DIACHI = diaChi;
                ncc.SDT = sDT;

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
