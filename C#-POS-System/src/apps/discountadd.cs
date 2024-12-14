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
    public partial class discountadd : UserControl
    {
        public discountadd()
        {
            InitializeComponent();
        }

        private void discountadd_Load(object sender, EventArgs e)
        {

        }

        private void rjPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
