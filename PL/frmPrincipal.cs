using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pjPalmera.BLL;
using pjPalmera.Entities;
using PL;

namespace pjPalmera.PL
{
    public partial class frmPrincipal : Form
    {

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

       // private UsuariosEntity user = new UsuariosEntity();

        public frmPrincipal()
        {
            InitializeComponent();
        }
       
        private void facturasAnuladasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFactAnuladas FactAnuladas = new frmFactAnuladas();
            FactAnuladas.Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            frmVenta Venta = new frmVenta();
            Venta.Show();
        }



        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }

        private void notaDeCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNotasCredito NoteCredito = new frmNotasCredito();
            NoteCredito.Show();
        }

 

        private void registroDePersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegPersonas Personas = new frmRegPersonas();
            Personas.ShowDialog(this);
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.CashS();
        }

        /// <summary>
        /// Load system login
        /// </summary>
        private void Login()
        {
            try
            {
                frmlogin login = new frmlogin();
                login.ShowDialog(this);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmAjustarProductos Pedido = new frmAjustarProductos();
            Pedido.ShowDialog(this);
        }

        private void reporteDeArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditarProductos EditProductos = new frmEditarProductos();
            EditProductos.ShowDialog(this);
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            frmRegArticulos n_productos = new frmRegArticulos();
            n_productos.ShowDialog(this);
        }

        private void cierreDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCierreCaja CerrarCaja = new PL.frmCierreCaja();
            CerrarCaja.ShowDialog(this);
        }


        private void abrirCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // info User      
            var user = new UsuariosEntity();
            var box = new OperationsCajaEntity();
            var fmbox = new frmAbrirCaja();

            user.Id_user = Int32.Parse(this.txtIdUser.Text); //
            user.LongName = this.txtLongName.Text;
            user.User_name = this.txtUsername.Text;
            user.Privileges = this.txtPermisson.Text;
            box.TypeOp = "1";
            box.Status = 1;
            fmbox.txtUserFirstNameLast.Text = user.LongName;
           // fmbox.txtUserName.Text = user.User_name;
            fmbox.txtIdUser.Text = user.Id_user.ToString();
            // fmbox.txtPermission.Text = user.Privileges.ToString();
            fmbox.txtType.Text = box.TypeOp.ToString();
            fmbox.txtIdTicket.Text = box.Status.ToString();
            fmbox.ShowDialog(this);
        }

        private void facturasEmitidasCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsulFactCredito ConFacturaCredito = new frmConsulFactCredito();
            ConFacturaCredito.ShowDialog(this);
        }


        private void consultarClientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsulClientes ConsultarClientes = new frmConsulClientes();
            ConsultarClientes.Text = "Ajustar y Consultar Clientes";
            ConsultarClientes.ShowDialog(this);
        }



        private void cxCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistPagoClientesCr HistorialPagosCr = new frmHistPagoClientesCr();

            HistorialPagosCr.ShowDialog(this);
        }

        private void efectuarPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.payCreditInv();
        }

        
        private void pagosAlCobrarAlTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPagosTotalCr PagTotalCr = new frmPagosTotalCr();
            PagTotalCr.ShowDialog(this);
        }

        private void anularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAnularFactura AnularFacturas = new frmAnularFactura();
            AnularFacturas.ShowDialog(this);
        }

        private void activarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmActivarFactura ActivarFacturas = new PL.frmActivarFactura();
            ActivarFacturas.ShowDialog(this);
        }

        private void consultarFacturasAnuladasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void devolucionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCambios cambios = new frmCambios();
            cambios.ShowDialog(this);
        }

        private void ventaACréditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreditS();

        }


         private void registrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegUsers regUsers = new frmRegUsers();
            regUsers.Show(this);
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            // splash splash = new splash();
            //splash.ShowDialog(this);

            //Login();
            //var user = new UsuariosEntity();
            //user.Id_user = int.Parse(this.txtIdUser.Text);

            this.tabControl1.Visible = true;
            this.DetailControls();
         //   this.ValidateProfiles(user);
            this.menuStrip1.Visible = false;
            this.lblStation.Text = Environment.MachineName;         
        }

        private void pbRegClient_Click(object sender, EventArgs e)
        {
            frmRegClientes RegClient = new frmRegClientes();
            RegClient.Show(this);
        }

        private void pbCashSell_Click(object sender, EventArgs e)
        {
            this.CashS();
        }



        /// <summary>
        ///  Pay Credit Invoices
        /// </summary>
        private void payCreditInv()
        {
            var user = new UsuariosEntity();
            var fpay = new frmEfectPagosFactCred();

            user.Id_user = int.Parse(this.txtIdUser.Text);
            user.LongName = this.txtLongName.Text;
            user.Privileges = this.txtPermisson.Text;

            fpay.txtIdUser.Text = user.Id_user.ToString();
            fpay.txtUserLong.Text = user.LongName.ToString();
            fpay.txtPermissions.Text = user.Privileges.ToString();
            // fpay.InitialDesControls();

            // Here add to evalute privileges
            //-->

            fpay.ShowDialog(this);
        }


        /// <summary>
        /// Invoice Cash
        /// </summary>
        private void CashS()
        {
            // 
            var sell = new VentaEntity();
            var cashier = new UsuariosEntity();
            var finvoice = new frmVenta();

            var type = int.Parse(sell.Set_Type_invoice(FacturaBO.eType_invoices.cash.ToString())); // Get type invoice and convert to int value
            sell.tipo = type.ToString();
            cashier.Id_user = int.Parse(this.txtIdUser.Text);
            cashier.LongName = this.txtLongName.Text;
            cashier.Privileges = this.txtPermisson.Text;
            cashier.User_name = this.txtUsername.Text;
            finvoice.lblCajeroName.Text = cashier.LongName;
            finvoice.txtTypeInvoice.Text = sell.tipo;
            finvoice.txtPermissionId.Text = cashier.Privileges.ToString();

            // Here add to evalute privileges
            //-->
            finvoice.txtUserId.Text = cashier.Id_user.ToString();

            UsuariosBO.getVisibleControls(cashier);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    finvoice.Text = "Ventas al Contado";
                    finvoice.DesVisibleCtrlInvCr();
                    finvoice.Show();
                    break;
                case "2":
                    // MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    finvoice.Text = "Ventas al Contado";
                    finvoice.DesVisibleCtrlInvCr();
                    finvoice.Show();
                    break;
                case "3":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "4":
                    finvoice.Text = "Ventas al Contado";
                    finvoice.DesVisibleCtrlInvCr();
                    finvoice.Show();
                    break;
            }            
        }


        /// <summary>
        /// Credit Invoice
        /// </summary>
        private void CreditS()
        {
            var casher = new UsuariosEntity();
            var venta = new VentaCrEntity();
            var ventas = new frmVenta();
            var allower = new frmAutorizar();
            var type = Int32.Parse(venta.Set_Type_invoice(FacturaBO.eType_invoices.credit.ToString())); // Get type invoice and convert to int value

            venta.tipo = type.ToString();
            ventas.txtTypeInvoice.Text = venta.tipo;
            casher.Id_user = Int32.Parse(this.txtIdUser.Text);
            casher.LongName = this.txtLongName.Text;
            casher.Privileges = this.txtPermisson.Text;
            casher.User_name = this.txtUsername.Text;
            ventas.lblCajeroName.Text = casher.LongName;
            ventas.txtPermissionId.Text = casher.Privileges.ToString();
            ventas.txtUsername.Text = casher.User_name;
            ventas.txtUserId.Text = casher.Id_user.ToString();
            

            // Here:
            // Validate permission before to access  into this module or use
            //


            ventas.txtUserId.Text = casher.Id_user.ToString();

            UsuariosBO.getVisibleControls(casher);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    ventas.Text = "Ventas a Crédito";
                    ventas.DesVisibleCtrlInvCash();
                    ventas.EnVisibleCtrlInvCr();
                    ventas.Show();
                    break;
                case "2":
                    allower.ShowDialog();
                    break;
                case "3":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case "4":
                    ventas.Text = "Ventas a Crédito";
                    ventas.DesVisibleCtrlInvCash();
                    ventas.EnVisibleCtrlInvCr();
                    ventas.Show();
                    break;
            }

        }




        /// <summary>
        /// Description about Controls 
        /// </summary>
        private void DetailControls()
        {
            this.toolTip1.SetToolTip(this.pbExitApp, "Salir del Sistema");
            this.toolTip1.SetToolTip(this.pbCashSell0, "Realizar Venta al Contado");
            this.toolTip1.SetToolTip(this.pbCashSell1, "Realizar Venta al Contado");
            this.toolTip1.SetToolTip(this.pbSellCred1, "Realizar Venta a Crédito");
            this.toolTip1.SetToolTip(this.pbIngProd, "Agregar Nuevos Productos");
            //this.toolTip1.SetToolTip(this.pictureBox4,"Ingresar Pedidos");
            this.toolTip1.SetToolTip(this.pbEditProv, "Editar Proveedor");
            this.toolTip1.SetToolTip(this.pbConsultProd, "Consultar Catalogo de Productos");
            this.toolTip1.SetToolTip(this.pbInvoiceCont, "Consultar Documentos de Ventas al Contado");
            this.toolTip1.SetToolTip(this.pbInvCancel, "Consultar Ventas Anuladas");
            this.toolTip1.SetToolTip(this.pbProdSold, "Historial de Articulos Vendidos");
            this.toolTip1.SetToolTip(this.pbConsInvoiceCred, "Consultar Documentos de Ventas a Crédito");
            this.toolTip1.SetToolTip(this.pbBalanceMonth, "Reporte de Balance por Meses");
            this.toolTip1.SetToolTip(this.pbBalanceDay, "Reporte de Balance del Día");
            this.toolTip1.SetToolTip(this.pbBalanceYear, "Reporte de Balance del Año");
            this.toolTip1.SetToolTip(this.pbChangeReturn, "Cambios y Devoluciones");
            this.toolTip1.SetToolTip(this.pbAddProd, "Agregar Nuevo Articulo al Inventario");
            this.toolTip1.SetToolTip(this.pbAddReq, "Ingresar Pedido por la Empresa");
            this.toolTip1.SetToolTip(this.pbConsProd, "Consultar Articulos");
            this.toolTip1.SetToolTip(this.pbExpProd, "Consultar Articulos a Expirar");
            this.toolTip1.SetToolTip(this.pbAddProvedor, "Agregar Nuevo Proveedor de Articulos");
            this.toolTip1.SetToolTip(this.pbConsProvedor, "Consultar Proveedores");
            this.toolTip1.SetToolTip(this.pbAddCustomers, "Agregar Nuevo Cliente");
            this.toolTip1.SetToolTip(this.pbGenPed, "Generar Pedidos");
            this.toolTip1.SetToolTip(this.pbGenShopping, "Generar Ordenes de Compras");
            this.toolTip1.SetToolTip(this.pbStockMin, "Stock mínimo de Articulos en Inventario");
            this.toolTip1.SetToolTip(this.pbAdjProduct, "Editar información de Articulos");
            this.toolTip1.SetToolTip(this.pbPayCredit, "Pagar Cuentas a Crédito");
            this.toolTip1.SetToolTip(this.pbPaidHistory, "Consultar Pagos del Clientes");
            this.toolTip1.SetToolTip(this.pbBalance, "Consultar Balance de clientes");
            this.toolTip1.SetToolTip(this.pbCredits, "Reporte de Creditos Pendientes");
            this.toolTip1.SetToolTip(this.pbaddUser, "Agregar Nuevo Usuario");
            this.toolTip1.SetToolTip(this.pbcloseBox, "Cerrar Caja Actual para finalizar las operaciones");
            this.toolTip1.SetToolTip(this.pbopenBox, "Aperturar Caja Actual para iniciar las operaciones");
            this.toolTip1.SetToolTip(this.pbhistoryBox, "Historial de Apertura o Cierre de Caja");
            this.toolTip1.SetToolTip(this.pbConsUser, "Consultar y Editar Usuarios");
            this.toolTip1.SetToolTip(this.pbEditCustomers, "Editar informaciones del Usuario");
            this.toolTip1.SetToolTip(this.pbConsultCustomer, "Consultar Usuarios");
        }



        /// <summary>
        /// Ask question System exit
        /// </summary>
        private void AppExit()
        {
            var user = new UsuariosEntity();
            var box = new OperationsCajaEntity();
            var fmbox = new frmCierreCaja();
            var answer = new DialogResult();

            answer = MessageBox.Show("Seguro que desea salir del Sistema", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (answer == DialogResult.Yes)
            {
                // function valide if current user has some box with opened status
                box.UserId = Convert.ToInt32(this.txtIdUser.Text);
                var statusbox = OperationsCajaBO.GetStatusBox(box);

                switch (statusbox)
                {
                    case 0:
                        Application.Exit();
                        break;

                    case 1:
                        MessageBox.Show(OperationsCajaBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                }
            }
            else if (answer == DialogResult.No)
            {
                return;
            }
        }


        private void pbChangeReturn_Click(object sender, EventArgs e)
        {
            
        }

        private void pbInvoiceCont_Click(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            user.Id_user = int.Parse(this.txtIdUser.Text);
            frmConsultFacturasCont ConsultFactEmit = new frmConsultFacturasCont();

            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    ConsultFactEmit.ShowDialog(this);
                    break;
                case "2":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "4":
                    break;
            }
        }

        private void pbConsInvoiceCred_Click(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            user.Id_user = int.Parse(this.txtIdUser.Text);
            frmConsulFactCredito FacturasCredito = new frmConsulFactCredito();


            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    FacturasCredito.ShowDialog(this);
                    break;
                case "2":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "4":
                    break;
            }
            
        }

        private void pbInvCancel_Click(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            user.Id_user = int.Parse(this.txtIdUser.Text);
            frmConsultFactAnuladas FactAnuladas = new frmConsultFactAnuladas();

            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    FactAnuladas.ShowDialog(this);
                    break;
                case "2":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "4":
                    break;
            }
        }

        private void pbProdSold_Click(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            user.Id_user = int.Parse(this.txtIdUser.Text);
            frmHistorialVentArticulos ArticulosVendidos = new frmHistorialVentArticulos();

            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    ArticulosVendidos.ShowDialog(this);
                    break;
                case "2":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "4":
                    break;
            }
        }

        private void pbAddProd_Click(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            user.Id_user = int.Parse(this.txtIdUser.Text);
            frmRegArticulos RegArt = new frmRegArticulos();

            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    RegArt.ShowDialog(this);
                    break;
                case "2":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    RegArt.ShowDialog(this);
                    break;
                case "4":
                    break;
            }
        }

        private void pbAddReq_Click(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            var editProduct = new frmAjustarProductos();
            user.Id_user = int.Parse(this.txtIdUser.Text);
            

            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    editProduct.ShowDialog(this);
                    break;
                case "2":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    editProduct.ShowDialog(this);
                    break;
                case "4":
                    break;
            }
        }

        private void pbExpProd_Click(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            var ArtVencer = new frmConsulArticulosExpirar();
            user.Id_user = int.Parse(this.txtIdUser.Text);


            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    ArtVencer.ShowDialog(this);
                    break;
                case "2":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    ArtVencer.ShowDialog(this);
                    break;
                case "4":
                    break;
            }
        }
        private void pbAddProvedor_Click(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            var fprovider = new frmRegProveedor();
            user.Id_user = int.Parse(this.txtIdUser.Text);
            fprovider.txtIdUser.Text = user.Id_user.ToString();

            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    fprovider.Text = "Agregar Nuevo Proveedor";
                    fprovider.ShowDialog(this);
                    break;
                case "2":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    fprovider.Text = "Agregar Nuevo Proveedor";
                    fprovider.ShowDialog(this);
                    break;
                case "4":
                    break;
            }
        }
        private void pbConsProvedor_Click(object sender, EventArgs e)
        {
            frmConsultarProveedor ConsultaProv = new frmConsultarProveedor();
            ConsultaProv.Show();
        }

        private void pbEditProv_Click(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            var proveedor = new frmConsultarProveedor();
            user.Id_user = int.Parse(this.txtIdUser.Text);
            proveedor.Text = "Editar Proveedor";


            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    proveedor.EnableControls();
                    proveedor.ShowDialog(this);
                    break;
                case "2":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "4":
                    proveedor.EnableControls();
                    proveedor.ShowDialog(this);
                    break;
            }
        }

        private void pbAddCustomers_Click(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            var regCustomer = new frmRegClientes();
            user.Id_user = int.Parse(this.txtIdUser.Text);
            regCustomer.txtIdUser.Text = user.Id_user.ToString();
            regCustomer.Text = "Agregar Nuevo Cliente";
            

            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    regCustomer.ShowDialog(this);
                    break;
                case "2":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "4":
                    regCustomer.ShowDialog(this);
                    break;
            }
        }

        private void pbCashSell0_Click(object sender, EventArgs e)
        {
            this.CashS();
        }

        private void pbCashSell1_Click(object sender, EventArgs e)
        {
            this.CashS();
        }

        private void pbConsultProd_Click(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            user.Id_user = int.Parse(this.txtIdUser.Text);
            user.Privileges = this.txtPermisson.Text;
            frmConsultarProductos productos = new frmConsultarProductos();
            productos.txtIdUser.Text = user.Id_user.ToString();
            productos.txtRol.Text = user.Privileges.ToString();
            productos.Text = "Consultar Articulos";
            productos.InniDisableControls();

            productos.Show(this);
        }

        private void pbConsProdMin_Click(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            var productos = new frmConsultarProductos();
            user.Id_user = int.Parse(this.txtIdUser.Text);
            
            productos.txtIdUser.Text = user.Id_user.ToString();
            // productos.txtRol.Text = user.Privileges.ToString();
            productos.Text = "Consultar Articulos";


            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    productos.InniDisableControls();
                    productos.Show(this);
                    break;
                case "2":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "4":
                    productos.InniDisableControls();
                    productos.Show(this);
                    break;
            }
        }

        private void pbIngProd_Click(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            frmRegArticulos articulos = new frmRegArticulos();
            user.Id_user =int.Parse(this.txtIdUser.Text);

            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    articulos.ShowDialog(this);
                    break;
                case "2":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    articulos.ShowDialog(this);
                    break;
                case "4":
                    break;
            }
        }

        private void pbStockMin_Click(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            var minimo = new frmStockMinimo();
            user.Id_user = int.Parse(this.txtIdUser.Text);

            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    minimo.ShowDialog(this);
                    break;
                case "2":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    minimo.ShowDialog(this);
                    break;
                case "4":
                    break;
            }
        }

        private void pbAdjProduct_Click(object sender, EventArgs e)
        {
            var productos = new frmConsultarProductos();
            var user = new UsuariosEntity();

            user.Id_user = int.Parse(this.txtIdUser.Text);
            user.Privileges = this.txtPermisson.Text;
            productos.txtIdUser.Text = user.Id_user.ToString();
            productos.txtRol.Text = user.Privileges.ToString();

            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    productos.Text = "Editar información de Articulos";
                    productos.IniControls();
                    productos.Show(this);
                    break;
                case "2":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "4":
                    break;
            }

        }

        private void consultarArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void crearNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pbConsultCustomer_Click(object sender, EventArgs e)
        {
            var conCustomer = new frmConsulClientes();
            var user = new UsuariosEntity();

            user.Id_user = int.Parse(this.txtIdUser.Text);
            
            conCustomer.txtIdUser.Text = user.Id_user.ToString();

            conCustomer.Text = "Consultar Clientes";
            

            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    conCustomer.btnEditar.Visible = false;
                    conCustomer.btnEliminar.Visible = false;
                    conCustomer.ShowDialog(this);
                    break;
                case "2":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "4":
                    conCustomer.btnEditar.Visible = false;
                    conCustomer.btnEliminar.Visible = false;
                    conCustomer.ShowDialog(this);
                    break;
            }
        }

        private void pbEditCustomers_Click(object sender, EventArgs e)
        {
            var conCustomer = new frmConsulClientes();
            var user = new UsuariosEntity();
            user.Id_user = int.Parse(this.txtIdUser.Text);
            
            conCustomer.txtIdUser.Text = user.Id_user.ToString();
            conCustomer.Text = "Ajustar Clientes";
            conCustomer.ShowDialog(this);

            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    conCustomer.ShowDialog(this);
                    break;
                case "2":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "4":
                    conCustomer.ShowDialog(this);
                    break;
            }
        }



        

        private void pbPayCredit_Click(object sender, EventArgs e)
        {
            var pay = new frmEfectPagosFactCred();
            var user = new UsuariosEntity();
            var sBox = new OperationsCajaEntity();
            var fmain = new frmPrincipal();
            user.LongName = fmain.txtLongName.Text;
            user.Id_user = int.Parse(this.txtIdUser.Text);
            pay.txtIdUser.Text = user.Id_user.ToString();
            sBox.UserId = int.Parse(this.txtIdUser.Text);
            var frmBox = new frmAbrirCaja();

            var status = OperationsCajaBO.GetStatusBox(sBox);

            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":

                    if(status == 0)
                    {
                        MessageBox.Show(OperationsCajaBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        frmBox.txtIdUser.Text = sBox.UserId.ToString();
                        frmBox.txtUserFirstNameLast.Text = user.LongName;
                        frmBox.ShowDialog(this);
                    }
                    else
                    {
                        pay.ShowDialog(this);
                    }
                    break;
                case "2":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "4":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void pbPaidHistory_Click(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            var hpagocred = new frmHistPagoClientesCr();
            var query = new CreditAccountEntity();
            query.Result = 1;
            user.Id_user = int.Parse(this.txtIdUser.Text);
            
            hpagocred.txtTypeQuery.Text = query.Result.ToString();

           

            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    hpagocred.ShowDialog(this);
                    break;
                case "2":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "4":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void pbBalance_Click(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            var hpagocred = new frmHistPagoClientesCr();
            var query = new CreditAccountEntity();
            query.Result = 2;
            user.Id_user = int.Parse(this.txtIdUser.Text);
            hpagocred.txtTypeQuery.Text = query.Result.ToString();
            hpagocred.Text = "Consultar Balance del Cliente";
            

            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    hpagocred.ShowDialog(this);
                    break;
                case "2":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "4":
                    hpagocred.ShowDialog(this);
                    break;
            }
        }

        private void pbSellCred1_Click(object sender, EventArgs e)
        {
            #region old code
            //var allow = new frmAutorizar();
            //var casher = new UsuariosEntity();
            //var venta = new VentaCrEntity();
            //frmVenta ventas = new frmVenta();
            //var type = Int32.Parse(venta.Set_Type_invoice(FacturaBO.eType_invoices.credit.ToString())); // Get type invoice and convert to int value

            //venta.tipo = type.ToString();
            //ventas.txtTypeInvoice.Text = venta.tipo;
            //casher.Id_user = Int32.Parse(this.txtIdUser.Text);
            //casher.LongName = this.txtLongName.Text;
            //casher.Privileges = this.txtPermisson.Text;
            //casher.User_name = this.txtUsername.Text;
            //ventas.lblCajeroName.Text = casher.LongName;
            //ventas.txtPermissionId.Text = casher.Privileges.ToString();
            //ventas.txtUsername.Text = casher.User_name;
            //ventas.txtUserId.Text = casher.Id_user.ToString();
            //allow.txtUserId.Text = casher.Id_user.ToString();
            //allow.txtUserName.Text = casher.User_name.ToString();
            //allow.txtLongName.Text = casher.LongName.ToString();

            //// Here:
            //// Validate permission before to access  into this module or use
            ////

            //UsuariosBO.getVisibleControls(casher);
            //var rol = UsuariosBO.result;

            //switch (rol)
            //{
            //    case "1":
            //        ventas.Text = "Ventas a Crédito";
            //        ventas.DesVisibleCtrlInvCash();
            //        ventas.EnVisibleCtrlInvCr();
            //        ventas.btnNewInvoiceCr.Focus();
            //        ventas.Show();
            //        break;
            //    case "2":
            //        allow.ShowDialog();
            //        break;
            //    case "3":
            //        MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        break;
            //    case "4":
            //        MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        break;
            //}
            #endregion

            CreditS();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            var rptProductosAct = new frmRepProductos();
            user.Id_user = Int32.Parse(this.txtIdUser.Text);


            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    rptProductosAct.Show();
                    break;
                case "2":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "4":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void pbaddUser_Click(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            var regUsers = new frmRegUsers();
            user.Id_user = Int32.Parse(this.txtIdUser.Text);
            regUsers.txtidUser.Text = user.Id_user.ToString();
            regUsers.btnUpdate.Visible = false;
            regUsers.DesableControls();

            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    regUsers.Show(this);
                    break;
                case "2":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "4":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void pbopenBox_Click(object sender, EventArgs e)
        {
            // info User      
            var user = new UsuariosEntity();
            var box = new OperationsCajaEntity();
            var fmbox = new frmAbrirCaja();

            user.Id_user = Int32.Parse(this.txtIdUser.Text); //
            user.LongName = this.txtLongName.Text;
            //user.User_name = this.txtUsername.Text;
            box.TypeOp = "2";
            box.Status = 1;
            fmbox.txtUserFirstNameLast.Text = user.LongName;
            //fmbox.txtUserName.Text = user.User_name;
            fmbox.txtIdUser.Text = user.Id_user.ToString();
            //fmbox.txtPermission.Text = user.Privileges.ToString();
            fmbox.txtType.Text = box.TypeOp.ToString();
            fmbox.txtIdTicket.Text = box.Status.ToString();

            // function valide if current user has some box with opened status
            box.UserId = Convert.ToInt32(this.txtIdUser.Text);
            var statusbox = OperationsCajaBO.GetStatusBox(box);


            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    if (statusbox != 1)
                    {
                        fmbox.ShowDialog(this);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(OperationsCajaBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;

                case "2":
                    if (statusbox != 1)
                    {
                        fmbox.ShowDialog(this);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(OperationsCajaBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    // MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case "3":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case "4":
                    if (statusbox != 1)
                    {
                        fmbox.ShowDialog(this);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(OperationsCajaBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    // MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void pbcloseBox_Click(object sender, EventArgs e)
        {
            // info User      
            var user = new UsuariosEntity();
            var box = new OperationsCajaEntity();
            var fmbox = new frmCierreCaja();
            var fbopen = new frmAbrirCaja();

            user.Id_user = Int32.Parse(this.txtIdUser.Text); //
            user.LongName = this.txtLongName.Text;
            //user.User_name = this.txtUsername.Text;
            box.TypeOp = "3";
            box.Status = 1;
            fmbox.txtUserFirstNameLast.Text = user.LongName;
            //fmbox.txtUserName.Text = user.User_name;
            fmbox.txtIdUser.Text = user.Id_user.ToString();
            //fmbox.txtPermission.Text = user.Privileges.ToString();
            fmbox.txtType.Text = box.TypeOp.ToString();
            // fmbox.txtStatus.Text = box.Status.ToString();

            // function valide if current user has some box with opened status
            box.UserId = Convert.ToInt32(this.txtIdUser.Text);
            var statusbox = OperationsCajaBO.GetStatusBox(box);

            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    if (statusbox != 0)
                    {
                        fmbox.ShowDialog(this);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(OperationsCajaBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        // fbopen.ShowDialog(this);
                    }
                    break;

                case "2":
                    if (statusbox != 0)
                    {
                        fmbox.ShowDialog(this);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(OperationsCajaBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        // fbopen.ShowDialog(this);
                    }
                    // MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case "3":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case "4":
                    if (statusbox != 0)
                    {
                        fmbox.ShowDialog(this);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(OperationsCajaBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        // fbopen.ShowDialog(this);
                    }
                    // MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void pbhistoryBox_Click(object sender, EventArgs e)
        {
            // info User      
            var user = new UsuariosEntity();
            var fmHbox = new frmConsOpCaja();

            user.Id_user = Int32.Parse(this.txtIdUser.Text); //
            user.Privileges = this.txtPermisson.Text.ToString();

            fmHbox.txtUserId.Text = user.Id_user.ToString();
            fmHbox.txtPermission.Text = user.Privileges.ToString();

            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                    fmHbox.iniControlAdmin();
                    fmHbox.ShowDialog(this);
                    break;
                case "2":
                    fmHbox.iniControls();
                    fmHbox.ShowDialog(this);
                    // MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "4":
                    fmHbox.ShowDialog(this);
                    // MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void pbConsUser_Click(object sender, EventArgs e)
        {
            // info User      
            var user = new UsuariosEntity();
            var fmCUser = new frmConsUsers();

            user.Id_user = Int32.Parse(this.txtIdUser.Text); //

            fmCUser.txtUserId.Text = user.Id_user.ToString();


            UsuariosBO.getVisibleControls(user);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case "1":
                        fmCUser.ShowDialog(this);
                    break;
                case "2":
                        MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                        MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "4":
                        MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void pbExitApp_Click(object sender, EventArgs e)
        {
            AppExit();
        }
    }
}
