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
        private long orden;
        private long idproducto;
        private string descripcion;
        private string categoria;
        private string proveedor;
        private float stock;
        private float stockminimo;
        private DateTime vencimiento;
        private decimal costo;
        private decimal precio_venta;
        private string status;
        private int createby;
        private DateTime created;
       /// private DateTime modificated;


        //Constructor

        public ProductosEntity()
        {
        }

        public ProductosEntity(long orden, long idproducto, string descripcion, string categoria, string proveedor, float stock_actual, float stock, float stock_minimo,
            DateTime vencimiento, decimal costo, decimal precio_venta, string status, int createby, DateTime created)
        {
            this.Orden = orden;
            this.Codigo = idproducto;
            this.Descripcion = descripcion;
            this.Categoria = categoria;
            this.proveedor = proveedor;
            this.Stock = stock;
            this.Stockminimo = stock_minimo;
            this.Vencimiento = vencimiento;
            this.Costo = Costo;
            this.Precio_venta = precio_venta;
            this.Estado = status;
            this.Creado_por = createby;
            this.Creado = created;
        }

        //Properties

        public long Orden
        {
            get { return orden; }
            set { orden = value; }
        }


        public long Codigo
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

        public string Proveedor
        {
            get
            {
                return proveedor;
            }

            set
            {
                proveedor = value;
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

        public int Creado_por
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

        public DateTime Creado
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

        public String Estado
        {
            get { return status; }
            set { status = value; }
        }

        //public DateTime Modificated 
        //{
        //    get { return modificated; }
        //    set { modificated = value; }
        //}
       

        /// <summary>
        /// Calculo Precio Venta
        /// </summary>
        /// <param name="costo"></param>
        /// <returns></returns>
        public decimal PrecioVenta()
        {
            decimal preciog, pv;

            preciog = (costo * 30) / 100;
            pv = costo + preciog;

            return pv;
        }

    }
}
