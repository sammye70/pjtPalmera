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
        public int id { get; set; }
        public string descripcion { get; set; }
        public int idfamilia { get; set; }
        public float cantidad_vendida { get { return stock_actual - cantidad_vendida; } } //
        public float stock_actual { get; set; }
        public float stockmax { get; set; }
        public float stockmin { get; set; }
        public DateTime f_vencimiento { get; set; }
        public decimal costo { get; set; }
        public decimal Precio_Venta { get; set; }
        public int createby { get; set; }
        public int created { get; set; }


        //Constructor
        public ProductosEntity(int Id, string Descripcion, int Idfamilia, float Cantidad_vendida)
        {
            this.id = Id;
            this.descripcion = Descripcion;
            this.idfamilia = Idfamilia;

        }

        ProductosEntity()
        {

        }
    }
}
