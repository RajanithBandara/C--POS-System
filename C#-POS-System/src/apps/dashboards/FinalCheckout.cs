using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsAppProject.Apps;

namespace CSharp_POS_System.src.apps.dashboards
{
    public partial class FinalCheckout : Form
    {
        private double billsum;

        public FinalCheckout()
        {
            InitializeComponent();
            GetPaymentMethodList();
            PriceDisplay();
            SetupCustomerDropdown();
        }

        private void SetupCustomerDropdown()
        {
            comboBox2.Items.Add("Yes");
            comboBox2.Items.Add("No");
        }

        private void EnableCustomerIdInput()
        {
            textBox1.ReadOnly = comboBox2.SelectedIndex != 0;
        }

        public void GetPaymentMethodList()
        {
            using (SqlConnection conn = new SqlConnection(dbconnection.Instance.ConnectionString))
            {
                conn.Open();

                string sqlcmd = "SELECT PaymentMethodType FROM PaymentMethodTable";
                using (SqlCommand cmd = new SqlCommand(sqlcmd, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string paymentMethodType = reader.GetString(0);
                            comboBox1.Items.Add(paymentMethodType);
                        }

                        if (comboBox1.Items.Count > 0)
                        {
                            comboBox1.SelectedIndex = 0;
                        }
                    }
                }

                conn.Close();
            }
        }

        private void PriceDisplay()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbconnection.Instance.ConnectionString))
                {
                    conn.Open();

                    string sqlcmd = "SELECT dbo.take_sum_finalbill()";
                    SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                    object result = cmd.ExecuteScalar();

                    billsum = Convert.ToDouble(result);
                    label4.Text = $"Bill Amount: {billsum}";

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Yes")
            {
                ProcessTransaction(int.Parse(textBox1.Text));
            }
            else if (comboBox2.Text == "No")
            {
                ProcessTransaction(null);
            }
            else
            {
                MessageBox.Show("Please select a valid option.");
            }

            ReduceInventory();
        }

        private void ReduceInventory()
        {
            using (SqlConnection conn = new SqlConnection(dbconnection.Instance.ConnectionString))
            {
                conn.Open();

                string sqlProcedure = "ReduceInventoryFromTempTable";
                using (SqlCommand cmd = new SqlCommand(sqlProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Inventory updated successfully!");
                }

                conn.Close();
            }
        }

        private void ProcessTransaction(int? customerId)
        {
            string paymentMethod = comboBox1.Text;
            DateTime nowDateTime = DateTime.Now;
            int promotionId = 456; // Placeholder for PromotionID

            try
            {
                using (SqlConnection conn = new SqlConnection(dbconnection.Instance.ConnectionString))
                {
                    conn.Open();

                    int paymentMethodId = GetPaymentMethodId(paymentMethod, conn);
                    if (paymentMethodId == 0)
                    {
                        MessageBox.Show("Invalid payment method selected.");
                        return;
                    }

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Insert into TransactionTable
                            string transactionInsertQuery = @"INSERT INTO TransactionTable (TotalPrice, PaymentMethodID, DateTime)
                                                              VALUES (@Total, @PaymentMethodID, @DateTimeNow);
                                                              SELECT SCOPE_IDENTITY();";

                            int transactionId;
                            using (SqlCommand cmd = new SqlCommand(transactionInsertQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Total", billsum);
                                cmd.Parameters.AddWithValue("@PaymentMethodID", paymentMethodId);
                                cmd.Parameters.AddWithValue("@DateTimeNow", nowDateTime);

                                object result = cmd.ExecuteScalar();
                                transactionId = Convert.ToInt32(result);
                            }

                            // Insert into SalesTable
                            string salesInsertQuery = @"INSERT INTO SalesTable (TransactionDate, CustomerID, TransactionID)
                                                        VALUES (@TransactionDate, @CustomerID, @TransactionID)";

                            using (SqlCommand cmd = new SqlCommand(salesInsertQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@TransactionDate", nowDateTime);
                                cmd.Parameters.AddWithValue("@CustomerID", (object)customerId ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@TransactionID", transactionId);

                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            double remainder = billsum - Convert.ToDouble(textBox2.Text);   
                            MessageBox.Show($"Transaction completed successfully! {remainder}");
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing transaction: " + ex.Message);
            }
        }

        private int GetPaymentMethodId(string paymentMethod, SqlConnection conn)
        {
            try
            {
                string query = "SELECT PaymentMethodID FROM PaymentMethodTable WHERE PaymentMethodType = @PaymentMethod";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);

                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving PaymentMethodID: " + ex.Message);
                return 0;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableCustomerIdInput();
        }
    }
}
