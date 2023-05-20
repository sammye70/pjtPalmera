using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
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
        ///  Return String Result from UsuariosBO
        /// </summary>
        public static string result;

        #region Save New User
        /// <summary>
        /// Create New Account User
        /// </summary>
        /// <param name="user"></param>
        public static void Save(UsuariosEntity user)
        {
            try
            {
                var result = UsuariosDAL.Create(user);

                if (result == 1)
                {
                    throw new AggregateException("Operación de Salvado Efectuada Satisfactoriamente!");
                }
                else
                {
                    throw new ApplicationException("Uff, algo ocurrio, no se pudo completar la operación solicitada");
                }

            }
            catch (AggregateException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            catch (ApplicationException ax)
            {
                MessageBox.Show(ax.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        #endregion

        #region Update informations about Users
        /// <summary>
        ///  Update All informations about Users
        /// </summary>
        public static void Update(UsuariosEntity user)
        {
            try
            {
                var result = UsuariosDAL.UpdateUser(user);

                if (result == 1)
                {
                    throw new AggregateException("Operación Actualización Efectuada Satisfactoriamente!");
                }
                else
                {
                    throw new ApplicationException("Uff, algo ocurrio mal, no se pudo completar la operación solicitada");
                }
            }
            catch (AggregateException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            catch (ApplicationException ax)
            {
                MessageBox.Show(ax.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        #endregion


        #region Remove User
        /// <summary>
        ///  Remove user by id
        /// </summary>
        public static void RemoveUser(UsuariosEntity user)
        {
            try
            {
                if (user.Id_user == 1)
                {
                    throw new ApplicationException("No es posible eliminar este usuario. Cualquier asistencia contacar soporte técnica");
                }
                else
                {
                    var result = UsuariosDAL.RemoveUser(user);

                    if (result == 1)
                    {
                        throw new AggregateException("Operación de Eliminación Efectuada Satisfactoriamente!");
                    }
                    else
                    {
                        throw new ApplicationException("Uff, algo ocurrio mal, no se pudo completar la operación solicitada");
                    }
                }

            }
            catch (AggregateException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (ApplicationException ax)
            {
                MessageBox.Show(ax.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        } 
        #endregion


        /// <summary>
        ///  Disable user by id
        /// </summary>
        public static void DisableUser(UsuariosEntity user)
        {
            try
            {
                var result = UsuariosDAL.DisableUser(user);

                if (result == 1)
                {
                    throw new AggregateException("Operación de Desactivar Cuenta de Usuario Efectuada Satisfactoriamente!");
                }
                else
                {
                    throw new ApplicationException("Uff, algo ocurrio mal, no se pudo completar la operación solicitada");
                }
            }
            catch (AggregateException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            catch (ApplicationException ax)
            {
                MessageBox.Show(ax.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        /// <summary>
        ///  Enable user by id
        /// </summary>
        public static void EnableUser(UsuariosEntity user)
        {
            try
            {
                var result = UsuariosDAL.EnableUser(user);

                if (result == 1)
                {
                    throw new AggregateException("Operación de Activar Cuenta de Usuario Efectuada Satisfactoriamente!");
                }
                else
                {
                    throw new ApplicationException("Uff, algo ocurrio mal, no se pudo completar la operación solicitada");
                }
            }
            catch (AggregateException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            catch (ApplicationException ax)
            {
                MessageBox.Show(ax.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }


        #region Verify if user exists or not
        /// <summary>
        /// Check if exists username
        /// </summary>
        /// <returns>true when user exists and otherwise false</returns>
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
        #endregion

        #region User login process
        /// <summary>
        /// Search user and password. Then they are true allow to login, else not login.
        /// </summary>
        /// <returns>true when user or password are the same that registred and otherwise false</returns>
        public static bool Login_User(UsuariosEntity user)
        {

            try
            {
                var val = UsuariosDAL.Login_User(user);

                if (val == true)
                {
                    return val;
                }
                else if (val == false)
                {
                    strMessegerBO = "El nombre de usuario o la contraseña no es válido. Verificar y después intentar nuevamente.";
                    return val;
                }

                return val;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


        #region Verify user status before login or anything else task
        /// <summary>
        ///  Get status current user that try login.
        /// </summary>
        /// <returns> true when status is enable otherwise false </returns>
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
        #endregion

        /// <summary>
        ///  Get all information about User after login successfully by User Name
        /// </summary>
        /// <returns></returns>
        public static UsuariosEntity LoadUserInf(UsuariosEntity userInfo)
        {
            try
            {
                var user = UsuariosDAL.LoadUserInf(userInfo);

                if ( user == null)
                {
                    throw new Exception("Usuario no inicializado!");
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

    

        /// <summary>
        /// Get All Users
        /// </summary>
        public static List<UsuariosEntity> getAllUsers
        {
            get 
            {       
                try 
                {
                    var ls = UsuariosDAL.getAllUsers;
                    if (ls == null)
                    {
                        throw new ApplicationException("No se inicializo la lista de Usuarios.");
                    }
                    else 
                    {
                        return ls;
                    }
                }

                catch (ApplicationException ax)
                {
                    MessageBox.Show(ax.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
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
        public static string getVisibleControls(UsuariosEntity user)
        {
            try
            {
                var uLevel = UsuariosDAL.LoadUserInfid(user);

                if (uLevel == null)
                {
                    throw new ApplicationException("Usuario no inicializado.");
                }

                else
                {
                    return result = uLevel.Privileges;
                }
            }
            catch (ApplicationException ax)
            {
                MessageBox.Show(ax.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;   
            }
        }



        /// <summary>
        ///  Get all secret questions
        /// </summary>
        public static List<QuestionsEntity> getSecretQuestions
        {
            get 
            {
                try
                {
                   var question = UsuariosDAL.getSecretQuestions;

                    if(question == null)
                    {
                        throw new ApplicationException("No se inicializo la lista de preguntas.");
                    }
                    else
                    {
                        return question;
                    }
                }

                catch (ApplicationException ae)
                {
                    MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        /// <summary>
        /// Get all user roles
        /// </summary>
        public static List<RolesEntity> getRoles
        {
            get
            {
                try
                {
                    var roles = UsuariosDAL.getRoles;

                    if (roles == null)
                    {
                        throw new ApplicationException("No se inicializó la lista de roles.");
                    }
                    else
                    {
                        return roles;
                    }
                }

                catch (ApplicationException ae)
                {
                    MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }



        /// <summary>
        ///   Get All User by longname
        /// </summary>
        public static List<UsuariosEntity> getUserByLongName(UsuariosEntity User)
        {
            try
            {
                var ls = UsuariosDAL.getUserByLongName(User);

                if (ls == null)
                {
                    throw new ApplicationException("No se inicializó la lista de Usuarios.");
                }
                else
                {
                    return ls;
                }
            }

            catch (ApplicationException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }



            /// <summary>
            ///  Get All User by userName
            /// </summary>
            public static List<UsuariosEntity> getUserByName(UsuariosEntity User)
        {
            try 
            {
                var ls = UsuariosDAL.getUserByName(User);

                if(ls == null)
                {
                    throw new ApplicationException("No se inicializó la lista de Usuarios.");
                }
                else
                {
                    return ls;
                }
            }

            catch (ApplicationException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        ///  Get  User by Id
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static UsuariosEntity getUserInfId(UsuariosEntity user)
        {
            try
            {
                var r = UsuariosDAL.LoadUserInfid(user);
                if (r == null)
                {
                    throw new ApplicationException("No se inicializó la informaciones del Usuario.");
                }
                else
                {
                    return r;
                }
            }

            catch (ApplicationException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
