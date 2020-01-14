using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
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
        public static List<ProductosEntity> GetAll()
        {
            List<ProductosEntity> list = new List<ProductosEntity>();
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"SELECT * FROM productos";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(LoadProduct(reader));
                }

            }
          return list;
        }

        /// <summary>
        /// LoadProduct
        /// </summary>
        /// <param name="Reader"></param>
        /// <returns></returns>
        private static ProductosEntity LoadProduct(IDataReader Reader)
        {
            ProductosEntity Productos = new ProductosEntity();

            Productos.Idproducto = Convert.ToUInt32(Reader["idproducto"]);
            Productos.Idfabricante = Convert.ToString(Reader["idfabricante"]);
            Productos.Idfamilia= Convert.ToString(Reader["idfamilia"]);
            Productos.Descripcion = Convert.ToString(Reader["descripcion"]);
            Productos.Stockinicial = Convert.ToInt32(Reader["stockinicial"]);
            Productos.Stockminimo = Convert.ToInt32(Reader["stockminimo"]);
            Productos.F_vencimiento = Convert.ToDateTime(Reader["f_vencimiento"]);
            Productos.Costo = Convert.ToDecimal(Reader["costo"]);
            Productos.Precio_venta = Convert.ToDecimal(Reader["p_venta"]);

            return Productos;

        }
    }
}
