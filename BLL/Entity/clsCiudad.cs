using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
   public  class clsCiudad
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
        public clsCiudad(int Idciudad, string Nombre)
        {
            this._idCiudad = Idciudad;
            this._nombre = Nombre;
        }
    }
}
