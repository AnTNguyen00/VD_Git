using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_BLL;

namespace DAL_BLL
{
    public class NhanVien_DALBLL
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();

        #region Đăng nhập
        public List<NHANVIEN> checkDangNhap(string tk, string mk)
        {
            return QLNPP_PS.NHANVIENs.Where(t => t.TENDANGNHAP == tk && t.MATKHAU == mk).ToList();
        }

        #endregion

        #region Đổi mật khẩu
        public bool kiemTraTk(string tk, string mk)
        {
            NHANVIEN nhanvien = QLNPP_PS.NHANVIENs.Where(t => t.TENDANGNHAP == tk && t.MATKHAU == mk).FirstOrDefault();
            if (nhanvien == null)
                return false;
            else
                return true;
        }

        public bool doiMatKhau(string tk, string mk)
        {
            NHANVIEN nhanvien = QLNPP_PS.NHANVIENs.Where(k => k.TENDANGNHAP == tk).FirstOrDefault();
            if (nhanvien != null)
            {
                nhanvien.MATKHAU = mk;
                QLNPP_PS.SubmitChanges();
                return true;
            }
            return false;
        }

        #endregion

        #region Load dữ liệu nhân viên
        public List<NHANVIEN> getNhanVien()
        {
            return QLNPP_PS.NHANVIENs.Select(k => k).ToList<NHANVIEN>();
        }

        public List<NHOMNHANVIEN> Load_NhomNV()
        {
            return QLNPP_PS.NHOMNHANVIENs.Select(k => k).ToList<NHOMNHANVIEN>();
        }

        public List<string> Load_GioiTinh(string maNV)
        {
            List<string> nv = new List<string>();
            var gioitinh = (from gt in QLNPP_PS.NHANVIENs
                            where gt.MANV == maNV
                            select gt.GIOITINHNV).ToList();
            nv.AddRange(gioitinh);
            return nv;
        }

        #endregion

        #region Load dữ liệu nhân viên theo bảng lương
        public IQueryable load_MANV()
        {
            var manv = from Ma in QLNPP_PS.NHANVIENs
                       select new { Ma.MANV };
            return manv;
        }
        #endregion

        #region Load dữ liệu nhân viên theo chấm công
        public List<NHANVIEN> load_TenNV()
        {
            return QLNPP_PS.NHANVIENs.Select(k => k).ToList<NHANVIEN>();
        }

        #endregion    

        #region Thêm xóa sửa nhân viên
        public bool insert_NhanVien(string maNV, string tenDN, string matKh, string sDT, string maNhom, string hoTen, string gioiTinh, string ngaySinh, string diaChi, string luongCoBan, string cmnd, string ngayBDL, string ngayKTL, string trinhDo)
        {
            try
            {
                NHANVIEN nhanvien = new NHANVIEN();
                nhanvien.MANV = maNV;
                nhanvien.TENDANGNHAP = tenDN;
                nhanvien.MATKHAU = matKh;
                nhanvien.SODIENTHOAINV = sDT;
                nhanvien.MANHOMNV = maNhom;
                nhanvien.HOTENNV = hoTen;
                nhanvien.GIOITINHNV = gioiTinh;
                nhanvien.NGAYSINHNV = Convert.ToDateTime(ngaySinh);
                nhanvien.DIACHINV = diaChi;
                nhanvien.MUCLUONGCOBAN = Convert.ToDecimal(luongCoBan);
                nhanvien.CHUNGMINHTHU = cmnd;
                nhanvien.NGAYBATDAULAMVIEC = Convert.ToDateTime(ngayBDL);
                nhanvien.NGAYKETTHUCLAMVIEC = Convert.ToDateTime(ngayKTL);
                nhanvien.TRINHDOHOCVAN = trinhDo;
                QLNPP_PS.NHANVIENs.InsertOnSubmit(nhanvien);
                QLNPP_PS.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
   
        }
        public bool update_NhanVien(string maNV, string tenDN, string matKh, string sDT, string maNhom, string hoTen, string gioiTinh, string ngaySinh, string diaChi, string luongCoBan, string cmnd, string ngayBDL, string ngayKTL, string trinhDo)
        {
            NHANVIEN nhanvien = QLNPP_PS.NHANVIENs.Where(k => k.MANV == maNV).FirstOrDefault();
            if (nhanvien != null)
            {
                nhanvien.MANV = maNV;
                nhanvien.TENDANGNHAP = tenDN;
                nhanvien.MATKHAU = matKh;
                nhanvien.SODIENTHOAINV = sDT;
                nhanvien.MANHOMNV = maNhom;
                nhanvien.HOTENNV = hoTen;
                nhanvien.GIOITINHNV = gioiTinh;
                nhanvien.NGAYSINHNV = Convert.ToDateTime(ngaySinh);
                nhanvien.DIACHINV = diaChi;
                nhanvien.MUCLUONGCOBAN = Convert.ToDecimal(luongCoBan);
                nhanvien.CHUNGMINHTHU = cmnd;
                nhanvien.NGAYBATDAULAMVIEC = Convert.ToDateTime(ngayBDL);
                nhanvien.NGAYKETTHUCLAMVIEC = Convert.ToDateTime(ngayKTL);
                nhanvien.TRINHDOHOCVAN = trinhDo;
                QLNPP_PS.SubmitChanges();
                return true;
            }
            return false;
        }
        public bool delete_NhanVien(string maNV)
        {
            try
            {
                NHANVIEN nhanvien = QLNPP_PS.NHANVIENs.Where(t => t.MANV == maNV).FirstOrDefault();
                QLNPP_PS.NHANVIENs.DeleteOnSubmit(nhanvien);
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
