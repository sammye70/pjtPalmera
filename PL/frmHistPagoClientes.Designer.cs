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
            this.lblCriterial = new System.Windows.Forms.Label();
            this.txtCriterial = new System.Windows.Forms.TextBox();
            this.rbId = new System.Windows.Forms.RadioButton();
            this.rbCedula = new System.Windows.Forms.RadioButton();
            this.txtTypeQuery = new System.Windows.Forms.TextBox();
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
            // lblCriterial
            // 
            this.lblCriterial.AutoSize = true;
            this.lblCriterial.Location = new System.Drawing.Point(13, 28);
            this.lblCriterial.Name = "lblCriterial";
            this.lblCriterial.Size = new System.Drawing.Size(35, 13);
            this.lblCriterial.TabIndex = 1;
            this.lblCriterial.Text = "label1";
            // 
            // txtCriterial
            // 
            this.txtCriterial.Location = new System.Drawing.Point(130, 25);
            this.txtCriterial.Name = "txtCriterial";
            this.txtCriterial.Size = new System.Drawing.Size(131, 20);
            this.txtCriterial.TabIndex = 2;
            this.txtCriterial.TextChanged += new System.EventHandler(this.txtCriterial_TextChanged);
            // 
            // rbId
            // 
            this.rbId.AutoSize = true;
            this.rbId.Location = new System.Drawing.Point(360, 28);
            this.rbId.Name = "rbId";
            this.rbId.Size = new System.Drawing.Size(34, 17);
            this.rbId.TabIndex = 3;
            this.rbId.TabStop = true;
            this.rbId.Text = "Id";
            this.rbId.UseVisualStyleBackColor = true;
            // 
            // rbCedula
            // 
            this.rbCedula.AutoSize = true;
            this.rbCedula.Location = new System.Drawing.Point(469, 28);
            this.rbCedula.Name = "rbCedula";
            this.rbCedula.Size = new System.Drawing.Size(58, 17);
            this.rbCedula.TabIndex = 4;
            this.rbCedula.TabStop = true;
            this.rbCedula.Text = "Cedula";
            this.rbCedula.UseVisualStyleBackColor = true;
            // 
            // txtTypeQuery
            // 
            this.txtTypeQuery.Location = new System.Drawing.Point(642, 25);
            this.txtTypeQuery.Name = "txtTypeQuery";
            this.txtTypeQuery.Size = new System.Drawing.Size(100, 20);
            this.txtTypeQuery.TabIndex = 5;
            this.txtTypeQuery.Visible = false;
            // 
            // frmHistPagoClientesCr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 418);
            this.Controls.Add(this.txtTypeQuery);
            this.Controls.Add(this.rbCedula);
            this.Controls.Add(this.rbId);
            this.Controls.Add(this.txtCriterial);
            this.Controls.Add(this.lblCriterial);
            this.Controls.Add(this.dgvHistPagosClientCr);
            this.Name = "frmHistPagoClientesCr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial de Pagos por Clientes";
            this.Load += new System.EventHandler(this.frmHistPagoClientesCr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistPagosClientCr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistPagosClientCr;
        private System.Windows.Forms.Label lblCriterial;
        private System.Windows.Forms.TextBox txtCriterial;
        private System.Windows.Forms.RadioButton rbId;
        private System.Windows.Forms.RadioButton rbCedula;
        public System.Windows.Forms.TextBox txtTypeQuery;
    }
}