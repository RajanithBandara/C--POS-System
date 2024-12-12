using C__POS_System.src.apps;
using CSharp_POS_System.src.apps.inventorydash_userctrl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_POS_System.src.apps.dashboards
{
    public partial class inventorydashboard : Form
    {
        public inventorydashboard()
        {
            InitializeComponent();
            ConfigureFullScreenMode();

        }

        private void ConfigureFullScreenMode()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            inventoryadd inventoryadd = new inventoryadd();
            panel1.Controls.Clear();
            usercontroladd.addusercontrol(inventoryadd, panel1);
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            supplier_details_table supplierdet = new supplier_details_table();
            panel1.Controls.Clear();
            usercontroladd.addusercontrol(supplierdet, panel1);
        }

        private void inventorydashboard_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
