using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
    public class PagosEntity
    {
        //Fields
        private long id;
        private long id_cliente;
        private decimal balance_antes_pago;
        private decimal balance_actual;
        private decimal recibido;
        private decimal devuelta;
        private decimal pago;
        private DateTime fecha;

        //Constructor
        public PagosEntity()
        {
        }

        public PagosEntity(long id, long id_cliente, decimal balance_antes_pago, decimal balance_actual, decimal recibido, decimal devuelta, decimal pago, DateTime fecha)
        {
            this.Id = id;
            this.Id_cliente = id_cliente;
            this.Balance_antes_pago = balance_antes_pago;
            this.Balance_actual = balance_actual;
            this.Recibido = recibido;
            this.Devuelta = devuelta;
            this.Pago = pago;
            this.Fecha = fecha;
        }

        //Properties

        public Int64 Id
        {
            get { return id; }
            set { id = value; }
        }

        public Int64 Id_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }

        public decimal Balance_antes_pago
        {
            get { return balance_antes_pago; }

            set { balance_antes_pago = value;}
        }

        public decimal Balance_actual
        {
            get { return balance_actual;}

            set { balance_actual = value;}
        }

        public decimal Recibido
        {
            get { return recibido; }

            set {recibido = value; }
        }

        public decimal Devuelta
        {
            get { return devuelta; }

            set { devuelta = value; }
        }

        public decimal Pago
        {
            get { return pago; }
            set { pago = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }

            set { fecha = value; }
        }
    }
}
