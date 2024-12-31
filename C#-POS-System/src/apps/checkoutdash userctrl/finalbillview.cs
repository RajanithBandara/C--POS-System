using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using WindowsAppProject.Apps;

namespace CSharp_POS_System.src.apps
{
    public partial class finalbillview : UserControl
    {
        private string connectionString = "Server=localhost,1433;Database=posdb;User Id=sa;Password=password123#";

        public finalbillview()
        {
            InitializeComponent();
            finalpriceget();
            final_discountget();
            datagridview();
            LoadDataFromDatabase();
        }

        private void finalpriceget()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbconnection.Instance.ConnectionString))
                {
                    conn.Open();

                    string sqlcmd = "Select dbo.take_sum_finalbill()";
                    SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                    var resul = cmd.ExecuteScalar();

                    if (resul != null)
                    {
                        double totalsum = Convert.ToDouble(resul);
                        totalprice.Text = totalsum.ToString();
                    }
                    else
                    {
                        totalprice.Text = "0.00";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void final_discountget()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbconnection.Instance.ConnectionString))
                {
                    conn.Open();
                    string sqlcmd = "Select dbo.take_sum_discounts()";
                    SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        double totaldiscount = Convert.ToDouble(result);
                        totalDiscount.Text = totaldiscount.ToString();
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }   
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void datagridview()
        {
            kryptonDataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            kryptonDataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);

            int widthoff = panel1.Width;

            var col1 = kryptonDataGridView1.Columns.Add("ProductID", "Product ID");
            kryptonDataGridView1.Columns[col1].Width = widthoff / 10;

            var col2 = kryptonDataGridView1.Columns.Add("ProductName", "Batch Number");
            kryptonDataGridView1.Columns[col2].Width = widthoff / 8;

            var col3 = kryptonDataGridView1.Columns.Add("UnitPrice", "Product Name");
            kryptonDataGridView1.Columns[col3].Width = widthoff / 5;

            var col4 = kryptonDataGridView1.Columns.Add("Quantity", "Unit Price");
            kryptonDataGridView1.Columns[col4].Width = widthoff / 10;

            var col5 = kryptonDataGridView1.Columns.Add("TotalPrice", "Quantity");
            kryptonDataGridView1.Columns[col5].Width = widthoff / 10;

            var col6 = kryptonDataGridView1.Columns.Add("DiscountDetail", "Total Price");
            kryptonDataGridView1.Columns[col6].Width = widthoff / 10;

            var col7 = kryptonDataGridView1.Columns.Add("TotalDiscount", "Discount Added");
            kryptonDataGridView1.Columns[col7].Width = widthoff / 8;

            var col8 = kryptonDataGridView1.Columns.Add("NetPrice", "Net Price");
            kryptonDataGridView1.Columns[col8].Width = widthoff / 9;
        }

        private void LoadDataFromDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM FinalBillView";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    kryptonDataGridView1.Rows.Clear();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        double unitPrice = Convert.ToDouble(row["UnitPrice"]);
                        int quantity = Convert.ToInt32(row["Quantity"]);
                        double totalPrice = unitPrice * quantity;
                        double totalDiscount = Convert.ToDouble(row["DiscountedPrice"]);
                        double netPrice = totalPrice - totalDiscount;

                        kryptonDataGridView1.Rows.Add(
                            row["ProductID"],       
                            row["BatchNumber"],     
                            row["ProductName"],     
                            unitPrice,              
                            quantity,               
                            totalPrice,             
                            totalDiscount,          
                            netPrice                
                        );
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SQL Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        

        private void kryptonDataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Handle additional cell click events here
        }

        private void totalprice_TextChanged(object sender, EventArgs e)
        {
            if (kryptonDataGridView1.Rows.Count > 0)
            {
                double totalSum = 0;
                foreach (DataGridViewRow row in kryptonDataGridView1.Rows)
                {
                    if (row.Cells["TotalPrice"].Value != null)
                    {
                        totalSum += Convert.ToDouble(row.Cells["TotalPrice"].Value);
                    }
                }

                totalprice.Text = totalSum.ToString();
            }
        }

        private void totalDiscount_TextChanged(object sender, EventArgs e)
        {
            if (kryptonDataGridView1.Rows.Count > 0)
            {
                double totalSum = 0;
                foreach (DataGridViewRow row in kryptonDataGridView1.Rows)
                {
                    if (row.Cells["TotalDiscount"].Value != null)
                    {
                        totalSum += Convert.ToDouble(row.Cells["TotalDiscount"].Value);
                    }
                }

                totalDiscount.Text = totalSum.ToString();
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
