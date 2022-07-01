namespace PL
{
    partial class frmSearchCategory
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
            this.dgvCategoria = new System.Windows.Forms.DataGridView();
            this.lblCategoryFiltre = new System.Windows.Forms.Label();
            this.txtCriterio = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoria)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCategoria
            // 
            this.dgvCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategoria.Location = new System.Drawing.Point(12, 35);
            this.dgvCategoria.Name = "dgvCategoria";
            this.dgvCategoria.Size = new System.Drawing.Size(405, 266);
            this.dgvCategoria.TabIndex = 0;
            // 
            // lblCategoryFiltre
            // 
            this.lblCategoryFiltre.AutoSize = true;
            this.lblCategoryFiltre.Location = new System.Drawing.Point(12, 9);
            this.lblCategoryFiltre.Name = "lblCategoryFiltre";
            this.lblCategoryFiltre.Size = new System.Drawing.Size(35, 13);
            this.lblCategoryFiltre.TabIndex = 1;
            this.lblCategoryFiltre.Text = "label1";
            // 
            // txtCriterio
            // 
            this.txtCriterio.Location = new System.Drawing.Point(73, 9);
            this.txtCriterio.Name = "txtCriterio";
            this.txtCriterio.Size = new System.Drawing.Size(200, 20);
            this.txtCriterio.TabIndex = 2;
            // 
            // frmSearchCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 313);
            this.Controls.Add(this.txtCriterio);
            this.Controls.Add(this.lblCategoryFiltre);
            this.Controls.Add(this.dgvCategoria);
            this.Name = "frmSearchCategory";
            this.Text = "Buscar Categoria";
            this.Load += new System.EventHandler(this.frmSearchCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCategoria;
        private System.Windows.Forms.Label lblCategoryFiltre;
        private System.Windows.Forms.TextBox txtCriterio;
    }
}