using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
   public class ProvinciaEntity
    {
        //
        int id_provincia;
        string nombre;
        
        //
        public int Id_provincia
        {
            get { return id_provincia; }
            set { id_provincia = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        //
        public ProvinciaEntity()
        {
        }

        public ProvinciaEntity(int IdProvincia, string Nombre)
        {
            this.id_provincia = IdProvincia;
            this.nombre = Nombre;
        }
    }
}
