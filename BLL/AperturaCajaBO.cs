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
                    AperturaCajaDAL.CreateHistoryOpenBox(Ocaja);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema");
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
                AperturaCajaDAL.CreateOpenBox(oCaja);
            }
            catch (Exception ex)
            {
                // throw new Exception(ex.Message);
                MessageBox.Show(ex.Message, "Mensaje del Sistema");
                return;
            }
        }

        /// By: sammye70
        /// created: 10/02/2021
        /// Modificated by: sammye70
        /// Modificated Date:
        /// <summary>
        ///  Get Status Box (It will return 0 when is close and 1 if is open )
        /// </summary>
        /// <returns></returns>
        public static int GetStatusBox(AperturaCajaEntity oCaja)
        {
            var status = AperturaCajaDAL.GetStatusBox(oCaja);

            if (status == 0)
            {
                strMensajeBO = "";
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
