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

        //Fields
        private int id;
        private int id_cliente;
        private string nombre;
        private string apellidos;
        private DateTime f_factura;
        private decimal total;
        private decimal subtotal;
        private int status;
        private string vendedor;
        private int ncf;
        private int tipo;
        private decimal descuento;
        private decimal t_itbis;
        private List<DetalleVentaEntity> _productos;
      
     

        //Constructor
        public VentaEntity()
        {
        }

        public VentaEntity (int id_cliente, string nombre, string  apellidos, decimal total, DateTime f_factura, int ncf, int status, decimal descuento, decimal subtotal,
            decimal t_itbis)
        {
            this.Id_cliente = id_cliente;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Total = total;
            this.Fecha = f_factura;
            this.Ncf = ncf;
            this.Status = status;
            this.Descuento = descuento;
            this.Subtotal = subtotal;
            this.Total_itbis = t_itbis;
            //
            this._productos = new List<DetalleVentaEntity>();
        }


        //Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Id_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }

         public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }

        public decimal Total_itbis
        {
            get { return t_itbis; }
            set { t_itbis = value; }
        }

        public DateTime Fecha
        {
            get { return f_factura; }
            set { f_factura =  value; }
        }

        public int Ncf
        {
            get { return ncf; }
            set { ncf = value; }
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public decimal Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }

        public decimal Subtotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }

        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Vendedor
        {
            get { return vendedor; }
            set { vendedor = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<DetalleVentaEntity> Productos
        {
            get
            {
                return _productos;
            }
        }

        //Method Add Items to list<>
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
        public decimal Descuentos()
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
            t_pagar_c_descuento = t_pagar - Descuentos();
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
