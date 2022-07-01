
namespace pjPalmera.PL
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
            this.dgvOperationsBox = new System.Windows.Forms.DataGridView();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.lblBegin = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.cmbListProcess = new System.Windows.Forms.ComboBox();
            this.lblFilterProcess = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblUsers = new System.Windows.Forms.Label();
            this.cmbListUsers = new System.Windows.Forms.ComboBox();
            this.btnPrintTicket = new System.Windows.Forms.Button();
            this.txtPermission = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperationsBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOperationsBox
            // 
            this.dgvOperationsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOperationsBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperationsBox.Location = new System.Drawing.Point(12, 99);
            this.dgvOperationsBox.Name = "dgvOperationsBox";
            this.dgvOperationsBox.Size = new System.Drawing.Size(655, 350);
            this.dgvOperationsBox.TabIndex = 0;
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(413, 1);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(100, 20);
            this.txtUserId.TabIndex = 1;
            this.txtUserId.Visible = false;
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Location = new System.Drawing.Point(313, 49);
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
            this.lblEnd.Location = new System.Drawing.Point(272, 53);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(35, 13);
            this.lblEnd.TabIndex = 5;
            this.lblEnd.Text = "Hasta";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(121, 83);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(371, 12);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = "Indicar  las fechas de los Cierres o Aperturas de Caja que desea Mostrar";
            // 
            // btnFind
            // 
            this.btnFind.Image = global::PL.Properties.Resources.search;
            this.btnFind.Location = new System.Drawing.Point(544, 40);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(43, 42);
            this.btnFind.TabIndex = 7;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // cmbListProcess
            // 
            this.cmbListProcess.FormattingEnabled = true;
            this.cmbListProcess.Location = new System.Drawing.Point(61, 16);
            this.cmbListProcess.Name = "cmbListProcess";
            this.cmbListProcess.Size = new System.Drawing.Size(121, 21);
            this.cmbListProcess.TabIndex = 8;
            this.cmbListProcess.DropDown += new System.EventHandler(this.cmbListProcess_DropDown);
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
            // cmbListUsers
            // 
            this.cmbListUsers.FormattingEnabled = true;
            this.cmbListUsers.Location = new System.Drawing.Point(252, 14);
            this.cmbListUsers.Name = "cmbListUsers";
            this.cmbListUsers.Size = new System.Drawing.Size(121, 21);
            this.cmbListUsers.TabIndex = 10;
            this.cmbListUsers.Visible = false;
            this.cmbListUsers.DropDown += new System.EventHandler(this.cmbListUsers_DropDown);
            // 
            // btnPrintTicket
            // 
            this.btnPrintTicket.Image = global::PL.Properties.Resources.print;
            this.btnPrintTicket.Location = new System.Drawing.Point(593, 40);
            this.btnPrintTicket.Name = "btnPrintTicket";
            this.btnPrintTicket.Size = new System.Drawing.Size(50, 42);
            this.btnPrintTicket.TabIndex = 12;
            this.btnPrintTicket.UseVisualStyleBackColor = true;
            this.btnPrintTicket.Click += new System.EventHandler(this.btnPrintTicket_Click);
            // 
            // txtPermission
            // 
            this.txtPermission.Location = new System.Drawing.Point(519, 1);
            this.txtPermission.Name = "txtPermission";
            this.txtPermission.Size = new System.Drawing.Size(100, 20);
            this.txtPermission.TabIndex = 13;
            this.txtPermission.Visible = false;
            // 
            // frmConsOpCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 458);
            this.Controls.Add(this.txtPermission);
            this.Controls.Add(this.btnPrintTicket);
            this.Controls.Add(this.lblUsers);
            this.Controls.Add(this.cmbListUsers);
            this.Controls.Add(this.lblFilterProcess);
            this.Controls.Add(this.cmbListProcess);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblBegin);
            this.Controls.Add(this.dtpDateBegin);
            this.Controls.Add(this.dtpDateEnd);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.dgvOperationsBox);
            this.MaximizeBox = false;
            this.Name = "frmConsOpCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial Operaciones de Apertura y Cierre de la Caja";
            this.Load += new System.EventHandler(this.frmConsOpCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperationsBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOperationsBox;
        public System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.Label lblBegin;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ComboBox cmbListProcess;
        private System.Windows.Forms.Label lblFilterProcess;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public System.Windows.Forms.Label lblUsers;
        public System.Windows.Forms.ComboBox cmbListUsers;
        private System.Windows.Forms.Button btnPrintTicket;
        public System.Windows.Forms.TextBox txtPermission;
    }
}