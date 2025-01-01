using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_POS_System.src.apps.dashboards
{
    public partial class Checkoutdashboard : Form
    {
        
        public Checkoutdashboard()
        {
            InitializeComponent();
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rjPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            finalbillview finalbillview = new finalbillview();
            panel1.Controls.Clear();
            usercontroladd.addusercontrol(finalbillview, panel1);
        }

        private void rjPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Checkoutdashboard_Load(object sender, EventArgs e)
        {

        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            customerdetails customerdetails = new customerdetails();
            panel2.Controls.Clear();
            usercontroladd.addusercontrol(customerdetails, panel2);
        }

        private void rjButton2_Click_1(object sender, EventArgs e)
        {
            finalbillview finalbillview = new finalbillview();
            panel2.Controls.Clear();
            usercontroladd.addusercontrol(finalbillview, panel2);
        }

        private void rjButton1_Click_1(object sender, EventArgs e)
        {
            billaddition billadd = new billaddition();
            panel2.Controls.Clear();
            usercontroladd.addusercontrol(billadd, panel2);
        }
    }
}
