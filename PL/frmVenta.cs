﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Threading.Tasks;
using System.Windows.Forms;
using pjPalmera.Entities;
using pjPalmera.BLL;
using Entities;

/*
using System.Runtime.Remoting.Messaging;
using System.Runtime.CompilerServices;
using System.Web.UI.WebControls;
using MySqlX.XDevAPI.Relational;
*/

namespace pjPalmera.PL
{
    public partial class frmVenta : Form
    {
        //
        public VentaEntity venta = null;
        // VentaEntity detail = new VentaEntity();
        ProductosEntity producto = new ProductosEntity();
        TransactionsEntity Transactions = new TransactionsEntity();
        public ClientesEntity clientes = new ClientesEntity();

        // 
        frmCobros cobros = new frmCobros();

        //
        public decimal precio = 0;
        public float cantidad = 0;
        public long id;
        public Decimal t_pagar = 0;
        public int _iditem;
        public decimal _importe;
        public decimal _amount;
        public int indx = 0;
        public int id_venta;



        public int Iditem
        {
            get { return _iditem; }
            set { _iditem = value; }
        }

        public decimal Importe
        {
            get { return _importe; }
        }

        public int Id_invoice
        {
            get { return id_venta; }
        }

        public decimal Amount_
        {
            get { return _amount; }        
        }

        public frmVenta()
        {
            InitializeComponent();
        }


        private void frmVenta_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            Limpiar();
            LimpiarEfectivo();
            Deshabilitar();
            this.txtItbis.Visible = false;
            this.label9.Visible = false;
            SetToolControls();
            InitialControls();
            DiscountAverageInvoice();
            this.btnNuevo.Focus();
        }

