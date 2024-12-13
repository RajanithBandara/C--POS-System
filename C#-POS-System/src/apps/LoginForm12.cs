using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_POS_System.src.apps
{
    public partial class LoginForm12 : Form
    {
        public LoginForm12()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text; 
            string password = textBox2.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both Username and Password.", "Input Error");
            }
            else
            {
                MessageBox.Show($"Welcome, {username}! Login Successful.", "Success");
            }
        }
    }
}
