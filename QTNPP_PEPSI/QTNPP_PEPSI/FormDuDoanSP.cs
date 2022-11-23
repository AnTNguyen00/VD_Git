using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTNPP_PEPSI
{
    public partial class FormDuDoanSP : Form
    {
        public FormDuDoanSP()
        {
            InitializeComponent();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            FormTienHanhDuDoan formNew = new FormTienHanhDuDoan();
            formNew.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox_CaiDat_Click(object sender, EventArgs e)
        {
            FormCaiDatDD formNew = new FormCaiDatDD();
            formNew.Show();
        }
    }
}
