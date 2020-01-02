using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class clsDetalleVenta
    {
        /// <summary>
        /// Author: Samuel Estrella
        /// created: 22/12/2019
        /// Modificated by:  
        /// Title: Products for Sales
        /// </summary>

        public long ID { get; set; }
        public string DESCRIPCION { get; set; }
        //public int idfamilia { get; set; }
        public float CANTIDAD { get; set; }
        //public float stockmax { get; set; }
        //public float stockmin { get; set; }
        //public DateTime f_vencimiento { get; set; }
        //public decimal costo { get; set; }
        public decimal PRECIO{ get; set; }
        //public int createby { get; set; }
        //public int created { get; set; }
        public decimal ITBIS { get { return (IMPORTE * 18) / 100; } }
        public decimal IMPORTE { get { return PRECIO * (decimal)CANTIDAD; } }

    }
}
