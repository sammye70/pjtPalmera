using pjPalmera.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
    public class CreditAccountEntity : VentaEntity
    {
        // Fields
        private long idaccount;
        private decimal pay;
        private decimal currentamount;
        private decimal invoice_amount;
        private decimal pastamount;

        // Constructor
        public CreditAccountEntity()
        { 
        }

        // Properties

        /// <summary>
        /// Credit Account Id
        /// </summary>
        public long IdAccount
        {
            get { return idaccount; }
            set { idaccount = value; }
        }

        /// <summary>
        ///  Credit Account Pay value
        /// </summary>
        public decimal PayValue
        {
            get { return pay; }
            set { pay = value; }
        }

        /// <summary>
        ///  Credit Account Current Amount Pendding before  pay value at present
        /// </summary>
        public decimal CurrentAmount
        {
            get { return currentamount; }
            set { currentamount = value; }
        }

        /// <summary>
        ///  Credit Account Past Amount after last paid value
        /// </summary>
        public decimal PastAmount
        {
            get { return pastamount; }
            set { pastamount = value; }
        }

        /// <summary>
        ///  invoice amount set in credit account
        /// </summary>
        public decimal InvoiceAmount
        {
            get { return invoice_amount; }
            set { invoice_amount = value; }
        }
    }
}
