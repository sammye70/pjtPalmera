using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
    public class ProveedorEntity
    {
        //Fields
        private int idproveedor;
        private string nombre;
        private string nombre_contacto;
        private string tel_proveedor;
        private string tel_contacto;
        private string direccion_prob;
        private long rnc;
        private decimal limitecredito;
        private DateTime created;
        private int createby;


        //Contructor
        public ProveedorEntity()
        {
        }

        public ProveedorEntity(int idproveedor, string nombre_proveedor, string nombre_contacto, string tel_proveedor, string tel_contacto, 
            string direccion_prob, long rnc, decimal limitecredito, DateTime created, int createby)
        {
            this.Idproveedor = idproveedor;
            this.Nombre_proveedor = nombre_proveedor;
            this.Nombre_contacto = nombre_contacto;
            this.Tel_contacto = tel_contacto;
            this.Tel_proveedor = tel_proveedor;
            this.direccion_prob = direccion_prob;
            this.Rnc = rnc;
            this.Limitecredito = limitecredito;
            this.Created = created;
            this.Createby = createby;
        }

        //Properties
        public int Idproveedor
        {
            get { return idproveedor; }
            set { idproveedor = value; }
        }

        public string Nombre_proveedor
        {
            get { return nombre; }

            set { nombre = value; }
        }

        public string Nombre_contacto
        {
            get { return nombre_contacto; }

            set { nombre_contacto = value; }
        }

        public string Tel_contacto
        {
            get { return tel_contacto; }

            set { tel_contacto = value; }
        }

        public string Direccion_prob
        {
            get { return direccion_prob; }

            set { direccion_prob = value; }
        }

        public long Rnc
        {
            get { return rnc; }

            set { rnc = value; }
        }

        public decimal Limitecredito
        {
            get { return limitecredito; }

            set { limitecredito = value; }
        }

        public DateTime Created
        {
            get { return created; }

            set { created = value; }
        }

        public int Createby
        {
            get { return createby; }

            set { createby = value; }
        }

        public string Tel_proveedor
        {
            get { return tel_proveedor; }

            set { tel_proveedor = value; }
        }
    }
}
