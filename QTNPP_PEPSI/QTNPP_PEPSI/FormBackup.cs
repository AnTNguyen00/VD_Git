using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QTNPP_PEPSI
{
    public partial class FormBackup : Form
    {
        SqlConnection con = new SqlConnection("Data Source = DESKTOP-COHHIDH; Initial Catalog = QL_QTNPP_PEPSI; User ID = sa; Password = sa2012");

        public FormBackup()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtLocation.Text = dlg.SelectedPath;
                btnBackup.Enabled = true;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string database = con.Database.ToString();
            if (txtLocation.Text == string.Empty)
                MessageBox.Show("Please enter backup file location!");
            else
            {
                string str = "BACKUP DATABASE [" + database + "] TO DISK = '" + txtLocation.Text + "\\" + "QL_QTNPP_PEPSI" + "-" + DateTime.Now.ToString("dd-MM-yyyy--HH-mm-ss") + ".bak'";

                con.Open();
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sao lưu dữ liệu thành công");
                con.Close();
                btnBackup.Enabled = false;
            }
        }
    }
}
