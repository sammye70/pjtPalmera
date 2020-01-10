using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
    public class CategoriaEntity
    {
        private int category_id;
        private string category;

        public int Category_id
        {
            get
            {
                return category_id;
            }

            set
            {
                category_id = value;
            }
        }

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }

        public CategoriaEntity()
        {
        }

        public CategoriaEntity(int Category_id, string Category)
        {
            this.category_id = Category_id;
            this.category = Category;
        }
    }
}
