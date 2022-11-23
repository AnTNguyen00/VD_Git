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

namespace QTNPP_PEPSI
{
    public partial class FormSanPham : Form
    {
        SP_DALBLL SP = new SP_DALBLL();
        LoaiSP_DALBLL LoaiSP = new LoaiSP_DALBLL();
        XuatXu_DALBLL XX = new XuatXu_DALBLL();
        HangSanXuat_DALBLL HSX = new HangSanXuat_DALBLL();      

        public FormSanPham()
        {
            InitializeComponent();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            FormLoaiSanPham formNew = new FormLoaiSanPham();
            formNew.Show();
        }

        private void txtSoLo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoadAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFile = new OpenFileDialog();
            oFile.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (oFile.ShowDialog() == DialogResult.OK)
            {
                txthinhanh.Text = oFile.FileName.Substring(oFile.FileName.LastIndexOf("\\") + 1);
            }
        }

        private void GVSP_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaSP.Text = GVSP.CurrentRow.Cells[0].Value.ToString();
                cbbMaLoai.Text = GVSP.CurrentRow.Cells[1].Value.ToString();
                cbbHangSX.Text = GVSP.CurrentRow.Cells[2].Value.ToString();
                cbbMaXuatXu.Text = GVSP.CurrentRow.Cells[3].Value.ToString();
                txtTenSP.Text = GVSP.CurrentRow.Cells[4].Value.ToString();
                txthinhanh.Text = GVSP.CurrentRow.Cells[5].Value.ToString();
                txtThanhPhan.Text = GVSP.CurrentRow.Cells[6].Value.ToString();
                txtCongDung.Text = GVSP.CurrentRow.Cells[7].Value.ToString();
                txtBaoQuan.Text = GVSP.CurrentRow.Cells[8].Value.ToString();
                txtGhiChu.Text = GVSP.CurrentRow.Cells[9].Value.ToString();
                cbbDonViTinh.Text = GVSP.CurrentRow.Cells[10].Value.ToString();
                txtSoLo.Text = GVSP.CurrentRow.Cells[11].Value.ToString();
                DTPSanXuat.Text = GVSP.CurrentRow.Cells[12].Value.ToString();
                DTPHanSD.Text = GVSP.CurrentRow.Cells[13].Value.ToString();
                txtDonGia.Text = GVSP.CurrentRow.Cells[14].Value.ToString();
                txtSoLuongTon.Text = GVSP.CurrentRow.Cells[15].Value.ToString();

