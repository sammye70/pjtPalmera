using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pjPalmera.Entities;
using pjPalmera.BLL;

namespace pjPalmera.PL
{
    public partial class frmRegArticulos : Form
    {
        ProductosEntity producto = null;
        public frmRegArticulos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Desable all Controls from form
        /// </summary>
        private void DesableContros()
        {
            this.txtCodigo.Enabled = false;
            this.txtCosto.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.txtPrecioVenta.Enabled = false;
            this.txtStockInicial.Enabled = false;
            this.txtStockMinimo.Enabled = false;
            this.btnGuardar.Enabled = false;
            this.cmbFabrincante.Enabled = false;
            this.cmbFamilia.Enabled = false;
            this.dateTimePicker1.Enabled = false;
            this.cmbEstanteLocalizacion.Enabled = false;
        }

        /// <summary>
        /// Enable all Controls from form
        /// </summary>
        private void EnableControls()
        {
            this.txtCodigo.Enabled = true;
            this.txtCosto.Enabled = true;
            this.txtDescripcion.Enabled = true;
            this.txtPrecioVenta.Enabled = true;
            this.txtStockInicial.Enabled = true;
            this.txtStockMinimo.Enabled = true;
            this.btnGuardar.Enabled = true;
            this.cmbFabrincante.Enabled = true;
            this.cmbFamilia.Enabled = true;
            this.dateTimePicker1.Enabled = true;
            this.cmbEstanteLocalizacion.Enabled = true;
        }

        /// <summary>
        /// Set Detail about controls
        /// </summary>
        private void SetTooltipControls()
        {
            toolTip1.SetToolTip(btnNuevo, "Nuevo Registro");
            toolTip1.SetToolTip(btnGuardar, "Guardar Registro");
            toolTip1.SetToolTip(btnCancelar, "Limpiar Campos");
        }

        private void frmRegArticulos_Load(object sender, EventArgs e)
        {
            SetTooltipControls();
            DesableContros();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                NewProduct();

                DesableContros();
                MessageBox.Show("Guardado Satisfactoriamente","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EnableControls();
            producto = null;
        }

        /// <summary>
        /// Create New Product o Item
        /// </summary>
        private void NewProduct()
        {
            if (producto == null)
            {
                producto = new ProductosEntity();

                producto.idproducto = Convert.ToInt64(this.txtCodigo.Text);
                producto.idfabricante = Convert.ToInt32(this.cmbFabrincante.Text);
                producto.descripcion = this.txtDescripcion.Text;
                producto.idfamilia = Convert.ToInt32(this.cmbFamilia.Text);
                producto.stockinicial = Convert.ToDecimal(txtStockInicial.Text);
                producto.stockminimo = Convert.ToDecimal(this.txtStockMinimo.Text);
                producto.f_vencimiento = DateTime.Now.Date;
                producto.costo = Convert.ToDecimal(this.txtCosto.Text);
                producto.precio_venta = Convert.ToDecimal(txtPrecioVenta.Text);
                producto.created = DateTime.Now.Date;

                ProductosBO.Save(producto);
            }

        }
    }
}
