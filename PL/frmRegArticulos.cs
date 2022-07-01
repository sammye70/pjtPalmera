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
using System.Web.UI.WebControls;
using System.Media;

namespace pjPalmera.PL
{
    public partial class frmRegArticulos : Form
    {
        ProductosEntity productos = new ProductosEntity();
        //frmEditarProductos ccproductos = new frmEditarProductos();

        public frmRegArticulos()
        {
            InitializeComponent();
           
        }


        #region Hide Button Close
        //private const int CP_NOCLOSE_BUTTON = 0x200;
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams myCp = base.CreateParams;
        //        myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
        //        return myCp;
        //    }
        //} 
        #endregion


        private void frmRegArticulos_Load(object sender, EventArgs e)
        {

            InitializeControls();
            DesableContros();
            CleanControls();
            this.cmbEstado.Visible = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validator() == true)
                {
                    NewProduct();
                    CleanControls();
                   // DesableContros();
                    this.errorProvider1.Clear();
                    MessageBox.Show("Guardado Satisfactoriamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Proporcionar los campos indicados ", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                productos = null;
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                porcentaje();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            LoadStatusProduct();
            EnableControls();
            CleanControls();
            productos = null;
            InitializeControls();
        }

        /// <summary>
        /// Load Categories for Products
        /// </summary>
        public void Categories()
        {
            try
            {   this.cmbFamilia.DisplayMember = "Categoria";
                this.cmbFamilia.ValueMember = "Id";
                this.cmbFamilia.DataSource = CategoriaBO.GetCategories();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Load Provedor
        /// </summary>
        public void LoadProveedor()        
        {
            try
            {   this.cmbDistribuidor.DisplayMember = "Nombre_proveedor";
                this.cmbDistribuidor.ValueMember = "idproveedor";
                this.cmbDistribuidor.DataSource = ProveedorBO.GetProveedorsByName();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
            this.cmbDistribuidor.Enabled = false;
            this.cmbFamilia.Enabled = false;
            this.dateTimePicker1.Enabled = false;
            this.cmbEstanteLocalizacion.Enabled = false;
            this.cmbGanancia.Enabled = false;
            this.btnUpdateFields.Visible = false;
            this.btnGenerarCodigo.Enabled = false;
            this.btnAddCategoria.Enabled = false;
            this.btnAddFabricante.Enabled = false;
            this.cmbEstado.Enabled = false;
            this.btnCancelar.Visible = false;
        }

        /// <summary>
        /// Enable all Controls from RegArticulos
        /// </summary>
        public void EnableControls()
        {
            this.txtCodigo.Enabled = true;
            this.txtCosto.Enabled = true;
            this.txtDescripcion.Enabled = true;
            this.txtPrecioVenta.Enabled = true;
            this.txtStockInicial.Enabled = true;
            this.txtStockMinimo.Enabled = true;
            this.btnGuardar.Enabled = true;
            this.cmbDistribuidor.Enabled = true;
            this.cmbFamilia.Enabled = true;
            this.dateTimePicker1.Enabled = true;
            this.cmbEstanteLocalizacion.Enabled = true;
            this.cmbGanancia.Enabled = true;
            this.btnGenerarCodigo.Enabled = true;
            this.btnAddCategoria.Enabled = true;
            this.btnAddFabricante.Enabled = true;
            this.cmbEstado.Enabled = true;
        }

        /// <summary>
        /// Set properties the controls
        /// </summary>
        private void InitializeControls()
        {
            this.toolTip1.SetToolTip(btnNuevo, "Nuevo Articulo");
            this.toolTip1.SetToolTip(btnGuardar, "Guardar Articulo");
            this.toolTip1.SetToolTip(btnCancelar, "Cerrar");
            this.toolTip1.SetToolTip(btnUpdateFields, "Actualizar Informacion del  Articulo");
            this.toolTip1.SetToolTip(btnGenerarCodigo, "Generar Código para Productos");
            this.dateTimePicker1.Format = DateTimePickerFormat.Short;
            this.txtDescripcion.MaxLength = 23;
            this.cmbEstado.Text = "activo";
            this.txtCodigo.Focus();

            // BackColor
            this.cmbDistribuidor.BackColor = Color.Bisque;
            this.txtCodigo.BackColor = Color.Bisque;
            this.txtCosto.BackColor = Color.Bisque;
            this.txtDescripcion.BackColor = Color.Bisque;
            this.txtPrecioVenta.BackColor = Color.Bisque;
            this.txtStockInicial.BackColor = Color.Bisque;
            this.txtStockMinimo.BackColor = Color.Bisque;
            this.cmbFamilia.BackColor = Color.Bisque;
            this.dateTimePicker1.BackColor = Color.Bisque;
            this.cmbEstanteLocalizacion.BackColor = Color.Bisque;
            this.cmbEstado.BackColor = Color.Bisque;
            this.cmbGanancia.BackColor = Color.Bisque;

            // ForeColor
            this.cmbDistribuidor.ForeColor = Color.Maroon;
            this.txtCodigo.ForeColor = Color.Maroon;
            this.txtCosto.ForeColor = Color.Maroon;
            this.txtDescripcion.ForeColor = Color.Maroon;
            this.txtPrecioVenta.ForeColor = Color.Maroon;
            this.txtStockInicial.ForeColor = Color.Maroon;
            this.txtStockMinimo.ForeColor = Color.Maroon;
            this.cmbFamilia.ForeColor = Color.Maroon;
            this.dateTimePicker1.ForeColor = Color.Maroon;
            this.cmbEstanteLocalizacion.ForeColor = Color.Maroon;
            this.cmbEstado.ForeColor = Color.Maroon;
            this.cmbGanancia.ForeColor = Color.Maroon;

        }



        /// <summary>
        /// Initialitation frmRegArticulos Controls
        /// </summary>
        public void InitControl()
        {
            this.btnUpdateFields.Visible = true;
            this.cmbEstado.Visible = true;
            this.lblEstado.Visible = true;
            this.txtCodigo.Focus();
        }


        /// <summary>
        /// Hide controls in frmRegArticulos when current form to call this.
        /// </summary>
        public void HideControls()
        {
            //ffproductos.txtStockInicial.Visible = false;
            //ffproductos.txtStockMinimo.Visible = false;
            //ffproductos.lblStockInicial.Visible = false;
            //ffproductos.lblStockMinimo.Visible = false;
            this.btnGuardar.Visible = false;
            this.btnNuevo.Visible = false;
        }

        /// <summary>
        /// Create New Product or Item
        /// </summary>
        private void NewProduct()
        {
            bool err = false;
           // var st = 1;
            try
            {
                if (productos == null)
                {
                    productos = new ProductosEntity();

                    productos.Codigo = Convert.ToInt64(this.txtCodigo.Text);
                    productos.Proveedor = this.cmbDistribuidor.SelectedValue.ToString();
                    productos.Descripcion = this.txtDescripcion.Text;
                    productos.Categoria = this.cmbFamilia.SelectedValue.ToString();
                  //  productos.Stock = Convert.ToInt32(txtStockInicial.Text);
                    productos.Stockminimo = Convert.ToInt32(this.txtStockMinimo.Text);
                    productos.Vencimiento = Convert.ToDateTime(dateTimePicker1.Value.Date.ToShortDateString());
                    productos.Costo = Convert.ToDecimal(this.txtCosto.Text);
                    productos.Precio_venta = Convert.ToDecimal(txtPrecioVenta.Text);
                    productos.Creado = DateTime.Now.Date;
                    // productos.Estado = st.ToString();
                    productos.Creado_por = int.Parse(this.txtIdUser.Text);
                    productos.Estado = this.cmbEstado.SelectedValue.ToString();

                    ProductosBO.Save(productos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                err = true;
            }
            finally
            {
                if (err == true)
                {
                    MessageBox.Show("Verificar la infomación suministrada en los campos", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            return;
        }


        /// <summary>
        /// Update Fields Product
        /// </summary>
        private void UpdateFields()
        {
            bool err = false;
            try
            {
               var productos = new ProductosEntity();

                productos.Orden = Convert.ToInt64(this.txtOrden.Text);
                productos.Codigo = Convert.ToInt64(this.txtCodigo.Text);
                productos.Proveedor = this.cmbDistribuidor.SelectedText.ToString();
                productos.Descripcion = this.txtDescripcion.Text;
                productos.Categoria = this.cmbFamilia.SelectedValue.ToString();
                productos.Vencimiento = Convert.ToDateTime(dateTimePicker1.Value.Date.ToShortDateString());
                productos.Costo = Convert.ToDecimal(this.txtCosto.Text);
                productos.Precio_venta = Convert.ToDecimal(this.txtPrecioVenta.Text);
               // productos.Stock = Convert.ToInt32(this.txtStockInicial.Text);
                productos.Stockminimo = Convert.ToInt32(this.txtStockMinimo.Text);
                productos.Estado = this.cmbEstado.SelectedValue.ToString();

                ProductosBO.Update_Info_Product(productos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                err = true;
                return;
            }
            finally
            {
                if (err == true)
                {
                    MessageBox.Show("Verificar la infomación suministrada en los campos", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtCodigo.Focus();
                }
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
            this.cmbDistribuidor.Text = "";
            this.cmbFamilia.Text = "";
            this.cmbGanancia.Text = "";
            this.cmbEstado.Text = "";
        }

        /// <summary>
        /// Validator all controls
        /// </summary>
        /// <returns>It is return true if all controls are diferent than Empty</returns>
        public bool Validator()
        {
            bool result = true;

            if (string.IsNullOrEmpty(this.txtCodigo.Text))
            {
                this.errorProvider1.SetError(this.txtCodigo,"Indicar Codigo del Articulo");
                result =false;
            }

            if (string.IsNullOrEmpty(this.txtDescripcion.Text))
            {
                this.errorProvider1.SetError(this.txtDescripcion, "Indicar Descripcion del Articulo");
                result = false;
            }

            if (string.IsNullOrEmpty(this.txtCosto.Text))
            {
                this.errorProvider1.SetError(this.txtCosto, "Indicar Costo del Articulo");
                result = false;
            }

            if (string.IsNullOrEmpty(this.txtPrecioVenta.Text))
            {
                this.errorProvider1.SetError(this.txtPrecioVenta, "Indicar Precio de Venta del Articulo");
                result = false;
            }

            //if (string.IsNullOrEmpty(this.txtStockInicial.Text))
            //{
            //    this.errorProvider1.SetError(this.txtStockInicial, "Indicar Stock Inicial del Articulo");
            //    result = false;
            //}

            if (string.IsNullOrEmpty(this.txtStockMinimo.Text))
            {
                this.errorProvider1.SetError(this.txtStockMinimo, "Indicar Stock Minimo del Articulo");
                result = false;
            }

            //if (string.IsNullOrEmpty(this.cmbEstanteLocalizacion.Text))
            //{
            //    this.errorProvider1.SetError(this.cmbEstanteLocalizacion, "Indicar Estante donde se localizara el Articulo");
            //    result = false;
            //}

            if (string.IsNullOrEmpty(this.cmbDistribuidor.Text))
            {
                this.errorProvider1.SetError(this.cmbDistribuidor, "Indicar Proveedor del Articulo");
                result = false;
            }

            if (string.IsNullOrEmpty(this.cmbFamilia.Text))
            {
                this.errorProvider1.SetError(this.cmbFamilia, "Indicar Categoria  a la cual pertenece el Articulo");
                result = false;
            }

            return result;
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            var categoria = new frmCategoria();
            categoria.ShowDialog(this);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
        //    frmEditarProductos cccproductos = new frmEditarProductos();
            productos = null;
          //  ccproductos.dgvProdConsultar = null;
            this.Close();
        }

        /// <summary>
        /// Loop until variable x value, and average ganance
        /// </summary>
        public void porcentaje()
        {
            int x = 101;
            for (int i = 0; i < x; i++)
            {
                this.cmbGanancia.Items.Add(i);
            }
        }

        /// <summary>
        /// Calculate Price for Product
        /// </summary>
        private void Price_Sold()
        {
            if (this.txtCosto.Text == string.Empty)
            {
                this.txtPrecioVenta.Text = "";
                return;
            }
            else
            {
                try
                {
                    var OpServices = new OpServices();
                    decimal Price;
                    Price=OpServices.SetPrice(Convert.ToDecimal(this.txtCosto.Text), Convert.ToDecimal(this.cmbGanancia.Text));
                    this.txtPrecioVenta.Text = Convert.ToString(Price);

                    #region OldCode

                    //decimal c, pg, pv, p;

                    //c = Convert.ToDecimal(this.txtCosto.Text);
                    //p = Convert.ToDecimal(this.cmbGanancia.Text);
                    //pg = (c * p) / 100;
                    //pv = c + pg;
                    //this.txtPrecioVenta.Text = Convert.ToString(pv);

                    #endregion 
                }
                catch
                {
                    this.txtCosto.Focus();
                    return;
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var Regproveedor = new frmRegProveedor();
            Regproveedor.Show();
        }

        private void btnUpdateFields_Click(object sender, EventArgs e)
        {
            var Answer = new DialogResult();

            Answer = MessageBox.Show("Seguro Que Desea Guardar los Cambios", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (Answer == DialogResult.Yes)
            {
                UpdateFields();
                MessageBox.Show("Guardado Satisfactoriamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                //ccproductos.dgvProdConsultar.DataSource = null;
                //ccproductos.dgvProdConsultar.DataSource = ProductosBO.GetAll();
                this.Close();
            }
            else if (Answer == DialogResult.No)
            {
                //ccproductos.dgvProdConsultar.DataSource = null;
                //ccproductos.dgvProdConsultar.DataSource = ProductosBO.GetAll();
                this.Close();
                return;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Price_Sold();
         }

        private void btnGenerarCodigo_Click(object sender, EventArgs e)
        {
            var OpServices = new OpServices();
            this.txtCodigo.Text=Convert.ToString(OpServices.NumberGeneratorCode());
        }

        private void cmbFamilia_DropDown(object sender, EventArgs e)
        {
            Categories();
        }

        private void btnAddFabricante_Click(object sender, EventArgs e)
        {
            frmRegProveedor rproveedor = new frmRegProveedor();
            rproveedor.ShowDialog(this);
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (this.txtDescripcion.TextLength == 23)
            {
                MessageBox.Show("La longitud maxima es de 23 caracteres (a...z, etc)", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmbEstado_DropDown(object sender, EventArgs e)
        {
            LoadStatusProduct();
        }

        private void cmbDistribuidor_DropDown(object sender, EventArgs e)
        {
            LoadProveedor();
        }
    }
}
