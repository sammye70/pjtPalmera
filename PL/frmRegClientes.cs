using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;
using pjPalmera.BLL;
using pjPalmera.Entities;
using System.Drawing;

namespace pjPalmera.PL
{
    public partial class frmRegClientes : Form
    {
        ClientesEntity clientes = new ClientesEntity();

        /// <summary>
        /// Customer's Consult
        /// </summary>
        frmConsulClientes conClientes = new frmConsulClientes();
    
        public frmRegClientes()
        {
            InitializeComponent();
        }

        #region Desable Exit Button
        //private const int CP_NOCLOSE_BUTTON = 0x200;
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams myCp = base.CreateParams;
        //        myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
        //        return myCp;
        //    }
        //} 
        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //validator controls
            try
            {
                switch (Validator())
                {
                    case true:
                        NewCostumer();
                        break;
                    case false:
                        throw new Exception("Proporcionar los campos indicados.");
                }


                /* if (Validator() == true)
                {
                    
                }
                else if(Validator() == false)
                {
                    
                } */

            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                clientes = null;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EnabledControls();
            CleanControls();
            this.mktCedula.Focus();
            clientes = null;
        }

        /// <summary>
        /// Set Detail About Control
        /// </summary>
        private void DescripControls()
        {
            toolTip1.SetToolTip(btnNuevo, "Nuevo Registro");
            toolTip1.SetToolTip(btnGuardar, "Guardar Información del Nuevo Cliente");
            toolTip1.SetToolTip(btnUpdateClient, "Actualizar Información del Cliente");
        }

