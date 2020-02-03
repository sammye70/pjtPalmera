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
                string sql = @"INSERT INTO productos (idproducto, idfabricante, descripcion,idfamilia, stock, stockminimo, 
                                                      f_vencimiento, costo, p_venta, createby, created)
                                VALUES(@idproducto, @idfabricante, @descripcion, @idfamilia, @stock, @stockminimo, 
                                       @f_vencimiento, @costo, @p_venta, @createby, @created)";

                MySqlCommand cmd = new MySqlCommand(sql,con);

                cmd.Parameters.AddWithValue("@idproducto", Producto.Idproducto);
                cmd.Parameters.AddWithValue("@idfabricante", Producto.Fabricante);
                cmd.Parameters.AddWithValue("@descripcion", Producto.Descripcion);
                cmd.Parameters.AddWithValue("@idfamilia", Producto.Categoria);
                cmd.Parameters.AddWithValue("@stock", Producto.Stock);
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
                string sql = @"SELECT * FROM productos 
                                     ORDER BY descripcion ASC";

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
        /// Update Stock (Decrease) on table productos
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
        /// Update Information about some product
        /// </summary>
        public static void Update_info_product(ProductosEntity productos)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"UPDATE productos SET productos.numero=@numero, productos.idproducto=@idproducto, productos.descripcion=@descripcion, productos.f_vencimiento=@f_vencimiento,
                                        productos.p_venta=@p_venta, productos.costo=@costo, productos.idfamilia=@idfamilia, productos.idfabricante=@idfabricante,
                                        productos.stock=@stock, productos.stockminimo=@stockminimo   
                                WHERE numero=@numero";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("numero", productos.Orden);
                cmd.Parameters.AddWithValue("@idproducto", productos.Idproducto);
                cmd.Parameters.AddWithValue("@descripcion", productos.Descripcion);
                cmd.Parameters.AddWithValue("@f_vencimiento", productos.Vencimiento);
                cmd.Parameters.AddWithValue("@p_venta", productos.Precio_venta);
                cmd.Parameters.AddWithValue("@costo", productos.Costo);
                cmd.Parameters.AddWithValue("@idfamilia", productos.Categoria);
                cmd.Parameters.AddWithValue("@idfabricante", productos.Fabricante);
                cmd.Parameters.AddWithValue("@stock",productos.Stock);
                cmd.Parameters.AddWithValue("@stockminimo", productos.Stockminimo);
                cmd.Parameters.AddWithValue("@status",productos.Status);

                 productos.Orden = Convert.ToInt64(cmd.ExecuteScalar());
                con.Close();
            }
        }


        /// <summary>
        /// Search Products by Code
        /// </summary>
        public static ProductosEntity Search_Code(Int64 id)
        {
            //List<ProductosEntity> productos = new List<ProductosEntity>();
            ProductosEntity productos = new ProductosEntity();
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
               
               // ProductosEntity productos = new ProductosEntity();
                string search_code = @"select * from productos where productos.numero=@numero";

                MySqlCommand cmd = new MySqlCommand(search_code, con);

                cmd.Parameters.AddWithValue("@numero", id);
                

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    productos=(LoadProduct(reader));
                }
                con.Close();
            }
            return productos;
        }
        


        /// <summary>
        /// Filter Products by Code
        /// </summary>
        /// <returns></returns>
        public static List<ProductosEntity> FilterProductbyCode(Int64 id)
        {
           List<ProductosEntity> productos = new List<ProductosEntity>();
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                string query = @"select * from productos where productos.idproducto=@idproducto";

                MySqlCommand cmd = new MySqlCommand(query,con);

                cmd.Parameters.AddWithValue("@idproducto", id);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    productos.Add(LoadProduct(reader));
                }
            }
                return productos;
        }

        /// <summary>
        /// Filter Products by Code
        /// </summary>
        /// <returns></returns>
        public static List<ProductosEntity> FilterProductbyDescp(string descripcion)
        {
            List<ProductosEntity> productos = new List<ProductosEntity>();
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                string query = @"SELECT * FROM productos WHERE productos.descripcion LIKE '@descripcion%'";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@descripcion", descripcion);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    productos.Add(LoadProduct(reader));
                }
            }
            return productos;
        }

        /// <summary>
        /// LoadProduct
        /// </summary>
        /// <param name="Reader"></param>
        /// <returns></returns>
        private static ProductosEntity LoadProduct(IDataReader Reader)
        {
            ProductosEntity Productos = new ProductosEntity();

            Productos.Orden = Convert.ToInt64(Reader["numero"]);
            Productos.Idproducto = Convert.ToInt64(Reader["idproducto"]);
            Productos.Fabricante = Convert.ToString(Reader["idfabricante"]);
            Productos.Categoria= Convert.ToString(Reader["idfamilia"]);
            Productos.Descripcion = Convert.ToString(Reader["descripcion"]);
            Productos.Stock = Convert.ToInt32(Reader["stock"]);
            Productos.Stockminimo = Convert.ToInt32(Reader["stockminimo"]);
            Productos.Vencimiento = Convert.ToDateTime(Reader["f_vencimiento"]);
            Productos.Costo = Convert.ToDecimal(Reader["costo"]);
            Productos.Precio_venta = Convert.ToDecimal(Reader["p_venta"]);
            Productos.Created = Convert.ToDateTime(Reader["created"]);
            Productos.Status = Convert.ToString(Reader["status"]);

            return Productos;
        }
    }
}
