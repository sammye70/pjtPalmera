using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            frmRegClientes RegistrarClientes = new frmRegClientes();
            RegistrarClientes.ShowDialog(this);

        }



        private void facturasAnuladasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFactAnuladas FactAnuladas = new frmFactAnuladas();
            FactAnuladas.Show();
        }

        private void facturasEmitidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultFacturasCont ConsultFactEmit = new frmConsultFacturasCont();
            ConsultFactEmit.ShowDialog(this);
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
            frmVenta factura = new frmVenta();
            factura.Show();
        }

        private void notaDeCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNotasCredito NoteCredito = new frmNotasCredito();
            NoteCredito.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //frmlogin login = new frmlogin();
            //login.ShowDialog();
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
           DialogResult result = MessageBox.Show("Seguro que desea salir","Mensaje del Sistema",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else if( result == DialogResult.No)
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
            frmArticulosExpirar ArtVencer = new frmArticulosExpirar();
            ArtVencer.ShowDialog(this);
        }

        private void consultarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsulClientes ConsultarClientes = new frmConsulClientes();
            ConsultarClientes.ShowDialog(this);

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
    }
}
