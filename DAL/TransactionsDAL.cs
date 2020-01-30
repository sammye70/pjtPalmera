using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using pjPalmera.Entities;


namespace pjPalmera.DAL
{
    public class TransactionsDAL
    {

        /// <summary>
        /// Create Daily Transactions
        /// </summary>
        /// <param name="Transaction"></param>
        /// <returns></returns>
        public static TransactionsEntity CreateTranst(TransactionsEntity Transaction)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"INSERT INTO transactions (created, status, total, descuento, devuelta, recibido) 
                                    VALUES (@created, @status, @total, @descuento, @devuelta, @recibido)";

                MySqlCommand cmd = new MySqlCommand(query, con);

               // cmd.Parameters.AddWithValue("", Transaction.Id);
                cmd.Parameters.AddWithValue("@created", DateTime.Now);
                cmd.Parameters.AddWithValue("@status", Transaction.Status);
                cmd.Parameters.AddWithValue("@total", Transaction.Total);
                cmd.Parameters.AddWithValue("@descuento", Transaction.Descuento);
                cmd.Parameters.AddWithValue("@devuelta", Transaction.Devuelta);
                cmd.Parameters.AddWithValue("@recibido", Transaction.Recibido);

                Transaction.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return Transaction;
        }
        
    }
}
