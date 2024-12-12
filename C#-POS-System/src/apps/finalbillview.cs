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
    public partial class finalbillview : UserControl
    {
        public finalbillview()
        {
            InitializeComponent();
            datagridview();
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {}

        private void datagridview()
        {
            kryptonDataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);

            kryptonDataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);

            var col1 = kryptonDataGridView1.Columns.Add("Column1", "Product ID");
            kryptonDataGridView1.Columns[col1].Width = 148;

            var col2 = kryptonDataGridView1.Columns.Add("Column2", "Product Name");
            kryptonDataGridView1.Columns[col2].Width = 370;

            var col3 = kryptonDataGridView1.Columns.Add("Column3", "Unit Price");
            kryptonDataGridView1.Columns[col3].Width = 170;

            var col4 = kryptonDataGridView1.Columns.Add("Column4", "Quantity");
            kryptonDataGridView1.Columns[col4].Width = 150;

            var col5 = kryptonDataGridView1.Columns.Add("Column5", "Total Price");
            kryptonDataGridView1.Columns[col5].Width = 170;

            var col6 = kryptonDataGridView1.Columns.Add("Column6", "Discount Detail");
            kryptonDataGridView1.Columns[col6].Width = 200;

            var col7 = kryptonDataGridView1.Columns.Add("Column7", "Total Discount");
            kryptonDataGridView1.Columns[col7].Width = 200;

            var col8 = kryptonDataGridView1.Columns.Add("Column8", "Net Price");
            kryptonDataGridView1.Columns[col8].Width = 170;

            for(int i = 1; i<=20; i++)
            {
                kryptonDataGridView1.Rows.Add("001", "Munchee biscuit", "350", "3", "1050", "50", "150", "900");
            }
        }
    }
}
