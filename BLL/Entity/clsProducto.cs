using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class clsProducto
    {
        /// <summary>
        /// Author: Samuel Estrella
        /// created: 22/12/2019
        /// Modificated by:  
        /// Title: Product
        /// </summary>

        public int Id { get; set; }
        public string Descripcion { get; set; }
       // public int idfamilia { get; set; }
        public float Cantidad { get; set; }
        //public float stockmax { get; set; }
        //public float stockmin { get; set; }
        //public DateTime f_vencimiento { get; set; }
        //public decimal costo { get; set; }
        public decimal Precio_Venta { get; set; }
        //public int createby { get; set; }
        //public int created { get; set; }
        public decimal Valor { get { return Precio_Venta * (decimal)Cantidad; } }

    }
}
