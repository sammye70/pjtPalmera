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

                cmd.Parameters.AddWithValue("@category_id", Categoria.Category_id);
                cmd.Parameters.AddWithValue("@category",Categoria.Category);
                cmd.Parameters.AddWithValue("@created", DateTime.Now);

                Categoria.Category_id = Convert.ToInt32(cmd.ExecuteScalar());

            }
          return Categoria;
        }

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns></returns>
        public static List<CategoriaEntity> GetAll_()
        {
            List<CategoriaEntity> list = new List<CategoriaEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                string sql = @"select category from categories";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    list.Add(LoadCategories(reader));
                }

            }
            return list;
        }

        /// <summary>
        /// LoadCategories on Reader
        /// </summary>
        /// <returns></returns>
        private static CategoriaEntity LoadCategories(IDataReader reader)
        {
            CategoriaEntity category = new CategoriaEntity();

            category.Category = Convert.ToString(reader["category"]);
            return category;
        }

    }
}
