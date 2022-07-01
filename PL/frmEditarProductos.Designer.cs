namespace pjPalmera.PL
{
    partial class frmEditarProductos
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
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnEditarProd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbEstado = new System.Windows.Forms.RadioButton();
            this.rdbDescription = new System.Windows.Forms.RadioButton();
            this.rdbCodigo = new System.Windows.Forms.RadioButton();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.txtCriterioBusqueda = new System.Windows.Forms.TextBox();
            this.lblMensaje = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdConsultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProdConsultar
            // 
            this.dgvProdConsultar.AllowUserToDeleteRows = false;
            this.dgvProdConsultar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProdConsultar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdConsultar.Location = new System.Drawing.Point(10, 129);
            this.dgvProdConsultar.Name = "dgvProdConsultar";
            this.dgvProdConsultar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdConsultar.Size = new System.Drawing.Size(1075, 335);
            this.dgvProdConsultar.TabIndex = 2;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cmbEstado);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnEditarProd);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnRefrescar);
            this.panel1.Controls.Add(this.lblCriterio);
            this.panel1.Controls.Add(this.txtCriterioBusqueda);
            this.panel1.Location = new System.Drawing.Point(10, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1075, 93);
            this.panel1.TabIndex = 3;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbEstado.Location = new System.Drawing.Point(114, 38);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(144, 21);
            this.cmbEstado.TabIndex = 64;
            this.cmbEstado.SelectedIndexChanged += new System.EventHandler(this.cmbEstado_SelectedIndexChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.Image = global::PL.Properties.Resources.trash;
            this.btnRemove.Location = new System.Drawing.Point(915, 24);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(56, 43);
            this.btnRemove.TabIndex = 63;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSearch.Image = global::PL.Properties.Resources.search;
            this.btnSearch.Location = new System.Drawing.Point(399, 27);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(42, 37);
            this.btnSearch.TabIndex = 62;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnEditarProd
            // 
            this.btnEditarProd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarProd.Image = global::PL.Properties.Resources.edit;
            this.btnEditarProd.Location = new System.Drawing.Point(840, 24);
            this.btnEditarProd.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditarProd.Name = "btnEditarProd";
            this.btnEditarProd.Size = new System.Drawing.Size(64, 42);
            this.btnEditarProd.TabIndex = 52;
            this.btnEditarProd.UseVisualStyleBackColor = true;
            this.btnEditarProd.Click += new System.EventHandler(this.btnEditarProd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbEstado);
            this.groupBox1.Controls.Add(this.rdbDescription);
            this.groupBox1.Controls.Add(this.rdbCodigo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(465, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 64);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar por";
            // 
            // rdbEstado
            // 
            this.rdbEstado.AutoSize = true;
            this.rdbEstado.Location = new System.Drawing.Point(249, 23);
            this.rdbEstado.Name = "rdbEstado";
            this.rdbEstado.Size = new System.Drawing.Size(82, 20);
            this.rdbEstado.TabIndex = 64;
            this.rdbEstado.Text = "ESTADO";
            this.rdbEstado.UseVisualStyleBackColor = true;
            this.rdbEstado.CheckedChanged += new System.EventHandler(this.rdEstado_CheckedChanged);
            // 
            // rdbDescription
            // 
            this.rdbDescription.AutoSize = true;
            this.rdbDescription.Location = new System.Drawing.Point(113, 24);
            this.rdbDescription.Name = "rdbDescription";
            this.rdbDescription.Size = new System.Drawing.Size(117, 20);
            this.rdbDescription.TabIndex = 13;
            this.rdbDescription.Text = "DESCRIPCION";
            this.rdbDescription.UseVisualStyleBackColor = true;
            this.rdbDescription.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rdbCodigo
            // 
            this.rdbCodigo.AutoSize = true;
            this.rdbCodigo.Location = new System.Drawing.Point(20, 24);
            this.rdbCodigo.Name = "rdbCodigo";
            this.rdbCodigo.Size = new System.Drawing.Size(78, 20);
            this.rdbCodigo.TabIndex = 12;
            this.rdbCodigo.Text = "CODIGO";
            this.rdbCodigo.UseVisualStyleBackColor = true;
            this.rdbCodigo.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::PL.Properties.Resources.trash;
            this.btnEliminar.Location = new System.Drawing.Point(842, 24);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(56, 43);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Image = global::PL.Properties.Resources.refresh;
            this.btnRefrescar.Location = new System.Drawing.Point(977, 23);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(56, 43);
            this.btnRefrescar.TabIndex = 8;
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCriterio.Location = new System.Drawing.Point(20, 39);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(80, 16);
            this.lblCriterio.TabIndex = 6;
            this.lblCriterio.Text = "Descripcion";
            // 
            // txtCriterioBusqueda
            // 
            this.txtCriterioBusqueda.Location = new System.Drawing.Point(122, 37);
            this.txtCriterioBusqueda.Name = "txtCriterioBusqueda";
            this.txtCriterioBusqueda.Size = new System.Drawing.Size(267, 20);
            this.txtCriterioBusqueda.TabIndex = 5;
            this.txtCriterioBusqueda.TextChanged += new System.EventHandler(this.txtCriterioBusqueda_TextChanged);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMensaje.Location = new System.Drawing.Point(3, 469);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(737, 13);
            this.lblMensaje.TabIndex = 4;
            this.lblMensaje.Text = "Indicar como buscar (Código, Descripción), por Estado(Activo, Inactivo). Luego Se" +
    "leccionar y  después presionar el botón Editar";
            // 
            // frmEditarProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 488);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.dgvProdConsultar);
            this.Controls.Add(this.panel1);
            this.Name = "frmEditarProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Productos";
            this.Load += new System.EventHandler(this.frmEditarProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdConsultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.TextBox txtCriterioBusqueda;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbDescription;
        private System.Windows.Forms.RadioButton rdbCodigo;
        public System.Windows.Forms.Button btnEditarProd;
        public System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.DataGridView dgvProdConsultar;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.RadioButton rdbEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
    }
}