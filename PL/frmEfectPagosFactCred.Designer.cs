namespace pjPalmera.PL
{
    partial class frmEfectPagosFactCred
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
            this.txtValorPago = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBalanceAfterPaid = new System.Windows.Forms.TextBox();
            this.txtIdRecibo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdClient = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTarjeta = new System.Windows.Forms.RadioButton();
            this.rbEfectivo = new System.Windows.Forms.RadioButton();
            this.lblDevueltResult = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRecibidoEfectivo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblNoFacturaRes = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblBalenceResultados = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtPermissions = new System.Windows.Forms.TextBox();
            this.txtBalanceBeforePaid = new System.Windows.Forms.TextBox();
            this.idUser = new System.Windows.Forms.TextBox();
            this.txtUserLong = new System.Windows.Forms.TextBox();
            this.txtIdUser = new System.Windows.Forms.TextBox();
            this.txtIdAccount = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSearchInvoices = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.btnSearchClient = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtValorPago
            // 
            this.txtValorPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorPago.Location = new System.Drawing.Point(176, 128);
            this.txtValorPago.Multiline = true;
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.Size = new System.Drawing.Size(117, 39);
            this.txtValorPago.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 18);
            this.label2.TabIndex = 50;
            this.label2.Text = "Pago por Valor";
            // 
            // txtBalanceAfterPaid
            // 
            this.txtBalanceAfterPaid.Location = new System.Drawing.Point(564, 27);
            this.txtBalanceAfterPaid.Name = "txtBalanceAfterPaid";
            this.txtBalanceAfterPaid.Size = new System.Drawing.Size(79, 20);
            this.txtBalanceAfterPaid.TabIndex = 49;
            this.txtBalanceAfterPaid.Visible = false;
            // 
            // txtIdRecibo
            // 
            this.txtIdRecibo.Location = new System.Drawing.Point(658, 27);
            this.txtIdRecibo.Name = "txtIdRecibo";
            this.txtIdRecibo.Size = new System.Drawing.Size(79, 20);
            this.txtIdRecibo.TabIndex = 48;
            this.txtIdRecibo.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(264, 66);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(60, 18);
            this.label6.TabIndex = 46;
            this.label6.Text = "Cliente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(159, 66);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 45;
            this.label5.Text = "Codigo";
            // 
            // txtIdClient
            // 
            this.txtIdClient.Location = new System.Drawing.Point(154, 87);
            this.txtIdClient.Name = "txtIdClient";
            this.txtIdClient.Size = new System.Drawing.Size(79, 20);
            this.txtIdClient.TabIndex = 44;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTarjeta);
            this.groupBox1.Controls.Add(this.rbEfectivo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(389, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 49);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Método de Pago";
            // 
            // rbTarjeta
            // 
            this.rbTarjeta.AutoSize = true;
            this.rbTarjeta.Location = new System.Drawing.Point(128, 21);
            this.rbTarjeta.Name = "rbTarjeta";
            this.rbTarjeta.Size = new System.Drawing.Size(76, 20);
            this.rbTarjeta.TabIndex = 1;
            this.rbTarjeta.TabStop = true;
            this.rbTarjeta.Text = "Tarjeta";
            this.rbTarjeta.UseVisualStyleBackColor = true;
            // 
            // rbEfectivo
            // 
            this.rbEfectivo.AutoSize = true;
            this.rbEfectivo.Location = new System.Drawing.Point(29, 21);
            this.rbEfectivo.Name = "rbEfectivo";
            this.rbEfectivo.Size = new System.Drawing.Size(82, 20);
            this.rbEfectivo.TabIndex = 0;
            this.rbEfectivo.TabStop = true;
            this.rbEfectivo.Text = "Efectivo";
            this.rbEfectivo.UseVisualStyleBackColor = true;
            // 
            // lblDevueltResult
            // 
            this.lblDevueltResult.AutoSize = true;
            this.lblDevueltResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevueltResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDevueltResult.Location = new System.Drawing.Point(332, 187);
            this.lblDevueltResult.Name = "lblDevueltResult";
            this.lblDevueltResult.Size = new System.Drawing.Size(144, 24);
            this.lblDevueltResult.TabIndex = 40;
            this.lblDevueltResult.Text = "DevueltaResul";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(253, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 18);
            this.label4.TabIndex = 39;
            this.label4.Text = "Devuelta";
            // 
            // txtRecibidoEfectivo
            // 
            this.txtRecibidoEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecibidoEfectivo.Location = new System.Drawing.Point(129, 181);
            this.txtRecibidoEfectivo.Multiline = true;
            this.txtRecibidoEfectivo.Name = "txtRecibidoEfectivo";
            this.txtRecibidoEfectivo.Size = new System.Drawing.Size(100, 39);
            this.txtRecibidoEfectivo.TabIndex = 38;
            this.txtRecibidoEfectivo.TextChanged += new System.EventHandler(this.txtRecibidoEfectivo_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 18);
            this.label3.TabIndex = 37;
            this.label3.Text = "Recibido";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(235, 87);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(401, 20);
            this.txtCliente.TabIndex = 33;
            // 
            // lblNoFacturaRes
            // 
            this.lblNoFacturaRes.AutoSize = true;
            this.lblNoFacturaRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoFacturaRes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNoFacturaRes.Location = new System.Drawing.Point(128, 226);
            this.lblNoFacturaRes.Name = "lblNoFacturaRes";
            this.lblNoFacturaRes.Size = new System.Drawing.Size(143, 24);
            this.lblNoFacturaRes.TabIndex = 58;
            this.lblNoFacturaRes.Text = "NoFacturaRes";
            this.lblNoFacturaRes.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(25, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 18);
            this.label8.TabIndex = 57;
            this.label8.Text = "No. Factura";
            this.label8.Visible = false;
            // 
            // lblBalenceResultados
            // 
            this.lblBalenceResultados.AutoSize = true;
            this.lblBalenceResultados.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalenceResultados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBalenceResultados.Location = new System.Drawing.Point(201, 248);
            this.lblBalenceResultados.Name = "lblBalenceResultados";
            this.lblBalenceResultados.Size = new System.Drawing.Size(211, 24);
            this.lblBalenceResultados.TabIndex = 56;
            this.lblBalenceResultados.Text = "lblBalenceResultados";
            this.lblBalenceResultados.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 18);
            this.label1.TabIndex = 55;
            this.label1.Text = "Monto de la Factura";
            this.label1.Visible = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(227, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(293, 29);
            this.lblTitle.TabIndex = 61;
            this.lblTitle.Text = "Cobrar Ventas a Crédito";
            // 
            // txtPermissions
            // 
            this.txtPermissions.Location = new System.Drawing.Point(658, 53);
            this.txtPermissions.Name = "txtPermissions";
            this.txtPermissions.Size = new System.Drawing.Size(79, 20);
            this.txtPermissions.TabIndex = 62;
            this.txtPermissions.Visible = false;
            // 
            // txtBalanceBeforePaid
            // 
            this.txtBalanceBeforePaid.Location = new System.Drawing.Point(564, 52);
            this.txtBalanceBeforePaid.Name = "txtBalanceBeforePaid";
            this.txtBalanceBeforePaid.Size = new System.Drawing.Size(79, 20);
            this.txtBalanceBeforePaid.TabIndex = 63;
            this.txtBalanceBeforePaid.Visible = false;
            // 
            // idUser
            // 
            this.idUser.Location = new System.Drawing.Point(479, 53);
            this.idUser.Name = "idUser";
            this.idUser.Size = new System.Drawing.Size(79, 20);
            this.idUser.TabIndex = 64;
            this.idUser.Visible = false;
            // 
            // txtUserLong
            // 
            this.txtUserLong.Location = new System.Drawing.Point(658, 128);
            this.txtUserLong.Name = "txtUserLong";
            this.txtUserLong.Size = new System.Drawing.Size(79, 20);
            this.txtUserLong.TabIndex = 65;
            this.txtUserLong.Visible = false;
            // 
            // txtIdUser
            // 
            this.txtIdUser.Location = new System.Drawing.Point(658, 157);
            this.txtIdUser.Name = "txtIdUser";
            this.txtIdUser.Size = new System.Drawing.Size(79, 20);
            this.txtIdUser.TabIndex = 66;
            this.txtIdUser.Visible = false;
            // 
            // txtIdAccount
            // 
            this.txtIdAccount.Location = new System.Drawing.Point(560, 111);
            this.txtIdAccount.Name = "txtIdAccount";
            this.txtIdAccount.Size = new System.Drawing.Size(79, 20);
            this.txtIdAccount.TabIndex = 67;
            this.txtIdAccount.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PL.Properties.Resources.cash_icon;
            this.pictureBox1.Location = new System.Drawing.Point(12, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 68;
            this.pictureBox1.TabStop = false;
            // 
            // btnSearchInvoices
            // 
            this.btnSearchInvoices.Image = global::PL.Properties.Resources.search;
            this.btnSearchInvoices.Location = new System.Drawing.Point(439, 246);
            this.btnSearchInvoices.Name = "btnSearchInvoices";
            this.btnSearchInvoices.Size = new System.Drawing.Size(40, 37);
            this.btnSearchInvoices.TabIndex = 59;
            this.btnSearchInvoices.UseVisualStyleBackColor = true;
            this.btnSearchInvoices.Visible = false;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.Image = global::PL.Properties.Resources.documents1;
            this.btnNuevo.Location = new System.Drawing.Point(559, 191);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(72, 53);
            this.btnNuevo.TabIndex = 43;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCobrar
            // 
            this.btnCobrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCobrar.Image = global::PL.Properties.Resources.coins_money;
            this.btnCobrar.Location = new System.Drawing.Point(639, 191);
            this.btnCobrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(72, 53);
            this.btnCobrar.TabIndex = 42;
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // btnSearchClient
            // 
            this.btnSearchClient.Image = global::PL.Properties.Resources.search;
            this.btnSearchClient.Location = new System.Drawing.Point(642, 78);
            this.btnSearchClient.Name = "btnSearchClient";
            this.btnSearchClient.Size = new System.Drawing.Size(40, 37);
            this.btnSearchClient.TabIndex = 32;
            this.btnSearchClient.UseVisualStyleBackColor = true;
            this.btnSearchClient.Click += new System.EventHandler(this.btnSearchClient_Click);
            // 
            // frmEfectPagosFactCred
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 300);
            this.Controls.Add(this.txtIdAccount);
            this.Controls.Add(this.txtIdUser);
            this.Controls.Add(this.txtUserLong);
            this.Controls.Add(this.idUser);
            this.Controls.Add(this.txtBalanceBeforePaid);
            this.Controls.Add(this.txtPermissions);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSearchInvoices);
            this.Controls.Add(this.lblNoFacturaRes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblBalenceResultados);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValorPago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBalanceAfterPaid);
            this.Controls.Add(this.txtIdRecibo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtIdClient);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnCobrar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblDevueltResult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRecibidoEfectivo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.btnSearchClient);
            this.Name = "frmEfectPagosFactCred";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cobrar Ventas a  Créditos";
            this.Load += new System.EventHandler(this.frmEfectPagosFactCred_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValorPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbTarjeta;
        private System.Windows.Forms.RadioButton rbEfectivo;
        private System.Windows.Forms.Label lblDevueltResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRecibidoEfectivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnSearchClient;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.TextBox txtIdClient;
        private System.Windows.Forms.Button btnSearchInvoices;
        private System.Windows.Forms.Label lblNoFacturaRes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblBalenceResultados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.TextBox txtBalanceAfterPaid;
        public System.Windows.Forms.TextBox txtIdRecibo;
        public System.Windows.Forms.TextBox txtPermissions;
        public System.Windows.Forms.TextBox txtBalanceBeforePaid;
        public System.Windows.Forms.TextBox idUser;
        public System.Windows.Forms.TextBox txtUserLong;
        public System.Windows.Forms.TextBox txtIdUser;
        public System.Windows.Forms.TextBox txtIdAccount;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}