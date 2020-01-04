using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
   public class ClientesEntity
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
        public int Idclientes
        {
            get { return _idclientes; }
            set { _idclientes = value; }
        }

        public int Cedula
        {
            get { return _cedula; }
            set { _cedula = value; }
        }

       public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public string Ciudad
        {
            get { return _ciudad; }
            set { _ciudad = value; }
        }

        public decimal Limitecredito
        {
            get { return _limitecredito; }
            set { _limitecredito = value; }
        }

        public int Createby
        {
            get { return _createby;}
            set { _createby = value; }
        }
        
        public string Created
        {
            get { return _created; }
            set { _created = value; }
        }

        //Construtor
        public ClientesEntity(int Idclientes, int Cedula, string Nombre, string Apellidos, string Telefono, string Direccion, string Ciudad,
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
