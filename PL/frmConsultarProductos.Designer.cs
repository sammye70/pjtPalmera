namespace pjPalmera.PL
{
    partial class frmConsultarProductos
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
            this.dgvProdConsultar = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDescripcion = new System.Windows.Forms.RadioButton();
            this.rbCodigo = new System.Windows.Forms.RadioButton();
            this.btnExpExcel = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.txtCriterioBusqueda = new System.Windows.Forms.TextBox();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.dgvProductOnlyActive = new System.Windows.Forms.DataGridView();
            this.lblCostoAllProductos = new System.Windows.Forms.Label();
            this.lblCostoTotalProductRes = new System.Windows.Forms.Label();
            this.lblCantidadProdRes = new System.Windows.Forms.Label();
            this.lblTotalProductos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdConsultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductOnlyActive)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProdConsultar
            // 
            this.dgvProdConsultar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProdConsultar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdConsultar.Location = new System.Drawing.Point(12, 104);
            this.dgvProdConsultar.Name = "dgvProdConsultar";
            this.dgvProdConsultar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdConsultar.Size = new System.Drawing.Size(1053, 358);
            this.dgvProdConsultar.TabIndex = 0;
            this.dgvProdConsultar.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdConsultar_CellContentDoubleClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnExpExcel);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.lblCriterio);
            this.panel1.Controls.Add(this.txtCriterioBusqueda);
            this.panel1.Location = new System.Drawing.Point(7, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1053, 56);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDescripcion);
            this.groupBox1.Controls.Add(this.rbCodigo);
            this.groupBox1.Location = new System.Drawing.Point(518, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 49);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar por";
            // 
            // rbDescripcion
            // 
            this.rbDescripcion.AutoSize = true;
            this.rbDescripcion.Location = new System.Drawing.Point(126, 20);
            this.rbDescripcion.Name = "rbDescripcion";
            this.rbDescripcion.Size = new System.Drawing.Size(81, 17);
            this.rbDescripcion.TabIndex = 10;
            this.rbDescripcion.TabStop = true;
            this.rbDescripcion.Text = "Descripción";
            this.rbDescripcion.UseVisualStyleBackColor = true;
            this.rbDescripcion.CheckedChanged += new System.EventHandler(this.rbDescripcion_CheckedChanged);
            // 
            // rbCodigo
            // 
            this.rbCodigo.AutoSize = true;
            this.rbCodigo.Location = new System.Drawing.Point(34, 20);
            this.rbCodigo.Name = "rbCodigo";
            this.rbCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbCodigo.TabIndex = 9;
            this.rbCodigo.TabStop = true;
            this.rbCodigo.Text = "Código";
            this.rbCodigo.UseVisualStyleBackColor = true;
            this.rbCodigo.CheckedChanged += new System.EventHandler(this.rbCodigo_CheckedChanged);
            // 
            // btnExpExcel
            // 
            this.btnExpExcel.Location = new System.Drawing.Point(856, 11);
            this.btnExpExcel.Name = "btnExpExcel";
            this.btnExpExcel.Size = new System.Drawing.Size(102, 32);
            this.btnExpExcel.TabIndex = 10;
            this.btnExpExcel.Text = "Generar Informe";
            this.btnExpExcel.UseVisualStyleBackColor = true;
            this.btnExpExcel.Click += new System.EventHandler(this.btnExpExcel_Click);
            // 
            // button2
            // 
            this.button2.Image = global::PL.Properties.Resources.cancel1;
            this.button2.Location = new System.Drawing.Point(438, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 43);
            this.button2.TabIndex = 9;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::PL.Properties.Resources.search;
            this.btnSearch.Location = new System.Drawing.Point(376, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(56, 43);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(16, 26);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(29, 13);
            this.lblCriterio.TabIndex = 6;
            this.lblCriterio.Text = "label";
            // 
            // txtCriterioBusqueda
            // 
            this.txtCriterioBusqueda.Location = new System.Drawing.Point(85, 23);
            this.txtCriterioBusqueda.Name = "txtCriterioBusqueda";
            this.txtCriterioBusqueda.Size = new System.Drawing.Size(267, 20);
            this.txtCriterioBusqueda.TabIndex = 5;
            this.txtCriterioBusqueda.TextChanged += new System.EventHandler(this.txtCriterioBusqueda_TextChanged_1);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMensaje.Location = new System.Drawing.Point(12, 474);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(205, 13);
            this.lblMensaje.TabIndex = 2;
            this.lblMensaje.Text = "Click para seleccionar un producto";
            this.lblMensaje.Visible = false;
            // 
            // dgvProductOnlyActive
            // 
            this.dgvProductOnlyActive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductOnlyActive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductOnlyActive.Location = new System.Drawing.Point(12, 104);
            this.dgvProductOnlyActive.Name = "dgvProductOnlyActive";
            this.dgvProductOnlyActive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductOnlyActive.Size = new System.Drawing.Size(1053, 358);
            this.dgvProductOnlyActive.TabIndex = 3;
            this.dgvProductOnlyActive.Visible = false;
            this.dgvProductOnlyActive.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductOnlyActive_CellContentClick);
            // 
            // lblCostoAllProductos
            // 
            this.lblCostoAllProductos.AutoSize = true;
            this.lblCostoAllProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoAllProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblCostoAllProductos.Location = new System.Drawing.Point(801, 466);
            this.lblCostoAllProductos.Name = "lblCostoAllProductos";
            this.lblCostoAllProductos.Size = new System.Drawing.Size(79, 24);
            this.lblCostoAllProductos.TabIndex = 5;
            this.lblCostoAllProductos.Text = "Capital:";
            // 
            // lblCostoTotalProductRes
            // 
            this.lblCostoTotalProductRes.AutoSize = true;
            this.lblCostoTotalProductRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoTotalProductRes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblCostoTotalProductRes.Location = new System.Drawing.Point(886, 466);
            this.lblCostoTotalProductRes.Name = "lblCostoTotalProductRes";
            this.lblCostoTotalProductRes.Size = new System.Drawing.Size(162, 24);
            this.lblCostoTotalProductRes.TabIndex = 6;
            this.lblCostoTotalProductRes.Text = "Resultado Costo";
            // 
            // lblCantidadProdRes
            // 
            this.lblCantidadProdRes.AutoSize = true;
            this.lblCantidadProdRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadProdRes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCantidadProdRes.Location = new System.Drawing.Point(680, 466);
            this.lblCantidadProdRes.Name = "lblCantidadProdRes";
            this.lblCantidadProdRes.Size = new System.Drawing.Size(103, 24);
            this.lblCantidadProdRes.TabIndex = 8;
            this.lblCantidadProdRes.Text = "Resultado";
            // 
            // lblTotalProductos
            // 
            this.lblTotalProductos.AutoSize = true;
            this.lblTotalProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTotalProductos.Location = new System.Drawing.Point(488, 466);
            this.lblTotalProductos.Name = "lblTotalProductos";
            this.lblTotalProductos.Size = new System.Drawing.Size(186, 24);
            this.lblTotalProductos.TabIndex = 7;
            this.lblTotalProductos.Text = "Total de Unidades:";
            // 
            // frmConsultarProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 499);
            this.Controls.Add(this.lblCantidadProdRes);
            this.Controls.Add(this.lblTotalProductos);
            this.Controls.Add(this.lblCostoTotalProductRes);
            this.Controls.Add(this.lblCostoAllProductos);
            this.Controls.Add(this.dgvProductOnlyActive);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvProdConsultar);
            this.Name = "frmConsultarProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Productos";
            this.Load += new System.EventHandler(this.frmConsultarProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdConsultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductOnlyActive)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.TextBox txtCriterioBusqueda;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.DataGridView dgvProdConsultar;
        public System.Windows.Forms.Button btnExpExcel;
        public System.Windows.Forms.Label lblMensaje;
        public System.Windows.Forms.DataGridView dgvProductOnlyActive;
        public System.Windows.Forms.Label lblCostoTotalProductRes;
        public System.Windows.Forms.Label lblCostoAllProductos;
        public System.Windows.Forms.Label lblCantidadProdRes;
        public System.Windows.Forms.Label lblTotalProductos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDescripcion;
        private System.Windows.Forms.RadioButton rbCodigo;
    }
}