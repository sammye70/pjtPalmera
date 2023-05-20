using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
    public class ProductStatusEntity
    {
        //Fields
        private int id;
        private string status;

        //Constructor
        public ProductStatusEntity()
        { 
        }

        //Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
