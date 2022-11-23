using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_BLL;
using DTO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace QTNPP_PEPSI
{
    public partial class FormBanSanPham : Form
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();
        HoaDonBan_DALBLL hdb = new HoaDonBan_DALBLL();
        KhachHang_DALBLL kh = new KhachHang_DALBLL();
        SP_DALBLL sp = new SP_DALBLL();
        LoaiSP_DALBLL lsp = new LoaiSP_DALBLL();
        NhanVien_DALBLL nv = new NhanVien_DALBLL();

        public FormBanSanPham()
        {
            InitializeComponent();
        }

        private void FormBanSanPham_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = FormDangNhap.nv.MANV;
            txtTenNV.Text = FormDangNhap.nv.HOTENNV;

            GvHoaDon.DataSource = hdb.load_HDB();

            //Khởi tạo combobox Khách hàng
            cbbTenKhachHang.DataSource = kh.load_TenKH();
            cbbTenKhachHang.DisplayMember = "HOTENKH";
            cbbTenKhachHang.ValueMember = "MAKH";

            //Khởi tạo combobox Loại SP
            cbbMaLoaiSP.DataSource = lsp.load_TenLoaiSP1();
            cbbMaLoaiSP.DisplayMember = "TENLOAISANPHAM";
            cbbMaLoaiSP.ValueMember = "MALOAISANPHAM";

            //chỉ định dòng đầu vào textbox
            txtMaHoaDon.Text = GvHoaDon.CurrentRow.Cells[0].Value.ToString();
            DTPNgayLap.Text = GvHoaDon.CurrentRow.Cells[1].Value.ToString();

            btnThem.Enabled = false;          
        }

        #region Hóa đơn bán

        List<HOADONBAN> lst_HDB;

        public string VAT(string mhd)
        {
            lst_HDB = new List<HOADONBAN>();
            string dg = "";
            lst_HDB = hdb.load_VAT(mhd);
            foreach (HOADONBAN sp in lst_HDB)
            {
                dg = (sp.VAT).ToString(); //tên cột VAT
            }
            return dg;
        }

        public double TinhTongTien()
        {
            double tong = 0;
            for (int i = 0; i < GvChiTietHD.RowCount; i++)
            {
                if (GvChiTietHD.Rows[i].Cells[5].Value != null)
                {
                    tong += Int32.Parse(GvChiTietHD.Rows[i].Cells[5].Value.ToString());
                }
            }
            return tong;
        }

        #endregion

        private void GvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string mhd = GvHoaDon.CurrentRow.Cells[0].Value.ToString();
            GvChiTietHD.DataSource = hdb.load_CTHDB(mhd);
            txtMaHoaDon.Text = mhd;

            DTPNgayLap.Text = GvHoaDon.CurrentRow.Cells[1].Value.ToString();

            cbbTenKhachHang.DataSource = kh.load_TenKH1(mhd);
            cbbTenKhachHang.DisplayMember = "HOTENKH";
            cbbTenKhachHang.ValueMember = "MAKH";

            txtVAT.Text = VAT(mhd);
            double tt = (TinhTongTien()) + ((TinhTongTien() * (double.Parse(VAT(mhd)) / 100.0)));
            txtThanhTien.Text = tt.ToString();
        }

        #region Load SL, đơn giá, SLTon theo Sản phẩm

        List<SANPHAM> lst_SANPHAM;
        public string SoLuong(string maSP)
        {
            lst_SANPHAM = new List<SANPHAM>();
            string sl = "";
            lst_SANPHAM = sp.load_SoLuong(maSP);
            foreach (SANPHAM th in lst_SANPHAM)
            {
                sl = (th.SOLUONGTON).ToString(); //tên cột số lượng
            }
            return sl;
        }

        public string DonGia(string maSP)
        {
            lst_SANPHAM = new List<SANPHAM>();
            string dg = "";
            lst_SANPHAM = sp.load_DonGia(maSP);
            foreach (SANPHAM th in lst_SANPHAM)
            {
                dg = (th.DONGIASP).ToString() + " VNĐ"; //tên cột đơn giá
            }
            return dg;
        }

        public string SoLuongTon(string maSP)
        {
            lst_SANPHAM = new List<SANPHAM>();
            string dg = "";
            lst_SANPHAM = sp.load_SoLuongTon(maSP);
            foreach (SANPHAM th in lst_SANPHAM)
            {
                dg = (th.SOLUONGTON).ToString(); //tên cột số lượng tồn
            }
            return dg;
        }

        #endregion

        private void GvChiTietHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbMaLoaiSP.Text = "";
            txtTonKho.Text = SoLuongTon(GvChiTietHD.CurrentRow.Cells[0].Value.ToString());
            cbbMaSP.Text = GvChiTietHD.CurrentRow.Cells[1].Value.ToString();
            cbbDonViTinh.Text = GvChiTietHD.CurrentRow.Cells[2].Value.ToString();
            txtGiaBan.Text = GvChiTietHD.CurrentRow.Cells[3].Value.ToString();
            txtSoLuong.Text = GvChiTietHD.CurrentRow.Cells[4].Value.ToString();
            txtThanhTien.Text = GvChiTietHD.CurrentRow.Cells[5].Value.ToString();
        }    

        private void Clear()
        {
            cbbTenKhachHang.Text = string.Empty;

            txtDiaChi.Text = string.Empty;
            txtTongTien.Text = 0.ToString();
            txtVAT.Text = string.Empty;

            cbbMaLoaiSP.Text = string.Empty;
            cbbMaSP.Text = string.Empty;
            cbbDonViTinh.Text = string.Empty;

            txtSoLuong.Text = string.Empty;
            txtGiaBan.Text = string.Empty;
            txtThanhTien.Text = string.Empty;
            txtTonKho.Text = string.Empty;

            GvChiTietHD.DataSource = null;
            dsspban.Clear();
        }

        #region Load địa chỉ theo Khách hàng 

        List<KHACHHANG> lst_KHACHHANG;

        public string diachi(string makh)
        {
            lst_KHACHHANG = new List<KHACHHANG>();
            string dg = "";
            lst_KHACHHANG = kh.load_DiaChi(makh);
            foreach (KHACHHANG th in lst_KHACHHANG)
            {
                dg = (th.DIACHIKH).ToString(); //tên cột địa chỉ
            }
            return dg;
        }

        #endregion

        private void cbbTenKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDiaChi.Text = diachi(cbbTenKhachHang.SelectedValue.ToString()).ToString();
        }

        private void cbbMaLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbMaSP.DataSource = sp.load_TenSP(cbbMaLoaiSP.SelectedValue.ToString());
            cbbMaSP.DisplayMember = "TENSANPHAM";
            cbbMaSP.ValueMember = "MASP";
        }

        private void cbbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string masp = cbbMaSP.SelectedValue.ToString();
            txtTonKho.Text = SoLuong(masp);
            txtGiaBan.Text = DonGia(masp);
            cbbDonViTinh.DataSource = sp.load_DVT(masp);
            cbbDonViTinh.DisplayMember = "DVT";
            txtSoLuong.Text = "0";
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtThanhTien.Text = ((Int32.Parse(txtSoLuong.Text)) * (Int32.Parse(txtGiaBan.Text))).ToString();
            }
            catch
            {
                txtThanhTien.Text = 0.ToString();
            }
        }

        public string layMaTuDong_HDB()
        {
            try
            {
                List<HOADONBAN> lst = new List<HOADONBAN>();
            lst = hdb.getHDB();
            string a = GvHoaDon.Rows[GvHoaDon.Rows.Count - 1].Cells[0].Value.ToString();
            string mahdb = "";
            mahdb = "HDB";
            int ma = lst.Count;
            ma = ma + 1;
            if (lst.Count <= 9)
                mahdb = mahdb + "00";
            else
                mahdb = mahdb + "0";

            mahdb += ma.ToString();

            return mahdb;
            }
            catch { return "HDB001"; }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtMaHoaDon.Text = layMaTuDong_HDB();
            Clear();

            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnLapHoaDon.Enabled = true;

            //Khởi tạo combobox Khách hàng
            cbbTenKhachHang.DataSource = kh.load_TenKH();
            cbbTenKhachHang.DisplayMember = "HOTENKH";
            cbbTenKhachHang.ValueMember = "MAKH";

            //Khởi tạo combobox Loại SP
            cbbMaLoaiSP.DataSource = lsp.load_TenLoaiSP1();
            cbbMaLoaiSP.DisplayMember = "TENLOAISANPHAM";
            cbbMaLoaiSP.ValueMember = "MALOAISANPHAM";
        }

        public void hienThiDSMua()
        {
            GvChiTietHD.DataSource = null;
            GvChiTietHD.DataSource = dsspban;
            txtTongTien.Text = dsspban.Sum(p => p.SOLUONG * p.DONGIA).ToString();
            txtThanhTien.Text = dsspban.Sum(p => p.SOLUONG * p.DONGIA).ToString();
            GvHoaDon.DataSource = hdb.load_HDB();
        }

        List<SPMua_DTO> dsspban = new List<SPMua_DTO>();

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiểm tra rỗng
            if (string.IsNullOrEmpty(cbbTenKhachHang.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lb_tenkh.Text.ToLower());
                this.cbbTenKhachHang.Focus();
                return;
            }

            if (string.IsNullOrEmpty(cbbMaSP.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lb_mathuoc.Text.ToLower());
                this.cbbMaSP.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtSoLuong.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lbsoluong.Text.ToLower());
                this.txtSoLuong.Focus();
                return;
            }

            //----------------------------------------------------------

            int soLuong = int.Parse(txtSoLuong.Text);
            if (soLuong == 0)
            {
                MessageBox.Show("Số lượng bán không thể bằng 0!", "Thông báo");
                this.txtSoLuong.Focus();
                return;
            }

            string maSP = cbbMaSP.SelectedValue.ToString();

            SPMua_DTO chonmua = dsspban.SingleOrDefault(p => p.MASP == maSP);
            if (Int32.Parse(txtTonKho.Text) > Int32.Parse(txtSoLuong.Text))
            {
                if (chonmua == null)
                {
                    SANPHAM sanpham = QLNPP_PS.SANPHAMs.SingleOrDefault(p => p.MASP == maSP);
                    dsspban.Add(new SPMua_DTO
                    {
                        MASP = sanpham.MASP,
                        TENSANPHAM = sanpham.TENSANPHAM,
                        DVT = sanpham.DVT,
                        DONGIA = Convert.ToDouble(sanpham.DONGIASP),
                        SOLUONG = soLuong,
                    });
                }
                else
                {
                    chonmua.SOLUONG = soLuong;
                }
                hienThiDSMua();
            }
            else
            {
                MessageBox.Show("Số lượng mặt hàng hiện không đủ để cung ứng!", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Muốn xóa mặt hàng này khỏi hóa đơn này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string str = txtMaHoaDon.Text;
                    hdb.xoa_CTHDB(txtMaHoaDon.Text, GvChiTietHD.CurrentRow.Cells[0].Value.ToString());

                    GvChiTietHD.DataSource = hdb.load_CTHDB(txtMaHoaDon.Text);
                    SPMua_DTO xoa = dsspban.SingleOrDefault(p => p.MASP == GvChiTietHD.CurrentRow.Cells[0].Value.ToString());
                    dsspban.Remove(xoa);
                    hienThiDSMua();
                    MessageBox.Show("Xoá dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Xoá dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void focus()
        {
            GvHoaDon.ClearSelection();
            int nRowIndex = GvHoaDon.Rows.Count - 1;

            GvHoaDon.Rows[nRowIndex].Selected = true;
            GvHoaDon.Rows[nRowIndex].Cells[0].Selected = true;
        }

        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            //Kiểm tra rỗng
            if (dsspban.Count == 0)
            {
                MessageBox.Show("Hóa đơn phải có ít nhất 1 sản phẩm", "Thông báo");
                return;
            }

            if (string.IsNullOrEmpty(txtVAT.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lbVAT.Text.ToLower());
                this.txtSoLuong.Focus();
                return;
            }
            else
            {
                int slton = int.Parse(txtTonKho.Text);
                int vat = int.Parse(txtVAT.Text);
                decimal thanhtien = decimal.Parse(txtThanhTien.Text);
                decimal Tongtien = decimal.Parse(((TinhTongTien()) + (TinhTongTien() * (double.Parse(vat.ToString()) / 100.0))).ToString());
 
                HOADONBAN hd = new HOADONBAN
                {
                    MAHDB = layMaTuDong_HDB(),
                    MAKH = cbbTenKhachHang.SelectedValue.ToString(),
                    MANV = FormDangNhap.nv.MANV,
                    NGAYLAPBAN = DTPNgayLap.Value,
                    VAT = double.Parse(txtVAT.Text),
                    TONGTIENBAN = Tongtien
                };

                QLNPP_PS.HOADONBANs.InsertOnSubmit(hd);
                QLNPP_PS.SubmitChanges();
                CHITIETHOADONBAN cthdb = null;
                foreach (SPMua_DTO spban in dsspban)
                {
                    cthdb = new CHITIETHOADONBAN
                    {
                        MAHDB = hd.MAHDB,
                        MASP = spban.MASP,
                        SOLUONGBAN = spban.SOLUONG,
                        THANHTIENBAN = Convert.ToDecimal(spban.THANHTIEN)
                    };
                    QLNPP_PS.CHITIETHOADONBANs.InsertOnSubmit(cthdb);
                }

                QLNPP_PS.SubmitChanges();

                GvHoaDon.DataSource = hdb.load_HDB();
                MessageBox.Show("Thêm hóa đơn thành công", "Thông báo");
                QLNPP_PS.SubmitChanges();
                dsspban.Clear();

                focus();
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnLapHoaDon.Enabled = false;
            }
        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            rptXuatHDB rpt = new rptXuatHDB();
            rpt.SetDatabaseLogon("sa", "sa2012", "DESKTOP-COHHIDH", "QL_QTNPP_PEPSI");

            FormXuatBaoCao fm = new FormXuatBaoCao();
           
            fm.crystalReportViewer1.ReportSource = rpt;
            fm.crystalReportViewer1.DisplayStatusBar = false;
            fm.crystalReportViewer1.DisplayToolbar = true;

            rpt.SetParameterValue("LocHD", txtMaHoaDon.Text.ToString());
            fm.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            FormKhachHang formNew = new FormKhachHang();
            formNew.Show();
        }

        private void btnLoaiSP_Click(object sender, EventArgs e)
        {
            FormLoaiSanPham formNew = new FormLoaiSanPham();
            formNew.Show();
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            FormSanPham formNew = new FormSanPham();
            formNew.Show();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (btnLoc.Text == "Lọc phiếu")
            {
                GvHoaDon.DataSource = hdb.load_MAHDB(txtSearch.Text);

                btnLoc.Text = "Hủy";
            }
            else
            {
                GvHoaDon.DataSource = hdb.load_HDB();
                txtSearch.Text = string.Empty;
                btnLoc.Text = "Lọc phiếu";
            }
        }

        private void btn_XoaHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdb.xoa_HDB(txtMaHoaDon.Text) == 1)
                {
                    MessageBox.Show("Xoá dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GvHoaDon.DataSource = hdb.load_HDB();
                    btnThem.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Xoá dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Xoá dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Nếu bạn muốn, bạn có thể cho phép nhập số thực với dấu chấm
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Nếu bạn muốn, bạn có thể cho phép nhập số thực với dấu chấm
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtVAT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Nếu bạn muốn, bạn có thể cho phép nhập số thực với dấu chấm
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
