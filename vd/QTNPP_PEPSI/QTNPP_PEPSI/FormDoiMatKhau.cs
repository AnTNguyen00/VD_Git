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
    public partial class FormDoiMatKhau : Form
    {
        NHANVIEN nvlog = FormDangNhap.nv;
        FormDangNhap dangnhap = new FormDangNhap();
        NhanVien_DALBLL nv = new NhanVien_DALBLL();
        FormTrangChu trangchu = new FormTrangChu();
        public FormDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            //Kiểm tra ô nhập giá trị
            if (String.IsNullOrEmpty(txtPassword.Text) || String.IsNullOrEmpty(txtNewPass.Text) || String.IsNullOrEmpty(txtRePass.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ giá trị !", "Thông báo");
                return;
            }

            if (nv.kiemTraTk(nvlog.TENDANGNHAP, txtPassword.Text))
            {
                if (txtNewPass.Text == txtRePass.Text)
                {
                    if (txtPassword.Text == txtNewPass.Text)
                    {
                        MessageBox.Show("Mật khẩu mới và mật khẩu hiện tại không được trùng nhau !", "Thông báo");
                        txtNewPass.Focus();
                        return;
                    }

                    if (nv.doiMatKhau(nvlog.TENDANGNHAP, txtNewPass.Text))
                    {
                        MessageBox.Show("Đổi mật khẩu thành công !", "Thông báo");
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Đổi thất bại", "Thông báo");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới phải trùng khớp với mật khẩu xác nhận !", "Thông báo");
                    txtNewPass.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu hiện tại sai. Vui lòng nhập lại !", "Thông báo");
                txtPassword.Focus();
                return;
            }
        }

        private void FormDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtUser.Text = nvlog.TENDANGNHAP.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox_ShowPass1_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }

        private void pictureBox_ShowPass2_Click(object sender, EventArgs e)
        {
            txtNewPass.UseSystemPasswordChar = !txtNewPass.UseSystemPasswordChar;
        }

        private void pictureBox_ShowPass3_Click(object sender, EventArgs e)
        {
            txtRePass.UseSystemPasswordChar = !txtRePass.UseSystemPasswordChar;
        }
    }
}
