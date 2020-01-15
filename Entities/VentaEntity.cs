using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private string clientes;
        private string apellidos { get; set; }
        private DateTime f_factura { get; set; }
        private string vendedor { get; set; }
        private int ncf { get; set; }
        private string tipo { get; set; } 
        private int status { get; set; }
        //private int _nif;
        //private string _descripcion;
        //private decimal _p_venta;
        //private float _cantidad;
        private List<DetalleVentaEntity> productos;
       // public decimal precio = 0;
        public Int64 id;
        public float cantidad;
        /// <summary>
        /// 
        /// </summary>
        public List<DetalleVentaEntity> Productos
        {
            get
            {
                return productos;
            }
        }


        /// <summary>
        /// Constructor VentaEntity
        /// </summary>
        /// <param name="clientes"></param>
        /// <param name="apellidos"></param>
        public VentaEntity (string clientes, string apellidos )
        {
          //  this.ncf = ncf;
            this.Clientes = clientes;
            this.apellidos = apellidos;
            this.f_factura = DateTime.Now.Date;
            //this.vendedor = vendedor;

            this.productos = new List<DetalleVentaEntity>();
        }

        public VentaEntity()
        {
        }


        public string Clientes
        {
            get { return clientes; } set { clientes = value; }
        }


        /// <summary>
        /// Add Items to list<DetalleVentaEntity>
        /// </summary>
        /// <param name="producto"></param>
        public void addProduct(DetalleVentaEntity producto)
        {
            Productos.Add(producto);
        }

        //
        public void RemoveItem(DetalleVentaEntity producto)
        {

            Productos.RemoveAt(1);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal SubTotal()
        {
            decimal total = 0;
            foreach (DetalleVentaEntity producto in Productos)
            {
                total += producto.IMPORTE;
            }
            return total;
        }


        /// <summary>
        /// 
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
        public decimal Descuento()
        {
            decimal t_descuento = 0, descuento = 10;
            t_descuento = (descuento * SubTotal()) / 100;
            return t_descuento;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itbis"></param>
        /// <param name="subtotal"></param>
        /// <returns></returns>
        public decimal Pagar(decimal itbis, decimal subtotal)
        {
            decimal t_pagar, t_pagar_c_descuento;
            t_pagar = itbis + subtotal;
            t_pagar_c_descuento = t_pagar - Descuento();
            return t_pagar_c_descuento;
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
