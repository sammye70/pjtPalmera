
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
        private string _vendedor;
        private int _ncf; 
        private int _nif;
        //private string _descripcion;
        private decimal _p_venta;
        private float _cantidad;
        private List<clsProducto> _productos;

        public List<clsProducto> Productos
        {
            get
            {
                return _productos;
            }
        }


        //Constructor
        public clsVenta(string clientes )
        {
            this._clientes = clientes;
            this._f_factura = DateTime.Now;
            this._productos = new List<clsProducto>();
        }

        //Method
        public void addProduct(clsProducto producto)
        {
            Productos.Add(producto);
        }

        public decimal Total()
        {
            decimal total = 0;
            foreach (clsProducto producto in Productos)
            {
                total += producto.Valor;
            }
            return total;
        }

        public decimal Itbis()
        {
            clsProducto producto = new clsProducto();
            decimal itbis = 18, t_itbis;
            t_itbis = (itbis*producto.Valor)/100;
            return t_itbis;
        }
    }
}
