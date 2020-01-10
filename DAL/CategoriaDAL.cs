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
                string sql = @"INSERT INTO categories (category_id, category)
                                VALUES(@category_id, @category)";

                MySqlCommand cmd = new MySqlCommand(sql,con);

                cmd.Parameters.AddWithValue("@category_id", Categoria.Category_id);
                cmd.Parameters.AddWithValue("@category",Categoria.Category);

                Categoria.Category_id = Convert.ToInt32(cmd.ExecuteScalar());

            }
          return Categoria;
        }
    }
}
