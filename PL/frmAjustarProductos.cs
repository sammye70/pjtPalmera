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

namespace pjPalmera.PL
{
    public partial class frmAjustarProductos : Form
    {
        ProductosEntity productos = new ProductosEntity();

        public frmAjustarProductos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clean content of controls
        /// </summary>
        private void CleanControls()
        {
            this.txtCodigoProducto.Text = "";
            this.txtCantidad.Text = "";
        }

        /// <summary>
        /// Desable all Controls
        /// </summary>
        private void DesableControls()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.dgvProductos.ReadOnly = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CleanControls();
            productos = null;
        }

        private void frmAjustarProductos_Load(object sender, EventArgs e)
        {
          DesableControls();
          this.dgvProductos.DataSource= ProductosBO.GetAll();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //
            //Update Stock in one product, Take to deferences idproducto, Then search it.
            //
            productos = new ProductosEntity();

            productos.Idproducto = Convert.ToInt64(this.txtCodigoProducto.Text);
            productos.Stock = Convert.ToUInt32(txtCantidad.Text);

            ProductosBO.Increment_Stock(productos); //

            this.dgvProductos.DataSource = null;
            this.dgvProductos.DataSource = ProductosBO.GetAll();
        }
    }
}
