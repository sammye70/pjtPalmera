using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
    public class ProductosEntity
    {
        //Properties
        public long idproducto { get; set; }
        public string descripcion { get; set; }
        public int idfamilia { get; set; }
        public int idfabricante { get; set; }
       // public float cantidad_vendida { get { return stock_actual - cantidad_vendida; } } //
      //  public float stock_actual { get; set; }
        public float stockinicial { get; set; }
        public float stockminimo { get; set; }
        public DateTime f_vencimiento { get; set; }
        public decimal costo { get; set; }
        public decimal precio_venta { get; set; }
        public int createby { get; set; }
        public DateTime created { get; set; }


        //Constructor
        public ProductosEntity(long Idproducto, string Descripcion, int Idfamilia, int Idfrabricante, float Stock_actual, float Stock_inicial, float Stock_minimo, 
            DateTime F_vencimiento, decimal Costo, decimal Precio_venta, int Createby, DateTime Created )
        {
            this.idproducto = Idproducto;
            this.descripcion = Descripcion;
            this.idfamilia = Idfamilia;
            this.idfabricante = Idfrabricante;
            this.stockinicial = Stock_inicial;
            this.stockminimo = Stock_minimo;
            this.f_vencimiento = F_vencimiento;
            this.costo = Costo;
            this.precio_venta = Precio_venta;
            this.createby = Createby;
            this.created = Created;
        }

        public ProductosEntity()
        {
        }
    }
}
