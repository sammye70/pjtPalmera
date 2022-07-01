namespace pjPalmera.PL
{
    partial class frmConsulArticulosExpirar
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
            this.dgvProductExpirar = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearchYear = new System.Windows.Forms.Button();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.lblCriterio2 = new System.Windows.Forms.Label();
            this.btnSearchMonth = new System.Windows.Forms.Button();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdYear = new System.Windows.Forms.RadioButton();
            this.rdMonth = new System.Windows.Forms.RadioButton();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductExpirar)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProductExpirar
            // 
            this.dgvProductExpirar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductExpirar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductExpirar.Location = new System.Drawing.Point(12, 98);
            this.dgvProductExpirar.Name = "dgvProductExpirar";
            this.dgvProductExpirar.Size = new System.Drawing.Size(891, 300);
            this.dgvProductExpirar.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearchYear);
            this.panel1.Controls.Add(this.cmbYear);
            this.panel1.Controls.Add(this.lblCriterio2);
            this.panel1.Controls.Add(this.btnSearchMonth);
            this.panel1.Controls.Add(this.cmbMonth);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.lblCriterio);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(891, 80);
            this.panel1.TabIndex = 6;
            // 
            // btnSearchYear
            // 
            this.btnSearchYear.Image = global::PL.Properties.Resources.search;
            this.btnSearchYear.Location = new System.Drawing.Point(294, 26);
            this.btnSearchYear.Name = "btnSearchYear";
            this.btnSearchYear.Size = new System.Drawing.Size(42, 37);
            this.btnSearchYear.TabIndex = 15;
            this.btnSearchYear.UseVisualStyleBackColor = true;
            this.btnSearchYear.Click += new System.EventHandler(this.btnSearchYear_Click);
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(51, 37);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(70, 21);
            this.cmbYear.TabIndex = 14;
            // 
            // lblCriterio2
            // 
            this.lblCriterio2.AutoSize = true;
            this.lblCriterio2.Location = new System.Drawing.Point(10, 40);
            this.lblCriterio2.Name = "lblCriterio2";
            this.lblCriterio2.Size = new System.Drawing.Size(35, 13);
            this.lblCriterio2.TabIndex = 13;
            this.lblCriterio2.Text = "label2";
            // 
            // btnSearchMonth
            // 
            this.btnSearchMonth.Image = global::PL.Properties.Resources.search;
            this.btnSearchMonth.Location = new System.Drawing.Point(294, 26);
            this.btnSearchMonth.Name = "btnSearchMonth";
            this.btnSearchMonth.Size = new System.Drawing.Size(42, 37);
            this.btnSearchMonth.TabIndex = 12;
            this.btnSearchMonth.UseVisualStyleBackColor = true;
            this.btnSearchMonth.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(188, 37);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(64, 21);
            this.cmbMonth.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdYear);
            this.groupBox1.Controls.Add(this.rdMonth);
            this.groupBox1.Location = new System.Drawing.Point(354, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 55);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar a Expirar";
            // 
            // rdYear
            // 
            this.rdYear.AutoSize = true;
            this.rdYear.Location = new System.Drawing.Point(168, 25);
            this.rdYear.Name = "rdYear";
            this.rdYear.Size = new System.Drawing.Size(44, 17);
            this.rdYear.TabIndex = 9;
            this.rdYear.Text = "Año";
            this.rdYear.UseVisualStyleBackColor = true;
            this.rdYear.CheckedChanged += new System.EventHandler(this.rdYear_CheckedChanged);
            // 
            // rdMonth
            // 
            this.rdMonth.AutoSize = true;
            this.rdMonth.Location = new System.Drawing.Point(28, 25);
            this.rdMonth.Name = "rdMonth";
            this.rdMonth.Size = new System.Drawing.Size(75, 17);
            this.rdMonth.TabIndex = 8;
            this.rdMonth.Text = "Mes y Año";
            this.rdMonth.UseVisualStyleBackColor = true;
            this.rdMonth.CheckedChanged += new System.EventHandler(this.rdMonth_CheckedChanged);
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(153, 40);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(35, 13);
            this.lblCriterio.TabIndex = 7;
            this.lblCriterio.Text = "label1";
            // 
            // button1
            // 
            this.button1.Image = global::PL.Properties.Resources.go;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(691, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 45);
            this.button1.TabIndex = 6;
            this.button1.Text = "Generar Consulta";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmConsulArticulosExpirar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 410);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvProductExpirar);
            this.Name = "frmConsulArticulosExpirar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Articulos a Expirar";
            this.Load += new System.EventHandler(this.frmArticulosVencer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductExpirar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvProductExpirar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdMonth;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rdYear;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Button btnSearchMonth;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label lblCriterio2;
        private System.Windows.Forms.Button btnSearchYear;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}