using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pjPalmera.DAL;
using pjPalmera.Entities;

namespace pjPalmera.BLL
{
    public class TransactionsBO 
    {
        /// <summary>
        /// Create Daily Transactions
        /// </summary>
        /// <returns></returns>
        public static TransactionsEntity CreateTranst(TransactionsEntity Transactions)
        {
            try
            {
                return TransactionsDAL.CreateTranst(Transactions);
            }
            catch (InvalidOperationException ex)
            {
                ex.GetType();
                return null;
             
            }
        }
    }
}
