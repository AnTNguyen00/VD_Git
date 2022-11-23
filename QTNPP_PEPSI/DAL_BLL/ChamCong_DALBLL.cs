using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class ChamCong_DALBLL
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();

        #region Load dữ liệu chấm công
        public IQueryable load_ChamCong()
        {
            return (from cc in QLNPP_PS.CHAMCONGs
                    join nv in QLNPP_PS.NHANVIENs on cc.MANV equals nv.MANV
                    select new { cc.MANV, cc.MACHAMCONG, nv.HOTENNV, cc.THANG, cc.NAM, cc.SONGAYLAMVIEC });
        }

        public IQueryable load_ChamCongNV(string maNV)
        {
            return (from chcong in QLNPP_PS.CHAMCONGs
                    where chcong.MANV == maNV
                    select new { chcong.MACHAMCONG, chcong.MANV, chcong.THANG, chcong.NAM, chcong.SONGAYLAMVIEC });
        }

        public void chamCong(string maCC, string maNV, int soNgayLam)
        {
            CHAMCONG cc = QLNPP_PS.CHAMCONGs.Where(t => t.MACHAMCONG == maCC && t.MANV == maNV).FirstOrDefault();
            cc.SONGAYLAMVIEC = soNgayLam + 1;

            QLNPP_PS.SubmitChanges();
        }

        #endregion

        #region Thêm xóa chấm công

        public void insert_ChamCong(string maCC, string maNV, int thang, int nam, int soNgayLam)
        {
            CHAMCONG d = new CHAMCONG { MACHAMCONG = maCC, MANV = maNV, THANG = thang, NAM = nam, SONGAYLAMVIEC = soNgayLam };

            QLNPP_PS.CHAMCONGs.InsertOnSubmit(d);
            QLNPP_PS.SubmitChanges();
        }

        public void delete_ChamCong(string maCC, string maNV)
        {
            CHAMCONG diem = QLNPP_PS.CHAMCONGs.Where(t => (t.MACHAMCONG == maCC && t.MANV == maNV)).FirstOrDefault();
            
            QLNPP_PS.CHAMCONGs.DeleteOnSubmit(diem);
            QLNPP_PS.SubmitChanges();
        }

        #endregion
    }
}
