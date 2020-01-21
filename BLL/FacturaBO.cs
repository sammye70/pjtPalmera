using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using pjPalmera.Entities;
using pjPalmera.DAL;

namespace pjPalmera.BLL
{
    public class FacturaBO
    {
        /// <summary>
        /// Save Head invoice
        /// </summary>
        /// <param name="venta"></param>
        public static void Create(VentaEntity venta)
        {
            try
            {
                FacturasDAL.Create(venta);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        /// <summary>
        /// Save Detail invoice
        /// </summary>
        /// <param name="detail"></param>
        public static void Create_detail(VentaEntity detail)
        {
            try
            {
                FacturasDAL.Created_Detail(detail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

    }
}
