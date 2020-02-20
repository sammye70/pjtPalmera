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
             //   MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
              //  MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        /// <summary>
        /// Get All Invoices
        /// </summary>
        /// <returns></returns>
        public static List<VentaEntity> GetAll()
        {
            try
            {
                return FacturasDAL.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        /// <summary>
        /// Search Invoices by Number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static List<VentaEntity> SearhByNumber(Int64 number)
        {
            try
            {
                return FacturasDAL.SearhByNumber(number);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        /// <summary>
        /// Search Invoices by Date
        /// </summary>
        /// <param name="DateBegin"></param>
        /// <param name="DateUntil"></param>
        /// <returns></returns>
        public static List<VentaEntity> SearhByDate(string DateBegin, string DateUntil)
        {
            try
            {
                return FacturasDAL.SearhByDate(DateBegin, DateUntil);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

        }

    }
}
