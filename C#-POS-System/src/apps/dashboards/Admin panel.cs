using C__POS_System.Properties;
using CSharp_POS_System.src.apps.Admin_panel_uctrl;
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
    public partial class Admin_panel : Form
    {
        public Admin_panel()
        {
            InitializeComponent();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            UserSettings usersettings = new UserSettings();
            panel1.Controls.Clear();
            usercontroladd.addusercontrol(usersettings, panel1);
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            UserAddition useradd = new UserAddition();  
            panel1.Controls.Clear();
            usercontroladd.addusercontrol(useradd, panel1);
        }
    }
}
