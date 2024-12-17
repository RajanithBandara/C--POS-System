using CSharp_POS_System.src.apps.dashboards;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsAppProject.Apps;

namespace CSharp_POS_System.src.apps
{
    public partial class LoginForm12 : Form
    {
        public LoginForm12()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnterData();
        }

        private void EnterData()
        {
            string username = textBox1.Text.Trim();
            string enteredPassword = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(enteredPassword))
            {
                MessageBox.Show("Please enter both Username and Password.", "Input Error");
                return;
            }

            string connectionStr = dbconnection.Instance.ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string sql = @"
            SELECT U.Pwd, E.Position 
            FROM UserTable U 
            INNER JOIN EmployeeTable E ON U.EmployeeID = E.EmployeeID 
            WHERE U.UserName = @username";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedPassword = reader["Pwd"].ToString();
                                string position = reader["Position"].ToString();

                                if (storedPassword == enteredPassword)
                                {
                                    MessageBox.Show("Login successful!", "Success");
                                    this.Hide();

                                    switch (position)
                                    {
                                        case "Manager":
                                            new maindashboard().Show();
                                            break;
                                        case "Cashier":
                                            new Checkoutdashboard().Show();
                                            break;
                                        case "Store Keeper":
                                            new inventorydashboard().Show();
                                            break;
                                        default:
                                            MessageBox.Show("Unknown position. Access denied.", "Error");
                                            this.Show();
                                            break;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Username or Password.", "Login Failed");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Username or Password.", "Login Failed");
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error");
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
