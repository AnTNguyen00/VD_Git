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
    public partial class FormSaoLuu : Form
    {
        public FormSaoLuu()
        {
            InitializeComponent();
            CenterToParent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void btnBackupFull_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    fbd.Description = "Chọn Thư mực chứa file";
            //    if (fbd.ShowDialog() == DialogResult.OK)
            //    {
            //        string address = fbd.SelectedPath;
            //        if (BackupDALLBLL.Instance.FullBackup(address))
            //            MessageBox.Show("Backup Full thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        else
            //        {
            //            MessageBox.Show("Backup Full không thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi:" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void btnBackupDiff_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    fbd.Description = "Chọn Thư mực chứa file";
            //    if (fbd.ShowDialog() == DialogResult.OK)
            //    {
            //        string address = fbd.SelectedPath;
            //        if (BackupDALLBLL.Instance.DiffBackup(address))
            //            MessageBox.Show("Backup Diff thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        else
            //        {
            //            MessageBox.Show("Backup Diff không thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi:" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnBackupLog_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    fbd.Description = "Chọn Thư mực chứa file";
            //    if (fbd.ShowDialog() == DialogResult.OK)
            //    {
            //        string address = fbd.SelectedPath;
            //        if (BackupDALLBLL.Instance.LogBackup(address))
            //            MessageBox.Show("Backup Log thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        else
            //        {
            //            MessageBox.Show("Backup Log không thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi:" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
