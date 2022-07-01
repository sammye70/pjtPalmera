namespace pjPalmera.PL
{
    partial class frmActivarFactura
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
            this.txtNoFactActivar = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnActivarFac = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Factura No.";
            // 
            // txtNoFactActivar
            // 
            this.txtNoFactActivar.Location = new System.Drawing.Point(83, 35);
            this.txtNoFactActivar.Name = "txtNoFactActivar";
            this.txtNoFactActivar.Size = new System.Drawing.Size(204, 20);
            this.txtNoFactActivar.TabIndex = 4;
            this.txtNoFactActivar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoFactActivar_KeyDown);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::PL.Properties.Resources.documents;
            this.btnLimpiar.Location = new System.Drawing.Point(96, 90);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 48);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnActivarFac
            // 
            this.btnActivarFac.Image = global::PL.Properties.Resources.apply;
            this.btnActivarFac.Location = new System.Drawing.Point(177, 90);
            this.btnActivarFac.Name = "btnActivarFac";
            this.btnActivarFac.Size = new System.Drawing.Size(75, 48);
            this.btnActivarFac.TabIndex = 6;
            this.btnActivarFac.UseVisualStyleBackColor = true;
            this.btnActivarFac.Click += new System.EventHandler(this.btnActivarFac_Click);
            // 
            // frmActivarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 153);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnActivarFac);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNoFactActivar);
            this.Name = "frmActivarFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Activar Factura";
            this.Load += new System.EventHandler(this.frmActivarFactura_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnActivarFac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoFactActivar;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}