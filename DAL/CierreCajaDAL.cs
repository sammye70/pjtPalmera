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
    public class CierreCajaDAL
    {
        /// <summary>
        /// Get Amount Total Invoices
        /// </summary>
        /// <returns></returns>
        public static decimal MontoVentas()
        {
            decimal amount;
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                string query = @"SELECT SUM(total) from transactions;";

                MySqlCommand cmd = new MySqlCommand(query,con);

                amount = Convert.ToDecimal(cmd.ExecuteScalar());
                
            }
            return amount;
        }

        /// <summary>
        /// Clean Transtactions Invoices
        /// </summary>
        public static void CleanTranstactions()
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                string query = @"TRUNCATE TABLE transactions;";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Clean Open Box
        /// </summary>
        public static void CleanOpenBox()
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                string query = @"TRUNCATE TABLE open_box;";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
