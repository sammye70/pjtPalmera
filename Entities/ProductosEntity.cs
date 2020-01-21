using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
    public class ProductosEntity
    {


        //Field
        private long idproducto;
        private string descripcion;
        private string idfamilia;
        private string idfabricante;
        // public float cantidad_vendida { get { return stock_actual - cantidad_vendida; } } //
        //  public float stock_actual { get; set; }
        private float stock;
        private float stockminimo;
        private DateTime f_vencimiento;
        private decimal costo;
        private decimal precio_venta;
        private int createby;
        private DateTime created;



        public ProductosEntity()
        {
        }

        //Constructor
        public ProductosEntity(long idproducto, string descripcion, string idfamilia, string idfabricante, float stock_actual, float stock, float stock_minimo,
            DateTime f_vencimiento, decimal costo, decimal precio_venta, int createby, DateTime created)
        {
            this.Idproducto = idproducto;
            this.Descripcion = descripcion;
            this.Idfamilia = idfamilia;
            this.Idfabricante = idfabricante;
            this.Stock = stock;
            this.Stockminimo = stock_minimo;
            this.F_vencimiento = f_vencimiento;
            this.Costo = Costo;
            this.Precio_venta = precio_venta;
            this.Createby = createby;
            this.Created = created;
        }

 
        public long Idproducto
        {
            get
            {
                return idproducto;
            }

            set
            {
                idproducto = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public string Idfamilia
        {
            get
            {
                return idfamilia;
            }

            set
            {
                idfamilia = value;
            }
        }

        public string Idfabricante
        {
            get
            {
                return idfabricante;
            }

            set
            {
                idfabricante = value;
            }
        }

        public float Stock
        {
            get
            {
                return stock;
            }

            set
            {
                stock = value;
            }
        }

        public float Stockminimo
        {
            get
            {
                return stockminimo;
            }

            set
            {
                stockminimo = value;
            }
        }

        public DateTime F_vencimiento
        {
            get
            {
                return f_vencimiento;
            }

            set
            {
                f_vencimiento = value;
            }
        }

        public decimal Costo
        {
            get
            {
                return costo;
            }

            set
            {
                costo = value;
            }
        }

        public decimal Precio_venta
        {
            get
            {
                return precio_venta;
            }

            set
            {
                precio_venta = value;
            }
        }

        public int Createby
        {
            get
            {
                return createby;
            }

            set
            {
                createby = value;
            }
        }

        public DateTime Created
        {
            get
            {
                return created;
            }

            set
            {
                created = value;
            }
        }
    }
}
