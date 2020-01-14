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

        private void generarReporteDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRepProveedor ReporteProv = new frmRepProveedor();
            ReporteProv.Show();
        }

        private void crearClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegClientes RegistrarClientes = new frmRegClientes();
            RegistrarClientes.Show();

        }

        private void generarReporteDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRepClientes ReporteClientes = new frmRepClientes();
            ReporteClientes.Show();
        }

        private void reporteDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRepFacturas ReporteFact = new frmRepFacturas();
            ReporteFact.Show();
        }

        private void facturasAnuladasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFactAnuladas FactAnuladas = new frmFactAnuladas();
            FactAnuladas.Show();
        }

        private void facturasEmitidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsulFactEmitidas ConsultFactEmit = new frmConsulFactEmitidas();
            ConsultFactEmit.Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            frmVenta Venta = new frmVenta();
            Venta.Show();
        }

        private void crearArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegArticulos RegArt = new frmRegArticulos();
            RegArt.Show();
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
            frmlogin login = new frmlogin();
            login.ShowDialog();

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
            frmVenta Venta = new PL.frmVenta();
            Venta.Show();
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
    }
}
