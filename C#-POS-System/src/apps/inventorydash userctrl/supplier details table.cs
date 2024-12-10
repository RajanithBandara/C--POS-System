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
            ConfigureDataGridView();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ConfigureDataGridView()
        {
            dataGridView1.Columns.Add("Column1", "Name");
            dataGridView1.Columns.Add("Column2", "Age");
            dataGridView1.Columns.Add("Column3", "Country");

            dataGridView1.Rows.Add("John", "30", "USA");
            dataGridView1.Rows.Add("Anna", "25", "Canada");
            dataGridView1.Rows.Add("Mike", "35", "UK");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}
