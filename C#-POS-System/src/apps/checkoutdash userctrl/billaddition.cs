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

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int proid = int.Parse(textBox1.Text);
            int batchno = int.Parse(textBox6.Text);
            string proname = textBox2.Text;
            int unitprice = int.Parse(textBox3.Text);
            int discountprice = int.Parse(textBox8.Text);
            int quantity = int.Parse(textBox5.Text);

            passdata(proid, batchno, proname, unitprice, discountprice, quantity);
            dataexport();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }
        private void passdata(int proid, int batchno, string proname, int unitprice, int discountedprice, int quantity)
        {
            string connectionstr = dbconnection.Instance.ConnectionString;

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionstr))
                {
                    conn.Open();

                    string sqlcmd = "Insert into tempdata values(@ProID, @ProName, @UnitPrice, @Discount, @Quantity)";

                    try
                    {
                        using(SqlCommand cmd = new SqlCommand(sqlcmd, conn))
                        {
                            cmd.Parameters.AddWithValue("@ProID", proid);
                            cmd.Parameters.AddWithValue("@ProName", proname);
                            cmd.Parameters.AddWithValue("@UnitPrice", unitprice);
                            cmd.Parameters.AddWithValue("@Discount", discountedprice);
                            cmd.Parameters.AddWithValue("@Quantity", quantity);

                            cmd.ExecuteNonQuery();
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
    }
}
