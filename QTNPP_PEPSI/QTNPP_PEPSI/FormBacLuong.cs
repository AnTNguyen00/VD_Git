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
    public partial class FormBacLuong : Form
    {
        BacLuong_DALBLL bacluong = new BacLuong_DALBLL();

        public FormBacLuong()
        {
            InitializeComponent();
        }

        private void FormBacLuong_Load(object sender, EventArgs e)
        {
            GVBacLuong.DataSource = bacluong.load_BacLuong();
            GVChiTietBacLuong.DataSource = bacluong.load_CTBacLuong();

            //Khởi tạo combobox Nhân viên
            cbbNhanVien.DataSource = bacluong.load_CTBacLuong();
            cbbNhanVien.DisplayMember = "HOTENNV";
            cbbNhanVien.ValueMember = "MANV";

            //chỉ định dòng đầu vào textbox
            txtMaBacLuong.Text = GVBacLuong.CurrentRow.Cells[0].Value.ToString();
            txtTenBacLuong.Text = GVBacLuong.CurrentRow.Cells[1].Value.ToString();
            txtHeSoLuong.Text = GVBacLuong.CurrentRow.Cells[2].Value.ToString();

            txtMaBacLuong.Text = GVChiTietBacLuong.CurrentRow.Cells[0].Value.ToString();
            cbbNhanVien.Text = GVChiTietBacLuong.CurrentRow.Cells[1].Value.ToString();
            DTPTuNgay.Text = GVChiTietBacLuong.CurrentRow.Cells[2].Value.ToString();
            DTPDenNgay.Text = GVChiTietBacLuong.CurrentRow.Cells[3].Value.ToString();

            btnThem.Enabled = false;
            btnThemCT.Enabled = false;
            txtMaBacLuong.Enabled = false;
        }

        private void GVBacLuong_Click(object sender, EventArgs e)
        {
            txtMaBacLuong.Text = GVBacLuong.CurrentRow.Cells[0].Value.ToString();
            txtTenBacLuong.Text = GVBacLuong.CurrentRow.Cells[1].Value.ToString();
            txtHeSoLuong.Text = GVBacLuong.CurrentRow.Cells[2].Value.ToString();
        }

        private void GVChiTietBacLuong_Click(object sender, EventArgs e)
        {
            txtMaBacLuong.Text = GVChiTietBacLuong.CurrentRow.Cells[0].Value.ToString();
            cbbNhanVien.Text = GVChiTietBacLuong.CurrentRow.Cells[1].Value.ToString();
            DTPTuNgay.Text = GVChiTietBacLuong.CurrentRow.Cells[2].Value.ToString();
            DTPDenNgay.Text = GVChiTietBacLuong.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            List<BACLUONG> lst = new List<BACLUONG>();
            lst = bacluong.getBacLuong();
            //string a = GVBacLuong.Rows[GVBacLuong.Rows.Count - 1].Cells[0].Value.ToString();
            string mabac = "";
            mabac = "B";
            int ma = lst.Count;
            ma = ma + 1;
            if (lst.Count <= 9)
                mabac = mabac + "0";
            else
                mabac = mabac + "";

            mabac += ma.ToString();

            txtMaBacLuong.Text = mabac;

            btnThem.Enabled = true;
            txtTenBacLuong.Clear();
            txtHeSoLuong.Clear();
            txtTenBacLuong.Focus();
        }

        private void clear()
        {
            txtMaBacLuong.Clear();
            txtTenBacLuong.Clear();
            txtHeSoLuong.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                bacluong.insert_Bac(txtMaBacLuong.Text, txtTenBacLuong.Text, Convert.ToDouble(txtHeSoLuong.Text));
                MessageBox.Show("Thêm dữ liệu  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GVBacLuong.DataSource = bacluong.load_BacLuong();
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
                if (bacluong.delete_Bac(txtMaBacLuong.Text) == 1)
                {
                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVBacLuong.DataSource = bacluong.load_BacLuong();
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
                if (bacluong.update_Bac(txtMaBacLuong.Text, txtTenBacLuong.Text, Convert.ToDouble(txtHeSoLuong.Text)) == 1)
                {
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVBacLuong.DataSource = bacluong.load_BacLuong();
                }
                else
                {
                    MessageBox.Show("Sửa dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Xoá dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTaoMoiCT_Click(object sender, EventArgs e)
        {
            btnThemCT.Enabled = true;           
            cbbNhanVien.ResetText();
            DTPTuNgay.Text = string.Empty;
            DTPDenNgay.Text = string.Empty;
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            try
            {
                bacluong.insert_CTBac(txtMaBacLuong.Text, cbbNhanVien.SelectedValue.ToString(), DateTime.Parse(DTPTuNgay.Text), DateTime.Parse(DTPDenNgay.Text));
                MessageBox.Show("Thêm dữ liệu  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GVChiTietBacLuong.DataSource = bacluong.load_CTBacLuong();
                btnThem.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Thêm dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            try
            {
                string mabac = GVChiTietBacLuong.CurrentRow.Cells[0].Value.ToString();
                string manv = GVChiTietBacLuong.CurrentRow.Cells[1].Value.ToString();
                bacluong.delete_CTBac(mabac, manv);
                MessageBox.Show("Xoá dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GVChiTietBacLuong.DataSource = bacluong.load_CTBacLuong();
                clear();
            }
            catch
            {
                MessageBox.Show("Xoá dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            try
            {
                if (bacluong.update_CTBL(txtMaBacLuong.Text, cbbNhanVien.Text, DateTime.Parse(DTPTuNgay.Text), DateTime.Parse(DTPDenNgay.Text)) == 1)
                {
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVChiTietBacLuong.DataSource = bacluong.load_CTBacLuong();
                }
                else
                {
                    MessageBox.Show("Sửa dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Xoá dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
