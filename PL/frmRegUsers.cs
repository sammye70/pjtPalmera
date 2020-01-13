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
    public partial class frmRegUsers : Form
    {
        UsuariosEntity Usuarios = null;

        public frmRegUsers()
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CleanControls();
            this.Close();
        }

        private void frmRegUsers_Load(object sender, EventArgs e)
        {
            DesableControls();
            this.btnNuevo.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EnableControls();
            this.txtUsername.Focus();
        }


        /// <summary>
        /// Checking TextBox are not Empty
        /// </summary>
        /// <returns>It is true if TextBox is equialt to Empty</returns>
        public bool Validator_Controls()
        {
            bool result = true;

            if (string.IsNullOrEmpty(this.txtUsername.Text))
            {
                this.errorProvider1.SetError(this.txtUsername, "Indicar un nombre de usuario");
                result = false;
            }

            if (string.IsNullOrEmpty(this.txtPassword.Text))
            {
                this.errorProvider1.SetError(this.txtPassword, "Indicar una contraseña");
                result = false;
            }

            if (string.IsNullOrEmpty(this.txtRetPassword.Text))
            {
                this.errorProvider1.SetError(this.txtRetPassword, "Indicar la contraseña igual a la anterior");
                result = false;
            }

            if (string.IsNullOrEmpty(this.cmbPrivileges.Text))
            {
                this.errorProvider1.SetError(this.cmbPrivileges, "Indicar privilegios al usuario");
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Checking  the fields password and re-password are equivalent
        /// </summary>
        /// <returns></returns>
        public bool Password_Validator()
        {
            bool Result = true;
            if (this.txtPassword.Text == this.txtRetPassword.Text)
            {
                Result = true;
            }
            else
            {
                Result = false;
            }
            return Result;
        }

        /// <summary>
        /// Enable all controls on this form
        /// </summary>
        private void EnableControls()
        {
            this.txtUsername.Enabled = true;
            this.txtPassword.Enabled = true;
            this.txtRetPassword.Enabled = true;
            this.cmbPrivileges.Enabled = true;
            this.btnGuardar.Enabled = true;
        }

        /// <summary>
        /// Desable all controls on this form
        /// </summary>
        private void DesableControls()
        {
            this.txtUsername.Enabled = false;
            this.txtPassword.Enabled = false;
            this.txtRetPassword.Enabled = false;
            this.cmbPrivileges.Enabled = false;
            this.btnGuardar.Enabled = false;
        }

        /// <summary>
        /// Clean all controls
        /// </summary>
        private void CleanControls()
        {
            this.txtPassword.Text = "";
            this.txtRetPassword.Text = "";
            this.txtUsername.Text = "";
            this.cmbPrivileges.Text = "";
        }

        /// <summary>
        /// Create New User
        /// </summary>
        private void NewUser()
        {
            Usuarios = new UsuariosEntity();
            string email = "n/a";
            int privilege = 1, status=1;


            Usuarios.User_name = this.txtUsername.Text;
            Usuarios.Password = this.txtPassword.Text;
            Usuarios.Created = DateTime.Now;
            Usuarios.Email = email;
            Usuarios.Privileges = privilege;
            Usuarios.Status = Convert.ToString(status);

            UsuariosBO.Save(Usuarios);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Validator_Controls() == true) && (Password_Validator() == true))
                {
                    NewUser();
                    CleanControls();
                    DesableControls();
                    this.errorProvider1.Clear();
                    MessageBox.Show("Usuario Creado Satisfactoriamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.btnNuevo.Focus();
                }
                else
                {
                    MessageBox.Show("Verificar nombre de Usuario o Contraseña / Privilegios que sean validos", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Usuarios = null;
            }
            
        }
    }
}
