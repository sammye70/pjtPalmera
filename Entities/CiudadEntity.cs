using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
   public  class CiudadEntity
    {
        //
        int _idCiudad;
        string _nombre;

        //
        public int Idciudad
        {
            get { return _idCiudad; }
            set { _idCiudad = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        //
        public CiudadEntity(int Idciudad, string Nombre)
        {
            this._idCiudad = Idciudad;
            this._nombre = Nombre;
        }
    }
}
