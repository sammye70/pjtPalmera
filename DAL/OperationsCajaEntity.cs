using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
    public  class OperationsCajaEntity
    {
        //Fields (Cash)

        private int id;
        private int userid;
        private decimal uno;
        private decimal cinco;
        private decimal diez;
        private decimal venticinco;
        private decimal cincuenta;
        private decimal cien;
        private decimal doscientos;
        private decimal quinientos;
        private decimal mil;
        private decimal dosmil;
        private string fecha;
        private decimal monto;
        private string type_op;
        private int status;
        private decimal faltante;
        private decimal venta;
        private string bdate;
        private string udate;
        private decimal montopagos;
        private decimal montopagostarjeta;
        private decimal montopagosefectivo;
        private decimal montotarjeta;
        private decimal montoefectivo;



        //Constructors

        public OperationsCajaEntity()
        {
        }

        public OperationsCajaEntity(int id, int userid, string fecha, decimal uno, decimal cinco, decimal diez, decimal venticinco, decimal cincuenta, decimal cien, decimal doscientos, decimal quinientos, decimal mil, decimal dosmil,
                                   decimal monto, string type_op)
        {
            this.Id = id;
            this.UserId = userid;
            this.Fecha = fecha;
            this.Uno = uno;
            this.Cinco = cinco;
            this.Diez = diez;
            this.Venticinco = venticinco;
            this.Cincuenta = cincuenta;
            this.Cien = cien;
            this.Doscientos = doscientos;
            this.Quinientos = quinientos;
            this.Mil = mil;
            this.Dosmil = dosmil;
            this.Monto = monto;
            this.TypeOp = type_op;

        }


        //Properties

        public int Id
        {
            get { return id; }

            set { id = value; }
        }

        /// <summary>
        /// Operation type (open or close)
        /// </summary>
        public string TypeOp
        {
            get { return type_op; }
            set { type_op = value; }
        }

        public String Fecha
        {
            get { return fecha; }

            set { fecha = value; }
        }

        public decimal Faltante
        {
            get { return faltante; }
            set { faltante = value; }
        }

        /// <summary>
        /// Total amount all sells
        /// </summary>
        public decimal Venta
        {
            get { return venta; }
            set { venta = value; }
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public int UserId
        {
            get { return userid; }

            set { userid = value; }
        }

        public String Bdate
        {
            get { return bdate; }
            set { bdate = value; }
        }

        public String Udate
        {
            get { return udate; }
            set { udate = value; }
        }


        public decimal Uno
        {
            get { return uno; }

            set { uno = value; }
        }

        public decimal Cinco
        {
            get { return cinco; }

            set { cinco = value; }
        }

        public decimal Diez
        {
            get { return diez; }

            set { diez = value; }
        }

        public decimal Venticinco
        {
            get { return venticinco; }

            set { venticinco = value; }
        }

        public decimal Cincuenta
        {
            get
            { return cincuenta; }

            set
            { cincuenta = value; }
        }

        public decimal Cien
        {
            get
            { return cien; }

            set
            { cien = value; }
        }

        public decimal Doscientos
        {
            get
            {
                return doscientos;
            }

            set
            {
                doscientos = value;
            }
        }

        public decimal Quinientos
        {
            get
            {
                return quinientos;
            }

            set
            {
                quinientos = value;
            }
        }

        public decimal Mil
        {
            get
            {
                return mil;
            }

            set
            {
                mil = value;
            }
        }

        public decimal Dosmil
        {
            get
            {
                return dosmil;
            }

            set
            {
                dosmil = value;
            }
        }

        /// <summary>
        /// Total Amount all cash inside box before close
        /// </summary>
        public decimal Monto
        {
            get
            {
                return monto;
            }

            set
            {
                monto = value;
            }
        }

        /// <summary>
        ///  Total Amount all Sells but only with Cash
        /// </summary>
        public decimal AmountSellsCash
        {
            get { return montoefectivo; }
            set { montoefectivo = value; }
        }

        /// <summary>
        /// Total Amount all Sells but only with credit card
        /// </summary>
        public decimal AmountSellsCard
        {
            get { return montotarjeta; }
            set { montotarjeta = value; }
        }

        /// <summary>
        /// Total Amount all Pays Credit Account
        /// </summary>
        public decimal MontosPagos
        {
            get { return montopagos; }
            set { montopagos = value; }
        }

        /// <summary>
        /// Total Amount all Pays Credit Account but only cash
        /// </summary>
        public decimal TotalAmountPaysCash
        {
            get { return montopagosefectivo; }
            set { montopagosefectivo = value; }
        }

        /// <summary>
        /// Total Amount all Pays Credit Account but only credit card
        /// </summary>
        public decimal TotalAmountPaysCard
        {
            get { return montopagostarjeta; }
            set { montopagostarjeta = value; }
        }

    }
}
