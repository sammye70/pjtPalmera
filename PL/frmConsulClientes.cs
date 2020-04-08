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
       
        // frmVenta fcliente = new frmVenta();
        ClientesEntity clientes = new ClientesEntity();
       
        public frmConsulClientes()
        {
            InitializeComponent();
        }
        private long _numero;

        public long Orden
        {
            get { return _numero; }
        }

        private void frmConsulClientes_Load(object sender, EventArgs e)
        {
            //this.dgvClientConsultar.AutoGenerateColumns = false;
            DesableControls();
            LoadClients();
            ControlDescrip();
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
                    clientes.Cedula = this.txtCriterioBusqueda.Text;
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

        /// <summary>
        /// Detail About All Controls
        /// </summary>
        private void ControlDescrip()
        {
            this.toolTip1.SetToolTip(this.btnEditar, "Editar Informacion del Cliente");
            this.toolTip1.SetToolTip(this.btnEliminar, "Eliminar Cliente Seleccionado Actualmente");
            this.toolTip1.SetToolTip(this.btnRefresh, "Actualizar Listado de Clientes Mostrados");
            this.toolTip1.SetToolTip(this.btnSearch, "Buscar Conforme al Filtrado Elegido");
        }

        /// <summary>
        /// Load All Clients
        /// </summary>
        private void LoadClients()
        {
            this.dgvClientConsultar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvClientConsultar.DataSource = ClientesBO.GetAll();

            var row = this.dgvClientConsultar.Rows.Count;
            DialogResult result = new DialogResult();

            if (row < 1)
            {
                result = MessageBox.Show("No Hay Datos que Mostrar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        /// <summary>
        /// Edit Client Informations
        /// </summary>
        private void EditClient()
        {
            frmRegClientes ffClientes = new frmRegClientes();

            try
            {
                DataGridViewRow x = this.dgvClientConsultar.CurrentRow;
                _numero = Convert.ToInt64(this.dgvClientConsultar.Rows[x.Index].Cells["id"].Value);

                ffClientes.Show();
                ffClientes.Text = "Actualizar Información del Cliente";
                ffClientes.EnabledControls();
                ffClientes.InitialControls();

                clientes = ClientesBO.GetbyCodeUpdate(this.Orden);
                
                ffClientes.txtIdClient.Text = Convert.ToString(clientes.Id);
                ffClientes.mktCedula.Text = clientes.Cedula;
                ffClientes.txtNombre.Text = clientes.Nombre;
                ffClientes.txtApellidos.Text = clientes.Apellidos;
                ffClientes.txtDireccion.Text = clientes.Direccion;
                ffClientes.cmbCiudad.Text = clientes.Ciudad;
                ffClientes.cmbProvincia.Text = clientes.Provincia;
                ffClientes.mktLimteCredClient.Text = Convert.ToString(clientes.Limite_credito);
                ffClientes.mktTelefono.Text = clientes.Telefono;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        /// <summary>
        /// Delete Client by Id 
        /// </summary>
        private void DeleteClient()
        {
            try
            {
                DataGridViewRow x = this.dgvClientConsultar.CurrentRow;
                _numero = Convert.ToInt64(this.dgvClientConsultar.Rows[x.Index].Cells["id"].Value);
                ClientesBO.Delete(this.Orden);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditClient();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.dgvClientConsultar.DataSource = ClientesBO.GetAll();

            var row = this.dgvClientConsultar.Rows.Count;
            DialogResult result = new DialogResult();

            if (row < 1)
            {
                result = MessageBox.Show("No Hay Datos que Mostrar","Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Question = new DialogResult();
            Question = MessageBox.Show("Esta apunto de Eliminar el Cliente Seleccionado. Desea Continuar", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Question == DialogResult.Yes)
            {
                DeleteClient();
                MessageBox.Show("Cliente Eliminado Satisfactoriamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgvClientConsultar.DataSource = ClientesBO.GetAll();
            }
            else if (Question == DialogResult.No)
            {
                this.dgvClientConsultar.DataSource = ClientesBO.GetAll();
                return;
            }
            
        }
    }
}
