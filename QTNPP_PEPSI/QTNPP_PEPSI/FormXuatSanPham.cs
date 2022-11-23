using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_BLL;
using DTO;

namespace QTNPP_PEPSI
{
    public partial class FormXuatSanPham : Form
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();
        HoaDonXuat_DALBLL hdx = new HoaDonXuat_DALBLL();
        KhachHang_DALBLL kh = new KhachHang_DALBLL();
        SP_DALBLL sp = new SP_DALBLL();
        LoaiSP_DALBLL lsp = new LoaiSP_DALBLL();
        NhanVien_DALBLL nv = new NhanVien_DALBLL();

        public FormXuatSanPham()
        {
            InitializeComponent();
        }

        private void FormXuatSanPham_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = FormDangNhap.nv.MANV;
            txtTenNV.Text = FormDangNhap.nv.HOTENNV;

            GvPhieuXuat.DataSource = hdx.load_HDX();

            //Khởi tạo combobox Khách hàng
            cbbTenKhachHang.DataSource = kh.load_TenKH2();
            cbbTenKhachHang.DisplayMember = "HOTENKH";
            cbbTenKhachHang.ValueMember = "MAKH";

            //Khởi tạo combobox Loại SP
            cbbMaLoaiSP.DataSource = lsp.load_TenLoaiSP3();
            cbbMaLoaiSP.DisplayMember = "TENLOAISANPHAM";
            cbbMaLoaiSP.ValueMember = "MALOAISANPHAM";

            //chỉ định dòng đầu vào textbox
            txtMaPX.Text = GvPhieuXuat.CurrentRow.Cells[0].Value.ToString();
            DTPNgayXuat.Text = GvPhieuXuat.CurrentRow.Cells[1].Value.ToString();

