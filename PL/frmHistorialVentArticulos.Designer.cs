namespace pjPalmera.PL
{
    partial class frmHistorialVentArticulos
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
            this.dgvHistoryArtVend = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGenerarConsulta = new System.Windows.Forms.Button();
            this.rbHoy = new System.Windows.Forms.RadioButton();
            this.rbAyer = new System.Windows.Forms.RadioButton();
            this.rbMes = new System.Windows.Forms.RadioButton();
            this.rbYear = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryArtVend)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHistoryArtVend
            // 
            this.dgvHistoryArtVend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistoryArtVend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistoryArtVend.Location = new System.Drawing.Point(12, 85);
            this.dgvHistoryArtVend.Name = "dgvHistoryArtVend";
            this.dgvHistoryArtVend.Size = new System.Drawing.Size(1072, 374);
            this.dgvHistoryArtVend.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnGenerarConsulta);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1072, 67);
            this.panel1.TabIndex = 1;
            // 
            // btnGenerarConsulta
            // 
            this.btnGenerarConsulta.Location = new System.Drawing.Point(828, 18);
            this.btnGenerarConsulta.Name = "btnGenerarConsulta";
            this.btnGenerarConsulta.Size = new System.Drawing.Size(124, 29);
            this.btnGenerarConsulta.TabIndex = 2;
            this.btnGenerarConsulta.Text = "Generar Consulta";
            this.btnGenerarConsulta.UseVisualStyleBackColor = true;
            this.btnGenerarConsulta.Click += new System.EventHandler(this.btnGenerarConsulta_Click);
            // 
            // rbHoy
            // 
            this.rbHoy.AutoSize = true;
            this.rbHoy.Location = new System.Drawing.Point(52, 22);
            this.rbHoy.Name = "rbHoy";
            this.rbHoy.Size = new System.Drawing.Size(44, 17);
            this.rbHoy.TabIndex = 3;
            this.rbHoy.TabStop = true;
            this.rbHoy.Text = "Hoy";
            this.rbHoy.UseVisualStyleBackColor = true;
            // 
            // rbAyer
            // 
            this.rbAyer.AutoSize = true;
            this.rbAyer.Location = new System.Drawing.Point(121, 22);
            this.rbAyer.Name = "rbAyer";
            this.rbAyer.Size = new System.Drawing.Size(46, 17);
            this.rbAyer.TabIndex = 2;
            this.rbAyer.TabStop = true;
            this.rbAyer.Text = "Ayer";
            this.rbAyer.UseVisualStyleBackColor = true;
            // 
            // rbMes
            // 
            this.rbMes.AutoSize = true;
            this.rbMes.Location = new System.Drawing.Point(185, 22);
            this.rbMes.Name = "rbMes";
            this.rbMes.Size = new System.Drawing.Size(45, 17);
            this.rbMes.TabIndex = 4;
            this.rbMes.TabStop = true;
            this.rbMes.Text = "Mes";
            this.rbMes.UseVisualStyleBackColor = true;
            // 
            // rbYear
            // 
            this.rbYear.AutoSize = true;
            this.rbYear.Location = new System.Drawing.Point(256, 22);
            this.rbYear.Name = "rbYear";
            this.rbYear.Size = new System.Drawing.Size(44, 17);
            this.rbYear.TabIndex = 5;
            this.rbYear.TabStop = true;
            this.rbYear.Text = "Año";
            this.rbYear.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbYear);
            this.groupBox1.Controls.Add(this.rbHoy);
            this.groupBox1.Controls.Add(this.rbMes);
            this.groupBox1.Controls.Add(this.rbAyer);
            this.groupBox1.Location = new System.Drawing.Point(407, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 57);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consultar Articulos Vendidos:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(59, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(83, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // frmHistorialVentArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 471);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvHistoryArtVend);
            this.Name = "frmHistorialVentArticulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial Articulos Vendidos";
            this.Load += new System.EventHandler(this.frmHistorialVentArticulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryArtVend)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistoryArtVend;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGenerarConsulta;
        private System.Windows.Forms.RadioButton rbYear;
        private System.Windows.Forms.RadioButton rbMes;
        private System.Windows.Forms.RadioButton rbAyer;
        private System.Windows.Forms.RadioButton rbHoy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}