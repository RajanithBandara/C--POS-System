using CSharp_POS_System.src.apps.dashboards;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

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

            string connectionStr = "Server=localhost,1433;Database=possdb;User Id=sa;Password=password123#";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string sql = "SELECT Pwd, Role FROM EmployeeTable WHERE UserName = @username";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedPassword = reader["Pwd"].ToString();
                                string role = reader["Role"].ToString();

                                if (storedPassword == enteredPassword)
                                {
                                    MessageBox.Show("Login successful!", "Success");
                                    this.Hide();

                                    // Redirect based on role
                                    switch (role)
                                    {
                                        case "Manager":
                                            maindashboard dashboard = new maindashboard();
                                            dashboard.Show();
                                            break;
                                        case "Cashier":
                                            Checkoutdashboard checkoutdashboard = new Checkoutdashboard();
                                            checkoutdashboard.Show();
                                            break;
                                        case "Store Keeper":
                                            inventorydashboard inventorydashboard = new inventorydashboard();
                                            inventorydashboard.Show();
                                            break;
                                        default:
                                            MessageBox.Show("Unknown role. Access denied.", "Error");
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

        // Function to update Employee details
        public void UpdateEmployee(int employeeID, string name, string username, string password, string position)
        {
            string connectionStr = "Server=localhost,1433;Database=possdb;User Id=sa;Password=password123#";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string sql = "UPDATE EmployeeTable SET EmployeeName = @name, UserName = @username, Pwd = @password, Position = @position WHERE EmployeeID = @employeeID";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@position", position);
                        cmd.Parameters.AddWithValue("@employeeID", employeeID);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Employee details updated successfully.", "Success");
                        }
                        else
                        {
                            MessageBox.Show("No matching employee found.", "Error");
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

        // Function to delete an Employee record
        public void DeleteEmployee(int employeeID)
        {
            string connectionStr = "Server=localhost,1433;Database=possdb;User Id=sa;Password=password123#";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string sql = "DELETE FROM EmployeeTable WHERE EmployeeID = @employeeID";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@employeeID", employeeID);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Employee record deleted successfully.", "Success");
                        }
                        else
                        {
                            MessageBox.Show("No matching employee found.", "Error");
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

        // Event Handlers
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Handle text changed event if needed
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Handle text changed event if needed
        }
    }
}
