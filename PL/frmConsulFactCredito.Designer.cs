namespace pjPalmera.PL
{
    partial class frmConsulFactCredito
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
            this.components = new System.ComponentModel.Container();
            this.dgvFacturasEmitidasCred = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblMontoTotalinvoicesRes = new System.Windows.Forms.Label();
            this.lblMontoAll_invoices = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbFecha = new System.Windows.Forms.RadioButton();
            this.rbNumFact = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.mktxtFechaHasta = new System.Windows.Forms.MaskedTextBox();
            this.mktxtFechaDesde = new System.Windows.Forms.MaskedTextBox();
            this.btnExpExcel = new System.Windows.Forms.Button();
            this.lblCriterio2 = new System.Windows.Forms.Label();
            this.lblCriterio1 = new System.Windows.Forms.Label();
            this.txtNumFactura = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasEmitidasCred)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvFacturasEmitidasCred
            // 
            this.dgvFacturasEmitidasCred.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFacturasEmitidasCred.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturasEmitidasCred.Location = new System.Drawing.Point(12, 69);
            this.dgvFacturasEmitidasCred.Name = "dgvFacturasEmitidasCred";
            this.dgvFacturasEmitidasCred.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturasEmitidasCred.Size = new System.Drawing.Size(1158, 334);
            this.dgvFacturasEmitidasCred.TabIndex = 24;
            // 
            // lblMontoTotalinvoicesRes
            // 
            this.lblMontoTotalinvoicesRes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMontoTotalinvoicesRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTotalinvoicesRes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblMontoTotalinvoicesRes.Location = new System.Drawing.Point(1064, 406);
            this.lblMontoTotalinvoicesRes.Name = "lblMontoTotalinvoicesRes";
            this.lblMontoTotalinvoicesRes.Size = new System.Drawing.Size(109, 24);
            this.lblMontoTotalinvoicesRes.TabIndex = 30;
            this.lblMontoTotalinvoicesRes.Text = "Resultado ";
            // 
            // lblMontoAll_invoices
            // 
            this.lblMontoAll_invoices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMontoAll_invoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoAll_invoices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblMontoAll_invoices.Location = new System.Drawing.Point(943, 406);
            this.lblMontoAll_invoices.Name = "lblMontoAll_invoices";
            this.lblMontoAll_invoices.Size = new System.Drawing.Size(126, 24);
            this.lblMontoAll_invoices.TabIndex = 29;
            this.lblMontoAll_invoices.Text = "Monto Total:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.mktxtFechaHasta);
            this.panel1.Controls.Add(this.mktxtFechaDesde);
            this.panel1.Controls.Add(this.btnExpExcel);
            this.panel1.Controls.Add(this.lblCriterio2);
            this.panel1.Controls.Add(this.lblCriterio1);
            this.panel1.Controls.Add(this.txtNumFactura);
            this.panel1.Location = new System.Drawing.Point(12, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1158, 63);
            this.panel1.TabIndex = 31;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbFecha);
            this.groupBox1.Controls.Add(this.rbNumFact);
            this.groupBox1.Location = new System.Drawing.Point(460, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 52);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrado por";
            // 
            // rbFecha
            // 
            this.rbFecha.AutoSize = true;
            this.rbFecha.Location = new System.Drawing.Point(157, 23);
            this.rbFecha.Name = "rbFecha";
            this.rbFecha.Size = new System.Drawing.Size(55, 17);
            this.rbFecha.TabIndex = 7;
            this.rbFecha.TabStop = true;
            this.rbFecha.Text = "Fecha";
            this.rbFecha.UseVisualStyleBackColor = true;
            // 
            // rbNumFact
            // 
            this.rbNumFact.AutoSize = true;
            this.rbNumFact.Location = new System.Drawing.Point(29, 23);
            this.rbNumFact.Name = "rbNumFact";
            this.rbNumFact.Size = new System.Drawing.Size(101, 17);
            this.rbNumFact.TabIndex = 6;
            this.rbNumFact.TabStop = true;
            this.rbNumFact.Text = "Numero Factura";
            this.rbNumFact.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::PL.Properties.Resources.search;
            this.btnSearch.Location = new System.Drawing.Point(338, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(46, 39);
            this.btnSearch.TabIndex = 36;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Visible = false;
            // 
            // mktxtFechaHasta
            // 
            this.mktxtFechaHasta.Location = new System.Drawing.Point(232, 22);
            this.mktxtFechaHasta.Mask = "00/00/0000";
            this.mktxtFechaHasta.Name = "mktxtFechaHasta";
            this.mktxtFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.mktxtFechaHasta.TabIndex = 35;
            this.mktxtFechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // mktxtFechaDesde
            // 
            this.mktxtFechaDesde.Location = new System.Drawing.Point(77, 22);
            this.mktxtFechaDesde.Mask = "00/00/0000";
            this.mktxtFechaDesde.Name = "mktxtFechaDesde";
            this.mktxtFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.mktxtFechaDesde.TabIndex = 34;
            this.mktxtFechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // btnExpExcel
            // 
            this.btnExpExcel.Location = new System.Drawing.Point(748, 18);
            this.btnExpExcel.Name = "btnExpExcel";
            this.btnExpExcel.Size = new System.Drawing.Size(110, 31);
            this.btnExpExcel.TabIndex = 33;
            this.btnExpExcel.Text = "Exportar a Excel";
            this.btnExpExcel.UseVisualStyleBackColor = true;
            // 
            // lblCriterio2
            // 
            this.lblCriterio2.AutoSize = true;
            this.lblCriterio2.Location = new System.Drawing.Point(191, 25);
            this.lblCriterio2.Name = "lblCriterio2";
            this.lblCriterio2.Size = new System.Drawing.Size(35, 13);
            this.lblCriterio2.TabIndex = 31;
            this.lblCriterio2.Text = "label2";
            // 
            // lblCriterio1
            // 
            this.lblCriterio1.AutoSize = true;
            this.lblCriterio1.Location = new System.Drawing.Point(31, 25);
            this.lblCriterio1.Name = "lblCriterio1";
            this.lblCriterio1.Size = new System.Drawing.Size(35, 13);
            this.lblCriterio1.TabIndex = 30;
            this.lblCriterio1.Text = "label1";
            // 
            // txtNumFactura
            // 
            this.txtNumFactura.Location = new System.Drawing.Point(77, 22);
            this.txtNumFactura.Name = "txtNumFactura";
            this.txtNumFactura.Size = new System.Drawing.Size(100, 20);
            this.txtNumFactura.TabIndex = 29;
            // 
            // frmConsulFactCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 453);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvFacturasEmitidasCred);
            this.Controls.Add(this.lblMontoTotalinvoicesRes);
            this.Controls.Add(this.lblMontoAll_invoices);
            this.Name = "frmConsulFactCredito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Facturas a Credito";
            this.Load += new System.EventHandler(this.frmConsulFactCredito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasEmitidasCred)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFacturasEmitidasCred;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Label lblMontoTotalinvoicesRes;
        public System.Windows.Forms.Label lblMontoAll_invoices;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbFecha;
        private System.Windows.Forms.RadioButton rbNumFact;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.MaskedTextBox mktxtFechaHasta;
        private System.Windows.Forms.MaskedTextBox mktxtFechaDesde;
        private System.Windows.Forms.Button btnExpExcel;
        private System.Windows.Forms.Label lblCriterio2;
        private System.Windows.Forms.Label lblCriterio1;
        private System.Windows.Forms.TextBox txtNumFactura;
    }
}