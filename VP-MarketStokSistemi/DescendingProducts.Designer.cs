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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DescendingProducts));
            this.dgwDecreasingProduct = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwDecreasingProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwDecreasingProduct
            // 
            this.dgwDecreasingProduct.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgwDecreasingProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwDecreasingProduct.Location = new System.Drawing.Point(108, 172);
            this.dgwDecreasingProduct.Name = "dgwDecreasingProduct";
            this.dgwDecreasingProduct.RowHeadersWidth = 51;
            this.dgwDecreasingProduct.RowTemplate.Height = 24;
            this.dgwDecreasingProduct.Size = new System.Drawing.Size(847, 483);
            this.dgwDecreasingProduct.TabIndex = 0;
            this.dgwDecreasingProduct.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwDecreasingProduct_CellContentDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(242, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(521, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "Products Decreasing in Stock";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlText;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(929, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 80);
            this.button2.TabIndex = 8;
            this.button2.Text = "CLOSE";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DescendingProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1123, 743);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgwDecreasingProduct);
            this.Name = "DescendingProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Descending Products";
            this.Load += new System.EventHandler(this.DescendingProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwDecreasingProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwDecreasingProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}