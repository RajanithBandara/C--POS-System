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

namespace C__POS_System.src.apps
{
    public partial class Supplier_details_addition_form : UserControl
    {
        public Supplier_details_addition_form()
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
            int SupplierID = int.Parse(textBox1.Text);
            string SupplierName = textBox2.Text;
            string ContactNo = textBox3.Text;
            string EmailAddress = textBox4.Text;
            string PostalAddress = textBox5.Text;

            try
            {
                sendata(SupplierID, SupplierName, ContactNo, EmailAddress, PostalAddress);
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        
        }

        private void sendata(int id, string name, string contact, string email, string address)
        {
            string connectionstr = "Server=localhost,1433;Database=posdb;User Id=sa;Password=password123#";
            string sqlcmd = "SupplierDetails";

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionstr))
                {
                    SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@SID", id);
                    cmd.Parameters.AddWithValue("@SName", name);
                    cmd.Parameters.AddWithValue("@Scon", contact);
                    cmd.Parameters.AddWithValue("@SEAddress", email);
                    cmd.Parameters.AddWithValue("@SPAddress", address);
                    cmd.Parameters.AddWithValue("@SAs", address);
                    cmd.Parameters.AddWithValue("@Stype", address);

                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    MessageBox.Show($"{rowsAffected} row(s) inserted successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
