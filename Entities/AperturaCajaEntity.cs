using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace pjPalmera.Entities
{
    public class AperturaCajaEntity
    {
        //Fields (Cash)

        private int id;
        private int userid;
        private int uno;
        private int cinco;
        private int diez;
        private int venticinco;
        private int cincuenta;
        private int cien;
        private int doscientos;
        private int quinientos;
        private int mil;
        private int dosmil;
        private DateTime fecha;
        private decimal monto;
        private int type_op;
        private int status;


        //Constructors

        public AperturaCajaEntity()
        {
        }

        public AperturaCajaEntity(int id, int userid, DateTime fecha, int uno, int cinco, int diez, int venticinco, int cincuenta, int cien, int doscientos, int quinientos, int mil, int dosmil,
                                   decimal monto, int type_op)
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

        public int Status 
        {
            get { return status; }
            set { status = value; }
        }


        public int TypeOp
        {
            get { return type_op; }
            set { type_op = value; }
        }
        
        public int Id
        {
            get { return id;}

            set { id = value; }
        }

        public int UserId
        {
            get { return userid; }

            set { userid = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }

            set { fecha = value; }
        }

        public int Uno
        {
            get { return uno; }

            set { uno = value; }
        }

        public int Cinco
        {
            get { return cinco; }

            set { cinco = value; }
        }

        public int Diez
        {
            get { return diez; }

            set { diez = value; }
        }

        public int Venticinco
        {
            get { return venticinco; }

            set { venticinco = value; }
        }

        public int Cincuenta
        {
            get
            {
                return cincuenta;
            }

            set
            {
                cincuenta = value;
            }
        }

        public int Cien
        {
            get
            {
                return cien;
            }

            set
            {
                cien = value;
            }
        }

        public int Doscientos
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

        public int Quinientos
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

        public int Mil
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

        public int Dosmil
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


      


    }
}
