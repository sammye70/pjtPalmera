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
        frmRegArticulos ffproductos = new frmRegArticulos();
        ProductosEntity productos = new ProductosEntity();

        private Int64 _orden;
        private Int64 _idproducto;

        public frmEditarProductos()
        {
            InitializeComponent();
            DesableControls();
            DetailControls();
        }

        public Int64 Idproducto
        {
            get { return _idproducto; }
        }

        public Int64 Orden
        {
            get { return _orden; }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            CleanControls();
            this.txtCriterioBusqueda.Focus();
            this.lblCriterio.Text = "CODIGO";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            CleanControls();
            this.txtCriterioBusqueda.Focus();
            this.lblCriterio.Text = "DESCRIPCION";

        }

        /// <summary>
        /// Clean Content the Controls
        /// </summary>
        private void CleanControls()
        {
            this.txtCriterioBusqueda.Clear();
        }

        /// <summary>
        /// Desable Controls
        /// </summary>
        private void DesableControls()
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.lblCriterio.Text = "";
            this.dgvProdConsultar.ReadOnly = true;
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
            //this.dgvProdConsultar.Columns["Orden"].Visible = false;
        }

        private void frmEditarProductos_Load(object sender, EventArgs e)
        {
            this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            DesableControls();
            this.dgvProdConsultar.DataSource = null;
            this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
         
        }

        /// <summary>
        /// Initialitation frmRegArticulos Controls
        /// </summary>
        private void InitControl()
        {
            ffproductos.btnUpdateFields.Visible = true;
            ffproductos.cmbEstado.Visible = true;
            ffproductos.lblEstado.Visible = true;
            ffproductos.txtCodigo.Focus();
        }

        /// <summary>
        /// Hide controls in frmRegArticulos when current form to call this.
        /// </summary>
        private void HideControls()
        { 
            //ffproductos.txtStockInicial.Visible = false;
            //ffproductos.txtStockMinimo.Visible = false;
            //ffproductos.lblStockInicial.Visible = false;
            //ffproductos.lblStockMinimo.Visible = false;
            ffproductos.btnGuardar.Visible = false;
            ffproductos.btnNuevo.Visible = false;
        }


        /// <summary>
        /// Edit Fields in Product and to Save in Databases
        /// </summary>
        private void EditProduct()
        {
            try
            {

                  DataGridViewRow x = dgvProdConsultar.CurrentRow;
                  _orden = Convert.ToInt64(dgvProdConsultar.Rows[x.Index].Cells["Orden"].Value); 
       

                ffproductos.Show();
                HideControls();
                ffproductos.Text = "Actualizar Información del Articulo";
                ffproductos.EnableControls();
                ffproductos.porcentaje();
                InitControl();

                productos = ProductosBO.SearchByOrden(this.Orden);

                ffproductos.txtOrden.Text = Convert.ToString(productos.Orden);
                ffproductos.txtCodigo.Text = Convert.ToString(productos.Idproducto);
                ffproductos.txtDescripcion.Text = productos.Descripcion;
                ffproductos.cmbFabrincante.Text = productos.Fabricante;
                ffproductos.cmbFamilia.Text = productos.Categoria;
                ffproductos.dateTimePicker1.Text = Convert.ToString(productos.Vencimiento);
                ffproductos.txtCosto.Text = Convert.ToString(productos.Costo);
                ffproductos.txtPrecioVenta.Text = Convert.ToString(productos.Precio_venta);
                ffproductos.txtStockInicial.Text = Convert.ToString(productos.Stock);
                ffproductos.txtStockMinimo.Text = Convert.ToString(productos.Stockminimo);
                ffproductos.cmbEstado.Text = productos.Status;

                //ffproductos.LoadProveedor();
                //ffproductos.Categories();
               
            }
            catch
            {
                productos = null;
                this.txtCriterioBusqueda.Focus();
                return;
            }

        }



        /// <summary>
        /// Filter Product by Code
        /// </summary>
        private void SearchByCode()
        {
            if ((txtCriterioBusqueda.Text != string.Empty))
            {
                try
                {
                    productos.Idproducto = Convert.ToInt64(this.txtCriterioBusqueda.Text);
                    this.dgvProdConsultar.DataSource = ProductosBO.FilterProductbyCode(productos.Idproducto);
                }
                catch
                {

                }
            }
            else
            {
                this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
                this.txtCriterioBusqueda.Focus();
            }
        }

        /// <summary>
        /// Filter Product by Description
        /// </summary>
        private void SearchByDescrip()
        {
            if ((this.txtCriterioBusqueda.Text != string.Empty))
            {
                productos.Descripcion = this.txtCriterioBusqueda.Text;

                this.dgvProdConsultar.DataSource = ProductosBO.FilterProductbyDescp(productos.Descripcion);
            }
            else
            {
                this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
                this.txtCriterioBusqueda.Focus();
            }
        }

        /// <summary>
        /// Controls Descriptions
        /// </summary>
        private void DetailControls()
        {
            this.toolTip1.SetToolTip(this.btnEditarProd,"Editar Articulos Seleccionado");
            this.toolTip1.SetToolTip(this.btnRefrescar, "Actualizar");
            this.toolTip1.SetToolTip(this.btnEliminar, "Desactivar Articulo");
        }



        /// <summary>
        /// Delete selected product
        /// </summary>
        private void DeleteProduct()
        {
           try
             {
                DataGridViewRow x = dgvProdConsultar.CurrentRow;
                _idproducto = Convert.ToInt64(dgvProdConsultar.Rows[x.Index].Cells["idproducto"].Value);
                ProductosBO.DeleteProduct(this.Idproducto);
                }
            catch
            {
                // MessageBox.Show("Seleccione un Elemento","Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            }
        }

        private void btnEditarProd_Click(object sender, EventArgs e)
        {
            EditProduct();
        }

        private void txtCriterioBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked == true)
            {
                SearchByCode();
            }

            if (this.radioButton2.Checked == true)
            {
                SearchByDescrip();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult Question = new DialogResult();

            Question = MessageBox.Show("Seguro que desea eliminar el producto", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Question == DialogResult.Yes)
            {
                DeleteProduct();
                MessageBox.Show("El Producto fue eliminado", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgvProdConsultar.DataSource = null;
                this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
            }
            else if(Question == DialogResult.No)
            {
                this.dgvProdConsultar.DataSource = null;
                this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
                return;
            }
        }
    }
}
