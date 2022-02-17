using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pjPalmera.Entities;
using pjPalmera.DAL;


namespace pjPalmera.BLL
{
    public class AperturaCajaBO
    {

        /// <summary>
        /// Messeger to Result from CostumerBO
        /// </summary>
        public static string strMensajeBO;

        /// <summary>
        /// Save History Detail About process Open Box
        /// </summary>
        /// <param name="Ocaja"></param>
        /// <returns></returns>
        public static void CreateHistoryOpenBox(AperturaCajaEntity Ocaja)
        {
            try
            {
                   var result =  AperturaCajaDAL.CreateHistoryOpenBox(Ocaja);

                if (result >= 1)
                {
                    throw new ApplicationException("Operación realizada satisfactoriamente.");
                }
                else
                {
                    throw new Exception("No fue posible realizar la operación indicada.");
                }
            }

            catch (ApplicationException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        /// <summary>
        /// Save process Open Box until Close Box
        /// </summary>
        /// <param name="Ocaja"></param>
        public static void CreateOpenBox(AperturaCajaEntity oCaja)
        {
            try
            {
                var result = AperturaCajaDAL.CreateOpenBox(oCaja);
                if (result >= 1 )
                {
                    throw new ApplicationException("Operación realizada satisfactoriamente.");
                }
                else
                {
                    throw new Exception("No fue posible realizar la operación indicada.");
                }
            }

            catch (ApplicationException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            catch (Exception ex)
            {
                // throw new Exception(ex.Message);
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// By: sammye70
        /// created: 10/02/2021
        /// Modificated by: sammye70
        /// Modificated Date:
        /// <summary>
        ///  Get Status Box (It will return 0 when was closed and 1 if it was opened )
        /// </summary>
        /// <returns></returns>
        public static int GetStatusBox(AperturaCajaEntity oCaja)
        {
            var status = AperturaCajaDAL.GetStatusBox(oCaja);

            if (status == 0)
            {
                strMensajeBO = "Debe Aperturar la Caja para iniciar las operaciones de venta";
                return status;
            }
            else if (status == 1)
            {
                strMensajeBO = "El Usuario tiene una Caja Aperturada. \n Primero debe cerrar la caja que fue aperturada por el usuario actual para continuar.";
                return status;
            }

            return status;
        }

        /// <summary>
        /// Get Current Amount used open box
        /// </summary>
        /// <returns></returns>
        public static decimal GetAmount()
        {
            try
            {
                return AperturaCajaDAL.GetAmount();
            }
            catch 
            {
               // MessageBox.Show("No se ha Abierto la Caja", "Mensaje del Sistema");
                return 0;
            }
        }
    }
}
