using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
            int PID = Convert.ToInt32(textBox1.Text);
            int BNo = Convert.ToInt32(textBox5.Text);
            int Qty = Convert.ToInt32(textBox6.Text);
            double Price = Convert.ToDouble(textBox7.Text);
            DateTime ExDate = kryptonDateTimePicker1.Value;
            int SupID = Convert.ToInt32(textBox9.Text);
            DateTime SupDate = kryptonDateTimePicker2.Value;
            int Damage = Convert.ToInt32(textBox11.Text);


            string connectionstr = dbconnection.Instance.ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionstr))
            {
                string sqlcmd1 = "insert into SupplyDetails(SupplierID, SuppliedDate) values(@SupID, @SupDate)";
                string sqlcmd2 = "insert into StockUpdateTable(ProductID, BatchNo, ExpiryDate, UnitPrice, Quantity, DamagedCount) values(@PID, @BNo, @ExDate, @Price, @Qty, @Damage)";
                string sqlcmd3 = "insert into InventoryTable (@PID, @Qty)";

                conn.Open();

                try
                {
                    using (SqlCommand cmd1 = new SqlCommand(sqlcmd1, conn))
                    {
                        cmd1.Parameters.AddWithValue("@SupID", SupID);
                        cmd1.Parameters.AddWithValue("@SupDate", SupDate);

                        cmd1.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd2 = new SqlCommand(sqlcmd2, conn))
                    {
                        cmd2.Parameters.AddWithValue("@PID", PID);
                        cmd2.Parameters.AddWithValue("@BNo", BNo);
                        cmd2.Parameters.AddWithValue("@ExDate", ExDate);
                        cmd2.Parameters.AddWithValue("@Price", Price);
                        cmd2.Parameters.AddWithValue("@Qty", Qty);
                        cmd2.Parameters.AddWithValue("@Damage", Damage);

                        cmd2.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd3 = new SqlCommand(sqlcmd3, conn))
                    {
                        cmd3.Parameters.AddWithValue("@PID", PID);
                        cmd3.Parameters.AddWithValue("@Qty", Qty);

                        cmd3.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error", ex.Message);
                }

            }
            
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;   
            textBox3.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox9.Text = string.Empty;  
            textBox11.Text = string.Empty;
            comboBox1.SelectedIndex = -1;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
