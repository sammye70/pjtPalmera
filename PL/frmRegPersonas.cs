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
    public partial class frmRegPersonas : Form
    {
        PersonasEntity Personas = null;
        public frmRegPersonas()
        {
            InitializeComponent();
        }


        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
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

        private void frmPersonas_Load(object sender, EventArgs e)
        {
            SetTooltipControls();
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            frmRegUsers users = new PL.frmRegUsers();
            users.ShowDialog(this);
        }

        private void btnCrearUsuario_Click_1(object sender, EventArgs e)
        {
            frmRegUsers User = new frmRegUsers();
            User.ShowDialog(this);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //
            try
            {   
                if (Validator() == true)
                {
                    NewPerson();
                    CleanControls();
                    this.errorProvider1.Clear();
                    DesableControls();
                    MessageBox.Show("Guardado Satisfactoriamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Proporcionar los campos indicados ", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
             //   Personas = null;

            }
            finally
            {
                Personas = null;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CleanControls();
            this.Close();
        }

        /// <summary>
        /// Validator all controls
        /// </summary>
        /// <returns>It is return true if all controls are diferent than Empty</returns>
        public bool Validator()
        {
            bool result=true;

            if (string.IsNullOrEmpty(this.txtNombre.Text))
            {
                this.errorProvider1.SetError(this.txtNombre,"Indicar Nombre");
                result = false;
            }

            if (string.IsNullOrEmpty(this.txtApellidos.Text))
            {
                this.errorProvider1.SetError(this.txtApellidos, "Indicar Apellidos");
                result = false;
            }

            if (string.IsNullOrEmpty(this.txtDireccion.Text))
            {
                this.errorProvider1.SetError(this.txtDireccion, "Indicar Direccion");
                result = false;
            }


            if (string.IsNullOrEmpty(this.mktCedula.Text))
            {
                this.errorProvider1.SetError(this.mktCedula, "Indicar Cedula");
                result = false;
            }

            if (string.IsNullOrEmpty(this.mktSueldo.Text))
            {
                this.errorProvider1.SetError(this.mktSueldo, "Indicar Sueldo");
                result = false;
            }

            if (string.IsNullOrEmpty(this.mktTelefono.Text))
            {
                this.errorProvider1.SetError(this.mktTelefono, "Indicar Telefono");
                result = false;
            }

            if (string.IsNullOrEmpty(this.cmbPosicion.Text))
            {
                this.errorProvider1.SetError(this.cmbPosicion, "Indicar Posicion");
                result = false;
            }


            return result;
        }

        /// <summary>
        /// Desable All Controls
        /// </summary>
        private void DesableControls()
        {
            this.mktCedula.Enabled = false;
            this.mktSueldo.Enabled = false;
            this.mktTelefono.Enabled = false;
            this.cmbPosicion.Enabled = false;
            this.txtApellidos.Enabled = false;
            this.txtDireccion.Enabled = false;
            this.txtNombre.Enabled = false;
            this.btnGuardar.Enabled = false;
        }

        /// <summary>
        /// Enable All Controls
        /// </summary>
        private void EnableControls()
        {
            this.mktCedula.Enabled = true;
            this.mktSueldo.Enabled = true;
            this.mktTelefono.Enabled = true;
            this.cmbPosicion.Enabled = true;
            this.txtApellidos.Enabled = true;
            this.txtDireccion.Enabled = true;
            this.txtNombre.Enabled = true;
            this.btnGuardar.Enabled = true;

        }

        /// <summary>
        /// Clean all Controls
        /// </summary>
        private void CleanControls()
        {
            this.mktCedula.Text = "";
            this.mktSueldo.Text = "";
            this.mktTelefono.Text="";
            this.txtApellidos.Text = "";
            this.txtDireccion.Text = "";
            this.txtNombre.Text = "";
            this.cmbPosicion.Text ="";
        }


        /// <summary>
        /// Save New Person
        /// </summary>
        private void NewPerson()
        {
            if (Personas == null)
            {
                Personas = new PersonasEntity();

                Personas.Cedula = Convert.ToString(this.mktCedula.Text);
                Personas.Nombre = this.txtNombre.Text;
                Personas.Apellidos = this.txtApellidos.Text;
                Personas.Direccion = this.txtDireccion.Text;
                Personas.Telefono = this.mktTelefono.Text;
                Personas.Posicion = this.cmbPosicion.Text;
                Personas.Sueldo = Convert.ToDecimal(this.mktSueldo.Text);
           
                PersonasBO.Save(Personas);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Personas = null;
            CleanControls();
            EnableControls();
            this.mktCedula.Focus();
        }

        private void frmRegPersonas_Load(object sender, EventArgs e)
        {
            DesableControls();
            this.btnNuevo.Focus();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
    }
}
