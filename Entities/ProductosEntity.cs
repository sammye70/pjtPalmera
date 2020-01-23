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
        private string categoria;
        private string fabricante;
        // public float cantidad_vendida { get { return stock_actual - cantidad_vendida; } } //
        //  public float stock_actual { get; set; }
        private float stock;
        private float stockminimo;
        private DateTime vencimiento;
        private decimal costo;
        private decimal precio_venta;
        private int createby;
        private DateTime created;



        public ProductosEntity()
        {
        }

        //Constructor
        public ProductosEntity(long idproducto, string descripcion, string categoria, string fabricante, float stock_actual, float stock, float stock_minimo,
            DateTime vencimiento, decimal costo, decimal precio_venta, int createby, DateTime created)
        {
            this.Idproducto = idproducto;
            this.Descripcion = descripcion;
            this.Categoria = categoria;
            this.Fabricante = fabricante;
            this.Stock = stock;
            this.Stockminimo = stock_minimo;
            this.Vencimiento = vencimiento;
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

        public string Categoria
        {
            get
            {
                return categoria;
            }

            set
            {
                categoria = value;
            }
        }

        public string Fabricante
        {
            get
            {
                return fabricante;
            }

            set
            {
                fabricante = value;
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

        public DateTime Vencimiento
        {
            get
            {
                return vencimiento;
            }

            set
            {
                vencimiento = value;
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

        /// <summary>
        /// Calculo Precio Venta
        /// </summary>
        /// <param name="costo"></param>
        /// <returns></returns>
        public decimal PrecioVenta(decimal costo)
        {
            decimal preciog, pv;

            preciog = (costo * 30) / 100;
            pv = costo + preciog;

            return pv;
        }
    }
}
