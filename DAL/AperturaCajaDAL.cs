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
   public class AperturaCajaDAL
    {

        /// <summary>
        /// Save History Header and Detail About process Open Box
        /// </summary>
        /// <param name="Ocaja"></param>
        /// <returns></returns>
        public static void CreateHistoryOpenBox(AperturaCajaEntity oCaja)
        {
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spCreateOpBox", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pcajero", oCaja.Cajero);
                    cmd.Parameters.AddWithValue("@pmonto", oCaja.Monto);
                    cmd.Parameters.AddWithValue("@ptypeop", oCaja.TypeOp);
                    cmd.Parameters.AddWithValue("@pcreated", DateTime.Now);

                    oCaja.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }

                using (var cmd = new MySqlCommand("spCreateDetailOpBox", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pid_open_process", oCaja.Id);
                    cmd.Parameters.AddWithValue("@pcajero", oCaja.Cajero);
                    cmd.Parameters.AddWithValue("@puno", oCaja.Uno);
                    cmd.Parameters.AddWithValue("@pcinco", oCaja.Cinco);
                    cmd.Parameters.AddWithValue("@pdiez", oCaja.Diez);
                    cmd.Parameters.AddWithValue("@pventicinco", oCaja.Venticinco);
                    cmd.Parameters.AddWithValue("@pcincuenta", oCaja.Cincuenta);
                    cmd.Parameters.AddWithValue("@pcien", oCaja.Cien);
                    cmd.Parameters.AddWithValue("@pdoscientos", oCaja.Doscientos);
                    cmd.Parameters.AddWithValue("@pquinientos", oCaja.Quinientos);
                    cmd.Parameters.AddWithValue("@pmil", oCaja.Mil);
                    cmd.Parameters.AddWithValue("@pdosmil", oCaja.Dosmil);
                    cmd.Parameters.AddWithValue("@pmonto", oCaja.Monto);
                    cmd.Parameters.AddWithValue("@pcreated", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
        }



        /// By: sammye70
        /// created: 10/02/2021
        /// Modificated by: sammye70
        /// Modificated Date:
        /// <summary>
        ///  Get Status Box (It will return 0 when is close and 1 if is open )
        /// </summary>
        /// <returns></returns>
        public static int GetStatusBox(AperturaCajaEntity oCaja)
        {
            int status = 0;
            // string strmgs;

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spGetStatusBox", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pcajero", oCaja.Cajero);
                    cmd.Parameters.Add("@resp", MySqlDbType.Int32);
                    cmd.Parameters["@resp"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();

                    status = (Int32) cmd.Parameters["@resp"].Value;
                }
            }
            return status;
        }


        /// By: sammye70
        /// created: 
        /// Modificated by: sammye70
        /// Modificated Date: 
        /// <summary>
        /// Save process Open Box until box status change to closed
        /// </summary>
        /// <param name="Ocaja"></param>
        public static void CreateOpenBox(AperturaCajaEntity oCaja)
        {
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spCreateOpenB", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pcajero", oCaja.Cajero);
                    cmd.Parameters.AddWithValue("@pmonto", oCaja.Monto);
                    cmd.Parameters.AddWithValue("@pstatus", oCaja.Status);
                    cmd.Parameters.AddWithValue("@pcreated", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Get Current Amount used open box
        /// </summary>
        /// <returns></returns>
        public static decimal GetAmount()
        {
            decimal amount;
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"SELECT SUM(monto) FROM open_box;";

                MySqlCommand cmd = new MySqlCommand(query, con);

                amount = Convert.ToDecimal(cmd.ExecuteScalar());
            }
            return amount;
        }

    }
}
