namespace pjPalmera.PL
{
    partial class frmRegClientes
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.mktCedula = new System.Windows.Forms.MaskedTextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.cmbProvincia = new System.Windows.Forms.ComboBox();
            this.cmbCiudad = new System.Windows.Forms.ComboBox();
            this.mktTelefono = new System.Windows.Forms.MaskedTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnAgregarCiudad = new System.Windows.Forms.Button();
            this.btnAgregarProvincia = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cedula";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apellidos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Direccion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Provincia";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ciudad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(241, 274);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Telefono";
            // 
            // mktCedula
            // 
            this.mktCedula.Location = new System.Drawing.Point(63, 53);
            this.mktCedula.Name = "mktCedula";
            this.mktCedula.Size = new System.Drawing.Size(126, 20);
            this.mktCedula.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(63, 84);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(188, 20);
            this.txtNombre.TabIndex = 8;
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(63, 120);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(269, 20);
            this.txtApellidos.TabIndex = 9;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(64, 161);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(268, 51);
            this.txtDireccion.TabIndex = 10;
            // 
            // cmbProvincia
            // 
            this.cmbProvincia.AutoCompleteCustomSource.AddRange(new string[] {
            "1"});
            this.cmbProvincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbProvincia.FormattingEnabled = true;
            this.cmbProvincia.Items.AddRange(new object[] {
            "Azúa",
            "Baoruco ",
            "Barahona ",
            "Dajabón ",
            "Distrito Nacional",
            "Duarte ",
            "Elías Pina ",
            "El Seibo ",
            "Espaillat ",
            "Hato Mayor",
            "Independencia",
            "La Altagracia",
            "La Romana",
            "La Vega",
            "Maria Trinidad Sanchez",
            "Monseñor Nouel",
            "Monte Cristi",
            "Monte Plata",
            "Pedernales",
            "Peravia",
            "Puerto Plata",
            "Salcedo",
            "Samana",
            "Sánchez Ramírez",
            "San Cristobal",
            "San Jose de Ocoa",
            "San Juan",
            "San Pedro de Macorís",
            "Santiago",
            "Santiago Rodríguez",
            "Santo Domingo",
            "Valverde."});
            this.cmbProvincia.Location = new System.Drawing.Point(63, 234);
            this.cmbProvincia.Name = "cmbProvincia";
            this.cmbProvincia.Size = new System.Drawing.Size(227, 21);
            this.cmbProvincia.TabIndex = 11;
            // 
            // cmbCiudad
            // 
            this.cmbCiudad.FormattingEnabled = true;
            this.cmbCiudad.Location = new System.Drawing.Point(63, 271);
            this.cmbCiudad.Name = "cmbCiudad";
            this.cmbCiudad.Size = new System.Drawing.Size(139, 21);
            this.cmbCiudad.TabIndex = 13;
            // 
            // mktTelefono
            // 
            this.mktTelefono.Location = new System.Drawing.Point(295, 271);
            this.mktTelefono.Name = "mktTelefono";
            this.mktTelefono.Size = new System.Drawing.Size(114, 20);
            this.mktTelefono.TabIndex = 15;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PL.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(318, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::PL.Properties.Resources.cancel;
            this.btnCancelar.Location = new System.Drawing.Point(327, 331);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 40);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::PL.Properties.Resources.save;
            this.btnGuardar.Location = new System.Drawing.Point(244, 331);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 40);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::PL.Properties.Resources.documents;
            this.btnNuevo.Location = new System.Drawing.Point(158, 331);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 40);
            this.btnNuevo.TabIndex = 19;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnAgregarCiudad
            // 
            this.btnAgregarCiudad.Image = global::PL.Properties.Resources.add;
            this.btnAgregarCiudad.Location = new System.Drawing.Point(206, 266);
            this.btnAgregarCiudad.Name = "btnAgregarCiudad";
            this.btnAgregarCiudad.Size = new System.Drawing.Size(27, 28);
            this.btnAgregarCiudad.TabIndex = 14;
            this.btnAgregarCiudad.Text = "+";
            this.btnAgregarCiudad.UseVisualStyleBackColor = true;
            this.btnAgregarCiudad.Click += new System.EventHandler(this.btnAgregarCiudad_Click);
            // 
            // btnAgregarProvincia
            // 
            this.btnAgregarProvincia.Image = global::PL.Properties.Resources.add;
            this.btnAgregarProvincia.Location = new System.Drawing.Point(295, 229);
            this.btnAgregarProvincia.Name = "btnAgregarProvincia";
            this.btnAgregarProvincia.Size = new System.Drawing.Size(27, 28);
            this.btnAgregarProvincia.TabIndex = 12;
            this.btnAgregarProvincia.Text = "+";
            this.btnAgregarProvincia.UseVisualStyleBackColor = true;
            this.btnAgregarProvincia.Click += new System.EventHandler(this.btnAgregarProvincia_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(13, 311);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 10);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // frmRegClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 396);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.mktTelefono);
            this.Controls.Add(this.btnAgregarCiudad);
            this.Controls.Add(this.cmbCiudad);
            this.Controls.Add(this.btnAgregarProvincia);
            this.Controls.Add(this.cmbProvincia);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.mktCedula);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Clientes";
            this.Load += new System.EventHandler(this.frmRegClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox mktCedula;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.ComboBox cmbProvincia;
        private System.Windows.Forms.Button btnAgregarProvincia;
        private System.Windows.Forms.ComboBox cmbCiudad;
        private System.Windows.Forms.Button btnAgregarCiudad;
        private System.Windows.Forms.MaskedTextBox mktTelefono;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}