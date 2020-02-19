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
        ProductosEntity productos = new ProductosEntity();
        //frmEditarProductos ccproductos = new frmEditarProductos();

        public frmRegArticulos()
        {
            InitializeComponent();
           
        }


        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }


        private void frmRegArticulos_Load(object sender, EventArgs e)
        {

            InitializeControls();
            DesableContros();
            CleanControls();
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
                    DesableContros();
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
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            EnableControls();
            CleanControls();
            productos = null;
            this.txtCodigo.Focus();
        }

        /// <summary>
        /// Load Categories
        /// </summary>
        public void Categories()
        {
            this.cmbFamilia.DisplayMember = "category";
            this.cmbFamilia.DataSource = CategoriaBO.GetAll();
        }

        /// <summary>
        /// Load Provider
        /// </summary>
        public void LoadProveedor()
        {
            this.cmbFabrincante.DisplayMember = "nombre_proveedor";
            this.cmbFabrincante.DataSource=ProveedorBO.GetAllByName();
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
            this.cmbGanancia.Enabled = false;
            this.btnUpdateFields.Visible = false;
            this.btnGenerarCodigo.Enabled = false;
            this.btnAddCategoria.Enabled = false;
            this.btnAddFabricante.Enabled = false;
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
            this.cmbFabrincante.Enabled = true;
            this.cmbFamilia.Enabled = true;
            this.dateTimePicker1.Enabled = true;
            this.cmbEstanteLocalizacion.Enabled = true;
            this.cmbGanancia.Enabled = true;
            this.btnGenerarCodigo.Enabled = true;
            this.btnAddCategoria.Enabled = true;
            this.btnAddFabricante.Enabled = true;
        }

        /// <summary>
        /// Set properties the controls
        /// </summary>
        private void InitializeControls()
        {
            this.toolTip1.SetToolTip(btnNuevo, "Nuevo Registro");
            this.toolTip1.SetToolTip(btnGuardar, "Guardar Registro");
            this.toolTip1.SetToolTip(btnCancelar, "Cerrar");
            this.toolTip1.SetToolTip(btnUpdateFields, "Guardar Registro");
            this.toolTip1.SetToolTip(btnGenerarCodigo, "Generar Código para Productos");
            this.dateTimePicker1.Format = DateTimePickerFormat.Short;
        }

        /// <summary>
        /// Create New Product or Item
        /// </summary>
        private void NewProduct()
        {
            if (productos == null)
            {
                productos = new ProductosEntity();

                productos.Idproducto = Convert.ToInt64(this.txtCodigo.Text);
                productos.Fabricante = this.cmbFabrincante.Text;
                productos.Descripcion = this.txtDescripcion.Text;
                productos.Categoria = this.cmbFamilia.Text;
                productos.Stock = Convert.ToInt32(txtStockInicial.Text);
                productos.Stockminimo = Convert.ToInt32(this.txtStockMinimo.Text);
                productos.Vencimiento = Convert.ToDateTime(dateTimePicker1.Value.Date.ToShortDateString());
                productos.Costo = Convert.ToDecimal(this.txtCosto.Text);
                productos.Precio_venta = Convert.ToDecimal(txtPrecioVenta.Text);
                productos.Created = DateTime.Now.Date;
                productos.Status = cmbEstado.Text;

                ProductosBO.Save(productos);
            }
        }


        /// <summary>
        /// Update Fields Product
        /// </summary>
        private void UpdateFields()
        {

            try
            {
                productos = new ProductosEntity();

                productos.Orden = Convert.ToInt64(this.txtOrden.Text);
                productos.Idproducto = Convert.ToInt64(this.txtCodigo.Text);
                productos.Fabricante = this.cmbFabrincante.Text;
                productos.Descripcion = this.txtDescripcion.Text;
                productos.Categoria = this.cmbFamilia.Text;
                productos.Vencimiento = Convert.ToDateTime(dateTimePicker1.Value.Date.ToShortDateString());
                productos.Costo = Convert.ToDecimal(this.txtCosto.Text);
                productos.Precio_venta = Convert.ToDecimal(this.txtPrecioVenta.Text);
                productos.Stock = Convert.ToInt32(this.txtStockInicial.Text);
                productos.Stockminimo = Convert.ToInt32(this.txtStockMinimo.Text);

                ProductosBO.Update_Info_Product(productos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        //    MessageBox.Show("Guardado Satisfactoriamente","Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            this.cmbGanancia.Text = "";
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

            if (string.IsNullOrEmpty(this.txtStockInicial.Text))
            {
                this.errorProvider1.SetError(this.txtStockInicial, "Indicar Stock Inicial del Articulo");
                result = false;
            }

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

            if (string.IsNullOrEmpty(this.cmbFabrincante.Text))
            {
                this.errorProvider1.SetError(this.cmbFabrincante, "Indicar fabricante del Articulo");
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
            frmCategoria categoria = new frmCategoria();
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
                    decimal c, pg, pv, p;

                    c = Convert.ToDecimal(this.txtCosto.Text);
                    p = Convert.ToDecimal(this.cmbGanancia.Text);
                    pg = (c * p) / 100;
                    pv = c + pg;
                    this.txtPrecioVenta.Text = Convert.ToString(pv);
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
            frmRegProveedor proveedor = new frmRegProveedor();
            proveedor.ShowDialog(this);
        }

        private void btnUpdateFields_Click(object sender, EventArgs e)
        {
            DialogResult Question = new DialogResult();

            Question = MessageBox.Show("Seguro Que Desea Guardar los Cambios", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Question == DialogResult.Yes)
            {
                UpdateFields();
                MessageBox.Show("Guardado Satisfactoriamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            //    ccproductos.dgvProdConsultar.DataSource = null;
              //  ccproductos.dgvProdConsultar.DataSource = ProductosBO.GetAll();
                this.Close();
            }
            else if (Question == DialogResult.No)
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
            ProductosEntity productos = new ProductosEntity();
            this.txtCodigo.Text=Convert.ToString(productos.NumberGeneratorCode());
        }

        private void cmbFabrincante_DropDown(object sender, EventArgs e)
        {
            LoadProveedor();
        }

        private void cmbFamilia_DropDown(object sender, EventArgs e)
        {
            Categories();
        }
    }
}
