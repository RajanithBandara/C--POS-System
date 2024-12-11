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

            var col1 = kryptonDataGridView1.Columns.Add("Column1", "Supplier ID");
            kryptonDataGridView1.Columns[col1].Width = 200;

            var col2 = kryptonDataGridView1.Columns.Add("Column2", "Supplier Name");
            kryptonDataGridView1.Columns[col2].Width = 350;

            var col3 = kryptonDataGridView1.Columns.Add("Column3", "Contact Number");
            kryptonDataGridView1.Columns[col3].Width = 250;

            var col4 = kryptonDataGridView1.Columns.Add("Column4", "Email Address");
            kryptonDataGridView1.Columns[col4].Width = 350;

            var col5 = kryptonDataGridView1.Columns.Add("Column5", "Postal Address");
            kryptonDataGridView1.Columns[col5].Width = 350;
            kryptonDataGridView1.Columns[col5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            string connectionstr = dbconnection.Instance.ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstr))
                {
                    conn.Open();

                    string sqlcmd = "Select * from SupplierTable";

                    using (SqlCommand cmd = new SqlCommand(sqlcmd, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var supID = reader["SupplierID"].ToString();
                                var supName = reader["SupplierName"].ToString();
                                var supContact = reader["ContactNo"].ToString();
                                var supEmail = reader["EmailAddress"].ToString();
                                var supPost = reader["PostalAddress"].ToString();

                                kryptonDataGridView1.Rows.Add(supID, supName, supContact, supEmail, supPost);
                            }
                        }
                    }
                }
            } catch(Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }

        }



    }
}