                Bitmap anh = new Bitmap(@"C:\Users\Admin\OneDrive\Desktop\QTNPP_PEPSI\HinhAnhSP\" + txthinhanh.Text);
     
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = (Image)anh;
            }
            catch
            { }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (SP.sua_SP(txtMaSP.Text, cbbMaLoai.SelectedValue.ToString(), cbbHangSX.SelectedValue.ToString(), cbbMaXuatXu.SelectedValue.ToString(),
                    txtTenSP.Text, txthinhanh.Text, txtThanhPhan.Text, txtCongDung.Text, txtBaoQuan.Text, txtGhiChu.Text, cbbDonViTinh.SelectedValue.ToString(),
                    int.Parse(txtSoLo.Text), DateTime.Parse(DTPSanXuat.Text), DateTime.Parse(DTPHanSD.Text), decimal.Parse(txtDonGia.Text)
                    ) == 1)
                {
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVSP.DataSource = SP.load_SP();
                }
                else
                {
                    MessageBox.Show("Sửa dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }         
            }
            catch
            {
                MessageBox.Show("Sửa dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (SP.xoa_SP(txtMaSP.Text) == 1 && txtSoLuongTon.Text == "0")
                {
                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVSP.DataSource = SP.load_SP();
                }
                else
                {
                    MessageBox.Show("Xóa dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Xoá dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtTenSP.Text) || String.IsNullOrEmpty(txtSoLo.Text) || String.IsNullOrEmpty(txtDonGia.Text) || String.IsNullOrEmpty(txtThanhPhan.Text) || String.IsNullOrEmpty(txtCongDung.Text) || String.IsNullOrEmpty(txtGhiChu.Text) || String.IsNullOrEmpty(cbbDonViTinh.Text) || String.IsNullOrEmpty(cbbHangSX.Text) || String.IsNullOrEmpty(cbbMaLoai.Text) || String.IsNullOrEmpty(cbbMaXuatXu.Text))
            {
                MessageBox.Show("Dữ liệu không được để trống!", "Thông báo");
                return;
            }
            try
            {
                SP.them_SP(txtMaSP.Text, cbbMaLoai.SelectedValue.ToString(), cbbHangSX.SelectedValue.ToString(), cbbMaXuatXu.SelectedValue.ToString(),
                    txtTenSP.Text, txthinhanh.Text, txtThanhPhan.Text, txtCongDung.Text, txtBaoQuan.Text, txtGhiChu.Text, cbbDonViTinh.SelectedValue.ToString(),
                    int.Parse(txtSoLo.Text), DateTime.Parse(DTPSanXuat.Text), DateTime.Parse(DTPHanSD.Text), decimal.Parse(txtDonGia.Text),
                    int.Parse(txtSoLuongTon.Text));

                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GVSP.DataSource = SP.load_SP();
            }

            catch
            {
                MessageBox.Show("Thêm dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void TangMaTuDong_thuoc()
        {
            List<SANPHAM> lst = new List<SANPHAM>();
            lst = SP.getSanPham();
            string a = GVSP.Rows[GVSP.Rows.Count - 1].Cells[0].Value.ToString();
            string masp = "SP";
            string b = a.Substring(2, 2);
            int ma = Convert.ToInt32(b);
            ma = ma + 1;
            if (lst.Count < 9)
                masp = masp + "0";
            else
                masp = masp + "";
            masp += ma;

            txtMaSP.Text = masp;
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            TangMaTuDong_thuoc();
            txtTenSP.Enabled = true;
            cbbHangSX.Text = string.Empty;
            cbbHangSX.Text = string.Empty;
            cbbMaXuatXu.Text = string.Empty;
            cbbMaLoai.Text = string.Empty;
            txtTenSP.Text = string.Empty;
            txtThanhPhan.Text = "";
            txtCongDung.Text = "";

            txtBaoQuan.Text = "";
            txtGhiChu.Text = "";
            cbbDonViTinh.Text = "";
            txtSoLo.Text = "";
            txtSoLuongTon.Text = "0";
            txtDonGia.Text = "";
            DTPSanXuat.Text = "";
            DTPHanSD.Text = "";
            btnThem.Enabled = true;
        }

        private void FormSanPham_Load(object sender, EventArgs e)
        {
            if (FormDangNhap.nv.MANHOMNV == "NV")
            {
                btnLoadAnh.Enabled = btnThem.Enabled = btnXoa.Enabled = btnTaoMoi.Enabled = btnSua.Enabled = false;
            }

            //đổi link
            Bitmap anh = new Bitmap(@"C:\Users\Admin\OneDrive\Desktop\QTNPP_PEPSI\HinhAnhSP\7upChai.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = (Image)anh;
            GVSP.DataSource = SP.load_SP();

            cbbHangSX.DataSource = HSX.load_TenHSX();
            cbbHangSX.DisplayMember = "TenHSX";
            cbbHangSX.ValueMember = "MaHSX";

            cbbMaLoai.DataSource = LoaiSP.load_TenLoaiSP();
            cbbMaLoai.DisplayMember = "TENLOAISANPHAM";
            cbbMaLoai.ValueMember = "MALOAISANPHAM";

            cbbMaXuatXu.DataSource = XX.load_TenXuatXu();
            cbbMaXuatXu.DisplayMember = "tenxuatxu";
            cbbMaXuatXu.ValueMember = "Maxuatxu";

            cbbDonViTinh.DataSource = SP.load_DVT();
            cbbDonViTinh.DisplayMember = "DVT";
            cbbDonViTinh.ValueMember = "DVT";
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSoLuongTon_KeyPress(object sender, KeyPressEventArgs e)
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
