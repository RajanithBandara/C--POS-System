namespace CSharp_POS_System.src.apps.inventorydash_userctrl
{
    partial class inventory_view
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kryptonDataGridView1 = new Krypton.Toolkit.KryptonDataGridView();
            this.kryptonDataGridView2 = new Krypton.Toolkit.KryptonDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.kryptonDataGridView1.ColumnHeadersHeight = 36;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 10);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.RowHeadersWidth = 51;
            this.kryptonDataGridView1.RowTemplate.Height = 24;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(1306, 500);
            this.kryptonDataGridView1.TabIndex = 0;
            // 
            // kryptonDataGridView2
            // 
            this.kryptonDataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.kryptonDataGridView2.ColumnHeadersHeight = 36;
            this.kryptonDataGridView2.Location = new System.Drawing.Point(0, 520);
            this.kryptonDataGridView2.Name = "kryptonDataGridView2";
            this.kryptonDataGridView2.RowHeadersWidth = 51;
            this.kryptonDataGridView2.RowTemplate.Height = 24;
            this.kryptonDataGridView2.Size = new System.Drawing.Size(1306, 230);
            this.kryptonDataGridView2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.kryptonDataGridView1);
            this.panel1.Controls.Add(this.kryptonDataGridView2);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1306, 760);
            this.panel1.TabIndex = 2;
            // 
            // inventory_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.panel1);
            this.Name = "inventory_view";
            this.Size = new System.Drawing.Size(1326, 780);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private Krypton.Toolkit.KryptonDataGridView kryptonDataGridView2;
        private System.Windows.Forms.Panel panel1;
    }
}
