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

        //Atributes
        private string _clientes;
        private DateTime _f_factura;
        //private string _vendedor;
        //private int _ncf; 
        //private int _nif;
        //private string _descripcion;
        //private decimal _p_venta;
        //private float _cantidad;
        private List<clsDetalleVentaEntity> _productos;
        public decimal precio = 0;
        public Int64 id;
        public float cantidad;
        /// <summary>
        /// 
        /// </summary>
        public List<clsDetalleVentaEntity> Productos
        {
            get
            {
                return _productos;
            }
        }


        //Constructor
        public clsVentaEntity (string clientes)
        {
            this._clientes = clientes;
            this._f_factura = DateTime.Now;
            this._productos = new List<clsDetalleVentaEntity>();
        }

        //Method Add Items to list<>
        public void addProduct(clsDetalleVentaEntity producto)
        {
            Productos.Add(producto);
        }

        //
        public void RemoveItem(clsDetalleVentaEntity producto)
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
            foreach (clsDetalleVenta producto in Productos)
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
            clsDetalleVenta producto = new clsDetalleVenta();
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
