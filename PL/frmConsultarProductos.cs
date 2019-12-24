using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    public partial class frmConsultarProductos : Form
    {
        
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
            this.txtCriterioBusqueda.Clear();
            this.dgvProdConsultar.DataSource = null;
            this.txtCriterioBusqueda.Focus();
        }
    }
}
