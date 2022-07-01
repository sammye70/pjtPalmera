namespace pjPalmera.PL
{
    partial class frmConsultFacturasCont
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbFecha = new System.Windows.Forms.RadioButton();
            this.rbNumFact = new System.Windows.Forms.RadioButton();
            this.lblCriterio2 = new System.Windows.Forms.Label();
            this.lblCriterio1 = new System.Windows.Forms.Label();
            this.txtValorCriterio1 = new System.Windows.Forms.TextBox();
            this.btnExpExcel = new System.Windows.Forms.Button();
            this.mktxtFechaDesde = new System.Windows.Forms.MaskedTextBox();
            this.mktxtFechaHasta = new System.Windows.Forms.MaskedTextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblMontoTotalinvoicesRes = new System.Windows.Forms.Label();
            this.lblMontoAll_invoices = new System.Windows.Forms.Label();
            this.gbHeadInvoices = new System.Windows.Forms.GroupBox();
            this.dgvFacturasEmitidas = new System.Windows.Forms.DataGridView();
            this.gbDetailinvoices = new System.Windows.Forms.GroupBox();
            this.dgvDetailFactCont = new System.Windows.Forms.DataGridView();
            this.btnConsulDetailinvoice = new System.Windows.Forms.Button();
            this.btnFiltroInvoices = new System.Windows.Forms.Button();
            this.btnReprintInvoice = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gbHeadInvoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasEmitidas)).BeginInit();
            this.gbDetailinvoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailFactCont)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbFecha);
            this.groupBox1.Controls.Add(this.rbNumFact);
            this.groupBox1.Location = new System.Drawing.Point(425, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 52);
            this.groupBox1.TabIndex = 12;
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
            this.rbFecha.CheckedChanged += new System.EventHandler(this.rbFecha_CheckedChanged);
            // 
            // rbNumFact
            // 
            this.rbNumFact.AutoSize = true;
            this.rbNumFact.Location = new System.Drawing.Point(29, 23);
            this.rbNumFact.Name = "rbNumFact";
            this.rbNumFact.Size = new System.Drawing.Size(101, 17);
            this.rbNumFact.TabIndex = 6;
            this.rbNumFact.TabStop = true;
            this.rbNumFact.Text = "Número Factura";
            this.rbNumFact.UseVisualStyleBackColor = true;
            this.rbNumFact.CheckedChanged += new System.EventHandler(this.rbNumFact_CheckedChanged);
            // 
            // lblCriterio2
            // 
            this.lblCriterio2.AutoSize = true;
            this.lblCriterio2.Location = new System.Drawing.Point(174, 29);
            this.lblCriterio2.Name = "lblCriterio2";
            this.lblCriterio2.Size = new System.Drawing.Size(35, 13);
            this.lblCriterio2.TabIndex = 11;
            this.lblCriterio2.Text = "label2";
            // 
            // lblCriterio1
            // 
            this.lblCriterio1.AutoSize = true;
            this.lblCriterio1.Location = new System.Drawing.Point(14, 29);
            this.lblCriterio1.Name = "lblCriterio1";
            this.lblCriterio1.Size = new System.Drawing.Size(35, 13);
            this.lblCriterio1.TabIndex = 10;
            this.lblCriterio1.Text = "label1";
            // 
            // txtValorCriterio1
            // 
            this.txtValorCriterio1.Location = new System.Drawing.Point(60, 26);
            this.txtValorCriterio1.Name = "txtValorCriterio1";
            this.txtValorCriterio1.Size = new System.Drawing.Size(100, 20);
            this.txtValorCriterio1.TabIndex = 8;
            this.txtValorCriterio1.TextChanged += new System.EventHandler(this.txtValorCriterio1_TextChanged);
            // 
            // btnExpExcel
            // 
            this.btnExpExcel.Image = global::PL.Properties.Resources.up;
            this.btnExpExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExpExcel.Location = new System.Drawing.Point(1046, 22);
            this.btnExpExcel.Name = "btnExpExcel";
            this.btnExpExcel.Size = new System.Drawing.Size(122, 39);
            this.btnExpExcel.TabIndex = 14;
            this.btnExpExcel.Text = "Exportar a Excel";
            this.btnExpExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExpExcel.UseVisualStyleBackColor = true;
            this.btnExpExcel.Visible = false;
            // 
            // mktxtFechaDesde
            // 
            this.mktxtFechaDesde.Location = new System.Drawing.Point(60, 26);
            this.mktxtFechaDesde.Mask = "00/00/0000";
            this.mktxtFechaDesde.Name = "mktxtFechaDesde";
            this.mktxtFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.mktxtFechaDesde.TabIndex = 15;
            this.mktxtFechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // mktxtFechaHasta
            // 
            this.mktxtFechaHasta.Location = new System.Drawing.Point(215, 26);
            this.mktxtFechaHasta.Mask = "00/00/0000";
            this.mktxtFechaHasta.Name = "mktxtFechaHasta";
            this.mktxtFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.mktxtFechaHasta.TabIndex = 16;
            this.mktxtFechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::PL.Properties.Resources.search;
            this.btnSearch.Location = new System.Drawing.Point(321, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(46, 39);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblMontoTotalinvoicesRes
            // 
            this.lblMontoTotalinvoicesRes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMontoTotalinvoicesRes.AutoSize = true;
            this.lblMontoTotalinvoicesRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTotalinvoicesRes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblMontoTotalinvoicesRes.Location = new System.Drawing.Point(1065, 616);
            this.lblMontoTotalinvoicesRes.Name = "lblMontoTotalinvoicesRes";
            this.lblMontoTotalinvoicesRes.Size = new System.Drawing.Size(109, 24);
            this.lblMontoTotalinvoicesRes.TabIndex = 19;
            this.lblMontoTotalinvoicesRes.Text = "Resultado ";
            this.lblMontoTotalinvoicesRes.Visible = false;
            // 
            // lblMontoAll_invoices
            // 
            this.lblMontoAll_invoices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMontoAll_invoices.AutoSize = true;
            this.lblMontoAll_invoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoAll_invoices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblMontoAll_invoices.Location = new System.Drawing.Point(944, 616);
            this.lblMontoAll_invoices.Name = "lblMontoAll_invoices";
            this.lblMontoAll_invoices.Size = new System.Drawing.Size(126, 24);
            this.lblMontoAll_invoices.TabIndex = 18;
            this.lblMontoAll_invoices.Text = "Monto Total:";
            this.lblMontoAll_invoices.Visible = false;
            // 
            // gbHeadInvoices
            // 
            this.gbHeadInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbHeadInvoices.Controls.Add(this.dgvFacturasEmitidas);
            this.gbHeadInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbHeadInvoices.Location = new System.Drawing.Point(5, 80);
            this.gbHeadInvoices.Name = "gbHeadInvoices";
            this.gbHeadInvoices.Size = new System.Drawing.Size(1169, 228);
            this.gbHeadInvoices.TabIndex = 22;
            this.gbHeadInvoices.TabStop = false;
            this.gbHeadInvoices.Text = "Facturas";
            // 
            // dgvFacturasEmitidas
            // 
            this.dgvFacturasEmitidas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFacturasEmitidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturasEmitidas.Location = new System.Drawing.Point(6, 23);
            this.dgvFacturasEmitidas.Name = "dgvFacturasEmitidas";
            this.dgvFacturasEmitidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturasEmitidas.Size = new System.Drawing.Size(1157, 193);
            this.dgvFacturasEmitidas.TabIndex = 15;
            // 
            // gbDetailinvoices
            // 
            this.gbDetailinvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetailinvoices.Controls.Add(this.dgvDetailFactCont);
            this.gbDetailinvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDetailinvoices.Location = new System.Drawing.Point(5, 326);
            this.gbDetailinvoices.Name = "gbDetailinvoices";
            this.gbDetailinvoices.Size = new System.Drawing.Size(1169, 287);
            this.gbDetailinvoices.TabIndex = 23;
            this.gbDetailinvoices.TabStop = false;
            this.gbDetailinvoices.Text = "Detalle de la Factura";
            // 
            // dgvDetailFactCont
            // 
            this.dgvDetailFactCont.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetailFactCont.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailFactCont.Location = new System.Drawing.Point(6, 21);
            this.dgvDetailFactCont.Name = "dgvDetailFactCont";
            this.dgvDetailFactCont.RowHeadersWidth = 67;
            this.dgvDetailFactCont.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetailFactCont.Size = new System.Drawing.Size(1157, 257);
            this.dgvDetailFactCont.TabIndex = 24;
            // 
            // btnConsulDetailinvoice
            // 
            this.btnConsulDetailinvoice.Image = global::PL.Properties.Resources.go;
            this.btnConsulDetailinvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsulDetailinvoice.Location = new System.Drawing.Point(684, 22);
            this.btnConsulDetailinvoice.Name = "btnConsulDetailinvoice";
            this.btnConsulDetailinvoice.Size = new System.Drawing.Size(130, 39);
            this.btnConsulDetailinvoice.TabIndex = 24;
            this.btnConsulDetailinvoice.Text = "Consultar Detalle";
            this.btnConsulDetailinvoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsulDetailinvoice.UseVisualStyleBackColor = true;
            this.btnConsulDetailinvoice.Click += new System.EventHandler(this.btnConsulDetailinvoice_Click);
            // 
            // btnFiltroInvoices
            // 
            this.btnFiltroInvoices.Image = global::PL.Properties.Resources.delete;
            this.btnFiltroInvoices.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltroInvoices.Location = new System.Drawing.Point(820, 22);
            this.btnFiltroInvoices.Name = "btnFiltroInvoices";
            this.btnFiltroInvoices.Size = new System.Drawing.Size(110, 39);
            this.btnFiltroInvoices.TabIndex = 25;
            this.btnFiltroInvoices.Text = "Borrar Filtro";
            this.btnFiltroInvoices.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiltroInvoices.UseVisualStyleBackColor = true;
            this.btnFiltroInvoices.Click += new System.EventHandler(this.btnFiltroInvoices_Click);
            // 
            // btnReprintInvoice
            // 
            this.btnReprintInvoice.Image = global::PL.Properties.Resources.print;
            this.btnReprintInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReprintInvoice.Location = new System.Drawing.Point(936, 22);
            this.btnReprintInvoice.Name = "btnReprintInvoice";
            this.btnReprintInvoice.Size = new System.Drawing.Size(104, 39);
            this.btnReprintInvoice.TabIndex = 26;
            this.btnReprintInvoice.Text = "Reimprimir";
            this.btnReprintInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReprintInvoice.UseVisualStyleBackColor = true;
            this.btnReprintInvoice.Click += new System.EventHandler(this.btnReprintInvoice_Click);
            // 
            // frmConsultFacturasCont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 649);
            this.Controls.Add(this.btnReprintInvoice);
            this.Controls.Add(this.btnFiltroInvoices);
            this.Controls.Add(this.btnConsulDetailinvoice);
            this.Controls.Add(this.gbDetailinvoices);
            this.Controls.Add(this.gbHeadInvoices);
            this.Controls.Add(this.lblMontoTotalinvoicesRes);
            this.Controls.Add(this.lblMontoAll_invoices);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.mktxtFechaHasta);
            this.Controls.Add(this.mktxtFechaDesde);
            this.Controls.Add(this.btnExpExcel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCriterio2);
            this.Controls.Add(this.lblCriterio1);
            this.Controls.Add(this.txtValorCriterio1);
            this.Name = "frmConsultFacturasCont";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Facturas al Contado";
            this.Load += new System.EventHandler(this.frmConsulFactEmitidas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbHeadInvoices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasEmitidas)).EndInit();
            this.gbDetailinvoices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailFactCont)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbFecha;
        private System.Windows.Forms.RadioButton rbNumFact;
        private System.Windows.Forms.Label lblCriterio2;
        private System.Windows.Forms.Label lblCriterio1;
        private System.Windows.Forms.TextBox txtValorCriterio1;
        private System.Windows.Forms.Button btnExpExcel;
        private System.Windows.Forms.MaskedTextBox mktxtFechaDesde;
        private System.Windows.Forms.MaskedTextBox mktxtFechaHasta;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Label lblMontoTotalinvoicesRes;
        public System.Windows.Forms.Label lblMontoAll_invoices;
        private System.Windows.Forms.GroupBox gbHeadInvoices;
        private System.Windows.Forms.DataGridView dgvFacturasEmitidas;
        private System.Windows.Forms.GroupBox gbDetailinvoices;
        private System.Windows.Forms.DataGridView dgvDetailFactCont;
        private System.Windows.Forms.Button btnConsulDetailinvoice;
        private System.Windows.Forms.Button btnFiltroInvoices;
        private System.Windows.Forms.Button btnReprintInvoice;
    }
}