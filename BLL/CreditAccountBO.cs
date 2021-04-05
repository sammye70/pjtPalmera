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
   public  class CreditAccountBO
    {

        /// <summary>
        ///  Get credit account amount for customer
        /// </summary>
        /// <returns></returns>
        public static decimal GetAmount(int crAccount)
        {
            try
            {
                return CreditAccountDAL.GetAmount(crAccount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }



        /*-----------------------------------------------Process Create  Account sell credit invoices-----------------------------
         * Created: 07/01/2021
         * Author: Samuel Estrella
         * Modificated date: 
         * Modificated by: 
         * ----------------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        ///  Create  Account when customer sell credit invoices
        /// </summary>
        /// <param name="crAccount"></param>
        /// <returns></returns>
        public static CreditAccountEntity CreateCrAccount(CreditAccountEntity crAccount)
        {

            try
            {
                return CreditAccountDAL.CreateCrAccount(crAccount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
