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
        public static decimal GetAmount(long customerid)
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
                    cmd.Parameters.Add("@pamount", MySqlDbType.Decimal);
                    cmd.Parameters["@pamount"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    crAmount = (decimal)cmd.Parameters["@pamount"].Value;
                }
            }

            return crAmount;
        }



        /* ************************************************************************************************************************ *
         * Description: Create  Account when customer shop credit invoices                                                          *
         * Created: 07/01/2021                                                                                                      *
         * Author: Samuel Estrella                                                                                                  *
         * Modificated date:                                                                                                        *
         * Modificated by:                                                                                                          *
         * ***********************************************************************************************************************  */

        /// <summary>
        ///  Create  Account when customer shop credit invoices and does't has one
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

                    cmd.Parameters.AddWithValue("@pid_customer", crAccount.id_cliente);
                    // cmd.Parameters.AddWithValue("pid_invoice", crAccount.id);
                    // cmd.Parameters.AddWithValue("pinvoice_amount", crAccount.InvoiceAmount);
                    cmd.Parameters.AddWithValue("@pcurrent_amount", crAccount.InvoiceAmount);
                    // cmd.Parameters.AddWithValue("pcurrent_amount", crAccount.CurrentAmount);
                    cmd.Parameters.AddWithValue("@ppast_amount", 0);
                    cmd.Parameters.AddWithValue("@pcreated", DateTime.Now);
                    cmd.Parameters.AddWithValue("@pcreatedby", crAccount.id_user);

                    cmd.ExecuteNonQuery();
                }
            }

            return crAccount;
        }


        /* ********************************************************************************************************************** *
        * Description: Update  Account when customer to
        * shop credit invoices                                                        *
        * Created: 07/01/2021                                                                                                    *
        * Author: Samuel Estrella                                                                                                *
        * Modificated date:                                                                                                      *
        * Modificated by:                                                                                                        *
        * ********************************************************************************************************************** */

        /// <summary>
        ///  Create  Update  Account when customer shop to credit invoices  
        /// </summary>
        /// <param name="crAccount"></param>
        /// <returns></returns>
        public static CreditAccountEntity UpdateCrAccount(CreditAccountEntity crAccount)
        {
            //var crAccount = new CreditAccountEntity();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spUpdateCrAccountCustomer", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pid_customer", crAccount.id_cliente);
                    // cmd.Parameters.AddWithValue("pid_invoice", crAccount.id);
                    // cmd.Parameters.AddWithValue("pinvoice_amount", crAccount.InvoiceAmount);
                    cmd.Parameters.AddWithValue("@pcurrent_amount", crAccount.InvoiceAmount);
                    // cmd.Parameters.AddWithValue("pcurrent_amount", crAccount.CurrentAmount);
                    cmd.Parameters.AddWithValue("@ppast_amount", crAccount.PastAmountcr);
                    cmd.Parameters.AddWithValue("@pmodificated", DateTime.Now);
                    cmd.Parameters.AddWithValue("@pmodificatedby", crAccount.id_user);

                    cmd.ExecuteNonQuery();

                }
            }

            return crAccount;
        }




        /* ***********************************************************************************************************************
        * Description: Update  Account when customert to pay credit invoices                                                     *
        * Created: 07/09/2021                                                                                                    *
        * Author: Samuel Estrella                                                                                                *
        * Modificated date:                                                                                                      *
        * Modificated by:                                                                                                        *
        * ********************************************************************************************************************** */

        /// <summary>
        ///  Create  Update  Account when customer to pay credit invoices  
        /// </summary>
        /// <param name="crAccount"></param>
        /// <returns></returns>
        public static CreditAccountEntity UpdateCrAccountPay(CreditAccountEntity crAccount)
        {
            //var crAccount = new CreditAccountEntity();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spUpdateCrAccountCustomerPay", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pid_customer", crAccount.id_cliente);
                    // cmd.Parameters.AddWithValue("pid_invoice", crAccount.id);
                    // cmd.Parameters.AddWithValue("pinvoice_amount", crAccount.InvoiceAmount);
                    cmd.Parameters.AddWithValue("@ppay_amount", crAccount.PayValue);
                    // cmd.Parameters.AddWithValue("@pcurrent_amount", crAccount.InvoiceAmount);
                    // cmd.Parameters.AddWithValue("pcurrent_amount", crAccount.CurrentAmount);
                    cmd.Parameters.AddWithValue("@ppast_amount", crAccount.PastAmountcr);
                    cmd.Parameters.AddWithValue("@pmodificated", DateTime.Now);
                    cmd.Parameters.AddWithValue("@pmodificatedby", crAccount.id_user);

                    crAccount.Result = cmd.ExecuteNonQuery();

                }
            }

            return crAccount;
        }


        /// <summary>
        ///  Save inside pay history
        /// </summary>
        /// <param name="crAccount"></param>
        /// <returns></returns>
        public static CreditAccountEntity SavePayHistory(CreditAccountEntity crAccount)
        {
            //var crAccount = new CreditAccountEntity();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spPayCrAccountCustomer", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pid_customer", crAccount.id_cliente);
                    // cmd.Parameters.AddWithValue("pid_invoice", crAccount.id);
                     cmd.Parameters.AddWithValue("@pid_account", crAccount.IdAccount);
                    cmd.Parameters.AddWithValue("@ppay", crAccount.PayValue);
                    // cmd.Parameters.AddWithValue("@pcurrent_amount", crAccount.InvoiceAmount);
                    cmd.Parameters.AddWithValue("@pamount_pendding", crAccount.NewAmountcr); // current
                    // cmd.Parameters.AddWithValue("@ppast_amount", crAccount.PastAmountcr);
                    cmd.Parameters.AddWithValue("@pcreated", DateTime.Now);
                    cmd.Parameters.AddWithValue("@pcreatedby", crAccount.id_user);

                    crAccount.id = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }

            return crAccount;
        }



        /// <summary>
        /// Get New balances from Account Credit Manager
        /// </summary>
        /// <param name="crAccount"></param>
        /// <returns></returns>
        public static decimal GetBalanceAfterCr(int idcustomer)
        {
            decimal crAccountAmount;
            // var crAccountAmount = new CreditAccountEntity();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spGetNewbalance", con))
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pidcustomer", idcustomer);
                    cmd.Parameters.Add("@pnewbalance", MySqlDbType.Decimal);
                    // cmd.Parameters.Add("@ppasbalance", MySqlDbType.Decimal);

                    cmd.Parameters["@pnewbalance"].Direction = ParameterDirection.Output;
                    //  cmd.Parameters["@ppasbalance"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    crAccountAmount = (decimal) cmd.Parameters["@pnewbalance"].Value;
                    //  crAccountAmount.PastAmountcr = (decimal)cmd.Parameters["@ppasbalance"].Value;

                }
            }

            return crAccountAmount;
        }


        /// <summary>
        ///  Verify if exists customer credit account
        /// </summary>
        /// <returns></returns>
        public static int ExistAccountCustomer(int idcustomer)
        {
            int res = 0;

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spGetExistsAccount", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pidcustomer", idcustomer);
                    cmd.Parameters.Add("@presp", MySqlDbType.Int32);
                    cmd.Parameters["@presp"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    res = (int)cmd.Parameters["@presp"].Value;

                }

                return res;
            }

        }


        /// <summary>
        /// Get All Credit Account Pendding
        /// </summary>
        /// <returns></returns>
        public static List<CuentaEntity> GetAllAccount
        {
            get
            {
                var account = new List<CuentaEntity>();

                using (var con = new MySqlConnection(SettingDAL.connectionstring))
                {
                    MySqlCommand cmd = new MySqlCommand("spGetAllCrAccounts", con);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    // cmd.Parameters.AddWithValue("@cuenta", cuenta);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        account.Add(LoadCrInvoices(reader));
                    }
                }
                return account;
            }

        }

        /// <summary>
        /// Get Credit Account by customer id
        /// </summary>
        /// <param name="id_cliente"></param>
        /// <returns></returns>
        public static List<CuentaEntity> GetCrAcCustomerById(long id)
        {
            var crAccount = new List<CuentaEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {

                MySqlCommand cmd = new MySqlCommand("spGetCrAccountsById", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pidcustomers", id);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    crAccount.Add(LoadCrInvoices(reader));
                }
            }
            return crAccount;
        }


        /// <summary>
        /// Get History Pay Credit Account by customer id Except Amount
        /// </summary>
        /// <param name="id_cliente"></param>
        /// <returns></returns>
        public static List<CuentaEntity> GetPayCrAcCustomerById(long id)
        {
            var crAccount = new List<CuentaEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {

                MySqlCommand cmd = new MySqlCommand("spGetHistPayAccountByCedula", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pidcustomers", id);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    crAccount.Add(LoadPayCrInvoices(reader));
                }
            }
            return crAccount;
        }


        /// <summary>
        /// Get History Pay Credit Account by customer id with some exceptions
        /// </summary>
        /// <param name="id_cliente"></param>
        /// <returns></returns>
        public static List<CuentaEntity> GetPayCrAcCustomerByIdEx(long id)
        {
            var crAccount = new List<CuentaEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {

                MySqlCommand cmd = new MySqlCommand("spGetDetailAmountCurrentCr", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pidcustomers", id);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    crAccount.Add(LoadPayCrInvoicesEx(reader));
                }
            }
            return crAccount;
        }


        /// <summary>
        /// Get Credit Account by customer id Card
        /// </summary>
        /// <param name="id_cliente"></param>
        /// <returns></returns>
        public static List<CuentaEntity> GetCrAcCustomerByIdCard(long id)
        {
            var crAccount = new List<CuentaEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {

                MySqlCommand cmd = new MySqlCommand("spGetCrAccountByCedula", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pidcard", id);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    crAccount.Add(LoadCrInvoices(reader));
                }
            }
            return crAccount;
        }


        /// <summary>
        ///  Get Basic informations from CreditAccount
        /// </summary>
        public static Int64 GetcrAccountBasic(CreditAccountEntity craccount)
        {
            long idaccount=0;

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spGetCrAccountsById", con)) //-------> Create store procedure equal this, but add a filter inside new account Balances and other informations (DONE)
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pidcustomers", craccount.id_cliente);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        craccount = LoadCrAccount(reader);
                    }

                    idaccount = craccount.IdAccount;
                }
            }
            return idaccount;
            ;
        }


        /// <summary>
        ///  load customer has credit account
        /// </summary>
        /// <param name="Reader"></param>
        /// <returns></returns>
        private static CuentaEntity LoadCrInvoices(IDataReader Reader)
        {
            var account = new CuentaEntity();

            account.Cedula = (Reader["idcard"]).ToString();
            account.Id_cliente = Convert.ToInt64(Reader["idcustomer"]);
            account.Nombre = (Reader["nombre"]).ToString();
            account.Apellidos = (Reader["apellidos"]).ToString();
            account.Monto = Convert.ToDecimal(Reader["current_amount"]);
           
            return account;
        }


        /// <summary>
        ///  load customer has credit account history
        /// </summary>
        /// <param name="Reader"></param>
        /// <returns></returns>
        private static CuentaEntity LoadPayCrInvoices(IDataReader Reader)
        {
            var account = new CuentaEntity();

            account.Cedula = (Reader["idcard"]).ToString();
            account.Id_cliente = Convert.ToInt64(Reader["idcustomer"]);
            account.Nombre = (Reader["nombre"]).ToString();
            account.Apellidos = (Reader["apellidos"]).ToString();
            account.Monto = Convert.ToDecimal(Reader["amount_pendding"]);
            account.Pago = Convert.ToDecimal(Reader["pay"]);
            account.Ultimo_Pago = Convert.ToDateTime(Reader["lastpay"]);

            return account;
        }


        /// <summary>
        ///  load customer has credit account history with some excepts 
        /// </summary>
        /// <param name="Reader"></param>
        /// <returns></returns>
        private static CuentaEntity LoadPayCrInvoicesEx(IDataReader Reader)
        {
            var account = new CuentaEntity();

            account.Cedula = (Reader["idcard"]).ToString();
            account.Id_cliente = Convert.ToInt64(Reader["idcustomer"]);
            account.Nombre = (Reader["nombre"]).ToString();
            account.Apellidos = (Reader["apellidos"]).ToString();
            account.Monto = Convert.ToDecimal(Reader["current_amount"]);
           

            return account;
        }


        /// <summary>
        ///  load customer after pay or add some money to credit account
        /// </summary>
        /// <returns></returns>
        private static CreditAccountEntity LoadCrAccount(IDataReader Reader)
        {
            var craccount = new CreditAccountEntity();

            craccount.IdAccount = Convert.ToInt64(Reader["id_account"]);
            craccount.NewAmountcr = Convert.ToDecimal(Reader["current_amount"]);
            craccount.PastAmountcr = Convert.ToDecimal(Reader["past_amount"]);


           return craccount;
        }


    }
}
