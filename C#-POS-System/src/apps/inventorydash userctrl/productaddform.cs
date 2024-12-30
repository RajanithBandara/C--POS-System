using Krypton.Toolkit;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsAppProject.Apps;

namespace CSharp_POS_System.src.apps.inventorydash_userctrl
{
    public partial class productadd : UserControl
    {
        private string connectionString = dbconnection.Instance.ConnectionString;

        public productadd()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void ClearFields()
        {
            ProductID.Text = string.Empty;
            ProductName.Text = string.Empty;
            BrandName.Text = string.Empty;
            ProductCategory.SelectedIndex = -1;
        }

        private void LoadCategories()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT CategoryID, CategoryType FROM CategoryTable";
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable categories = new DataTable();
                    adapter.Fill(categories);

                    ProductCategory.DataSource = categories;
                    ProductCategory.DisplayMember = "CategoryType";
                    ProductCategory.ValueMember = "CategoryID";
                    ProductCategory.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddProduct()
        {
            if (string.IsNullOrWhiteSpace(ProductID.Text) ||
                string.IsNullOrWhiteSpace(ProductName.Text) ||
                ProductCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(ProductID.Text, out int productId))
            {
                MessageBox.Show("Product ID must be a numeric value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string productName = ProductName.Text.Trim();
            string brandName = BrandName.Text.Trim();
            int categoryId = (int)ProductCategory.SelectedValue;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string queryProduct = @"
                    INSERT INTO ProductTable (ProductID, ProductName, BrandName, CategoryID)
                    VALUES (@ProductID, @ProductName, @BrandName, @CategoryID)";
                string queryInventory = @"
                    INSERT INTO InventoryTable (ProductID, FinalQuantity)
                    VALUES (@ProductID, @FinalQuantity)";

                try
                {
                    conn.Open();
                    using (SqlCommand cmdProduct = new SqlCommand(queryProduct, conn))
                    {
                        cmdProduct.Parameters.AddWithValue("@ProductID", productId);
                        cmdProduct.Parameters.AddWithValue("@ProductName", productName);
                        cmdProduct.Parameters.AddWithValue("@BrandName", brandName);
                        cmdProduct.Parameters.AddWithValue("@CategoryID", categoryId);

                        cmdProduct.ExecuteNonQuery();
                    }

                    using (SqlCommand cmdInventory = new SqlCommand(queryInventory, conn))
                    {
                        cmdInventory.Parameters.AddWithValue("@ProductID", productId);
                        cmdInventory.Parameters.AddWithValue("@FinalQuantity", 0); // Initial quantity is set to 0
                        cmdInventory.ExecuteNonQuery();
                    }

                    MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateProduct()
        {
            if (string.IsNullOrWhiteSpace(ProductID.Text))
            {
                MessageBox.Show("Product ID is required for update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(ProductID.Text, out int productId))
            {
                MessageBox.Show("Product ID must be a numeric value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string productName = ProductName.Text.Trim();
            string brandName = BrandName.Text.Trim();
            int categoryId = ProductCategory.SelectedIndex == -1 ? 0 : (int)ProductCategory.SelectedValue;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string queryProduct = @"
                    UPDATE ProductTable
                    SET ProductName = @ProductName,
                        BrandName = @BrandName,
                        CategoryID = @CategoryID
                    WHERE ProductID = @ProductID";

                string queryInventory = @"
                    UPDATE InventoryTable
                    SET FinalQuantity = FinalQuantity + @QuantityChange
                    WHERE ProductID = @ProductID";

                try
                {
                    conn.Open();
                    using (SqlCommand cmdProduct = new SqlCommand(queryProduct, conn))
                    {
                        cmdProduct.Parameters.AddWithValue("@ProductID", productId);
                        cmdProduct.Parameters.AddWithValue("@ProductName", productName);
                        cmdProduct.Parameters.AddWithValue("@BrandName", brandName);
                        cmdProduct.Parameters.AddWithValue("@CategoryID", categoryId);

                        cmdProduct.ExecuteNonQuery();
                    }

                    using (SqlCommand cmdInventory = new SqlCommand(queryInventory, conn))
                    {
                        cmdInventory.Parameters.AddWithValue("@ProductID", productId);
                        cmdInventory.Parameters.AddWithValue("@QuantityChange", 10); // Example change quantity
                        cmdInventory.ExecuteNonQuery();
                    }

                    MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            AddProduct();
        }

        private void Updatebutton_Click(object sender, EventArgs e)
        {
            UpdateProduct();
        }
    }
}
