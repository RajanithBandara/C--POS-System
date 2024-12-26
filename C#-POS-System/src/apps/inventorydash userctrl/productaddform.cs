using Krypton.Toolkit;
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
using WindowsAppProject.Apps;

namespace CSharp_POS_System.src.apps.inventorydash_userctrl
{
    public partial class productadd : UserControl
    {
        public productadd()
        {
            InitializeComponent();
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox4.Text = string.Empty;
            comboBox1.SelectedIndex = -1;
        }

        private void addinventorydata()
        {
            int PID = Convert.ToInt32(textBox1.Text);
            string PName = Convert.ToString(textBox2.Text);
            string BName = Convert.ToString(textBox4.Text);
            string PCat = comboBox1.Text;

            string connectionstr = dbconnection.Instance.ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionstr))
            {
                string sqlcmd = "insert into ProductTable values(@PID, @PName, @BName, @PCat)";
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(sqlcmd, conn))
                        {
                            cmd.Parameters.AddWithValue("@PID", PID);
                            cmd.Parameters.AddWithValue("@PName", PName);
                            cmd.Parameters.AddWithValue("@BName", BName);
                            cmd.Parameters.AddWithValue("@PCat", PCat);

                            cmd.ExecuteNonQuery();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error", ex.Message);
                    }

                }
            }

        }
    }
}
