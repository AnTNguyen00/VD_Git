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
    public partial class FormPAL : Form
    {
        PAL_DALBLL pal = new PAL_DALBLL();

        public FormPAL()
        {
            InitializeComponent();
            btnThem.Enabled = false;
        }

        private void FormPAL_Load(object sender, EventArgs e)
        {
            if (FormDangNhap.nv.MANHOMNV == "NV")
            {
                btnSua.Enabled = btnTaoMoi.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            }

            GVPAL.DataSource = pal.load_PAL();
            txtMaPAL.Text = GVPAL.CurrentRow.Cells[0].Value.ToString();
            txtTenPAL.Text = GVPAL.CurrentRow.Cells[1].Value.ToString();

            btnThem.Enabled = false;
            txtMaPAL.Enabled = false;
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            List<PAL> lst = new List<PAL>();
            lst = pal.getPAL();
            string a = GVPAL.Rows[GVPAL.Rows.Count - 1].Cells[0].Value.ToString();
            string mapal = "";
            mapal = "PAL";
            int ma = lst.Count;
            ma = ma + 1;
            if (lst.Count < 9)
                mapal = mapal + "";
            else
                mapal = mapal + "0";
            mapal += ma.ToString();

            txtMaPAL.Text = mapal;

            btnThem.Enabled = true;

            txtTenPAL.Clear();
        }

        private void clear()
        {
            txtMaPAL.Clear();
            txtTenPAL.Clear();  
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                pal.them_PAL(txtMaPAL.Text, txtTenPAL.Text);
                MessageBox.Show("Thêm dữ liệu  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GVPAL.DataSource = pal.load_PAL();
            }
            catch
            {
                MessageBox.Show("Thêm dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GVPAL_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaPAL.Text = GVPAL.CurrentRow.Cells[0].Value.ToString();
                txtTenPAL.Text = GVPAL.CurrentRow.Cells[1].Value.ToString();
            }
            catch
            { }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (pal.xoa_PAL(txtMaPAL.Text) == 1)
                {
                    MessageBox.Show("Xoá dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVPAL.DataSource = pal.load_PAL();
                    clear();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (pal.sua_PAL(txtMaPAL.Text,txtTenPAL.Text) == 1)
                {
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVPAL.DataSource = pal.load_PAL();
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
