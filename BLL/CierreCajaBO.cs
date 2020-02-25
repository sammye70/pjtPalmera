using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using pjPalmera.Entities;
using pjPalmera.DAL;

namespace pjPalmera.BLL
{
    public class CierreCajaBO
    {
        /// <summary>
        /// Get Amount Total Invoices
        /// </summary>
        /// <returns></returns>
        public static decimal MontoVentas()
        {
            try
            {
                return CierreCajaDAL.MontoVentas();
            }
            catch //(Exception ex)
            {
              //  MessageBox.Show("No se Realizaron Ventas", "Mensaje del Sistema");
                return 0;
            }
        }

        /// <summary>
        /// Clean Transtactions Invoices
        /// </summary>
        public static void CleanTranstactions()
        {
            try
            {
                CierreCajaDAL.CleanTranstactions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema");
                return;
            }
        }

        /// <summary>
        /// Clean Open Box
        /// </summary>
        public static void CleanOpenBox()
        {
            CierreCajaDAL.CleanOpenBox();

        }
    }
}
