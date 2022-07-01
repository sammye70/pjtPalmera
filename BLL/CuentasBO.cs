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
        // Would to be removed --------------------
        /// <summary>
        /// Get Amount Credit by Client from ventas
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
