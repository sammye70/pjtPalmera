using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms; //
using pjPalmera.Entities;
using pjPalmera.DAL;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace pjPalmera.BLL
{
    public class FacturaBO
    {
        /// <summary>
        /// messeger about result after checked business rules
        /// </summary>
        public static string strMensajeBO; //


        /// <summary>
        /// Amount Total All Invoices where Active and type iqual to cash
        /// </summary>
        /// <returns></returns>
        public static decimal AmountAllInvoices()
        {
            try
            {
                return FacturasDAL.AmountAllInvoices();
            }
            catch (Exception)
            {
                strMensajeBO = "";
                MessageBox.Show("No Hay Monto que Mostrar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type_pay"></param>
        /// <param name="amount"></param>
        /// <param name="descount"></param>
        /// <returns></returns>
        public static decimal GetAmountPay(int type_pay, decimal amount, decimal descount)
        {
            return 0;
        }



        /// <summary>
        /// Get type pay
        /// </summary>
        /// <returns></returns>
        public static List<type_payEntity> GetType_Pays()
        {
            try
            {
                return FacturasDAL.GetType_Pays();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }


            /// <summary>
            /// Amount Total All Invoices where Active and type iqual Credit
            /// </summary>
            /// <returns></returns>
            public static decimal AmountAllInvoicesCr()
        {
            try
            {
                return FacturasDAL.AmountAllInvoicesCr();
            }
            catch (Exception)
            {
                strMensajeBO = "No Hay Monto que Mostrar";
                MessageBox.Show("No Hay Monto que Mostrar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }

        }


        /// <summary>
        /// Get All Invoices (Cash and Credit)
        /// </summary>
        /// <returns></returns>
        public static List<VentaEntity> GetAll()
        {
            try
            {
                return FacturasDAL.GetAll();
            }
            catch 
            {
               // strMensajeBO = ex.Message;
              //  MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        /// <summary>
        /// Search Invoices by Number and type equial to Cash only
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
                strMensajeBO = ex.Message;
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        /// <summary>
        /// Search Invoices by Date (cash and credit)
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
                strMensajeBO = ex.Message;
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

        }

        /// <summary>
        /// Get All Credit Invoices only
        /// </summary>
        /// <returns></returns>
        public static List<VentaEntity> GetCreditInvoices()
        {
            try
            {
                return FacturasDAL.GetCreditInvoices();
            }
            catch (Exception ex)
            {
                strMensajeBO = ex.Message;
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }



        /// <summary>
        /// Get All Cash Invoices
        /// </summary>
        public static List<VentaEntity> GetCashInvoices()
        {
            try
            {
                return FacturasDAL.GetCashInvoices();
            }
            catch 
            {
               // strMensajeBO = ex.Message;
               // MessageBox.Show(ex.StackTrace, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }


        /// <summary>
        /// Search Invoices by Number and type equial to credit
        /// </summary>
        /// <returns></returns>
        public static List<VentaEntity> SearhByNumberCr(Int64 number)
        {

            try
            {
                return FacturasDAL.SearhByNumberCr(number);
            }
            catch (Exception ex)
            {
                strMensajeBO = ex.Message;
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        /// <summary>
        /// Change to Status Enable current Invoice
        /// </summary>
        public static void EnableInvoice(VentaEntity invoice)
        {
            try
            {
                FacturasDAL.EnableInvoice(invoice);
            }
            catch (Exception ex)
            {
                strMensajeBO = ex.Message;
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }


        /// <summary>
        /// Get All Invoices Desable only Head by this.
        /// </summary>
        /// <returns></returns>
        public static List<VentaEntity> Get_All_Invoice_Desable()
        {
            try
            {
                return FacturasDAL.Get_Invoice_Desable();
            }
            catch (Exception ex)
            {
                strMensajeBO = ex.Message;
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        //-----------------------------------------------Process Desable Invoices--------------------------------------
        // Created: 02/07/2020
        // Author: Samuel Estrella
        // Modificated date:
        // Modificated by:
        //-------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Verificaty Invoices if Exits or not (Only enable invoices, and temporal)
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool ExitsInvoice(int number)
        {
            var MensajeDAL = FacturasDAL.ExitsInvoiceAct(number);

            if (MensajeDAL == true)
            {
                strMensajeBO = "Se encontro la Factura";
                return true;
            }
            else if (MensajeDAL == false)
            {
                strMensajeBO = "No Existe la Factura o la misma fue anulada, Verificar e Internar Nuevamente";
                return MensajeDAL = false;
            }
            return MensajeDAL;
        }

        /// <summary>
        /// Verificaty Invoices if Exits or not (Permanent invoices)
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool ExitsInvoiceDes(int number)
        {
            var MensajeDAL = FacturasDAL.ExitsInvoiceDes(number);

            if (MensajeDAL == true)
            {
                strMensajeBO = "Se encontro la Factura";
                return true;
            }
            else if (MensajeDAL == false)
            {
                strMensajeBO = "No Existe la Factura o la misma fue anulada, Verificar e Internar Nuevamente";
                return MensajeDAL = false;
            }
            return MensajeDAL;
        }


        /// <summary>
        /// Get Head Invoice by Id use to desable current invoice
        /// </summary>
        /// <param name="invoice_id"></param>
        /// <returns></returns>
        public static VentaEntity Get_Head_Invoice_ById(int invoice_id)
        {

            try
            {
                return FacturasDAL.Get_Head_Invoice_ById(invoice_id);
            }
            catch (Exception)
            {

                throw;
            }
        
        
        }

        /// <summary>
        /// Get Detail Invoice for desable this.
        /// </summary>
        /// <param name="invoice_id"></param>
        /// <returns></returns>
        public static List<DetalleVentaEntity> GetDetail_byInvoiceId(int invoice_id)
        {
            try
            {
                return FacturasDAL.Get_Detail_by_InvoiceId(invoice_id);
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Change to Status Desable current Invoice
        /// </summary>
        public static void DesableInvoices(VentaEntity invoice)
        {
            try
            {
                FacturasDAL.DesableInvoice(invoice);
            }
            catch (Exception ex)
            {
                strMensajeBO = ex.Message;
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }


        /// <summary>
        /// Delete Detail Item by id invoice After Disabled Invoice
        /// </summary>
        /// <param name="invoice"></param>
        public static void DeleteDetailByIdInvoice(VentaEntity invoice)
        {
            try
            {
                FacturasDAL.DeleteDetailByIdInvoice(invoice);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //------------------------------------------ Until Here Process Desable Invoices------------------------------------------



        /// <summary>
        /// Get All Product in Invoices (short description)
        /// </summary>
        /// <returns></returns>
        public static List<ProductosVendidosEntity> GetAllProducInvoices()
        {
            try
            {
                return FacturasDAL.AllProducInvoices();
            }
            catch (Exception ex)
            {
                strMensajeBO = ex.Message;
                MessageBox.Show("Error " + ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }


        /// <summary>
        /// Filter Detail Invoice by Id Invoice (Long Description)
        /// </summary>
        /// <returns></returns>
        public static List<DetalleVentaEntity> GetDetailInvoices(int idventa)
        {
            try
            {
                return FacturasDAL.Get_Detail_Invoices(idventa);
            }
            catch (Exception ex)
            {
                strMensajeBO = ex.Message;
                MessageBox.Show("Error " + ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }


        /// <summary>
        /// Get All Detail Invoice (cash) Long Description
        /// </summary>
        /// <returns></returns>
        public static List<DetalleVentaEntity> GetAllDetailInvoices()
        {
            try
            {
                return FacturasDAL.Get_All_Detail_Invoices();
            }
            catch (Exception ex)
            {
                strMensajeBO = ex.Message;
              //  MessageBox.Show("Error " + ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }


        //-----------------------------------------------Process Create New Invoices--------------------------------------
        // Created: 02/07/2020
        // Author: Samuel Estrella
        // Modificated date:
        // Modificated by:
        //----------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Process Insert Invoice Head and Detail (New)
        /// </summary>
        /// <param name="Venta"></param>
        public static void CreateInvoice(VentaEntity Venta)
        {
            try
            {
                FacturasDAL.Create(Venta);
                strMensajeBO = "";
            }
            catch (Exception ex)
            {
                strMensajeBO = ex.Message;
                return;
            }
        }


        //------------------------------------------ Until Here Process Create New Invoices---------------------------------



        /***********************************************************************************************************
        // Name: Register Daily Transactions 
        // Created: 09/07/2020
        // Author: Samuel Estrella
        // Modificated date: 09/07/2020
        // Modificated by: Samuel Estrella
        //*********************************************************************************************************/


        /// <summary>
        /// Create Daily Transactions Temporaly and Permanent
        /// </summary>
        /// <param name="invoice"></param>
        public static void CreateTranst(VentaEntity invoice)
        {
            try
            {
                FacturasDAL.CreateTranstPermant(invoice);
            }
            catch (InvalidOperationException ex)
            {
                ex.GetType();
                return;

            }
        }

        /// <summary>
        /// Update Daily Transactions Permanenet and Temporal
        /// </summary>
        /// <param name="invoice"></param>
        public static void UpdateTranst(VentaEntity invoice)
        {
            try
            {
                FacturasDAL.UpdateTranst(invoice);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //--------------------------------------------- Until Method Daily Transactions ------------------------------------------ 


        /// <summary>
        /// Delete Empty Rows and Detail Invoices
        /// </summary>
        public static void DeleteEmptyRow()
        {
            try
            {
                FacturasDAL.DeleteEmptyRow();
            }
            catch (Exception ex)
            {
                strMensajeBO = ex.Message;
                return;
            }
        }


    }
}
