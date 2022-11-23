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
    public partial class FormChamCong : Form
    {
        QLNPP_PEPSI1DataContext QLNPP_PS = new QLNPP_PEPSI1DataContext();
        ChamCong_DALBLL chamcong = new ChamCong_DALBLL();
        NhanVien_DALBLL nv = new NhanVien_DALBLL();

        public FormChamCong()
        {
            InitializeComponent();
        }

        private void FormChamCong_Load(object sender, EventArgs e)
        {
            if (FormDangNhap.nv.MANHOMNV == "NV")
            {
                GvChamCong.DataSource = chamcong.load_ChamCongNV(FormDangNhap.nv.MANV);
                txtMaChamCong.Text = GvChamCong.Rows[GvChamCong.Rows.Count - 1].Cells[0].Value.ToString();
                panelEx1.Visible = false;
                panelEx2.Visible = false;
            }
            else
            {
                GvChamCong.DataSource = chamcong.load_ChamCong();
                cbbMaNhanVien.DataSource = nv.load_TenNV();
                cbbMaNhanVien.ValueMember = "MANV";
                cbbMaNhanVien.DisplayMember = "HOTENNV";
            }
        }

        private void GvChamCong_Click(object sender, EventArgs e)
        {
            try
            {
                cbbMaNhanVien.Text = GvChamCong.CurrentRow.Cells[0].Value.ToString();
                txtMaCC2.Text = GvChamCong.CurrentRow.Cells[1].Value.ToString();
                txtThang.Text = GvChamCong.CurrentRow.Cells[3].Value.ToString();
                txtNam.Text = GvChamCong.CurrentRow.Cells[4].Value.ToString();
                txtSoNgayLam.Text = GvChamCong.CurrentRow.Cells[5].Value.ToString();
            }
            catch { }
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            try
            {
                int soNgayLam = Int32.Parse(GvChamCong.CurrentRow.Cells[5].Value.ToString());
                chamcong.chamCong(txtMaChamCong.Text, FormDangNhap.nv.MANV, soNgayLam);
                GvChamCong.DataSource = chamcong.load_ChamCongNV(FormDangNhap.nv.MANV);
                MessageBox.Show("Thực hiện chấm công thành công", "Thông báo");
                btnThoat_Click(sender, e);
            }
            catch
            { }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtMaChamCong.Text = string.Empty;
            cbbMaNhanVien.Text = string.Empty;
            txtMaCC2.Text = string.Empty;
            txtThang.Text = string.Empty;
            txtNam.Text = string.Empty;
            txtSoNgayLam.Text = string.Empty;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaCC2.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lbMCC.Text.ToLower());
                this.txtMaChamCong.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cbbMaNhanVien.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lbMNV.Text.ToLower());
                this.cbbMaNhanVien.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtThang.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lbThang.Text.ToLower());
                this.txtMaChamCong.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtNam.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lbNam.Text.ToLower());
                this.txtMaChamCong.Focus();
                return;
            }

            CHAMCONG cc = QLNPP_PS.CHAMCONGs.Where(t => t.MANV == cbbMaNhanVien.SelectedValue.ToString() && t.MACHAMCONG == txtMaCC2.Text).FirstOrDefault();
            if (cc == null)
            {
                chamcong.insert_ChamCong(txtMaCC2.Text, cbbMaNhanVien.SelectedValue.ToString(), Int32.Parse(txtThang.Text), Int32.Parse(txtNam.Text), Int32.Parse(txtSoNgayLam.Text));
                GvChamCong.DataSource = chamcong.load_ChamCong();
                MessageBox.Show("Thêm thành công", "Thông báo");
            }
            else
            {
                cc.SONGAYLAMVIEC = Int32.Parse(txtSoNgayLam.Text);
                QLNPP_PS.SubmitChanges();
                GvChamCong.DataSource = chamcong.load_ChamCong();
                MessageBox.Show("Giá trị đã có, sửa thành công", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Muốn xóa bảng chấm công này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string manv = GvChamCong.CurrentRow.Cells[0].Value.ToString();
                    string macc = GvChamCong.CurrentRow.Cells[1].Value.ToString(); 
                    chamcong.delete_ChamCong(macc, manv);
                    MessageBox.Show("Xoá dữ liệu  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    GvChamCong.DataSource = chamcong.load_ChamCong();
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
    }
}
