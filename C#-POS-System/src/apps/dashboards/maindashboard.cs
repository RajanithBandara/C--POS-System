﻿using C__POS_System.src.apps;
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
    public partial class maindashboard : Form
    {
        public maindashboard()
        {
            InitializeComponent();
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            discountadd discountadd = new discountadd();
            panel1.Controls.Clear();
            usercontroladd.addusercontrol(discountadd, panel1);
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            Supplier_details_addition_form supplieraddition = new Supplier_details_addition_form();
            panel1.Controls.Clear();
            usercontroladd.addusercontrol(supplieraddition, panel1);
        }
    }
}
