using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
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
        public static decimal MontoVentas(CierreCajaEntity cCaja)
        { 
            decimal amount;
            
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spGetAmountTempSells", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@puserid", cCaja.UserId);
                   
                    amount = Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            return amount;
        }

        /// <summary>
        /// Remove Transtactions temp by user id
        /// </summary>
        public static int CleanTranstactions(CierreCajaEntity cCaja)
        {
            int result;
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spRemoveTransactionTemp", con))
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@puserid", cCaja.UserId);
                   
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
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


        /// <summary>
        /// Save History Header and Detail About process Close Box
        /// </summary>
        /// <param name="Ocaja"></param>
        /// <returns></returns>
        public static int CreateHistoryCloseBox(CierreCajaEntity cCaja)
        {
            int result;
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spCreateOpBox", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pcajero", cCaja.UserId);
                    cmd.Parameters.AddWithValue("@pmonto", cCaja.Monto);
                    cmd.Parameters.AddWithValue("@ptypeop", cCaja.TypeOp);
                    cmd.Parameters.AddWithValue("@pcreated", DateTime.Now);

                    cCaja.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }

                using (var cmd = new MySqlCommand("spCreateDetailOpBox", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pid_open_process", cCaja.Id);
                    cmd.Parameters.AddWithValue("@pcajero", cCaja.UserId);
                    cmd.Parameters.AddWithValue("@puno", cCaja.Uno);
                    cmd.Parameters.AddWithValue("@pcinco", cCaja.Cinco);
                    cmd.Parameters.AddWithValue("@pdiez", cCaja.Diez);
                    cmd.Parameters.AddWithValue("@pventicinco", cCaja.Venticinco);
                    cmd.Parameters.AddWithValue("@pcincuenta", cCaja.Cincuenta);
                    cmd.Parameters.AddWithValue("@pcien", cCaja.Cien);
                    cmd.Parameters.AddWithValue("@pdoscientos", cCaja.Doscientos);
                    cmd.Parameters.AddWithValue("@pquinientos", cCaja.Quinientos);
                    cmd.Parameters.AddWithValue("@pmil", cCaja.Mil);
                    cmd.Parameters.AddWithValue("@pdosmil", cCaja.Dosmil);
                    cmd.Parameters.AddWithValue("@pmonto", cCaja.Monto);
                    cmd.Parameters.AddWithValue("@pcreated", DateTime.Now);

                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }
    }
}
