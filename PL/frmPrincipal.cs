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

     
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            AppExit();
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
            var box = new AperturaCajaEntity();
            frmAbrirCaja fmbox = new frmAbrirCaja();

            user.Id_user = Int32.Parse(this.txtIdUser.Text); //
            user.LongName = this.txtLongName.Text;
            user.User_name = this.txtUsername.Text;
            user.Privileges = Int32.Parse(this.txtPermisson.Text);
            box.TypeOp = 1;
            box.Status = 1;
            fmbox.txtUserFirstNameLast.Text = user.LongName;
            fmbox.txtUserName.Text = user.User_name;
            fmbox.txtIdUser.Text = user.Id_user.ToString();
            fmbox.txtPermission.Text = user.Privileges.ToString();
            fmbox.txtType.Text = box.TypeOp.ToString();
            fmbox.txtStatus.Text = box.Status.ToString();
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


        private void pictureBox7_Click(object sender, EventArgs e)
        {
            AppExit();
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
            var user = new UsuariosEntity();
            user.Id_user = int.Parse(this.txtIdUser.Text);

            this.tabControl1.Visible = true;
            this.DetailControls();
            this.ValidateProfiles(user);
            this.menuStrip1.Visible = false;
           
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
            user.Privileges = int.Parse(this.txtPermisson.Text);

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
            frmVenta finvoice = new frmVenta();

            var type = Int32.Parse(sell.Set_Type_invoice((FacturaBO.eType_invoices.cash).ToString())); // Get type invoice and convert to int value
            sell.tipo = type.ToString();
            cashier.Id_user = Int32.Parse(this.txtIdUser.Text);
            cashier.LongName = this.txtLongName.Text;
            cashier.Privileges = Int32.Parse(this.txtPermisson.Text);
            cashier.User_name = this.txtUsername.Text;
            finvoice.lblCajeroName.Text = cashier.LongName;
            finvoice.txtTypeInvoice.Text = sell.tipo;
            finvoice.txtPermissionId.Text = cashier.Privileges.ToString();
            finvoice.txtUsername.Text = cashier.User_name;
            // finvoice.DesVisibleCtrlInvCr();

            // Here add to evalute privileges
            //-->
            finvoice.txtUserId.Text = cashier.Id_user.ToString();

            UsuariosBO.getVisibleControls(cashier);
            var rol = UsuariosBO.result;

            switch (rol)
            {
                case 1:
                    finvoice.Show();
                    break;
                case 2:
                   // MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    finvoice.Show();
                    break;
                case 3:
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            frmVenta ventas = new frmVenta();
            var type = Int32.Parse(venta.Set_Type_invoice(FacturaBO.eType_invoices.credit.ToString())); // Get type invoice and convert to int value

            venta.tipo = type.ToString();
            ventas.txtTypeInvoice.Text = venta.tipo;
            casher.Id_user = Int32.Parse(this.txtIdUser.Text);
            casher.LongName = this.txtLongName.Text;
            casher.Privileges = Int32.Parse(this.txtPermisson.Text);
            casher.User_name = this.txtUsername.Text;
            ventas.lblCajeroName.Text = casher.LongName;
            ventas.txtPermissionId.Text = casher.Privileges.ToString();
            ventas.txtUsername.Text = casher.User_name;
            ventas.txtUserId.Text = casher.Id_user.ToString();
            ventas.Text = "Ventas a Crédito";
            ventas.DesVisibleCtrlInvCash();
            ventas.EnVisibleCtrlInvCr();
            ventas.btnNewInvoiceCr.Focus();

            // Here:
            // Validate permission before to access  into this module or use
            //

            ventas.Show();
        }




        /// <summary>
        ///  Users profiles validation to get controls
        /// </summary>
        public void ValidateProfiles(UsuariosEntity user)
        {
            try
            {
                UsuariosBO.getVisibleControls(user);
                var level = UsuariosBO.result;

                switch (level)
                {
                    case 0:
                        
                        break;

                    case 1:
                        level1Perm();
                        break;
                    case 2:
                        level2Perm();
                        break;
                    case 3:
                        level3Perm();
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(UsuariosBO.strMessegerBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            // this.toolTip1.SetToolTip(this.pictureBox4,"Ingresar Pedidos");
            this.toolTip1.SetToolTip(this.pbConsultProd, "Consultar Productos");
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
        }


        /// <summary>
        ///  Supervisor permission (Enable only controls for this rol)
        /// </summary>
        public static void level1Perm()
        {
 

        }

        /// <summary>
        ///  Cashier permission (Enable only controls for this rol)
        /// </summary>
        public  void level2Perm()
        {
            
            this.pbConsProvedor.Enabled = false;
            this.pbAddCustomers.Enabled = false;
            this.pbAddCustomers.Enabled = false;
            this.pbIngProd.Enabled = false;
            this.pbSellCred1.Enabled = false;
            this.pbInvoiceCont.Enabled = false;
            this.pbInvCancel.Enabled = false;
            this.pbProdSold.Enabled = false;
            this.pbAddProd.Enabled = false;
            this.pbChangeReturn.Enabled = false;
            this.pbAddReq.Enabled = false;
            // this.pbConsProd.Enabled = false;
            this.pbExpProd.Enabled = false;
            this.pbAddProvedor.Enabled = false;
            this.pbConsProvedor.Enabled = false;
            this.pbConsInvoiceCred.Enabled = false;
            this.pbAdjProduct.Enabled = false;
            this.pbPayCredit.Enabled = false;
            this.pbPaidHistory.Enabled = false;
            this.pbBalance.Enabled = false;
            this.pbCredits.Enabled = false;
          

        }

        /// <summary>
        ///  Reciving Clerk permission (Enable only controls for this rol)
        /// </summary>
        public  void level3Perm()
        {

        }


        /// <summary>
        /// Ask question System exit
        /// </summary>
        private void AppExit()
        {
            var answer = new DialogResult();

            answer = MessageBox.Show("Seguro que desea salir del Sistema", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (answer == DialogResult.Yes)
            {
                Application.Exit();
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
            frmConsultFacturasCont ConsultFactEmit = new frmConsultFacturasCont();
            ConsultFactEmit.ShowDialog(this);
        }

        private void pbConsInvoiceCred_Click(object sender, EventArgs e)
        {
            frmConsulFactCredito FacturasCredito = new frmConsulFactCredito();
            FacturasCredito.ShowDialog(this);
        }

        private void pbInvCancel_Click(object sender, EventArgs e)
        {
            frmConsultFactAnuladas FactAnuladas = new frmConsultFactAnuladas();
            FactAnuladas.ShowDialog(this);
        }

        private void pbProdSold_Click(object sender, EventArgs e)
        {
            frmHistorialVentArticulos ArticulosVendidos = new frmHistorialVentArticulos();
            ArticulosVendidos.ShowDialog(this);
        }

        private void pbAddProd_Click(object sender, EventArgs e)
        {
            frmRegArticulos RegArt = new frmRegArticulos();
            RegArt.ShowDialog(this);
        }

        private void pbAddReq_Click(object sender, EventArgs e)
        {
            frmAjustarProductos editProduct = new frmAjustarProductos();
            editProduct.ShowDialog(this);
        }


        private void pbExpProd_Click(object sender, EventArgs e)
        {
            frmConsulArticulosExpirar ArtVencer = new frmConsulArticulosExpirar();
            ArtVencer.ShowDialog(this);
        }

        private void pbAddProvedor_Click(object sender, EventArgs e)
        {
            frmRegProveedor fprovider = new frmRegProveedor();
            var provider = new ProveedorEntity();
            provider.Idproveedor = int.Parse(this.txtIdUser.Text);
            fprovider.txtIdUser.Text = provider.Idproveedor.ToString();
            fprovider.Text = "Agregar Nuevo Proveedor";
            fprovider.ShowDialog(this);
        }

        private void pbConsProvedor_Click(object sender, EventArgs e)
        {
            frmConsultarProveedor ConsultaProv = new frmConsultarProveedor();
            ConsultaProv.Show();
        }

        private void pbEditProv_Click(object sender, EventArgs e)
        {
            frmConsultarProveedor proveedor = new frmConsultarProveedor();
            proveedor.Text = "Editar Proveedor";
            proveedor.EnableControls();
            proveedor.ShowDialog(this);
        }

        private void pbAddCustomers_Click(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            user.Id_user = int.Parse(this.txtIdUser.Text);
            frmRegClientes regCustomer = new frmRegClientes();
            regCustomer.txtIdUser.Text = user.Id_user.ToString();
            regCustomer.Text = "Agregar Nuevo Cliente";
            regCustomer.ShowDialog(this);
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
            user.Privileges = int.Parse(this.txtPermisson.Text);
            frmConsultarProductos productos = new frmConsultarProductos();
            productos.txtIdUser.Text = user.Id_user.ToString();
            productos.txtRol.Text = user.Privileges.ToString();
            productos.Text = "Consultar Articulos";

            productos.Show(this);
        }

        private void pbConsProdMin_Click(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            user.Id_user = int.Parse(this.txtIdUser.Text);
            user.Privileges = int.Parse(this.txtPermisson.Text);
            frmConsultarProductos productos = new frmConsultarProductos();
            productos.txtIdUser.Text = user.Id_user.ToString();
            productos.txtRol.Text = user.Privileges.ToString();
            productos.Text = "Consultar Articulos";
            productos.btnEditarProd.Visible = false;
            productos.btnRemove.Visible = false;
            productos.Show(this);
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
                case 1:
                    articulos.ShowDialog(this);
                    break;
                case 2:
                    MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 3:
                    articulos.ShowDialog(this);
                    break;
            }
        }

        private void pbStockMin_Click(object sender, EventArgs e)
        {
            frmStockMinimo minimo = new frmStockMinimo();
            minimo.ShowDialog(this);
        }

        private void pbAdjProduct_Click(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            user.Id_user = int.Parse(this.txtIdUser.Text);
            user.Privileges = int.Parse(this.txtPermisson.Text);
            frmConsultarProductos productos = new frmConsultarProductos();
            productos.txtIdUser.Text = user.Id_user.ToString();
            productos.txtRol.Text = user.Privileges.ToString();
            productos.Text = "Editar información de Articulos";
            productos.Show(this);
        }

        private void consultarArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void crearNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pbConsultCustomer_Click(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            user.Id_user = int.Parse(this.txtIdUser.Text);
            frmConsulClientes conCustomer = new frmConsulClientes();
            conCustomer.txtIdUser.Text = user.Id_user.ToString();
            conCustomer.btnEditar.Visible = false;
            conCustomer.btnEliminar.Visible = false;
            conCustomer.Text = "Consultar Clientes";
            conCustomer.ShowDialog(this);
        }

        private void pbEditCustomers_Click(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            user.Id_user = int.Parse(this.txtIdUser.Text);
            frmConsulClientes conCustomer = new frmConsulClientes();
            conCustomer.txtIdUser.Text = user.Id_user.ToString();
            conCustomer.Text = "Ajustar Clientes";
            conCustomer.ShowDialog(this);
        }

        private void pbPayCredit_Click(object sender, EventArgs e)
        {
            var user = new UsuariosEntity();
            user.Id_user = int.Parse(this.txtIdUser.Text);
            frmEfectPagosFactCred pay = new frmEfectPagosFactCred();
            pay.txtIdUser.Text = user.Id_user.ToString();
            pay.ShowDialog(this);
        }

        private void pbPaidHistory_Click(object sender, EventArgs e)
        {
            var query = new CreditAccountEntity();
            query.Result = 1;
            frmHistPagoClientesCr hpagocred = new frmHistPagoClientesCr();
            hpagocred.txtTypeQuery.Text = query.Result.ToString();

            hpagocred.ShowDialog(this);
        }

        private void pbBalance_Click(object sender, EventArgs e)
        {
            var query = new CreditAccountEntity();
            query.Result = 2;
            frmHistPagoClientesCr hpagocred = new frmHistPagoClientesCr();
            hpagocred.txtTypeQuery.Text = query.Result.ToString();
            hpagocred.Text = "Consultar Balance del Cliente";
            hpagocred.ShowDialog(this);
        }

        private void pbSellCred1_Click(object sender, EventArgs e)
        {
            var casher = new UsuariosEntity();
            var venta = new VentaCrEntity();
            frmVenta ventas = new frmVenta();
            var type = Int32.Parse(venta.Set_Type_invoice(FacturaBO.eType_invoices.credit.ToString())); // Get type invoice and convert to int value

            venta.tipo = type.ToString();
            ventas.txtTypeInvoice.Text = venta.tipo;
            casher.Id_user = Int32.Parse(this.txtIdUser.Text);
            casher.LongName = this.txtLongName.Text;
            casher.Privileges = Int32.Parse(this.txtPermisson.Text);
            casher.User_name = this.txtUsername.Text;
            ventas.lblCajeroName.Text = casher.LongName;
            ventas.txtPermissionId.Text = casher.Privileges.ToString();
            ventas.txtUsername.Text = casher.User_name;
            ventas.txtUserId.Text = casher.Id_user.ToString();
            ventas.Text = "Ventas a Crédito";
            ventas.DesVisibleCtrlInvCash();
            ventas.EnVisibleCtrlInvCr();
            ventas.btnNewInvoiceCr.Focus();

            // Here:
            // Validate permission before to access  into this module or use
            //
        }
    }
}
