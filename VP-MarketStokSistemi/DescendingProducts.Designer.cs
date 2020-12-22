namespace VP_MarketStokSistemi
{
    partial class DescendingProducts
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgwDecreasingProduct = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwDecreasingProduct)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgwDecreasingProduct
            // 
            this.dgwDecreasingProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwDecreasingProduct.Location = new System.Drawing.Point(79, 147);
            this.dgwDecreasingProduct.Name = "dgwDecreasingProduct";
            this.dgwDecreasingProduct.RowHeadersWidth = 51;
            this.dgwDecreasingProduct.RowTemplate.Height = 24;
            this.dgwDecreasingProduct.Size = new System.Drawing.Size(847, 483);
            this.dgwDecreasingProduct.TabIndex = 0;
            this.dgwDecreasingProduct.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwDecreasingProduct_CellContentDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(219, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 100);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(29, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(486, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Products Decreasing in Stock";
            // 
            // DescendingProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 743);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgwDecreasingProduct);
            this.Name = "DescendingProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Descending Products";
            this.Load += new System.EventHandler(this.DescendingProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwDecreasingProduct)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwDecreasingProduct;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}