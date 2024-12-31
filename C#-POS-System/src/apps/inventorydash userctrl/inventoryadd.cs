using Krypton.Toolkit;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsAppProject.Apps;

namespace CSharp_POS_System.src.apps.inventorydash_userctrl
{
    public partial class inventoryadd : UserControl
    {
        private InventoryRepository _repository;

        public inventoryadd()
        {
            InitializeComponent();
            _repository = new InventoryRepository();
            textBox1.TextChanged += textBox1_TextChanged; // Attach event for ProductID
        }

        private void inventoryadd_Load(object sender, EventArgs e)
        {
            // Additional initialization logic can go here if needed.
        }

        private void AddInventoryData()
        {
            try
            {
                // Validate inputs
                if (!int.TryParse(textBox1.Text, out int productId) || productId <= 0)
                    throw new Exception("Invalid Product ID.");

                if (!int.TryParse(textBox5.Text, out int batchNo) || batchNo <= 0)
                    throw new Exception("Invalid Batch Number.");

                if (!int.TryParse(textBox6.Text, out int quantity) || quantity <= 0)
                    throw new Exception("Invalid Quantity.");

                if (!double.TryParse(textBox7.Text, out double unitPrice) || unitPrice <= 0)
                    throw new Exception("Invalid Unit Price.");

                if (!int.TryParse(textBox9.Text, out int supplierId) || supplierId <= 0)
                    throw new Exception("Invalid Supplier ID.");

                if (!int.TryParse(textBox11.Text, out int damagedCount) || damagedCount < 0)
                    throw new Exception("Invalid Damaged Count.");

                DateTime expiryDate = kryptonDateTimePicker1.Value;
                DateTime suppliedDate = kryptonDateTimePicker2.Value;

                // Call repository methods to add the data
                _repository.AddSupplyDetails(supplierId, suppliedDate);
                _repository.AddStockUpdate(productId, batchNo, expiryDate, unitPrice, quantity, damagedCount);
                _repository.AddInventory(productId, quantity);

                MessageBox.Show("Inventory data added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding inventory data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Triggered when ProductID text box changes (automatically search and populate data)
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int productId))
            {
                try
                {
                    // Fetch product details when ProductID is valid
                    DataRow productInfo = _repository.GetProductDetails(productId);
                    PopulateProductFields(productInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching product details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ClearProductFields(); // Clear the fields if ProductID is invalid
            }
        }

        // Method to get product details by ProductID
        public DataRow GetProductDetails(int productId)
        {
            string query = "SELECT ProductName, BrandName, [Category Type] FROM ProductTable WHERE ProductID = @ProductID";
            DataTable dt = _repository.ExecuteQuery(query, new SqlParameter("@ProductID", productId));
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        // This is the search button click handler, if needed for manual search.
        private void rjButton3_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate the Product ID input
                if (!int.TryParse(textBox1.Text, out int productId) || productId <= 0)
                {
                    MessageBox.Show("Please enter a valid Product ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Exit early if the input is invalid
                }

                // Fetch product details
                DataRow productInfo = _repository.GetProductDetails(productId);

                // Populate the product fields with the fetched data
                PopulateProductFields(productInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching product details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Populate fields with product information
        private void PopulateProductFields(DataRow productInfo)
        {
            if (productInfo != null)
            {
                // Populate fields with the fetched data
                productname.Text = productInfo["ProductName"].ToString();
                brandname.Text = productInfo["BrandName"].ToString();
                productcategory.Text = productInfo["Category Type"].ToString();
            }
            else
            {
                // Handle case where no product was found
                MessageBox.Show("Product not found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearProductFields();
            }
        }


        // Clear fields if no product found or reset
        private void ClearProductFields()
        {
            productname.Text = string.Empty;
            brandname.Text = string.Empty;
            productcategory.Text = string.Empty;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            AddInventoryData();
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(textBox1.Text, out int productId))
                    throw new Exception("Invalid Product ID.");

                _repository.DeleteInventoryData(productId);
                MessageBox.Show("Inventory data deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting inventory data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class InventoryRepository
    {
        private readonly string _connectionString;

        public InventoryRepository()
        {
            _connectionString = dbconnection.Instance.ConnectionString;
        }

        // Method to add supply details
        public void AddSupplyDetails(int supplierId, DateTime suppliedDate)
        {
            string query = "INSERT INTO SupplyDetails (SupplierID, SuppliedDate) VALUES (@SupplierID, @SuppliedDate)";
            ExecuteNonQuery(query, new SqlParameter("@SupplierID", supplierId), new SqlParameter("@SuppliedDate", suppliedDate));
        }

        // Method to add stock update
        public void AddStockUpdate(int productId, int batchNo, DateTime expiryDate, double unitPrice, int quantity, int damagedCount)
        {
            string query = "INSERT INTO StockUpdateTable (ProductID, BatchNo, ExpiryDate, UnitPrice, Quantity, DamagedCount) VALUES (@ProductID, @BatchNo, @ExpiryDate, @UnitPrice, @Quantity, @DamagedCount)";
            ExecuteNonQuery(query,
                new SqlParameter("@ProductID", productId),
                new SqlParameter("@BatchNo", batchNo),
                new SqlParameter("@ExpiryDate", expiryDate),
                new SqlParameter("@UnitPrice", unitPrice),
                new SqlParameter("@Quantity", quantity),
                new SqlParameter("@DamagedCount", damagedCount));
        }

        // Method to add inventory
        public void AddInventory(int productId, int quantity)
        {
            string query = "INSERT INTO InventoryTable (ProductID, Quantity) VALUES (@ProductID, @Quantity)";
            ExecuteNonQuery(query, new SqlParameter("@ProductID", productId), new SqlParameter("@Quantity", quantity));
        }

        // Method to delete inventory data
        public void DeleteInventoryData(int productId)
        {
            string query = "DELETE FROM InventoryTable WHERE ProductID = @ProductID";
            ExecuteNonQuery(query, new SqlParameter("@ProductID", productId));
        }

        public DataRow GetProductDetails(int productId)
        {
            // Query to join ProductTable and CategoryTable to get the product details and category name
            string query = @"
        SELECT p.ProductName, p.BrandName, c.CategoryName AS 'Category Type'
        FROM ProductTable p
        JOIN CategoryTable c ON p.CategoryID = c.CategoryID
        WHERE p.ProductID = @ProductID";

            DataTable dt = ExecuteQuery(query, new SqlParameter("@ProductID", productId));
            return dt.Rows.Count > 0 ? dt.Rows[0] : null; // Return the first row if exists, otherwise null
        }




        // Method to execute a query and return a DataTable
        public DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // Method to execute a non-query command
        private void ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
