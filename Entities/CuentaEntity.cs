using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
    public class CuentaEntity
    {
        //Fields
        private long id_cliente;
        private string nombre;
        private string apellidos;
        private decimal monto;
        private DateTime fecha;

        //Constructor
        public CuentaEntity()
        {
        }

        public CuentaEntity(long id_cliente, string nombre, string apellidos, decimal monto, DateTime fecha)
        {
            this.Id_cliente = id_cliente;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Monto = monto;
            this.Fecha = fecha;
        }

        //Properties
        public long Id_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }

        public string Nombre
        {
            get { return nombre;}
            set { nombre = value; }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public decimal Monto
        {
            get { return monto; }
            set { monto = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

    }
}
