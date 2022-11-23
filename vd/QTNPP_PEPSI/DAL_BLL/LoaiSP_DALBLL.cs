using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class LoaiSP_DALBLL
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();

        #region Load dữ liệu loại sản phẩm
        public IQueryable load_LoaiSP()
        {
            var loaisp = from lsp in QLNPP_PS.LOAISANPHAMs select new { lsp.MALOAISANPHAM, lsp.MAPAL, lsp.TENLOAISANPHAM };
            return loaisp;
        }

        public List<LOAISANPHAM> getLoaiSP()
        {
            return QLNPP_PS.LOAISANPHAMs.Select(k => k).ToList<LOAISANPHAM>();
        }

        #endregion

        #region Load dữ liệu loại sản phẩm theo sản phẩm
        public IQueryable load_TenLoaiSP()
        {
            var loaisp = from lsp in QLNPP_PS.LOAISANPHAMs select new { lsp.MALOAISANPHAM, lsp.MAPAL, lsp.TENLOAISANPHAM };
            return loaisp;
        }

        #endregion

        #region Load dữ liệu loại sản phẩm theo hóa đơn bán
        public IQueryable load_TenLoaiSP1()
        {
            var loaisp = from lsp in QLNPP_PS.LOAISANPHAMs select new { lsp.MALOAISANPHAM, lsp.MAPAL, lsp.TENLOAISANPHAM };
            return loaisp;
        }

        #endregion

        #region Load dữ liệu loại sản phẩm theo hóa đơn nhập
        public IQueryable load_TenLoaiSP2()
        {
            var loaisp = from lsp in QLNPP_PS.LOAISANPHAMs select new { lsp.MALOAISANPHAM, lsp.MAPAL, lsp.TENLOAISANPHAM };
            return loaisp;
        }

        #endregion

        #region Load dữ liệu loại sản phẩm theo hóa đơn xuất
        public IQueryable load_TenLoaiSP3()
        {
            var loaisp = from lsp in QLNPP_PS.LOAISANPHAMs select new { lsp.MALOAISANPHAM, lsp.MAPAL, lsp.TENLOAISANPHAM };
            return loaisp;
        }

        #endregion

        #region Thêm xóa sửa loại sản phẩm

        public int them_LoaiSP(string maLoai, string tenLoai, string maPal)
        {
            LOAISANPHAM lsp = new LOAISANPHAM { MAPAL = maPal, TENLOAISANPHAM = tenLoai, MALOAISANPHAM = maLoai };
            try
            {
                QLNPP_PS.LOAISANPHAMs.InsertOnSubmit(lsp);
                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int xoa_LoaiSP(string maLoai)
        {
            try
            {
                var lsp = QLNPP_PS.LOAISANPHAMs.Where(t => t.MALOAISANPHAM == maLoai).Single();

                QLNPP_PS.LOAISANPHAMs.DeleteOnSubmit(lsp);
                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int sua_LoaiSP(string maLoai, string tenLoai, string maPal)
        {
            try
            {
                LOAISANPHAM lsp = QLNPP_PS.LOAISANPHAMs.Where(k => k.MALOAISANPHAM == maLoai).FirstOrDefault();
                lsp.TENLOAISANPHAM = tenLoai;
                lsp.MAPAL = maPal;

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
