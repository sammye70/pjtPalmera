using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;
using pjPalmera.BLL;
using pjPalmera.Entities;


namespace pjPalmera.PL
{
    public partial class frmRegClientes : Form
    {
        //
        ClientesEntity clientes = null;

        public frmRegClientes()
        {
            InitializeComponent();
        }

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //validator controls
            try
            {
                if (Validator() == true)
                {
                    NewCostumer();
                    CleanControls();
                    this.errorProvider1.Clear();
                    DesableControls();
                    this.btnCancelar.Enabled = true;
                    this.btnNuevo.Focus();
                    MessageBox.Show("Guardado Satisfactoriamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(Validator() == false)
                {
                    MessageBox.Show("Proporcionar los campos indicados ", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                clientes = null;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EnabledControls();
            this.mktCedula.Focus();
            clientes = null;
            
        }

        /// <summary>
        /// Set Detail About Control
        /// </summary>
        private void SetTooltipControls()
        {
            toolTip1.SetToolTip(btnNuevo, "Nuevo Registro");
            toolTip1.SetToolTip(btnGuardar, "Guardar Registro");
            toolTip1.SetToolTip(btnCancelar, "Limpiar Campos");
        }

        /// <summary>
        /// Save costumer from form
        /// </summary>
        private void NewCostumer()
        {
            if (clientes == null)
            {
                clientes = new ClientesEntity();
                clientes.Cedula = Convert.ToInt64(this.mktCedula.Text);
                clientes.Nombre = this.txtNombre.Text;
                clientes.Apellidos = this.txtApellidos.Text;
                clientes.Direccion = this.txtDireccion.Text;
                clientes.Ciudad = this.cmbCiudad.Text;
                clientes.Provincia = this.cmbProvincia.Text;
                clientes.Telefono = this.mktTelefono.Text;
                clientes.Created = DateTime.Now.Date;

                clientes = ClientesBO.Save(clientes);
                MessageBox.Show("Cliente Registrado Satisfactoriamente");   

            }
        }
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
            this.txtNombre.Enabled = false;
            this.txtApellidos.Enabled = false;
            this.txtDireccion.Enabled = false;
            this.cmbCiudad.Enabled = false;
            this.cmbProvincia.Enabled = false;
            this.btnAgregarCiudad.Enabled = false;
            this.btnAgregarProvincia.Enabled = false;
            this.btnGuardar.Enabled = false;
            this.btnCancelar.Enabled = false;
        }

        /// <summary>
        /// Enabled Controls
        /// </summary>
        private void EnabledControls()
        {
            this.mktCedula.Enabled = true;
            this.mktTelefono.Enabled = true;
            this.txtNombre.Enabled = true;
            this.txtApellidos.Enabled = true;
            this.txtDireccion.Enabled = true;
            this.cmbCiudad.Enabled = true;
            this.cmbProvincia.Enabled = true;
            this.btnAgregarCiudad.Enabled = true;
            this.btnAgregarProvincia.Enabled = true;
            this.btnGuardar.Enabled = true;
            this.btnCancelar.Enabled = true;
        }

        /// <summary>
        /// Remove Data the All Controls
        /// </summary>
        private void CleanControls()
        {
            this.mktCedula.Text = "";
            this.mktTelefono.Text = "";
            this.txtNombre.Text = "";
            this.txtApellidos.Text = "";
            this.txtDireccion.Text = "";
            this.cmbCiudad.Text = "";
            this.cmbProvincia.Text = "";
            clientes = null;
        }

        /// <summary>
        /// Initial All Controls
        /// </summary>
        private void InitialControls()
        {
            
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

        private void frmRegClientes_Load(object sender, EventArgs e)
        {            
            SetTooltipControls();
            DesableControls();
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


    }
}
