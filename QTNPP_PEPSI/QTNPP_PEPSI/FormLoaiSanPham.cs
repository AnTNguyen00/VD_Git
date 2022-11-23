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
    public partial class FormLoaiSanPham : Form
    {
        LoaiSP_DALBLL loaisp = new LoaiSP_DALBLL();
        PAL_DALBLL pal = new PAL_DALBLL();

        public FormLoaiSanPham()
        {
            InitializeComponent();
        }

        private void FormLoaiSanPham_Load(object sender, EventArgs e)
        {
            if (FormDangNhap.nv.MANHOMNV == "NV")
            {
                btnSua.Enabled = btnTaoMoi.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            }
            GVLoaiSP.DataSource = loaisp.load_LoaiSP();

            //Khởi tạo combobox PAL
            cbbMaPAL.DataSource = pal.load_MAPAL();
            cbbMaPAL.DisplayMember = "MAPAL";
            cbbMaPAL.ValueMember = "MAPAL";

            //chỉ định dòng đầu vào textbox
            txtMaLoaiSP.Text = GVLoaiSP.CurrentRow.Cells[0].Value.ToString();
            cbbMaPAL.Text = GVLoaiSP.CurrentRow.Cells[1].Value.ToString();
            txtTenLoaiSP.Text = GVLoaiSP.CurrentRow.Cells[2].Value.ToString();

            btnThem.Enabled = false;
            txtMaLoaiSP.Enabled = false;
        }

        private void GVLoaiSP_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaLoaiSP.Text = GVLoaiSP.CurrentRow.Cells[0].Value.ToString();
                cbbMaPAL.Text = GVLoaiSP.CurrentRow.Cells[1].Value.ToString();
                txtTenLoaiSP.Text = GVLoaiSP.CurrentRow.Cells[2].Value.ToString();
            }
            catch
            { }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            List<LOAISANPHAM> lst = new List<LOAISANPHAM>();
            lst = loaisp.getLoaiSP();
            string a = GVLoaiSP.Rows[GVLoaiSP.Rows.Count - 1].Cells[0].Value.ToString();
            string malsp = "";
            malsp = "L";
            int ma = lst.Count;
            ma = ma + 1;
            if (lst.Count <= 9)
                malsp = malsp + "00";
            else if (lst.Count > 9 && lst.Count<100)
                malsp = malsp + "0";
            else
                malsp = malsp + "";

            malsp += ma.ToString();

            txtMaLoaiSP.Text = malsp;

            btnThem.Enabled = true;
            txtTenLoaiSP.Clear();
            cbbMaPAL.ResetText();
            txtTenLoaiSP.Focus();
        }

        private void clear()
        {
            txtMaLoaiSP.Clear();
            cbbMaPAL.ResetText();
            txtTenLoaiSP.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                loaisp.them_LoaiSP(txtMaLoaiSP.Text, txtTenLoaiSP.Text, cbbMaPAL.SelectedValue.ToString());
                MessageBox.Show("Thêm dữ liệu  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GVLoaiSP.DataSource = loaisp.load_LoaiSP();
                btnThem.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Thêm dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (loaisp.xoa_LoaiSP(txtMaLoaiSP.Text) == 1)
                {
                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVLoaiSP.DataSource = loaisp.load_LoaiSP();
                    clear();
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
                if (loaisp.sua_LoaiSP(txtMaLoaiSP.Text, txtTenLoaiSP.Text, cbbMaPAL.SelectedValue.ToString()) == 1)
                {
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVLoaiSP.DataSource = loaisp.load_LoaiSP();
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            FormPAL formNew = new FormPAL();
            formNew.Show();
        }
    }
}
