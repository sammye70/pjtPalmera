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
    public class ProvinciaDAL
    {
        /// <summary>
        /// Create Province
        /// </summary>
        /// <param name="Provincia"></param>
        /// <returns></returns>
        public static ProvinciaEntity Create(ProvinciaEntity Provincia)
        {
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                using (var cmd = new MySqlCommand("spCreateProvincia", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@pnombre", Provincia.Nombre);
                    cmd.ExecuteNonQuery();
                }
            }
           return Provincia;
        }

        /// <summary>
        /// Get All Provincias
        /// </summary>
        public static List<ProvinciaEntity> GetAll()
        {
            var list = new List<ProvinciaEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                using (var cmd = new MySqlCommand("spGetAllProvincias", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                   

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(LoadPronvicias(reader));
                    }
                }
             return list;
            }
        }

        /// <summary>
        ///  Verify if exits provincia rnc
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ExitsProvincia(string name)
        {
            int rnum = 0;
            bool resp = false;

            using (var con = new MySqlConnection(SettingDAL.connectionstring)) 
            {
                con.Open();

                using (var cmd = new MySqlCommand("spSearchExistProvincia", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pnombre", name);
                    cmd.Parameters.Add("@resp", MySqlDbType.Int32);
                    cmd.Parameters["@resp"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    rnum = (Int32) cmd.Parameters["@resp"].Value;

                    if (rnum == 1)
                    {
                        return resp = true;
                    }
                    else if (rnum == 0)
                    {
                        return resp = false;
                    }
                }
            }
            return resp;
        }


        /// <summary>
        /// Load Detail Provincias 
        /// </summary>
        /// <returns></returns>
        private static ProvinciaEntity LoadPronvicias(IDataReader reader)
        {
            ProvinciaEntity provincia = new ProvinciaEntity();

            provincia.Id_provincia = Convert.ToInt32(reader["id_provincia"]);
            provincia.Nombre = Convert.ToString(reader["nombre"]);

            return provincia;
        }

    }
}
