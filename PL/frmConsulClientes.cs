using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using pjPalmera.BLL;
using pjPalmera.Entities;

namespace pjPalmera.PL
{
    public partial class frmConsulClientes : Form
    {
        private int _idcliente;

        public frmConsulClientes()
        {
            InitializeComponent();
        }

        public int Idcliente
        {
            get { return _idcliente; }
        }

        private void frmConsulClientes_Load(object sender, EventArgs e)
        {
            //this.dgvClientConsultar.AutoGenerateColumns = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.dgvClientConsultar.DataSource = ClientesBO.GetAll();
        }

    }
}
