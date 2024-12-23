using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsAppProject.Apps;

namespace CSharp_POS_System.src.apps.inventorydash_userctrl
{
    public partial class inventoryadd : UserControl
    {
        public inventoryadd()
        {
            InitializeComponent();
            categoryload();
        }

        private void inventoryadd_Load(object sender, EventArgs e)
        {

        }

        private void categoryload()
        {
            string connectionstr = dbconnection.Instance.ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstr))
                {
                    string sqlcmd = "Select CategoryType from CategoryTable";

                    conn.Open();

                    using (SqlCommand command = new SqlCommand(sqlcmd, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            comboBox1.Items.Clear();

                            while (reader.Read())
                            {
                                comboBox1.Items.Add(reader["CategoryType"].ToString());
                            }
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void addinventorydata()
        {
            string connectionstr = dbconnection.Instance.ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionstr))
            {
                
            }
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;   
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox9.Text = string.Empty;
            textBox10.Text = string.Empty;  
            textBox11.Text = string.Empty;
            comboBox1.SelectedIndex = -1;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
