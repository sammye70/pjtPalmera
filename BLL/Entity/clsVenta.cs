
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entity;


namespace BLL.Entity

{

    public class clsVenta
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
        private List<clsDetalleVenta> _productos;

        /// <summary>
        /// 
        /// </summary>
        public List<clsDetalleVenta> Productos
        {
            get
            {
                return _productos;
            }
        }


        //Constructor
        public clsVenta(string clientes)
        {
            this._clientes = clientes;
            this._f_factura = DateTime.Now;
            this._productos = new List<clsDetalleVenta>();
        }

        //Method
        public void addProduct(clsDetalleVenta producto)
        {
            Productos.Add(producto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal Total()
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
            c_itbis = (itbis * Total()) / 100;
            t_itbis = Total() - c_itbis;
            return t_itbis;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal Descuento()
        {
            decimal t_decuento = 0, descuento = 10;
            t_decuento = (descuento * Total()) / 100;
            return t_decuento;
        }

    }
}
