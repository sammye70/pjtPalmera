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
    public class ProvinciaDAL
    {
        /// <summary>
        /// Create Province
        /// </summary>
        /// <param name="Provincia"></param>
        /// <returns></returns>
        public static ProvinciaEntity Create(ProvinciaEntity Provincia)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"INSERT INTO provincia (id_provincia, nombre)
                                    VALUES(@id_provincia, @nombre)";
                MySqlCommand cmd = new MySqlCommand(sql,con);

                cmd.Parameters.AddWithValue("@id_provincia", Provincia.Id_provincia);
                cmd.Parameters.AddWithValue("@nombre", Provincia.Nombre);

                Provincia.Id_provincia = Convert.ToInt32(cmd.ExecuteScalar());
            }
           return Provincia;
        }

    }
}
