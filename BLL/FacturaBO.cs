﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms; //
using pjPalmera.Entities;
using pjPalmera.DAL;

namespace pjPalmera.BLL
{
    public class FacturaBO
    {
        public static bool MensajeBO; //
        public static string strMensajeBO; //

        /// <summary>
        /// Save Head invoice (Cash)
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
                strMensajeBO = ex.Message;
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }


        /// <summary>
        /// Save Head invoice (Credit)
        /// </summary>
        /// <param name="Venta"></param>
        public static void CreateCr(VentaEntity Venta)
        {
            try
            {
                FacturasDAL.CreateCr(Venta);
            }
            catch (Exception ex)
            {
                strMensajeBO = ex.Message;
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }


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
                strMensajeBO = ex.Message;
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                strMensajeBO = ex.Message;
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        /// <summary>
        /// Search Invoices by Number and type equial to Cash
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
                strMensajeBO = ex.Message;
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

        }

        /// <summary>
        ///  Search Last Invoice Id
        /// </summary>
        /// <returns></returns>
        public static int LastId()
        {
            try
            {
                return FacturasDAL.LastId();
            }
            catch (Exception ex)
            {
                strMensajeBO = ex.Message;
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
        }

        /// <summary>
        /// Get All Credit Invoices
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
            catch (Exception ex)
            {
                strMensajeBO = ex.Message;
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// Get All Invoices Desable
        /// </summary>
        /// <returns></returns>
        public static List<VentaEntity> GetInvoiceDesable()
        {
            try
            {
                return FacturasDAL.GetInvoiceDesable();
            }
            catch (Exception ex)
            {
                strMensajeBO = ex.Message;
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }


        /// <summary>
        /// Verificaty Invoices if Exits or not
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool ExitsInvoice(Int64 number)
        {
            var MensajeDA = FacturasDAL.result;
               

                if ( MensajeDA == true)
                {
                    return MensajeBO = true;
                }
                else if (MensajeDA == false)
                {
                    return MensajeBO = true;
                }
                return MensajeBO;
        }

        /// <summary>
        /// Get All Product in Invoices
        /// </summary>
        /// <returns></returns>
        public static List<ProductosVendidosEntity> GetAllProducInvoices()
        {
            try
            {
                return FacturasDAL.GetAllProducInvoices();
            }
            catch (Exception ex)
            {
                strMensajeBO = ex.Message;
                MessageBox.Show("Error "+ ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                return FacturasDAL.GetDetailInvoices(idventa);
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
                return FacturasDAL.GetAllDetailInvoices();
            }
            catch (Exception ex)
            {
                strMensajeBO = ex.Message;
              //  MessageBox.Show("Error " + ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }


        /// <summary>
        /// Process Insert  Invoice Head and Detail (New)
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
