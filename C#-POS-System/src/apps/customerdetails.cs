using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CSharp_POS_System.src.apps
{
    public partial class customerdetails : UserControl
    {
        private string connectionString = "Server=localhost,1433;Database=posdb;User Id=sa;Password=password123#"; 

        public customerdetails()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadCustomerData();
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click events if necessary
        }

        // Method to initialize the DataGridView with columns and styles
        private void InitializeDataGridView()
        {
            // Set default styles for the DataGridView
            kryptonDataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Regular);
            kryptonDataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);

            int widthoff = rjPanel1.Width; // Adjust column widths dynamically based on the panel width

            // Add columns with proper widths
            kryptonDataGridView1.Columns.Add("Column1", "Customer ID");
            kryptonDataGridView1.Columns["Column1"].Width = widthoff / 9;

            kryptonDataGridView1.Columns.Add("Column2", "Customer Name");
            kryptonDataGridView1.Columns["Column2"].Width = widthoff / 5;

            kryptonDataGridView1.Columns.Add("Column3", "Email Address");
            kryptonDataGridView1.Columns["Column3"].Width = widthoff / 5;

            kryptonDataGridView1.Columns.Add("Column4", "Contact");
            kryptonDataGridView1.Columns["Column4"].Width = widthoff / 7;

            kryptonDataGridView1.Columns.Add("Column5", "Postal Address");
            kryptonDataGridView1.Columns["Column5"].Width = widthoff / 3;

            kryptonDataGridView1.RowTemplate.Height = 35;
        }

        // Method to load customer data from the database into the DataGridView
        private void LoadCustomerData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Open the connection

                    string query = "SELECT * from CustomerDetailsView";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd); // Adapter to fill the DataTable
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable); // Populate the DataTable with query results

                        kryptonDataGridView1.Rows.Clear(); // Clear existing rows in the DataGridView

                        // Add rows from the DataTable to the DataGridView
                        foreach (DataRow row in dataTable.Rows)
                        {
                            kryptonDataGridView1.Rows.Add(
                                row["CustomerID"].ToString(),
                                row["CustomerName"].ToString(),
                                row["EmailAddress"].ToString(),
                                row["ContactNo"].ToString(),
                                row["PostalAddress"].ToString()
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
