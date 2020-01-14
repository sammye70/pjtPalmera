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
    public partial class frmConsultarProveedor : Form
    {
        public frmConsultarProveedor()
        {
            InitializeComponent();
        }

        private void frmConsultarProveedor_Load(object sender, EventArgs e)
        {
            this.dgvContProveedor.DataSource =ProveedorBO.GetAllProveedor();
        }
    }
}
