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

        private void frmRegArticulos_Load(object sender, EventArgs e)
        {
            InitializeControls();
            DesableContros();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                NewProduct();
                CleanControls();
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
        /// Set properties the controls
        /// </summary>
        private void InitializeControls()
        {
            this.toolTip1.SetToolTip(btnNuevo, "Nuevo Registro");
            this.toolTip1.SetToolTip(btnGuardar, "Guardar Registro");
            this.toolTip1.SetToolTip(btnCancelar, "Limpiar Campos");
            this.dateTimePicker1.Format = DateTimePickerFormat.Short;
        }

        /// <summary>
        /// Create New Product or Item
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
                producto.stockinicial = Convert.ToInt32(txtStockInicial.Text);
                producto.stockminimo = Convert.ToInt32(this.txtStockMinimo.Text);
                producto.f_vencimiento = Convert.ToDateTime(dateTimePicker1.Value.Date.ToShortDateString());
                producto.costo = Convert.ToDecimal(this.txtCosto.Text);
                producto.precio_venta = Convert.ToDecimal(txtPrecioVenta.Text);
                producto.created = DateTime.Now.Date;

                ProductosBO.Save(producto);
            }

        }

        /// <summary>
        /// Clean Content to all Controls
        /// </summary>
        private void CleanControls()
        {
            this.txtCodigo.Text = "";
            this.txtDescripcion.Text = "";
            this.txtCosto.Text = "";
            this.txtPrecioVenta.Text = "";
            this.txtStockInicial.Text = "";
            this.txtStockMinimo.Text = "";
            this.cmbEstanteLocalizacion.Text = "";
            this.cmbFabrincante.Text = "";
            this.cmbFamilia.Text = "";
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            frmCategoria categoria = new frmCategoria();
            categoria.ShowDialog(this);
        }
    }
}
