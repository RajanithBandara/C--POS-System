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
            this.WindowState = FormWindowState.Maximized;

            this.MaximizeBox = false;
            this.MinimizeBox = false;

        }
    }
}
