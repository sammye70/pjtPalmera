using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
    public class type_payEntity
    {
        public string[] arr_pay = new string[2];
        private int id;
        private string nombre;

        public type_payEntity() 
        { 
        }


        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public string Nombre
        {
            set { nombre = value; }
            get { return nombre; }
        }

        /// <summary>
        ///  Set pay Methods for current invoice
        /// </summary>
        public  void setMethod()
        {
          this.arr_pay[0] = "efectivo";
          this.arr_pay[1] = "tarjeta";
         // this.arr_pay[2] = "credito";
        }

        /// <summary>
        /// Get pay Methods for current invoice
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public List<string> getMethod(int i)
        {
            var lst = new List<string>();
            lst = this.arr_pay.ToList();
            return lst;
        }
    }
}
