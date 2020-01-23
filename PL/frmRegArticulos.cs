﻿using System;
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
            LoadProveedor();
            Categories();
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
                producto = null;
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EnableControls();
            producto = null;
            this.txtCodigo.Focus();
            
        }

        /// <summary>
        /// Load Categories
        /// </summary>
        private void Categories()
        {
            this.cmbFamilia.DisplayMember = "category";
            this.cmbFamilia.DataSource = CategoriaBO.GetAll();
        }

        /// <summary>
        /// Load Provider
        /// </summary>
        private void LoadProveedor()
        {
            this.cmbFabrincante.DisplayMember = "nombre_proveedor";
            this.cmbFabrincante.DataSource=ProveedorBO.GetAllProveedor_();
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

                producto.Idproducto = Convert.ToInt64(this.txtCodigo.Text);
                producto.Fabricante = this.cmbFabrincante.Text;
                producto.Descripcion = this.txtDescripcion.Text;
                producto.Categoria = this.cmbFamilia.Text;
                producto.Stock = Convert.ToInt32(txtStockInicial.Text);
                producto.Stockminimo = Convert.ToInt32(this.txtStockMinimo.Text);
                producto.Vencimiento = Convert.ToDateTime(dateTimePicker1.Value.Date.ToShortDateString());
                producto.Costo = Convert.ToDecimal(this.txtCosto.Text);
                producto.Precio_venta = Convert.ToDecimal(txtPrecioVenta.Text);
                producto.Created = DateTime.Now.Date;

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

            if (string.IsNullOrEmpty(this.cmbEstanteLocalizacion.Text))
            {
                this.errorProvider1.SetError(this.cmbEstanteLocalizacion, "Indicar Estante donde se localizara el Articulo");
                result = false;
            }

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
            producto = null;
            this.Close();
        }

        private void txtCosto_TextChanged(object sender, EventArgs e)
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
                    decimal c, pg, pv;
                    c = Convert.ToDecimal(this.txtCosto.Text);
                    pg = (c * 30) / 100;
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
    }
}
