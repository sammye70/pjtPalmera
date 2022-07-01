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
            CleanControls();
            DesableControls();
            LoadClients();
            ControlDescrip();
            InitialControls();
            this.txtCriterioBusqueda.Focus();
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
        /// Clean Content inside All Controls
        /// </summary>
        private void CleanControls()
        {
            this.lblCriterio.Text = "";
            this.txtCriterioBusqueda.Text = "";
            this.rbApellidos.Checked = false;
            this.rbCedula.Checked = false;
            this.rbNombre.Checked = false;
        }


        /// <summary>
        ///  Hide Constrols from Consult Customers
        /// </summary>
        public void HideCtrlCustmer()
        {
            this.btnEditar.Visible = false;
            this.btnEliminar.Visible = false;
            this.dgvClientConsultar.Columns["Created"].Visible = false;
            this.dgvClientConsultar.Columns["Createby"].Visible = false;

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
                    this.HideCtrlCustmer();
                }
                else
                {
                    this.dgvClientConsultar.DataSource = null;
                    this.dgvClientConsultar.DataSource = ClientesBO.GetAll();
                    this.HideCtrlCustmer();
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
            this.toolTip1.SetToolTip(this.btnEditar, "Editar Información del Cliente Seleccionado Actualmente");
            this.toolTip1.SetToolTip(this.btnEliminar, "Eliminar Cliente Seleccionado Actualmente");
            this.toolTip1.SetToolTip(this.btnRefresh, "Actualizar Listado de Clientes Mostrados");
            this.toolTip1.SetToolTip(this.btnSearch, "Buscar Conforme al Filtrado Elegido");
            this.toolTip1.SetToolTip(this.txtCriterioBusqueda, "Criterio a buscar dependiento el filtro elegido");
        }

        /// <summary>
        /// Load All Clients
        /// </summary>
        private void LoadClients()
        {   
            try
            {   
                this.dgvClientConsultar.DataSource = ClientesBO.GetAll();
                this.dgvClientConsultar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                this.HideCtrlCustmer();
                var row = this.dgvClientConsultar.RowCount;

                if (row <= 0)
                {
                    MessageBox.Show("No Hay Datos que Mostrar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.HideCtrlCustmer();
                    this.txtCriterioBusqueda.Focus();
                }
                else {
                    this.HideCtrlCustmer();
                    this.txtCriterioBusqueda.Focus();
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Edit Client Informations
        /// </summary>
        private void EditClient()
        {
            var ffClientes = new frmRegClientes();
            var user = new UsuariosEntity();
           // bool error = false;

            try
            {
                DataGridViewRow x = this.dgvClientConsultar.CurrentRow;
                _numero = Convert.ToInt64(this.dgvClientConsultar.Rows[x.Index].Cells["id"].Value);
                user.Id_user = int.Parse(this.txtIdUser.Text);
                ffClientes.txtIdUser.Text = user.Id_user.ToString();

                ffClientes.Show();
                ffClientes.Text = "Actualizar Información";
                ffClientes.lblTitle.Text = "Actualizar Información del Cliente";
                ffClientes.EnabledControls();
                ffClientes.InitialControlsUp();
                ffClientes.InitialControls();

                clientes = ClientesBO.GetbyCodeUpdate(this.Orden);

                ffClientes.txtIdClient.Text = Convert.ToString(clientes.Id);
                ffClientes.mktCedula.Text = clientes.Cedula;
                ffClientes.txtNombre.Text = clientes.Nombre;
                ffClientes.txtApellidos.Text = clientes.Apellidos;
                ffClientes.txtDireccion.Text = clientes.Direccion;
               // ffClientes.cmbCiudad.Text = clientes.Ciudad;
               // ffClientes.cmbProvincia.Text = clientes.Provincia;
                ffClientes.mktLimteCredClient.Text = Convert.ToString(clientes.Limite_credito);
                ffClientes.mktTelefono.Text = clientes.Telefono;
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // error = true;
                return;
            }
      

        }


        /// <summary>
        /// Set Properties Controls
        /// </summary>
        private void InitialControls()
        {
            this.txtCriterioBusqueda.Focus();
            this.btnSearch.Visible = false;

            // BackColor 
            this.txtCriterioBusqueda.BackColor = Color.Bisque;
            this.dgvClientConsultar.DefaultCellStyle.BackColor = Color.Bisque;

            // ForeColor
            this.txtCriterioBusqueda.ForeColor = Color.Maroon;
            this.dgvClientConsultar.ForeColor = Color.Maroon;
        }


        /// <summary>
        /// Delete Client by Id 
        /// </summary>
        private void DeleteClient()
        {
            var question = new DialogResult();
            try
            {
                question = MessageBox.Show("Seguro que desea continuar?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (question == DialogResult.Yes)
                {
                    DataGridViewRow x = this.dgvClientConsultar.CurrentRow;
                    _numero = Convert.ToInt64(this.dgvClientConsultar.Rows[x.Index].Cells["id"].Value);

                    ClientesBO.Delete(this.Orden);

                    MessageBox.Show(ClientesBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dgvClientConsultar.DataSource = ClientesBO.GetAll();
                    this.HideCtrlCustmer();

                }
                else if (question == DialogResult.No)
                {
                    this.rbCedula.Focus();
                    this.HideCtrlCustmer();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
            this.HideCtrlCustmer();

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
                
                CleanControls();
                this.txtCriterioBusqueda.Focus();
            }
            else if (Question == DialogResult.No)
            {
                this.dgvClientConsultar.DataSource = ClientesBO.GetAll();
                this.HideCtrlCustmer();
                this.txtCriterioBusqueda.Focus();
                return;
            }
            
        }

        private void rbCedula_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbCedula.Checked == true)
            {
                this.lblCriterio.Text = "Cédula";
                this.txtCriterioBusqueda.Text = "";
                this.txtCriterioBusqueda.Focus();
                this.dgvClientConsultar.DataSource = ClientesBO.GetAll();
                this.HideCtrlCustmer();
            }
        }

        private void rbNombre_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbNombre.Checked == true)
            {
                this.lblCriterio.Text = "Nombre";
                this.txtCriterioBusqueda.Text = "";
                this.txtCriterioBusqueda.Focus();
                this.dgvClientConsultar.DataSource = ClientesBO.GetAll();
                this.HideCtrlCustmer();
            }
        }

        private void rbApellidos_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbApellidos.Checked == true)
            {
                this.lblCriterio.Text = "Apellidos";
                this.txtCriterioBusqueda.Text = "";
                this.txtCriterioBusqueda.Focus();
                this.dgvClientConsultar.DataSource = ClientesBO.GetAll();
                this.HideCtrlCustmer();
            }
        }

        /// <summary>
        /// Set criterio to Search Costumer
        /// </summary>
        /// <param name="valCriterio"></param>
        private void SearchCriterio(string valCriterio)
        {
            //var messager = new DialogResult();

            try
            {
                if (this.txtCriterioBusqueda.Text != string.Empty)
                {
                    if ((this.rbCedula.Checked == true) && (this.rbApellidos.Checked == false) && (this.rbNombre.Checked == false))
                    {
                        var cedu = ClientesBO.GetCustomerByCedula(valCriterio);

                        if (cedu.Count != 0)
                        {
                            this.dgvClientConsultar.DataSource = ClientesBO.GetCustomerByCedula(valCriterio);
                            this.HideCtrlCustmer();
                        }
                        else
                        {
                            MessageBox.Show("No hay Clientes que mostrar que esten asociados a la Cédula indicada", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.dgvClientConsultar.DataSource = null;
                            this.dgvClientConsultar.DataSource = ClientesBO.GetAll();
                            this.HideCtrlCustmer();
                            this.txtCriterioBusqueda.Focus();
                        }
                    }
                    else if ((this.rbApellidos.Checked == true) && (this.rbCedula.Checked == false) && (this.rbNombre.Checked == false))
                    {
                        var apellClient = ClientesBO.GetbyApellidos(valCriterio);

                        if (apellClient.Count != 0)
                        {
                            this.dgvClientConsultar.DataSource = ClientesBO.GetbyApellidos(valCriterio);
                            this.HideCtrlCustmer();
                        }
                        else
                        {
                            this.dgvClientConsultar.DataSource = ClientesBO.GetbyApellidos(valCriterio);
                            MessageBox.Show("No hay Clientes que mostrar que esten asociados al/los Apellidos indicados", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.dgvClientConsultar.DataSource = null;
                            this.dgvClientConsultar.DataSource = ClientesBO.GetAll();
                            this.txtCriterioBusqueda.Focus();
                        }
                    }
                    else if ((this.rbNombre.Checked == true) && (this.rbCedula.Checked == false) && (this.rbApellidos.Checked == false))
                    {
                        var nombClient = ClientesBO.GetbyNombre(valCriterio);

                        if (nombClient.Count != 0)
                        {
                            this.dgvClientConsultar.DataSource = ClientesBO.GetbyNombre(valCriterio);
                            this.HideCtrlCustmer();
                        }
                        else
                        {
                            //this.dgvClientConsultar.DataSource = ClientesBO.GetbyNombre(valCriterio);
                            MessageBox.Show("No hay Clientes que mostrar que esten asociados al Nombre indicado", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.dgvClientConsultar.DataSource = null;
                            this.dgvClientConsultar.DataSource = ClientesBO.GetAll();
                            this.HideCtrlCustmer();
                            this.txtCriterioBusqueda.Focus();
                        }
                    }
                    else
                    {
                        this.txtCriterioBusqueda.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtCriterioBusqueda_TextChanged(object sender, EventArgs e)
        {
            var criterio = this.txtCriterioBusqueda.Text;
            SearchCriterio(criterio);
        }

    }
}
