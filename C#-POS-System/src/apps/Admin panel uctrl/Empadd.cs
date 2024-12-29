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
    public partial class Empadd : UserControl
    {
        public Empadd()
        {
            InitializeComponent();
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            int EID = int.Parse(textBox1.Text);
            string empname = textBox2.Text;
            string position = textBox3.Text;
            addempdata(EID, empname, position);
        }

        private void addempdata(int empid, string empname, string position)
        {
            string connectionstr = dbconnection.Instance.ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionstr))
            {
                conn.Open();
                string procedureName = "AddEmployeeData";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EID", empid);
                        cmd.Parameters.AddWithValue("@EName", empname);
                        cmd.Parameters.AddWithValue("@Eposition", position);

                        int rowsaffect = cmd.ExecuteNonQuery();
                        MessageBox.Show($"{rowsaffect} rows affected successfully.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
