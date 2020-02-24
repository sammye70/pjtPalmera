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

        private Int64 _numero;

        ProductosEntity productos = new ProductosEntity();

        public frmConsultarProductos()
        {
            InitializeComponent();
        }

        public Int64 Orden
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
            this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
            this.dgvProductOnlyActive.DataSource = ProductosBO.OnlyActive();
            AmountAllProduct();
            this.txtCriterioBusqueda.Focus();
        }

        private void txtCriterioBusqueda_TextChanged(object sender, EventArgs e)
        {

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
        /// Clean Content in All Controls
        /// </summary>
        private void CleanControls()
        {
            this.lblCostoTotalProductRes.Text = "";
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.dgvProdConsultar.ReadOnly = true;
            this.dgvProductOnlyActive.ReadOnly = true;
        }


        /// <summary>
        /// Filter product by code
        /// </summary>
        private void FilterProduct()
        {
            if (this.txtCriterioBusqueda.Text != string.Empty)
            {
                productos.Idproducto = Convert.ToInt64(this.txtCriterioBusqueda.Text);

                this.dgvProdConsultar.DataSource = ProductosBO.FilterProductbyCode(productos.Idproducto);
                this.dgvProductOnlyActive.DataSource = ProductosBO.FilterProductbyCode(productos.Idproducto);
            }
            else
            {
                this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
                this.dgvProductOnlyActive.DataSource = ProductosBO.GetAll();
                this.txtCriterioBusqueda.Focus();
            }
        }

        private void dgvProdConsultar_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Check Stock if < 1 messager

            decimal cvalor = Convert.ToDecimal (this.dgvProdConsultar.Rows[e.RowIndex].Cells["Stock"].Value);

            try
            {
                if (cvalor == 0)
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
                if (cvalor == 0)
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
    }
}