        private void btnBuscarClientes_Click(object sender, EventArgs e)
        {
            if (txtClientes.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un cliente");
                this.txtClientes.Focus();
                return;
            }

            venta = new VentaEntity();
            dgvDetalle.DataSource = venta.listProductos;
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // InsertItem();  // -------> Old Method
            BuildDataGrid();
            LoadHeadGrid();
            InsertNewItem();   //--------------------> New Method  ----Modificated: 15/04/2020  -  17:35 By:SEC
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                SearchProduct();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

      
        private void timer1_Tick(object sender, EventArgs e)
        {
            label14.Text = DateTime.Now.ToString("hh:mm:ss tt");
            label15.Text = DateTime.Now.ToLongDateString();
        }

        /// <summary>
        /// Total Pagar   (Old code)
        /// </summary>
        public void SetPagar()
        {

            decimal subtotal, itbis, t_pagar, descuento;
            subtotal = venta.SubTotal();
            // itbis = venta.Itbis();
            itbis = 0;
            descuento = venta.Descuento(subtotal);
            t_pagar = venta.Pagar(subtotal);

            this.lblSubtotal.Text = Convert.ToString(subtotal);
            this.txtItbis.Text = Convert.ToString(itbis);
            this.lblTotalPagar.Text = string.Format("{0}", t_pagar);
            this.lblDescuento.Text = Convert.ToString(descuento);
        }

        /// <summary>
        /// Initialize All Controls
        /// </summary>
        private void InitialControls()
        {
            //
            // this.BackColor = Color.AliceBlue;

            //BackColor
           // this.txtApClientes.BackColor = Color.Bisque;
            this.txtClientes.BackColor = Color.Bisque;
            this.txtProductos.BackColor = Color.Bisque;
            this.txtDescripcion.BackColor = Color.Bisque;
            this.txtPrecio.BackColor = Color.Bisque;
            this.txtCantidad.BackColor = Color.Bisque;
            this.cmbDescPostVentaExt.BackColor = Color.Bisque;
            this.dgvDetalle.DefaultCellStyle.BackColor = Color.Bisque;

            //ForeColor
          //  this.txtApClientes.ForeColor = Color.Maroon;
            this.txtClientes.ForeColor = Color.Maroon;
            this.txtProductos.ForeColor = Color.Maroon;
            this.txtDescripcion.ForeColor = Color.Maroon;
            this.txtPrecio.ForeColor = Color.Maroon;
            this.txtCantidad.ForeColor = Color.Maroon;
            this.cmbDescPostVentaExt.ForeColor = Color.Maroon;
            this.dgvDetalle.ForeColor = Color.Maroon;
        }


        private void btnPagar_Click(object sender, EventArgs e)
        {
         //   cobrar.ShowDialog(this);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Validate if DataSource is diferent to Null, In case is true nothing do, but in case false remove item selected from the list
            var answer = MessageBox.Show("Seguro que desea eliminar el Producto del Carrito", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (this.dgvDetalle.Rows.Count == 0)
            {
                MessageBox.Show("No hay Productos que Eliminar del Carrito", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtProductos.Focus();
                return;
            }
            else if (answer == DialogResult.Yes)
            {
                RemoveItems();
               // RemoveItem();
                MessageBox.Show("Se Eliminó el Producto del Carrito", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtProductos.Focus();
            }

            else 
            {
                this.txtProductos.Focus();
                return;
            }

        }

        private void btnBuscarClientes_Click_1(object sender, EventArgs e)
        {

            try
            {
                SearchCostumer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidatorPost())
                return;

                _amount = Convert.ToDecimal(this.lblTotalPagar.Text);
                // cobros.txtTotalCobrar.Text = this.Amount_.ToString();
                cobros.lblTotalCobrar.Text = this.Amount_.ToString();
                cobros.ShowDialog(this);
                // ProcessSell();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        private void txtEfectivoRecibido_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal efectivo, cobrar;
                cobrar = decimal.Parse(this.lblTotalPagar.Text);
                efectivo = decimal.Parse(this.txtEfectivoRecibido.Text);
                this.txtDevueltaEfectivo.Text = Convert.ToString(efectivo - cobrar);
            }
            catch
            {
                this.txtDevueltaEfectivo.Text = "";
                this.txtEfectivoRecibido.Focus();
            }
        }

        private void cmbDescuentoPostVenta_TextChanged(object sender, EventArgs e)
        {
            try
            {
               this.txtPrecio.Text = Convert.ToString(venta.SetDescountInvoice(Convert.ToDecimal(this.txtPrecio.Text), +
                   Convert.ToDecimal(this.cmbDescPostVentaExt.Text)));
            }
            catch
            {
                return;
              
            }
        }

        /// <summary>
        /// Validator Post Pay
        /// </summary>
        public bool ValidatorPost()
        {
            var cash = cobros.txtEfectivoRecibido.Text;
            var type_pay = cobros.cmbfPagos.Text;
            var tpay = new type_payEntity();

            bool resul = true;

            if (this.lblTotalPagar.Text == "0.00")
            {
                MessageBox.Show("No se puede procesar la venta. Debe Efectuar una antes.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnNuevo.Focus();
                resul = false;
            }

            if (type_pay == tpay.getMethod(0).ToString())
            {
                 if (( cash == string.Empty) && (cash == "0.00"))
                 {
                    MessageBox.Show("Indicar el efectivo recibido por el cliente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cobros.txtTotalCobrar.Focus();
                    resul = false;
                 }
            }

            return resul;
        }


        /// <summary>
        /// Clear Textbox
        /// </summary>
        private void Limpiar()
        {
            //this.txtClientes.Clear();
            this.txtProductos.Clear();
            this.txtDescripcion.Clear();
            this.txtPrecio.Clear();
            this.txtCantidad.Clear();
            this.cmbDescPostVentaExt.Text = "";
            //this.lblDescuento.Clear();
            //this.lblTotalPagar.Clear();
            // this.txtItbis.Clear();
        }

        /// <summary>
        /// Deshabilita TextBox, Buttons
        /// </summary>
        private void Deshabilitar()
        {
            this.txtClientes.Enabled = false;
            this.txtCantidad.Enabled = false;
            this.txtPrecio.Enabled = false;
            this.txtProductos.Enabled = false;
            this.btnAgregar.Enabled = false;
            this.btnPagar.Enabled = false;
           // this.btnNuevo.Enabled = false;
            this.cmbTipoVenta.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.txtItbis.Enabled = false;
            this.lblDescuento.Enabled = false;
            this.lblTotalPagar.Enabled = false;
            this.lblSubtotal.Enabled = false;
            this.chbDescuento.Enabled = false;
            this.btnBuscarProducto.Enabled = false;
            this.btnBuscarClientes.Enabled = false;
            this.btnEliminar.Enabled = false;
           // this.txtApClientes.Enabled = false;
            this.btnGuardar.Enabled = false;
            this.txtEfectivoRecibido.Enabled = false;
            this.txtDevueltaEfectivo.Enabled = false;
            this.cmbDescPostVentaExt.Enabled = false;
        }

        /// <summary>
        /// Enable TextBox, Buttons
        /// </summary>
        private void Habilitar()
        {
            this.txtClientes.Enabled = true;
            this.txtCantidad.Enabled = true;
            this.txtPrecio.Enabled = true;
            this.txtProductos.Enabled = true;
            this.btnAgregar.Enabled = true;
            this.btnPagar.Enabled = true;
            this.cmbTipoVenta.Enabled = true;
            this.txtDescripcion.Enabled = true;
            this.txtItbis.Enabled = true;
            this.lblDescuento.Enabled = true;
            this.lblTotalPagar.Enabled = true;
            this.lblSubtotal.Enabled = true;
            this.lblDescuento.Enabled = true;
            // this.btnNuevo.Enabled = true;
            this.btnBuscarProducto.Enabled = true;
            this.btnBuscarClientes.Enabled = true;
            this.btnEliminar.Enabled = true;
         //   this.txtApClientes.Enabled = true;
            this.btnGuardar.Enabled = true;
            this.txtEfectivoRecibido.Enabled = true;
            this.txtDevueltaEfectivo.Enabled = true;
            this.cmbDescPostVentaExt.Enabled = true;
        }


        /// <summary>
        /// Loop until x value, and average descount
        /// </summary>
        private void DiscountAverageInvoice()
        {
            int x = 100;
            for (int i = 1; i <= x; i++)
            {
                this.cmbDescPostVentaExt.Items.Add(i);
            }
        }

        /// <summary>
        /// Change ReadOnly TextBox
        /// </summary>
        private void OnlyRead()
        {
            this.txtItbis.ReadOnly = true;
           // this.txtApClientes.ReadOnly = true;
            this.txtClientes.ReadOnly = true;
            this.txtDevueltaEfectivo.ReadOnly = true;
            this.txtPrecio.ReadOnly = true;
            this.txtDescripcion.ReadOnly = true;
           this.dgvDetalle.ReadOnly = true;
        }

        #region Pagar
        /// <summary>
        /// Pay Process 
        /// </summary>
        private void Pagar()
        {
            Limpiar();
            OnlyRead();
            this.txtClientes.Clear();
            this.cmbTipoVenta.Text = "";
            this.dgvDetalle.DataSource = null;
            LimpiarEfectivo();
            this.cmbTipoVenta.Focus();
        }
        #endregion

        #region RemoveItems --> New Code (Current in use) -- Modificated: 17/04/2020  - 1:53
        /// <summary>
        /// Remove Items from DataGridView  (New Code)---> Pendding 
        /// </summary>
        private void RemoveItems()
        {
            DataGridViewRow x = this.dgvDetalle.CurrentRow; // Get current containing Cell
            int i = this.dgvDetalle.RowCount; // Get/Set DataGridviwe rows has
            int ci = this.dgvDetalle.CurrentRow.Index; // Current row index
            decimal result; 

            if (this.dgvDetalle.CurrentRow.Index != -1)
            {
                try
                {
                    _importe = Convert.ToDecimal(this.dgvDetalle.Rows[x.Index].Cells[4].Value);

                    result = OpServices.UpdateSubAmount(Convert.ToDecimal(this.lblSubtotal.Text), Convert.ToDecimal(this.Importe));
                    this.lblSubtotal.Text = Convert.ToString(result);
                    this.lblTotalPagar.Text= Convert.ToString(OpServices.UpdateAmount(result));
                    this.lblDescuento.Text= Convert.ToString(OpServices.UpdateDescountAmount(result));

                    this.dgvDetalle.Rows.RemoveAt(ci);
                   // i--;

                }
                catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
            }
            else
                {
                    return;           
                }

        } 
        #endregion


        #region RemoveItems --> Old Code 
        /// <summary>
        /// Remove Items from the Grid -- Old Code  (Will to work in future this section)
        /// </summary>
        private void RemoveItem()
        {
            DataGridViewRow x = this.dgvDetalle.CurrentRow;
            var n = this.dgvDetalle.RowCount;

            var list = venta.listProductos;

            _iditem = Convert.ToInt32(this.dgvDetalle.Rows[x.Index].Cells["No"].Value);   // -------------------->
            _importe = Convert.ToDecimal(this.dgvDetalle.Rows[x.Index].Cells["IMPORTE"].Value);
            decimal subtotal, diferencia, descuento, total, tdescuento, rdescuento, pdescuento;
            total = Convert.ToDecimal(this.lblTotalPagar.Text);
            subtotal = Convert.ToDecimal(this.lblDescuento.Text);
            descuento = Convert.ToDecimal(this.lblDescuento.Text);


            try
            {
                if (this.dgvDetalle.CurrentRow.Index != -1)
                {                                                                   // ------------------> Verify logic code (possible use iteration (For))
                     //Remove Row from list

                    venta.RemoveItem(this.Iditem);
                    
                    this.dgvDetalle.Parent.Refresh();
                    this.dgvDetalle.Refresh();
                    diferencia = subtotal - this.Importe; // Subtract amount by item in list
                    tdescuento = total - diferencia; // not important this line
                    pdescuento = (diferencia * 10) / 100;
                    rdescuento = diferencia - pdescuento;
                    this.lblTotalPagar.Text = Convert.ToString(rdescuento); //Refrest Amount after remove item from the list
                    this.lblDescuento.Text = Convert.ToString(diferencia); // Refrest Sub Amount after remove item from the list 
                    this.lblDescuento.Text = Convert.ToString(pdescuento); // Refrest  Descount  Amount  after remove item from the list          
                }
                else
                {
                    // MessageBox.Show("Seleccione el Elemento que desea Eliminar del Carrito", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.txtProductos.Focus();
                    return;
                }
            }
            catch
            {

            }


        } 
        #endregion

        /// <summary>
        /// Clean labels
        /// </summary>
        private void LimpiarEfectivo()
        {

            this.txtDevueltaEfectivo.Text = "";
            this.txtEfectivoRecibido.Text = "";
            this.cmbDescPostVentaExt.Text = "";
            //this.txtRecibidoEfectivo.Text = "";
            this.lblTotalPagar.Text = "0.00";
            this.txtItbis.Text = "0.00";
            this.lblSubtotal.Text = "0.00";
            this.lblDescuento.Text = "0.00";
            // this.txtRecibidoEfectivo.Text="0.0";
        }

        /// <summary>
        /// Prepare for New Invoice   -- Modificated: 16/04/2020, 10:55.
        /// </summary>
        public void NewInvoice()
        {
            Habilitar();
            Limpiar();
            //LimpiarEfectivo();
            OnlyRead();
            // BuildDataGrid();    // ----> New Method  to Initial DataGridView
            // LoadHeadGrid();     // ----> New Method to Initial Head in DataGridView
            this.txtClientes.Text = "CONTADO";
            // this.txtApClientes.Text = "CONTADO";
            this.txtIdCliente.Text = "1";
            venta = new VentaEntity(); //Head invoice
            this.dgvDetalle.Rows.Clear();
            this.txtProductos.Focus();
        }


        /// <summary>
        /// DataGrid Initialitation
        /// </summary>
        private void BuildDataGrid()
        {
            this.Controls.Add(this.dgvDetalle);
            this.dgvDetalle.ColumnCount = 5;
        }

        /// <summary>
        /// Load Head on GridView Item for Invoices
        /// </summary>
        private void LoadHeadGrid()
        {
            //Header Text
            //---------------------------------------------------
          //  this.dgvDetalle.Columns[0].HeaderText = "No";
            this.dgvDetalle.Columns[0].HeaderText = "CODIGO";
            this.dgvDetalle.Columns[1].HeaderText = "DESCRIPCION";
            this.dgvDetalle.Columns[2].HeaderText = "CANTIDAD";
            this.dgvDetalle.Columns[3].HeaderText = "PRECIO";
            //this.dgvDetalle.Columns[4].HeaderText = "ITBIS";
            this.dgvDetalle.Columns[4].HeaderText = "IMPORTE";


            //Columns Width 
            // -------------------------------------------------
            //this.dgvDetalle.Columns[0].Width = 10;
            //this.dgvDetalle.Columns[1].Width = 10;  
            //this.dgvDetalle.Columns[2].Width = 10;
            //this.dgvDetalle.Columns[3].Width = 10;
            //this.dgvDetalle.Columns[4].Width = 10;  <-----
            //this.dgvDetalle.Columns[5].Width = 15;
        }

       

        /// <summary>
        /// Search Costumer from ConsultClientes by Id
        /// </summary>
        private void SearchCostumer()
        {
            frmConsulClientes Con_Clientes = new frmConsulClientes();

            if (Con_Clientes.ShowDialog() == DialogResult.OK)
            {
              //  clientes = ClientesBO.GetbyId(Con_Clientes.Orden);

                this.txtIdCliente.Text = Convert.ToString(Con_Clientes.Orden);
                this.txtClientes.Text = clientes.Nombre;
               // this.txtApClientes.Text = clientes.Apellidos;
                this.txtProductos.Focus(); //
            }
        }

        /// <summary>
        /// Search Product from ConsulProductos by Id
        /// </summary>
        public void SearchProduct()
        {
            try
            {
                frmConsultarProductos consulProductos = new frmConsultarProductos();
                consulProductos.IniControls();
                consulProductos.FilterProduct();


                if (consulProductos.ShowDialog() == DialogResult.OK )
                {
                    producto = ProductosBO.SearchByOrden(consulProductos.Orden);

                    this.txtProductos.Text = Convert.ToString(producto.Codigo);
                    this.txtDescripcion.Text = producto.Descripcion;
                    this.txtPrecio.Text = Convert.ToString(producto.Precio_venta);
                    this.txtCantidad.Focus();
                }
            }
            catch
            {

               
            }
        }

        /// <summary>
        /// Searh Product from Ventas by Code
        /// </summary>
        public void SearchProductByCode(Int64 code)
        {
           ProductosEntity producto = new ProductosEntity();

            if (producto != null)
            {
                ProductosBO.SearchByCode(code);   //Search Product Code Number become with this.

                producto.Codigo = Convert.ToInt64(this.txtProductos.Text);
                this.txtDescripcion.Text = producto.Descripcion;
                this.txtPrecio.Text = Convert.ToString(producto.Precio_venta);
                this.txtCantidad.Focus();
            }
            
        }


        #region Process_Selling
        /// <summary>
        /// All Steps for Process one Sell
        /// </summary>
        public void ProcessSell()
        {
            TicketVentaEntity caja = new TicketVentaEntity();
            var Answer = new DialogResult();

            //if (!ValidatorPost())
            //    return;

            Answer = MessageBox.Show("Imprimir Recibo", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Answer == DialogResult.Yes)
            {
                CreateInvoice();
                PrintTicket();
                FacturaBO.DeleteEmptyRow();
                // MessageBox.Show("Se Imprimio Recibo", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Venta Procesada", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NewInvoice();
                LimpiarEfectivo();
                Limpiar();
                this.txtProductos.Focus();
            }
            else if (Answer == DialogResult.No)
            {
                CreateInvoice();
                FacturaBO.DeleteEmptyRow();
                caja.AbreCajon();
                //  MessageBox.Show("No se Imprimio Recibo", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Venta Procesada", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NewInvoice();
                LimpiarEfectivo();
                Limpiar();
                this.txtProductos.Focus();
            }
        } 
        #endregion

        #region Invoice paid cash
        /// <summary>
        /// Print Bill
        /// </summary>
        /// Bill print Setting
        /// Author: Samuel Estrella
        /// Date: 17/01/2020
        public void PrintTicket()
        {

            //Parameters
            PrintDocument pd = new PrintDocument();
            PaperSize pz = new PaperSize("", 420, 520);
            pd.PrintPage += Pd_PrintPage;

            pd.PrintController = new StandardPrintController();

            pd.DefaultPageSettings.Margins.Left = 0;

            pd.DefaultPageSettings.Margins.Right = 0;

            pd.DefaultPageSettings.Margins.Top = 0;

            pd.DefaultPageSettings.Margins.Bottom = 0;


            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Bill Cash Header, Detail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            // TicketVentaEntity tk = new TicketVentaEntity();
            // Parameters
            Font fBody = new Font("Lucida Console", 8, FontStyle.Regular);// Format Font for Body
            Font ffTitle = new Font("Lucida Console", 11, FontStyle.Bold); // Format Font for Title Company Name
            Font fTitle = new Font("Lucida Console", 8, FontStyle.Bold); // Format Font for Title
            Font fdpTitle = new Font("Lucida Console", 8, FontStyle.Regular); // Format Font Detail Products
            Font fpTitle = new Font("Lucida Console", 8, FontStyle.Bold); // Format Font Title Amount
            Font fpBody = new Font("Lucida Console", 8, FontStyle.Bold);// Format number Amount
            Font tbottom = new Font("Lucida Console", 6, FontStyle.Regular); // Format Font Messege Bottom
            Font tblank = new Font("Lucida Console", 19, FontStyle.Bold); // Format Font  Bottom
            Font fdTitle = new Font("Lucida Console", 8, FontStyle.Regular); // Format Font for Detail Title (Address,Telephone, etc.. About Company Information)
            Graphics g = e.Graphics;
            SolidBrush sb = new SolidBrush(Color.Black); // Set Brush color for Drawing Charaters

            string Type = "FACTURA AL CONTADO";

            //Id Invoice
            
            this.txtId_Invoice.Text = Convert.ToString(Id_invoice);

            RawPrinterHelper j = new RawPrinterHelper(); //

            // Header invoice
            
            //int AutoScrollOffset1= -100;
            //AutoScrollOffset1 = AutoScrollOffset1 -100;
            g.DrawString("Farmacia CRM", ffTitle, sb, 75, 120);
            g.DrawString("Donde tu Salud es Nuestra Prioridad", fTitle, sb, 20, 134);
            g.DrawString("C/9, #15, Las Escobas, Jima Arriba", fdTitle, sb, 27, 148);
            g.DrawString("RNC:80700148433", fdTitle, sb, 80, 160);
            g.DrawString("Tel: 809-954-9952", fdTitle, sb, 80, 175);
            g.DrawString("Whatsapp:809-851-2775", fdTitle, sb, 70, 185);

            g.DrawString("FECHA:", fTitle, sb, 10, 210);
            g.DrawString(DateTime.Now.ToShortDateString(), fBody, sb, 80, 210);
            g.DrawString("HORA:", fTitle, sb, 155, 210);
            g.DrawString(DateTime.Now.ToShortTimeString(), fBody, sb, 195, 210);
            g.DrawString("CLIENTE:", fTitle, sb, 10, 220);
            g.DrawString(this.txtClientes.Text, fBody, sb, 80, 220);
           // g.DrawString(this.txtApClientes.Text, fBody, sb, 180, 220);
            g.DrawString("NCF:", fTitle, sb, 10, 232);
            g.DrawString("NIF:", fTitle, sb, 10, 244);
            g.DrawString(this.txtId_Invoice.Text, fBody, sb, 50, 244);

            if (this.txtClientes.Text != "CONTADO") 
            {
                Type = "FACTURA A CONTADO";
            }

            g.DrawString(Type, fTitle, sb, 75, 255);

            // Detail Invoice
            g.DrawString("----------------------------------------", fBody, sb, 5, 280);
            g.DrawString("DESCRIPCION        CANT  PRECIO IMPORTE ", fdpTitle, sb, 10, 290);
            g.DrawString("----------------------------------------", fBody, sb, 5, 298);
            int AutoScrollOffset = +14;

            int a = this.dgvDetalle.Rows.Count;

            for (int i = 0; i < a; i++)
            {
                //g.DrawString(Convert.ToString(this.dgvDetalle.Rows[i].Cells[0].Value), fdpTitle, sb, 5, 305 + AutoScrollOffset);
                g.DrawString(Convert.ToString(this.dgvDetalle.Rows[i].Cells[1].Value), fdpTitle, sb, 5, 305 + AutoScrollOffset); //Description
                g.DrawString(Convert.ToString(this.dgvDetalle.Rows[i].Cells[2].Value), fdpTitle, sb, 153, 305 + AutoScrollOffset); //Quality
                g.DrawString(Convert.ToString(this.dgvDetalle.Rows[i].Cells[3].Value), fdpTitle, sb, 178, 305 + AutoScrollOffset);// Price
                g.DrawString(Convert.ToString(this.dgvDetalle.Rows[i].Cells[4].Value), fpTitle, sb, 225, 305 + AutoScrollOffset); // Total Price x Unit
                AutoScrollOffset = AutoScrollOffset + 12;
            }

            // Paid Detail
            AutoScrollOffset = AutoScrollOffset + 12;
            g.DrawString("SubTotal:", fdpTitle, sb, 100, 330 + AutoScrollOffset);   // 
            g.DrawString(this.lblDescuento.Text, fBody, sb, 200, 330 + AutoScrollOffset);  //
            g.DrawString("Descuento:", fdpTitle, sb, 100, 350 + AutoScrollOffset); 
            g.DrawString(this.lblDescuento.Text, fBody, sb, 200, 350 + AutoScrollOffset); //
            g.DrawString("Total a Pagar:", fpTitle, sb, 100, 368 + AutoScrollOffset); //
            g.DrawString(this.lblTotalPagar.Text, fpBody, sb, 200, 368 + AutoScrollOffset);  //
            g.DrawString("", fdpTitle, sb, 100, 370 + AutoScrollOffset);
            g.DrawString("Recibido:", fdpTitle, sb, 100, 389 + AutoScrollOffset); //
            g.DrawString(cobros.getRecibido.ToString(), fBody, sb, 200, 389 + AutoScrollOffset); //
            g.DrawString("Devuelta:", fdpTitle, sb, 100, 405 + AutoScrollOffset); //
            g.DrawString(cobros.getDevuelta.ToString(), fBody, sb, 200, 405 + AutoScrollOffset); //

            // Feet Messenge
            AutoScrollOffset = AutoScrollOffset + 8;
            g.DrawString("Le Atendio:", fBody, sb, 5, 420 + AutoScrollOffset);
            g.DrawString("Alexander Evangelista", fpBody, sb, 100, 420 + AutoScrollOffset);
            g.DrawString("Nota: no hacemos devoluciones después de la 24 horas,", tbottom, sb, 5, 440 + AutoScrollOffset);
            g.DrawString("y mucho menos si los medicamentos se encuentran en", tbottom, sb, 5, 450 + AutoScrollOffset);
            g.DrawString("mal estado.", tbottom, sb, 5, 460 + AutoScrollOffset);

            g.DrawString("Tú eres la persona más linda que Jesús", fTitle, sb, 5, 480 + AutoScrollOffset);
            g.DrawString("tiene en este mundo Buscale.", fTitle, sb, 5, 495 + AutoScrollOffset);

            g.DrawString(".", tblank, sb, 5, 505 + AutoScrollOffset);
            // 
        }
        #endregion

        #region Validator content in Controls
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Validator()
        {
            bool result = true;

            if (venta == null)
            {
                MessageBox.Show("Debe ingresar un cliente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtClientes.Focus();
                result = false;
            }

            if (this.txtProductos.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un Producto", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtProductos.Focus();
                result = false;
            }


            if (!long.TryParse(txtProductos.Text, out id))
            {
                MessageBox.Show("Debe ingresar un Codigo numerico", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtProductos.Focus();
                result = false;
            }

            if (id <= 0)
            {
                MessageBox.Show("Debe ingresar un Codigo Valido", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtProductos.Focus();
                result = false;
            }


            if (this.txtDescripcion.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar una Descripcion", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              //  this.txtDescripcion.Focus();
                result = false;
            }

            if (this.txtCantidad.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar una cantidad", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCantidad.Focus();
                result = false;
            }


            if (!float.TryParse(txtCantidad.Text, out cantidad))
            {
                MessageBox.Show("Debe ingresar una cantidad numerica", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCantidad.Focus();
                result = false;
            }

            if (cantidad <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad mayor que 0", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCantidad.Focus();
                result = false;
            }

            if (this.txtPrecio.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un precio", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               // this.txtPrecio.Focus();
                result = false;
            }


            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Debe ingresar un precio valido", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              //  this.txtCantidad.Focus();
                result = false;
            }

            if (precio <= 0)
            {
                MessageBox.Show("Debe ingresar un precio mayor que 0", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              //  this.txtPrecio.Focus();
                result = false;
            }
           // this.txtProductos.Focus();
            return result;
        }
        #endregion

        #region Insert Rows on the List  (New Code) ---> Modificated: 16/04/2020 - 15:45  
        /// <summary>
        /// Insert Item on the List  (New Code)  
        /// </summary>
        public void InsertNewItem()
        {
            var venta = new VentaEntity();
            var stock = ProductosBO.getStock(Convert.ToInt64(this.txtProductos.Text));
            var quantity = decimal.Parse(this.txtCantidad.Text);
            var evStockQuantity = ProductosBO.getStockQuantity(stock, quantity);


            if (!Validator())
                return;


            if (evStockQuantity == true)
            {
                MessageBox.Show(ProductosBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCantidad.Focus();
            }
            else if (evStockQuantity == false)
            {
                try
                {
                    decimal importT, amount = 0;
                    int x = this.dgvDetalle.RowCount;

                    for (int i = 1; i > x; i++)
                    {
                        x = x++;
                    }

                    importT = venta.ProductValue(Convert.ToDecimal(this.txtCantidad.Text), Convert.ToDecimal(this.txtPrecio.Text));
                    this.dgvDetalle.Rows.Add(this.txtProductos.Text, this.txtDescripcion.Text, this.txtCantidad.Text, this.txtPrecio.Text, importT);

                    ////Add prices all elements in list
                    foreach (DataGridViewRow row in this.dgvDetalle.Rows)
                    {
                        amount += Convert.ToDecimal(row.Cells[4].Value);
                    }

                    this.lblSubtotal.Text = Convert.ToString(amount);
                    this.lblDescuento.Text = Convert.ToString(venta.Descuento(amount));
                    this.lblTotalPagar.Text = Convert.ToString(venta.Pagar(amount));

                    Limpiar();
                    this.txtProductos.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        #endregion

        #region Insert item the list (Old Code for this Process, Note: It's functional)
        /// <summary>
        /// Insert Item to list
        /// </summary>
        public void InsertItem()
        {
            try
            {
                if (!Validator())
                    return;

                //add products to Gridview
                DetalleVentaEntity Detail = new DetalleVentaEntity();
                //var list = new List<DetalleVentaEntity>();
                var list = venta.listProductos; // Products list 

                int x = this.dgvDetalle.RowCount;
               
                for (int i= 0; i <= list.Count; i++)  
                {
                    indx=i;
                }

              //  Detail.No = indx; // Index in list    ------------------>> Done, but it's verification process   -- Last Modificated: 13/05/2020, by: Samuel Estrella
                Detail.CODIGO = Convert.ToInt64(txtProductos.Text);
                Detail.DESCRIPCION = txtDescripcion.Text;
                Detail.CANTIDAD = Int32.Parse(this.txtCantidad.Text);
                Detail.PRECIO = decimal.Parse(this.txtPrecio.Text);
                dgvDetalle.DataSource = null;
                venta.addProduct(Detail);
                dgvDetalle.DataSource = venta.listProductos;  //Data from List to DataGridView


                //DataGridViewColumn Column = this.dgvDetalle.Columns[0];
                //Column.Visible = false;

                SetPagar();
                Limpiar();
                this.txtProductos.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region Save Invoice Old Code Not Functional

        /// <summary>
        /// Save Invoices Head and Detail
        /// </summary>
        public void Save_Invoices()
        {
            CreateInvoice();   //------------------------> Here Work
            //Save_Head();
            //Save_Detail();
           // UpdateStock();
           // Save_Transactions();
        }

        #region New Create Invoice code

        enum Type_invoices { cash=1, credit = 2 }

        /// <summary>
        ///  Code Create Invoice (New Process)
        /// </summary>
        /// 
        public void CreateInvoice()
        {
            int x = this.dgvDetalle.Rows.Count; // Rows counter in DataGridView Items List

            int status = 1;
            //var c = 1;
            
            try
            {
                var ventas = new VentaEntity();

                // Validate type of Invoices (Cash or Credit) --> In this case is Cash
                if (this.txtClientes.Text == "CONTADO")
                {
                    ventas.id_caja = 1;
                    ventas.id_vendedor = 1;
                    ventas.tipo = ventas.set_Type_invoice(Convert.ToString(Type_invoices.cash));
                    ventas.id_cliente = Convert.ToInt32(this.txtIdCliente.Text);
                    ventas.clientes = this.txtClientes.Text; //
                    // ventas.apellidos = this.txtApClientes.Text; //
                    ventas.total = decimal.Parse(this.lblTotalPagar.Text); //
                    ventas.status = status; //
                    ventas.descuento = decimal.Parse(this.lblDescuento.Text); //
                    ventas.subtotal = decimal.Parse(this.lblSubtotal.Text); //
                    ventas.total_itbis = decimal.Parse(this.txtItbis.Text); //
                    ventas.recibido = decimal.Parse(cobros.getRecibido.ToString()); //
                    ventas.devuelta = decimal.Parse(cobros.getDevuelta.ToString()); //
                    ventas.method_pago = (Int32) cobros.cmbfPagos.SelectedValue;
                    //ventas.method_pago = cobros.getTypePay; //


                    for (int i = 0; i < x; i++)
                    { 
                        var Detail = new DetalleVentaEntity();

                        Detail.CODIGO = Convert.ToInt64(this.dgvDetalle.Rows[i].Cells[0].Value); // Id
                        Detail.DESCRIPCION = Convert.ToString(this.dgvDetalle.Rows[i].Cells[1].Value); // Description
                        Detail.CANTIDAD = Convert.ToInt32(this.dgvDetalle.Rows[i].Cells[2].Value); // Quantity
                        Detail.PRECIO = Convert.ToDecimal(this.dgvDetalle.Rows[i].Cells[3].Value); // Price
                        // Detail.ITBIS = Convert.ToDecimal(this.dgvDetalle.Rows[i].Cells["ITBIS"].Value); // Itbis
                        Detail.IMPORTE = Convert.ToDecimal(this.dgvDetalle.Rows[i].Cells[4].Value); // amount 

                        ventas.addProduct(Detail);
                    }

                    FacturaBO.CreateInvoice(ventas);  // Cash Invoices (Save history all invoices)            -----------> Here Continue to Work
                    ProductosBO.Decrease_Stock(ventas); // Decrease Stock 
                    FacturaBO.CreateTranst(ventas);
                    id_venta = ventas.id;
                }
                //else if ((this.txtClientes.Text != "CONTADO") || (this.txtClientes.Text != "Contado") || (this.txtClientes.Text != "contado"))
                //{
                    
                //    venta.tipo = ventas.set_Type_invoice(Convert.ToString(Type_invoices.credit));
                //    var id = Convert.ToInt32(this.txtIdCliente.Text);

                //    for (int i = 0; i < x; i++)
                //    {
                //        var Detail = new DetalleVentaEntity();

                //        Detail.CODIGO = Convert.ToInt64(this.dgvDetalle.Rows[i].Cells[0].Value); //Id
                //        Detail.DESCRIPCION = this.dgvDetalle.Rows[i].Cells[1].Value.ToString(); //Description
                //        Detail.CANTIDAD = Convert.ToInt32(this.dgvDetalle.Rows[i].Cells[2].Value); //Quality
                //        Detail.PRECIO = Convert.ToDecimal(this.dgvDetalle.Rows[i].Cells[3].Value); //Price
                //        //Detail.ITBIS = Convert.ToDecimal(this.dgvDetalle.Rows[i].Cells[5].Value.ToString()); //Itbis
                //        Detail.IMPORTE = Convert.ToDecimal(this.dgvDetalle.Rows[i].Cells[4].Value); //amount      

                //        venta.addProduct(Detail);
                //    }

                //    FacturaBO.CreateInvoice(ventas);  // Cash Invoices (Save history all invoices)            -----------> Here Continue to Work
                //                                      ////  CuentasBO.StatusCxc(c, id); // Set value cxc to client  
                //                                      //// FacturaBO.Create(venta); // Save all invoices
                //                                      ////  FacturaBO.CreateCr(venta); // Credit Invoices
                //}

                    /*-----------------------------------------------------------------------------------------------*/

                }
            catch (Exception)
            {
                MessageBox.Show("Error " + FacturaBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

           
        }
        #endregion

       
        /// <summary>
        /// Update Decrease    
        /// </summary>
        /// 
        public void UpdateStock()
        {
            try
            {
                DetalleVentaEntity Detail = new DetalleVentaEntity();

                int x = this.dgvDetalle.Rows.Count;

                for (int i = 0; i < x; i++)
                {
                    Detail.CODIGO = Convert.ToInt64(this.dgvDetalle.Rows[i].Cells[0].Value); //Id_product
                    Detail.CANTIDAD = Convert.ToInt32(this.dgvDetalle.Rows[i].Cells[2].Value); //Quality
                }

                ProductosBO.Decrease_Stock(venta);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        /// <summary>
        /// Save Transactions in Invoices
        /// </summary>
        public void Save_Transactions()
        {
            int status = 1;
            Transactions = new TransactionsEntity();

            Transactions.Status = status;
            Transactions.Total = Convert.ToDecimal(this.lblTotalPagar.Text);
            Transactions.Descuento = Convert.ToDecimal(this.lblDescuento.Text);
            Transactions.Devuelta = Convert.ToDecimal(this.txtDevueltaEfectivo.Text);
            Transactions.Recibido =Convert.ToDecimal (this.txtEfectivoRecibido.Text);

            if (this.txtClientes.Text == "CONTADO") 
            {
                venta.tipo = "1";
            }
            else
            {
                venta.tipo = "2";
            }

            //TransactionsBO.CreateTranst(Transactions);
        }

        #endregion

        #region Set Detail of Controls
        /// <summary>
        /// Set Detail about controls
        /// </summary>
        private void SetToolControls()
        {
            this.toolTip1.SetToolTip(this.btnBuscarClientes, "Buscar Clientes");
            this.toolTip1.SetToolTip(this.btnBuscarProducto, "Buscar Productos");
            this.toolTip1.SetToolTip(this.btnNuevo, "Limpia de los campos de cliente, y producto a ser agregados");
            this.toolTip1.SetToolTip(this.btnEliminar, "Eliminar item del carro de compra");
            this.toolTip1.SetToolTip(this.btnPagar, "Efectuar pago de la compra ");
            this.toolTip1.SetToolTip(this.btnAgregar, "Agregar Items a la compra");
            this.toolTip1.SetToolTip(this.btnNuevo, "Crear Nueva Venta");
            this.toolTip1.SetToolTip(this.btnGuardar, "Guardar Compra");
        }



        #endregion

        #region Descuento

        ///private void chbDescuento_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        decimal descuento, td_pagar, tpagar;
        //        decimal total_pagar, t_itbis, t_itbis_c_pagar;

        //        total_pagar = venta.Pagar(itbis, );
        //        t_itbis = venta.Itbis();
        //        tpagar = venta.SubTotal();

        //        if (this.chbDescuento.Checked == true)
        //        {
        //            descuento = venta.Descuento();
        //            t_itbis_c_pagar = total_pagar + t_itbis;
        //            td_pagar = t_itbis_c_pagar - descuento;
        //            this.lblDescuento.Text = string.Format("{0:C2}", descuento);
        //            this.lblTotalPagar.Text = string.Format("{0:C2}", td_pagar);
        //        }
        //        else
        //        {
        //            t_itbis_c_pagar = t_itbis + total_pagar;
        //            this.lblTotalPagar.Text = string.Format("{0:C2}", t_itbis_c_pagar);
        //            lblDescuento.Clear();
        //            return;
        //        }
        //    }

        //    catch (Exception)
        //    {
        //        MessageBox.Show("Debe indicar un Total a Pagar, asi poder aplicar Descuento", "Mensaje del Sistema", 
        //        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        this.txtProductos.Focus();
        //        return;
        //    }

        //} 
        #endregion


        private void dgvDetalle_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Exception ex = e.Exception;   // Desable Error from DataGridView
            e.Cancel = false;
        }


        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                // InsertItem();   //-----> Old Method
                BuildDataGrid();
                LoadHeadGrid();
                InsertNewItem();  //----> New Method
            }
        }

        private void txtProductos_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.F2)
            {
                ProcessSell();
            }

            if (e.KeyData == Keys.F3)
            {
                try
                {
                    SearchProduct();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (e.KeyData == Keys.F4)
            {
                InsertNewItem();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FacturaBO.DeleteEmptyRow();
            //var Amount = AperturaCajaBO.GetAmount(); //Get Current Amount Invoices after Open Box
            decimal Amount = 1000;  //------> This variable is use to development

            if (Amount != 0)
            {
                NewInvoice();
                LimpiarEfectivo();
            }
            else
            {
                MessageBox.Show("Debe Abrir la Caja Antes para poder Realizar Ventas", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }

}





