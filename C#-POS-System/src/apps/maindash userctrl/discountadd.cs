using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsAppProject.Apps;
using System.Data.SqlClient;

namespace CSharp_POS_System.src.apps
{
    public partial class discountadd : UserControl
    {
        public discountadd()
        {
            InitializeComponent();
        }

        private void discountadd_Load(object sender, EventArgs e)
        {

        }

        private void rjPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            string PromotionID = textBox1.Text;
            string Description = textBox2.Text;
            DateTime ValidatePeriod = dateTimePicker1.Value;
            string ValidateProductID = textBox3.Text;
            string PromotionType = textBox4.Text;

            string connectionstr = dbconnection.Instance.ConnectionString;
            string sqlcmd = $"INSERT INTO DiscountPromoTable (PromotionID,ProductID,PromotionValidatePeriod,PromotionDescription,PromotionType) VALUES (@Value1,@Value2,@Value3,@Value4,@Value5)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstr))
                {
                    SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                    cmd.Parameters.AddWithValue("@Value1", PromotionID);
                    cmd.Parameters.AddWithValue("@Value2", ValidateProductID);
                    cmd.Parameters.AddWithValue("@Value3", ValidatePeriod);
                    cmd.Parameters.AddWithValue("@Value4", Description);
                    cmd.Parameters.AddWithValue("@Value5", PromotionType);


                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    MessageBox.Show($"{rowsAffected} row(s) inserted successfully.");
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
