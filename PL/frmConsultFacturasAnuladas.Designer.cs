namespace pjPalmera.PL
{
    partial class frmConsultFactAnuladas
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
            this.dgvFactAnuladas = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerarConsulta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactAnuladas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvFactAnuladas
            // 
            this.dgvFactAnuladas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFactAnuladas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFactAnuladas.Location = new System.Drawing.Point(12, 80);
            this.dgvFactAnuladas.Name = "dgvFactAnuladas";
            this.dgvFactAnuladas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFactAnuladas.Size = new System.Drawing.Size(985, 415);
            this.dgvFactAnuladas.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnGenerarConsulta);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(985, 62);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(331, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Facturas Anuladas";
            // 
            // btnGenerarConsulta
            // 
            this.btnGenerarConsulta.Location = new System.Drawing.Point(778, 20);
            this.btnGenerarConsulta.Name = "btnGenerarConsulta";
            this.btnGenerarConsulta.Size = new System.Drawing.Size(126, 31);
            this.btnGenerarConsulta.TabIndex = 2;
            this.btnGenerarConsulta.Text = "Generar Consulta";
            this.btnGenerarConsulta.UseVisualStyleBackColor = true;
            this.btnGenerarConsulta.Click += new System.EventHandler(this.btnGenerarConsulta_Click);
            // 
            // frmConsultFactAnuladas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 507);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvFactAnuladas);
            this.Name = "frmConsultFactAnuladas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Facturas Anuladas";
            this.Load += new System.EventHandler(this.frmConsultFactAnuladas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactAnuladas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFactAnuladas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGenerarConsulta;
        private System.Windows.Forms.Label label1;
    }
}