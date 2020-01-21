using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pjPalmera.DAL;
using pjPalmera.Entities;

namespace pjPalmera.BLL
{
    public class UsuariosBO
    {
        UsuariosEntity user = new UsuariosEntity();

        /// <summary>
        /// Create New Account User
        /// </summary>
        /// <param name="Usuarios"></param>
        /// <returns></returns>
        public static UsuariosEntity Save(UsuariosEntity Usuarios)
        {
            try
            {
                return UsuariosDAL.Create(Usuarios);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        /// <summary>
        /// Search user and password. Then they are true allow to login, else not allow to login.
        /// </summary>
        /// <returns></returns>
        public static void Login_User(UsuariosEntity user)
        {
             UsuariosDAL.Login_User(user);
        }
    }
}
