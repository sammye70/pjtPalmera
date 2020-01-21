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
                cmd.Parameters.AddWithValue("@stockinicial", Producto.Stock);
                cmd.Parameters.AddWithValue("@stockminimo", Producto.Stockminimo);
                cmd.Parameters.AddWithValue("@f_vencimiento", Producto.Vencimiento);
                cmd.Parameters.AddWithValue("@costo", Producto.Costo);
                cmd.Parameters.AddWithValue("@p_venta", Producto.Precio_venta);
                cmd.Parameters.AddWithValue("@createby", Producto.Createby);
                cmd.Parameters.AddWithValue("@created", DateTime.Now);

                //Producto.Id=Convert.ToInt32(cmd.ExecuteScalar());
                cmd.ExecuteNonQuery();
                con.Close();
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
                con.Close();
            }
          return list;
        }


        /// <summary>
        /// Update Stock on table productos
        /// </summary>
        /// 
        /// Author: Samuel Estrella
        /// Created: 21/01/2020
        /// Modificated: 21/01/2020
        /// Modificated by:
        public static void Decrease_Stock(VentaEntity venta)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                ProductosEntity product = new ProductosEntity();

               string update_stock = @"UPDATE productos SET productos.stock=productos.stock-@cantidad WHERE idproducto = @idproducto";
                //string update_stock = @"update productos set stock = stock - @cantidad where idproducto = @idproducto";

                MySqlCommand cmd = new MySqlCommand(update_stock, con);

                cmd.Parameters.Clear();

                foreach (DetalleVentaEntity producto in venta.Productos)
                {
                    cmd.Parameters.AddWithValue("@idproducto",producto.ID);
                    cmd.Parameters.AddWithValue("@cantidad", producto.CANTIDAD); 
                }

                product.Idproducto = Convert.ToInt64(cmd.ExecuteScalar());

                con.Close();
            }
        }


        /// <summary>
        /// Update Increment Stock
        /// </summary>
        /// 
        /// Author: Samuel Estrella
        /// Created: 21/01/2020
        /// Modificated: 21/01/2020
        /// Modificated by:
        public static void Increment_Stock(ProductosEntity producto)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string update_stock = @"UPDATE productos SET productos.stock=productos.stock+@cantidad, productos.modificated=@modificated  
                                        WHERE idproducto = @idproducto";

                MySqlCommand cmd = new MySqlCommand(update_stock, con);

                cmd.Parameters.AddWithValue("@idproducto",producto.Idproducto);
                cmd.Parameters.AddWithValue("@cantidad", producto.Stock);
                cmd.Parameters.AddWithValue("@modificated", DateTime.Now);

                producto.Idproducto = Convert.ToInt64(cmd.ExecuteScalar());
                con.Close();   
            }
        }


        /// <summary>
        /// LoadProduct
        /// </summary>
        /// <param name="Reader"></param>
        /// <returns></returns>
        private static ProductosEntity LoadProduct(IDataReader Reader)
        {
            ProductosEntity Productos = new ProductosEntity();

            Productos.Idproducto = Convert.ToInt64(Reader["idproducto"]);
            Productos.Idfabricante = Convert.ToString(Reader["idfabricante"]);
            Productos.Idfamilia= Convert.ToString(Reader["idfamilia"]);
            Productos.Descripcion = Convert.ToString(Reader["descripcion"]);
            Productos.Stock = Convert.ToInt32(Reader["stock"]);
            Productos.Stockminimo = Convert.ToInt32(Reader["stockminimo"]);
            Productos.Vencimiento = Convert.ToDateTime(Reader["f_vencimiento"]);
            Productos.Costo = Convert.ToDecimal(Reader["costo"]);
            Productos.Precio_venta = Convert.ToDecimal(Reader["p_venta"]);
            Productos.Created = Convert.ToDateTime(Reader["created"]);

            return Productos;
        }
    }
}
