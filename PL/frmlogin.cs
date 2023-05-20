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
using PL;
using System.Runtime.CompilerServices;
using System.Threading;

namespace pjPalmera.PL
{
    public partial class frmlogin : Form
    {
        /// <summary>
        ///  Class that content User Information properties for login
        /// </summary>
        UsuariosEntity user = new UsuariosEntity();

        public frmlogin()
        {
            InitializeComponent();
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {
            //
            CleanControls();
            SetTool();
            this.txtUserName.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Clean content inside all controls
        /// </summary>
        private void CleanControls() 
        {
            this.txtUserName.Text = "";
            this.txtPassword.Text = "";
        }

        /// <summary>
        ///  Verify if exists contents inside controls
        /// </summary>
        /// <returns></returns>
        private bool CheckStringControls()
        {
            bool ans = true;
           // var usr = usrprofile.User_name;
           // var usrpass = usrprofile.Password;

            if (this.txtUserName.Text == string.Empty)
            {
                this.errorProvider1.SetError(this.txtUserName, "Indicar un nombre de usuario.");
                this.txtUserName.Focus();
                return ans = false;
            }

            if (this.txtPassword.Text == string.Empty)
            {
                this.errorProvider1.SetError(this.txtPassword, "Indicar una contraseña.");
                this.txtPassword.Focus();
                return ans = false;
            }

          return ans;
        }

        /// <summary>
        ///  Process user login in the system
        /// </summary>
        private void procLogin() 
        {
            try
            {
                var fmain = new frmPrincipal(); // Get principal form
                //var log = new frmlogin();
                user.User_name = this.txtUserName.Text; // Get username from textbox username
                user.Password = this.txtPassword.Text; // Get password from textbox password
                user.Password = user.setHash(user.Password); // Generate and Encrypt password
                /// var strform = CheckStringControls(user); // Check if exists some things inside form
                var stUser = UsuariosBO.GetStatusUser(user.User_name); // Check username status

                
                if (CheckStringControls() != false)
                   
                switch (stUser)
                {
                    case true:
                        var loguser = UsuariosBO.Login_User(user); // Validator user and pass
                        var infuser = UsuariosBO.LoadUserInf(user); // Get user info

                        if (loguser == true)
                        {
                            //fmain.txtUsername.Text = infuser.User_name;
                            fmain.lblUserAuth.Text = infuser.User_name;
                            fmain.txtLongName.Text = infuser.LongName;
                            fmain.lblLongName.Text = infuser.LongName;
                            fmain.txtPermisson.Text = infuser.Privileges.ToString();
                            fmain.txtIdUser.Text = infuser.Id_user.ToString();
                            
                            this.Hide();
                            fmain.Show();

                            // MessageBox.Show("Login User", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if (loguser == false)
                        {
                            MessageBox.Show(UsuariosBO.strMessegerBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtUserName.Focus();
                        }
                        break;

                    case false:
                        MessageBox.Show(UsuariosBO.strMessegerBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.txtUserName.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Set Details about Constrols
        /// </summary>
        private void SetTool()
        {
            this.lblCompanyName.Text = "By Code Solutions";
            this.toolTip1.SetToolTip(this.btnCancelar,"Cancela el ingreso al Sistema");
            this.toolTip1.SetToolTip(this.btnIniciar, "Ingreso al Sistema");
            this.toolTip1.SetToolTip(this.lblForgetPassword, "Click para recuperar la contraseña a partir de la pregunta de seguridad.");
            this.toolTip1.SetToolTip(this.txtUserName, "Indicar un nombre de usuario válido");
            this.toolTip1.SetToolTip(this.txtPassword, "Indicar una contraseña válida relacionada al usuario indicado arriba.");
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            procLogin();
        }

        private void lblForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //var RecoveryPass = new frmRecoveryPassword();
            //RecoveryPass.ShowDialog(this);
            MessageBox.Show("Esta función no esta disponible. Disculpe los inconvenientes. \n Si necesita alguna información consultar su supervisor o administrador.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                this.btnIniciar.Focus();
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtPassword.Focus();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
