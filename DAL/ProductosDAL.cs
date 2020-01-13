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
        public static ProductosEntity Create( ProductosEntity Producto)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"INSERT INTO productos (idproducto, idfabricante, descripcion,idfamilia, stockinicial, stockminimo, 
                                f_vencimiento, costo, p_venta, createby, created)
                                VALUES(@idproducto, @idfabricante, @descripcion, @idfamilia, @stockinicial, @stockminimo, 
                                @f_vencimiento, @costo, @p_venta, @createby, @created)";

                MySqlCommand cmd = new MySqlCommand(sql,con);

                cmd.Parameters.AddWithValue("@idproducto", Producto.Idproducto);
                cmd.Parameters.AddWithValue("@idfabricante", Producto.Idfabricante);
                cmd.Parameters.AddWithValue("@descripcion", Producto.Descripcion);
                cmd.Parameters.AddWithValue("@idfamilia", Producto.Idfamilia);
                cmd.Parameters.AddWithValue("@stockinicial", Producto.Stockinicial);
                cmd.Parameters.AddWithValue("@stockminimo", Producto.Stockminimo);
                cmd.Parameters.AddWithValue("@f_vencimiento", Producto.F_vencimiento);
                cmd.Parameters.AddWithValue("@costo", Producto.Costo);
                cmd.Parameters.AddWithValue("@p_venta", Producto.Precio_venta);
                cmd.Parameters.AddWithValue("@createby", Producto.Createby);
                cmd.Parameters.AddWithValue("@created", Producto.Created);

                Producto.Idproducto=Convert.ToInt32(cmd.ExecuteScalar());
            }
          return Producto;
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
