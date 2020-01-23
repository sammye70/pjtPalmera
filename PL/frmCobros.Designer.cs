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
            this.btnCancelarPago = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEfectivoRecibido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDevueltaEfectivo = new System.Windows.Forms.TextBox();
            this.btnProcesarPagos = new System.Windows.Forms.Button();
            this.txtTotalCobrar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelarPago
            // 
            this.btnCancelarPago.Image = global::PL.Properties.Resources.cancel;
            this.btnCancelarPago.Location = new System.Drawing.Point(193, 226);
            this.btnCancelarPago.Name = "btnCancelarPago";
            this.btnCancelarPago.Size = new System.Drawing.Size(75, 59);
            this.btnCancelarPago.TabIndex = 1;
            this.btnCancelarPago.Text = "Cancelar";
            this.btnCancelarPago.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelarPago.UseVisualStyleBackColor = true;
            this.btnCancelarPago.Click += new System.EventHandler(this.btnCancelarPago_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Efectivo Recibido";
            // 
            // txtEfectivoRecibido
            // 
            this.txtEfectivoRecibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivoRecibido.Location = new System.Drawing.Point(194, 76);
            this.txtEfectivoRecibido.Multiline = true;
            this.txtEfectivoRecibido.Name = "txtEfectivoRecibido";
            this.txtEfectivoRecibido.Size = new System.Drawing.Size(146, 46);
            this.txtEfectivoRecibido.TabIndex = 5;
            this.txtEfectivoRecibido.TextChanged += new System.EventHandler(this.txtEfectivoRecibido_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Devuelta Efectivo";
            // 
            // txtDevueltaEfectivo
            // 
            this.txtDevueltaEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDevueltaEfectivo.Location = new System.Drawing.Point(194, 138);
            this.txtDevueltaEfectivo.Multiline = true;
            this.txtDevueltaEfectivo.Name = "txtDevueltaEfectivo";
            this.txtDevueltaEfectivo.Size = new System.Drawing.Size(146, 46);
            this.txtDevueltaEfectivo.TabIndex = 7;
            // 
            // btnProcesarPagos
            // 
            this.btnProcesarPagos.Image = global::PL.Properties.Resources.apply;
            this.btnProcesarPagos.Location = new System.Drawing.Point(100, 226);
            this.btnProcesarPagos.Name = "btnProcesarPagos";
            this.btnProcesarPagos.Size = new System.Drawing.Size(75, 59);
            this.btnProcesarPagos.TabIndex = 0;
            this.btnProcesarPagos.Text = "Procesar";
            this.btnProcesarPagos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesarPagos.UseVisualStyleBackColor = true;
            this.btnProcesarPagos.Click += new System.EventHandler(this.btnProcesarPagos_Click);
            // 
            // txtTotalCobrar
            // 
            this.txtTotalCobrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCobrar.Location = new System.Drawing.Point(194, 12);
            this.txtTotalCobrar.Multiline = true;
            this.txtTotalCobrar.Name = "txtTotalCobrar";
            this.txtTotalCobrar.Size = new System.Drawing.Size(146, 46);
            this.txtTotalCobrar.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Total a Cobrar";
            // 
            // frmCobros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 318);
            this.Controls.Add(this.txtTotalCobrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDevueltaEfectivo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEfectivoRecibido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelarPago);
            this.Controls.Add(this.btnProcesarPagos);
            this.Name = "frmCobros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cobrar";
            this.Load += new System.EventHandler(this.frmCobros_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcesarPagos;
        private System.Windows.Forms.Button btnCancelarPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalCobrar;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtEfectivoRecibido;
        public System.Windows.Forms.TextBox txtDevueltaEfectivo;
    }
}