        #region Process to Create New Customer
        /// <summary>
        /// Save costumer from form
        /// </summary>
        private void NewCostumer()
        {
            if (clientes == null)
            {
               /* try
                {
                   
                }

                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mensaje del Sistema");
                    throw new Exception(ClientesBO.strMensajeBO);  
                } */

                // var c = 1;

                var clientes = new ClientesEntity();

                clientes.Cedula = this.mktCedula.Text;
                clientes.Nombre = this.txtNombre.Text;
                clientes.Apellidos = this.txtApellidos.Text;
                clientes.Direccion = this.txtDireccion.Text;
                clientes.Ciudad = this.cmbCiudad.SelectedValue.ToString();
                clientes.Provincia = this.cmbProvincia.SelectedValue.ToString();
                clientes.Telefono = this.mktTelefono.Text;
                // clientes.Cxc = c;
                clientes.Limite_credito = Convert.ToDecimal(this.mktLimteCredClient.Text);
                // clientes.Created = DateTime.Now.Date;


                var valCriterio = clientes.Cedula;
                var SearchCedProcess = ClientesBO.ExitsCedula(valCriterio);
                var messenge = new DialogResult();


                switch(SearchCedProcess)
                {
                    case true:

                        messenge = MessageBox.Show(ClientesBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (messenge == DialogResult.OK)
                        {
                            this.mktCedula.Focus();
                        }
                        break;

                    case false:

                        var question = new DialogResult();

                        question = MessageBox.Show("Esta apunto de Crear un Nuevo Cliente, Seguro quiere continuar", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (question == DialogResult.Yes)
                        {
                            ClientesBO.Save(clientes);
                            var resProcess = ClientesBO.ResultRequest(valCriterio);

                            if (resProcess == true)
                            {
                                MessageBox.Show(ClientesBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CleanControls();
                                this.errorProvider1.Clear();
                                DesableControls();
                                // this.btnCancelar.Enabled = true;
                                this.btnNuevo.Focus();
                            }
                            else if (resProcess == false)
                            {
                                MessageBox.Show(ClientesBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.errorProvider1.Clear();
                                this.mktCedula.Focus();
                            }

                        }
                        else if (question == DialogResult.No)
                        {
                            CleanControls();
                            this.errorProvider1.Clear();
                            DesableControls();
                            this.btnNuevo.Focus();
                        }

                        break;
                }

                /*
                if (SearchCedProcess == true)
                {

                }
                else if (SearchCedProcess == false)
                {
                    
                }*/
            }
        }

        #endregion

        #region Validator Controls

        /// <summary>
        /// Validator all controls
        /// </summary>
        /// <returns>It is return true if all controls are diferent than Empty</returns>
        public bool Validator()
        {

            bool result = true;

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                errorProvider1.SetError(this.txtNombre, "Ingresar Nombre");
                result = false;
            }
            if (string.IsNullOrEmpty(this.txtApellidos.Text))
            {
                result = false;
                errorProvider1.SetError(txtApellidos, "Ingresar Apellidos");
            }
            if (string.IsNullOrEmpty(this.txtDireccion.Text))
            {
                errorProvider1.SetError(this.txtDireccion, "Indicar la Direccion");
                result = false;

            }
            if (string.IsNullOrEmpty(this.cmbProvincia.Text))
            {
                errorProvider1.SetError(this.cmbProvincia, "Indicar la Provincia");
                result = false;
            }

            if (string.IsNullOrEmpty(this.cmbCiudad.Text))
            {
                errorProvider1.SetError(this.cmbCiudad, "Indicar la Ciudad");
                result = false;
            }

            if (string.IsNullOrEmpty(this.mktCedula.Text))
            {
                errorProvider1.SetError(this.mktCedula, "Indicar la Cedula");
                result = false;
                this.mktCedula.Focus();
            }

            if (string.IsNullOrEmpty(this.mktTelefono.Text))
            {
                errorProvider1.SetError(this.mktTelefono, "Indicar le Telefono");
                result = false;
            }

            return result;

        } 
        #endregion


        /// <summary>
        /// Desable Controls
        /// </summary>
        private void DesableControls()
        {
            this.mktCedula.Enabled = false;
            this.mktTelefono.Enabled = false;
            this.mktLimteCredClient.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtApellidos.Enabled = false;
            this.txtDireccion.Enabled = false;
            this.cmbCiudad.Enabled = false;
            this.cmbProvincia.Enabled = false;
            this.btnAgregarCiudad.Enabled = false;
            this.btnAgregarProvincia.Enabled = false;
            this.btnGuardar.Enabled = false;
          //  this.btnCancelar.Enabled = false;
        }

        /// <summary>
        /// Enabled Controls Clients
        /// </summary>
        public void EnabledControls()
        {
            this.mktCedula.Enabled = true;
            this.mktLimteCredClient.Enabled = true;
            this.mktTelefono.Enabled = true;
            this.txtNombre.Enabled = true;
            this.txtApellidos.Enabled = true;
            this.txtDireccion.Enabled = true;
            this.cmbCiudad.Enabled = true;
            this.cmbProvincia.Enabled = true;
            this.btnAgregarCiudad.Enabled = true;
            this.btnAgregarProvincia.Enabled = true;
            this.btnGuardar.Enabled = true;
           // this.btnCancelar.Enabled = true;
        }

        /// <summary>
        /// Clean Data the All Controls
        /// </summary>
        private void CleanControls()
        {
            this.mktCedula.Text = "";
            this.mktTelefono.Text = "";
            this.mktLimteCredClient.Text = "";
            this.txtNombre.Text = "";
            this.txtApellidos.Text = "";
            this.txtDireccion.Text = "";
            this.cmbCiudad.Text = "";
            this.cmbProvincia.Text = "";
            clientes = null;
        }


        /// <summary>
        ///  Initial Constrols Update Info Customers
        /// </summary>
        public void InitialControlsUp()
        {
            this.btnNuevo.Visible = false;
            this.btnGuardar.Visible = false;
            this.btnUpdateClient.Visible = true;
        }

        /// <summary>
        /// Initial All Controls Register Customers
        /// </summary>
        public void InitialControls()
        {
            //this.btnNuevo.Visible = false;
            //this.btnGuardar.Visible = false;
            //this.btnUpdateClient.Visible = true;

            // BackColor 
            this.mktCedula.BackColor = Color.Bisque;
            this.txtNombre.BackColor = Color.Bisque;
            this.txtApellidos.BackColor = Color.Bisque;
            this.txtDireccion.BackColor = Color.Bisque;
            this.mktLimteCredClient.BackColor = Color.Bisque;
            this.mktTelefono.BackColor = Color.Bisque;
            this.cmbCiudad.BackColor = Color.Bisque;
            this.cmbProvincia.BackColor = Color.Bisque;
            
            // ForeColor
            this.mktCedula.ForeColor = Color.Maroon;
            this.txtNombre.ForeColor = Color.Maroon;
            this.txtApellidos.ForeColor = Color.Maroon;
            this.txtDireccion.ForeColor = Color.Maroon;
            this.mktTelefono.ForeColor = Color.Maroon;
            this.mktLimteCredClient.ForeColor = Color.Maroon;
            this.cmbProvincia.ForeColor = Color.Maroon;
            this.cmbCiudad.ForeColor = Color.Maroon;
        }


        /// <summary>
        /// Update Client Informations
        /// </summary>
        private void UpdateClient()
        {
            var clientes = new ClientesEntity();

            try
            {
                if (clientes != null)
                {
                    clientes.Id = Int64.Parse(this.txtIdClient.Text);
                    clientes.Cedula = this.mktCedula.Text;
                    clientes.Nombre = this.txtNombre.Text;
                    clientes.Apellidos = this.txtApellidos.Text;
                    clientes.Direccion = this.txtDireccion.Text;
                    clientes.Telefono = this.mktTelefono.Text;
                    clientes.Limite_credito = Convert.ToDecimal(this.mktLimteCredClient.Text);
                    clientes.Ciudad = this.cmbCiudad.SelectedValue.ToString();
                    clientes.Provincia = this.cmbProvincia.SelectedValue.ToString();

                    ClientesBO.Update(clientes);

                    conClientes.dgvClientConsultar.DataSource = null;
                    conClientes.dgvClientConsultar.DataSource = ClientesBO.GetAll();
                                     
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        /// <summary>
        /// Uppcase Textbox
        /// </summary>
        private void UpperText()
        {
            this.txtNombre.CharacterCasing = CharacterCasing.Upper;
            this.txtDireccion.CharacterCasing = CharacterCasing.Upper;
            this.txtApellidos.CharacterCasing = CharacterCasing.Upper;
        }

        /// <summary>
        /// Load All States
        /// </summary>
        private void LoadProvincias()
        {
            this.cmbProvincia.DisplayMember = "Nombre";
            this.cmbProvincia.ValueMember = "Id_provincia";
            this.cmbProvincia.DataSource = ProvinciaBO.GetAll();
        }

        /// <summary>
        ///  Load All Cities
        /// </summary>
        private void LoadCiudades()
        {
            this.cmbCiudad.DisplayMember = "Nombre";
            this.cmbCiudad.ValueMember = "Id_ciudad";
            this.cmbCiudad.DataSource = CiudadBO.GetAll();
        }



        private void frmRegClientes_Load(object sender, EventArgs e)
        {
            DescripControls();
            DesableControls();
            InitialControls();
            this.errorProvider1.Clear();
            this.btnNuevo.Focus();
            UpperText();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.errorProvider1.Clear();
            CleanControls();
            this.Close();
        }

        private void btnAgregarCiudad_Click(object sender, EventArgs e)
        {
            frmAddCiudad Ciudad = new frmAddCiudad();
            Ciudad.ShowDialog(this);
        }

        private void btnAgregarProvincia_Click(object sender, EventArgs e)
        {
            frmAddProvincia Pronvicia = new frmAddProvincia();
            Pronvicia.ShowDialog(this);
        }

        /// <summary>
        /// Update Customer's Informations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateClient_Click(object sender, EventArgs e)
        {
            var number = this.mktCedula.Text; //087-0021479-7

            if (number.Length < 13)
            {
                MessageBox.Show("Indicar informacion Valida", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.mktCedula.Focus();
            }
            else 
            {
                bool error = false;
                var message = ClientesBO.ExitsCedula(number);


                switch (message)
                {
                    case true:
                        
                        var question = new DialogResult();

                        MessageBox.Show(ClientesBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        question = MessageBox.Show("Esta Apunto de Actualizar la Información del Cliente. Seguro desea Continuar?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                        if (question == DialogResult.Yes)
                        {
                            try
                            {
                                UpdateClient();
                                MessageBox.Show("Las Informaciones fueron Actualizas Satisfactoriamente!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                error = true;
                            }
                            finally
                            {
                                if (error == true)
                                {
                                    MessageBox.Show("Verificar la informaciones indicadas", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    this.mktCedula.Focus();
                                }
                            }
                        }
                        else if (question == DialogResult.No)
                        {
                            this.Close();
                            return;
                        }

                        break;

                    case false:

                        MessageBox.Show(ClientesBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.CleanControls();
                        this.mktCedula.Focus();

                        break;
                }

            }

            
        }

        private void cmbProvincia_DropDown(object sender, EventArgs e)
        {
            try
            {
                LoadProvincias();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cmbCiudad_DropDown(object sender, EventArgs e)
        {
            try
            {
                LoadCiudades();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
