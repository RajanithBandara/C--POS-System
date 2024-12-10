using System;
using System.Data;
using System.Windows.Forms;

namespace CSharp_POS_System.src.apps.inventorydash_userctrl
{
    public partial class supplierdetails : UserControl
    {
        public supplierdetails()
        {
            InitializeComponent();
            LoadSupplierDetails();
        }

        private void LoadSupplierDetails()
        {
            if (rjPanel1 == null)
            {
                MessageBox.Show("rjPanel1 is not initialized.");
                return;
            }

            DataTable supplierTable = new DataTable();

            supplierTable.Columns.Add("Supplier ID", typeof(int));
            supplierTable.Columns.Add("Supplier Name", typeof(string));
            supplierTable.Columns.Add("Contact No", typeof(string));
            supplierTable.Columns.Add("Address", typeof(string));
            supplierTable.Columns.Add("Postal Address", typeof(string));

            supplierTable.Rows.Add(1, "ABC Suppliers", "1234567890", "123 Main Street", "10001");
            supplierTable.Rows.Add(2, "XYZ Traders", "9876543210", "456 Market Road", "20002");
            supplierTable.Rows.Add(3, "Global Supplies", "1122334455", "789 Commercial Ave", "30003");

            DataGridView dataGridView = new DataGridView
            {
                DataSource = supplierTable,
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            rjPanel1.Controls.Clear();
            rjPanel1.Controls.Add(dataGridView);
        }
    }
}
