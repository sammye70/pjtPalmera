namespace pjPalmera.PL
{
    partial class frmRegUsers
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
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtRetPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPrivileges = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbSecretQuestion1 = new System.Windows.Forms.ComboBox();
            this.txtSecretAnswer1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtidUser = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPassLength = new System.Windows.Forms.Label();
            this.lblRescPassLength = new System.Windows.Forms.Label();
            this.lblRescPassDiferent = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnNuevo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtUserIdMod = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 93;
            this.label1.Text = "Nombre de Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 94;
            this.label2.Text = "Contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 95;
            this.label3.Text = "Confirmar Contraseña";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(194, 185);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(145, 20);
            this.txtUsername.TabIndex = 96;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(194, 218);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(238, 20);
            this.txtPassword.TabIndex = 97;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // txtRetPassword
            // 
            this.txtRetPassword.Location = new System.Drawing.Point(194, 251);
            this.txtRetPassword.Name = "txtRetPassword";
            this.txtRetPassword.PasswordChar = '*';
            this.txtRetPassword.Size = new System.Drawing.Size(238, 20);
            this.txtRetPassword.TabIndex = 98;
            this.txtRetPassword.TextChanged += new System.EventHandler(this.txtRetPassword_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 99;
            this.label4.Text = "Tipo de Usuario";
            // 
            // cmbPrivileges
            // 
            this.cmbPrivileges.FormattingEnabled = true;
            this.cmbPrivileges.Location = new System.Drawing.Point(194, 295);
            this.cmbPrivileges.Name = "cmbPrivileges";
            this.cmbPrivileges.Size = new System.Drawing.Size(128, 21);
            this.cmbPrivileges.TabIndex = 100;
            this.cmbPrivileges.DropDown += new System.EventHandler(this.cmbPrivileges_DropDown);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(190, 51);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(205, 24);
            this.lblTitle.TabIndex = 102;
            this.lblTitle.Text = "Crear Nuevo Usuario";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbSecretQuestion1);
            this.groupBox1.Controls.Add(this.txtSecretAnswer1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(38, 344);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(549, 130);
            this.groupBox1.TabIndex = 107;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preguntas de Seguridad para Recuperación de la Contraseña";
            // 
            // cmbSecretQuestion1
            // 
            this.cmbSecretQuestion1.FormattingEnabled = true;
            this.cmbSecretQuestion1.Location = new System.Drawing.Point(141, 47);
            this.cmbSecretQuestion1.Name = "cmbSecretQuestion1";
            this.cmbSecretQuestion1.Size = new System.Drawing.Size(382, 21);
            this.cmbSecretQuestion1.TabIndex = 121;
            this.cmbSecretQuestion1.DropDown += new System.EventHandler(this.cmbSecretQuestion1_DropDown);
            // 
            // txtSecretAnswer1
            // 
            this.txtSecretAnswer1.Location = new System.Drawing.Point(188, 84);
            this.txtSecretAnswer1.Name = "txtSecretAnswer1";
            this.txtSecretAnswer1.PasswordChar = '*';
            this.txtSecretAnswer1.Size = new System.Drawing.Size(335, 20);
            this.txtSecretAnswer1.TabIndex = 110;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 13);
            this.label6.TabIndex = 109;
            this.label6.Text = "Respuesta a la Pregunta Secreta 1:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 107;
            this.label5.Text = "Pregunta Secreta 1:";
            // 
            // txtidUser
            // 
            this.txtidUser.Location = new System.Drawing.Point(68, 510);
            this.txtidUser.Name = "txtidUser";
            this.txtidUser.Size = new System.Drawing.Size(100, 20);
            this.txtidUser.TabIndex = 108;
            this.txtidUser.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(38, 481);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(549, 14);
            this.groupBox2.TabIndex = 111;
            this.groupBox2.TabStop = false;
            // 
            // lblPassLength
            // 
            this.lblPassLength.AutoSize = true;
            this.lblPassLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassLength.Location = new System.Drawing.Point(438, 221);
            this.lblPassLength.Name = "lblPassLength";
            this.lblPassLength.Size = new System.Drawing.Size(73, 13);
            this.lblPassLength.TabIndex = 112;
            this.lblPassLength.Text = "PassLength";
            // 
            // lblRescPassLength
            // 
            this.lblRescPassLength.AutoSize = true;
            this.lblRescPassLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRescPassLength.Location = new System.Drawing.Point(437, 253);
            this.lblRescPassLength.Name = "lblRescPassLength";
            this.lblRescPassLength.Size = new System.Drawing.Size(102, 13);
            this.lblRescPassLength.TabIndex = 114;
            this.lblRescPassLength.Text = "RescPassLength";
            // 
            // lblRescPassDiferent
            // 
            this.lblRescPassDiferent.AutoSize = true;
            this.lblRescPassDiferent.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRescPassDiferent.Location = new System.Drawing.Point(224, 274);
            this.lblRescPassDiferent.Name = "lblRescPassDiferent";
            this.lblRescPassDiferent.Size = new System.Drawing.Size(97, 12);
            this.lblRescPassDiferent.TabIndex = 116;
            this.lblRescPassDiferent.Text = "RescPassDiferent";
            this.lblRescPassDiferent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(194, 150);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(238, 20);
            this.txtLastName.TabIndex = 120;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(194, 117);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(145, 20);
            this.txtFirstName.TabIndex = 119;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(40, 151);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(58, 13);
            this.lblLastName.TabIndex = 118;
            this.lblLastName.Text = "Apellidos";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(40, 120);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(50, 13);
            this.lblFirstName.TabIndex = 117;
            this.lblFirstName.Text = "Nombre";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::PL.Properties.Resources.documents;
            this.btnNuevo.Location = new System.Drawing.Point(377, 501);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(58, 54);
            this.btnNuevo.TabIndex = 90;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PL.Properties.Resources.Administrator_icon;
            this.pictureBox1.Location = new System.Drawing.Point(467, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 101;
            this.pictureBox1.TabStop = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::PL.Properties.Resources.save;
            this.btnGuardar.Location = new System.Drawing.Point(441, 500);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(58, 54);
            this.btnGuardar.TabIndex = 91;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtUserIdMod
            // 
            this.txtUserIdMod.Location = new System.Drawing.Point(221, 501);
            this.txtUserIdMod.Name = "txtUserIdMod";
            this.txtUserIdMod.Size = new System.Drawing.Size(100, 20);
            this.txtUserIdMod.TabIndex = 121;
            this.txtUserIdMod.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = global::PL.Properties.Resources.save;
            this.btnUpdate.Location = new System.Drawing.Point(442, 501);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(58, 54);
            this.btnUpdate.TabIndex = 122;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frmRegUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 567);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtUserIdMod);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtidUser);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblRescPassDiferent);
            this.Controls.Add(this.lblRescPassLength);
            this.Controls.Add(this.lblPassLength);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmbPrivileges);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRetPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGuardar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Cuenta de Usuario";
            this.Load += new System.EventHandler(this.frmRegUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtRetPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPrivileges;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSecretAnswer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblRescPassDiferent;
        private System.Windows.Forms.Label lblRescPassLength;
        private System.Windows.Forms.Label lblPassLength;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cmbSecretQuestion1;
        public System.Windows.Forms.TextBox txtidUser;
        public System.Windows.Forms.TextBox txtUserIdMod;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.TextBox txtUsername;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.TextBox txtLastName;
        public System.Windows.Forms.TextBox txtFirstName;
        public System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.Button btnNuevo;
    }
}