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

            MaxLengthPass();
            CleanControls();
            this.lblRescPassDiferent.Text = ".";
            this.btnNuevo.Focus();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EnableControls();
            this.txtFirstName.Focus();
        }

        #region Validator all controls before with save process
        /// <summary>
        /// Checking TextBox are not Empty
        /// </summary>
        /// <returns>It is true if TextBox is equalt to Empty</returns>
        public bool Validator_Controls()
        {

            bool result = false;

            if (string.IsNullOrEmpty(this.txtFirstName.Text) == true)
            {
                this.errorProvider1.SetError(this.txtFirstName, "Indicar un nombre.");
                result = true;
            }

            if (string.IsNullOrEmpty(this.txtLastName.Text) == true)
            {
                this.errorProvider1.SetError(this.txtLastName, "Indicar el/los apellido(s).");
                result = true;
            }

            if (string.IsNullOrEmpty(this.txtUsername.Text) == true)
            {
                this.errorProvider1.SetError(this.txtUsername, "Indicar un usuario.");
                result = true;
            }

            if (string.IsNullOrEmpty(this.txtPassword.Text) == true)
            {
                this.errorProvider1.SetError(this.txtPassword, "Indicar una contraseña.");
                result = true;
            }

            if (string.IsNullOrEmpty(this.txtRetPassword.Text) == true)
            {
                this.errorProvider1.SetError(this.txtRetPassword, "Indicar la contraseña igual a la anterior.");
                result = true;
            }

            if (string.IsNullOrEmpty(this.cmbPrivileges.Text) == true || this.cmbPrivileges.SelectedIndex == -1 || this.cmbPrivileges.SelectedIndex < 0)
            {
                this.errorProvider1.SetError(this.cmbPrivileges, "Seleccionar un rol para otorgar al usuario de los listados.");
                result = true;
            }

            if (string.IsNullOrEmpty(this.cmbSecretQuestion1.Text) == true || this.cmbSecretQuestion1.SelectedIndex == -1 || this.cmbSecretQuestion1.SelectedIndex < 0)
            {
                this.errorProvider1.SetError(this.cmbSecretQuestion1, "Seleccionar una pregunta de seguridad de las listadas.");
                result = true;
            }

            if (string.IsNullOrEmpty(this.txtSecretAnswer1.Text) == true)
            {
                this.errorProvider1.SetError(this.txtSecretAnswer1, "Indicar la respuesta a la pregunta de seguridad.");
                result = true;
            }

            if (CheckPass() != true)
            {
                result = true;
            }

            return result;
        }

        #endregion


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
            this.cmbSecretQuestion1.Enabled = true;
        }

        /// <summary>
        /// Desable all controls on this form
        /// </summary>
        public void DesableControls()
        {
            this.txtFirstName.Enabled = false;
            this.txtLastName.Enabled = false;
            this.txtUsername.Enabled = false;
            this.txtPassword.Enabled = false;
            this.txtRetPassword.Enabled = false;
            this.cmbPrivileges.Enabled = false;
            this.btnGuardar.Enabled = false;
            this.txtSecretAnswer1.Enabled = false;
            this.cmbSecretQuestion1.Enabled = false;
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
            this.txtSecretAnswer1.Text = "";
            this.cmbSecretQuestion1.Text = "";
        }


        /// <summary>
        /// Update informations about User
        /// </summary>
        private void UpdateUser()
        {
            var user = new UsuariosEntity();
            string email = "n/a";
            int status = 1;
            var pass_hash = user.setHash(this.txtPassword.Text);
            var sec_ans_hast = user.setHash(this.txtSecretAnswer1.Text);

            user.Createby = int.Parse(this.txtidUser.Text);
            user.Id_user = int.Parse(this.txtUserIdMod.Text);
            user.Firstname = this.txtFirstName.Text;
            user.Lastname = this.txtLastName.Text;
            user.LongName = user.ContName(user.Firstname, user.Lastname);
            user.User_name = this.txtUsername.Text;
            user.Password = pass_hash;
            user.Email = email;
            user.Privileges = this.cmbPrivileges.SelectedIndex.ToString();
            user.Secret_question = this.cmbSecretQuestion1.SelectedIndex.ToString();
            user.Secret_answer = sec_ans_hast;
            user.Status = Convert.ToString(status);

            UsuariosBO.Update(user);
            CleanControls();
            DesableControls();
            this.errorProvider1.Clear();
            this.Close();
        }

        #region Create new user
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
                    int status = 1;
                    var pass_hash = user.setHash(this.txtPassword.Text);
                    var sec_ans_hash = user.setHash(this.txtSecretAnswer1.Text);

                    user.Createby = int.Parse(this.txtidUser.Text);
                    user.Firstname = this.txtFirstName.Text;
                    user.Lastname = this.txtLastName.Text;
                    user.LongName = user.ContName(user.Firstname, user.Lastname);
                    user.User_name = this.txtUsername.Text;
                    user.Password = pass_hash;
                    user.Email = email;
                    user.Privileges = this.cmbPrivileges.SelectedIndex.ToString();
                    user.Secret_question = this.cmbSecretQuestion1.SelectedIndex.ToString();
                    user.Secret_answer = sec_ans_hash;
                    user.Status = Convert.ToString(status);

                    UsuariosBO.Save(user);
                    CleanControls();
                    DesableControls();
                    this.errorProvider1.Clear();
                    this.btnNuevo.Focus();

                    break;
            }
        }
        #endregion

        #region Verify if passwords are the same
        /// <summary>
        ///  Verify properties, behivors for password and repassword
        /// </summary>
        /// <returns> true when the password and repassword are equals otherwise false</returns>
        private bool CheckPass()
        {
            bool result = true;
            var pass = this.txtPassword.Text; // main password
            var respass = this.txtRetPassword.Text; // password confirmation

            // Verify if main password and confirmation password are same.
            if (string.Equals(pass,respass) == true)
            {
                this.lblRescPassDiferent.Text = "";
                result = true;
            }
            else
            {
                this.lblRescPassDiferent.ForeColor = Color.Red;
                this.lblRescPassDiferent.Text = "Las Contraseñas son Diferentes.";
                this.errorProvider1.SetError(this.txtPassword, "Verificar la contraseña indicada!");
                this.errorProvider1.SetError(this.txtRetPassword, "Indicar una contraseña igual que la anterior!");
                result = false;
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

            return result;
        }
        #endregion

        #region Password Length
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

        #endregion

        /// <summary>
        ///  Load all avalible secret questions that can set to users
        /// </summary>
        private void loadSecretQuestions()
        {
            this.cmbSecretQuestion1.DataSource = UsuariosBO.getSecretQuestions;
            this.cmbSecretQuestion1.DisplayMember = "Question";
        }


        /// <summary>
        /// Load all avaible roles that can set to users
        /// </summary>
        private void loadRolUsers()
        {
            this.cmbPrivileges.DataSource = UsuariosBO.getRoles;
            this.cmbPrivileges.DisplayMember = "Rol";
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validator_Controls() != false)
                    return;

                this.NewUser();

               
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

        private void cmbPrivileges_DropDown(object sender, EventArgs e)
        {
            try
            {
                this.loadRolUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmbSecretQuestion1_DropDown(object sender, EventArgs e)
        {
            try
            {
                this.loadSecretQuestions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if(Validator_Controls() != false)
                    return;

                this.UpdateUser();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
