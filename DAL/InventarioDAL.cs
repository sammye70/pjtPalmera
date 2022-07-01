using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
    public class InventarioEntity
    {
        private long idinventario;
        private int stock;


        public InventarioEntity()
        {
        }

        public InventarioEntity(long idinventario, int stock)
        {
            Idinventario = idinventario;
            Stock = stock;
        }

        public long Idinventario
        {
            get { return idinventario; }
            set { idinventario = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }
    }
}
