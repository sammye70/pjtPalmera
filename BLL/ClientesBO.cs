using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using pjPalmera.Entities;
using pjPalmera.DAL;

namespace pjPalmera.BLL
{
    public class ClientesBO
    {
        /// <summary>
        /// Messeger to Result from CostumerBO
        /// </summary>
        public static string strMensajeBO;

        /// <summary>
        /// Save costumer
        /// </summary>
        /// <param name="costumer"></param>
        /// <returns></returns>
        public static void Save(ClientesEntity costumer)
        {
            try
            {
                ClientesDAL.Create(costumer);
                strMensajeBO = "Actualizado Satisfactoriamente.!!";
            }
            catch (Exception ex)
            {
                strMensajeBO = ex.Message;
                return;
            }
            finally
            {
                strMensajeBO = "Verificar la información suministrada e intentar nuevamente.";
            }
        }

        /// <summary>
        ///  Message about request create customer state
        /// </summary>
        /// <param name="costumer"></param>
        /// <returns>1 if</returns>
        public static bool ResultRequest(string cedula)
        {
            try
            {
                var status_request = ClientesDAL.ExitsCedula(cedula);

                if (status_request == true)
                {
                    strMensajeBO = "Cliente Registrado Satisfactoriamente!";
                    return true;
                }
                else if (status_request == false)
                {
                    strMensajeBO = "No se puedo procesar el Registro del Nuevo Cliente";
                    return false;
                }
                return status_request;
            }
            catch (Exception ex)
            {
                strMensajeBO = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Update customer information        --------------------------------> this need to create any exceptions for throw error without app
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static void Update(ClientesEntity customer)
        {
            var id = customer.Id;
            var name = customer.Nombre;
            //var MessengerDAL = "";
            try
            {
                if ((id == 1) || (name == "contado") || (name == "CONTADO") || (name == "Contado"))
                {
                    strMensajeBO = "No es Posible Editar este Registro. Para cualquier asistencia contactar Soporte Técnico.";
                    //return null
                }
                else if (id != 1)
                {
                    strMensajeBO = "Se Editó Satisfactoriamente el Registro Indicado!!";
                    ClientesDAL.Update(customer);
                }
            }
            catch (AggregateException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        /// <summary>
        ///Delete Client by Id 
        /// </summary>
        /// <param name="id"></param>
        public static void Delete(long id)
        {
            try
            {
                if (id == 1)
                {
                    strMensajeBO = "No es posible eliminar este Registro. Para cualquier asistencia contactar Soporte Técnico.";
                    return;
                }
                else if (id != 1)
                {
                    ClientesDAL.Delete(id);
                    strMensajeBO = "Eliminó Satisfactoriamente el Registro Indicado!!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
        }

        /// <summary>
        ///Get all Costumers 
        /// </summary>
        /// <returns></returns>
        public static List<ClientesEntity> GetAll()
        {
            try
            {
                return ClientesDAL.All;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        /// <summary>
        /// Get Users by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static ClientesEntity GetbyId(long Id)
        {
            try
            {
                return ClientesDAL.GetbyId(Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        /// <summary>
        /// Get User by Id for Update Information
        /// </summary>
        /// <returns></returns>
        public static ClientesEntity GetbyCodeUpdate(long Id)
        {
            try
            {
                return ClientesDAL.GetbyCodeUpdate(Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        /// <summary>
        ///  Get Costumer by Lastname (List)
        /// </summary>
        /// <returns></returns>
        public static List<ClientesEntity> GetbyApellidos(string lastname)
        {
            try
            {
                return ClientesDAL.GetbyApellidos(lastname);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }

        /// <summary>
        ///  Get Costumer by Firstname (List)
        /// </summary>
        /// <returns></returns>
        public static List<ClientesEntity> GetbyNombre(string fistname)
        {
            try
            {
                var MessengerDAL = ClientesDAL.GetbyNombre(fistname);

                if (MessengerDAL != null)
                {
                    //strMensajeBO = "";
                    return ClientesDAL.GetbyNombre(fistname);
                }
                else
                {
                    strMensajeBO = "No se encontraron Nombres que concuerden con el/los indicados";
                    return ClientesDAL.GetbyNombre(fistname);
                }
            }
            catch (Exception ex)
            {
                strMensajeBO = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Filter Customer by cedula
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        public static List<ClientesEntity> GetbyCedula(string cedula)
        {
            try
            {
                return ClientesDAL.GetbyCedula(cedula);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        /// <summary>
        /// Check if exits customer cedula
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        public static bool ExitsCedula(string cedula)
        {

            try
            {
                var messengerDAL = ClientesDAL.ExitsCedula(cedula);

                if (messengerDAL == true)
                {
                    return true;
                    throw new AggregateException("Se encontro un registro asociado con este número de Cédula.");

                    //strMensajeBO = ";
                }
                else if (messengerDAL == false)
                {
                    return false;
                    throw new ApplicationException("No se encuentra registrado asociado a este número Cédula indicada. \n En cualquier caso verficar e intentar nuevamente.");

                    // strMensajeBO = ;
                }

                return messengerDAL;

            }

            catch (AggregateException age)
            {
                strMensajeBO = age.Message;
                return true;
            }

            catch (ApplicationException ape)
            {
                strMensajeBO = ape.Message;
                return false;
            }

            catch (Exception gex)
            {
                strMensajeBO = gex.Message;
                return false;
            }

        }


        /// <summary>
        /// Filter Customer by Cedula 
        /// </summary>
        /// <returns></returns>
        public static List<ClientesEntity> GetCustomerByCedula(string cedula)
        {
            try
            {
                return ClientesDAL.GetCustomerByCedula(cedula);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        /// <summary>
        /// Check if Exits Customer Code
        /// </summary>
        /// <returns></returns>
        public static bool ExitsCode(string code)
        {
            var messengerDAL = ClientesDAL.ExitsCode(code);

            if (messengerDAL == true)
            {
                strMensajeBO = "Se encontro el Código";
                return true;
            }
            else if (messengerDAL == false)
            {
                strMensajeBO = "No se encontro el Código indicado, verificar e intentar nuevamente";
                return false;
            }

            return messengerDAL;


        }

    }

}