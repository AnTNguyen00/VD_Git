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
    public partial class FormRestore : Form
    {
        SqlConnection con = new SqlConnection("Data Source = DESKTOP-COHHIDH; Initial Catalog = QL_QTNPP_PEPSI; User ID = sa; Password = sa2012");

        public FormRestore()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL server database backup files|*.bak";
            dlg.Title = "Database restore";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtLocation.Text = dlg.FileName;
                btnBrowse.Enabled = true;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            string database = con.Database.ToString();
            con.Open();

            try
            {
                string str1 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand cmd1 = new SqlCommand(str1, con);
                cmd1.ExecuteNonQuery();

                string str2 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK = '" + txtLocation.Text + "' WITH REPLACE;";
                SqlCommand cmd2 = new SqlCommand(str2, con);
                cmd2.ExecuteNonQuery();

                string str3 = string.Format("ALTER DATABASE [" + database + "] SET MULTI_USER");
                SqlCommand cmd3 = new SqlCommand(str3, con);
                cmd3.ExecuteNonQuery();

                MessageBox.Show("Khôi phục dữ liệu thành công");
                con.Close();
            }
            catch { }
        }
    }
}
