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
using ClosedXML.Excel;


namespace CSharp_POS_System.src.apps
{
    public partial class billaddition : UserControl
    {
        public billaddition()
        {
            InitializeComponent();
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            int ProID = int.Parse(textBox1.Text);
            string BatchNo = comboBox1.Text;

            searching(ProID, BatchNo);
        }

        private void searching(int proid, string batchno)
        {
            using (SqlConnection conn = new SqlConnection(dbconnection.Instance.ConnectionString))
            {
                string sqlcmd_1 = @"
                                    SELECT 
                                        ProductTable.ProductName, 
                                        StockUpdateTable.UnitPrice, 
                                        StockUpdateTable.ExpiryDate, 
                                        CategoryTable.CategoryType,
                                        DiscountPromoTable.DiscountAmt,
                                        DiscountPromoTable.PromotionDescription
                                    FROM ProductTable
                                    INNER JOIN StockUpdateTable
                                        ON ProductTable.ProductID = StockUpdateTable.ProductID
                                    INNER JOIN CategoryTable
                                        ON ProductTable.CategoryID = CategoryTable.CategoryID
                                    Inner Join DiscountPromoTable
                                    ON ProductTable.ProductID = DiscountPromoTable.ProductID
                                    WHERE ProductTable.ProductID = @ProID 
                                      AND StockUpdateTable.BatchNo = @BatchNo;";

                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlcmd_1, conn))
                {
                    cmd.Parameters.AddWithValue("@ProID", proid);
                    cmd.Parameters.AddWithValue("@BatchNo", batchno);

                    using (SqlDataReader readerdata = cmd.ExecuteReader())
                    {
                        if (readerdata.HasRows)
                        {
                            while (readerdata.Read())
                            {
                                string productName = readerdata["ProductName"].ToString();
                                double unitPrice = Convert.ToDouble(readerdata["UnitPrice"]);
                                DateTime expiryDate = Convert.ToDateTime(readerdata["ExpiryDate"]);
                                string categoryType = readerdata["CategoryType"].ToString();
                                double discountamount = Convert.ToDouble(readerdata["DiscountAmt"]);
                                string promotiondesc = readerdata["PromotionDescription"].ToString();

                                textBox2.Text = productName;
                                textBox7.Text = categoryType;
                                textBox3.Text = unitPrice.ToString("F2");
                                textBox4.Text = expiryDate.ToString("yyyy-MM-dd");
                                
                                if (discountamount > 0)
                                {
                                    double discountcal = unitPrice / 100 * discountamount;
                                    textBox8.Text = discountcal.ToString();
                                }
                                else
                                {
                                    discountamount = 0;
                                    textBox8.Text = "0";
                                }


                                label10.Text = promotiondesc;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No data found for the specified criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            int ProductID = int.Parse(textBox1.Text);
            string BatchNumber = comboBox1.Text;
            string ProductName = textBox2.Text;
            string CategoryType = textBox7.Text;
            double UnitPrice = Convert.ToDouble(textBox3.Text);
            double DiscountPrice = int.Parse(textBox8.Text);
            int Quantity = int.Parse(textBox5.Text);
            double TotalPrice = (UnitPrice - DiscountPrice) * Quantity;
            DateTime ExpiryDate = Convert.ToDateTime(textBox4.Text);

            try
            {
                passdata(ProductID, BatchNumber, ProductName, UnitPrice, DiscountPrice, Quantity, TotalPrice, ExpiryDate);

            } catch (Exception ex)
            {
                MessageBox.Show($"Error occured {ex}");
            }

        }
        private void passdata(int proid, string batchno, string proname, double unitprice, double discountedprice, int quantity, double totalprice, DateTime expirydate)
        {
            string connectionstr = dbconnection.Instance.ConnectionString;

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionstr))
                {
                    conn.Open();

                    string sqlcmd = "Insert into tempdata values(@ProID,@BatchNumber, @ProName, @UnitPrice, @Discount, @Quantity, @TotalPrice, @ExpiryDate)";

                    try
                    {
                        using(SqlCommand cmd = new SqlCommand(sqlcmd, conn))
                        {
                            cmd.Parameters.AddWithValue("@ProID", proid);
                            cmd.Parameters.AddWithValue("@BatchNumber", batchno);
                            cmd.Parameters.AddWithValue("@ProName", proname);
                            cmd.Parameters.AddWithValue("@UnitPrice", unitprice);
                            cmd.Parameters.AddWithValue("@Discount", discountedprice);
                            cmd.Parameters.AddWithValue("@Quantity", quantity);
                            cmd.Parameters.AddWithValue("@TotalPrice", totalprice);
                            cmd.Parameters.AddWithValue("@ExpiryDate", expirydate);

                            int rowsaffected = cmd.ExecuteNonQuery();

                            if (rowsaffected > 0)
                            {
                                label11.Text = $"Successfully inserted {proid}";
                                label11.ForeColor = Color.Green;
                            }
                            else
                            {
                                label11.Text = $"Operation failed to add {proid}";
                                label11.ForeColor = Color.Red;
                            }
                            
                            
                        }
                    } catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataexport()
        {

            string sqlcmd = "Select * from tempdata";
            DataTable datatable = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(dbconnection.Instance.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlcmd, conn))
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(datatable);
                    }
                }
            

            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Save Excel File"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = saveFileDialog.FileName;

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("ExportedData");
                    worksheet.Cell(1, 1).InsertTable(datatable);
                    workbook.SaveAs(filepath);  
                }

                MessageBox.Show("Data Exported Succesfully. ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            int ProductNumber = int.Parse(textBox1.Text);
            searchbatchnumbers(ProductNumber);

            textBox2.Text = "";
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            comboBox1.SelectedIndex = 0;
            textBox7.Text = string.Empty;   
            textBox8.Text = string.Empty;
            
        }

        private void searchbatchnumbers(int ProductID)
        {
            using(SqlConnection conn = new SqlConnection(dbconnection.Instance.ConnectionString))
            {
                conn.Open();
                string sqlcmd = "Select BatchNo from StockUpdateTable where ProductID = @ProductId";

                using (SqlCommand cmd = new SqlCommand(sqlcmd, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductId", ProductID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    { 
                        comboBox1.Items.Clear();
                        
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["BatchNo"].ToString());
                        }
                    }
                }
                conn.Close();
            }
        }
    }
}
