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

        #region Load dữ liệu nhân viên cho quản lý phân quyền
        public List<NHANVIEN> load_TenNV()
        {
            return QLNPP_PS.NHANVIENs.Select(k => k).ToList<NHANVIEN>();
        }

        public List<NHOMNHANVIEN> load_NhomNV()
        {
            return QLNPP_PS.NHOMNHANVIENs.Select(k => k).ToList<NHOMNHANVIEN>();
        }

        #endregion
    }
}
