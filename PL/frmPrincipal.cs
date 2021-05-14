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


        private void crearProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegProveedor Proveedor = new frmRegProveedor();
            Proveedor.Show();
        }

        private void consultarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultarProveedor ConsultaProv = new frmConsultarProveedor();
            ConsultaProv.Show();
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

        private void crearArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegArticulos RegArt = new frmRegArticulos();
            RegArt.ShowDialog(this);
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

        private void consultarArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultarProductos productos = new PL.frmConsultarProductos();
            productos.Text = "Ajustar y Consultar Articulos";
            productos.ShowDialog(this);
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmVenta Venta = new frmVenta();
            Venta.Show();
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

        /// <summary>
        /// Description about Controls
        /// </summary>
        private void DetailControls()
        {
            this.toolTip1.SetToolTip(this.pbExitApp,"Salir del Sistema");
            this.toolTip1.SetToolTip(this.pictureBox2, "Realizar Venta");
            this.toolTip1.SetToolTip(this.pictureBox3,"Crear Nuevos Productos");
            this.toolTip1.SetToolTip(this.pictureBox4,"Ingresar Pedidos");
        }

        /// <summary>
        /// Ask question 
        /// </summary>
        private void AppExit()
        {
            var answer = new DialogResult();

            answer = MessageBox.Show("Seguro que desea salir","Mensaje del Sistema",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
            
            if (answer == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if(answer == DialogResult.No)
            {
                return;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            AppExit();
        }

        private void ingresarPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAjustarProductos Pedido = new frmAjustarProductos();
            Pedido.ShowDialog(this);
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

        private void articulosAVencerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsulArticulosExpirar ArtVencer = new frmConsulArticulosExpirar();
            ArtVencer.ShowDialog(this);
        }

        private void consultarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void editarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultarProveedor EditProveedor = new frmConsultarProveedor();

            EditProveedor.Text = "Editar Proveedor";
            EditProveedor.EnableControls();
            EditProveedor.ShowDialog(this);
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

        private void stockMinimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockMinimo StockArticulos = new frmStockMinimo();
            StockArticulos.ShowDialog();
        }

        private void facturasEmitidasCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsulFactCredito ConFacturaCredito = new frmConsulFactCredito();
            ConFacturaCredito.ShowDialog(this);
        }

        private void crearNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegClientes RegistrarClientes = new frmRegClientes();
            RegistrarClientes.ShowDialog(this);
        }

        private void consultarClientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsulClientes ConsultarClientes = new frmConsulClientes();
            ConsultarClientes.Text = "Ajustar y Consultar Clientes";
            ConsultarClientes.ShowDialog(this);
        }

        private void asignarCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void facturasEmitidasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmConsultFacturasCont ConsultFactEmit = new frmConsultFacturasCont();
            ConsultFactEmit.ShowDialog(this);
        }

        private void consultarFacturasCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsulFactCredito FacturasCredito = new frmConsulFactCredito();
            FacturasCredito.ShowDialog(this);
        }

        private void historialArticulosVendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistorialVentArticulos ArticulosVendidos = new frmHistorialVentArticulos();
            ArticulosVendidos.ShowDialog(this);
        }

        private void efectuarVentaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Invoice Cash
            var venta = new VentaEntity();
            var casher = new UsuariosEntity();
            frmVenta factura = new frmVenta();

            var type = Int32.Parse(venta.set_Type_invoice((FacturaBO.eType_invoices.cash).ToString())); // Get type invoice and convert to int value
            venta.tipo = type.ToString();
            casher.Id_user = Int32.Parse(this.txtIdUser.Text);
            casher.LongName = this.txtLongName.Text;
            casher.Privileges = Int32.Parse(this.txtPermisson.Text);
            casher.User_name = this.txtUsername.Text;
            factura.lblCajeroName.Text = casher.LongName;
            factura.txtTypeInvoice.Text = venta.tipo;
            factura.txtPermissionId.Text = casher.Privileges.ToString();
            factura.txtUsername.Text = casher.User_name;
            factura.DesVisibleCtrlInvCr();
            factura.Show();
        }

        private void cxCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistPagoClientesCr HistorialPagosCr = new frmHistPagoClientesCr();

            HistorialPagosCr.ShowDialog(this);
        }

        private void efectuarPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEfectPagosFactCred CobrarFactCr = new frmEfectPagosFactCred();
            CobrarFactCr.ShowDialog(this);
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
            frmConsultFactAnuladas FactAnuladas = new frmConsultFactAnuladas();
            FactAnuladas.ShowDialog(this);
        }

        private void devolucionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCambios cambios = new frmCambios();
            cambios.ShowDialog(this);
        }

        private void ventaACréditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Credit Invoice
            var casher = new UsuariosEntity();
            var venta = new VentaCrEntity();
            frmVenta ventas = new frmVenta();
            var type = Int32.Parse(venta.set_Type_invoice((FacturaBO.eType_invoices.credit).ToString())); // Get type invoice and convert to int value

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
            ventas.Show();

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

            this.tabControl1.Visible = true;
            DetailControls();
        }

        private void pbRegClient_Click(object sender, EventArgs e)
        {
            frmRegClientes RegClient = new frmRegClientes();
            RegClient.Show(this);
        }
    }
}
