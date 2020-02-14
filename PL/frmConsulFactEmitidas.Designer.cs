namespace pjPalmera.PL
{
    partial class frmConsultFacturas
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
            this.dgvFacturasEmitidas = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasEmitidas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvFacturasEmitidas
            // 
            this.dgvFacturasEmitidas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFacturasEmitidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturasEmitidas.Location = new System.Drawing.Point(8, 70);
            this.dgvFacturasEmitidas.Name = "dgvFacturasEmitidas";
            this.dgvFacturasEmitidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturasEmitidas.Size = new System.Drawing.Size(954, 362);
            this.dgvFacturasEmitidas.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbFecha);
            this.groupBox1.Controls.Add(this.rbNumFact);
            this.groupBox1.Location = new System.Drawing.Point(390, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 52);
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
            this.rbNumFact.Text = "Numero Factura";
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
            this.btnExpExcel.Location = new System.Drawing.Point(678, 15);
            this.btnExpExcel.Name = "btnExpExcel";
            this.btnExpExcel.Size = new System.Drawing.Size(110, 31);
            this.btnExpExcel.TabIndex = 14;
            this.btnExpExcel.Text = "Exportar a Excel";
            this.btnExpExcel.UseVisualStyleBackColor = true;
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
            // frmConsultFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 441);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.mktxtFechaHasta);
            this.Controls.Add(this.mktxtFechaDesde);
            this.Controls.Add(this.btnExpExcel);
            this.Controls.Add(this.dgvFacturasEmitidas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCriterio2);
            this.Controls.Add(this.lblCriterio1);
            this.Controls.Add(this.txtValorCriterio1);
            this.Name = "frmConsultFacturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Facturas Emitidas";
            this.Load += new System.EventHandler(this.frmConsulFactEmitidas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasEmitidas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFacturasEmitidas;
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
    }
}