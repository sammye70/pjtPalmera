namespace pjPalmera.PL
{
    partial class frmCobros
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
            this.btnCancelarPago = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEfectivoRecibido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDevueltaEfectivo = new System.Windows.Forms.TextBox();
            this.btnProcesarPagos = new System.Windows.Forms.Button();
            this.lblTitleTotalCobrar = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmbfPagos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDevueltaEfectivo = new System.Windows.Forms.Label();
            this.lblAprobacion = new System.Windows.Forms.Label();
            this.txtAprobacionNo = new System.Windows.Forms.TextBox();
            this.lblTotalCobrar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelarPago
            // 
            this.btnCancelarPago.Image = global::PL.Properties.Resources.cancel;
            this.btnCancelarPago.Location = new System.Drawing.Point(194, 294);
            this.btnCancelarPago.Name = "btnCancelarPago";
            this.btnCancelarPago.Size = new System.Drawing.Size(75, 59);
            this.btnCancelarPago.TabIndex = 1;
            this.btnCancelarPago.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelarPago.UseVisualStyleBackColor = true;
            this.btnCancelarPago.Click += new System.EventHandler(this.btnCancelarPago_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Recibido";
            // 
            // txtEfectivoRecibido
            // 
            this.txtEfectivoRecibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivoRecibido.Location = new System.Drawing.Point(219, 87);
            this.txtEfectivoRecibido.Multiline = true;
            this.txtEfectivoRecibido.Name = "txtEfectivoRecibido";
            this.txtEfectivoRecibido.Size = new System.Drawing.Size(146, 46);
            this.txtEfectivoRecibido.TabIndex = 5;
            this.txtEfectivoRecibido.TextChanged += new System.EventHandler(this.txtEfectivoRecibido_TextChanged);
            this.txtEfectivoRecibido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEfectivoRecibido_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Devuelta";
            // 
            // txtDevueltaEfectivo
            // 
            this.txtDevueltaEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDevueltaEfectivo.Location = new System.Drawing.Point(220, 148);
            this.txtDevueltaEfectivo.Multiline = true;
            this.txtDevueltaEfectivo.Name = "txtDevueltaEfectivo";
            this.txtDevueltaEfectivo.Size = new System.Drawing.Size(146, 46);
            this.txtDevueltaEfectivo.TabIndex = 7;
            this.txtDevueltaEfectivo.Visible = false;
            // 
            // btnProcesarPagos
            // 
            this.btnProcesarPagos.Image = global::PL.Properties.Resources.apply;
            this.btnProcesarPagos.Location = new System.Drawing.Point(101, 294);
            this.btnProcesarPagos.Name = "btnProcesarPagos";
            this.btnProcesarPagos.Size = new System.Drawing.Size(75, 59);
            this.btnProcesarPagos.TabIndex = 0;
            this.btnProcesarPagos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesarPagos.UseVisualStyleBackColor = true;
            this.btnProcesarPagos.Click += new System.EventHandler(this.btnProcesarPagos_Click);
            // 
            // lblTitleTotalCobrar
            // 
            this.lblTitleTotalCobrar.AutoSize = true;
            this.lblTitleTotalCobrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleTotalCobrar.ForeColor = System.Drawing.Color.Red;
            this.lblTitleTotalCobrar.Location = new System.Drawing.Point(44, 33);
            this.lblTitleTotalCobrar.Name = "lblTitleTotalCobrar";
            this.lblTitleTotalCobrar.Size = new System.Drawing.Size(142, 24);
            this.lblTitleTotalCobrar.TabIndex = 8;
            this.lblTitleTotalCobrar.Text = "Total a Cobrar";
            // 
            // cmbfPagos
            // 
            this.cmbfPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbfPagos.FormattingEnabled = true;
            this.cmbfPagos.Location = new System.Drawing.Point(165, 215);
            this.cmbfPagos.Name = "cmbfPagos";
            this.cmbfPagos.Size = new System.Drawing.Size(201, 24);
            this.cmbfPagos.TabIndex = 10;
            this.cmbfPagos.DropDown += new System.EventHandler(this.cmbfPagos_DropDown);
            this.cmbfPagos.SelectedIndexChanged += new System.EventHandler(this.cmbfPagos_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Forma de Pago";
            // 
            // lblDevueltaEfectivo
            // 
            this.lblDevueltaEfectivo.AutoSize = true;
            this.lblDevueltaEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevueltaEfectivo.Location = new System.Drawing.Point(222, 147);
            this.lblDevueltaEfectivo.Name = "lblDevueltaEfectivo";
            this.lblDevueltaEfectivo.Size = new System.Drawing.Size(138, 33);
            this.lblDevueltaEfectivo.TabIndex = 12;
            this.lblDevueltaEfectivo.Text = "Devuelta";
            // 
            // lblAprobacion
            // 
            this.lblAprobacion.AutoSize = true;
            this.lblAprobacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAprobacion.Location = new System.Drawing.Point(15, 253);
            this.lblAprobacion.Name = "lblAprobacion";
            this.lblAprobacion.Size = new System.Drawing.Size(157, 24);
            this.lblAprobacion.TabIndex = 13;
            this.lblAprobacion.Text = "Aprobación No.";
            // 
            // txtAprobacionNo
            // 
            this.txtAprobacionNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAprobacionNo.Location = new System.Drawing.Point(169, 250);
            this.txtAprobacionNo.Name = "txtAprobacionNo";
            this.txtAprobacionNo.Size = new System.Drawing.Size(197, 22);
            this.txtAprobacionNo.TabIndex = 14;
            // 
            // lblTotalCobrar
            // 
            this.lblTotalCobrar.AutoSize = true;
            this.lblTotalCobrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCobrar.Location = new System.Drawing.Point(221, 33);
            this.lblTotalCobrar.Name = "lblTotalCobrar";
            this.lblTotalCobrar.Size = new System.Drawing.Size(110, 33);
            this.lblTotalCobrar.TabIndex = 15;
            this.lblTotalCobrar.Text = "Cobrar";
            // 
            // frmCobros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 365);
            this.Controls.Add(this.lblTotalCobrar);
            this.Controls.Add(this.txtAprobacionNo);
            this.Controls.Add(this.lblAprobacion);
            this.Controls.Add(this.lblDevueltaEfectivo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbfPagos);
            this.Controls.Add(this.lblTitleTotalCobrar);
            this.Controls.Add(this.txtDevueltaEfectivo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEfectivoRecibido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelarPago);
            this.Controls.Add(this.btnProcesarPagos);
            this.Name = "frmCobros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cobrar la Venta";
            this.Load += new System.EventHandler(this.frmCobros_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcesarPagos;
        private System.Windows.Forms.Button btnCancelarPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTitleTotalCobrar;
        public System.Windows.Forms.TextBox txtEfectivoRecibido;
        public System.Windows.Forms.TextBox txtDevueltaEfectivo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAprobacion;
        private System.Windows.Forms.TextBox txtAprobacionNo;
        public System.Windows.Forms.Label lblDevueltaEfectivo;
        public System.Windows.Forms.ComboBox cmbfPagos;
        public System.Windows.Forms.Label lblTotalCobrar;
    }
}