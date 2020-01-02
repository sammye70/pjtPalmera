using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
   public class clsClientes
    {
        //Properties
        int _idclientes;
        int _cedula;
        string _nombre;
        string _apellidos;
        string _telefono;
        string _direccion;
        string _ciudad;
        decimal _limitecredito;
        int _createby;
        string _created;

        //Methods
        public int _Idclientes
        {
            get { return _idclientes; }
            set { _idclientes = value; }
        }

        public int _Cedula
        {
            get { return _cedula; }
            set { _cedula = value; }
        }

       public string _Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string _Apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }

        public string _Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string _Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public string _Ciudad
        {
            get { return _ciudad; }
            set { _ciudad = value; }
        }

        public decimal _Limitecredito
        {
            get { return _limitecredito; }
            set { _limitecredito = value; }
        }

        public int _Createby
        {
            get { return _createby;}
            set { _createby = value; }
        }
        
        public string created
        {
            get { return _created; }
            set { _created = value; }
        }

        //Construtor
        public clsClientes(int Idclientes, int Cedula, string Nombre, string Apellidos, string Telefono, string Direccion, string Ciudad,
            decimal Limitecredito, int Createby, string Created)
        {
            this._idclientes = Idclientes;
            this._cedula = Cedula;
            this._nombre = Nombre;
            this._apellidos = Apellidos;
            this._telefono = Telefono;
            this._direccion = Direccion;
            this._ciudad = Ciudad;
            this._limitecredito = Limitecredito;
            this._createby = Createby;
            this._created = Created;
        }
    }
}
