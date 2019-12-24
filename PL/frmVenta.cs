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
        private BLL.Entity.clsVenta venta = null;

        public frmVenta()
        {
            InitializeComponent();
        }


        private void frmVenta_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            Limpiar();
            Deshabilitar();
            this.btnNuevo.Focus();
        }

        private void btnBuscarClientes_Click(object sender, EventArgs e)
        {
            if (txtClientes.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un cliente");
                this.txtClientes.Focus();
                return;
                ; }

            venta = new BLL.Entity.clsVenta(txtClientes.Text);
            dgvDetalle.DataSource = venta.Productos;
        }


        //
        private void Limpiar()
        {
            //this.txtClientes.Clear();
            this.txtProductos.Clear();
            this.txtDescripcion.Clear();
            this.txtPrecio.Clear();
            this.txtCantidad.Clear();
            //this.txtSubtotal.Clear();
            //this.txtTotalPagar.Clear();
           // this.txtItbis.Clear();
        }
        //
        private void Deshabilitar()
        {
            this.txtClientes.Enabled = false;
            this.txtCantidad.Enabled = false;
            this.txtPrecio.Enabled = false;
            this.txtProductos.Enabled = false;
            this.btnAgregar.Enabled = false;
            this.btnPagar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.cmbTipoVenta.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.txtItbis.Enabled = false;
            this.txtSubtotal.Enabled = false;
            this.txtTotalPagar.Enabled = false;
            this.txtDescuento.Enabled = false;
            this.chbDescuento.Enabled = false;
            if (dgvDetalle == null)
            {
                this.chbDescuento.Enabled = false;
            }
        }
        //
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
            this.txtSubtotal.Enabled = true;
            this.txtTotalPagar.Enabled = true;
            this.txtDescuento.Enabled = true;
            this.btnCancelar.Enabled = true;
            if (dgvDetalle != null)
            {
                this.chbDescuento.Enabled = true;
            }

        }
        //
        private void OnlyRead()
        {
            this.txtSubtotal.ReadOnly = true;
            this.txtTotalPagar.ReadOnly = true;
            this.txtItbis.ReadOnly = true;
            this.txtDescuento.ReadOnly = true;
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Habilitar();
            Limpiar();
            OnlyRead();
            this.dgvDetalle.DataSource = null;
            this.cmbTipoVenta.Focus();
              
        }

        private void cmbTipoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbTipoVenta.Text == "Contado")
            {
                this.txtClientes.Text = "Contado";
                venta = new BLL.Entity.clsVenta(txtClientes.Text);
                dgvDetalle.DataSource = venta.Productos;
                this.txtProductos.Focus();
            }
            if (this.cmbTipoVenta.Text == "Credito")
            {
                this.txtClientes.Clear();
                this.btnBuscarClientes.Focus();
                dgvDetalle.DataSource = null;
            }
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

            if (id <= 0)
            {
                MessageBox.Show("Debe ingresar un Codigo Valido");
                this.txtProductos.Focus();
                return;
            }


            if (this.txtDescripcion.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar una Descripcion");
                this.txtDescripcion.Focus();
                return;
            }

            if (this.txtCantidad.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar una cantidad");
                this.txtCantidad.Focus();
                return;
            }

            float cantidad = 0;
            if (!float.TryParse(txtCantidad.Text, out cantidad))
            {
                MessageBox.Show("Debe ingresar una cantidad numerica");
                this.txtCantidad.Focus();
                return;
            }

            if (cantidad <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad mayor que 0");
                this.txtCantidad.Focus();
                return;
            }

            if (this.txtPrecio.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un precio");
                this.txtPrecio.Focus();
                return;
            }

            decimal precio = 0;
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Debe ingresar un precio valido");
                this.txtCantidad.Focus();
                return;
            }

            if (precio <= 0)
            {
                MessageBox.Show("Debe ingresar un precio mayor que 0");
                this.txtPrecio.Focus();
                return;
            }

            //add products to Gridview
            BLL.Entity.clsProducto productos = new BLL.Entity.clsProducto();
            productos.Id = id;
            productos.Descripcion = txtDescripcion.Text;
            productos.Cantidad = cantidad;
            productos.Precio_Venta = precio;
            productos.itbis = decimal.Parse(txtItbis.Text);
            venta.addProduct(productos);
            dgvDetalle.DataSource = null;
            dgvDetalle.DataSource = venta.Productos;

            decimal total, t_pagar;
            decimal _itbis=18, t_itbis;
            total = venta.Total();
            t_itbis = (total * _itbis) / 100;
            t_pagar = t_itbis + total;
            this.txtSubtotal.Text = string.Format("{0:C2}",total);
            this.txtItbis.Text = string.Format("{0:C2}", t_itbis);
            this.txtTotalPagar.Text = string.Format("{0:C2}",t_pagar);
            Limpiar();
            this.txtProductos.Focus();

        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            frmConsultarProductos consulProductos = new frmConsultarProductos();
            consulProductos.Show();
            consulProductos.Text = "Buscar Productos";
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            //Deshabilitar();
            this.btnNuevo.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label14.Text = DateTime.Now.ToString("hh:mm:ss tt");
            label15.Text = DateTime.Now.ToLongDateString();
        }
    }
}
