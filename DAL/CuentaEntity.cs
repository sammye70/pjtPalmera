using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
    /// <summary>
    ///  Customer Account (Only for review and filter in pay process)
    /// </summary>
    public class CuentaEntity
    {
        //Fields
        private string idcard;
        private long id_cliente;
        private string nombre;
        private string apellidos;
        private decimal monto;
        private DateTime fecha;
        private decimal pago;

        //Constructor
        public CuentaEntity()
        {
        }

        public CuentaEntity(string idcard, long id_cliente, string nombre, string apellidos, decimal monto, DateTime fecha)
        {
            this.Cedula = idcard;
            this.Id_cliente = id_cliente;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Monto = monto;
            this.Ultimo_Pago = fecha;
        }

        //Properties

        public string Cedula
        {
            get { return idcard; }
            set { idcard = value; }
        }

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

 
        public decimal Pago
        {
            get { return pago; }
            set { pago = value; }
        }

        public DateTime Ultimo_Pago
        {
            get { return fecha; }
            set { fecha = value; }
        }
    }
}
