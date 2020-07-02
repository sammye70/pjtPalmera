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
    public partial class frmConsultarProductos : Form
    {

        ProductosEntity productos = new ProductosEntity();

        public frmConsultarProductos()
        {
            InitializeComponent();
        }
        private long _numero;
        
        public long Orden
        {
            get { return _numero; }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.dgvProdConsultar.DataSource = null;
            this.txtCriterioBusqueda.Clear();
            this.Close();
        }

        private void frmConsultarProductos_Load(object sender, EventArgs e)
        {

            CleanControls();
            DesableControls();
            DetailControls();
            this.dgvProdConsultar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
            StockUnit();
            this.dgvProductOnlyActive.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvProductOnlyActive.DataSource = ProductosBO.OnlyActive();
            AutoSizeCells();
            AmountAllProduct();
            this.rbCodigo.Checked = true;
            this.txtCriterioBusqueda.Focus();
        }

        private void txtCriterioBusqueda_TextChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// All Controls  Descriptions
        /// </summary>
        private void DetailControls()
        {
            this.toolTip1.SetToolTip(this.btnEditarProd, "Editar Articulos Seleccionado");
            this.toolTip1.SetToolTip(this.btnRefrescar, "Actualizar Lista de Articulos Mostrados");
            this.toolTip1.SetToolTip(this.btnRemove, "Eliminar Articulo Seleccionado");
        }


        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.txtCriterioBusqueda.Text = "";
            productos = null;
            this.dgvProdConsultar.DataSource = null;
            this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
            this.txtCriterioBusqueda.Focus();
        }

        /// <summary>
        /// Auto Size All Cells
        /// </summary>
        private void AutoSizeCells()
        {
            this.dgvProdConsultar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }


        /// <summary>
        /// Clean Content in All Controls
        /// </summary>
        private void CleanControls()
        {
            this.lblCostoTotalProductRes.Text = "";
            this.lblCantidadProdRes.Text = "";
            this.lblCriterio.Text = "";
        }


        /// <summary>
        /// Desable and Enable Controls from Consult Products
        /// </summary>
        public void IniControls()
        {
            this.btnExpExcel.Visible = false;
            this.lblMensaje.Visible = true;
            this.dgvProductOnlyActive.Visible = true;
            this.dgvProdConsultar.Visible = false;
            this.lblCostoAllProductos.Visible = false;
            this.lblCostoTotalProductRes.Visible = false;
            this.btnRefrescar.Visible = false;
            this.btnRemove.Visible = false;
            this.btnEditarProd.Visible = false;
            this.rbStatus.Visible = false;
            this.btnSearch.Visible = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.rbCodigo.Focus();
        }

        /// <summary>
        /// Prepare to Control for New Search
        /// </summary>
        private void NewSearch()
        {
            this.txtCriterioBusqueda.Text = "";
        }

        /// <summary>
        /// Stock All Product by Unit
        /// </summary>
        private void StockUnit()
        {
            Int32 stock;
            stock = ProductosBO.CountProduct();
            this.lblCantidadProdRes.Text = Convert.ToString(stock);
        }


        /// <summary>
        /// Get Amount Cost All Products where status active
        /// </summary>
        private void AmountAllProduct()
        {
            decimal amount;
            amount = ProductosBO.GetAmountAllProducts();
            this.lblCostoTotalProductRes.Text = Convert.ToString(amount);
        }


        /// <summary>
        /// Desable all Controls 
        /// </summary>
        private void DesableControls()
        {
            //this.MaximizeBox = false;
            //this.MinimizeBox = false;
            this.dgvProdConsultar.ReadOnly = true;
            this.dgvProductOnlyActive.ReadOnly = true;
        }


        /// <summary>
        /// Filter product by code
        /// </summary>
        private void FilterProduct()
        {
            if ((this.rbCodigo.Checked == true) && (this.txtCriterioBusqueda.Text != string.Empty) && (this.rbDescription.Checked == false))
            {
                productos.Idproducto = Convert.ToInt64(this.txtCriterioBusqueda.Text);
                this.dgvProdConsultar.DataSource = ProductosBO.FilterProductbyCode(productos.Idproducto); //----------------------->Here
                this.dgvProductOnlyActive.DataSource = ProductosBO.FilterProductbyCode(productos.Idproducto);
            }
            else if ((this.rbDescription.Checked == true) && (this.txtCriterioBusqueda.Text != string.Empty) && (this.rbCodigo.Checked == false))
            {
                productos.Descripcion = this.txtCriterioBusqueda.Text;
                this.dgvProdConsultar.DataSource = ProductosBO.FilterProductbyDescp(productos.Descripcion);
                this.dgvProductOnlyActive.DataSource = ProductosBO.FilterProductbyDescp(productos.Descripcion); //------------------------> Here
                 MessageBox.Show("Indicar Descripcion del producto");
            }
            else
            {
                this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
                this.dgvProductOnlyActive.DataSource = ProductosBO.GetAll();
            }
            //if (this.txtCriterioBusqueda.Text != string.Empty)
            //{
            //    productos.Idproducto = Convert.ToInt64(this.txtCriterioBusqueda.Text);

            //    this.dgvProdConsultar.DataSource = ProductosBO.FilterProductbyCode(productos.Idproducto);
            //    this.dgvProductOnlyActive.DataSource = ProductosBO.FilterProductbyCode(productos.Idproducto);
            //}
            //else
            //{
            //    this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
            //    this.dgvProductOnlyActive.DataSource = ProductosBO.GetAll();
            //    this.txtCriterioBusqueda.Focus();
            //}
        }


        /// <summary>
        /// Edit Fields in Product and to Save Changes
        /// </summary>
        private void EditProduct()
        {
            frmRegArticulos ffproductos = new frmRegArticulos();
            try
            {

                DataGridViewRow x = dgvProdConsultar.CurrentRow;
                _numero = Convert.ToInt64(dgvProdConsultar.Rows[x.Index].Cells["Orden"].Value);


                ffproductos.Show();
                ffproductos.HideControls();
                ffproductos.Text = "Actualizar Información del Articulo";
                ffproductos.EnableControls();
                ffproductos.porcentaje();
                ffproductos.InitControl();

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

        private void dgvProdConsultar_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Check Stock if < 1 messager

            decimal cvalor = Convert.ToDecimal (this.dgvProdConsultar.Rows[e.RowIndex].Cells["Stock"].Value);

            try
            {
                if (cvalor <= 0)
                {
                    //  if (e.RowIndex == -1)
                    //    return;

                    _numero = Convert.ToInt64(dgvProdConsultar.Rows[e.RowIndex].Cells["Orden"].Value);

                    MessageBox.Show("No hay Stock disponible del producto", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.dgvProdConsultar.DataSource = null;
                    this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
                    return;
                } 

                else
                {
                    if (e.RowIndex == -1)
                        return;

                    _numero = Convert.ToInt64(dgvProdConsultar.Rows[e.RowIndex].Cells["Orden"].Value);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Get Product by Status
        /// </summary>
        private void LoadProductStatus()
        {
            if (this.cmbEstado.Text == "Activo")
            {
                this.dgvProdConsultar.DataSource = ProductosBO.GetProductosActive(productos);
            }
            else if (this.cmbEstado.Text == "Inactivo")
            {
                this.dgvProdConsultar.DataSource = ProductosBO.GetProductosDesable(productos);
            }
            else
            {
                MessageBox.Show("No hay productos que Mostrar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
            }
        }



        private void txtCriterioBusqueda_TextChanged_1(object sender, EventArgs e)
        {
            FilterProduct();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvProductOnlyActive_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            decimal cvalor = Convert.ToDecimal(this.dgvProdConsultar.Rows[e.RowIndex].Cells["Stock"].Value);

            try
            {
                if (cvalor <=0)
                {
                    //  if (e.RowIndex == -1)
                    //    return;

                    _numero = Convert.ToInt64(this.dgvProductOnlyActive.Rows[e.RowIndex].Cells["Orden"].Value);

                    MessageBox.Show("No hay Stock disponible del producto", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.dgvProductOnlyActive.DataSource = null;
                    this.dgvProductOnlyActive.DataSource = ProductosBO.GetAll();
                    return;
                }
                else
                {
                    if (e.RowIndex == -1)
                        return;

                    _numero = Convert.ToInt64(this.dgvProductOnlyActive.Rows[e.RowIndex].Cells["Orden"].Value);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /// <summary>
        /// Delete selected product
        /// </summary>
        private void DeleteProduct()
        {
            try
            {
                DataGridViewRow x = dgvProdConsultar.CurrentRow;
                _numero = Convert.ToInt64(dgvProdConsultar.Rows[x.Index].Cells["idproducto"].Value);
                ProductosBO.DeleteProduct(this.Orden);
            }
            catch
            {
                MessageBox.Show("Seleccione un Elemento", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Refresh Data in DataView
        /// </summary>
        private void RefreshGrid()
        {
            try
            {
                this.dgvProdConsultar.DataSource = null;
                this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        private void btnExpExcel_Click(object sender, EventArgs e)
        {
            frmRepProductos repProductos = new frmRepProductos();
            repProductos.ShowDialog(this);
        }

        private void btnEditarProd_Click(object sender, EventArgs e)
        {
            EditProduct();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult Question = new DialogResult();

            Question = MessageBox.Show("Seguro que desea eliminar el producto", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Question == DialogResult.Yes)
            {
                DeleteProduct();
                MessageBox.Show("El Producto fue Eliminado Satisfactoriamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgvProdConsultar.DataSource = null;
                this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
            }
            else if (Question == DialogResult.No)
            {
                this.dgvProdConsultar.DataSource = null;
                this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
                return;
            }
        }


        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void rbCodigo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbCodigo.Checked == true)
            {
                this.lblCriterio.Text = "Código";
                NewSearch();
                this.cmbEstado.Visible = false;
                this.txtCriterioBusqueda.Visible = true;
            }
        }

        private void rbDescription_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbDescription.Checked == true)
            {
                this.lblCriterio.Text = "Descripción";
                NewSearch();
                this.cmbEstado.Visible = false;
                this.txtCriterioBusqueda.Visible = true;
            }
        }

        private void rbStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbStatus.Checked == true)
            {
                this.lblCriterio.Text = "Estado";
                NewSearch();
                this.txtCriterioBusqueda.Visible = false;
                this.cmbEstado.Visible = true;
            }
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProductStatus();
        }
    }
}
