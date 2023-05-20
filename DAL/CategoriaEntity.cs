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


        public CategoriaEntity()
        {
        }

        public CategoriaEntity(int category_id, string category)
        {
            this.Id = category_id;
            this.Categoria = category;
        }


        public int Id
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

        public string Categoria
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


    }
}