            btnThem.Enabled = false;
        }

        #region Hóa đơn xuất

        List<string> lst_HDX;

        public string GhiChu(string maPX)
        {
            lst_HDX = new List<string>();
            string gc = "";
            lst_HDX = hdx.load_GhiChu(maPX);
            foreach (string th in lst_HDX)
            {
                try
                {
                    gc = th.ToString(); //tên cột ghi chú
                }
                catch
                {
                    return "";
                }
            }
            return gc;
        }

        public int TinhTongTien()
        {
            int tong = 0;
            for (int i = 0; i < GvChiTietPhieuXuat.RowCount; i++)
            {
                if (GvChiTietPhieuXuat.Rows[i].Cells[5].Value != null)
                {
                    tong += Int32.Parse(GvChiTietPhieuXuat.Rows[i].Cells[5].Value.ToString());
                }
            }
            return tong;
        }

        List<bool?> lst_TrangThai;

        public bool? TrangThai(string maPX)
        {
            lst_TrangThai = new List<bool?>();
            lst_TrangThai = hdx.load_TrangThai(maPX);
            foreach (bool? th in lst_TrangThai)
            {
                try
                {
                    return th;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public void checkTrangThai(string maPX)
        {
            if (TrangThai(maPX) == true)
            {
                rdHoanThanh.Checked = true;
            }
            else
            {
                rdChuaHoanThanh.Checked = true;
            }
        }

        #endregion

        private void GvPhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string pxsp = GvPhieuXuat.CurrentRow.Cells[0].Value.ToString();
            GvChiTietPhieuXuat.DataSource = hdx.load_CTHDX(pxsp);
            txtMaPX.Text = pxsp;

            DTPNgayXuat.Text = GvPhieuXuat.CurrentRow.Cells[1].Value.ToString();

            txtGhiChu.Text = GhiChu(pxsp);

            //Khởi tạo combobox Khách hàng
            cbbTenKhachHang.DataSource = kh.load_TenKH3(pxsp);
            cbbTenKhachHang.DisplayMember = "HOTENKH";
            cbbTenKhachHang.ValueMember = "MAKH";

            txtTongTien.Text = TinhTongTien().ToString();
            checkTrangThai(pxsp);
        }

        #region Load SL, đơn giá, SLTon theo Sản phẩm

        List<SANPHAM> lst_SANPHAM;
        public string SoLuong(string maSP)
        {
            lst_SANPHAM = new List<SANPHAM>();
            string sl = "";
            lst_SANPHAM = sp.load_SoLuongXuat(maSP);
            foreach (SANPHAM th in lst_SANPHAM)
            {
                sl = (th.SOLUONGTON).ToString(); //tên cột số lượng
            }
            return sl;
        }

        public string SoLuongTon(string maSP)
        {
            lst_SANPHAM = new List<SANPHAM>();
            string dg = "";
            lst_SANPHAM = sp.load_SoLuongTonXuat(maSP);
            foreach (SANPHAM th in lst_SANPHAM)
            {
                dg = (th.SOLUONGTON).ToString(); //tên cột số lượng tồn
            }
            return dg;
        }

        #endregion

        private void GvChiTietPhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbMaLoaiSP.Text = "";
            txtTonKho.Text = SoLuongTon(GvChiTietPhieuXuat.CurrentRow.Cells[0].Value.ToString());
            cbbMaSP.Text = GvChiTietPhieuXuat.CurrentRow.Cells[1].Value.ToString();
            cbbDonViTinh.Text = GvChiTietPhieuXuat.CurrentRow.Cells[2].Value.ToString();
            txtGiaXuat.Text = GvChiTietPhieuXuat.CurrentRow.Cells[3].Value.ToString();
            txtSoLuong.Text = GvChiTietPhieuXuat.CurrentRow.Cells[4].Value.ToString();
            txtThanhTien.Text = GvChiTietPhieuXuat.CurrentRow.Cells[5].Value.ToString();
        }

        private void Clear()
        {
            cbbTenKhachHang.Text = string.Empty;
            txtTongTien.Text = 0.ToString();

            cbbMaLoaiSP.Text = string.Empty;
            cbbMaSP.Text = string.Empty;
            cbbDonViTinh.Text = string.Empty;

            txtSoLuong.Text = string.Empty;
            txtGiaXuat.Text = string.Empty;
            txtThanhTien.Text = string.Empty;
            txtTonKho.Text = string.Empty;

            GvChiTietPhieuXuat.DataSource = null;
            dsspxuat.Clear();
        }

        private void cbbMaLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbMaSP.DataSource = sp.load_TenSP2(cbbMaLoaiSP.SelectedValue.ToString());
            cbbMaSP.DisplayMember = "TENSANPHAM";
            cbbMaSP.ValueMember = "MASP";
        }

        private void cbbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string masp = cbbMaSP.SelectedValue.ToString();
            txtTonKho.Text = SoLuong(masp);
            cbbDonViTinh.DataSource = sp.load_DVT2(masp);
            cbbDonViTinh.DisplayMember = "DVT";
            txtSoLuong.Text = "0";
            txtGiaXuat.Text = "0";
        }

        public string layMaTuDong_HDX()
        {
            try
            {
                List<PHIEUXUATHANG> lst = new List<PHIEUXUATHANG>();
                lst = hdx.getHDX();
                string a = GvPhieuXuat.Rows[GvPhieuXuat.Rows.Count - 1].Cells[0].Value.ToString();
                string mapn = "";
                mapn = "PX";
                int ma = lst.Count;
                ma = ma + 1;
                if (lst.Count <= 9)
                    mapn = mapn + "00";
                else
                    mapn = mapn + "0";

                mapn += ma.ToString();

                return mapn;
            }
            catch { return "PX001"; }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtMaPX.Text = layMaTuDong_HDX();
            Clear();

            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnLapPX.Enabled = true;

            //Khởi tạo combobox Khách hàng
            cbbTenKhachHang.DataSource = kh.load_TenKH2();
            cbbTenKhachHang.DisplayMember = "HOTENKH";
            cbbTenKhachHang.ValueMember = "MAKH";

            //Khởi tạo combobox Loại SP
            cbbMaLoaiSP.DataSource = lsp.load_TenLoaiSP3();
            cbbMaLoaiSP.DisplayMember = "TENLOAISANPHAM";
            cbbMaLoaiSP.ValueMember = "MALOAISANPHAM";
        }

        public void hienThiDSXuat()
        {
            GvChiTietPhieuXuat.DataSource = null;
            GvChiTietPhieuXuat.DataSource = dsspxuat;
            GvPhieuXuat.DataSource = hdx.load_HDX();
        }

        List<SPXuat_DTO> dsspxuat = new List<SPXuat_DTO>();

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiểm tra rỗng
            if (string.IsNullOrEmpty(cbbTenKhachHang.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lb_kh.Text.ToLower());
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
                MessageBox.Show("Số lượng nhập không thể bằng 0!", "Thông báo");
                this.txtSoLuong.Focus();
                return;
            }

            string maSP = cbbMaSP.SelectedValue.ToString();
            SPXuat_DTO chonxuat = dsspxuat.SingleOrDefault(p => p.MASP == maSP);

            if (Int32.Parse(txtTonKho.Text) > Int32.Parse(txtSoLuong.Text))
            {
                if (chonxuat == null)
                {
                    SANPHAM sanpham = QLNPP_PS.SANPHAMs.SingleOrDefault(p => p.MASP == maSP);
                    dsspxuat.Add(new SPXuat_DTO
                    {
                        MASP = sanpham.MASP,
                        TENSANPHAM = sanpham.TENSANPHAM,
                        DVT = sanpham.DVT,
                        DONGIA = Convert.ToDouble(txtGiaXuat.Text),
                        SOLUONG = soLuong,
                    });
                }
                else
                {
                    chonxuat.SOLUONG = soLuong;
                }
                hienThiDSXuat();
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
                if (hdx.xoa_HDX(txtMaPX.Text) == 1)
                {
                    MessageBox.Show("Xoá dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GvPhieuXuat.DataSource = hdx.load_HDX();
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

        private void focus()
        {
            GvPhieuXuat.ClearSelection();
            int nRowIndex = GvPhieuXuat.Rows.Count - 1;

            GvPhieuXuat.Rows[nRowIndex].Selected = true;
            GvPhieuXuat.Rows[nRowIndex].Cells[0].Selected = true;
        }

        private void btnLapPX_Click(object sender, EventArgs e)
        {
            //Kiểm tra rỗng
            if (dsspxuat.Count == 0)
            {
                MessageBox.Show("Hóa đơn phải có ít nhất 1 sản phẩm", "Thông báo");
                return;
            }

            bool kt = rdHoanThanh.Checked ? true : false;

            PHIEUXUATHANG pxh = new PHIEUXUATHANG
            {
                MAPX = layMaTuDong_HDX(),
                MAKH = cbbTenKhachHang.SelectedValue.ToString(),
                NGAYXUAT = DateTime.Now,
                GHICHUX = txtGhiChu.Text,
                TRANGTHAI = kt,
                TONGTIEN = Convert.ToDecimal(TinhTongTien())
            };

            QLNPP_PS.PHIEUXUATHANGs.InsertOnSubmit(pxh);
            QLNPP_PS.SubmitChanges();
            CHITIETPHIEUXUAT ctpx = null;

            foreach (SPXuat_DTO pdt in dsspxuat)
            {
                ctpx = new CHITIETPHIEUXUAT
                {
                    MAPX = pxh.MAPX,
                    MASP = pdt.MASP,
                    SOLUONGNHAP = pdt.SOLUONG,
                    DVT = pdt.DVT,
                    DONGIABAN = Convert.ToDecimal(pdt.DONGIA),
                    THANHTIEN = pdt.SOLUONG * Convert.ToDecimal(pdt.DONGIA)
                };
                QLNPP_PS.CHITIETPHIEUXUATs.InsertOnSubmit(ctpx);
            }
            QLNPP_PS.SubmitChanges();

            GvPhieuXuat.DataSource = hdx.load_HDX();
            MessageBox.Show("Lập phiếu xuất thành công", "Thông báo");
            QLNPP_PS.SubmitChanges();
            dsspxuat.Clear();

            focus();
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLapPX.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            bool kt = rdHoanThanh.Checked ? true : false;
            hdx.sua_HDX(txtMaPX.Text, txtGhiChu.Text, kt);
            GvPhieuXuat.DataSource = hdx.load_HDX();
        }

        private void btnXuatPX_Click(object sender, EventArgs e)
        {
            rptXuatPXH rpt = new rptXuatPXH();
            rpt.SetDatabaseLogon("sa", "sa2012", "DESKTOP-COHHIDH", "QL_QTNPP_PEPSI");

            FormXuatBaoCao fm = new FormXuatBaoCao();

            fm.crystalReportViewer1.ReportSource = rpt;
            fm.crystalReportViewer1.DisplayStatusBar = false;
            fm.crystalReportViewer1.DisplayToolbar = true;

            rpt.SetParameterValue("LocPX", txtMaPX.Text.ToString());
            fm.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (btnLoc.Text == "Lọc phiếu")
            {
                GvPhieuXuat.DataSource = hdx.load_MAHDX(txtSearch.Text);

                btnLoc.Text = "Hủy";
            }
            else
            {
                GvPhieuXuat.DataSource = hdx.load_HDX();
                txtSearch.Text = string.Empty;
                btnLoc.Text = "Lọc phiếu";
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            FormKhachHang formNew = new FormKhachHang();
            formNew.Show();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            FormLoaiSanPham formNew = new FormLoaiSanPham();
            formNew.Show();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            FormSanPham formNew = new FormSanPham();
            formNew.Show();
        }

        private void txtGiaXuat_TextChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text != "" && txtGiaXuat.Text != "")
            {
                txtThanhTien.Text = (Int32.Parse(txtSoLuong.Text) * Int32.Parse(txtGiaXuat.Text)).ToString();
            }
        }

        private void btnXoaCTPX_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Muốn xóa mặt hàng này khỏi phiếu xuất này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string str = txtMaPX.Text;
                    hdx.xoa_CTHDX(txtMaPX.Text, GvChiTietPhieuXuat.CurrentRow.Cells[0].Value.ToString());

                    GvChiTietPhieuXuat.DataSource = hdx.load_CTHDX(txtMaPX.Text);
                    SPXuat_DTO xoa = dsspxuat.SingleOrDefault(p => p.MASP == GvChiTietPhieuXuat.CurrentRow.Cells[0].Value.ToString());
                    dsspxuat.Remove(xoa);
                    hienThiDSXuat();
                    MessageBox.Show("Xoá dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void txtGiaXuat_KeyPress(object sender, KeyPressEventArgs e)
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
