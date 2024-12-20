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

namespace CSharp_POS_System.src.apps.Admin_panel_uctrl
{
    public partial class UserAddition : UserControl
    {
        public UserAddition()
        {
            InitializeComponent();
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            int userid = Convert.ToInt32(textBox1.Text);
            int eid = Convert.ToInt32(textBox2.Text);
            string username = Convert.ToString(textBox3.Text);
            string password = Convert.ToString(textBox4.Text);

            adduserdata(userid, username, password, eid);
        }

        private void adduserdata(int uid, string username, string password, int eid)
        {
            string connectionstr = dbconnection.Instance.ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionstr))
            {
                string sqlcmd = "insert into UserTable values(@UID, @UName, @Pwd, @EID)";

                conn.Open();

                try
                {
                    using (SqlCommand cmd = new SqlCommand(sqlcmd, conn))
                    {
                        cmd.Parameters.AddWithValue("@UID", uid);
                        cmd.Parameters.AddWithValue("@UName", username);
                        cmd.Parameters.AddWithValue("@Pwd", password);
                        cmd.Parameters.AddWithValue("@EID", eid);

                        int rowsaffect = cmd.ExecuteNonQuery();
                        MessageBox.Show($"Data Inserted into {rowsaffect}  column successfully");
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show("Error", ex.Message);
                }

            }
        }
    }
}
