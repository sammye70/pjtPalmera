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
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCategory = new System.Windows.Forms.RadioButton();
            this.rbStatus = new System.Windows.Forms.RadioButton();
            this.rbDescription = new System.Windows.Forms.RadioButton();
            this.rbCodigo = new System.Windows.Forms.RadioButton();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEditarProd = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.txtCriterioBusqueda = new System.Windows.Forms.TextBox();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lblCostoAllProductos = new System.Windows.Forms.Label();
            this.lblCostoTotalProductRes = new System.Windows.Forms.Label();
            this.lblCantidadProdRes = new System.Windows.Forms.Label();
            this.lblTotalProductos = new System.Windows.Forms.Label();
            this.dgvProductOnlyActive = new System.Windows.Forms.DataGridView();
            this.txtIdUser = new System.Windows.Forms.TextBox();
            this.txtRol = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdConsultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductOnlyActive)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProdConsultar
            // 
            this.dgvProdConsultar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProdConsultar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdConsultar.Location = new System.Drawing.Point(12, 88);
            this.dgvProdConsultar.Name = "dgvProdConsultar";
            this.dgvProdConsultar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdConsultar.Size = new System.Drawing.Size(1144, 374);
            this.dgvProdConsultar.TabIndex = 0;
            this.dgvProdConsultar.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdConsultar_CellContentDoubleClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbCategories);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.cmbEstado);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.btnEditarProd);
            this.panel1.Controls.Add(this.btnRefrescar);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.lblCriterio);
            this.panel1.Controls.Add(this.txtCriterioBusqueda);
            this.panel1.Location = new System.Drawing.Point(11, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1140, 70);
            this.panel1.TabIndex = 1;
            // 
            // cmbCategories
            // 
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(96, 22);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(254, 21);
            this.cmbCategories.TabIndex = 69;
            this.cmbCategories.Visible = false;
            this.cmbCategories.DropDown += new System.EventHandler(this.cmbCategories_DropDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCategory);
            this.groupBox1.Controls.Add(this.rbStatus);
            this.groupBox1.Controls.Add(this.rbDescription);
            this.groupBox1.Controls.Add(this.rbCodigo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(657, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 56);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar por";
            // 
            // rbCategory
            // 
            this.rbCategory.AutoSize = true;
            this.rbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCategory.Location = new System.Drawing.Point(253, 24);
            this.rbCategory.Name = "rbCategory";
            this.rbCategory.Size = new System.Drawing.Size(103, 20);
            this.rbCategory.TabIndex = 65;
            this.rbCategory.Text = "CATEGORIA";
            this.rbCategory.UseVisualStyleBackColor = true;
            this.rbCategory.CheckedChanged += new System.EventHandler(this.rbCategory_CheckedChanged);
            // 
            // rbStatus
            // 
            this.rbStatus.AutoSize = true;
            this.rbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbStatus.Location = new System.Drawing.Point(379, 24);
            this.rbStatus.Name = "rbStatus";
            this.rbStatus.Size = new System.Drawing.Size(81, 20);
            this.rbStatus.TabIndex = 64;
            this.rbStatus.Text = "ESTADO";
            this.rbStatus.UseVisualStyleBackColor = true;
            this.rbStatus.CheckedChanged += new System.EventHandler(this.rbStatus_CheckedChanged);
            // 
            // rbDescription
            // 
            this.rbDescription.AutoSize = true;
            this.rbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDescription.Location = new System.Drawing.Point(113, 24);
            this.rbDescription.Name = "rbDescription";
            this.rbDescription.Size = new System.Drawing.Size(116, 20);
            this.rbDescription.TabIndex = 13;
            this.rbDescription.Text = "DESCRIPCION";
            this.rbDescription.UseVisualStyleBackColor = true;
            this.rbDescription.CheckedChanged += new System.EventHandler(this.rbDescription_CheckedChanged);
            // 
            // rbCodigo
            // 
            this.rbCodigo.AutoSize = true;
            this.rbCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCodigo.Location = new System.Drawing.Point(20, 24);
            this.rbCodigo.Name = "rbCodigo";
            this.rbCodigo.Size = new System.Drawing.Size(77, 20);
            this.rbCodigo.TabIndex = 12;
            this.rbCodigo.Text = "CODIGO";
            this.rbCodigo.UseVisualStyleBackColor = true;
            this.rbCodigo.CheckedChanged += new System.EventHandler(this.rbCodigo_CheckedChanged);
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(95, 22);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(144, 21);
            this.cmbEstado.TabIndex = 65;
            this.cmbEstado.Visible = false;
            this.cmbEstado.DropDown += new System.EventHandler(this.cmbEstado_DropDown);
            // 
            // btnRemove
            // 
            this.btnRemove.Image = global::PL.Properties.Resources.trash;
            this.btnRemove.Location = new System.Drawing.Point(513, 14);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(56, 43);
            this.btnRemove.TabIndex = 67;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEditarProd
            // 
            this.btnEditarProd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarProd.Image = global::PL.Properties.Resources.edit;
            this.btnEditarProd.Location = new System.Drawing.Point(442, 14);
            this.btnEditarProd.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditarProd.Name = "btnEditarProd";
            this.btnEditarProd.Size = new System.Drawing.Size(64, 42);
            this.btnEditarProd.TabIndex = 66;
            this.btnEditarProd.UseVisualStyleBackColor = true;
            this.btnEditarProd.Click += new System.EventHandler(this.btnEditarProd_Click);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Image = global::PL.Properties.Resources.refresh;
            this.btnRefrescar.Location = new System.Drawing.Point(575, 14);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(56, 43);
            this.btnRefrescar.TabIndex = 64;
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::PL.Properties.Resources.search;
            this.btnSearch.Location = new System.Drawing.Point(376, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(56, 43);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCriterio.Location = new System.Drawing.Point(16, 26);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(37, 16);
            this.lblCriterio.TabIndex = 6;
            this.lblCriterio.Text = "label";
            // 
            // txtCriterioBusqueda
            // 
            this.txtCriterioBusqueda.Location = new System.Drawing.Point(100, 23);
            this.txtCriterioBusqueda.Name = "txtCriterioBusqueda";
            this.txtCriterioBusqueda.Size = new System.Drawing.Size(267, 20);
            this.txtCriterioBusqueda.TabIndex = 5;
            this.txtCriterioBusqueda.TextChanged += new System.EventHandler(this.txtCriterioBusqueda_TextChanged_1);
            // 
            // lblMensaje
            // 
            this.lblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            // lblCostoAllProductos
            // 
            this.lblCostoAllProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.lblCostoTotalProductRes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.lblCantidadProdRes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.lblTotalProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalProductos.AutoSize = true;
            this.lblTotalProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTotalProductos.Location = new System.Drawing.Point(488, 466);
            this.lblTotalProductos.Name = "lblTotalProductos";
            this.lblTotalProductos.Size = new System.Drawing.Size(186, 24);
            this.lblTotalProductos.TabIndex = 7;
            this.lblTotalProductos.Text = "Total de Unidades:";
            // 
            // dgvProductOnlyActive
            // 
            this.dgvProductOnlyActive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductOnlyActive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductOnlyActive.Location = new System.Drawing.Point(11, 88);
            this.dgvProductOnlyActive.Name = "dgvProductOnlyActive";
            this.dgvProductOnlyActive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductOnlyActive.Size = new System.Drawing.Size(1144, 374);
            this.dgvProductOnlyActive.TabIndex = 3;
            this.dgvProductOnlyActive.Visible = false;
            this.dgvProductOnlyActive.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductOnlyActive_CellContentClick);
            // 
            // txtIdUser
            // 
            this.txtIdUser.Location = new System.Drawing.Point(277, 469);
            this.txtIdUser.Name = "txtIdUser";
            this.txtIdUser.Size = new System.Drawing.Size(100, 20);
            this.txtIdUser.TabIndex = 9;
            this.txtIdUser.Visible = false;
            // 
            // txtRol
            // 
            this.txtRol.Location = new System.Drawing.Point(387, 471);
            this.txtRol.Name = "txtRol";
            this.txtRol.Size = new System.Drawing.Size(100, 20);
            this.txtRol.TabIndex = 10;
            this.txtRol.Visible = false;
            // 
            // frmConsultarProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 499);
            this.Controls.Add(this.txtRol);
            this.Controls.Add(this.txtIdUser);
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
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.TextBox txtCriterioBusqueda;
        public System.Windows.Forms.DataGridView dgvProdConsultar;
        public System.Windows.Forms.Label lblMensaje;
        public System.Windows.Forms.Label lblCostoTotalProductRes;
        public System.Windows.Forms.Label lblCostoAllProductos;
        public System.Windows.Forms.Label lblCantidadProdRes;
        public System.Windows.Forms.Label lblTotalProductos;
        public System.Windows.Forms.Button btnEditarProd;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton rbStatus;
        public System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.Button btnRemove;
        public System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.ComboBox cmbEstado;
        public System.Windows.Forms.DataGridView dgvProductOnlyActive;
        public System.Windows.Forms.RadioButton rbDescription;
        public System.Windows.Forms.RadioButton rbCodigo;
        public System.Windows.Forms.RadioButton rbCategory;
        private System.Windows.Forms.ComboBox cmbCategories;
        public System.Windows.Forms.TextBox txtIdUser;
        public System.Windows.Forms.TextBox txtRol;
    }
}