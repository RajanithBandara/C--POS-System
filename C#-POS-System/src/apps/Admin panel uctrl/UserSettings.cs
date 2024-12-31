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
using System.Data.OleDb;

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
                string databaseUsername = GetUsernameFromDatabase(userId);
                
                if(databaseUsername  != userName)
            {
                MessageBox.Show("The current username does not match the database username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
        private string GetUsernameFromDatabase(string userId)
        {
            string username = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT  Username FROM UserTable WHERE UserID = @UserID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            username = result.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return username;
        }


        private bool UpdateDatabase(string userId, string userName, string newPassword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string procedureName = "UpdateUserData";

                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

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


        private void rjButton4_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int userId))
            {
                MessageBox.Show("Please enter a valid numeric User ID.");
                return;
            }

            string sqlcmd = "SELECT username FROM UserTable WHERE userId = @userId";
            using (SqlConnection conn = new SqlConnection(dbconnection.Instance.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sqlcmd, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);

                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string username = reader.GetString(0);
                                textBox2.Text = username;
                            }
                            else
                            {
                                MessageBox.Show("No user data found for the provided User ID.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    conn.Close();
                }
            }
        }

       
    }
}
    


