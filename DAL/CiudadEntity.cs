using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
   public  class CiudadEntity
    {
   
        private int id_ciudad;
        private string nombre;



        public int Id_ciudad
        {
            get
            {
                return id_ciudad;
            }

            set
            {
                id_ciudad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }


        public CiudadEntity()
        {
        }


        public CiudadEntity(int Id_ciudad, string Nombre)
        {
            this.Id_ciudad = id_ciudad;
            this.Nombre = nombre;
        }
    }
}
