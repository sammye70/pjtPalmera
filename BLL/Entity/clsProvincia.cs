using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
   public class clsProvincia
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
        public clsProvincia(int IdProvincia, string Nombre)
        {
            this._idprovincia = IdProvincia;
            this._nombre = Nombre;
        }

        public clsProvincia(int IdProvincia)
        {
            this._idprovincia = IdProvincia;
        }

        public clsProvincia( string nombre)
        {
            this._nombre = nombre;
        }
    }
}
