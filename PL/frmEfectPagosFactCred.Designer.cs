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
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdClient = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTarjeta = new System.Windows.Forms.RadioButton();
            this.rbEfectivo = new System.Windows.Forms.RadioButton();
            this.lblDevueltResult = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRecibidoEfectivo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBalenceResultados = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnSearchClient = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblNoFacturaRes = new System.Windows.Forms.Label();
            this.btnSearchInvoices = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtValorPago
            // 
            this.txtValorPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorPago.Location = new System.Drawing.Point(147, 173);
            this.txtValorPago.Multiline = true;
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.Size = new System.Drawing.Size(117, 39);
            this.txtValorPago.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 18);
            this.label2.TabIndex = 50;
            this.label2.Text = "Pago por Valor";
            // 
            // txtBalanceAfterPaid
            // 
            this.txtBalanceAfterPaid.Location = new System.Drawing.Point(372, 16);
            this.txtBalanceAfterPaid.Name = "txtBalanceAfterPaid";
            this.txtBalanceAfterPaid.Size = new System.Drawing.Size(79, 20);
            this.txtBalanceAfterPaid.TabIndex = 49;
            // 
            // txtIdRecibo
            // 
            this.txtIdRecibo.Location = new System.Drawing.Point(189, 14);
            this.txtIdRecibo.Name = "txtIdRecibo";
            this.txtIdRecibo.Size = new System.Drawing.Size(79, 20);
            this.txtIdRecibo.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(315, 39);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(76, 18);
            this.label7.TabIndex = 47;
            this.label7.Text = "Apellidos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(133, 39);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(68, 18);
            this.label6.TabIndex = 46;
            this.label6.Text = "Nombre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 39);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 45;
            this.label5.Text = "Codigo";
            // 
            // txtIdClient
            // 
            this.txtIdClient.Location = new System.Drawing.Point(23, 60);
            this.txtIdClient.Name = "txtIdClient";
            this.txtIdClient.Size = new System.Drawing.Size(79, 20);
            this.txtIdClient.TabIndex = 44;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.Image = global::PL.Properties.Resources.documents1;
            this.btnNuevo.Location = new System.Drawing.Point(545, 258);
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
            this.btnCobrar.Image = global::PL.Properties.Resources.money;
            this.btnCobrar.Location = new System.Drawing.Point(625, 258);
            this.btnCobrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(72, 53);
            this.btnCobrar.TabIndex = 42;
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTarjeta);
            this.groupBox1.Controls.Add(this.rbEfectivo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(307, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 51);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Método de Pago";
            // 
            // rbTarjeta
            // 
            this.rbTarjeta.AutoSize = true;
            this.rbTarjeta.Location = new System.Drawing.Point(111, 21);
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
            this.rbEfectivo.Location = new System.Drawing.Point(29, 19);
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
            this.lblDevueltResult.Location = new System.Drawing.Point(303, 239);
            this.lblDevueltResult.Name = "lblDevueltResult";
            this.lblDevueltResult.Size = new System.Drawing.Size(144, 24);
            this.lblDevueltResult.TabIndex = 40;
            this.lblDevueltResult.Text = "DevueltaResul";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(224, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 18);
            this.label4.TabIndex = 39;
            this.label4.Text = "Devuelta";
            // 
            // txtRecibidoEfectivo
            // 
            this.txtRecibidoEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecibidoEfectivo.Location = new System.Drawing.Point(100, 234);
            this.txtRecibidoEfectivo.Multiline = true;
            this.txtRecibidoEfectivo.Name = "txtRecibidoEfectivo";
            this.txtRecibidoEfectivo.Size = new System.Drawing.Size(100, 39);
            this.txtRecibidoEfectivo.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 18);
            this.label3.TabIndex = 37;
            this.label3.Text = "Recibido";
            // 
            // lblBalenceResultados
            // 
            this.lblBalenceResultados.AutoSize = true;
            this.lblBalenceResultados.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalenceResultados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBalenceResultados.Location = new System.Drawing.Point(478, 109);
            this.lblBalenceResultados.Name = "lblBalenceResultados";
            this.lblBalenceResultados.Size = new System.Drawing.Size(211, 24);
            this.lblBalenceResultados.TabIndex = 36;
            this.lblBalenceResultados.Text = "lblBalenceResultados";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(313, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 18);
            this.label1.TabIndex = 35;
            this.label1.Text = "Monto de la Factura";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(250, 60);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(244, 20);
            this.txtApellidos.TabIndex = 34;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(104, 60);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(145, 20);
            this.txtNombre.TabIndex = 33;
            // 
            // btnSearchClient
            // 
            this.btnSearchClient.Image = global::PL.Properties.Resources.search;
            this.btnSearchClient.Location = new System.Drawing.Point(512, 51);
            this.btnSearchClient.Name = "btnSearchClient";
            this.btnSearchClient.Size = new System.Drawing.Size(40, 37);
            this.btnSearchClient.TabIndex = 32;
            this.btnSearchClient.UseVisualStyleBackColor = true;
            this.btnSearchClient.Click += new System.EventHandler(this.btnSearchClient_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 18);
            this.label8.TabIndex = 52;
            this.label8.Text = "No. Factura";
            // 
            // lblNoFacturaRes
            // 
            this.lblNoFacturaRes.AutoSize = true;
            this.lblNoFacturaRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoFacturaRes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNoFacturaRes.Location = new System.Drawing.Point(123, 109);
            this.lblNoFacturaRes.Name = "lblNoFacturaRes";
            this.lblNoFacturaRes.Size = new System.Drawing.Size(143, 24);
            this.lblNoFacturaRes.TabIndex = 53;
            this.lblNoFacturaRes.Text = "NoFacturaRes";
            // 
            // btnSearchInvoices
            // 
            this.btnSearchInvoices.Image = global::PL.Properties.Resources.search;
            this.btnSearchInvoices.Location = new System.Drawing.Point(615, 105);
            this.btnSearchInvoices.Name = "btnSearchInvoices";
            this.btnSearchInvoices.Size = new System.Drawing.Size(40, 37);
            this.btnSearchInvoices.TabIndex = 54;
            this.btnSearchInvoices.UseVisualStyleBackColor = true;
            this.btnSearchInvoices.Click += new System.EventHandler(this.btnSearchInvoices_Click);
            // 
            // frmEfectPagosFactCred
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 318);
            this.Controls.Add(this.btnSearchInvoices);
            this.Controls.Add(this.lblNoFacturaRes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtValorPago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBalanceAfterPaid);
            this.Controls.Add(this.txtIdRecibo);
            this.Controls.Add(this.label7);
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
            this.Controls.Add(this.lblBalenceResultados);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnSearchClient);
            this.Name = "frmEfectPagosFactCred";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cobrar Facturas Creditos";
            this.Load += new System.EventHandler(this.frmEfectPagosFactCred_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValorPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBalanceAfterPaid;
        private System.Windows.Forms.TextBox txtIdRecibo;
        private System.Windows.Forms.Label label7;
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
        private System.Windows.Forms.Label lblBalenceResultados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnSearchClient;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblNoFacturaRes;
        private System.Windows.Forms.Button btnSearchInvoices;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.TextBox txtIdClient;
    }
}