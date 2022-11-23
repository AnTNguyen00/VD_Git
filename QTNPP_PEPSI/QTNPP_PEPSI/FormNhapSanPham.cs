using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using DAL_BLL;
using DTO;

namespace QTNPP_PEPSI
{
    public partial class FormNhapSanPham : Form
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();
        HoaDonNhap_DALBLL hdn = new HoaDonNhap_DALBLL();
        NhaCC_DALBLL ncc = new NhaCC_DALBLL();
        SP_DALBLL sp = new SP_DALBLL();
        LoaiSP_DALBLL lsp = new LoaiSP_DALBLL();
        NhanVien_DALBLL nv = new NhanVien_DALBLL();

        public FormNhapSanPham()
        {
            InitializeComponent();
        }

        private void FormNhapSanPham_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = FormDangNhap.nv.MANV;
            txtTenNV.Text = FormDangNhap.nv.HOTENNV;

            GvPhieuNhap.DataSource = hdn.load_HDN();

            //Khởi tạo combobox Nhà cung cấp
            cbbTenNhaCC.DataSource = ncc.load_TenNCC();
            cbbTenNhaCC.DisplayMember = "TENNHACUNGCAP";
            cbbTenNhaCC.ValueMember = "MANCC";

            //Khởi tạo combobox Loại SP
            cbbMaLoaiSP.DataSource = lsp.load_TenLoaiSP2();
            cbbMaLoaiSP.DisplayMember = "TENLOAISANPHAM";
            cbbMaLoaiSP.ValueMember = "MALOAISANPHAM";

            //chỉ định dòng đầu vào textbox
            txtMaPN.Text = GvPhieuNhap.CurrentRow.Cells[0].Value.ToString();
            DTPNgayLap.Text = GvPhieuNhap.CurrentRow.Cells[1].Value.ToString();

