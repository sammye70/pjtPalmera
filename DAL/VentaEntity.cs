using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace pjPalmera.Entities

{
    public class VentaEntity
    {
        //***********************************************************************************************
        //  Title: Invoice Header y Detail
        //  Author: Samuel Estrella
        //  created: 22/12/2019
        //  Modificated by:  07/07/2020
        //  Modificated by: Samuel Estrella
        //
        //***********************************************************************************************

        // Fields and Properties

        /// <summary>
        ///  Invoice id Properties
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Invoice Customer FirstName and LastNames
        /// </summary>
        public string clientes { get; set; }
        // public string apellidos { get; set; }
        /// <summary>
        ///  Invoice Date
        /// </summary>
        public DateTime fecha { get; set; }
        public string vendedor { get; set; }
        public int ncf { get; set; }
        public string tipo { get; set; }
        public int status { get; set; }
        public decimal total { get; set; }
        public decimal descuento { get; set; }
        public decimal subtotal { get; set; }
        /// <summary>
        ///  Invoice customer id
        /// </summary>
        public int id_cliente { get; set; }
        public decimal total_itbis { get; set; }
        public decimal recibido { get; set; }
        public decimal devuelta { get; set; }
        public int id_caja { get; set; }
        public DateTime modificado { get; set;}
        public int id_user { get; set; }
        public int method_pago { get; set; }
        public string request_number { get; set; }
        public int credit_type { get; set; }
        private List<DetalleVentaEntity> item;


        //Contructors

        public VentaEntity()
        {
            this.item = new List<DetalleVentaEntity>();            //       <-------------- Check Parameter in this Constructor
        }


        /// <summary>
        /// Return Product from List
        /// </summary>
        public List<DetalleVentaEntity> listProductos
        {
            get
            {
                return item;
            }
        }

        #region MyRegion

        //public VentaEntity (string clientes, string apellidos )
        //{
        //  //  this.ncf = ncf;
        //    this.Nombre = clientes;
        //    this.Apellidos = apellidos;
        //    this.f_factura = DateTime.Now.Date;
        //    //this.vendedor = vendedor;

        //    this.productos = new List<DetalleVentaEntity>();
        //} 
        #endregion


        /// <summary>
        /// Add Items to DetalleVentaEntity
        /// </summary>
        /// <param name="producto"></param>
        public void addProduct(DetalleVentaEntity item)
        {
            listProductos.Add(item);
        }

        /// <summary>
        /// Remove Item from List
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItem(int item)
        {
            listProductos.RemoveAt(item);
            //listProductos.Sort();

        }


        /// <summary>
        /// Calculate amount for items
        /// </summary>
        /// <returns></returns>
        public decimal SubTotal()
        {
            decimal total = 0;
            foreach (DetalleVentaEntity item in listProductos)
            {
                total += item.IMPORTE;
            }
            return total;
        }

        /// <summary>
        /// Set Amount  in Specificate Product
        /// </summary>
        /// <param name="price"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public decimal ProductValue(decimal price, decimal cantidad)
        {
            decimal importe;

            importe = price * cantidad;
            return importe;
        }

        /// <summary>
        /// Return Tax applied to Total Amount
        /// </summary>
        /// <returns></returns>
        public decimal Itbis()
        {
            DetalleVentaEntity producto = new DetalleVentaEntity();
            decimal itbis = 18, t_itbis, c_itbis;
            c_itbis = (itbis * SubTotal()) / 100;
            t_itbis = SubTotal() - c_itbis;
            return t_itbis;
        }

        /// <summary>
        /// Discount in the invoice
        /// </summary>
        /// <returns></returns>
        public decimal Descuento(decimal subtotal)
        {
            decimal t_descuento = 0, descuento = 10;
            t_descuento = (descuento * subtotal) / 100;
            return t_descuento;
        }

        /// <summary>
        /// Total Amount after applied discount
        /// </summary>
        /// <param name="itbis"></param>
        /// <param name="subtotal"></param>
        /// <returns></returns>
        public decimal Pagar(decimal subtotal)
        {
            decimal pagar_c_descuento;
            //t_pagar = itbis + subtotal; // --------> Remove itbis for this time
            pagar_c_descuento = subtotal - Descuento(subtotal);
            return pagar_c_descuento;
        }

        /// <summary>
        ///  Total Amount not applied discount
        /// </summary>
        /// <returns></returns>
        public decimal PagarSinDescuento(decimal subtotal)
        {
            decimal pagar_c_descuento;
            //t_pagar = itbis + subtotal; // --------> Remove itbis for this time
            pagar_c_descuento = subtotal - Descuento(subtotal);
            return pagar_c_descuento;
        }

        /// <summary>
        /// Change Cash to costumer
        /// </summary>
        /// <param name="recibido"></param>
        /// <param name="cobrar"></param>
        /// <returns></returns>
        public decimal Cambio_Compras(decimal recibido, decimal cobrar)
        {
            decimal cambio;
            cambio = recibido - cobrar;
            return cambio;
        }

        /// <summary>
        /// Apply discount producto's price after submit
        /// </summary>
        /// <param name="price"></param>
        /// <param name="discount"></param>
        /// <returns>Average for discount</returns>
        public decimal SetDescountInvoice(decimal price, decimal descount)
        {
            decimal t_discount; //calculate discount
            decimal p_discount; //result after to apply discount

            t_discount = (price * descount) / 100;
            p_discount = price - t_discount;
            return p_discount;
        }

        /// <summary>
        ///  Set Invoice Type
        /// </summary>
        /// <param name="strTypeInv"></param>
        /// <returns>1 to cash and 2 credit</returns>
        public  string Set_Type_invoice(string strTypeInv)
        {
            if (strTypeInv == "cash")
            {
                return "1";
            }
            else if (strTypeInv == "credit") 
            {
                return "2";
            }
            return "";
        }
    }
}
