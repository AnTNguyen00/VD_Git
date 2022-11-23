using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DAL_BLL;

namespace QTNPP_PEPSI
{
    public partial class FormTrangChu : DevComponents.DotNetBar.Office2007RibbonForm
    {
        FormDangNhap dangnhap = new FormDangNhap();
        PhanQuyen_DALBLL phanquyen = new PhanQuyen_DALBLL();

        public FormTrangChu()
        {
            InitializeComponent();
        }

        private void buttonItem22_Click(object sender, EventArgs e)
        {
            FormNhanVien vl = new FormNhanVien();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem29_Click(object sender, EventArgs e)
        {
            FormPAL vl = new FormPAL();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem24_Click(object sender, EventArgs e)
        {
            FormBangLuongNV vl = new FormBangLuongNV();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem25_Click(object sender, EventArgs e)
        {
            FormBacLuong vl = new FormBacLuong();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem27_Click(object sender, EventArgs e)
        {
            FormChamCong vl = new FormChamCong();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem28_Click(object sender, EventArgs e)
        {
            FormSanPham vl = new FormSanPham();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem30_Click(object sender, EventArgs e)
        {
            FormLoaiSanPham vl = new FormLoaiSanPham();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem31_Click(object sender, EventArgs e)
        {
            FormNhaCC vl = new FormNhaCC();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem32_Click(object sender, EventArgs e)
        {
            FormXuatXu vl = new FormXuatXu();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem33_Click(object sender, EventArgs e)
        {
            FormTinhThanh_QuanHuyen vl = new FormTinhThanh_QuanHuyen();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem34_Click(object sender, EventArgs e)
        {
            FormHangSanXuat vl = new FormHangSanXuat();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem36_Click(object sender, EventArgs e)
        {
            FormKhachHang vl = new FormKhachHang();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            FormDangNhap vl = new FormDangNhap();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau vl = new FormDoiMatKhau();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem39_Click(object sender, EventArgs e)
        {
            FormThongKeSanPham vl = new FormThongKeSanPham();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem40_Click(object sender, EventArgs e)
        {
            FormThongKeHoaDon vl = new FormThongKeHoaDon();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem41_Click(object sender, EventArgs e)
        {
            FormTimKiemSanPham vl = new FormTimKiemSanPham();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem42_Click(object sender, EventArgs e)
        {
            FormTimKiemNhanVien vl = new FormTimKiemNhanVien();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem43_Click(object sender, EventArgs e)
        {
            FormSoLuongTon vl = new FormSoLuongTon();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem38_Click(object sender, EventArgs e)
        {
            FormNhapSanPham vl = new FormNhapSanPham();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem37_Click(object sender, EventArgs e)
        {
            FormBanSanPham vl = new FormBanSanPham();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.No)
            {
                this.Hide();
                dangnhap.Show();
            }
        }

        private void buttonItem20_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn muốn đóng màn hình này không?", "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
                Close();
        }

        private void FormTrangChu_Load(object sender, EventArgs e)
        {
            List<PHANQUYEN> lst_pq = phanquyen.load_QuyenChuaCo(FormDangNhap.nv.MANHOMNV);
            string maCheck = "";
            labelItem1.Text = "Xin Chào, " + FormDangNhap.nv.HOTENNV;

            foreach (RibbonBar item in ribbonPanel2.Controls)
            {
                maCheck = item.Tag.ToString();
                if (lst_pq.Any(t => t.MADMMH == maCheck))
                {
                    item.Visible = false;
                }
            }
            foreach (RibbonBar item in ribbonPanel3.Controls)
            {
                maCheck = item.Tag.ToString();
                if (lst_pq.Any(t => t.MADMMH == maCheck))
                {
                    item.Visible = false;
                }
            }
            foreach (RibbonBar item in ribbonPanel4.Controls)
            {
                maCheck = item.Tag.ToString();
                if (lst_pq.Any(t => t.MADMMH == maCheck))
                {
                    item.Visible = false;
                }
            }
            foreach (ButtonItem item in explorerBarGroupItem1.SubItems)
            {
                maCheck = item.Tag.ToString();
                if (lst_pq.Any(t => t.MADMMH == maCheck))
                {
                    item.Visible = false;
                }
            }
        }

        private void buttonItem44_Click(object sender, EventArgs e)
        {
            FormXuatSanPham vl = new FormXuatSanPham();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            FormSanPham vl = new FormSanPham();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            FormBanSanPham vl = new FormBanSanPham();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem26_Click(object sender, EventArgs e)
        {
            FormNhapSanPham vl = new FormNhapSanPham();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem45_Click(object sender, EventArgs e)
        {
            FormXuatSanPham vl = new FormXuatSanPham();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem21_Click(object sender, EventArgs e)
        {
            FormNhanVien vl = new FormNhanVien();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem23_Click(object sender, EventArgs e)
        {
            FormKhachHang vl = new FormKhachHang();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem35_Click(object sender, EventArgs e)
        {
            FormQuanLyTaiKhoan vl = new FormQuanLyTaiKhoan();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem47_Click(object sender, EventArgs e)
        {
            FormBackup vl = new FormBackup();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem48_Click(object sender, EventArgs e)
        {
            FormRestore vl = new FormRestore();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem46_Click(object sender, EventArgs e)
        {
            FormDangKy_CTTL_CTTB vl = new FormDangKy_CTTL_CTTB();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem49_Click(object sender, EventArgs e)
        {
            FormLapLich vl = new FormLapLich();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }
        private void buttonItem18_Click(object sender, EventArgs e)
        {
            FormDuDoanSP vl = new FormDuDoanSP();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }
    }
}
