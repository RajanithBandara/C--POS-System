using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsAppProject.Apps;
using System.Data.SqlClient;

namespace CSharp_POS_System.src.apps.Admin_panel_uctrl
{
    public partial class UserSettings : UserControl
    {
        private string connectionString = dbconnection.Instance.ConnectionString;
        public UserSettings()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            
                string userId = textBox1.Text.Trim();
                string userName = textBox2.Text.Trim();
                string currentPassword = textBox3.Text.Trim();
                string newPassword = textBox4.Text.Trim();
                string confirmPassword = textBox5.Text.Trim();

                
                if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
                {
                    MessageBox.Show("All password fields must be filled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                string databasePassword = GetPasswordFromDatabase(userId);

                
                if (databasePassword == null)
                {
                    MessageBox.Show("User ID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (databasePassword != currentPassword)
                {
                    MessageBox.Show("The current password does not match the database password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                if (newPassword != confirmPassword)
                {
                    MessageBox.Show("The new password and confirm password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

               
                bool isUpdated = UpdateDatabase(userId, userName, newPassword);

                if (isUpdated)
                {
                    MessageBox.Show("User details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update user details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
            private string GetPasswordFromDatabase(string userId)
            {
                string password = null;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "SELECT Pwd FROM UserTable WHERE UserID = @UserID";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserID", userId);

                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                password = result.ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                return password;
            }

            private bool UpdateDatabase(string userId, string userName, string newPassword)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "UPDATE UserTable SET UserName = @UserName, Pwd = @Password WHERE UserID = @UserID";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserID", userId);
                            cmd.Parameters.AddWithValue("@UserName", userName);
                            cmd.Parameters.AddWithValue("@Password", newPassword);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            return rowsAffected > 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Database update error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }
    }


