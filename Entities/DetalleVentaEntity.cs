using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
 
    /// Author: Samuel Estrella
    /// created: 22/12/2019
    /// Modificated by:  
    /// Title: Products for Sales
    
    
    public class DetalleVentaEntity
    {
        //Fields
       // private int no;
        private long id;
        private string description;
        private float quantity;
        private decimal price;
        private decimal itbis;
        private decimal amount;
        private long id_venta;
        private DateTime created;

        #region Other Fields
        //public int idfamilia { get; set; }
        //public float stockmax { get; set; }
        //public float stockmin { get; set; }
        //public DateTime f_vencimiento { get; set; }
        //public decimal costo { get; set; }
        //public int createby { get; set; }
        //public int created { get; set; } 
        #endregion

        //Properties
        //public int No
        //{
        //    get { return no; }
        //    set { no = value; }
        //}

        /// <summary>
        /// 
        /// </summary>
        public long CODIGO 
        {
            get { return id; }
            set { id = value; } 
        }

        /// <summary>
        /// 
        /// </summary>
        public string DESCRIPCION 
        {
            get { return description; }
            set { description = value; } 
        }

        /// <summary>
        /// 
        /// </summary>
        public float CANTIDAD 
        {
            get { return quantity; }
            set { quantity = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal PRECIO 
        {
            get { return price; }
            set { price = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal ITBIS 
        { 
            get { return itbis =(amount * 18) / 100; } 
            set { amount = value; } 
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal IMPORTE 
        { 
            get { return amount = price * (decimal)quantity; } 
            set { amount = value; } 
        }

        /// <summary>
        /// 
        /// </summary>
        public long ID_FACTURA
        {
            get { return id_venta; }
            set { id_venta = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime MODIFICADO
        {
            get { return created; }
            set { created = value; }
        }


    }
}
