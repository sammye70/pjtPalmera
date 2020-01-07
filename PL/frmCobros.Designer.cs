namespace pjPamera.PL
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
            this.btnProcesarPagos = new System.Windows.Forms.Button();
            this.btnCancelarPago = new System.Windows.Forms.Button();
            this.txtMontoCobrar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEfectivoRecibido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDevueltaEfectivo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnProcesarPagos
            // 
            this.btnProcesarPagos.Location = new System.Drawing.Point(135, 270);
            this.btnProcesarPagos.Name = "btnProcesarPagos";
            this.btnProcesarPagos.Size = new System.Drawing.Size(75, 23);
            this.btnProcesarPagos.TabIndex = 0;
            this.btnProcesarPagos.Text = "Procesar";
            this.btnProcesarPagos.UseVisualStyleBackColor = true;
            // 
            // btnCancelarPago
            // 
            this.btnCancelarPago.Location = new System.Drawing.Point(231, 270);
            this.btnCancelarPago.Name = "btnCancelarPago";
            this.btnCancelarPago.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarPago.TabIndex = 1;
            this.btnCancelarPago.Text = "Cancelar";
            this.btnCancelarPago.UseVisualStyleBackColor = true;
            this.btnCancelarPago.Click += new System.EventHandler(this.btnCancelarPago_Click);
            // 
            // txtMontoCobrar
            // 
            this.txtMontoCobrar.Location = new System.Drawing.Point(135, 74);
            this.txtMontoCobrar.Name = "txtMontoCobrar";
            this.txtMontoCobrar.Size = new System.Drawing.Size(146, 20);
            this.txtMontoCobrar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total a Pagar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Efectivo Recibido";
            // 
            // txtEfectivoRecibido
            // 
            this.txtEfectivoRecibido.Location = new System.Drawing.Point(135, 117);
            this.txtEfectivoRecibido.Name = "txtEfectivoRecibido";
            this.txtEfectivoRecibido.Size = new System.Drawing.Size(146, 20);
            this.txtEfectivoRecibido.TabIndex = 5;
            this.txtEfectivoRecibido.TextChanged += new System.EventHandler(this.txtEfectivoRecibido_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Devuelta Efectivo";
            // 
            // txtDevueltaEfectivo
            // 
            this.txtDevueltaEfectivo.Location = new System.Drawing.Point(135, 153);
            this.txtDevueltaEfectivo.Name = "txtDevueltaEfectivo";
            this.txtDevueltaEfectivo.Size = new System.Drawing.Size(146, 20);
            this.txtDevueltaEfectivo.TabIndex = 7;
            // 
            // frmCobros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 318);
            this.ControlBox = false;
            this.Controls.Add(this.txtDevueltaEfectivo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEfectivoRecibido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMontoCobrar);
            this.Controls.Add(this.btnCancelarPago);
            this.Controls.Add(this.btnProcesarPagos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCobros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCobros";
            this.Load += new System.EventHandler(this.frmCobros_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcesarPagos;
        private System.Windows.Forms.Button btnCancelarPago;
        private System.Windows.Forms.TextBox txtMontoCobrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEfectivoRecibido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDevueltaEfectivo;
    }
}