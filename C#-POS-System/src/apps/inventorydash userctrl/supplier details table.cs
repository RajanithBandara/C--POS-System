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
            kryptonDataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular);

            kryptonDataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16, FontStyle.Bold);

            var col1 = kryptonDataGridView1.Columns.Add("Column1", "Name");
            kryptonDataGridView1.Columns[col1].Width = 150; 

            var col2 = kryptonDataGridView1.Columns.Add("Column2", "Age");
            kryptonDataGridView1.Columns[col2].Width = 100; 

            var col3 = kryptonDataGridView1.Columns.Add("Column3", "Country");
            kryptonDataGridView1.Columns[col3].Width = 200; 

            kryptonDataGridView1.Rows.Add("John", "30", "USA");
            kryptonDataGridView1.Rows.Add("Anna", "25", "Canada");
            kryptonDataGridView1.Rows.Add("Mike", "35", "UK");

        }



    }
}
