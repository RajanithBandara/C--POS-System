namespace CSharp_POS_System.src.apps.inventorydash_userctrl
{
    partial class productadd
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
            this.Update = new RoundedPanelClass.RJPanel();
            this.Updatebutton = new CustomControls.RJControls.RJButton();
            this.ProductCategory = new System.Windows.Forms.ComboBox();
            this.Clear = new CustomControls.RJControls.RJButton();
            this.Submit = new CustomControls.RJControls.RJButton();
            this.BrandName = new System.Windows.Forms.TextBox();
            this.ProductName = new System.Windows.Forms.TextBox();
            this.ProductID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Update.SuspendLayout();
            this.SuspendLayout();
            // 
            // Update
            // 
            this.Update.BackColor = System.Drawing.Color.DarkGray;
            this.Update.BorderRadius = 30;
            this.Update.Controls.Add(this.Updatebutton);
            this.Update.Controls.Add(this.ProductCategory);
            this.Update.Controls.Add(this.Clear);
            this.Update.Controls.Add(this.Submit);
            this.Update.Controls.Add(this.BrandName);
            this.Update.Controls.Add(this.ProductName);
            this.Update.Controls.Add(this.ProductID);
            this.Update.Controls.Add(this.label5);
            this.Update.Controls.Add(this.label4);
            this.Update.Controls.Add(this.label3);
            this.Update.Controls.Add(this.label2);
            this.Update.Controls.Add(this.label1);
            this.Update.ForeColor = System.Drawing.Color.White;
            this.Update.GradientAngle = 90F;
            this.Update.GradientBottomColor = System.Drawing.Color.DarkGray;
            this.Update.GradientTopColor = System.Drawing.Color.DarkGray;
            this.Update.Location = new System.Drawing.Point(221, 28);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(883, 723);
            this.Update.TabIndex = 0;

            // 
            // Updatebutton
            // 
            this.Updatebutton.BackColor = System.Drawing.Color.Tomato;
            this.Updatebutton.BackgroundColor = System.Drawing.Color.Tomato;
            this.Updatebutton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.Updatebutton.BorderRadius = 6;
            this.Updatebutton.BorderSize = 0;
            this.Updatebutton.FlatAppearance.BorderSize = 0;
            this.Updatebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Updatebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.Updatebutton.ForeColor = System.Drawing.Color.White;
            this.Updatebutton.Location = new System.Drawing.Point(409, 549);
            this.Updatebutton.Name = "Updatebutton";
            this.Updatebutton.Size = new System.Drawing.Size(150, 40);
            this.Updatebutton.TabIndex = 12;
            this.Updatebutton.Text = "Update";
            this.Updatebutton.TextColor = System.Drawing.Color.White;
            this.Updatebutton.UseVisualStyleBackColor = false;
            this.Updatebutton.Click += new System.EventHandler(this.Updatebutton_Click);
            // 
            // ProductCategory
            // 
            this.ProductCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ProductCategory.FormattingEnabled = true;
            this.ProductCategory.Location = new System.Drawing.Point(396, 340);
            this.ProductCategory.Name = "ProductCategory";
            this.ProductCategory.Size = new System.Drawing.Size(296, 33);
            this.ProductCategory.TabIndex = 11;

            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.Color.Tomato;
            this.Clear.BackgroundColor = System.Drawing.Color.Tomato;
            this.Clear.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.Clear.BorderRadius = 6;
            this.Clear.BorderSize = 0;
            this.Clear.FlatAppearance.BorderSize = 0;
            this.Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.Clear.ForeColor = System.Drawing.Color.White;
            this.Clear.Location = new System.Drawing.Point(594, 549);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(150, 40);
            this.Clear.TabIndex = 10;
            this.Clear.Text = "Clear";
            this.Clear.TextColor = System.Drawing.Color.White;
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Submit
            // 
            this.Submit.BackColor = System.Drawing.Color.DimGray;
            this.Submit.BackgroundColor = System.Drawing.Color.DimGray;
            this.Submit.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.Submit.BorderRadius = 6;
            this.Submit.BorderSize = 0;
            this.Submit.FlatAppearance.BorderSize = 0;
            this.Submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.Submit.ForeColor = System.Drawing.Color.White;
            this.Submit.Location = new System.Drawing.Point(221, 549);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(150, 40);
            this.Submit.TabIndex = 9;
            this.Submit.Text = "Submit";
            this.Submit.TextColor = System.Drawing.Color.White;
            this.Submit.UseVisualStyleBackColor = false;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // BrandName
            // 
            this.BrandName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BrandName.Location = new System.Drawing.Point(396, 403);
            this.BrandName.Name = "BrandName";
            this.BrandName.Size = new System.Drawing.Size(296, 30);
            this.BrandName.TabIndex = 8;

            // 
            // ProductName
            // 
            this.ProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ProductName.Location = new System.Drawing.Point(396, 280);
            this.ProductName.Name = "ProductName";
            this.ProductName.Size = new System.Drawing.Size(296, 30);
            this.ProductName.TabIndex = 6;

            // 
            // ProductID
            // 
            this.ProductID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ProductID.Location = new System.Drawing.Point(396, 220);
            this.ProductID.Name = "ProductID";
            this.ProductID.Size = new System.Drawing.Size(296, 30);
            this.ProductID.TabIndex = 5;
     
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(191, 405);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Brand Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(191, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Product Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(191, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Product Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(191, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Product ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(274, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Addition Form";
            // 
            // productadd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.Update);
            this.Name = "productadd";
            this.Size = new System.Drawing.Size(1326, 780);
            this.Update.ResumeLayout(false);
            this.Update.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedPanelClass.RJPanel Update;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ProductID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox BrandName;
        private System.Windows.Forms.TextBox ProductName;
        private CustomControls.RJControls.RJButton Clear;
        private CustomControls.RJControls.RJButton Submit;
        private System.Windows.Forms.ComboBox ProductCategory;
        private CustomControls.RJControls.RJButton Updatebutton;
    }
}
