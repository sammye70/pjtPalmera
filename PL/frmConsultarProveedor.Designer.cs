﻿namespace pjPalmera.PL
{
    partial class frmConsultarProveedor
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
            this.lblCriterioBuscar = new System.Windows.Forms.Label();
            this.txtCriterioBuscar = new System.Windows.Forms.TextBox();
            this.rbRnc = new System.Windows.Forms.RadioButton();
            this.rbNomEmpresa = new System.Windows.Forms.RadioButton();
            this.dgvContProveedor = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCriterioBuscar
            // 
            this.lblCriterioBuscar.AutoSize = true;
            this.lblCriterioBuscar.Location = new System.Drawing.Point(12, 26);
            this.lblCriterioBuscar.Name = "lblCriterioBuscar";
            this.lblCriterioBuscar.Size = new System.Drawing.Size(33, 13);
            this.lblCriterioBuscar.TabIndex = 0;
            this.lblCriterioBuscar.Text = "Label";
            // 
            // txtCriterioBuscar
            // 
            this.txtCriterioBuscar.Location = new System.Drawing.Point(68, 23);
            this.txtCriterioBuscar.Name = "txtCriterioBuscar";
            this.txtCriterioBuscar.Size = new System.Drawing.Size(151, 20);
            this.txtCriterioBuscar.TabIndex = 1;
            this.txtCriterioBuscar.TextChanged += new System.EventHandler(this.txtCriterioBuscar_TextChanged);
            // 
            // rbRnc
            // 
            this.rbRnc.AutoSize = true;
            this.rbRnc.Location = new System.Drawing.Point(256, 26);
            this.rbRnc.Name = "rbRnc";
            this.rbRnc.Size = new System.Drawing.Size(48, 17);
            this.rbRnc.TabIndex = 2;
            this.rbRnc.TabStop = true;
            this.rbRnc.Text = "RNC";
            this.rbRnc.UseVisualStyleBackColor = true;
            this.rbRnc.CheckedChanged += new System.EventHandler(this.rbRnc_CheckedChanged);
            // 
            // rbNomEmpresa
            // 
            this.rbNomEmpresa.AutoSize = true;
            this.rbNomEmpresa.Location = new System.Drawing.Point(352, 26);
            this.rbNomEmpresa.Name = "rbNomEmpresa";
            this.rbNomEmpresa.Size = new System.Drawing.Size(114, 17);
            this.rbNomEmpresa.TabIndex = 3;
            this.rbNomEmpresa.TabStop = true;
            this.rbNomEmpresa.Text = "Nombre Proveedor";
            this.rbNomEmpresa.UseVisualStyleBackColor = true;
            this.rbNomEmpresa.CheckedChanged += new System.EventHandler(this.rbNomEmpresa_CheckedChanged);
            // 
            // dgvContProveedor
            // 
            this.dgvContProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvContProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContProveedor.Location = new System.Drawing.Point(5, 62);
            this.dgvContProveedor.Name = "dgvContProveedor";
            this.dgvContProveedor.Size = new System.Drawing.Size(1038, 395);
            this.dgvContProveedor.TabIndex = 4;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::PL.Properties.Resources.cancel1;
            this.btnCancelar.Location = new System.Drawing.Point(578, 11);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(56, 43);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::PL.Properties.Resources.search;
            this.btnBuscar.Location = new System.Drawing.Point(516, 11);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(56, 43);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Visible = false;
            // 
            // frmConsultarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 469);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvContProveedor);
            this.Controls.Add(this.rbNomEmpresa);
            this.Controls.Add(this.rbRnc);
            this.Controls.Add(this.txtCriterioBuscar);
            this.Controls.Add(this.lblCriterioBuscar);
            this.Name = "frmConsultarProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Proveedor";
            this.Load += new System.EventHandler(this.frmConsultarProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContProveedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCriterioBuscar;
        private System.Windows.Forms.TextBox txtCriterioBuscar;
        private System.Windows.Forms.RadioButton rbRnc;
        private System.Windows.Forms.RadioButton rbNomEmpresa;
        private System.Windows.Forms.DataGridView dgvContProveedor;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnBuscar;
    }
}