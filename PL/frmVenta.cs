using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class frmVenta : Form
    {
        private BLL.Entity.clsVenta venta;

        public frmVenta()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
            
        }

        private void btnBuscarClientes_Click(object sender, EventArgs e)
        {
            if (txtClientes.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un cliente");
                this.txtClientes.Focus();
                return;
;            }

            venta = new BLL.Entity.clsVenta(txtClientes.Text);
            Detalledgv.DataSource = venta.Productos;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (venta == null)
            {
                MessageBox.Show("Debe ingresar un cliente");
                this.txtClientes.Focus();
                return;
            }

            if (this.txtProductos.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un Producto");
                this.txtProductos.Focus();
                return;
            }

            int id;
            if (!int.TryParse(txtProductos.Text, out id))
            {
                MessageBox.Show("Debe ingresar un Codigo numerico");
                this.txtProductos.Focus();
                return;
            }
        }
    }
}
