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
    public partial class FormKhachHang : Form
    {
        KhachHang_DALBLL kh = new KhachHang_DALBLL();
        QuanHuyen_DALBLL quanhuyen = new QuanHuyen_DALBLL();
        LoaiKhachHang_DALBLL loaikh = new LoaiKhachHang_DALBLL();

        public FormKhachHang()
        {
            InitializeComponent();
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            GVKhachHang.DataSource = kh.load_KhachHang();

            //Khởi tạo combobox Loại KH
            cbbLoaiKH.DataSource = loaikh.load_TenLoaiKH();
            cbbLoaiKH.DisplayMember = "TENLOAIKH";
            cbbLoaiKH.ValueMember = "LOAIKHACHHANG1";


            //Khởi tạo combobox Quận huyện
            cbbQuanHuyen.DataSource = quanhuyen.load_TenQuanHuyen();
            cbbQuanHuyen.DisplayMember = "TENQUANHUYEN";
            cbbQuanHuyen.ValueMember = "MAQUANHUYEN";

            //chỉ định dòng đầu vào textbox
            txtMaKhachHang.Text = GVKhachHang.CurrentRow.Cells[0].Value.ToString();
            cbbQuanHuyen.SelectedValue = GVKhachHang.CurrentRow.Cells[1].Value.ToString();
            txtHoTenKH.Text = GVKhachHang.CurrentRow.Cells[2].Value.ToString();
            cbbLoaiKH.SelectedValue = GVKhachHang.CurrentRow.Cells[3].Value.ToString();
            DTPNgaysinh.Value = Convert.ToDateTime(GVKhachHang.CurrentRow.Cells[4].Value.ToString());
            txtDiaChi.Text = GVKhachHang.CurrentRow.Cells[6].Value.ToString();
            txtSDT.Text = GVKhachHang.CurrentRow.Cells[7].Value.ToString();

            btnThem.Enabled = false;
            txtMaKhachHang.Enabled = false;
        }

        #region Load giới tính theo KH

        List<string> lst_GioiTinh;
        public string GioiTinh(string maKH)
        {
            lst_GioiTinh = new List<string>();
            string gt = "";
            lst_GioiTinh = kh.load_GioiTinh(maKH);
            foreach (string sp in lst_GioiTinh)
            {
                try
                {
                    gt = sp.ToString(); //tên cột giới tính
                }
                catch
                {
                    return "";
                }
            }
            return gt;
        }

        public void checkGioiTinh(string maKH)
        {
            if (GioiTinh(maKH) == "Nam")
            {
                rdNam.Checked = true;
            }
            else
            {
                rdNu.Checked = true;
            }
        }

        #endregion

        private void GVKhachHang_Click(object sender, EventArgs e)
        {
            try
            {
                string kh = GVKhachHang.CurrentRow.Cells[0].Value.ToString();

                txtMaKhachHang.Text = GVKhachHang.CurrentRow.Cells[0].Value.ToString();
                cbbQuanHuyen.SelectedValue = GVKhachHang.CurrentRow.Cells[1].Value.ToString();
                txtHoTenKH.Text = GVKhachHang.CurrentRow.Cells[2].Value.ToString();
                cbbLoaiKH.SelectedValue = GVKhachHang.CurrentRow.Cells[3].Value.ToString();
                DTPNgaysinh.Value = Convert.ToDateTime(GVKhachHang.CurrentRow.Cells[4].Value.ToString());
                txtDiaChi.Text = GVKhachHang.CurrentRow.Cells[6].Value.ToString();
                txtSDT.Text = GVKhachHang.CurrentRow.Cells[7].Value.ToString();

                checkGioiTinh(kh);
            }
            catch
            { }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            List<KHACHHANG> lst = new List<KHACHHANG>();
            lst = kh.getKhachHang();
            string a = GVKhachHang.Rows[GVKhachHang.Rows.Count - 1].Cells[0].Value.ToString();
            string makh = "KH";
            string b = a.Substring(2, 2);
            int ma = Convert.ToInt32(b);
            ma = ma + 1;
            if (lst.Count < 9)
                makh = makh + "0";
            else
                makh = makh + "";
            makh += ma;


            txtMaKhachHang.Text = makh;
            btnThem.Enabled = true;
            txtHoTenKH.Clear();

            txtDiaChi.Clear();
            txtSDT.Clear();
            cbbLoaiKH.SelectedIndex = 0;
            cbbQuanHuyen.SelectedIndex = 0;

            txtDiaChi.Enabled = true;
            txtHoTenKH.Enabled = true;
            txtSDT.Enabled = true;

            txtHoTenKH.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaKhachHang.Text) || String.IsNullOrEmpty(txtHoTenKH.Text) || String.IsNullOrEmpty(txtSDT.Text) || String.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Dữ liệu không được để trống", "Thông báo");
                return;
            }

            string maKH = txtMaKhachHang.Text;
            string tenKH = txtHoTenKH.Text;
            string ngaySinh = DTPNgaysinh.Value.ToString();
            string loaiKH= cbbLoaiKH.SelectedValue.ToString();
            string maQH = cbbQuanHuyen.SelectedValue.ToString();

            string kt = rdNam.Checked ? "Nam" : "Nữ";

            string diaChi = txtDiaChi.Text;
            string sdT = txtSDT.Text;

            if (kh.insert_KH(maKH, maQH, tenKH, loaiKH, ngaySinh, kt, diaChi, sdT) == true)
            {
                MessageBox.Show("Thêm thành công", "Thông báo");
                FormKhachHang_Load(sender, e);
                return;
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Thông báo");
                FormKhachHang_Load(sender, e);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maKH = GVKhachHang.CurrentRow.Cells[0].Value.ToString();
            if (kh.delete_KH(maKH) == true)
            {
                MessageBox.Show("Xóa thành công", "Thông báo");
                FormKhachHang_Load(sender, e);
                return;
            }
            else
            {
                MessageBox.Show("Xóa thất bại", "Thông báo");
                FormKhachHang_Load(sender, e);
                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                FormKhachHang_Load(sender, e);
                btnLuu.Enabled = true;
                btnSua.Text = "Hủy";
            }
            else
            {
                FormKhachHang_Load(sender, e);
                btnSua.Text = "Sửa";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaKhachHang.Text) || String.IsNullOrEmpty(txtHoTenKH.Text) || String.IsNullOrEmpty(txtSDT.Text) || String.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Dữ liệu không được để trống!", "Thông báo");
                return;
            }

            //================================================//

            string maKH = txtMaKhachHang.Text;
            string tenKH = txtHoTenKH.Text;
            string ngaySinh = DTPNgaysinh.Value.ToString();
            string loaiKH = cbbLoaiKH.SelectedValue.ToString();
            string maQH = cbbQuanHuyen.SelectedValue.ToString();

            string kt = rdNam.Checked ? "Nam" : "Nữ";

            string diaChi = txtDiaChi.Text;
            string sdT = txtSDT.Text;

            //================================================//

            //Cập nhập dữ liệu
            if (kh.update_KH(maKH, maQH, tenKH, loaiKH, ngaySinh, kt, diaChi, sdT) == true)
            {
                MessageBox.Show("Cập nhập thành công", "Thông báo");
                FormKhachHang_Load(sender, e);
                return;
            }
            {
                MessageBox.Show("Cập nhập thất bại!", "Thông báo");
                FormKhachHang_Load(sender, e);
                return;
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            FormLoaiKhachHang formNew = new FormLoaiKhachHang();
            formNew.Show();
        }
    }
}
