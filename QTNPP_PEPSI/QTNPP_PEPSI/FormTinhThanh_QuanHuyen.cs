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
    public partial class FormTinhThanh_QuanHuyen : Form
    {
        TinhThanh_DALBLL tinhthanh = new TinhThanh_DALBLL();
        QuanHuyen_DALBLL quanhuyen = new QuanHuyen_DALBLL();

        public FormTinhThanh_QuanHuyen()
        {
            InitializeComponent();
        }

        private void FormTinhThanh_QuanHuyen_Load(object sender, EventArgs e)
        {
            if (FormDangNhap.nv.MANHOMNV == "NV")
            {
                btnTaoMoiTT.Enabled = btnThemTT.Enabled = btnXoaTT.Enabled = false;
                btnTaoMoiQH.Enabled = btnThemQH.Enabled = btnXoaQH.Enabled = false;
            }
            GvTinhThanh.DataSource = tinhthanh.load_TinhThanh();

            //Khởi tạo combobox Tỉnh thành
            cbbTinhThanh.DataSource = tinhthanh.load_TinhThanh();
            cbbTinhThanh.DisplayMember = "MATINHTHANH";
            cbbTinhThanh.ValueMember = "MATINHTHANH";

            //chỉ định dòng đầu vào textbox của tỉnh thành
            txtMaTinhThanh.Text = GvTinhThanh.CurrentRow.Cells[0].Value.ToString();
            txtTenTinhThanh.Text = GvTinhThanh.CurrentRow.Cells[1].Value.ToString();

            btnThemTT.Enabled = false;
            btnThemQH.Enabled = false;
            txtMaTinhThanh.Enabled = false;
            txtTenTinhThanh.Enabled = false;
            txtMaQuanHuyen.Enabled = false;
            txtTenQuanHuyen.Enabled = false;
            cbbTinhThanh.Enabled = false;
        }

        private void GVQuanHuyen_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaQuanHuyen.Text = GVQuanHuyen.CurrentRow.Cells[0].Value.ToString();
                cbbTinhThanh.Text = GVQuanHuyen.CurrentRow.Cells[1].Value.ToString();
                txtTenQuanHuyen.Text = GVQuanHuyen.CurrentRow.Cells[2].Value.ToString();

                List<TINHTHANH> lstTinhThanh = new List<TINHTHANH>();
                lstTinhThanh = tinhthanh.load_TinhThanh();

                //Binding giá trị mã tỉnh thành sang combobox Tinh thanh
                foreach (TINHTHANH i in lstTinhThanh)
                {
                    if (i.MATINHTHANH == GVQuanHuyen.CurrentRow.Cells[1].Value.ToString())
                    {
                        cbbTinhThanh.SelectedItem = i;
                        break;
                    }
                }
            }
            catch
            { }
        }

        private void GvTinhThanh_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaTinhThanh.Text = GvTinhThanh.CurrentRow.Cells[0].Value.ToString();
                txtTenTinhThanh.Text = GvTinhThanh.CurrentRow.Cells[1].Value.ToString();

                GVQuanHuyen.DataSource = quanhuyen.getQuanHuyen1(GvTinhThanh.CurrentRow.Cells[0].Value.ToString());
            }
            catch
            { }
        }

        private void btnTaoMoiQH_Click(object sender, EventArgs e)
        {
            btnThemQH.Enabled = true;
            txtMaQuanHuyen.Enabled = true;
            txtTenQuanHuyen.Enabled = true;
            cbbTinhThanh.Enabled = true;

            //================================================//
            txtMaQuanHuyen.Clear();
            txtTenQuanHuyen.Clear();
        }

        private void clearQH()
        {
            txtMaQuanHuyen.Clear();
            cbbTinhThanh.ResetText();
            txtTenQuanHuyen.Clear();
        }

        private void btnThemQH_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu rỗng
            if (String.IsNullOrEmpty(txtMaQuanHuyen.Text) || String.IsNullOrEmpty(txtTenQuanHuyen.Text))
            {
                MessageBox.Show("Dữ liệu không được để trống", "Thông báo");
                return;
            }

            //Kiểm tra tên quận huyện đã tồn tại hay chưa
            List<QUANHUYEN> lstQuanHuyen = new List<QUANHUYEN>();
            lstQuanHuyen = quanhuyen.getQuanHuyenLst();
            foreach (QUANHUYEN i in lstQuanHuyen)
            {
                if (i.TENQUANHUYEN == txtTenQuanHuyen.Text)
                {
                    MessageBox.Show("Quận Huyện đã tồn tại", "Thông báo");
                    FormTinhThanh_QuanHuyen_Load(sender, e);
                    return;
                }
            }

            //Thêm dữ liệu
            if (quanhuyen.insertQuanHuyen(txtMaQuanHuyen.Text, cbbTinhThanh.SelectedValue.ToString(), txtTenQuanHuyen.Text) == true)
            {
                MessageBox.Show("Thêm thành công", "Thông báo");
                FormTinhThanh_QuanHuyen_Load(sender, e);
                return;
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Thông báo");
                FormTinhThanh_QuanHuyen_Load(sender, e);
                return;
            }
        }

        private void btnXoaQH_Click(object sender, EventArgs e)
        {
            if (quanhuyen.deleteQuanHuyen(txtMaQuanHuyen.Text) == true)
            {
                MessageBox.Show("Xóa thành công", "Thông báo");
                FormTinhThanh_QuanHuyen_Load(sender, e);
                return;
            }
            else
            {
                MessageBox.Show("Xóa thất bại", "Thông báo");
                FormTinhThanh_QuanHuyen_Load(sender, e);
                return;
            }
        }

        private void btnTaoMoiTT_Click(object sender, EventArgs e)
        {
            btnThemTT.Enabled = true;
            txtMaTinhThanh.Enabled = true;
            txtTenTinhThanh.Enabled = true;

            //================================================//
            txtMaTinhThanh.Clear();
            txtTenTinhThanh.Clear();
        }

        private void clearTT()
        {
            txtMaTinhThanh.Clear();
            txtTenTinhThanh.Clear();
        }

        private void btnThemTT_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu rỗng
            if (String.IsNullOrEmpty(txtMaTinhThanh.Text) || String.IsNullOrEmpty(txtTenTinhThanh.Text))
            {
                MessageBox.Show("Dữ liệu không được để trống", "Thông báo");
                return;
            }

            //Kiểm tra tên tỉnh thành đã tồn tại hay chưa
            List<TINHTHANH> lstTinhThanh = new List<TINHTHANH>();
            lstTinhThanh = tinhthanh.load_TinhThanh();
            foreach (TINHTHANH i in lstTinhThanh)
            {
                if (i.TENTINHTHANH == txtTenTinhThanh.Text)
                {
                    MessageBox.Show("Tỉnh Thành đã tồn tại", "Thông báo");
                    FormTinhThanh_QuanHuyen_Load(sender, e);
                    return;
                }
            }

            //Thêm dữ liệu
            if (tinhthanh.them_TinhThanh(txtMaTinhThanh.Text, txtTenTinhThanh.Text) == true)
            {
                MessageBox.Show("Thêm thành công", "Thông báo");
                FormTinhThanh_QuanHuyen_Load(sender, e);
                return;
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Thông báo");
                FormTinhThanh_QuanHuyen_Load(sender, e);
                return;
            }
        }

        private void btnXoaTT_Click(object sender, EventArgs e)
        {
            if (tinhthanh.xoa_TinhThanh(txtMaTinhThanh.Text) == true)
            {
                MessageBox.Show("Xóa thành công", "Thông báo");
                FormTinhThanh_QuanHuyen_Load(sender, e);
                return;
            }
            else
            {
                MessageBox.Show("Xóa thất bại", "Thông báo");
                FormTinhThanh_QuanHuyen_Load(sender, e);
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
