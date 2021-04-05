using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using pjPalmera.Entities;
using pjPalmera.BLL;

namespace pjPalmera.PL
{
    public partial class frmRegUsers : Form
    {
      // UsuariosEntity Usuarios = new UsuariosEntity();

        public frmRegUsers()
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CleanControls();
            this.Close();
        }

        private void frmRegUsers_Load(object sender, EventArgs e)
        {
            DesableControls();
            MaxLengthPass();
            this.btnNuevo.Focus();
            CleanControls();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EnableControls();
            this.txtFirstName.Focus();
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
                this.errorProvider1.SetError(this.txtUsername, "Indicar un nombre de usuario.");
                result = false;
            }

            if (string.IsNullOrEmpty(this.txtPassword.Text))
            {
                this.errorProvider1.SetError(this.txtPassword, "Indicar una contraseña.");
                result = false;
            }

            if (string.IsNullOrEmpty(this.txtRetPassword.Text))
            {
                this.errorProvider1.SetError(this.txtRetPassword, "Indicar la contraseña igual a la anterior.");
                result = false;
            }

            if (string.IsNullOrEmpty(this.cmbPrivileges.Text))
            {
                this.errorProvider1.SetError(this.cmbPrivileges, "Indicar privilegios al usuario.");
                result = false;
            }

            if (string.IsNullOrEmpty(this.txtSecretQuestion1.Text))
            {
                this.errorProvider1.SetError(this.txtSecretQuestion1, "Indicar una pregunta de seguridad.");
                result = false;
            }

            if (string.IsNullOrEmpty(this.txtSecretAnswer1.Text))
            {
                this.errorProvider1.SetError(this.txtSecretAnswer1, "Indicar la respuesta a la pregunta de seguridad.");
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
            this.txtFirstName.Enabled = true;
            this.txtLastName.Enabled = true;
            this.txtUsername.Enabled = true;
            this.txtPassword.Enabled = true;
            this.txtRetPassword.Enabled = true;
            this.cmbPrivileges.Enabled = true;
            this.btnGuardar.Enabled = true;
            this.txtSecretAnswer1.Enabled = true;
            this.txtSecretQuestion1.Enabled = true;
        }

        /// <summary>
        /// Desable all controls on this form
        /// </summary>
        private void DesableControls()
        {
            this.txtFirstName.Enabled = false;
            this.txtLastName.Enabled = false;
            this.txtUsername.Enabled = false;
            this.txtPassword.Enabled = false;
            this.txtRetPassword.Enabled = false;
            this.cmbPrivileges.Enabled = false;
            this.btnGuardar.Enabled = false;
            this.txtSecretAnswer1.Enabled = false;
            this.txtSecretQuestion1.Enabled = false;
        }

        /// <summary>
        /// Clean all controls
        /// </summary>
        private void CleanControls()
        {
            this.txtFirstName.Text = "";
            this.txtLastName.Text = "";
            this.txtPassword.Text = "";
            this.txtRetPassword.Text = "";
            this.txtUsername.Text = "";
            this.cmbPrivileges.Text = "";
            this.lblRescPassDiferent.Text = "";
            this.lblRescPassLength.Text = "";
            this.lblPassLength.Text = "";
            this.txtSecretQuestion1.Text = "";
            this.txtSecretAnswer1.Text = "";
        }

        /// <summary>
        /// Create New User
        /// </summary>
        private void NewUser()
        {
           var ValCrit = UsuariosBO.ExistsUser(this.txtUsername.Text);

            switch (ValCrit)
            {
                case true:
                    MessageBox.Show(UsuariosBO.strMessegerBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtUsername.Focus();
                    break;

                case false:
                    var user = new UsuariosEntity();
                    string email = "n/a";
                    int privilege = 1, status = 1;
                    var pass_hash = user.setHash(this.txtPassword.Text);
                    var sec_ans_hast = user.setHash(this.txtSecretAnswer1.Text);

                    user.Firstname = this.txtFirstName.Text;
                    user.Lastname = this.txtLastName.Text;
                    user.LongName = user.ContName(user.Firstname, user.Lastname);
                    user.User_name = this.txtUsername.Text;
                    user.Password = pass_hash;
                    user.Email = email;
                    user.Privileges = privilege;
                    user.Secret_question = this.txtSecretQuestion1.Text;
                    user.Secret_answer = sec_ans_hast;
                    user.Status = Convert.ToString(status);

                    UsuariosBO.Save(user);
                    MessageBox.Show("Usuario Creado Satisfactoriamente!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CleanControls();
                    DesableControls();
                    this.errorProvider1.Clear();
                    this.btnNuevo.Focus();

                    break;
            }
        }

        /// <summary>
        ///  Verify properties, behivors for password and repassword
        /// </summary>
        private void CheckPass()
        {
            var pass = this.txtPassword.Text; // main password
            var respass = this.txtRetPassword.Text; // password confirmation

            // Verify if main password and confirmation password are some.
            if (pass.Equals(respass))
            {
                this.lblRescPassDiferent.Text = "";
            }
            else
            {
                this.lblRescPassDiferent.ForeColor = Color.Red;
                this.lblRescPassDiferent.Text = "Las Contraseñas son Diferentes.";
            }

            // Check Reconfirmation password length 
            if (respass.Length <= 4)
            {
                this.lblPassLength.Visible = true;
                this.lblRescPassLength.Text = "Contraseña muy Débil";
                this.lblRescPassLength.BackColor = Color.Red;
            }
            else if (respass.Length <= 9)
            {
                this.lblRescPassLength.Visible = true;
                this.lblRescPassLength.Text = "Contraseña Moderable";
                this.lblRescPassLength.BackColor = Color.Yellow;
            }
            else if (respass.Length >= 10)
            {
                this.lblRescPassLength.Visible = true;
                this.lblRescPassLength.Text = "Contraseña Fuerte";
                this.lblRescPassLength.BackColor = Color.Green;
            }
            else 
            {
                this.lblRescPassLength.Visible = false;
            }


            // Check password length 
            if (pass.Length <= 4)
            {
                this.lblPassLength.Visible = true;
                this.lblPassLength.Text = "Contraseña muy Débil";
                this.lblPassLength.BackColor = Color.Red;
            }
            else if (pass.Length <= 9)
            {
                this.lblPassLength.Visible = true;
                this.lblPassLength.Text = "Contraseña Moderable";
                this.lblPassLength.BackColor = Color.Yellow;
            }
            else if (pass.Length >= 10)
            {
                this.lblPassLength.Visible = true;
                this.lblPassLength.Text = "Contraseña Fuerte";
                this.lblPassLength.BackColor = Color.Green;
            }
            else
            {
                this.lblPassLength.Visible = false;
            }
        }

        /// <summary>
        /// Set Maximum Characters in password and repassword.
        /// </summary>
        private void MaxLengthPass()
        {
            var passlng = this.txtPassword.MaxLength;
            var cfpasslng = this.txtRetPassword.MaxLength;

            passlng = 20;
            cfpasslng = 20;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Validator_Controls() == true) && (Password_Validator() == true))
                {
                    NewUser();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }          
        }

        private void txtRetPassword_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CheckPass();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CheckPass();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
