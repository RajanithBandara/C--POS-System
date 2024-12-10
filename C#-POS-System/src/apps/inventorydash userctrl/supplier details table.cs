using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krypton.Toolkit;

namespace C__POS_System.src.apps
{
    public partial class supplier_details_table : UserControl
    {
        public supplier_details_table()
        {
            InitializeComponent();
            ConfigureKryptonDataGridView();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void ConfigureKryptonDataGridView()
        {

            kryptonDataGridView1.Columns.Add("Column1", "Name");
            kryptonDataGridView1.Columns.Add("Column2", "Age");
            kryptonDataGridView1.Columns.Add("Column3", "Country");

            kryptonDataGridView1.Rows.Add("John", "30", "USA");
            kryptonDataGridView1.Rows.Add("Anna", "25", "Canada");
            kryptonDataGridView1.Rows.Add("Mike", "35", "UK");

        }

}
}
