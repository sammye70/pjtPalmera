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
    public class CiudadDAL
    {
        /// <summary>
        /// Create New City
        /// </summary>
        /// <param name="Ciudad"></param>
        /// <returns></returns>
        public static CiudadEntity Create(CiudadEntity Ciudad)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"INSERT INTO ciudad (id_ciudad, nombre)
                                    VALUES(@id_ciudad, @nombre)";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id_ciudad",Ciudad.Id_ciudad);
                cmd.Parameters.AddWithValue("@nombre",Ciudad.Nombre);

                Ciudad.Id_ciudad = Convert.ToInt32(cmd.ExecuteScalar());
            }
           return Ciudad;
        }
    }
}
