using RoundedPanelClass;
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
    public partial class customerdetails : UserControl
    {
        public customerdetails()
        {
            InitializeComponent();
            datagridview();
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datagridview()
        {
            kryptonDataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);

            kryptonDataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);

            int widthoff = rjPanel1.Width;

            var col1 = kryptonDataGridView1.Columns.Add("Column1", "Customer ID");
            kryptonDataGridView1.Columns[col1].Width = widthoff / 9;

            var col2 = kryptonDataGridView1.Columns.Add("Column2", "Customer Name");
            kryptonDataGridView1.Columns[col2].Width = widthoff / 5;

            var col3 = kryptonDataGridView1.Columns.Add("Column3", "Email Address");
            kryptonDataGridView1.Columns[col3].Width = widthoff / 5;

            var col4 = kryptonDataGridView1.Columns.Add("Column4", "Contact");
            kryptonDataGridView1.Columns[col4].Width = widthoff / 7;

            var col5 = kryptonDataGridView1.Columns.Add("Column5", "Postal Address");
            kryptonDataGridView1.Columns[col5].Width = widthoff / 3;

            for (int i = 1; i <= 20; i++)
            {
                kryptonDataGridView1.Rows.Add("101", "Saman Perera", "someone@gmail.com", "1234567890", "22/B, JayasiriMawatha, Katuneriya");
            }
        }
    }
}
