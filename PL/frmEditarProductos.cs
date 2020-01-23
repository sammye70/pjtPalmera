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
        public frmEditarProductos()
        {
            InitializeComponent();
            DesableControls();
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

        private void dgvProdConsultar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtCriterioBusqueda.Text = dgvProdConsultar.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
