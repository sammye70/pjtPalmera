using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
   public class ClientesEntity
    {
        //Field
        private long idcliente;
        private long cedula;
        private string nombre;
        private string apellidos;
        private string telefono;
        private string direccion;
        private string provincia;
        private string ciudad;
        private decimal limitecredito;
        private int createby;
        private DateTime created;

        //Constructor
        public ClientesEntity()
        {
        }

        public ClientesEntity(Int64 id, Int64 cedula, string nombre, string apellidos, string telefono, string direccion, string provincia, string ciudad, decimal limitecredito, int createby, DateTime created)
        {
            this.idcliente = id;
            this.cedula = cedula;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.direccion = direccion;
            this.provincia = provincia;
            this.ciudad = ciudad;
            this.limitecredito = limitecredito;
            this.createby = createby;
            this.created = created;
        }

        //Properties
        public long Id
        {
            get { return idcliente; }
            set { idcliente = value; }
        }

        public long Cedula
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
    }
}
