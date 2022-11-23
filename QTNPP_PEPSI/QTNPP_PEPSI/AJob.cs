using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace QTNPP_PEPSI
{
    public partial class AJob : UserControl
    {
        private PlanItem job;
        private event EventHandler sua;
        private event EventHandler xoa;

        public PlanItem Job { get => job; set => job = value; }
        public event EventHandler Sua
        {
            add { sua += value; }
            remove { sua -= value; }
        }
        public event EventHandler Xoa
        {
            add { xoa += value; }
            remove { xoa -= value; }
        }

        public AJob(PlanItem job)
        {
            InitializeComponent();

            cbbTrangThai.DataSource = PlanItem.ListStatus;

            this.Job = job;
            HienThiThongTin();
        }

        void HienThiThongTin() 
        {
            txtCongViec.Text = Job.Job;

            nmDen_Gio.Value = Job.FromTime.X;
            nmDen_Phut.Value = Job.FromTime.Y;
            nmTu_Gio.Value = Job.ToTime.X;
            nmTu_Phut.Value = Job.ToTime.Y;

            cbbTrangThai.SelectedIndex = PlanItem.ListStatus.IndexOf(Job.Status);

            ckDone.Checked = PlanItem.ListStatus.IndexOf(Job.Status) == (int)EPlanItem.DONE ? true : false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Job.Job = txtCongViec.Text;
            Job.FromTime = new Point((int)nmDen_Gio.Value, (int)nmDen_Phut.Value);
            Job.ToTime = new Point((int)nmTu_Gio.Value, (int)nmTu_Phut.Value);
            Job.Status = PlanItem.ListStatus[cbbTrangThai.SelectedIndex];

            if (sua != null)
                sua(this, new EventArgs());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (xoa != null)
                xoa(this, new EventArgs());
        }

        private void ckDone_CheckedChanged(object sender, EventArgs e)
        {
            cbbTrangThai.SelectedIndex = ckDone.Checked ? (int)EPlanItem.DONE : (int)EPlanItem.DOING;
        }
    }
}
