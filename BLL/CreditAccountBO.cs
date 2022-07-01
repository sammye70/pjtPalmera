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
        ///  Get credit account amount for customer from CreditAccount 
        /// </summary>
        /// <returns></returns>
        public static decimal GetAmount(long crAccount)
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

        /// <summary>
        /// Get Amount Credit by Client from ventas
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static decimal AmountSells(Int64 id)
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
        /// Get Credit Account by customer id
        /// </summary>
        /// <param name="id_cliente"></param>
        /// <returns></returns>
        public static List<CuentaEntity> GetCrAcCustomerById(long id)
        {

            try
            {
                var ls = CreditAccountDAL.GetCrAcCustomerById(id);

                if (ls != null)
                {
                    return ls;
                }
                else 
                {
                    throw new ApplicationException("Uff, algo salio mal cuando intento cargar las cuentas a crédito");
                }
            }
            catch (ApplicationException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }




        /// <summary>
        ///  Get History Pay Credit Account by customer id Except Amount
        /// </summary>
        /// <param name="id_cliente"></param>
        /// <returns></returns>
        public static List<CuentaEntity> GetPayCrAcCustomerById(long id)
        {

            try
            {
                var ls = CreditAccountDAL.GetPayCrAcCustomerById(id);

                if (ls != null)
                {
                    return ls;
                }
                else
                {
                    throw new ApplicationException("Uff, algo salio mal cuando intento cargar las cuentas a crédito");
                }
            }
            catch (ApplicationException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }


        /// <summary>
        /// Get History Pay Credit Account by customer id with some exceptions
        /// </summary>
        /// <param name="id_cliente"></param>
        /// <returns></returns>
        public static List<CuentaEntity> GetPayCrAcCustomerByIdEx(long id)
        { 
            try
            {
                var ls = CreditAccountDAL.GetPayCrAcCustomerByIdEx(id);

                if (ls != null)
                {
                    return ls;
                }
                else
                {
                    throw new ApplicationException("Uff, algo salio mal cuando intento cargar las cuentas a crédito");
                }
            }
            catch (ApplicationException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }



        /// <summary>
        /// Get Credit Account by customer id Card
        /// </summary>
        /// <param name="id_cliente"></param>
        /// <returns></returns>
        public static List<CuentaEntity> GetCrAcCustomerByIdCard(long id)
        {
            try
            {
                var ls = CreditAccountDAL.GetCrAcCustomerByIdCard(id);

                if (ls != null)
                {
                    return ls;
                }
                else
                {
                    throw new ApplicationException("Uff, algo salio mal cuando intento cargar las cuentas a crédito");
                }
            }
            catch (ApplicationException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }


            /*-----------------------------------------------Process Create  Account sell credit invoices-----------------------------
             * 
             * Description: Create Credit Account when customer does not has one, and Update Credit Account amount if has one.
             * Created: 07/01/2021
             * Author: Samuel Estrella
             * Modificated date: 
             * Modificated by: 
             * 
             * ----------------------------------------------------------------------------------------------------------------------*/
            /// <summary>
            ///  Create Credit Account when customer does not has one, and Update Credit Account amount if has one.
            /// </summary>
            /// <param name="crAccount"></param>
            /// <returns></returns>
            public static CreditAccountEntity CreateCrAccount(CreditAccountEntity crAccount)
        {
            try
            {
                // Verify if customer had transactions in the past
                var chkStAccount = CreditAccountDAL.ExistAccountCustomer(crAccount.id_cliente); 

                if(chkStAccount == 0)
                {
                    return CreditAccountDAL.CreateCrAccount(crAccount);
                }
                else
                {
                    var getCrAmountpast = CreditAccountDAL.GetAmount(crAccount.id_cliente);
                    crAccount.PastAmountcr = getCrAmountpast;
                    CreditAccountDAL.UpdateCrAccount(crAccount);
                    var getNewBalance = CreditAccountDAL.GetBalanceAfterCr(crAccount.id_cliente);
                    crAccount.NewAmountcr = getNewBalance;
                    return crAccount;
                   // throw new ApplicationException("Operación realizada satisfactoriamente!!");
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }



        /// <summary>
        ///  Create  Update  Account when customer to pay credit invoices  pendding
        /// </summary>
        /// <param name="crAccount"></param>
        /// <returns>Last Credit Amount after paid</returns>
        public static CreditAccountEntity UpdateCrAccountPay(CreditAccountEntity crAccount)
        {

            try
            {
                //var craccount = new CreditAccountEntity();

                if (crAccount == null)
                {
                    throw new ApplicationException("Cuenta no inicializada. Verificar y intentar nuevamente!!");
                }
                else
                {
                    var getCrAmountpast = CreditAccountDAL.GetAmount(crAccount.id_cliente);
                    crAccount.PastAmountcr = getCrAmountpast;
                    var pAccount = CreditAccountDAL.UpdateCrAccountPay(crAccount);
                    var getNewBalance = CreditAccountDAL.GetBalanceAfterCr(crAccount.id_cliente);
                    crAccount.NewAmountcr = getNewBalance;

                    if (pAccount.Result == 1)
                    {
                        // return crAccount;
                        if (getNewBalance <= 0)
                        {
                            crAccount.Concept = "Saldo del monto pendiente.";
                            crAccount.credit_type = 1;
                        }
                        else if (getNewBalance > 0)
                        {
                            crAccount.Concept = "Abono al monto pendiente.";
                            crAccount.credit_type = 2;
                        }

                        throw new ApplicationException("Operación realizada Satisfactoriamente!!");
                    }
                    else 
                    {
                        // return crAccount;
                        throw new Exception("Uff, algo no esta bien para continuar con la operación solicitada!!");
                    }
                }
            }
            catch (ApplicationException ax)
            {
                MessageBox.Show(ax.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return crAccount;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        /// <summary>
        ///  Save inside pay history
        /// </summary>
        /// <param name="crAccount"></param>
        /// <returns></returns>
        public static CreditAccountEntity SavePayHistory(CreditAccountEntity crAccount)
        {
            try
            {
                crAccount.IdAccount = CreditAccountDAL.GetcrAccountBasic(crAccount);
                crAccount = CreditAccountDAL.SavePayHistory(crAccount);

                if (crAccount.id == 0)
                {
                    throw new ApplicationException("Algo salio mal cuando se intento salvar en el historial de operaciones del cliente!!");
                }
                else
                {
                    return crAccount;
                }
            }
            catch (ApplicationException ax)
            {
                MessageBox.Show(ax.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        ///  Get Basic informations from CreditAccount
        /// </summary>
        public static CreditAccountEntity GetcrAccountBasic(CreditAccountEntity craccount)
        {
            try
            {
                craccount.IdAccount = CreditAccountDAL.GetcrAccountBasic(craccount);

                if (craccount.NewAmountcr == 0 || craccount.PastAmountcr == 0 || craccount.IdAccount == 0 )
                {
                    throw new ApplicationException("Algo salio mal cuando se intento recuperar la informaciones de la cuenta solicitada..!!");
                }
                else 
                {
                    return craccount; 
                }
            }

            catch (ApplicationException ax)
            {
                MessageBox.Show(ax.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }



        /// <summary>
        /// Get All Credit Account Pendding
        /// </summary>
        /// <returns></returns>
        public static List<CuentaEntity> GetAllAccount()
        {

            try
            {
                return CreditAccountDAL.GetAllAccount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            
        }

   }
}
