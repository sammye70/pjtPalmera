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
        public static void CreateOpenBox(AperturaCajaEntity Ocaja)
        {
            try
            {
                AperturaCajaDAL.CreateOpenBox(Ocaja);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema");
                return;
            }
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
