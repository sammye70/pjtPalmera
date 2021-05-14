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
        /// <summary>
        /// Messeger to Result from UsuariosBO
        /// </summary>
        public static string strMessegerBO;

            
        /// <summary>
        /// Create New Account User
        /// </summary>
        /// <param name="user"></param>
        public static void Save(UsuariosEntity user)
        {
            try
            {
                UsuariosDAL.Create(user);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        /// <summary>
        /// Check if exists username
        /// </summary>
        /// <returns>true or false</returns>
        public static bool ExistsUser(string username)
        {
            var val = UsuariosDAL.ExistsUser(username);

            if (val == true)
            {
                strMessegerBO = ("AVISO \n") + " El Nombre de Usuario indicado fue registrado anteriormente. \n Por favor indicar uno distinto.";
                return val;
            }
            else if (val == false)
            {
                // strMessage = "El Nombre de Usuario indicado esta disponible.";
                return val;
            }

            return val;
        }


        /// <summary>
        /// Search user and password. Then they are true allow to login, else not login.
        /// </summary>
        /// <returns></returns>
        public static bool Login_User(UsuariosEntity user)
        {

           var val = UsuariosDAL.Login_User(user);

            if (val == true)
            {
               return val;
            }
            else if (val == false)
            {
                strMessegerBO = "El nombre de usuario o la contraseña no son válidos. Verificar y después intentar nuevamente.";
                return val;
            }

            return val;
        }


        /// <summary>
        ///  Get status current user.
        ///  Return true when status is enable o false if it's desable
        /// </summary>
        /// <returns>true or false</returns>
        public static bool GetStatusUser(string user)
        {
            try
            {
                var val = UsuariosDAL.StatusUser(user);

                if (val == true)
                {
                    return val; 
                }
                else if (val == false)
                {
                    strMessegerBO = "Cuenta de Usuario Deshabilitada, Contactar el Administrador del Sistema o Supervisor de Turno.";
                    return val;
                }

                return val;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        ///  Get all information about User after login normal
        /// </summary>
        /// <returns></returns>
        public static UsuariosEntity LoadUserInf(string username)
        {
            try
            {
                return UsuariosDAL.LoadUserInf(username);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
