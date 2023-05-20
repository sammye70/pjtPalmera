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
        private string cedula;
        private string nombre;
        private string apellidos;
        private string telefono;
        private string direccion;
        private string provincia;
        private string ciudad;
        private decimal limite_credito;
        private int createby;
        private DateTime created;
        private string status;
        //private int cxc;

        //Constructor
        public ClientesEntity()
        {
        }

        public ClientesEntity(long id, string cedula, string nombre, string apellidos, string telefono, string direccion, string provincia, string ciudad, decimal limite_credito, int createby, int cxc, DateTime created)
        {
            this.Id = id;
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.Provincia = provincia;
            this.Ciudad = ciudad;
            this.Limite_credito = limite_credito;
            this.Createby = createby;
            this.Created = created;
     
        }

        //Properties
        public long Id
        {
            get { return idcliente; }
            set { idcliente = value; }
        }

        public string Cedula
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

        public decimal Limite_credito
        {
            get { return limite_credito; }
            set { limite_credito = value; }
        }

        public string Estado
        {
            get { return status; }
            set { status = value; }
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
