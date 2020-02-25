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
        /// Save History Detail About process Open Box
        /// </summary>
        /// <param name="Ocaja"></param>
        /// <returns></returns>
        public static void CreateHistoryOpenBox(AperturaCajaEntity Ocaja)
        {

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"INSERT INTO  history_open_box (cajero, uno, cinco, diez, venticinco, cincuenta, cien, doscientos, quinientos, mil, dosmil, monto, created)
                                    VALUES(@cajero, @uno, @cinco, @diez, @venticinco, @cincuenta, @cien, @doscientos, @quinientos, @mil, @dosmil, @monto, @created)";
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@cajero", 1);
                cmd.Parameters.AddWithValue("@uno", Ocaja.Uno);
                cmd.Parameters.AddWithValue("@cinco", Ocaja.Cinco);
                cmd.Parameters.AddWithValue("@diez", Ocaja.Diez);
                cmd.Parameters.AddWithValue("@venticinco", Ocaja.Venticinco);
                cmd.Parameters.AddWithValue("@cincuenta", Ocaja.Cincuenta);
                cmd.Parameters.AddWithValue("@cien", Ocaja.Cien);
                cmd.Parameters.AddWithValue("@doscientos", Ocaja.Doscientos);
                cmd.Parameters.AddWithValue("@quinientos", Ocaja.Quinientos);
                cmd.Parameters.AddWithValue("@mil", Ocaja.Mil);
                cmd.Parameters.AddWithValue("@dosmil", Ocaja.Dosmil);
                cmd.Parameters.AddWithValue("@monto", Ocaja.Monto);
                cmd.Parameters.AddWithValue("@created", DateTime.Now);

                cmd.ExecuteNonQuery();
            }
        }


        /// <summary>
        /// Save process Open Box until Close Box
        /// </summary>
        /// <param name="Ocaja"></param>
        public static void CreateOpenBox(AperturaCajaEntity Ocaja)
        {

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"INSERT INTO  open_box (cajero, monto, created)
                                    VALUES(@cajero, @monto, @created)";
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@cajero", 1);
                cmd.Parameters.AddWithValue("@monto", Ocaja.Monto);
                cmd.Parameters.AddWithValue("@created", DateTime.Now);

                cmd.ExecuteNonQuery();
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
