using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
    /// <summary>
    /// Daily Transactions Entity
    /// </summary>
  public  class TransactionsEntity
    {
        //Fields
        private int id;
        private DateTime f_factura;
        private string vendedor;
        private string tipo;
        private int status;
        private decimal total;
        private decimal descuento;
        private decimal subtotal;
        private decimal total_itbis;
        private decimal recibido;
        private decimal devuelta;
        private int id_venta;


        //Constructor
       public TransactionsEntity()
       {
        
       }

        public TransactionsEntity(int id, DateTime f_factura, string vendedor, string tipo, int status, decimal total, decimal descuento, 
            decimal subtotal, decimal total_itbis, decimal recibido, decimal devuelta)
        {
            this.Id = id;
            this.F_factura = f_factura;
            this.Vendedor = vendedor;
            this.Tipo = tipo;
            this.Status = status;
            this.Total = total;
            this.Descuento = descuento;
            this.Subtotal = subtotal;
            this.Total_itbis = total_itbis;
            this.Recibido = recibido;
            this.Devuelta = devuelta;
        }

        //Properties
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public DateTime F_factura
        {
            get
            {
                return f_factura;
            }

            set
            {
                f_factura = value;
            }
        }

        public string Vendedor
        {
            get
            {
                return vendedor;
            }

            set
            {
                vendedor = value;
            }
        }

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public decimal Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public decimal Descuento
        {
            get
            {
                return descuento;
            }

            set
            {
                descuento = value;
            }
        }

        public decimal Subtotal
        {
            get
            {
                return subtotal;
            }

            set
            {
                subtotal = value;
            }
        }

        public decimal Total_itbis
        {
            get
            {
                return total_itbis;
            }

            set
            {
                total_itbis = value;
            }
        }

        public decimal Recibido
        {
            get
            {
                return recibido;
            }

            set
            {
                recibido = value;
            }
        }

        public decimal Devuelta
        {
            get
            {
                return devuelta;
            }

            set
            {
                devuelta = value;
            }
        }

        public int Id_venta
        {
            get { return id_venta; }
            set { id_venta = value; }
        }

    }
}
