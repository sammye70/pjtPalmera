using pjPalmera.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
  
    public class CreditAccountEntity : VentaEntity //, iCreditAccount
    {
        // Fields
        private long idaccount;
        private decimal pay;
        private decimal currentamount;
        private decimal invoice_amount;
        private decimal pastamountcr;
        private DateTime modificate_date;
        private int result;
        private string concept;

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
        public decimal NewAmountcr
        {
            get { return currentamount; }
            set { currentamount = value; }
        }

        /// <summary>
        ///  Credit Account Past Amount after last paid value
        /// </summary>
        public decimal PastAmountcr
        {
            get { return pastamountcr; }
            set { pastamountcr = value; }
        }

        /// <summary>
        ///  invoice amount set in credit account
        /// </summary>
        public decimal InvoiceAmount
        {
            get { return invoice_amount; }
            set { invoice_amount = value; }
        }


        /// <summary>
        /// Set Date when a customer submit some pay in credit account
        /// </summary>
        public DateTime Modificate_date
        {
            get { return modificate_date; }
            set { modificate_date = value; }
        }
    
        /// <summary>
        /// Set and Get Result of operation
        /// </summary>
        public int Result
        {
            get { return result; }
            set { result = value; }
        }

        /// <summary>
        ///  Set or Get pay concept
        /// </summary>
        public string Concept
        {
            get { return concept; }
            set { concept = value; }
        }
    }
}
