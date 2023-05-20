using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
    public class ProductosVendidosEntity
    {
        //public Int32 No { get; set; }
        public long ID { get; set; }
        public string DESCRIPCION { get; set; }
        public float CANTIDAD { get; set; }
        public DateTime FECHA_VENTA { get; set; }
    }
}
