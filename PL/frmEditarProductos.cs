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
    public partial class frmEditarProductos : Form
    {
        frmRegArticulos fproductos = new frmRegArticulos();
        ProductosEntity productos = new ProductosEntity();

        private Int64 _idproducto;

        public frmEditarProductos()
        {
            InitializeComponent();
            DesableControls();
        }

        public Int64 Idproducto
        {
            get { return _idproducto; }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            CleanControls();
            this.txtCriterioBusqueda.Focus();
            this.label1.Text = "CODIGO";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            CleanControls();
            this.txtCriterioBusqueda.Focus();
            this.label1.Text = "DESCRIPCION";

        }

        /// <summary>
        /// Clean Content the Controls
        /// </summary>
        private void CleanControls()
        {
            this.txtCriterioBusqueda.Text = "";
        }

        /// <summary>
        /// Desable Controls
        /// </summary>
        private void DesableControls()
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.dgvProdConsultar.ReadOnly = true;
        }

        private void frmEditarProductos_Load(object sender, EventArgs e)
        {
            this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
              this.dgvProdConsultar.DataSource = null;
              this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked == true)
            {
                ProductosEntity producto = new ProductosEntity();
                producto.Idproducto = Convert.ToInt64(txtCriterioBusqueda.Text);
              // this.dgvProdConsultar.DataSource= ProductosBO.Searh_Code();
            }

            if (this.radioButton2.Checked == true)
            {

            }
        }

        /// <summary>
        /// Initialitation frmRegArticulos Controls
        /// </summary>
        private void InitControl()
        {
            fproductos.btnUpdateFields.Visible = true;
            fproductos.cmbEstado.Visible = true;
            fproductos.lblEstado.Visible = true;
            fproductos.txtCodigo.Focus();
        }

        /// <summary>
        /// Hide controls in frmRegArticulos when current form to call this.
        /// </summary>
        private void HideControls()
        { 
            fproductos.txtStockInicial.Visible = false;
            fproductos.txtStockMinimo.Visible = false;
            fproductos.lblStockInicial.Visible = false;
            fproductos.lblStockMinimo.Visible = false;
            fproductos.btnGuardar.Visible = false;
            fproductos.btnNuevo.Visible = false;
        }


        /// <summary>
        /// Edit Fields in Product and to Save in Databases
        /// </summary>
        private void EditProduct()
        {
            try
            {
                DataGridViewRow x = dgvProdConsultar.CurrentRow;


                _idproducto = Convert.ToInt64(dgvProdConsultar.Rows[x.Index].Cells["Idproducto"].Value);

                // this.DialogResult = DialogResult.OK;

                fproductos.Show();
                HideControls();
                fproductos.Text = "Actualizar Información del Articulo";
                fproductos.EnableControls();
                InitControl();

                productos = ProductosBO.Searh_Code(this.Idproducto);

                fproductos.txtCodigo.Text = Convert.ToString(productos.Idproducto);
                fproductos.txtDescripcion.Text = productos.Descripcion;
                fproductos.cmbFabrincante.Text = productos.Fabricante;
                fproductos.cmbFamilia.Text = productos.Categoria;
                fproductos.dateTimePicker1.Text = Convert.ToString(productos.Vencimiento);
                fproductos.txtCosto.Text = Convert.ToString(productos.Costo);
                fproductos.txtPrecioVenta.Text = Convert.ToString(productos.Precio_venta);

                //fproductos.LoadProveedor();
                //fproductos.Categories();
               
            }
            catch
            {
                productos = null;
                this.txtCriterioBusqueda.Focus();
                return;
                
            }

        }

        private void btnEditarProd_Click(object sender, EventArgs e)
        {
            EditProduct();
        }
    }
}
