using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using pjPalmera.Entities;
using System.Security.Cryptography;

namespace pjPalmera.DAL
{
    public class CategoriaDAL
    {
        /// <summary>
        /// Create Category
        /// </summary>
        /// <param name="Categoria"></param>
        /// <returns></returns>
        public static CategoriaEntity Create(CategoriaEntity Categoria)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"INSERT INTO categories (category_id, category, created)
                                VALUES(@category_id, @category, @created)";

                MySqlCommand cmd = new MySqlCommand(sql,con);

                cmd.Parameters.AddWithValue("@category_id", Categoria.Id);
                cmd.Parameters.AddWithValue("@category",Categoria.Categoria);
                cmd.Parameters.AddWithValue("@created", DateTime.Now);

                Categoria.Id = Convert.ToInt32(cmd.ExecuteScalar());

            }
          return Categoria;
        }

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns></returns>
        public static List<CategoriaEntity> GetCategories()
        {
            List<CategoriaEntity> list = new List<CategoriaEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spGet_Categories", con))
                {
                    con.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(LoadCategories(reader));
                    }
                }
            }
            return list;
        }


        /// <summary>
        /// Verify if exits category
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ExitsCategory(string name)
        {
            bool resp = false;
            int rnum = 0;

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                using (var cmd = new MySqlCommand("spSearchExistCategoria", con))
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
        /// Load Categories on Reader
        /// </summary>
        /// <returns></returns>
        private static CategoriaEntity LoadCategories(IDataReader reader)
        {
            CategoriaEntity category = new CategoriaEntity();

            category.Id = Convert.ToInt32(reader["category_id"]);
            category.Categoria = Convert.ToString(reader["category"]);

            return category;
        }

    }
}
