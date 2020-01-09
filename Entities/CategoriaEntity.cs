using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
    public class CategoriaEntity
    {
        private int id;
        private string nombre;

        //
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        //Constructor
        public CategoriaEntity(int Id, string Nombre)
        {
            this.id = Id;
            this.nombre = Nombre;
        }

        public CategoriaEntity()
        {
        }
    }
}
