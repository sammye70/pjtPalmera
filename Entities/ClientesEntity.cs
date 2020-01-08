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
        public int idclientes;
        public int cedula;
        public string nombre;
        public string apellidos;
        public string telefono;
        public string direccion;
        public string provincia;
        public string ciudad;
        public decimal limitecredito;
        public int createby;
        public DateTime created;

        //Methods
        public int Idclientes
        {
            get { return idclientes; }
            set { idclientes = value; }
        }

        public int Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Provincia
        {

            get { return provincia; }
            set { provincia = value; }
        }
        
        public string Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        public decimal Limitecredito
        {
            get { return limitecredito; }
            set { limitecredito = value; }
        }

        public int Createby
        {
            get { return createby; }
            set { createby = value; }
        }

        public DateTime Created
        {
            get { return created; }
            set {  created=value; }
        }

        //Construtor
        public ClientesEntity(int Idclientes, int Cedula, string Nombre, string Apellidos, string Telefono, string Direccion, string Provincia, string Ciudad,
            decimal Limitecredito, int Createby, DateTime Created)
        {
            this.idclientes = Idclientes;
            this.cedula = Cedula;
            this.nombre = Nombre;
            this.apellidos = Apellidos;
            this.telefono = Telefono;
            this.direccion = Direccion;
            this.provincia = Provincia;
            this.ciudad = Ciudad;
            this.limitecredito = Limitecredito;
            this.createby = Createby;
            this.created = Created;
        }

        public ClientesEntity()
        {
        }

    }
}
