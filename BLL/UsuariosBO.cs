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
        ///  Return Numeric Result from UsuariosBO
        /// </summary>
        public static int result;
            
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
        ///  Get status current user that try login.
        /// </summary>
        /// <returns> true when status is enable or false if it's disabled</returns>
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
                strMessegerBO = "Ufff Algo Salio Mal.\n \n Pasos sugeridos para intentar solucionar: \n \n 1. Comprobar que el Router o Switch tenga todos los indicadores de luz encendidos.\n \n 2. Verificar que el computador tenga conectividad con la Red. \n 3. Comprobar que el cable de Red este conectado desde el computador hasta el Router o Switch.\n \n 4. Verificar que el cable este en buen estado (ambas puntas del cable, y que no tenga cortes). \n  \n Cualquier otro inconveniente fuera de los listadas anteriormente contactar asistencia de Soporte Técnico.";
                return false;
            }
        }

        /// <summary>
        ///  Get all information about User after login successfully by User Name
        /// </summary>
        /// <returns></returns>
        public static UsuariosEntity LoadUserInf(UsuariosEntity userInfo)
        {
            try
            {
                var usuarioDAL = UsuariosDAL.LoadUserInf(userInfo);
                if ( usuarioDAL == null)
                {
                    throw new Exception("Usuario no inizializado.");
                }
                else 
                {
                 return UsuariosDAL.LoadUserInf(userInfo);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

 
        /* ------------ WARNING -----------
         * Now this project needs to create rules for manager permissions when user try open some module. The rules would building inside BO Entity (e. create products, not everyone can create new items ----> FacturaBO, etc).  NOTE: see BO above.
         * ---- DONE ----
        */   

        /// <summary>
        ///  Get level permission by user to enable or disable controls
        /// </summary>
        /// <returns></returns>
        public static Int32 getVisibleControls(UsuariosEntity user)
        {
            try
            {
                var uLevel = UsuariosDAL.LoadUserInfid(user);
                var rol1 = (int)eRoles_U.supervisor;
                var rol2 = (int)eRoles_U.cashier;
                var rol3 = (int)eRoles_U.storeges_clerk;
                var rol4 = (int)eRoles_U.seller;

                if (uLevel == null)
                {
                    throw new AggregateException("Usuario no inizializado.");
                }

                else
                {
                    if (rol1 == uLevel.Privileges)
                    {
                        result = uLevel.Privileges;
                    }
                    else if (rol2 == uLevel.Privileges)
                    {
                        result = uLevel.Privileges;
                    }
                    else if (rol3 == uLevel.Privileges)
                    {
                        result = uLevel.Privileges;
                    }
                    else if (rol4 == uLevel.Privileges)
                    {
                        result = uLevel.Privileges;
                    }

                    else
                    {
                        throw new  ApplicationException("No tiene permisos para realizar la operación.");

                    }
                }

                return result;
            }
            catch (AggregateException ax)
            {
                MessageBox.Show(ax.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return result;

            }
            catch (ApplicationException ax)
            {
                MessageBox.Show(ax.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result; 
                    
            }
        }

    }
}
