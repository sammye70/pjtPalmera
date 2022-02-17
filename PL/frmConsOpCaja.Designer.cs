
namespace PL
{
    partial class frmConsOpCaja
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.lblBegin = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblFilterProcess = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblUsers = new System.Windows.Forms.Label();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 99);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 350);
            this.dataGridView1.TabIndex = 0;
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(526, 9);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(100, 20);
            this.txtUserId.TabIndex = 1;
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Location = new System.Drawing.Point(316, 49);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(200, 20);
            this.dtpDateEnd.TabIndex = 2;
            // 
            // dtpDateBegin
            // 
            this.dtpDateBegin.Location = new System.Drawing.Point(61, 49);
            this.dtpDateBegin.Name = "dtpDateBegin";
            this.dtpDateBegin.Size = new System.Drawing.Size(200, 20);
            this.dtpDateBegin.TabIndex = 3;
            // 
            // lblBegin
            // 
            this.lblBegin.AutoSize = true;
            this.lblBegin.Location = new System.Drawing.Point(10, 53);
            this.lblBegin.Name = "lblBegin";
            this.lblBegin.Size = new System.Drawing.Size(38, 13);
            this.lblBegin.TabIndex = 4;
            this.lblBegin.Text = "Desde";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(278, 53);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(35, 13);
            this.lblEnd.TabIndex = 5;
            this.lblEnd.Text = "Hasta";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(168, 82);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(371, 12);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = "Indicar  las fechas de los Cierres o Aperturas de Caja que desea Mostrar";
            // 
            // btnFind
            // 
            this.btnFind.Image = global::PL.Properties.Resources.search;
            this.btnFind.Location = new System.Drawing.Point(526, 36);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(43, 42);
            this.btnFind.TabIndex = 7;
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(61, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // lblFilterProcess
            // 
            this.lblFilterProcess.AutoSize = true;
            this.lblFilterProcess.Location = new System.Drawing.Point(9, 18);
            this.lblFilterProcess.Name = "lblFilterProcess";
            this.lblFilterProcess.Size = new System.Drawing.Size(46, 13);
            this.lblFilterProcess.TabIndex = 9;
            this.lblFilterProcess.Text = "Proceso";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Location = new System.Drawing.Point(200, 16);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(43, 13);
            this.lblUsers.TabIndex = 11;
            this.lblUsers.Text = "Usuario";
            this.lblUsers.Visible = false;
            // 
            // cmbUsers
            // 
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(252, 14);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(121, 21);
            this.cmbUsers.TabIndex = 10;
            this.cmbUsers.Visible = false;
            // 
            // button1
            // 
            this.button1.Image = global::PL.Properties.Resources.print;
            this.button1.Location = new System.Drawing.Point(670, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 42);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmConsOpCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 458);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblUsers);
            this.Controls.Add(this.cmbUsers);
            this.Controls.Add(this.lblFilterProcess);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblBegin);
            this.Controls.Add(this.dtpDateBegin);
            this.Controls.Add(this.dtpDateEnd);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.Name = "frmConsOpCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial Operaciones de Apertura y Cierre de la Caja";
            this.Load += new System.EventHandler(this.frmConsOpCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.Label lblBegin;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblFilterProcess;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public System.Windows.Forms.Label lblUsers;
        public System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.Button button1;
    }
}