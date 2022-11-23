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
    public partial class FormDangNhap : Form
    {
        NhanVien_DALBLL NV = new NhanVien_DALBLL();
        public static NHANVIEN nv;
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            List<NHANVIEN> list = NV.checkDangNhap(txtUserName.Text, txtPassword.Text);
            if (list.Any())
            {
                foreach (NHANVIEN item in list)
                {
                    nv = item;
                }
                MessageBox.Show("Đăng nhập thành công");
                FormTrangChu newForm = new FormTrangChu();
                newForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại!");
                return;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.btnDangNhap_Click(sender, e);
        }

        private void pictureBox_ShowPassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }

        private void pictureBox_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
