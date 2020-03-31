namespace pjPalmera.PL
{
    partial class frmHistPagoClientesCr
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
            this.dgvHistPagosClientCr = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistPagosClientCr)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistPagosClientCr
            // 
            this.dgvHistPagosClientCr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistPagosClientCr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistPagosClientCr.Location = new System.Drawing.Point(12, 65);
            this.dgvHistPagosClientCr.Name = "dgvHistPagosClientCr";
            this.dgvHistPagosClientCr.Size = new System.Drawing.Size(781, 341);
            this.dgvHistPagosClientCr.TabIndex = 0;
            // 
            // frmHistPagoClientesCr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 418);
            this.Controls.Add(this.dgvHistPagosClientCr);
            this.Name = "frmHistPagoClientesCr";
            this.Text = "Historial de Pagos por Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistPagosClientCr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistPagosClientCr;
    }
}