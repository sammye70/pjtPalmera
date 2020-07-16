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

       

        private void crearClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }



        private void facturasAnuladasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFactAnuladas FactAnuladas = new frmFactAnuladas();
            FactAnuladas.Show();
        }

        private void facturasEmitidasToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void efectuarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void notaDeCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNotasCredito NoteCredito = new frmNotasCredito();
            NoteCredito.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
           // splash splash = new splash();
            //splash.ShowDialog(this);
            //frmlogin login = new frmlogin();
            //login.ShowDialog();

            this.tabControl1.Visible = false;
            DetailControls();
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
                this.Close();
            }
            else if(answer == DialogResult.No)
            {        
               
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
            frmAbrirCaja ocaja = new frmAbrirCaja();
            ocaja.ShowDialog(this);
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
            frmVenta factura = new frmVenta();
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

        private void anularFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
    }
}
