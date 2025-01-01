using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_POS_System.src
{
    internal class usercontroladd
    {
        public static void addusercontrol(UserControl usrctrl, Panel panelname)
        {
            usrctrl.Dock = DockStyle.Fill;
            panelname.Controls.Clear();
            panelname.Controls.Add(usrctrl);
        }
    }
}
