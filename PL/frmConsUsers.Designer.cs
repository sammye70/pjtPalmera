
namespace pjPalmera.PL
{
    partial class frmConsUsers
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
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.lblCriterial = new System.Windows.Forms.Label();
            this.txtuserName = new System.Windows.Forms.TextBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnDisableUser = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEditarProd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbUsuario = new System.Windows.Forms.RadioButton();
            this.rbPersona = new System.Windows.Forms.RadioButton();
            this.btnEnable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(12, 64);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(417, 188);
            this.dgvUsers.TabIndex = 0;
            // 
            // lblCriterial
            // 
            this.lblCriterial.AutoSize = true;
            this.lblCriterial.Location = new System.Drawing.Point(12, 32);
            this.lblCriterial.Name = "lblCriterial";
            this.lblCriterial.Size = new System.Drawing.Size(51, 13);
            this.lblCriterial.TabIndex = 1;
            this.lblCriterial.Text = "lblCriterial";
            // 
            // txtuserName
            // 
            this.txtuserName.Location = new System.Drawing.Point(71, 29);
            this.txtuserName.Name = "txtuserName";
            this.txtuserName.Size = new System.Drawing.Size(184, 20);
            this.txtuserName.TabIndex = 2;
            this.txtuserName.TextChanged += new System.EventHandler(this.txtuserName_TextChanged);
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(117, 3);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(45, 20);
            this.txtUserId.TabIndex = 70;
            this.txtUserId.Visible = false;
            // 
            // btnDisableUser
            // 
            this.btnDisableUser.Image = global::PL.Properties.Resources.delete;
            this.btnDisableUser.Location = new System.Drawing.Point(436, 207);
            this.btnDisableUser.Name = "btnDisableUser";
            this.btnDisableUser.Size = new System.Drawing.Size(48, 41);
            this.btnDisableUser.TabIndex = 71;
            this.btnDisableUser.UseVisualStyleBackColor = true;
            this.btnDisableUser.Click += new System.EventHandler(this.btnDisableUser_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Image = global::PL.Properties.Resources.trash;
            this.btnRemove.Location = new System.Drawing.Point(436, 111);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(48, 43);
            this.btnRemove.TabIndex = 69;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEditarProd
            // 
            this.btnEditarProd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarProd.Image = global::PL.Properties.Resources.edit;
            this.btnEditarProd.Location = new System.Drawing.Point(436, 64);
            this.btnEditarProd.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditarProd.Name = "btnEditarProd";
            this.btnEditarProd.Size = new System.Drawing.Size(48, 40);
            this.btnEditarProd.TabIndex = 68;
            this.btnEditarProd.UseVisualStyleBackColor = true;
            this.btnEditarProd.Click += new System.EventHandler(this.btnEditarProd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbUsuario);
            this.groupBox1.Controls.Add(this.rbPersona);
            this.groupBox1.Location = new System.Drawing.Point(275, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 54);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar por:";
            // 
            // rbUsuario
            // 
            this.rbUsuario.AutoSize = true;
            this.rbUsuario.Location = new System.Drawing.Point(106, 25);
            this.rbUsuario.Name = "rbUsuario";
            this.rbUsuario.Size = new System.Drawing.Size(61, 17);
            this.rbUsuario.TabIndex = 74;
            this.rbUsuario.TabStop = true;
            this.rbUsuario.Text = "Usuario";
            this.rbUsuario.UseVisualStyleBackColor = true;
            this.rbUsuario.CheckedChanged += new System.EventHandler(this.rbUsuario_CheckedChanged);
            // 
            // rbPersona
            // 
            this.rbPersona.AutoSize = true;
            this.rbPersona.Location = new System.Drawing.Point(15, 25);
            this.rbPersona.Name = "rbPersona";
            this.rbPersona.Size = new System.Drawing.Size(64, 17);
            this.rbPersona.TabIndex = 73;
            this.rbPersona.TabStop = true;
            this.rbPersona.Text = "Persona";
            this.rbPersona.UseVisualStyleBackColor = true;
            this.rbPersona.CheckedChanged += new System.EventHandler(this.rbPersona_CheckedChanged);
            // 
            // btnEnable
            // 
            this.btnEnable.Image = global::PL.Properties.Resources.up;
            this.btnEnable.Location = new System.Drawing.Point(436, 160);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(48, 41);
            this.btnEnable.TabIndex = 73;
            this.btnEnable.UseVisualStyleBackColor = true;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // frmConsUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 264);
            this.Controls.Add(this.btnEnable);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDisableUser);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnEditarProd);
            this.Controls.Add(this.txtuserName);
            this.Controls.Add(this.lblCriterial);
            this.Controls.Add(this.dgvUsers);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar y Ajustar Usuarios";
            this.Load += new System.EventHandler(this.frmConsUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Label lblCriterial;
        private System.Windows.Forms.TextBox txtuserName;
        public System.Windows.Forms.Button btnRemove;
        public System.Windows.Forms.Button btnEditarProd;
        public System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Button btnDisableUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbUsuario;
        private System.Windows.Forms.RadioButton rbPersona;
        public System.Windows.Forms.Button btnEnable;
    }
}