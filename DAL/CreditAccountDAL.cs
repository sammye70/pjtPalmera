using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pjPalmera.Entities;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace pjPalmera.DAL
{
    public class CreditAccountDAL
    {
        /// <summary>
        ///  Get credit account amount for customer
        /// </summary>
        /// <returns></returns>
        public static decimal GetAmount(int customerid)
        {
            // var crAmount = new CreditAccountEntity();
             decimal crAmount = 0;

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spGetAmountCurrentCr", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pidcustomer", customerid);

                    crAmount = Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }

            return crAmount;
        }



        /* ********************************************************************************************************************** *
         * Description: Create  Account when customer sell credit invoices                                                        *
         * Created: 07/01/2021                                                                                                    *
         * Author: Samuel Estrella                                                                                                *
         * Modificated date:                                                                                                      *
         * Modificated by:                                                                                                        *
         * ********************************************************************************************************************** */

        /// <summary>
        ///  Create  Account when customer sell credit invoices
        /// </summary>
        /// <param name="crAccount"></param>
        /// <returns></returns>
        public static CreditAccountEntity CreateCrAccount(CreditAccountEntity crAccount)
        {
            //var crAccount = new CreditAccountEntity();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spCreateCrAccountCustomer", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("pid_customer", crAccount.id_cliente);
                    cmd.Parameters.AddWithValue("pid_invoice", crAccount.id);
                    cmd.Parameters.AddWithValue("pinvoice_amount", crAccount.InvoiceAmount);
                    cmd.Parameters.AddWithValue("pcurrent_amount", crAccount.CurrentAmount);
                    cmd.Parameters.AddWithValue("ppast_amount", 0.00);
                    cmd.Parameters.AddWithValue("pcreated", DateTime.Now);
                    cmd.Parameters.AddWithValue("pcreatedby", crAccount.id_vendedor);

                    cmd.ExecuteNonQuery();
                }
            }

            return crAccount;
        }

    }
}
