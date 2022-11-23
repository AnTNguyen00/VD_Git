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
    public partial class FormQuanLyTaiKhoan : Form
    {
        NhanVien_DALBLL nv = new NhanVien_DALBLL();
        PhanQuyen_DALPLL pq = new PhanQuyen_DALPLL();

        public FormQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void FormQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            cbbMaNhanVien.DataSource = nv.load_TenNV();
            cbbMaNhanVien.DisplayMember = "HOTENNV";
            cbbMaNhanVien.ValueMember = "MANV";

            cbbMaNhomNV.DataSource = nv.load_NhomNV();
            cbbMaNhomNV.DisplayMember = "TENNHOM";
            cbbMaNhomNV.ValueMember = "MANHOMNV";

            cbbQuyen.DataSource = nv.load_NhomNV();
            cbbQuyen.DisplayMember = "TENNHOM";
            cbbQuyen.ValueMember = "MANHOMNV";
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (pq.capnhat_Quyen(cbbMaNhanVien.SelectedValue.ToString(), cbbMaNhomNV.SelectedValue.ToString()))
            {
                MessageBox.Show("Thay đổi quyền thành công!", "Thông báo");
                return;
            }
            else
            {
                MessageBox.Show("Thay đổi quyền thất bại!", "Thông báo");
                return;
            }
        }

        private void cbbQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            GvQuyenKhongDuoc.DataSource = pq.load_QuyenChuaCo(cbbQuyen.SelectedValue.ToString());
            GvQuyenDuoc.DataSource = pq.load_QuyenCo(cbbQuyen.SelectedValue.ToString());
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (GvQuyenKhongDuoc.SelectedRows.Count > 0)
            {
                pq.them_Quyen("NV", GvQuyenKhongDuoc.CurrentRow.Cells[0].Value.ToString());
                GvQuyenKhongDuoc.DataSource = pq.load_QuyenChuaCo(cbbQuyen.SelectedValue.ToString());
                GvQuyenDuoc.DataSource = pq.load_QuyenCo(cbbQuyen.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("Vui lòng chọn danh mục màn hình!", "Thông báo");
                return;
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (GvQuyenDuoc.SelectedRows.Count > 0)
            {
                pq.xoa_Quyen("NV", GvQuyenDuoc.CurrentRow.Cells[0].Value.ToString());
                GvQuyenKhongDuoc.DataSource = pq.load_QuyenChuaCo(cbbQuyen.SelectedValue.ToString());
                GvQuyenDuoc.DataSource = pq.load_QuyenCo(cbbQuyen.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("Vui lòng chọn danh mục màn hình!", "Thông báo");
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            //chưa dc
            //GvQuyenKhongDuoc.DataSource = pq.load_QuyenChuaCo(cbbMaNhanVien.SelectedValue.ToString());
            //GvQuyenDuoc.DataSource = pq.load_QuyenCo(cbbMaNhanVien.SelectedValue.ToString());
        }
    }
}
