using System;
using System.Collections.Generic;
using System.Data;
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
        public static void Create(CiudadEntity Ciudad)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spCreateCiudad", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@pnombre", Ciudad.Nombre);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Get All Ciudades
        /// </summary>
        /// <returns></returns>
        public static List<CiudadEntity> GetAll()
        {
            var list = new List<CiudadEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                using (var cmd = new MySqlCommand("spGetAllCiudades", con))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(LoadCiudades(reader));
                    } 
                }
            }
          return list;
        }


        /// <summary>
        /// Verify if exits City
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool CiudadExits(string name)
        {
            bool resp = false;
            int vnum = 0;

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                using (var cmd = new MySqlCommand("spSearchExistCiudad", con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pnombre", name);
                    cmd.Parameters.Add("@resp", MySqlDbType.Int32);
                    cmd.Parameters["@resp"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    vnum = (Int32) cmd.Parameters["@resp"].Value;

                    if (vnum == 1)
                    {
                        return resp = true;
                    }
                    else if (vnum == 0)
                    {
                        return resp = false;
                    }
                }
            }

           return resp;
        }


        /// <summary>
        ///  Load Ciudades
        /// </summary>
        /// <returns></returns>
        private static CiudadEntity LoadCiudades(IDataReader reader)
        {
            var ciudades = new CiudadEntity();

            ciudades.Id_ciudad = Convert.ToInt32(reader["id_ciudad"]);
            ciudades.Nombre = Convert.ToString(reader["nombre"]);

            return ciudades;
        }
    }
}
