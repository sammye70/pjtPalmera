using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
    public class VentaCrEntity : VentaEntity
    {
        private decimal received;
        private decimal change;


        public VentaCrEntity() 
        {
        }

        public decimal Change(decimal received, decimal amount)
        {
            this.change = received - amount;
            return this.change;
        }


    }
}
