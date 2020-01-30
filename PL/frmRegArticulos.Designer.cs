namespace pjPalmera.PL
{
    partial class frmRegArticulos
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblStockInicial = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblStockMinimo = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbFabrincante = new System.Windows.Forms.ComboBox();
            this.cmbFamilia = new System.Windows.Forms.ComboBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.txtStockInicial = new System.Windows.Forms.TextBox();
            this.txtStockMinimo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbEstanteLocalizacion = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddCategoria = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAddFabricante = new System.Windows.Forms.Button();
            this.btnUpdateFields = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbGanancia = new System.Windows.Forms.ComboBox();
            this.btnGenerarCodigo = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripcion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fabricante";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(465, 30);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(183, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(393, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Vencimiento";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(77, 77);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(207, 20);
            this.txtCodigo.TabIndex = 5;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(77, 116);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(426, 20);
            this.txtDescripcion.TabIndex = 6;
            // 
            // lblStockInicial
            // 
            this.lblStockInicial.AutoSize = true;
            this.lblStockInicial.Location = new System.Drawing.Point(419, 188);
            this.lblStockInicial.Name = "lblStockInicial";
            this.lblStockInicial.Size = new System.Drawing.Size(65, 13);
            this.lblStockInicial.TabIndex = 7;
            this.lblStockInicial.Text = "Stock Inicial";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Costo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(273, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Precio Venta";
            // 
            // lblStockMinimo
            // 
            this.lblStockMinimo.AutoSize = true;
            this.lblStockMinimo.Location = new System.Drawing.Point(543, 188);
            this.lblStockMinimo.Name = "lblStockMinimo";
            this.lblStockMinimo.Size = new System.Drawing.Size(71, 13);
            this.lblStockMinimo.TabIndex = 10;
            this.lblStockMinimo.Text = "Stock Minimo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(354, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Categoria";
            // 
            // cmbFabrincante
            // 
            this.cmbFabrincante.FormattingEnabled = true;
            this.cmbFabrincante.Location = new System.Drawing.Point(77, 147);
            this.cmbFabrincante.Name = "cmbFabrincante";
            this.cmbFabrincante.Size = new System.Drawing.Size(226, 21);
            this.cmbFabrincante.TabIndex = 12;
            // 
            // cmbFamilia
            // 
            this.cmbFamilia.FormattingEnabled = true;
            this.cmbFamilia.Location = new System.Drawing.Point(412, 147);
            this.cmbFamilia.Name = "cmbFamilia";
            this.cmbFamilia.Size = new System.Drawing.Size(221, 21);
            this.cmbFamilia.TabIndex = 13;
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(77, 185);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(71, 20);
            this.txtCosto.TabIndex = 14;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Location = new System.Drawing.Point(344, 185);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(71, 20);
            this.txtPrecioVenta.TabIndex = 15;
            // 
            // txtStockInicial
            // 
            this.txtStockInicial.Location = new System.Drawing.Point(490, 185);
            this.txtStockInicial.Name = "txtStockInicial";
            this.txtStockInicial.Size = new System.Drawing.Size(43, 20);
            this.txtStockInicial.TabIndex = 16;
            // 
            // txtStockMinimo
            // 
            this.txtStockMinimo.Location = new System.Drawing.Point(615, 185);
            this.txtStockMinimo.Name = "txtStockMinimo";
            this.txtStockMinimo.Size = new System.Drawing.Size(44, 20);
            this.txtStockMinimo.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(53, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Localizacion en el Estante";
            this.label10.Visible = false;
            // 
            // cmbEstanteLocalizacion
            // 
            this.cmbEstanteLocalizacion.FormattingEnabled = true;
            this.cmbEstanteLocalizacion.Location = new System.Drawing.Point(190, 28);
            this.cmbEstanteLocalizacion.Name = "cmbEstanteLocalizacion";
            this.cmbEstanteLocalizacion.Size = new System.Drawing.Size(77, 21);
            this.cmbEstanteLocalizacion.TabIndex = 22;
            this.cmbEstanteLocalizacion.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::PL.Properties.Resources.cancel;
            this.btnCancelar.Location = new System.Drawing.Point(582, 229);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 51);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::PL.Properties.Resources.save;
            this.btnGuardar.Location = new System.Drawing.Point(501, 229);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 51);
            this.btnGuardar.TabIndex = 19;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::PL.Properties.Resources.documents;
            this.btnNuevo.Location = new System.Drawing.Point(422, 229);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(73, 51);
            this.btnNuevo.TabIndex = 18;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(20, 213);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(638, 10);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // btnAddCategoria
            // 
            this.btnAddCategoria.Image = global::PL.Properties.Resources.add;
            this.btnAddCategoria.Location = new System.Drawing.Point(635, 145);
            this.btnAddCategoria.Name = "btnAddCategoria";
            this.btnAddCategoria.Size = new System.Drawing.Size(27, 28);
            this.btnAddCategoria.TabIndex = 24;
            this.btnAddCategoria.Text = "+";
            this.btnAddCategoria.UseVisualStyleBackColor = true;
            this.btnAddCategoria.Click += new System.EventHandler(this.btnAgregarCategoria_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnAddFabricante
            // 
            this.btnAddFabricante.Image = global::PL.Properties.Resources.add;
            this.btnAddFabricante.Location = new System.Drawing.Point(304, 145);
            this.btnAddFabricante.Name = "btnAddFabricante";
            this.btnAddFabricante.Size = new System.Drawing.Size(27, 28);
            this.btnAddFabricante.TabIndex = 25;
            this.btnAddFabricante.Text = "+";
            this.btnAddFabricante.UseVisualStyleBackColor = true;
            this.btnAddFabricante.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUpdateFields
            // 
            this.btnUpdateFields.Image = global::PL.Properties.Resources.save;
            this.btnUpdateFields.Location = new System.Drawing.Point(500, 230);
            this.btnUpdateFields.Name = "btnUpdateFields";
            this.btnUpdateFields.Size = new System.Drawing.Size(75, 51);
            this.btnUpdateFields.TabIndex = 26;
            this.btnUpdateFields.UseVisualStyleBackColor = true;
            this.btnUpdateFields.Click += new System.EventHandler(this.btnUpdateFields_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Ganancia (%)";
            // 
            // cmbGanancia
            // 
            this.cmbGanancia.FormattingEnabled = true;
            this.cmbGanancia.Location = new System.Drawing.Point(223, 184);
            this.cmbGanancia.Name = "cmbGanancia";
            this.cmbGanancia.Size = new System.Drawing.Size(44, 21);
            this.cmbGanancia.TabIndex = 28;
            this.cmbGanancia.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnGenerarCodigo
            // 
            this.btnGenerarCodigo.Location = new System.Drawing.Point(290, 77);
            this.btnGenerarCodigo.Name = "btnGenerarCodigo";
            this.btnGenerarCodigo.Size = new System.Drawing.Size(95, 23);
            this.btnGenerarCodigo.TabIndex = 29;
            this.btnGenerarCodigo.Text = "Generar Código";
            this.btnGenerarCodigo.UseVisualStyleBackColor = true;
            this.btnGenerarCodigo.Click += new System.EventHandler(this.btnGenerarCodigo_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "label8";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(419, 84);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 31;
            this.lblEstado.Text = "Estado";
            this.lblEstado.Visible = false;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(475, 77);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(121, 21);
            this.cmbEstado.TabIndex = 32;
            this.cmbEstado.Visible = false;
            // 
            // frmRegArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 292);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnGenerarCodigo);
            this.Controls.Add(this.cmbGanancia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnUpdateFields);
            this.Controls.Add(this.btnAddFabricante);
            this.Controls.Add(this.btnAddCategoria);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbEstanteLocalizacion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.txtStockMinimo);
            this.Controls.Add(this.txtStockInicial);
            this.Controls.Add(this.txtPrecioVenta);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.cmbFamilia);
            this.Controls.Add(this.cmbFabrincante);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblStockMinimo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblStockInicial);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmRegArticulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Articulos";
            this.Load += new System.EventHandler(this.frmRegArticulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddCategoria;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnAddFabricante;
        public System.Windows.Forms.Label lblStockInicial;
        public System.Windows.Forms.Label lblStockMinimo;
        public System.Windows.Forms.TextBox txtStockInicial;
        public System.Windows.Forms.TextBox txtStockMinimo;
        public System.Windows.Forms.Button btnUpdateFields;
        public System.Windows.Forms.Button btnNuevo;
        public System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.TextBox txtCodigo;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.TextBox txtDescripcion;
        public System.Windows.Forms.ComboBox cmbFabrincante;
        public System.Windows.Forms.ComboBox cmbFamilia;
        public System.Windows.Forms.TextBox txtCosto;
        public System.Windows.Forms.TextBox txtPrecioVenta;
        public System.Windows.Forms.ComboBox cmbEstanteLocalizacion;
        private System.Windows.Forms.ComboBox cmbGanancia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGenerarCodigo;
        public System.Windows.Forms.ComboBox cmbEstado;
        public System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label label8;
    }
}