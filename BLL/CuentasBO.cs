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
    public class CuentasBO
    {

        /// <summary>
        /// Get Amount Credit by Client
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static decimal Amount(Int64 id)
        {
            try
            {
                return CuentasDAL.Amount(id);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
        }


        /// <summary>
        /// Get Account by id_Client
        /// </summary>
        /// <param name="id_cliente"></param>
        /// <returns></returns>
        public static List<CuentaEntity> GetInvoicesCr(int id)
        {
            try
            {
                return CuentasDAL.GetInvoicesCr(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        /// <summary>
        /// Get All Credit Account Pendding
        /// </summary>
        /// <returns></returns>
        public static List<ClientesEntity> GetAllAccount(int cuenta)
        {
            try
            {
                return CuentasDAL.GetAllAccount(cuenta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Set Status Credit Value on Costumers
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static ClientesEntity StatusCxc(int status, long id)
        {
            try
            {
                return CuentasDAL.StatusCxc(status, id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema");
                return null;
            }
        }
    }
}
