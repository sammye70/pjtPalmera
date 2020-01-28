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

        private Int64 _idproducto;

        ProductosEntity productos = new ProductosEntity();

        public frmConsultarProductos()
        {
            InitializeComponent();
        }

        public Int64 Idproducto
        {
            get { return _idproducto; }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.dgvProdConsultar.DataSource = null;
            this.txtCriterioBusqueda.Clear();
            this.Close();
        }

        private void frmConsultarProductos_Load(object sender, EventArgs e)
        {
            
            DesableControls();
            this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
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
        /// Desable all Controls 
        /// </summary>
        private void DesableControls()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.dgvProdConsultar.ReadOnly = true;
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

                    _idproducto = Convert.ToInt64(dgvProdConsultar.Rows[e.RowIndex].Cells["Idproducto"].Value);

                    MessageBox.Show("No hay Stock disponible del producto", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.dgvProdConsultar.DataSource = null;
                    this.dgvProdConsultar.DataSource = ProductosBO.GetAll();
                    return;


                }
                else
                {
                    if (e.RowIndex == -1)
                        return;

                    _idproducto = Convert.ToInt64(dgvProdConsultar.Rows[e.RowIndex].Cells["Idproducto"].Value);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
