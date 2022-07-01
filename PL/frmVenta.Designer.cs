namespace pjPalmera.PL
{
    partial class frmVenta
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
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblCajeroName = new System.Windows.Forms.Label();
            this.cmbCondictionDays = new System.Windows.Forms.ComboBox();
            this.lblCondictionCr = new System.Windows.Forms.Label();
            this.lblDescInvoiceCash = new System.Windows.Forms.Label();
            this.cmbDescPostVentaExt = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lblCajeroTitle = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnFindCustomer = new System.Windows.Forms.Button();
            this.txtClientes = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProductos = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblResDevuelta = new System.Windows.Forms.Label();
            this.cmbfPagos = new System.Windows.Forms.ComboBox();
            this.txtAprobacionNo = new System.Windows.Forms.TextBox();
            this.lblAprobacion = new System.Windows.Forms.Label();
            this.chbPrintTicketFact = new System.Windows.Forms.CheckBox();
            this.txtDevueltaEfectivo = new System.Windows.Forms.TextBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblChangeCash = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDescuentCash = new System.Windows.Forms.Label();
            this.lblTotalPay = new System.Windows.Forms.Label();
            this.txtEfectivoRecibido = new System.Windows.Forms.TextBox();
            this.lblGetCashPayInvC = new System.Windows.Forms.Label();
            this.lblMethodPago = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.chbDescuento = new System.Windows.Forms.CheckBox();
            this.btnProcesarPago = new System.Windows.Forms.Button();
            this.txtItbis = new System.Windows.Forms.TextBox();
            this.txtId_Invoice = new System.Windows.Forms.TextBox();
            this.btnPagar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNewInvoiceCr = new System.Windows.Forms.Button();
            this.btnProcInvoiceCr = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtTypeInvoice = new System.Windows.Forms.TextBox();
            this.txtPermissionId = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtCreditLimit = new System.Windows.Forms.TextBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtCurrentAmount = new System.Windows.Forms.TextBox();
            this.txtAmountPast = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(12, 352);
            this.dgvDetalle.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(1091, 313);
            this.dgvDetalle.TabIndex = 8;
            this.dgvDetalle.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDetalle_DataError);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Location = new System.Drawing.Point(12, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1258, 326);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblCajeroName);
            this.groupBox3.Controls.Add(this.cmbCondictionDays);
            this.groupBox3.Controls.Add(this.lblCondictionCr);
            this.groupBox3.Controls.Add(this.lblDescInvoiceCash);
            this.groupBox3.Controls.Add(this.cmbDescPostVentaExt);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.lblCajeroTitle);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.btnFindCustomer);
            this.groupBox3.Controls.Add(this.txtClientes);
            this.groupBox3.Controls.Add(this.lblCustomer);
            this.groupBox3.Controls.Add(this.txtPrecio);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtDescripcion);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.btnBuscarProducto);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtCantidad);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtProductos);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(9, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1211, 138);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Informaciones de la Venta ";
            // 
            // lblCajeroName
            // 
            this.lblCajeroName.AutoSize = true;
            this.lblCajeroName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCajeroName.Location = new System.Drawing.Point(908, 71);
            this.lblCajeroName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCajeroName.Name = "lblCajeroName";
            this.lblCajeroName.Size = new System.Drawing.Size(119, 18);
            this.lblCajeroName.TabIndex = 63;
            this.lblCajeroName.Text = "first/last_name";
            // 
            // cmbCondictionDays
            // 
            this.cmbCondictionDays.FormattingEnabled = true;
            this.cmbCondictionDays.Location = new System.Drawing.Point(1044, 98);
            this.cmbCondictionDays.Name = "cmbCondictionDays";
            this.cmbCondictionDays.Size = new System.Drawing.Size(69, 26);
            this.cmbCondictionDays.TabIndex = 62;
            // 
            // lblCondictionCr
            // 
            this.lblCondictionCr.AutoSize = true;
            this.lblCondictionCr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCondictionCr.Location = new System.Drawing.Point(808, 104);
            this.lblCondictionCr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCondictionCr.Name = "lblCondictionCr";
            this.lblCondictionCr.Size = new System.Drawing.Size(235, 18);
            this.lblCondictionCr.TabIndex = 61;
            this.lblCondictionCr.Text = "Condiciones de Factura (dias)";
            // 
            // lblDescInvoiceCash
            // 
            this.lblDescInvoiceCash.AutoSize = true;
            this.lblDescInvoiceCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescInvoiceCash.Location = new System.Drawing.Point(877, 101);
            this.lblDescInvoiceCash.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescInvoiceCash.Name = "lblDescInvoiceCash";
            this.lblDescInvoiceCash.Size = new System.Drawing.Size(120, 18);
            this.lblDescInvoiceCash.TabIndex = 60;
            this.lblDescInvoiceCash.Text = "Descuento (%)";
            // 
            // cmbDescPostVentaExt
            // 
            this.cmbDescPostVentaExt.FormattingEnabled = true;
            this.cmbDescPostVentaExt.Location = new System.Drawing.Point(1048, 98);
            this.cmbDescPostVentaExt.Name = "cmbDescPostVentaExt";
            this.cmbDescPostVentaExt.Size = new System.Drawing.Size(69, 26);
            this.cmbDescPostVentaExt.TabIndex = 59;
            this.cmbDescPostVentaExt.TextChanged += new System.EventHandler(this.cmbDescuentoPostVenta_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(908, 20);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 18);
            this.label15.TabIndex = 55;
            this.label15.Text = "Fecha";
            // 
            // lblCajeroTitle
            // 
            this.lblCajeroTitle.AutoSize = true;
            this.lblCajeroTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCajeroTitle.Location = new System.Drawing.Point(834, 71);
            this.lblCajeroTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCajeroTitle.Name = "lblCajeroTitle";
            this.lblCajeroTitle.Size = new System.Drawing.Size(63, 18);
            this.lblCajeroTitle.TabIndex = 53;
            this.lblCajeroTitle.Text = "Cajero:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(908, 46);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 18);
            this.label14.TabIndex = 54;
            this.label14.Text = "Hora";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(834, 20);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 18);
            this.label12.TabIndex = 52;
            this.label12.Text = "Fecha:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(834, 46);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 18);
            this.label11.TabIndex = 51;
            this.label11.Text = "Hora:";
            // 
            // btnFindCustomer
            // 
            this.btnFindCustomer.Image = global::PL.Properties.Resources.search;
            this.btnFindCustomer.Location = new System.Drawing.Point(580, 22);
            this.btnFindCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.btnFindCustomer.Name = "btnFindCustomer";
            this.btnFindCustomer.Size = new System.Drawing.Size(44, 36);
            this.btnFindCustomer.TabIndex = 50;
            this.btnFindCustomer.UseVisualStyleBackColor = true;
            this.btnFindCustomer.Click += new System.EventHandler(this.btnBuscarClientes_Click_1);
            // 
            // txtClientes
            // 
            this.txtClientes.Location = new System.Drawing.Point(94, 28);
            this.txtClientes.Margin = new System.Windows.Forms.Padding(4);
            this.txtClientes.Name = "txtClientes";
            this.txtClientes.Size = new System.Drawing.Size(478, 24);
            this.txtClientes.TabIndex = 49;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(13, 32);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(60, 18);
            this.lblCustomer.TabIndex = 48;
            this.lblCustomer.Text = "Cliente";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(646, 104);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(148, 24);
            this.txtPrecio.TabIndex = 46;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(584, 104);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 18);
            this.label7.TabIndex = 45;
            this.label7.Text = "Precio";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(154, 104);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(399, 24);
            this.txtDescripcion.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 104);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 18);
            this.label6.TabIndex = 43;
            this.label6.Text = "Descripción";
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBuscarProducto.Image = global::PL.Properties.Resources.search;
            this.btnBuscarProducto.Location = new System.Drawing.Point(441, 56);
            this.btnBuscarProducto.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(42, 37);
            this.btnBuscarProducto.TabIndex = 42;
            this.btnBuscarProducto.UseVisualStyleBackColor = true;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(567, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 18);
            this.label4.TabIndex = 41;
            this.label4.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(645, 68);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(4);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(96, 24);
            this.txtCantidad.TabIndex = 40;
            this.txtCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 18);
            this.label2.TabIndex = 38;
            this.label2.Text = "Código Producto";
            // 
            // txtProductos
            // 
            this.txtProductos.Location = new System.Drawing.Point(153, 68);
            this.txtProductos.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductos.Name = "txtProductos";
            this.txtProductos.Size = new System.Drawing.Size(280, 24);
            this.txtProductos.TabIndex = 35;
            this.txtProductos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductos_KeyDown);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.lblResDevuelta);
            this.groupBox4.Controls.Add(this.cmbfPagos);
            this.groupBox4.Controls.Add(this.txtAprobacionNo);
            this.groupBox4.Controls.Add(this.lblAprobacion);
            this.groupBox4.Controls.Add(this.chbPrintTicketFact);
            this.groupBox4.Controls.Add(this.txtDevueltaEfectivo);
            this.groupBox4.Controls.Add(this.lblSubtotal);
            this.groupBox4.Controls.Add(this.lblChangeCash);
            this.groupBox4.Controls.Add(this.lblDescuento);
            this.groupBox4.Controls.Add(this.lblTotalPagar);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.lblDescuentCash);
            this.groupBox4.Controls.Add(this.lblTotalPay);
            this.groupBox4.Controls.Add(this.txtEfectivoRecibido);
            this.groupBox4.Controls.Add(this.lblGetCashPayInvC);
            this.groupBox4.Controls.Add(this.lblMethodPago);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(6, 146);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1214, 172);
            this.groupBox4.TabIndex = 34;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Detalle Cobro";
            // 
            // lblResDevuelta
            // 
            this.lblResDevuelta.AutoSize = true;
            this.lblResDevuelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResDevuelta.Location = new System.Drawing.Point(669, 46);
            this.lblResDevuelta.Name = "lblResDevuelta";
            this.lblResDevuelta.Size = new System.Drawing.Size(80, 20);
            this.lblResDevuelta.TabIndex = 67;
            this.lblResDevuelta.Text = "Devuelta";
            // 
            // cmbfPagos
            // 
            this.cmbfPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbfPagos.FormattingEnabled = true;
            this.cmbfPagos.Location = new System.Drawing.Point(947, 48);
            this.cmbfPagos.Name = "cmbfPagos";
            this.cmbfPagos.Size = new System.Drawing.Size(162, 24);
            this.cmbfPagos.TabIndex = 66;
            this.cmbfPagos.DropDown += new System.EventHandler(this.cmbfPagos_DropDown);
            this.cmbfPagos.SelectedIndexChanged += new System.EventHandler(this.cmbfPagos_SelectedIndexChanged);
            // 
            // txtAprobacionNo
            // 
            this.txtAprobacionNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAprobacionNo.Location = new System.Drawing.Point(947, 104);
            this.txtAprobacionNo.Name = "txtAprobacionNo";
            this.txtAprobacionNo.Size = new System.Drawing.Size(170, 22);
            this.txtAprobacionNo.TabIndex = 65;
            // 
            // lblAprobacion
            // 
            this.lblAprobacion.AutoSize = true;
            this.lblAprobacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAprobacion.Location = new System.Drawing.Point(807, 104);
            this.lblAprobacion.Name = "lblAprobacion";
            this.lblAprobacion.Size = new System.Drawing.Size(132, 20);
            this.lblAprobacion.TabIndex = 64;
            this.lblAprobacion.Text = "Aprobación No.";
            // 
            // chbPrintTicketFact
            // 
            this.chbPrintTicketFact.AutoSize = true;
            this.chbPrintTicketFact.Location = new System.Drawing.Point(12, 134);
            this.chbPrintTicketFact.Name = "chbPrintTicketFact";
            this.chbPrintTicketFact.Size = new System.Drawing.Size(224, 22);
            this.chbPrintTicketFact.TabIndex = 63;
            this.chbPrintTicketFact.Text = "Imprimir Ticket de Factura";
            this.chbPrintTicketFact.UseVisualStyleBackColor = true;
            // 
            // txtDevueltaEfectivo
            // 
            this.txtDevueltaEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDevueltaEfectivo.Location = new System.Drawing.Point(307, 91);
            this.txtDevueltaEfectivo.Multiline = true;
            this.txtDevueltaEfectivo.Name = "txtDevueltaEfectivo";
            this.txtDevueltaEfectivo.Size = new System.Drawing.Size(122, 46);
            this.txtDevueltaEfectivo.TabIndex = 59;
            this.txtDevueltaEfectivo.Visible = false;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(120, 91);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(74, 20);
            this.lblSubtotal.TabIndex = 62;
            this.lblSubtotal.Text = "subtotal";
            // 
            // lblChangeCash
            // 
            this.lblChangeCash.AutoSize = true;
            this.lblChangeCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeCash.Location = new System.Drawing.Point(472, 42);
            this.lblChangeCash.Name = "lblChangeCash";
            this.lblChangeCash.Size = new System.Drawing.Size(180, 25);
            this.lblChangeCash.TabIndex = 58;
            this.lblChangeCash.Text = "Devuelta Efectivo";
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.Location = new System.Drawing.Point(388, 45);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(57, 20);
            this.lblDescuento.TabIndex = 61;
            this.lblDescuento.Text = "descu";
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.AutoSize = true;
            this.lblTotalPagar.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotalPagar.Location = new System.Drawing.Point(151, 41);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Size = new System.Drawing.Size(55, 20);
            this.lblTotalPagar.TabIndex = 60;
            this.lblTotalPagar.Text = "pagar";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 87);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 25);
            this.label8.TabIndex = 52;
            this.label8.Text = "Sub Total";
            // 
            // lblDescuentCash
            // 
            this.lblDescuentCash.AutoSize = true;
            this.lblDescuentCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuentCash.Location = new System.Drawing.Point(266, 41);
            this.lblDescuentCash.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescuentCash.Name = "lblDescuentCash";
            this.lblDescuentCash.Size = new System.Drawing.Size(115, 25);
            this.lblDescuentCash.TabIndex = 51;
            this.lblDescuentCash.Text = "Descuento";
            // 
            // lblTotalPay
            // 
            this.lblTotalPay.AutoSize = true;
            this.lblTotalPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotalPay.Location = new System.Drawing.Point(8, 38);
            this.lblTotalPay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalPay.Name = "lblTotalPay";
            this.lblTotalPay.Size = new System.Drawing.Size(141, 25);
            this.lblTotalPay.TabIndex = 49;
            this.lblTotalPay.Text = "Total a Pagar";
            // 
            // txtEfectivoRecibido
            // 
            this.txtEfectivoRecibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivoRecibido.Location = new System.Drawing.Point(649, 96);
            this.txtEfectivoRecibido.Multiline = true;
            this.txtEfectivoRecibido.Name = "txtEfectivoRecibido";
            this.txtEfectivoRecibido.Size = new System.Drawing.Size(122, 41);
            this.txtEfectivoRecibido.TabIndex = 57;
            this.txtEfectivoRecibido.TextChanged += new System.EventHandler(this.txtEfectivoRecibido_TextChanged);
            this.txtEfectivoRecibido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEfectivoRecibido_KeyDown);
            // 
            // lblGetCashPayInvC
            // 
            this.lblGetCashPayInvC.AutoSize = true;
            this.lblGetCashPayInvC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGetCashPayInvC.Location = new System.Drawing.Point(479, 107);
            this.lblGetCashPayInvC.Name = "lblGetCashPayInvC";
            this.lblGetCashPayInvC.Size = new System.Drawing.Size(149, 20);
            this.lblGetCashPayInvC.TabIndex = 56;
            this.lblGetCashPayInvC.Text = "Efectivo Recibido";
            // 
            // lblMethodPago
            // 
            this.lblMethodPago.AutoSize = true;
            this.lblMethodPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMethodPago.Location = new System.Drawing.Point(809, 48);
            this.lblMethodPago.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMethodPago.Name = "lblMethodPago";
            this.lblMethodPago.Size = new System.Drawing.Size(131, 20);
            this.lblMethodPago.TabIndex = 39;
            this.lblMethodPago.Text = "Forma de Pago";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(519, 450);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(100, 22);
            this.txtValor.TabIndex = 60;
            this.txtValor.Visible = false;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(76, 390);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(95, 22);
            this.txtIdCliente.TabIndex = 59;
            this.txtIdCliente.Visible = false;
            // 
            // chbDescuento
            // 
            this.chbDescuento.AutoSize = true;
            this.chbDescuento.Location = new System.Drawing.Point(658, 466);
            this.chbDescuento.Name = "chbDescuento";
            this.chbDescuento.Size = new System.Drawing.Size(127, 20);
            this.chbDescuento.TabIndex = 58;
            this.chbDescuento.Text = "Descuento (%)";
            this.chbDescuento.UseVisualStyleBackColor = true;
            this.chbDescuento.Visible = false;
            // 
            // btnProcesarPago
            // 
            this.btnProcesarPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcesarPago.Image = global::PL.Properties.Resources.apply;
            this.btnProcesarPago.Location = new System.Drawing.Point(17, 158);
            this.btnProcesarPago.Margin = new System.Windows.Forms.Padding(4);
            this.btnProcesarPago.Name = "btnProcesarPago";
            this.btnProcesarPago.Size = new System.Drawing.Size(72, 52);
            this.btnProcesarPago.TabIndex = 25;
            this.btnProcesarPago.UseVisualStyleBackColor = true;
            this.btnProcesarPago.Click += new System.EventHandler(this.btnProcesarPago_Click);
            // 
            // txtItbis
            // 
            this.txtItbis.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtItbis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtItbis.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItbis.ForeColor = System.Drawing.Color.Green;
            this.txtItbis.Location = new System.Drawing.Point(307, 442);
            this.txtItbis.Margin = new System.Windows.Forms.Padding(4);
            this.txtItbis.Name = "txtItbis";
            this.txtItbis.Size = new System.Drawing.Size(129, 33);
            this.txtItbis.TabIndex = 53;
            // 
            // txtId_Invoice
            // 
            this.txtId_Invoice.Location = new System.Drawing.Point(76, 525);
            this.txtId_Invoice.Name = "txtId_Invoice";
            this.txtId_Invoice.Size = new System.Drawing.Size(95, 22);
            this.txtId_Invoice.TabIndex = 20;
            this.txtId_Invoice.Visible = false;
            // 
            // btnPagar
            // 
            this.btnPagar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPagar.Location = new System.Drawing.Point(649, 401);
            this.btnPagar.Margin = new System.Windows.Forms.Padding(4);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(72, 53);
            this.btnPagar.TabIndex = 21;
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Visible = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(311, 420);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 18);
            this.label9.TabIndex = 50;
            this.label9.Text = "ITBIS";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label21.Location = new System.Drawing.Point(889, -1);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(207, 18);
            this.label21.TabIndex = 41;
            this.label21.Text = "Agregar al Carrito: ENTER";
            this.label21.Visible = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label22.Location = new System.Drawing.Point(409, -1);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(164, 18);
            this.label22.TabIndex = 42;
            this.label22.Text = "Buscar Producto: F6";
            this.label22.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label20.Location = new System.Drawing.Point(36, -1);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(131, 18);
            this.label20.TabIndex = 40;
            this.label20.Text = "Nueva Venta: F2";
            this.label20.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 669);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1302, 22);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(103, 17);
            this.toolStripStatusLabel1.Text = "By Code Solutions";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label23.Location = new System.Drawing.Point(581, -1);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(244, 18);
            this.label23.TabIndex = 43;
            this.label23.Text = "Agregar Producto al Carrito: F4";
            this.label23.Visible = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label24.Location = new System.Drawing.Point(229, -1);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(153, 18);
            this.label24.TabIndex = 44;
            this.label24.Text = "Procesar Venta: F3";
            this.label24.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnNewInvoiceCr);
            this.groupBox2.Controls.Add(this.btnProcInvoiceCr);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.Add(this.btnNuevo);
            this.groupBox2.Controls.Add(this.btnProcesarPago);
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(1121, 353);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(111, 313);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acciones";
            // 
            // btnNewInvoiceCr
            // 
            this.btnNewInvoiceCr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewInvoiceCr.Image = global::PL.Properties.Resources.shopping_cart;
            this.btnNewInvoiceCr.Location = new System.Drawing.Point(16, 35);
            this.btnNewInvoiceCr.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewInvoiceCr.Name = "btnNewInvoiceCr";
            this.btnNewInvoiceCr.Size = new System.Drawing.Size(72, 52);
            this.btnNewInvoiceCr.TabIndex = 57;
            this.btnNewInvoiceCr.UseVisualStyleBackColor = true;
            this.btnNewInvoiceCr.Click += new System.EventHandler(this.btnNewInvoiceCr_Click);
            // 
            // btnProcInvoiceCr
            // 
            this.btnProcInvoiceCr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcInvoiceCr.Image = global::PL.Properties.Resources.apply;
            this.btnProcInvoiceCr.Location = new System.Drawing.Point(48, 158);
            this.btnProcInvoiceCr.Margin = new System.Windows.Forms.Padding(4);
            this.btnProcInvoiceCr.Name = "btnProcInvoiceCr";
            this.btnProcInvoiceCr.Size = new System.Drawing.Size(73, 52);
            this.btnProcInvoiceCr.TabIndex = 56;
            this.btnProcInvoiceCr.UseVisualStyleBackColor = true;
            this.btnProcInvoiceCr.Click += new System.EventHandler(this.btnProcInvoiceCr_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Image = global::PL.Properties.Resources.trash;
            this.btnEliminar.Location = new System.Drawing.Point(16, 218);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(72, 52);
            this.btnEliminar.TabIndex = 24;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.Image = global::PL.Properties.Resources.shopping_cart;
            this.btnNuevo.Location = new System.Drawing.Point(17, 35);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(72, 52);
            this.btnNuevo.TabIndex = 55;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Image = global::PL.Properties.Resources.shopping_cart_full;
            this.btnAgregar.Location = new System.Drawing.Point(16, 98);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(70, 52);
            this.btnAgregar.TabIndex = 54;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtTypeInvoice
            // 
            this.txtTypeInvoice.Location = new System.Drawing.Point(76, 573);
            this.txtTypeInvoice.Name = "txtTypeInvoice";
            this.txtTypeInvoice.Size = new System.Drawing.Size(95, 22);
            this.txtTypeInvoice.TabIndex = 68;
            this.txtTypeInvoice.Visible = false;
            // 
            // txtPermissionId
            // 
            this.txtPermissionId.Location = new System.Drawing.Point(76, 434);
            this.txtPermissionId.Name = "txtPermissionId";
            this.txtPermissionId.Size = new System.Drawing.Size(95, 22);
            this.txtPermissionId.TabIndex = 69;
            this.txtPermissionId.Visible = false;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(76, 481);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(95, 22);
            this.txtUsername.TabIndex = 70;
            this.txtUsername.Visible = false;
            // 
            // txtCreditLimit
            // 
            this.txtCreditLimit.Location = new System.Drawing.Point(76, 615);
            this.txtCreditLimit.Name = "txtCreditLimit";
            this.txtCreditLimit.Size = new System.Drawing.Size(95, 22);
            this.txtCreditLimit.TabIndex = 71;
            this.txtCreditLimit.Visible = false;
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(910, 510);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(100, 22);
            this.txtUserId.TabIndex = 72;
            this.txtUserId.Visible = false;
            // 
            // txtCurrentAmount
            // 
            this.txtCurrentAmount.Location = new System.Drawing.Point(910, 570);
            this.txtCurrentAmount.Name = "txtCurrentAmount";
            this.txtCurrentAmount.Size = new System.Drawing.Size(100, 22);
            this.txtCurrentAmount.TabIndex = 73;
            this.txtCurrentAmount.Visible = false;
            // 
            // txtAmountPast
            // 
            this.txtAmountPast.Location = new System.Drawing.Point(752, 600);
            this.txtAmountPast.Name = "txtAmountPast";
            this.txtAmountPast.Size = new System.Drawing.Size(100, 22);
            this.txtAmountPast.TabIndex = 74;
            this.txtAmountPast.Visible = false;
            // 
            // frmVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 691);
            this.Controls.Add(this.txtAmountPast);
            this.Controls.Add(this.txtCurrentAmount);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.txtCreditLimit);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPermissionId);
            this.Controls.Add(this.txtTypeInvoice);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtIdCliente);
            this.Controls.Add(this.chbDescuento);
            this.Controls.Add(this.txtItbis);
            this.Controls.Add(this.txtId_Invoice);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.label22);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventas al Contado";
            this.Load += new System.EventHandler(this.frmVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnFindCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblMethodPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalPay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDescuentCash;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtItbis;
        private System.Windows.Forms.Label lblCajeroTitle;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.CheckBox chbDescuento;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnProcesarPago;
        public System.Windows.Forms.TextBox txtClientes;
        public System.Windows.Forms.TextBox txtPrecio;
        public System.Windows.Forms.TextBox txtDescripcion;
        public System.Windows.Forms.TextBox txtProductos;
        public System.Windows.Forms.TextBox txtIdCliente;
        public System.Windows.Forms.TextBox txtValor;
        public System.Windows.Forms.TextBox txtDevueltaEfectivo;
        private System.Windows.Forms.Label lblChangeCash;
        public System.Windows.Forms.TextBox txtEfectivoRecibido;
        private System.Windows.Forms.Label lblGetCashPayInvC;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtId_Invoice;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        public System.Windows.Forms.Label lblDescInvoiceCash;
        public System.Windows.Forms.ComboBox cmbDescPostVentaExt;
        private System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.CheckBox chbPrintTicketFact;
        private System.Windows.Forms.Label lblAprobacion;
        private System.Windows.Forms.TextBox txtAprobacionNo;
        public System.Windows.Forms.ComboBox cmbfPagos;
        private System.Windows.Forms.Label lblResDevuelta;
        private System.Windows.Forms.Button btnProcInvoiceCr;
        public System.Windows.Forms.ComboBox cmbCondictionDays;
        public System.Windows.Forms.Label lblCondictionCr;
        public System.Windows.Forms.Button btnNewInvoiceCr;
        public System.Windows.Forms.TextBox txtTypeInvoice;
        public System.Windows.Forms.Label lblCajeroName;
        public System.Windows.Forms.TextBox txtPermissionId;
        public System.Windows.Forms.TextBox txtUsername;
        public System.Windows.Forms.TextBox txtCreditLimit;
        public System.Windows.Forms.TextBox txtUserId;
        public System.Windows.Forms.TextBox txtCurrentAmount;
        public System.Windows.Forms.TextBox txtAmountPast;
    }
}