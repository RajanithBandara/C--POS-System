using Krypton.Toolkit;
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

namespace C__POS_System.src.apps
{
    public partial class supplier_details_table : UserControl
    {
        public supplier_details_table()
        {
            InitializeComponent();
            ConfigureKryptonDataGridView();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void ConfigureKryptonDataGridView()
        {
            kryptonDataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular);
            kryptonDataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);

            // Define Columns
            AddColumn("SupplierID", "Supplier ID", 200);
            AddColumn("SupplierName", "Supplier Name", 350);
            AddColumn("ContactNo", "Contact Number", 250);
            AddColumn("EmailAddress", "Email Address", 350);
            AddColumn("PostalAddress", "Postal Address", 350, DataGridViewAutoSizeColumnMode.Fill);
            AddColumn("ActivityStage", "Activity Stage", 200);
            AddColumn("SupplierType", "Supplier Type", 300);

            LoadSupplierData();
        }

        private void AddColumn(string name, string headerText, int width, DataGridViewAutoSizeColumnMode autoSizeMode = DataGridViewAutoSizeColumnMode.None)
        {
            var column = kryptonDataGridView1.Columns.Add(name, headerText);
            kryptonDataGridView1.Columns[column].Width = width;
            kryptonDataGridView1.Columns[column].AutoSizeMode = autoSizeMode;
        }

        private void LoadSupplierData()
        {
            string connectionstr = dbconnection.Instance.ConnectionString;
            string query = "SELECT SupplierID, SupplierName, ContactNo, EmailAddress, PostalAddress, ActivityStage, SupplierType FROM SupplierDetailsView";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            kryptonDataGridView1.Rows.Add(
                                reader["SupplierID"].ToString(),
                                reader["SupplierName"].ToString(),
                                reader["ContactNo"].ToString(),
                                reader["EmailAddress"].ToString(),
                                reader["PostalAddress"].ToString(),
                                reader["ActivityStage"].ToString(),
                                reader["SupplierType"].ToString()
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