            btnThem.Enabled = false;
        }

        #region Hóa đơn nhập

        List<string> lst_GhiChu;

        public string GhiChu(string maPN)
        {
            lst_GhiChu = new List<string>();
            string gc = "";
            lst_GhiChu = hdn.load_GhiChu(maPN);
            foreach (string th in lst_GhiChu)
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
            for (int i = 0; i < GvChiTietPhieuNhap.RowCount; i++)
            {
                if (GvChiTietPhieuNhap.Rows[i].Cells[5].Value != null)
                {
                    tong += Int32.Parse(GvChiTietPhieuNhap.Rows[i].Cells[5].Value.ToString());
                }
            }
            return tong;
        }

        List<bool?> lst_TrangThai;

        public bool? TrangThai(string maPN)
        {
            lst_TrangThai = new List<bool?>();
            lst_TrangThai = hdn.load_TrangThai(maPN);
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

        public void checkTrangThai(string maPN)
        {
            if (TrangThai(maPN) == true)
            {
                rdHoanThanh.Checked = true;
            }
            else
            {
                rdChuaHoanThanh.Checked = true;
            }
        }

        #endregion

        private void GvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string pnsp = GvPhieuNhap.CurrentRow.Cells[0].Value.ToString();
            GvChiTietPhieuNhap.DataSource = hdn.load_CTHDN(pnsp);
            txtMaPN.Text = pnsp;

            DTPNgayLap.Text = GvPhieuNhap.CurrentRow.Cells[1].Value.ToString();

            txtGhiChu.Text = GhiChu(pnsp);

            cbbTenNhaCC.DataSource = ncc.load_TenNCC1(pnsp);
            cbbTenNhaCC.ValueMember = "MANCC";
            cbbTenNhaCC.DisplayMember = "TENNHACUNGCAP";

            txtTongTien.Text = TinhTongTien().ToString();
            checkTrangThai(pnsp);
        }

        #region Load SL, đơn giá, SLTon theo Sản phẩm

        List<SANPHAM> lst_SANPHAM;
        public string SoLuong(string maSP)
        {
            lst_SANPHAM = new List<SANPHAM>();
            string sl = "";
            lst_SANPHAM = sp.load_SoLuongNhap(maSP);
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
            lst_SANPHAM = sp.load_SoLuongTonNhap(maSP);
            foreach (SANPHAM th in lst_SANPHAM)
            {
                dg = (th.SOLUONGTON).ToString(); //tên cột số lượng tồn
            }
            return dg;
        }

        #endregion

        private void GvChiTietPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbMaLoaiSP.Text = "";
            txtTonKho.Text = SoLuongTon(GvChiTietPhieuNhap.CurrentRow.Cells[0].Value.ToString());
            cbbMaSP.Text = GvChiTietPhieuNhap.CurrentRow.Cells[1].Value.ToString();
            cbbDonViTinh.Text = GvChiTietPhieuNhap.CurrentRow.Cells[2].Value.ToString();
            txtGiaNhap.Text = GvChiTietPhieuNhap.CurrentRow.Cells[3].Value.ToString();
            txtSoLuong.Text = GvChiTietPhieuNhap.CurrentRow.Cells[4].Value.ToString();
            txtThanhTien.Text = GvChiTietPhieuNhap.CurrentRow.Cells[5].Value.ToString();
        }

        private void Clear()
        {
            cbbTenNhaCC.Text = string.Empty;
            txtTongTien.Text = 0.ToString();

            cbbMaLoaiSP.Text = string.Empty;
            cbbMaSP.Text = string.Empty;
            cbbDonViTinh.Text = string.Empty;

            txtSoLuong.Text = string.Empty;
            txtGiaNhap.Text = string.Empty;
            txtThanhTien.Text = string.Empty;
            txtTonKho.Text = string.Empty;

            GvChiTietPhieuNhap.DataSource = null;
            dsspnhap.Clear();
        }

        private void cbbMaLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbMaSP.DataSource = sp.load_TenSP1(cbbMaLoaiSP.SelectedValue.ToString());
            cbbMaSP.DisplayMember = "TENSANPHAM";
            cbbMaSP.ValueMember = "MASP";
        }

        private void cbbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string masp = cbbMaSP.SelectedValue.ToString();
            txtTonKho.Text = SoLuong(masp);
            cbbDonViTinh.DataSource = sp.load_DVT1(masp);
            cbbDonViTinh.DisplayMember = "DVT";
            txtSoLuong.Text = "0";
            txtGiaNhap.Text = "0";
        }

        public string layMaTuDong_HDN()
        {
            try
            {
                List<PHIEUNHAPHANG> lst = new List<PHIEUNHAPHANG>();
                lst = hdn.getHDN();
                string a = GvPhieuNhap.Rows[GvPhieuNhap.Rows.Count - 1].Cells[0].Value.ToString();
                string mapn = "";
                mapn = "PN";
                int ma = lst.Count;
                ma = ma + 1;
                if (lst.Count <= 9)
                    mapn = mapn + "00";
                else
                    mapn = mapn + "0";

                mapn += ma.ToString();

                return mapn;
            }
            catch { return "PN001"; }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtMaPN.Text = layMaTuDong_HDN();
            Clear();

            btnThem.Enabled = true;
            btnXoaPN.Enabled = true;
            btnLapPN.Enabled = true;

            //Khởi tạo combobox Nhà cung cấp
            cbbTenNhaCC.DataSource = ncc.load_TenNCC();
            cbbTenNhaCC.DisplayMember = "TENNHACUNGCAP";
            cbbTenNhaCC.ValueMember = "MANCC";

            //Khởi tạo combobox Loại SP
            cbbMaLoaiSP.DataSource = lsp.load_TenLoaiSP2();
            cbbMaLoaiSP.DisplayMember = "TENLOAISANPHAM";
            cbbMaLoaiSP.ValueMember = "MALOAISANPHAM";
        }

        public void hienThiDSNhap()
        {
            GvChiTietPhieuNhap.DataSource = null;
            GvChiTietPhieuNhap.DataSource = dsspnhap;
            GvPhieuNhap.DataSource = hdn.load_HDN();
        }

        List<SPNhap_DTO> dsspnhap = new List<SPNhap_DTO>();

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiểm tra rỗng
            if (string.IsNullOrEmpty(cbbTenNhaCC.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lb_ncc.Text.ToLower());
                this.cbbTenNhaCC.Focus();
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
            SPNhap_DTO chonnhap = dsspnhap.SingleOrDefault(p => p.MASP == maSP);

            //if (Int32.Parse(txtTonKho.Text) > Int32.Parse(txtSoLuong.Text))
            //{
            //    if (chonnhap == null)
            //    {
                    SANPHAM sanpham = QLNPP_PS.SANPHAMs.SingleOrDefault(p => p.MASP == maSP);
                    dsspnhap.Add(new SPNhap_DTO
                    {
                        MASP = sanpham.MASP,
                        TENSANPHAM = sanpham.TENSANPHAM,
                        DVT = sanpham.DVT,
                        DONGIA = Convert.ToDouble(txtGiaNhap.Text),
                        SOLUONG = soLuong,
                    });
                //}
                //else
                //{
                //    chonnhap.SOLUONG = soLuong;
                //}
                hienThiDSNhap();
            //}
            //else
            //{
            //    MessageBox.Show("Số lượng mặt hàng hiện không đủ để cung ứng!", "Thông báo");
            //}
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdn.xoa_HDN(txtMaPN.Text) == 1)
                {
                    MessageBox.Show("Xoá dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GvPhieuNhap.DataSource = hdn.load_HDN();
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
            GvPhieuNhap.ClearSelection();
            int nRowIndex = GvPhieuNhap.Rows.Count - 1;

            GvPhieuNhap.Rows[nRowIndex].Selected = true;
            GvPhieuNhap.Rows[nRowIndex].Cells[0].Selected = true;
        }

        private void btnLapPN_Click(object sender, EventArgs e)
        {
            //Kiểm tra rỗng
            if (dsspnhap.Count == 0)
            {
                MessageBox.Show("Hóa đơn phải có ít nhất 1 sản phẩm", "Thông báo");
                return;
            }

            bool kt = rdHoanThanh.Checked ? true : false;

            PHIEUNHAPHANG pnh = new PHIEUNHAPHANG
            {
                MAPN = layMaTuDong_HDN(),
                MANCC = cbbTenNhaCC.SelectedValue.ToString(),
                NGAYNHAP = DateTime.Now,
                GHICHUN = txtGhiChu.Text,
                TRANGTHAI = kt,
                TONGTIEN = Convert.ToDecimal(TinhTongTien())
            };

            QLNPP_PS.PHIEUNHAPHANGs.InsertOnSubmit(pnh);
            QLNPP_PS.SubmitChanges();
            CHITIETPHIEUNHAP ctpn = null;

            foreach (SPNhap_DTO pdt in dsspnhap)
            {
                ctpn = new CHITIETPHIEUNHAP
                {
                    MAPN = pnh.MAPN,
                    MASP = pdt.MASP,
                    SOLUONGNHAP = pdt.SOLUONG,
                    DVT = pdt.DVT,
                    DONGIABAN = Convert.ToDecimal(pdt.DONGIA),
                    THANHTIEN = pdt.SOLUONG * Convert.ToDecimal(pdt.DONGIA)
                };
                QLNPP_PS.CHITIETPHIEUNHAPs.InsertOnSubmit(ctpn);
            }
            QLNPP_PS.SubmitChanges();

            GvPhieuNhap.DataSource = hdn.load_HDN();
            MessageBox.Show("Lập phiếu nhập thành công", "Thông báo");
            QLNPP_PS.SubmitChanges();
            dsspnhap.Clear();

            focus();
            btnThem.Enabled = false;
            btnXoaPN.Enabled = false;
            btnLapPN.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdn.sua_CTHDN(txtMaPN.Text, cbbMaSP.SelectedValue.ToString(), int.Parse(txtSoLuong.Text), decimal.Parse(txtGiaNhap.Text), decimal.Parse(txtThanhTien.Text)) == 1)
                {
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GvChiTietPhieuNhap.DataSource = hdn.load_CTHDN(txtMaPN.Text);
                }
                else
                {
                    MessageBox.Show("Sửa dữ không liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Sửa dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXuatPN_Click(object sender, EventArgs e)
        {
            rptXuatPNH rpt = new rptXuatPNH();
            rpt.SetDatabaseLogon("sa", "sa2012", "DESKTOP-COHHIDH", "QL_QTNPP_PEPSI");

            FormXuatBaoCao fm = new FormXuatBaoCao();

            fm.crystalReportViewer1.ReportSource = rpt;
            fm.crystalReportViewer1.DisplayStatusBar = false;
            fm.crystalReportViewer1.DisplayToolbar = true;

            rpt.SetParameterValue("LocPN", txtMaPN.Text.ToString());
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
                GvPhieuNhap.DataSource = hdn.load_MAPN(txtSearch.Text);

                btnLoc.Text = "Hủy";
            }
            else
            {
                GvPhieuNhap.DataSource = hdn.load_HDN();
                txtSearch.Text = string.Empty;
                btnLoc.Text = "Lọc phiếu";
            }
        }

        private void btnNhaCC_Click(object sender, EventArgs e)
        {
            FormNhaCC formNew = new FormNhaCC();
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

        private void txtGiaNhap_TextChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text != "" && txtGiaNhap.Text != "")
            {
                txtThanhTien.Text = (Int32.Parse(txtSoLuong.Text) * Int32.Parse(txtGiaNhap.Text)).ToString();
            }
        }

        private void btnXoaCTPN_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Muốn xóa mặt hàng này khỏi phiếu nhập này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    hdn.xoa_CTHDN(txtMaPN.Text, GvChiTietPhieuNhap.CurrentRow.Cells[0].Value.ToString());

                    GvChiTietPhieuNhap.DataSource = hdn.load_CTHDN(txtMaPN.Text);
                    SPNhap_DTO xoa = dsspnhap.SingleOrDefault(p => p.MASP == GvChiTietPhieuNhap.CurrentRow.Cells[0].Value.ToString());
                    dsspnhap.Remove(xoa);
                    hienThiDSNhap();
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

        private void txtThanhTien_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
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
