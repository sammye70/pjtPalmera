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
    }
}
