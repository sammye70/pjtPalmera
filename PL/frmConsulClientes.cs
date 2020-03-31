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
        private long _numero;

        // frmVenta fcliente = new frmVenta();
        ClientesEntity clientes = new ClientesEntity();
        public frmConsulClientes()
        {
            InitializeComponent();
        }

        public long Orden
        {
            get { return _numero; }
        }

        private void frmConsulClientes_Load(object sender, EventArgs e)
        {
            //this.dgvClientConsultar.AutoGenerateColumns = false;
            DesableControls();
            this.dgvClientConsultar.DataSource = ClientesBO.GetAll();
        }


        /// <summary>
        /// Desables all Controls
        /// </summary>
        private void DesableControls()
        {
            this.dgvClientConsultar.ReadOnly = true;
            //this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        /// <summary>
        /// Filter Costumer by Cedula
        /// </summary>
        private void SearchByCedula()
        {
            try
            {
                if (this.txtCriterioBusqueda.Text != string.Empty)
                {
                    clientes.Cedula = Convert.ToInt64(this.txtCriterioBusqueda.Text);
                    this.dgvClientConsultar.DataSource = ClientesBO.GetbyCedula(clientes.Cedula);
                }
                else
                {
                    this.dgvClientConsultar.DataSource = null;
                    this.dgvClientConsultar.DataSource = ClientesBO.GetAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }


        private void txtCriterioBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (this.txtCriterioBusqueda.Text != string.Empty)
            {
                SearchByCedula();
            }
            else
            {
                this.dgvClientConsultar.DataSource = null;
                this.dgvClientConsultar.DataSource = ClientesBO.GetAll();
                this.txtCriterioBusqueda.Focus();
            }
        }

        private void dgvClientConsultar_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            _numero = Convert.ToInt64(this.dgvClientConsultar.Rows[e.RowIndex].Cells["id"].Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
