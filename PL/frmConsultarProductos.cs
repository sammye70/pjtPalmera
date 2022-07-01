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
using System.IO;

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
        private decimal _quantity;
      

        public long Orden
        {
            get { return _numero; }
        }

        public decimal getQuantity
        {
            get { return _quantity; }        
        }

        UsuariosEntity user = new UsuariosEntity();

        private void frmConsultarProductos_Load(object sender, EventArgs e)
        {

            CleanControls();
            DesableControls();
            DetailControls();

            //StockUnit();
            AutoSizeCells();
            //AmountAllProduct();
            InitialControls();
            this.txtCriterioBusqueda.Focus();
            this.dgvProdConsultar.Rows[0].Selected = false;
            this.dgvProdConsultar.CurrentRow.Selected = false;
            

        }
    

        /// <summary>
        /// All Controls  Descriptions
        /// </summary>
        private void DetailControls()
        {
            this.toolTip1.SetToolTip(this.btnEditarProd, "Editar Articulos Seleccionado");
            this.toolTip1.SetToolTip(this.btnRefrescar, "Actualizar Lista de Articulos Mostrados");
            this.toolTip1.SetToolTip(this.btnRemove, "Eliminar Articulo Seleccionado");
            this.toolTip1.SetToolTip(this.btnSearch, "Realiza la acción de búsqueda para el filtro seleccionado");
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
        ///  Visible true Controls before call Consult Products.
        /// </summary>
        public void IniControls()
        {
            //this.lblMensaje.Visible = true;
            //this.dgvProductOnlyActive.Visible = true;
            //this.dgvProdConsultar.Visible = false;
            //this.lblCostoAllProductos.Visible = false;
            //this.lblCostoTotalProductRes.Visible = false;
            this.btnRefrescar.Visible = true;
            this.btnRemove.Visible = true;
            this.btnEditarProd.Visible = true;
            //this.rbStatus.Visible = false;
            //this.btnSearch.Visible = false;
            //this.MaximizeBox = false;
            //this.MinimizeBox = false;
            //this.rbCodigo.Focus();
            //this.btnSearch.Visible = false;
            // this.dgvProdConsultar.Visible = false;
            this.dgvProductOnlyActive.DataSource = ProductosBO.OnlyActive();
        }


        /// <summary>
        ///  Visible False Controls before call Consult Products.
        /// </summary>
        public void InniDisableControls()
        {
            this.btnRefrescar.Visible = false;
            this.btnRemove.Visible = false;
            this.btnEditarProd.Visible = false;
        }

        /// <summary>
        /// Prepare to Control for New Search
        /// </summary>
        private void NewSearch()
        {
            this.txtCriterioBusqueda.Text = "";
            this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
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
        ///  Get info for current user
        /// </summary>
        /// <param name="user"></param>
        public void getUserRol(UsuariosEntity user)
        {
            try
            {
                UsuariosBO.getVisibleControls(user);
                var rol = UsuariosBO.result;

                switch (rol)
                {
                    case "1":
                        rol1();
                        break;
                    case "2":
                        rol2();
                        break;
                    case "3":
                        break;
                }
            }

            catch (Exception)
            {
                MessageBox.Show(UsuariosBO.strMessegerBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

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
            this.lblCostoAllProductos.Visible = false;
            this.lblCostoTotalProductRes.Visible = false;
            this.lblCantidadProdRes.Visible = false;
            this.lblTotalProductos.Visible = false;
        }



        /// <summary>
        ///  Supervisor permission (Enable only controls for this rol)
        /// </summary>
        public void rol1()
        {
            //this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
            this.dgvProdConsultar.Columns["Creado_Por"].Visible = false;
            this.dgvProdConsultar.Columns["Creado"].Visible = false;
            this.dgvProdConsultar.Columns["Stockminimo"].Visible = false;
        }

        /// <summary>
        ///  Cashier permission (Enable only controls for this rol)
        /// </summary>
        public void rol2()
        {
            //this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
            this.btnEditarProd.Visible = false;
            this.btnRemove.Visible = false;
            this.rbStatus.Visible = false;
            this.dgvProdConsultar.Columns["Costo"].Visible = false;
            this.dgvProdConsultar.Columns["Estado"].Visible = false;
            this.dgvProdConsultar.Columns["Creado_Por"].Visible = false;
            this.dgvProdConsultar.Columns["Creado"].Visible = false;
            this.dgvProdConsultar.Columns["Stockminimo"].Visible = false;
            this.dgvProdConsultar.Columns["Orden"].Visible = false;

            // this.dgvProdConsultar.Columns["Modificated"].Visible = false;

        }

        /// <summary>
        ///  Reciving Clerk permission (Enable only controls for this rol)
        /// </summary>
        private void rol3()
        {

        }



        /// <summary>
        /// Filter product by code or descripcion
        /// </summary>
        public void FilterProduct()
        {
 
            if ((this.rbDescription.Checked == true) && (this.txtCriterioBusqueda.Text != string.Empty) && (this.rbCodigo.Checked == false) && (this.rbCategory.Checked == false))
            {
                this.btnSearch.Visible = false;
                var values = this.txtCriterioBusqueda.Text;
                this.dgvProdConsultar.DataSource = ProductosBO.FilterProductbyDescp(values);
                this.dgvProductOnlyActive.DataSource = ProductosBO.FilterProductbyDescp(values);
            }
            else if ((this.rbCodigo.Checked == true) && (this.txtCriterioBusqueda.Text != string.Empty) && (this.rbDescription.Checked == false))
            {
                this.btnSearch.Visible = false;
                var values = this.txtCriterioBusqueda.Text;
                this.dgvProdConsultar.DataSource = ProductosBO.FilterProductbyCodeAll(Convert.ToInt64(values));
                this.dgvProdConsultar.DataSource = ProductosBO.FilterProductbyCodeOnlyAct(Convert.ToInt64(values));
                this.dgvProductOnlyActive.DataSource = ProductosBO.FilterProductbyCodeOnlyAct(Convert.ToInt64(values));
            }
            else
            {
                this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
                //this.dgvProductOnlyActive.DataSource = ProductosBO.GetAll();
                this.txtCriterioBusqueda.Focus();
            }
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
                ffproductos.txtCodigo.Text = Convert.ToString(productos.Codigo);
                ffproductos.txtDescripcion.Text = productos.Descripcion;
                ffproductos.cmbDistribuidor.Text = productos.Proveedor;
                ffproductos.cmbFamilia.Text = productos.Categoria;
                ffproductos.dateTimePicker1.Text = Convert.ToString(productos.Vencimiento);
                ffproductos.txtCosto.Text = Convert.ToString(productos.Costo);
                ffproductos.txtPrecioVenta.Text = Convert.ToString(productos.Precio_venta);
                ffproductos.txtStockInicial.Text = Convert.ToString(productos.Stock);
                ffproductos.txtStockMinimo.Text = Convert.ToString(productos.Stockminimo);
                // ffproductos.cmbEstado.Text = productos.Estado;

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

            _quantity = Convert.ToDecimal (this.dgvProdConsultar.Rows[e.RowIndex].Cells["Stock"].Value);

            var chkstock = ProductosBO.getCheckStock(this.getQuantity);

            try
            {
                if (chkstock == true)
                {

                    _numero = Convert.ToInt64(dgvProdConsultar.Rows[e.RowIndex].Cells["Orden"].Value);

                    MessageBox.Show(ProductosBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.dgvProdConsultar.DataSource = null;
                   // this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
                    this.rol2();
                    return;
                } 

                else if(chkstock == false)
                {
                    if (e.RowIndex == -1)
                        return;

                    _numero = Convert.ToInt64(dgvProdConsultar.Rows[e.RowIndex].Cells["Orden"].Value);

                    this.DialogResult = DialogResult.OK;
                    this.rol2();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void txtCriterioBusqueda_TextChanged_1(object sender, EventArgs e)
        {
            FilterProduct();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool error = false;

            if ((this.rbCategory.Checked == true) && (this.cmbCategories.Text != null))
            {
                try
                {
                        var values = this.cmbCategories.SelectedValue;

                        this.dgvProdConsultar.DataSource = ProductosBO.GetProductByCategory((Int32)values);
                        this.dgvProductOnlyActive.DataSource = ProductosBO.GetProductByCategory((Int32)values);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;

                }
                finally
                {
                    if (error == true)
                    {
                        MessageBox.Show("Verificar la informaciones indicadas.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
            else if ((this.rbCategory.Checked == true) || (this.cmbCategories.Text == null))
            {
                MessageBox.Show("Debe indicar una categoria para poder realizar el Filtrado de los Productos.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cmbCategories.Focus();
            }


            if ((this.rbStatus.Checked == true) && (this.cmbEstado.Text != string.Empty))
            {
                try
                {
                    var values = this.cmbEstado.SelectedValue.ToString();
                    this.dgvProdConsultar.DataSource = ProductosBO.GetProductosByStatus(Convert.ToInt32(values));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;

                }
                finally
                {
                    if (error == true)
                    {
                        MessageBox.Show("Verificar la informaciones indicadas.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else if ((this.rbStatus.Checked == true) && (this.txtCriterioBusqueda.Text == string.Empty))
            {
                MessageBox.Show("Debe indicar un estado para poder realizar el Filtrado de los Productos.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtCriterioBusqueda.Focus();
            }


            if ((this.rbDescription.Checked == true) && (this.txtCriterioBusqueda.Text != string.Empty))
            {
                try
                {
                    var values = this.txtCriterioBusqueda.Text;
                    this.dgvProdConsultar.DataSource = ProductosBO.FilterProductbyDescp(values);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;

                }
                finally
                {
                    if (error == true)
                    {
                        MessageBox.Show("Verificar la informaciones indicadas.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
            else if ((this.rbDescription.Checked == true) && (this.txtCriterioBusqueda.Text == string.Empty))
            {
                MessageBox.Show("Debe indicar una descripcion para poder realizar el Filtrado de los Productos.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtCriterioBusqueda.Focus();
            }

        }

         private void dgvProductOnlyActive_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evaluate item stock
            // cvalor is number the item in storage
            // Return true if item stock is smaller than 0 or iqual to 0 (Example: -1 or 0)
            // Return false if item stock is bigger than 0

            // Create by: Samuel Estrella
            // Modificated:
            // Create:

            _quantity = Convert.ToDecimal(this.dgvProdConsultar.Rows[e.RowIndex].Cells["Stock"].Value);

            var chkstock = ProductosBO.getCheckStock(this.getQuantity);

            try
            {
                if (chkstock == true)
                {

                    _numero = Convert.ToInt64(dgvProdConsultar.Rows[e.RowIndex].Cells["Orden"].Value);

                    MessageBox.Show(ProductosBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.dgvProdConsultar.DataSource = null;
                    this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
                    return;
                }

                else if (chkstock == false)
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
                var user = new UsuariosEntity();
                user.Id_user = int.Parse(this.txtIdUser.Text);
                this.getUserRol(user);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        /// <summary>
        /// Load Categories for Products
        /// </summary>
        public void Categories()
        {
            try
            {
                this.cmbCategories.DisplayMember = "Categoria";
                this.cmbCategories.ValueMember = "Id";
                this.cmbCategories.DataSource = CategoriaBO.GetCategories();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }





        /// <summary>
        /// Initization all controls
        /// </summary>
        private void InitialControls()
        {
            this.rbCodigo.Checked = true;
            this.txtCriterioBusqueda.Focus();
            this.btnSearch.Visible = false;
            

            // BackColor 
            this.txtCriterioBusqueda.BackColor = Color.Bisque;
            this.cmbEstado.BackColor = Color.Bisque;
            this.cmbCategories.BackColor = Color.Bisque;
            this.dgvProdConsultar.DefaultCellStyle.BackColor = Color.Bisque;
            this.dgvProductOnlyActive.DefaultCellStyle.BackColor = Color.Bisque;

            // ForeColor
            this.txtCriterioBusqueda.ForeColor = Color.Maroon;
            this.cmbEstado.ForeColor = Color.Maroon;
            this.cmbCategories.ForeColor = Color.Maroon;
            this.dgvProdConsultar.ForeColor = Color.Maroon;
            this.dgvProductOnlyActive.ForeColor = Color.Maroon;
        }


        /// <summary>
        ///  Load Product Status
        /// </summary>
        public void LoadStatusProduct()
        {
            try
            {
                this.cmbEstado.DisplayMember = "status";
                this.cmbEstado.ValueMember = "id";
                this.cmbEstado.DataSource = ProductosBO.GetStatusProduct();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                this.cmbCategories.Visible = false;
                this.btnSearch.Visible = true;
                this.txtCriterioBusqueda.Visible = true;
                this.txtCriterioBusqueda.Text = "";
                this.txtCriterioBusqueda.Focus();
            }
        }

        private void rbDescription_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbDescription.Checked == true)
            {
                this.lblCriterio.Text = "Descripción";
                NewSearch();
                this.cmbEstado.Visible = false;
                this.btnSearch.Visible = false;
                this.txtCriterioBusqueda.Visible = true;
                this.cmbCategories.Visible = false;
                this.txtCriterioBusqueda.Text = "";
                this.txtCriterioBusqueda.Focus();
            }
        }

        private void rbStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbStatus.Checked == true)
            {
                this.lblCriterio.Text = "Estado";
                NewSearch();
                this.txtCriterioBusqueda.Visible = false;
                this.cmbCategories.Visible = false;
                this.cmbEstado.Visible = true;
                this.btnSearch.Visible = true;
                this.cmbEstado.Text = "";
                this.cmbEstado.Focus();
            }
        }


        private void cmbEstado_DropDown(object sender, EventArgs e)
        {
            LoadStatusProduct();
        }

        private void rbCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbCategory.Checked == true)
            {
                this.lblCriterio.Text = "Categorias";
                NewSearch();
                this.txtCriterioBusqueda.Visible = false;
                this.cmbCategories.Visible = true;
                this.btnSearch.Visible = true;
                this.cmbCategories.Text = "";
                this.cmbCategories.Focus();
            }
        }

        private void cmbCategories_DropDown(object sender, EventArgs e)
        {
            Categories();
        }

    }
}
