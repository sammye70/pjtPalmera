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
   public class ProductosDAL
    {
        /// <summary>
        /// Create New Product
        /// </summary>
        /// <param name="Producto"></param>
        /// <returns></returns>
        public static ProductosEntity Create( ProductosEntity producto)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"INSERT INTO productos (idproducto, idfabricante, descripcion,idfamilia, stockinicial, stockminimo, 
                                f_vencimiento, costo, p_venta, createby, created)
                                VALUES(@idproducto, @idfabricante, @descripcion, @idfamilia, @stockinicial, @stockminimo, 
                                @f_vencimiento, @costo, @p_venta, @createby, @created)";

                MySqlCommand cmd = new MySqlCommand(sql,con);

                cmd.Parameters.AddWithValue("@idproducto", producto.idproducto);
                cmd.Parameters.AddWithValue("@idfrabricante", producto.idfabricante);
                cmd.Parameters.AddWithValue("@descripcion", producto.descripcion);
                cmd.Parameters.AddWithValue("@idfamilia", producto.idfamilia);
                cmd.Parameters.AddWithValue("@stockinicial", producto.stockinicial);
                cmd.Parameters.AddWithValue("@stockminimo", producto.stockminimo);
                cmd.Parameters.AddWithValue("@f_vencimiento", producto.f_vencimiento);
                cmd.Parameters.AddWithValue("@costo", producto.costo);
                cmd.Parameters.AddWithValue("@p_venta", producto.precio_venta);
                cmd.Parameters.AddWithValue("@createby", producto.createby);
                cmd.Parameters.AddWithValue("@created", producto.created);

                producto.idproducto=Convert.ToInt32(cmd.ExecuteScalar());
            }
          return producto;
        }

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <param name="GetAllProd"></param>
        /// <returns></returns>
        public static ProductosEntity GetAllProductos(ProductosEntity GetAllProd)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"SELECT * FROM productos";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.ExecuteNonQuery();

            }
          return GetAllProd;
        }
    }
}
