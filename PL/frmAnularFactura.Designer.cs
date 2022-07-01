namespace pjPalmera.PL
{
    partial class frmAnularFactura
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
            this.txtNoFactAnular = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAnularFac = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // txtNoFactAnular
            // 
            this.txtNoFactAnular.Location = new System.Drawing.Point(81, 48);
            this.txtNoFactAnular.Name = "txtNoFactAnular";
            this.txtNoFactAnular.Size = new System.Drawing.Size(204, 20);
            this.txtNoFactAnular.TabIndex = 0;
            this.txtNoFactAnular.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoFactAnular_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Factura No.";
            // 
            // btnAnularFac
            // 
            this.btnAnularFac.Image = global::PL.Properties.Resources.apply;
            this.btnAnularFac.Location = new System.Drawing.Point(175, 103);
            this.btnAnularFac.Name = "btnAnularFac";
            this.btnAnularFac.Size = new System.Drawing.Size(75, 48);
            this.btnAnularFac.TabIndex = 2;
            this.btnAnularFac.UseVisualStyleBackColor = true;
            this.btnAnularFac.Click += new System.EventHandler(this.btnAnularFac_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::PL.Properties.Resources.documents;
            this.btnLimpiar.Location = new System.Drawing.Point(94, 103);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 48);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // frmAnularFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 163);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnAnularFac);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNoFactAnular);
            this.Name = "frmAnularFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anular Factura";
            this.Load += new System.EventHandler(this.frmAnularFactura_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNoFactAnular;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAnularFac;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}