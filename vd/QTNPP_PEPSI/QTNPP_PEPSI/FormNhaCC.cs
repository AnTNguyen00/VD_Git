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
    public partial class FormNhaCC : Form
    {
        NhaCC_DALBLL nhacc = new NhaCC_DALBLL();
        QuanHuyen_DALBLL quanhuyen = new QuanHuyen_DALBLL();

        public FormNhaCC()
        {
            InitializeComponent();
        }

        private void FormNhaCC_Load(object sender, EventArgs e)
        {
            if (FormDangNhap.nv.MANHOMNV == "NV")
            {
                btnSua.Enabled = btnTaoMoi.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            }
           
            GVNhaCC.DataSource = nhacc.load_NhaCC();

            cbbQuanHuyen.DataSource = quanhuyen.load_TenQuanHuyen();
            cbbQuanHuyen.DisplayMember = "TENQUANHUYEN";
            cbbQuanHuyen.ValueMember = "MAQUANHUYEN";

            //chỉ định dòng đầu vào textbox
            txtMaNCC.Text = GVNhaCC.CurrentRow.Cells[0].Value.ToString();
            cbbQuanHuyen.Text = GVNhaCC.CurrentRow.Cells[1].Value.ToString();
            txtTenNCC.Text = GVNhaCC.CurrentRow.Cells[2].Value.ToString();
            txtDiaChi.Text = GVNhaCC.CurrentRow.Cells[3].Value.ToString();
            txtSDT.Text = GVNhaCC.CurrentRow.Cells[4].Value.ToString();

            btnThem.Enabled = false;
            txtMaNCC.Enabled = false;
        }

        private void GVNhaCC_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaNCC.Text = GVNhaCC.CurrentRow.Cells[0].Value.ToString();
                cbbQuanHuyen.Text = GVNhaCC.CurrentRow.Cells[1].Value.ToString();
                txtTenNCC.Text = GVNhaCC.CurrentRow.Cells[2].Value.ToString();
                txtDiaChi.Text = GVNhaCC.CurrentRow.Cells[3].Value.ToString();
                txtSDT.Text = GVNhaCC.CurrentRow.Cells[4].Value.ToString();
            }
            catch
            { }
        }

        private void clear()
        {
            txtMaNCC.Clear();
            cbbQuanHuyen.ResetText();
            txtTenNCC.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            List<NHACUNGCAP> lst = new List<NHACUNGCAP>();
            lst = nhacc.getNhaCC();
            string a = GVNhaCC.Rows[GVNhaCC.Rows.Count - 1].Cells[0].Value.ToString();
            string malsp = "";
            malsp = "NCC";
            int ma = lst.Count;
            ma = ma + 1;
            if (lst.Count <= 9)
                malsp = malsp + "0";
            else
                malsp = malsp + "";

            malsp += ma.ToString();

            txtMaNCC.Text = malsp;

            btnThem.Enabled = true;
            cbbQuanHuyen.ResetText();
            txtTenNCC.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtTenNCC.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu rỗng
            if (String.IsNullOrEmpty(txtMaNCC.Text) || String.IsNullOrEmpty(txtTenNCC.Text) || String.IsNullOrEmpty(txtSDT.Text) || String.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Dữ liệu không được để trống!", "Thông báo");
                return;
            }

            try
            {
                nhacc.them_NhaCC(txtMaNCC.Text, cbbQuanHuyen.SelectedValue.ToString(), txtTenNCC.Text, txtDiaChi.Text, txtSDT.Text);
                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GVNhaCC.DataSource = nhacc.load_NhaCC();
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
                if (nhacc.xoa_NhaCC(txtMaNCC.Text) == 1)
                {
                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVNhaCC.DataSource = nhacc.load_NhaCC();
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
                if (nhacc.sua_NhaCC(txtMaNCC.Text, cbbQuanHuyen.SelectedValue.ToString(), txtTenNCC.Text, txtDiaChi.Text, txtSDT.Text) == 1)
                {
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVNhaCC.DataSource = nhacc.load_NhaCC();
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
    }
}
