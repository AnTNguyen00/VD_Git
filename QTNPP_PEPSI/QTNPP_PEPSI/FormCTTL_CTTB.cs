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
    public partial class FormCTTL_CTTB : Form
    {
        CTTB_DALBLL TBTL = new CTTB_DALBLL();
        SP_DALBLL SP = new SP_DALBLL();

        public FormCTTL_CTTB()
        {
            InitializeComponent();
        }

        private void btnLoadAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFile = new OpenFileDialog();
            oFile.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (oFile.ShowDialog() == DialogResult.OK)
            {
                txtHinhAnh.Text = oFile.FileName.Substring(oFile.FileName.LastIndexOf("\\") + 1);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            List<CTTB_CTTL> lst = new List<CTTB_CTTL>();
            lst = TBTL.getTBTL();
            string a = GVCTTB.Rows[GVCTTB.Rows.Count - 1].Cells[0].Value.ToString();
            string matbtl = "CT";
            string b = a.Substring(2, 2);
            int ma = Convert.ToInt32(b);
            ma = ma + 1;
            if (lst.Count < 9)
                matbtl = matbtl + "0";
            else
                matbtl = matbtl + "";
            matbtl += ma;

            txtMaCT.Text = matbtl;

            txtTenCT.Clear();
            cbbMaSP.Text = "";
            txtDiemDat.Clear();
            integerInput_SoSuat.Text = "0";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaCT.Text) || String.IsNullOrEmpty(txtTenCT.Text) || String.IsNullOrEmpty(txtHinhAnh.Text) || String.IsNullOrEmpty(integerInput_SoSuat.Text) || String.IsNullOrEmpty(cbbMaSP.Text))
            {
                MessageBox.Show("Dữ liệu không được để trống!", "Thông báo");
                return;
            }
            try
            {
                TBTL.insert_CTTB(txtMaCT.Text, txtTenCT.Text,integerInput_SoSuat.Value, cbbMaSP.SelectedValue.ToString(), DateTime.Parse(DTPNgayBD.Text), DateTime.Parse(DTPNgayKT.Text), decimal.Parse(txtDiemDat.Text),txtHinhAnh.Text);

                MessageBox.Show("Thêm dữ liệu  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GVCTTB.DataSource = TBTL.load_TBTL();
            }
            catch
            {
                MessageBox.Show("Thêm dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormCTTL_CTTB_Load(object sender, EventArgs e)
        {
            if (FormDangNhap.nv.MANHOMNV == "NV")
            {
                btnLoadAnh.Enabled = btnThem.Enabled = btnXoa.Enabled = btnTaoMoi.Enabled = btnSua.Enabled = false;
            }

            //đổi link
            Bitmap anh = new Bitmap(@"C:\Users\Admin\OneDrive\Desktop\QTNPP_PEPSI\hinhnew\1080-x-540-go-v-central-retail.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = (Image)anh;

            GVCTTB.DataSource = TBTL.load_TBTL();

            cbbMaSP.DataSource = SP.load_TenSP();
            cbbMaSP.DisplayMember = "TENSANPHAM";
            cbbMaSP.ValueMember = "MASP";

            txtTenCT.Enabled = true;
        }

        private void GVCTTB_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaCT.Text = GVCTTB.CurrentRow.Cells[0].Value.ToString();
                txtTenCT.Text = GVCTTB.CurrentRow.Cells[1].Value.ToString();
                integerInput_SoSuat.Text = GVCTTB.CurrentRow.Cells[2].Value.ToString();
                cbbMaSP.Text = GVCTTB.CurrentRow.Cells[3].Value.ToString();
                DTPNgayBD.Text = GVCTTB.CurrentRow.Cells[4].Value.ToString();
                DTPNgayKT.Text = GVCTTB.CurrentRow.Cells[5].Value.ToString();
                txtDiemDat.Text = GVCTTB.CurrentRow.Cells[6].Value.ToString();
                txtHinhAnh.Text= GVCTTB.CurrentRow.Cells[7].Value.ToString();

                Bitmap anh = new Bitmap(@"C:\Users\Admin\OneDrive\Desktop\QTNPP_PEPSI\hinhnew\" + txtHinhAnh.Text);

                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = (Image)anh;
            }
            catch
            { }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (TBTL.delete_CTTB(txtMaCT.Text) == 1)
                {
                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVCTTB.DataSource = TBTL.load_TBTL();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (TBTL.update_CTTB(txtMaCT.Text, txtTenCT.Text, integerInput_SoSuat.Value, cbbMaSP.SelectedValue.ToString(), DateTime.Parse(DTPNgayBD.Text), DateTime.Parse(DTPNgayKT.Text), decimal.Parse(txtDiemDat.Text), txtHinhAnh.Text) == 1)
                {
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVCTTB.DataSource = TBTL.load_TBTL();
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
    }
}
