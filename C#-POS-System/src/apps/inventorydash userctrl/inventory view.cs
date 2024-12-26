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
    public partial class inventory_view : UserControl
    {
        public inventory_view()
        {
            InitializeComponent();
            datagridview1();
            datagridview2();
        }
        private void datagridview1()
        {
            kryptonDataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            kryptonDataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);

            int widthoff = panel1.Width;

            var col1 = kryptonDataGridView1.Columns.Add("ProductID", "Product ID");
            kryptonDataGridView1.Columns[col1].Width = widthoff / 7;

            var col2 = kryptonDataGridView1.Columns.Add("ProductName", "Product Name");
            kryptonDataGridView1.Columns[col2].Width = widthoff / 4;

            var col3 = kryptonDataGridView1.Columns.Add("BrandName", "Brand Name");
            kryptonDataGridView1.Columns[col3].Width = widthoff / 4;

            var col4 = kryptonDataGridView1.Columns.Add("UnitPrice", "Unit Price");
            kryptonDataGridView1.Columns[col4].Width = widthoff / 6;

            var col5 = kryptonDataGridView1.Columns.Add("TotalQuantity", "Total Quantity");
            kryptonDataGridView1.Columns[col5].Width = widthoff / 7;

        }
        private void datagridview2()
        {
            kryptonDataGridView2.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            kryptonDataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);

            int widthoff = panel1.Width;

            var col1 = kryptonDataGridView2.Columns.Add("BatchNo", "Batch No");
            kryptonDataGridView2.Columns[col1].Width = widthoff / 7;

            var col2 = kryptonDataGridView2.Columns.Add("ExpiryDate", "Expiry Date");
            kryptonDataGridView2.Columns[col2].Width = widthoff / 6;

            var col3 = kryptonDataGridView2.Columns.Add("SupplierID", "Supplier ID");
            kryptonDataGridView2.Columns[col3].Width = widthoff / 7;

            var col4 = kryptonDataGridView2.Columns.Add("SuppliedDate", "Supplied Date");
            kryptonDataGridView2.Columns[col4].Width = widthoff / 6;

            var col5 = kryptonDataGridView2.Columns.Add("Damaged", "Damage");
            kryptonDataGridView2.Columns[col5].Width = widthoff / 7;

            var col6 = kryptonDataGridView2.Columns.Add("DisOrPro", "Discount and Promotion");
            kryptonDataGridView2.Columns[col6].Width = widthoff / 5;
        }
        private void LoadCustomerData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbconnection.Instance.ConnectionString))
                {
                    conn.Open(); // Open the connection

                    string query1 = "SELECT ProductID, ProductName, BrandName FROM ProductTable";


                    using (SqlCommand cmd = new SqlCommand(query1, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd); // Adapter to fill the DataTable
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable); // Populate the DataTable with query results

                        kryptonDataGridView1.Rows.Clear(); // Clear existing rows in the DataGridView

                        // Add rows from the DataTable to the DataGridView
                        foreach (DataRow row in dataTable.Rows)
                        {
                            kryptonDataGridView1.Rows.Add(
                                row["ProductID"].ToString(),
                                row["ProductName"].ToString(),
                                row["BrandName"].ToString()

                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show($"Error loading customer data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
