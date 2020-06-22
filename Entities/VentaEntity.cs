using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;


namespace pjPalmera.Entities

{
    public class VentaEntity
    {
        /// <summary>
        /// Author: Samuel Estrella
        /// created: 22/12/2019
        /// Modificated by:  
        /// Title: Invoice Header y Detail
        /// </summary>

        //Fields and Properties
        public int id { get; set; }
        public string clientes { get; set; }
        public string apellidos { get; set; }
        public DateTime fecha { get; set; }
        public string vendedor { get; set; }
        public int ncf { get; set; }
        public string tipo { get; set; } 
        public int status { get; set; }
        public decimal total { get; set; }
        public decimal descuento { get; set; }
        public decimal subtotal { get; set; }
        public int id_cliente { get; set; }
        public decimal total_itbis { get; set; }
        public decimal recibido { get; set; }
        public decimal devuelta { get; set; }
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
        /// Add Items to list<DetalleVentaEntity>
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
            listProductos.Sort();
           
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
        /// Return Itbis value
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
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal Descuento( decimal subtotal)
        {
            decimal t_descuento = 0, descuento = 10;
            t_descuento = (descuento * subtotal) / 100;
            return t_descuento;
        }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="recibido"></param>
        /// <param name="cobrar"></param>
        /// <returns></returns>
        public decimal Cambio_Compras( decimal recibido, decimal cobrar)
        {
            decimal cambio;
            cambio = recibido - cobrar;
            return cambio;
        }

    }
}
