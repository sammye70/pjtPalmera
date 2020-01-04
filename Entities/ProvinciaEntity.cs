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
        int _idprovincia;
        string _nombre;
        
        //
        public int Idprovincia {
            get { return _idprovincia; }
            set { _idprovincia = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        //
        public ProvinciaEntity(int IdProvincia, string Nombre)
        {
            this._idprovincia = IdProvincia;
            this._nombre = Nombre;
        }

        public ProvinciaEntity(int IdProvincia)
        {
            this._idprovincia = IdProvincia;
        }

        public ProvinciaEntity( string nombre)
        {
            this._nombre = nombre;
        }
    }
}
