using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class PhanQuyen_DALPLL
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();

        #region Load dữ liệu phân quyền
        public IQueryable load_QuyenChuaCo(string maNhomQuyen)
        {
            return (from pq in QLNPP_PS.PHANQUYENs
                    join dmmh in QLNPP_PS.DANHMUCMANHINHs on pq.MADMMH equals dmmh.MADMMH
                    where (pq.MANHOMNV == maNhomQuyen && pq.COQUYEN == false)
                    select new { dmmh.MADMMH, dmmh.TENMANHINH });
        }

        public IQueryable load_QuyenCo(string maNhomQuyen)
        {
            return (from tk in QLNPP_PS.PHANQUYENs
                    where (tk.MANHOMNV == maNhomQuyen && tk.COQUYEN == true)
                    select new { tk.DANHMUCMANHINH.MADMMH, tk.DANHMUCMANHINH.TENMANHINH });
        }

        public bool capnhat_Quyen(string maNV, string maNhomNV)
        {
            NHANVIEN nhanvien = QLNPP_PS.NHANVIENs.Where(k => k.MANV == maNV).FirstOrDefault();
            if (nhanvien != null)
            {
                nhanvien.MANHOMNV = maNhomNV;
                QLNPP_PS.SubmitChanges();
                return true;
            }
            return false;
        }

        #endregion

        #region Load dữ liệu phân quyền cho trang chủ
        public List<PHANQUYEN> load_QuyenChuaCo1(string maNhomQuyen)
        {
            List<PHANQUYEN> pq = new List<PHANQUYEN>();
            var DMMH = (from dm in QLNPP_PS.PHANQUYENs
                        where (dm.MANHOMNV == maNhomQuyen && dm.COQUYEN == false)
                        select dm).ToList();
            pq.AddRange(DMMH);
            return pq;
        }

        #endregion

        #region Thêm xóa quyền

        public void them_Quyen(string maNhomQuyen, string maDMMH)
        {
            PHANQUYEN PQ = QLNPP_PS.PHANQUYENs.Where(t => t.MANHOMNV == maNhomQuyen && t.MADMMH == maDMMH).FirstOrDefault();
            
            PQ.COQUYEN = true;
            QLNPP_PS.SubmitChanges();
        }
        public void xoa_Quyen(string maNhomQuyen, string maDMMH)
        {
            PHANQUYEN PQ = QLNPP_PS.PHANQUYENs.Where(t => t.MANHOMNV == maNhomQuyen && t.MADMMH == maDMMH).FirstOrDefault();
            
            PQ.COQUYEN = false;
            QLNPP_PS.SubmitChanges();
        }

        #endregion
    }
}
