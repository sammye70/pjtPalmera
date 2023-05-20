using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Threading.Tasks;
using System.Windows.Forms;
using pjPalmera.Entities;
using pjPalmera.BLL;

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
            this.chStatusBox();
            timer1.Enabled = true;
            CleanControlsSell();
            cleanCash();
            Deshabilitar();
            this.txtItbis.Visible = false;
            this.label9.Visible = false;
            this.txtAprobacionNo.Visible = false;
            SetToolControls();
            InitialControls();
            DiscountAverageInvoice();      
            this.btnNuevo.Focus();
            this.chbPrintTicketFact.Checked = true;
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
            this.cmbfPagos.BackColor = Color.Bisque;

            //ForeColor
            //  this.txtApClientes.ForeColor = Color.Maroon;
            this.txtClientes.ForeColor = Color.Maroon;
            this.txtProductos.ForeColor = Color.Maroon;
            this.txtDescripcion.ForeColor = Color.Maroon;
            this.txtPrecio.ForeColor = Color.Maroon;
            this.txtCantidad.ForeColor = Color.Maroon;
            this.cmbDescPostVentaExt.ForeColor = Color.Maroon;
            this.dgvDetalle.ForeColor = Color.Maroon;
            this.cmbfPagos.ForeColor = Color.Maroon;
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


        private void txtEfectivoRecibido_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(this.txtEfectivoRecibido.Text == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    decimal efectivo, cobrar;
                    cobrar = decimal.Parse(this.lblTotalPagar.Text);
                    efectivo = decimal.Parse(this.txtEfectivoRecibido.Text);
                    this.lblResDevuelta.Text = Convert.ToString(efectivo - cobrar);
                }
 
            }
            catch(ArgumentNullException)
            {
                return;
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
        /// Validator controls before Pay (Cash or credit card only)
        /// </summary>
        public bool ValidatorPost()
        {
            // var cash = cobros.txtEfectivoRecibido.Text;
            // var type_pay = cobros.cmbfPagos.Text;
           // var cash = this.txtEfectivoRecibido.Text;
           // var type_pay = this.cmbfPagos.Text;
           // var reference = this.txtAprobacionNo.Text;
            var tpay = new type_payEntity();

            bool resul = true;

            if (this.lblTotalPagar.Text == "0.00")
            {
                MessageBox.Show("No se puede procesar la venta. Debe Efectuar una antes.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnNuevo.Focus();
                resul = false;
            }

            #region method code
            if (this.cmbfPagos.Text == tpay.getMethod(0).ToString())
            {
                if ((this.txtEfectivoRecibido.Text == string.Empty) || (this.txtEfectivoRecibido.Text == "0.00"))
                {
                    MessageBox.Show("Indicar el efectivo recibido por el cliente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resul = false;
                }
            }

            if (this.cmbfPagos.Text == tpay.getMethod(1).ToString())
            {
                if (string.IsNullOrEmpty(this.txtAprobacionNo.Text) != true)
                {
                    MessageBox.Show("Indicar el Número de Aprobación", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtAprobacionNo.Focus();
                    resul = false;
                }
            } 
            #endregion

            if(this.cmbfPagos.Text == String.Empty && this.txtAprobacionNo.Text == String.Empty)
            {
                MessageBox.Show("Algunas informaciones son requeridas para continuar, verificar y después intentar nuevamente.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resul = false;
            }
            //  verify credit card before pay process 
            if (this.cmbfPagos.Text != String.Empty && this.txtAprobacionNo.Visible == true && string.IsNullOrEmpty(this.txtAprobacionNo.Text) == true)
            {
                MessageBox.Show("Indicar el Número de Aprobación", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtAprobacionNo.Focus();
                resul = false;
            }

            if (this.cmbfPagos.Text != String.Empty && this.txtAprobacionNo.Visible == true && string.IsNullOrEmpty(this.txtAprobacionNo.Text) == false && this.txtEfectivoRecibido.Enabled == false)
            {
                resul = true;
            }
            //  verify cash before pay process 
            if (this.cmbfPagos.Text != String.Empty && this.txtEfectivoRecibido.Enabled == true && string.IsNullOrEmpty(this.txtEfectivoRecibido.Text) == true)
            {
                MessageBox.Show("Indicar el efectivo recibido por el cliente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtEfectivoRecibido.Focus();
                resul = false;
            }

            if (this.cmbfPagos.Text != String.Empty && this.txtEfectivoRecibido.Enabled == true && string.IsNullOrEmpty(this.txtEfectivoRecibido.Text) == false && this.txtAprobacionNo.Visible == false)
            {
                resul = true;
            }

            return resul;
        }



        /// <summary>
        /// Clear Textbox after process sell or preparent new invoice
        /// </summary>
        public void CleanControlsSell()
        {
            //this.txtClientes.Clear();
            this.txtProductos.Clear();
            this.txtDescripcion.Clear();
            this.txtPrecio.Clear();
            this.txtCantidad.Clear();
            this.cmbDescPostVentaExt.Text = "";
            this.txtAprobacionNo.Text = "";
            this.cmbCondictionDays.Text = "";
            // this.txtClientes.Text = "";
            // this.txtIdCliente.Text = "";
            this.txtId_Invoice.Text = "";
            this.txtCreditLimit.Text = "";
            this.txtCurrentAmount.Text = "";
            this.txtAmountPast.Text = "";
            this.txtAprobacionNo.Visible = false;
            this.lblAprobacion.Visible = false;
            this.txtEfectivoRecibido.Enabled = false;

            //this.lblDescuento.Clear();
            //this.lblTotalPagar.Clear();
            // this.txtItbis.Clear();
        }

        /// <summary>
        ///  Clean all controls after insert item
        /// </summary>
        private void CleanControlsAfter()
        {
            this.txtProductos.Clear();
            this.txtDescripcion.Clear();
            this.txtPrecio.Clear();
            this.txtCantidad.Clear();
            this.cmbDescPostVentaExt.Text = "";
            this.txtAprobacionNo.Text = "";
            this.cmbCondictionDays.Text = "";
        }

        /// <summary>
        /// Get All Pay Methods
        /// </summary>
        private void LoadMethodPay()
        {
            this.cmbfPagos.DataSource = FacturaBO.GetMethod_Pays();
            this.cmbfPagos.DisplayMember = "Nombre";
            this.cmbfPagos.ValueMember = "Id";
        }

        /// <summary>
        ///  Hide Controls from Credit Invoice
        /// </summary>
        public void DesVisibleCtrlInvCr()
        {
            this.txtClientes.Visible = false;
            this.txtIdCliente.Visible = false;
            this.cmbCondictionDays.Visible = false;
            this.lblCustomer.Visible = false;
            this.btnFindCustomer.Visible = false;
            this.btnNewInvoiceCr.Visible = false;
            this.btnProcInvoiceCr.Visible = false;
            this.btnFindCustomer.Enabled = false;
            this.txtClientes.Text = "CONTADO";
            this.txtIdCliente.Text = "1";
        }

        /// <summary>
        /// Show Controls from Credit Invoice
        /// </summary>
        public void EnVisibleCtrlInvCr()
        {
            this.txtClientes.Visible = true;
            this.cmbCondictionDays.Visible = false;
            this.lblCustomer.Visible = true;
            this.btnFindCustomer.Visible = true;
            this.lblCondictionCr.Visible = false;
        }


        /// <summary>
        ///  Hide Controls from Cash Invoice before load Credit Invoice
        /// </summary>
        public void DesVisibleCtrlInvCash()
        {
            this.txtAprobacionNo.Visible = false;
            this.lblAprobacion.Visible = false;
            this.lblDescuento.Visible = false;
            this.lblResDevuelta.Visible = false;
            this.cmbDescPostVentaExt.Enabled = false;
            this.cmbfPagos.Visible = false;
            this.btnProcesarPago.Visible = false;
            this.btnNuevo.Visible = false;
            this.lblChangeCash.Visible = false;
            this.lblDescuentCash.Visible = false;
            this.lblMethodPago.Visible = false;
            this.lblGetCashPayInvC.Visible = false;
            this.txtEfectivoRecibido.Visible = false;
            this.txtClientes.Visible = false;
            this.lblCustomer.Visible = false;
            this.lblDescInvoiceCash.Visible = false;
            this.cmbDescPostVentaExt.Visible = false;
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
        ///  Preparet for new credit invoice
        /// </summary>
        private void NewInvoiceCr()
        {
            Habilitar();
            CleanControlsSell();
            //cleanCash();
            OnlyRead();
            // this.txtApClientes.Text = "CONTADO";
            // this.txtIdCliente.Text = "1";
            // venta = new VentaEntity(); //Head invoice
            this.dgvDetalle.Rows.Clear();
            this.btnFindCustomer.Focus();

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
            CleanControlsSell();
            OnlyRead();
            this.txtClientes.Clear();
            this.cmbfPagos.Text = "";
            this.dgvDetalle.DataSource = null;
            cleanCash();
            this.cmbfPagos.Focus();
        }
        #endregion

        #region RemoveItems New Code
        // (Current in use) -- Modificated: 17/04/2020  - 1:53
        /// <summary>
        /// Remove Items from DataGridView  (New Code)---> Pendding 
        /// </summary>
        private void RemoveItems()
        {
            DataGridViewRow x = this.dgvDetalle.CurrentRow; // Get current containing Cell
            int i = this.dgvDetalle.RowCount; // Get/Set DataGridview rows has
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
        /// Clean cash labels
        /// </summary>
        public void cleanCash()
        {
            this.txtDevueltaEfectivo.Text = "";
            this.txtEfectivoRecibido.Text = "";
            this.cmbDescPostVentaExt.Text = "";
            this.cmbfPagos.Text = "";
            this.txtAprobacionNo.Text = "";
            //this.txtRecibidoEfectivo.Text = "";
            this.lblTotalPagar.Text = "0.00";
            this.txtItbis.Text = "0.00";
            this.lblSubtotal.Text = "0.00";
            this.lblDescuento.Text = "0.00";
            this.lblResDevuelta.Text = "0.00";
            // this.txtRecibidoEfectivo.Text="0.0";
        }

        /// <summary>
        /// Prepare for New Invoice   -- Modificated: 16/04/2020, 10:55.
        /// </summary>
        public void NewInvoice()
        {
            Habilitar();
            CleanControlsSell();
            //cleanCash();
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
            var Con_Clientes = new frmConsulClientes();
            var Stype = this.txtTypeInvoice.Text;
            Con_Clientes.HideCtrlCustmer();

            if (Con_Clientes.ShowDialog() == DialogResult.OK)
            {

                clientes = ClientesBO.GetbyId(Con_Clientes.Orden);

                if(clientes != null)
                {
                    this.txtIdCliente.Text = (clientes.Id).ToString();
                    //this.txtIdCliente.Text = Convert.ToString(Con_Clientes.Orden);
                    this.txtClientes.Text = clientes.Nombre + " " + clientes.Apellidos;
                    this.txtCreditLimit.Text = clientes.Limite_credito.ToString();
                    // this.txtApClientes.Text = clientes.Apellidos;
                    this.txtProductos.Focus(); //
                }
            }
        }

        /// <summary>
        /// Search Product from ConsulProductos by Id
        /// </summary>
        public void SearchProduct()
        {
            try
            {
                var consulProductos = new frmConsultarProductos();
                var tventa = this.txtTypeInvoice.Text;
                var user = new UsuariosEntity();
                user.Id_user = int.Parse(this.txtUserId.Text);
                consulProductos.txtIdUser.Text = user.Id_user.ToString();
                

                UsuariosBO.getVisibleControls(user);
                var rol = UsuariosBO.result;

                switch (rol)                                    //----------------------------------------------------------------> continues building struct to determine if rol is correct to show controls
                {
                    case "1":
                            if(tventa == "1")
                            {
                                consulProductos.FilterProduct();
                                consulProductos.rol1();
                                consulProductos.InniDisableControls();
                            }

                            if(tventa == "2")
                            {
                                consulProductos.FilterProduct();
                                consulProductos.rol1();
                                consulProductos.InniDisableControls();
                            }
                        break;
                    case "2":
                            if (tventa == "1")
                            {
                                consulProductos.FilterProduct();
                                consulProductos.rol2();
                                consulProductos.InniDisableControls();
                            }

                            if (tventa == "2")
                            {
                                consulProductos.FilterProduct();
                                consulProductos.rol2();
                                consulProductos.InniDisableControls();
                            }
                        break;
                    case "3":
                        MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }

                // consulProductos.IniControls();
                //consulProductos.FilterProduct();


                if (consulProductos.ShowDialog() == DialogResult.OK)
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

        #region Enable and Desable Controls

        /// <summary>
        /// Deshabilita TextBox, Buttons
        /// </summary>
        public void Deshabilitar()
        {
            this.txtClientes.Enabled = false;
            this.txtCantidad.Enabled = false;
            this.txtPrecio.Enabled = false;
            this.txtProductos.Enabled = false;
            this.btnAgregar.Enabled = false;
            this.btnPagar.Enabled = false;
            // this.btnNuevo.Enabled = false;
            this.cmbfPagos.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.txtItbis.Enabled = false;
            this.lblDescuento.Enabled = false;
            this.lblTotalPagar.Enabled = false;
            this.lblSubtotal.Enabled = false;
            this.chbDescuento.Enabled = false;
            this.lblResDevuelta.Enabled = false;
            this.btnBuscarProducto.Enabled = false;
            this.btnFindCustomer.Enabled = false;
            this.btnEliminar.Enabled = false;
            // this.txtApClientes.Enabled = false;
            this.btnProcesarPago.Enabled = false;
            this.txtEfectivoRecibido.Enabled = false;
            this.txtDevueltaEfectivo.Enabled = false;
            this.cmbDescPostVentaExt.Enabled = false;
            this.lblAprobacion.Visible = false;
            this.chbPrintTicketFact.Visible = false;
            this.cmbCondictionDays.Enabled = false;
            this.btnProcInvoiceCr.Enabled = false;
            this.lblCondictionCr.Visible = false;
            this.cmbCondictionDays.Visible = false;
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
            this.cmbfPagos.Enabled = true;
            this.txtDescripcion.Enabled = true;
            this.txtItbis.Enabled = true;
            this.lblDescuento.Enabled = true;
            this.lblTotalPagar.Enabled = true;
            this.lblSubtotal.Enabled = true;
            this.lblResDevuelta.Enabled = true;
            this.lblDescuento.Enabled = true;
            // this.btnNuevo.Enabled = true;
            this.btnBuscarProducto.Enabled = true;
            this.btnFindCustomer.Enabled = true;
            this.btnEliminar.Enabled = true;
            //   this.txtApClientes.Enabled = true;
            this.btnProcesarPago.Enabled = true;
            // this.txtEfectivoRecibido.Enabled = true;
            // this.txtDevueltaEfectivo.Enabled = true;
            this.cmbDescPostVentaExt.Enabled = true;
            this.cmbCondictionDays.Enabled = true;
            this.btnProcInvoiceCr.Enabled = true;

        }
        #endregion

        #region Process_Selling_Cash_or_Credit
        /// <summary>
        /// All Steps for Process one Sell
        /// </summary>
        public void ProcessSell(bool resp)
        {
            // var cobros = new frmCobros();
            TicketVentaEntity caja = new TicketVentaEntity();
           
            // cobros.Hide();
            if (!ValidatorPost())
               return;

            var type = Int32.Parse(this.txtTypeInvoice.Text);  // Get type invoice (cash, credit)

            // Answer = MessageBox.Show("Imprimir Recibo", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            switch(resp)
            {
                case true: // Print Ticket
                    // cobros.Hide();
                    // this.txtProductos.Focus();
                    CreateInvoice(type);
                    PrintTicket();
                    FacturaBO.DeleteEmptyRow();
                    // MessageBox.Show("Se Imprimio Recibo", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Venta Procesada, Retirar Ticket", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NewInvoice();
                    cleanCash();
                    CleanControlsSell();
                    this.txtProductos.Focus();
                    break;

                case false: // Not Print Ticket
                    // cobros.Close();
                    CreateInvoice(type);
                    FacturaBO.DeleteEmptyRow();
                    caja.AbreCajon();
                    //  MessageBox.Show("No se Imprimio Recibo", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Venta Procesada", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NewInvoice();
                    cleanCash();
                    CleanControlsSell();
                    this.txtProductos.Focus();
                    break;
            }          
        }
        #endregion

        #region Invoice paid cash & credit
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

            // Invoice Titles
            string Type1 = "FACTURA AL CONTADO";
            string Type2 = "FACTURA A CREDITO";

            //Setting Business
            var infoBusiness = new EnterpriseSettings();

            //Id Invoice
            
            this.txtId_Invoice.Text = Convert.ToString(Id_invoice);  //
            

            RawPrinterHelper j = new RawPrinterHelper(); //

            // Header invoice
            
            //int AutoScrollOffset1= -100;
            //AutoScrollOffset1 = AutoScrollOffset1 -100;
            g.DrawString(infoBusiness.Name, ffTitle, sb, 75, 120);
            g.DrawString(infoBusiness.sLogan, fTitle, sb, 20, 134);
            g.DrawString(infoBusiness.Address, fdTitle, sb, 27, 148);
            g.DrawString("RNC:" + infoBusiness.rNc, fdTitle, sb, 80, 160);
            g.DrawString("Tel:" + infoBusiness.phoneNumber0, fdTitle, sb, 80, 175);
            g.DrawString("Whatsapp:" + infoBusiness.phoneNumber1, fdTitle, sb, 70, 185);

            g.DrawString("FECHA:", fTitle, sb, 10, 210); //
            g.DrawString(DateTime.Now.ToShortDateString(), fBody, sb, 80, 210); //
            g.DrawString("HORA:", fTitle, sb, 155, 210); //
            g.DrawString(DateTime.Now.ToShortTimeString(), fBody, sb, 195, 210); //
            g.DrawString("CLIENTE:", fTitle, sb, 10, 220); //
            g.DrawString(this.txtClientes.Text, fBody, sb, 80, 220);
           // g.DrawString(this.txtApClientes.Text, fBody, sb, 180, 220); //
            g.DrawString("NCF:", fTitle, sb, 10, 232); //
            g.DrawString("NIF:", fTitle, sb, 10, 244); //
            g.DrawString(this.txtId_Invoice.Text, fBody, sb, 50, 244); //

            // Type of invoices
            // Values: 1.- Cash, 2.-Credit
            var tp = this.txtTypeInvoice.Text; 

            if (tp == "1")
            {
                g.DrawString(Type1, fTitle, sb, 75, 255);
            }
            else if (tp == "2")
            {
                g.DrawString(Type2, fTitle, sb, 75, 255);
            }


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

            switch(tp)
            {
                case "1":
                    // Paid Detail
                    AutoScrollOffset = AutoScrollOffset + 12;
                    g.DrawString("SubTotal:", fdpTitle, sb, 90, 330 + AutoScrollOffset);   // 
                    g.DrawString(this.lblSubtotal.Text, fBody, sb, 202, 330 + AutoScrollOffset);  //
                    g.DrawString("Descuento:", fdpTitle, sb, 90, 350 + AutoScrollOffset);
                    g.DrawString(this.lblDescuento.Text, fBody, sb, 202, 350 + AutoScrollOffset); //
                    g.DrawString("Total a Pagar:", fpTitle, sb, 90, 368 + AutoScrollOffset); //
                    g.DrawString(this.lblTotalPagar.Text, fpBody, sb, 202, 368 + AutoScrollOffset);  //
                    g.DrawString("", fdpTitle, sb, 100, 370 + AutoScrollOffset);
                    g.DrawString("Recibido:", fdpTitle, sb, 90, 389 + AutoScrollOffset); //
                    g.DrawString(this.txtEfectivoRecibido.Text, fBody, sb, 202, 389 + AutoScrollOffset); //
                    g.DrawString("Devuelta:", fdpTitle, sb, 90, 405 + AutoScrollOffset); //
                    g.DrawString(this.lblResDevuelta.Text, fBody, sb, 202, 405 + AutoScrollOffset); //
                    g.DrawString("Pagado con:", fdpTitle, sb, 90, 420 + AutoScrollOffset);
                    g.DrawString(this.cmbfPagos.Text, fdpTitle, sb, 200, 420 + AutoScrollOffset);
                    break;

                case "2":
                     // summary credit account
                    g.DrawString("Monto Venta:", fpTitle, sb, 78, 330 + AutoScrollOffset); //
                    g.DrawString(this.lblTotalPagar.Text, fpBody, sb, 202, 330 + AutoScrollOffset);  //
                    g.DrawString("Balance Anterior:", fdpTitle, sb, 78, 350 + AutoScrollOffset); //
                    g.DrawString(this.txtAmountPast.Text, fBody, sb, 202, 350 + AutoScrollOffset); //
                    g.DrawString("Nuevo Balance:", fpTitle, sb, 78, 368 + AutoScrollOffset); //
                    g.DrawString(this.txtCurrentAmount.Text, fpBody, sb, 202, 368 + AutoScrollOffset);  //
                    break;
            }
 
            // Feet Messenge
            AutoScrollOffset = AutoScrollOffset + 8;
            g.DrawString("Le Atendio:", fBody, sb, 5, 426 + AutoScrollOffset);
            g.DrawString(this.lblCajeroName.Text, fpBody, sb, 100, 426 + AutoScrollOffset);   // Casher First Name and Last Name
            g.DrawString("Nota: no hacemos devoluciones después de la 24 horas,", tbottom, sb, 5, 442 + AutoScrollOffset);
            g.DrawString("y mucho menos si los medicamentos se encuentran en", tbottom, sb, 5, 452 + AutoScrollOffset);
            g.DrawString("mal estado.", tbottom, sb, 5, 462 + AutoScrollOffset);

            g.DrawString("Tú eres la persona más linda que Jesús", fTitle, sb, 5, 482 + AutoScrollOffset);
            g.DrawString("tiene en este mundo Buscale.", fTitle, sb, 5, 497 + AutoScrollOffset);

            g.DrawString(".", tblank, sb, 5, 506 + AutoScrollOffset);
            // 
        }
        #endregion

        #region Validator content in Controls
        /// <summary>
        ///  Validator content in Controls (type to corresponded)
        /// </summary>
        /// <returns></returns>
        public bool Validator()
        {
            bool result = true;

            if ((this.txtClientes.Text == string.Empty) || (this.txtClientes.Text == null))
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

        #region Insert Rows on the List -- Cash Invoices  (New Code) ---> Modificated: 16/04/2020 - 15:45  
        /// <summary>
        /// Insert Item on the List Cash (New Code)  
        /// </summary>
        public void InsertNewItem()
        {
            var venta = new VentaEntity();
            var stock = ProductosBO.getStock(Convert.ToInt64(this.txtProductos.Text));
            var quantity = decimal.Parse(this.txtCantidad.Text);
            var evStockQuantity = ProductosBO.getStockQuantity(stock, quantity);
            var typeInvoices = this.txtTypeInvoice.Text;
            decimal importT; // price x quantity
            decimal amount = 0; // invoice amount total
            int x = this.dgvDetalle.RowCount;


            if (!Validator())
                return;

            try
            {
                if (evStockQuantity == true)
                {
                    MessageBox.Show(ProductosBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtCantidad.Focus();
                }
                else if (evStockQuantity == false)
                {
                    switch (typeInvoices)
                    {

                        case "1":

                            for (int i = 1; i > x; i++)
                            {
                                x = x++;
                            }

                            importT = venta.ProductValue(Convert.ToDecimal(this.txtCantidad.Text), Convert.ToDecimal(this.txtPrecio.Text));
                            this.dgvDetalle.Rows.Add(this.txtProductos.Text, this.txtDescripcion.Text, this.txtCantidad.Text, this.txtPrecio.Text, importT);
                            this.dgvDetalle.AllowUserToAddRows = false;

                            ////Add prices all elements in list
                            foreach (DataGridViewRow row in this.dgvDetalle.Rows)
                            {
                                amount += Convert.ToDecimal(row.Cells[4].Value);
                            }

                            this.lblSubtotal.Text = Convert.ToString(amount);
                            this.lblDescuento.Text = Convert.ToString(venta.Descuento(amount));
                            this.lblTotalPagar.Text = Convert.ToString(venta.Pagar(amount));

                            CleanControlsSell();
                            this.txtProductos.Focus();

                            break;

                        case "2":

                            for (int i = 1; i > x; i++)
                            {
                                x = x++;
                            }

                            importT = venta.ProductValue(Convert.ToDecimal(this.txtCantidad.Text), Convert.ToDecimal(this.txtPrecio.Text));
                            this.dgvDetalle.Rows.Add(this.txtProductos.Text, this.txtDescripcion.Text, this.txtCantidad.Text, this.txtPrecio.Text, importT);
                            this.dgvDetalle.AllowUserToAddRows = false;

                            ////Add prices all elements in list
                            foreach (DataGridViewRow rows in this.dgvDetalle.Rows)
                            {
                                amount += Convert.ToDecimal(rows.Cells[4].Value);
                            }

                            this.lblTotalPagar.Text = Convert.ToString(amount);
                            // this.lblDescuento.Text = Convert.ToString(venta.Descuento(amount));
                            // this.lblTotalPagar.Text = Convert.ToString(venta.Pagar(amount));

                            CleanControlsAfter();
                            this.txtProductos.Focus();
                            break;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
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
                CleanControlsSell();
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
            // CreateInvoice();  
            //Save_Head();
            //Save_Detail();
           // UpdateStock();
           // Save_Transactions();
        }

        #region New- Create Invoice code



        /// <summary>
        ///  Code Create all Invoices, cash/credit (New Process)
        /// </summary>
        /// 
        public void CreateInvoice(int t_invoice)
        {
            try
            {
                int x = this.dgvDetalle.Rows.Count; // Rows counter in DataGridView Items List

                int status = 1;

                var ventas = new VentaEntity(); // This is a Base invoice Sell Entity 
                var ventascr = new VentaCrEntity(); // This is a invoice Entity but credit
                var craccount = new CreditAccountEntity(); // This is a credit account entity when some customer to shop, but if he/she has lines credit or not.

                switch (t_invoice)
                {
                    // Generate cash invoice to customers
                    case 1:
                        // Header
                        // ventas.id_caja = 1;
                        ventas.id_user = Int32.Parse(this.txtUserId.Text);
                        ventas.tipo = this.txtTypeInvoice.Text;
                        ventas.id_cliente = int.Parse(this.txtIdCliente.Text);
                        ventas.clientes = this.txtClientes.Text; //
                        // ventas.apellidos = this.txtApClientes.Text; //
                        ventas.total = decimal.Parse(this.lblTotalPagar.Text); //
                        ventas.status = status; //
                        ventas.descuento = decimal.Parse(this.lblDescuento.Text); //
                        ventas.subtotal = decimal.Parse(this.lblSubtotal.Text); //
                        ventas.total_itbis = decimal.Parse(this.txtItbis.Text); //
                        ventas.recibido = Convert.ToDecimal(this.txtEfectivoRecibido.Text); //
                        ventas.devuelta = Convert.ToDecimal(this.lblResDevuelta.Text); //
                        ventas.request_number = this.txtAprobacionNo.Text;
                        ventas.method_pago = (Int32)(this.cmbfPagos.SelectedValue);
                        // ventas.method_pago = (Int32) methodPagos;
                        //ventas.method_pago = cobros.getTypePay; //

                        // Detail
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

                        FacturaBO.CreateInvoice(ventas);  // Cash Invoices (Save history all invoices)
                        ProductosBO.Decrease_Stock(ventas); // Decrease Stock 
                        FacturaBO.CreateTranst(ventas);
                      //  FacturaBO.SetInvoiceCashPay(ventas);
                        id_venta = ventas.id;

                        break;

                    // Generate invoice if customer has line credit
                    case 2:
                        // Header
                        //ventascr.id_caja = 1;  //-----------------------------------> it's need to get from casher setting
                        ventascr.id_user = Int32.Parse(this.txtUserId.Text);
                        ventascr.tipo = this.txtTypeInvoice.Text;
                        ventascr.id_cliente = Convert.ToInt32(this.txtIdCliente.Text);
                        ventascr.clientes = this.txtClientes.Text; //
                        // ventas.apellidos = this.txtApClientes.Text; //
                        ventascr.total = decimal.Parse(this.lblTotalPagar.Text); // after applied all taxes
                        ventascr.status = status; //
                        ventascr.subtotal = decimal.Parse(this.lblSubtotal.Text); // before to apply all taxes

                        // Invoice's Detail
                        for (int i = 0; i < x; i++)
                        {
                            var Detailcr = new DetalleVentaCrEntity();

                            Detailcr.CODIGO = Convert.ToInt64(this.dgvDetalle.Rows[i].Cells[0].Value); // Id
                            Detailcr.DESCRIPCION = Convert.ToString(this.dgvDetalle.Rows[i].Cells[1].Value); // Description
                            Detailcr.CANTIDAD = Convert.ToInt32(this.dgvDetalle.Rows[i].Cells[2].Value); // Quantity
                            Detailcr.PRECIO = Convert.ToDecimal(this.dgvDetalle.Rows[i].Cells[3].Value); // Price per Unit
                            // Detail.ITBIS = Convert.ToDecimal(this.dgvDetalle.Rows[i].Cells["ITBIS"].Value); // Itbis
                            Detailcr.IMPORTE = Convert.ToDecimal(this.dgvDetalle.Rows[i].Cells[4].Value); // amount for current line

                            ventascr.addProduct(Detailcr);
                        }

                        // var chklineCredit = FacturaBO.CheckProcessCredit(ventascr);  // Old Business Object, but has of some funtionalite that BO bellow
                        var amount = decimal.Parse(this.lblTotalPagar.Text);
                        var chklineCredit = ClientesBO.VeficafyCreditAmount(ventascr.id_cliente, amount); // Check if customer has line credit

                        if (chklineCredit == true)
                        {
                            FacturaBO.CreateCrInvoice(ventascr);  // Credit Invoices (Save in repository for all invoices)  ----> Here Continue to Work (OK)
                            ProductosBO.Decrease_Stock(ventascr); // Decrease Stock (OK)
                            FacturaBO.CreateTranst(ventascr);   //----------------------------- Here to continue working (OK)

                            // Function to create credit account in general invoices for customer
                            craccount.id_cliente = ventascr.id_cliente;   ///------------> Here Pedding Work
                            craccount.id = ventascr.id;
                            craccount.InvoiceAmount = ventascr.total;
                            craccount.id_user = ventascr.id_user;
                            // craccount.CurrentAmount = ventascr.total;
                            // craccount.PastAmountcr = Decimal.Parse((CreditAccountBO.GetAmount(int.Parse(this.txtIdCliente.Text))).ToString()); //-->

                            CreditAccountBO.CreateCrAccount(craccount);
                            // FacturaBO.SetInvoiceCashPay(ventascr);
                            id_venta = ventascr.id;

                            // craccount.CurrentAmount = Decimal.Parse((CreditAccountBO.GetAmount(int.Parse(this.txtIdCliente.Text))).ToString());
                            this.txtCurrentAmount.Text = craccount.NewAmountcr.ToString();
                            this.txtAmountPast.Text = craccount.PastAmountcr.ToString();


                            //steps after process credit sell
                            PrintTicket();
                            FacturaBO.DeleteEmptyRow();
                            // MessageBox.Show("Se Imprimio Recibo", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MessageBox.Show("Venta Procesada, Retirar Ticket!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NewInvoice();
                            cleanCash();
                            CleanControlsSell();
                            this.Close();
                        }
                        else if(chklineCredit == false)
                        {
                            MessageBox.Show(ClientesBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.btnNewInvoiceCr.Focus();
                            return;
                        }

                        break;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        ///  Validator controls before credit line process (not cash or card)
        /// </summary>
        /// <returns></returns>
        private bool ValidatorPostCr()
        {
            bool resul = true;

            if (this.lblTotalPagar.Text == "0.00")
            {
                MessageBox.Show("No se puede procesar la venta. Debe Efectuar una antes.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnNuevo.Focus();
                resul = false;
            }

            return resul;
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
            this.toolTip1.SetToolTip(this.btnFindCustomer, "Buscar Clientes");
            this.toolTip1.SetToolTip(this.btnBuscarProducto, "Buscar Productos");
           // this.toolTip1.SetToolTip(this.btnNuevo, "Limpia de los campos de cliente, y producto a ser agregados");
            this.toolTip1.SetToolTip(this.btnEliminar, "Eliminar item del carro de compra");
            this.toolTip1.SetToolTip(this.btnPagar, "Efectuar pago de la compra ");
            this.toolTip1.SetToolTip(this.btnAgregar, "Agregar Items a la compra");
            this.toolTip1.SetToolTip(this.btnNuevo, "Crear Nueva Venta al Contado");
            this.toolTip1.SetToolTip(this.btnProcesarPago, "Procesar Compra");
            this.toolTip1.SetToolTip(this.btnNewInvoiceCr, "Crear Nueva Venta a Crédito");
            this.toolTip1.SetToolTip(this.btnProcInvoiceCr, "Procesar Compra");
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

        #region Press_Selling_Credit
           
        /// <summary>
        ///  Process Credit Sell
        /// </summary>
        private void ProcessSellCr()
        {
             if (!ValidatorPostCr())   //----> create method that valide controls after process credit sell -- DONE
                    return;

            var type = Int32.Parse(this.txtTypeInvoice.Text); // Get type invoice 

            try
            {
                CreateInvoice(type);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Check Box Status before begin sell process (Determine if is cash  or credit it)
        /// <summary>
        ///  Check if box was opened or closed to one user
        /// </summary>
        public void chStatusBox()
        {
            var sell = new VentaEntity();
            var tSell = this.txtTypeInvoice.Text;
            var sBox = new OperationsCajaEntity();
            var frmBox = new frmAbrirCaja();
            var type = sell.Set_Type_invoice(FacturaBO.eType_invoices.cash.ToString());
            sBox.UserId = int.Parse(this.txtUserId.Text);
            var status = OperationsCajaBO.GetStatusBox(sBox);

            switch (status)                                     // -------------------------------> it need to check before putting in production. working continue here.
            {
                case 0:
                    MessageBox.Show(OperationsCajaBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Hide();
                    this.Dispose();
                    frmBox.txtIdUser.Text = sBox.UserId.ToString();
                    frmBox.ShowDialog();
                    break;

                case 1:
                    if (tSell.Equals(type))
                    {
                        // MessageBox.Show("Abierta para venta a contado", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.NewInvoice();
                        this.btnNuevo.Focus();
                    }
                    else
                    {
                        // MessageBox.Show("Abierta para venta a crédito", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.NewInvoiceCr();
                        this.btnNuevo.Focus();
                    }
                    break;
            }
        }
        #endregion

        private void dgvDetalle_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Exception ex = e.Exception;   // Disable Error from DataGridView
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

            if (e.KeyData == Keys.F3)
            {
                this.btnProcesarPago.Focus();
            }

            if (e.KeyData == Keys.F4)
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
            //var Amount = OperationsCajaBO.GetAmount(); //Get Current Amount Invoices after Open Box
            decimal Amount = 1000;  //------> This variable is use to development

            if (Amount != 0)
            {
                NewInvoice();
                cleanCash();
            }
            else
            {
                MessageBox.Show("Debe Abrir la Caja Antes para poder Realizar Ventas", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void cmbfPagos_DropDown(object sender, EventArgs e)
        {
            try
            {
                LoadMethodPay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;                
            }
        }

        private void cmbfPagos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var type = this.cmbfPagos.Text;

            switch (type)
            {
                case "efectivo":
                    this.txtAprobacionNo.Visible = false;
                    this.lblAprobacion.Visible = false;
                    this.txtDevueltaEfectivo.Text = "0.00";
                    this.txtEfectivoRecibido.Text = "";
                    this.txtEfectivoRecibido.Enabled = true;
                    this.txtEfectivoRecibido.Focus();
                    //this.btnProcesarPago.Focus();
                    break;

                case "tarjeta":
                    _amount = decimal.Parse(this.lblTotalPagar.Text);
                    // this.txtDevueltaEfectivo.Text = "0";
                    this.txtEfectivoRecibido.Text = this.Amount_.ToString();
                    this.txtEfectivoRecibido.Enabled = false;
                    this.txtAprobacionNo.Visible = true;
                    this.lblAprobacion.Visible = true;
                    this.txtAprobacionNo.Focus();
                    break;
                default:
                    return;
            }
        }

        private void btnProcesarPago_Click(object sender, EventArgs e)
        {
            /* 
             * Verificate if send to print ticket, Using Method ProcessSell with boolean value.
             * If ProcessSell value is true print, else not print.
             * Variable b: is who store answer value from MessegeBox(It's true or false).
             * Variable cb: it is store value boolean true or false. Use to sent printing ticket.
            */
            try
            {
                if (!ValidatorPost())
                    return;

                var type = this.txtTypeInvoice.Text;

                switch (type)
                {
                    case "1":
                        var answer = new DialogResult();
                        bool b;
                        answer = MessageBox.Show("Imprimir Recibo", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        var cb = this.chbPrintTicketFact.Checked;

                        if (answer == DialogResult.Yes)
                        {
                            b = true;
                            // _amount = Convert.ToDecimal(this.lblTotalPagar.Text);   
                            // cobros.lblTotalCobrar.Text = this.Amount_.ToString();
                            // cobros.ShowDialog(this);
                            ProcessSell(b);   //---------------------------------------------------> This Method is working, pendding to put in operation
                        }
                        else if (answer == DialogResult.No)
                        {
                            b = false;
                            ProcessSell(b);
                        }
                        break;
                    case "2":
                        b = true;
                        ProcessSell(b);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtEfectivoRecibido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) 
            {
                this.cmbfPagos.Focus();
            }
        }

        private void btnNewInvoiceCr_Click(object sender, EventArgs e)
        {
            NewInvoiceCr();
        }

        private void btnProcInvoiceCr_Click(object sender, EventArgs e)
        {
            ProcessSellCr(); //--->> working here
        }

        
    }

}