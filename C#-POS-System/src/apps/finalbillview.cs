using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CSharp_POS_System.src.apps
{
    public partial class finalbillview : UserControl
    {
        private string connectionString = "Server=localhost,1433;Database=posdb;User Id=sa;Password=password123#";

        public finalbillview()
        {
            InitializeComponent();
            datagridview();
            LoadDataFromDatabase();
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell click events if necessary
        }

        private void datagridview()
        {
            kryptonDataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            kryptonDataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);

            int widthoff = panel1.Width;

            var col1 = kryptonDataGridView1.Columns.Add("ProductID", "Product ID");
            kryptonDataGridView1.Columns[col1].Width = widthoff / 10;

            var col2 = kryptonDataGridView1.Columns.Add("ProductName", "Product Name");
            kryptonDataGridView1.Columns[col2].Width = widthoff / 4;

            var col3 = kryptonDataGridView1.Columns.Add("UnitPrice", "Unit Price");
            kryptonDataGridView1.Columns[col3].Width = widthoff / 11;

            var col4 = kryptonDataGridView1.Columns.Add("Quantity", "Quantity");
            kryptonDataGridView1.Columns[col4].Width = widthoff / 10;

            var col5 = kryptonDataGridView1.Columns.Add("TotalPrice", "Total Price");
            kryptonDataGridView1.Columns[col5].Width = widthoff / 10;

            var col6 = kryptonDataGridView1.Columns.Add("DiscountDetail", "Discount Detail");
            kryptonDataGridView1.Columns[col6].Width = widthoff / 9;

            var col7 = kryptonDataGridView1.Columns.Add("TotalDiscount", "Total Discount");
            kryptonDataGridView1.Columns[col7].Width = widthoff / 8;

            var col8 = kryptonDataGridView1.Columns.Add("NetPrice", "Net Price");
            kryptonDataGridView1.Columns[col8].Width = widthoff / 12;
        }

        private void LoadDataFromDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT ProductID, ProductName, UnitPrice, Quantity, " +
                                   "DiscountDetail, TotalDiscount, NetPrice FROM ProductTable";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        double unitPrice = Convert.ToDouble(row["UnitPrice"]);
                        int quantity = Convert.ToInt32(row["Quantity"]);
                        double totalPrice = unitPrice * quantity;
                        double totalDiscount = Convert.ToDouble(row["TotalDiscount"]);
                        double netPrice = totalPrice - totalDiscount;

                        kryptonDataGridView1.Rows.Add(
                            row["ProductID"], row["ProductName"], unitPrice,
                            quantity, totalPrice, row["DiscountDetail"],
                            totalDiscount, netPrice);
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

        private void SaveDataToDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (DataGridViewRow row in kryptonDataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string query = "INSERT INTO ProductTable (ProductID, ProductName, UnitPrice, Quantity, TotalPrice, DiscountDetail, TotalDiscount, NetPrice) " +
                                       "VALUES (@ProductID, @ProductName, @UnitPrice, @Quantity, @TotalPrice, @DiscountDetail, @TotalDiscount, @NetPrice)";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@ProductID", row.Cells["ProductID"].Value ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ProductName", row.Cells["ProductName"].Value ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UnitPrice", row.Cells["UnitPrice"].Value ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Quantity", row.Cells["Quantity"].Value ?? DBNull.Value);

                        double unitPrice = Convert.ToDouble(row.Cells["UnitPrice"].Value);
                        int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                        double totalPrice = unitPrice * quantity;
                        double totalDiscount = Convert.ToDouble(row.Cells["TotalDiscount"].Value);
                        double netPrice = totalPrice - totalDiscount;

                        command.Parameters.AddWithValue("@TotalPrice", totalPrice);
                        command.Parameters.AddWithValue("@DiscountDetail", row.Cells["DiscountDetail"].Value ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TotalDiscount", totalDiscount);
                        command.Parameters.AddWithValue("@NetPrice", netPrice);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SQL Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
