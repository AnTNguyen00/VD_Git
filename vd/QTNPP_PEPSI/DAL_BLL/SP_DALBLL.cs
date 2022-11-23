using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class SP_DALBLL
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();

        #region Load dữ liệu sản phẩm
        public List<SANPHAM> getSanPham()
        {
            return QLNPP_PS.SANPHAMs.Select(k => k).ToList<SANPHAM>();
        }

        public IQueryable load_SP()
        {
            var sp = from sanpham in QLNPP_PS.SANPHAMs
                     select new
                     {
                         sanpham.MASP,
                         sanpham.MALOAISANPHAM,
                         sanpham.MAHSX,
                         sanpham.MAXUATXU,
                         sanpham.TENSANPHAM,
                         sanpham.HINHSP,
                         sanpham.THANHPHAN,
                         sanpham.CONGDUNG,
                         sanpham.BAOQUAN,
                         sanpham.GHICHUSP,
                         sanpham.DVT,
                         sanpham.SOLOSP,
                         sanpham.NGAYSANXUAT,
                         sanpham.HANSUDUNG,
                         sanpham.DONGIASP,
                         sanpham.SOLUONGTON
                     };
            return sp;
        }

        public IQueryable load_DVT()
        {
            var slsp = from sl in QLNPP_PS.SANPHAMs select new { sl.DVT };
            return slsp.Distinct();
        }

        #endregion

        #region Load dữ liệu sản phẩm theo hóa đơn bán
        public IQueryable load_TenSP(string maLoai)
        {
            var tensp = from t in QLNPP_PS.SANPHAMs where t.MALOAISANPHAM == maLoai select new { t.TENSANPHAM, t.MASP };
            return tensp;
        }

        public List<SANPHAM> load_SoLuong(string maSP)
        {
            List<SANPHAM> sp = new List<SANPHAM>();
            var soluong = (from sl in QLNPP_PS.SANPHAMs
                           where sl.MASP == maSP
                           select sl).ToList();
            sp.AddRange(soluong);
            return sp;
        }

        public List<SANPHAM> load_DonGia(string maSP)
        {
            List<SANPHAM> sp = new List<SANPHAM>();
            var dongia = (from dg in QLNPP_PS.SANPHAMs
                          where dg.MASP == maSP
                          select dg).ToList();
            sp.AddRange(dongia);
            return sp;
        }

        public List<SANPHAM> load_SoLuongTon(string maSP)
        {
            List<SANPHAM> sp = new List<SANPHAM>();
            var slt = (from dg in QLNPP_PS.SANPHAMs
                       where dg.MASP == maSP
                       select dg).ToList();
            sp.AddRange(slt);
            return sp;
        }

        public IQueryable load_DVT(string maSP)
        {
            var dvt = from s in QLNPP_PS.SANPHAMs where s.MASP == maSP select new { s.DVT };
            return dvt;
        }

        #endregion

        #region Load dữ liệu sản phẩm theo hóa đơn nhập
        public IQueryable load_TenSP1(string maLoai)
        {
            var tensp = from t in QLNPP_PS.SANPHAMs where t.MALOAISANPHAM == maLoai select new { t.TENSANPHAM, t.MASP };
            return tensp;
        }

        public List<SANPHAM> load_SoLuongNhap(string maSP)
        {
            List<SANPHAM> sp = new List<SANPHAM>();
            var soluong = (from sl in QLNPP_PS.SANPHAMs
                           where sl.MASP == maSP
                           select sl).ToList();
            sp.AddRange(soluong);
            return sp;
        }

        public List<SANPHAM> load_SoLuongTonNhap(string maSP)
        {
            List<SANPHAM> sp = new List<SANPHAM>();
            var slt = (from dg in QLNPP_PS.SANPHAMs
                       where dg.MASP == maSP
                       select dg).ToList();
            sp.AddRange(slt);
            return sp;
        }

        public IQueryable load_DVT1(string maSP)
        {
            var dvt = from s in QLNPP_PS.SANPHAMs where s.MASP == maSP select new { s.DVT };
            return dvt;
        }

        #endregion

        #region Load dữ liệu sản phẩm theo hóa đơn xuất
        public IQueryable load_TenSP2(string maLoai)
        {
            var tensp = from t in QLNPP_PS.SANPHAMs where t.MALOAISANPHAM == maLoai select new { t.TENSANPHAM, t.MASP };
            return tensp;
        }

        public List<SANPHAM> load_SoLuongXuat(string maSP)
        {
            List<SANPHAM> sp = new List<SANPHAM>();
            var soluong = (from sl in QLNPP_PS.SANPHAMs
                           where sl.MASP == maSP
                           select sl).ToList();
            sp.AddRange(soluong);
            return sp;
        }

        public List<SANPHAM> load_SoLuongTonXuat(string maSP)
        {
            List<SANPHAM> sp = new List<SANPHAM>();
            var slt = (from dg in QLNPP_PS.SANPHAMs
                       where dg.MASP == maSP
                       select dg).ToList();
            sp.AddRange(slt);
            return sp;
        }

        public IQueryable load_DVT2(string maSP)
        {
            var dvt = from s in QLNPP_PS.SANPHAMs where s.MASP == maSP select new { s.DVT };
            return dvt;
        }

        #endregion

        #region Thêm xóa sửa sản phẩm

        public int them_SP(string masp, string maloaisp, string mahsx, string maxuatxu, string tensp, string hinhsp, string thanhphan
            , string congdung, string baoquan, string ghichu, string dvt, int solosp, DateTime ngaysx, DateTime hansd, decimal dongia, int soluongton)
        {
            SANPHAM SP = new SANPHAM
            {
                MASP = masp,
                MALOAISANPHAM = maloaisp,
                MAHSX = mahsx,
                MAXUATXU = maxuatxu,
                TENSANPHAM = tensp,
                HINHSP = hinhsp,
                THANHPHAN = thanhphan,
                CONGDUNG = congdung,
                BAOQUAN = baoquan,
                GHICHUSP = ghichu,
                DVT = dvt,
                SOLOSP = solosp,
                NGAYSANXUAT = ngaysx,
                HANSUDUNG = hansd,
                DONGIASP = dongia,
                SOLUONGTON = soluongton
            };
            try
            {
                QLNPP_PS.SANPHAMs.InsertOnSubmit(SP);
                QLNPP_PS.SubmitChanges();
                return 1;
            }

            catch
            {
                return 0;
            }
        }

        public int xoa_SP(string MaSP)
        {
            try
            {
                var SP = QLNPP_PS.SANPHAMs.Where(t => t.MASP == MaSP).Single();

                QLNPP_PS.SANPHAMs.DeleteOnSubmit(SP);
                QLNPP_PS.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int sua_SP(string masp, string maloaisp, string mahsx, string maxuatxu, string tensp, string hinhsp,
            string thanhphan, string congdung, string baoquan, string ghichu, string dvt, int solosp, DateTime ngaysx, DateTime hansd, decimal dongia)
        {
            try
            {
                SANPHAM SP = QLNPP_PS.SANPHAMs.Where(t => t.MASP == masp).FirstOrDefault();
                SP.MASP = masp;
                SP.MAHSX = mahsx;
                SP.MAXUATXU = maxuatxu;
                SP.TENSANPHAM = tensp;
                SP.HINHSP = hinhsp;
                SP.THANHPHAN = thanhphan;
                SP.CONGDUNG = congdung;
                SP.BAOQUAN = baoquan;
                SP.GHICHUSP = ghichu;
                SP.DVT = dvt;
                SP.SOLOSP = solosp;
                SP.NGAYSANXUAT = ngaysx;
                SP.HANSUDUNG = hansd;
                SP.DONGIASP = dongia;

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
