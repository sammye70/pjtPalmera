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
    public partial class frmlogin : Form
    {
        UsuariosEntity usuario = new UsuariosEntity();

        public frmlogin()
        {
            InitializeComponent();
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {
            SetTool();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Set Details about Constrols
        /// </summary>
        private void SetTool()
        {
            toolTip1.SetToolTip(this.btnCancelar,"Cancela el ingreso al Sistema");
            toolTip1.SetToolTip(this.btnIniciar, "Ingreso al Sistema");
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    UsuariosBO.Login_User(usuario);

            //    if ((usuario.User_name == this.txtUserName.Text) && (usuario.Password == this.txtPassword.Text))
            //    {
            //        MessageBox.Show("Puede Iniciar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      this.Close();
            //    }
            //    else
            //    {
            //       MessageBox.Show("Indicar Usuario y Contraseña sean Validos!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Mensaje de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
            
        }
    }
}
