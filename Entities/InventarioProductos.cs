using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
    /// <summary>
    /// Author: Samuel Estrella
    /// created: 22/12/2019
    /// Modificated by:  
    /// Title: 
    /// </summary>
    public class InventarioProductosEntity
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public int idfamilia { get; set; }
        public float cantidad_vendida {  get { return stock_actual - cantidad_vendida; } } //
        public float stock_actual { get; set; }
        public float stockmax { get; set; }
        public float stockmin { get; set; }
        public DateTime f_vencimiento { get; set; }
        public decimal costo { get; set; }
        public decimal Precio_Venta { get; set; }
        public int createby { get; set; }
        public int created { get; set; }
    }
}
