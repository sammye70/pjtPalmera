using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
    public class ProveedorEntity
    {
        private int idproveedor;
        private string nombre_proveedor;
        private string nombre_contacto;
        private string tel_proveedor;
        private string tel_contacto;
        private string direccion_fab;
        private string rnc;
        private decimal limitecredito;
        private DateTime created;
        private int createby;


        public int Idproveedor
        {
            get { return idproveedor; }
            set { idproveedor = value; }
        }

        public string Nombre_proveedor
        {
            get { return nombre_proveedor;  }

            set { nombre_proveedor = value; }
        }

        public string Nombre_contacto
        {
            get { return nombre_contacto; }

            set { nombre_contacto = value;}
        }

        public string Tel_contacto
        {
            get { return tel_contacto; }

            set {  tel_contacto = value;}
        }

        public string Direccion_fab
        {
            get { return direccion_fab;}

            set{direccion_fab = value; }
        }

        public string Rnc
        {
            get { return rnc; }

            set { rnc = value; }
        }

        public decimal Limitecredito
        {
            get { return limitecredito;}

            set { limitecredito = value;}
        }

        public DateTime Created
        {
            get  { return created;}

            set { created = value; }
        }

        public int Createby
        {
            get {  return createby;}

            set { createby = value;}
        }

        public string Tel_proveedor
        {
            get { return tel_proveedor; }

            set { tel_proveedor = value; }
        }

        public ProveedorEntity()
        {
        }

        public ProveedorEntity(int Idproveedor, string Nombre_proveedor, string Nombre_contacto, string Tel_proveedor, string Tel_contacto, 
            string Direccion_fab, string Rnc, decimal Limitecredito, DateTime Created, int Createby)
        {
            this.idproveedor = Idproveedor;
            this.nombre_proveedor = Nombre_proveedor;
            this.nombre_contacto = Nombre_contacto;
            this.tel_contacto = Tel_contacto;
            this.tel_proveedor = Tel_proveedor;
            this.direccion_fab = Direccion_fab;
            this.rnc = Rnc;
            this.limitecredito = Limitecredito;
            this.created = Created;
            this.createby = Createby;
        }
    }
}
