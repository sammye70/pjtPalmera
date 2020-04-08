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
                                                      f_vencimiento, costo, p_venta, createby, created, status)
                                VALUES(@idproducto, @idfabricante, @descripcion, @idfamilia, @stock, @stockminimo, 
                                       @f_vencimiento, @costo, @p_venta, @createby, @created, @status)";

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
                cmd.Parameters.AddWithValue("@status",Producto.Status);

                //Producto.Id=Convert.ToInt32(cmd.ExecuteScalar());
                cmd.ExecuteNonQuery();
            }
          return Producto;
        }


        /// <summary>
        /// Get All Products
        /// </summary>
        /// <param name="GetAllProd"></param>
        /// <returns></returns>
        public static List<ProductosEntity> All
        {
            get
            {
                List<ProductosEntity> list = new List<ProductosEntity>();

                using (var con = new MySqlConnection(SettingDAL.connectionstring))
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
                }
                return list;
            }
        }

        /// <summary>
        /// Amount Total Cost All Products where only status Active
        /// </summary>
        /// <returns></returns>
        public static decimal GetAmountAllProducts()
        {
            decimal amount;
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
              //  string query = @"SELECT SUM(stock*costo) FROM productos;";
                string query = @"SELECT SUM(stock*costo) FROM productos WHERE status='Activo';";

                MySqlCommand cmd = new MySqlCommand(query, con);

                amount = Convert.ToDecimal(cmd.ExecuteScalar());
            }
           return amount;
        }


        /// <summary>
        /// Filter product and show only active
        /// </summary>
        /// <returns></returns>
        public static List<ProductosEntity> OnlyActive()
        {
            List<ProductosEntity> list = new List<ProductosEntity>();
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"SELECT * FROM productos 
                                 WHERE productos.status='Activo'  ORDER BY descripcion ASC";

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

               string update_stock = @"UPDATE productos SET productos.stock=productos.stock-@cantidad WHERE productos.idproducto=@idproducto";

                MySqlCommand cmd = new MySqlCommand(update_stock, con);

                foreach (DetalleVentaEntity producto in venta.Productos)
                {
                    cmd.Parameters.Clear(); //

                    cmd.Parameters.AddWithValue("@idproducto",producto.ID);
                    cmd.Parameters.AddWithValue("@cantidad", producto.CANTIDAD);

                    cmd.ExecuteNonQuery();
                }
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

                // cmd.ExecuteNonQuery();

                producto.Idproducto = Convert.ToInt64(cmd.ExecuteScalar());
                con.Close();   
            }
        }

        /// <summary>
        /// Count only Active Product
        /// </summary>
        /// <returns></returns>
        public static Int32 CountProduct()
        {
            Int32 count;
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                string query= @"  SELECT SUM(stock) from productos WHERE status='Activo';";

                MySqlCommand cmd = new MySqlCommand(query,con);

                count=Convert.ToInt32(cmd.ExecuteScalar());
            }
            return count;
        }



        /// <summary>
        /// Filter Product near to stock minimal
        /// </summary>
        /// <returns></returns>
        public static List<ProductosEntity> StockMinimo()   /// Pending to Build
        {
            List<ProductosEntity> list = new List<ProductosEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"SELECT  * FROM productos WHERE stock <= stockminimo AND status ='Activo' ORDER BY productos.idfabricante ";

                MySqlCommand cmd = new MySqlCommand(query, con);
                //cmd.Parameters.AddWithValue("@DateExpire", DateExpire);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(LoadProduct(reader));
                }
            }
            return list;
        }


        /// <summary>
        /// Filter Product near to expire date
        /// </summary>
        /// <returns></returns>
        public static List<ProductosEntity> ProductExpire   /// Pending to Build
        {
            get
            {
                List<ProductosEntity> list = new List<ProductosEntity>();

                using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
                {
                    con.Open();
                    string query = @"SELECT * FROM productos WHERE productos.status='Activo' AND idfamilia !='Escolar'  ORDER BY productos.f_vencimiento ASC ";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    //cmd.Parameters.AddWithValue("@DateExpire", DateExpire);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(LoadProduct(reader));
                    }
                }
                return list;
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
                                        productos.stock=@stock, productos.stockminimo=@stockminimo, productos.modificated=@modificated, productos.status=@status   
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
                cmd.Parameters.AddWithValue("@modificated",DateTime.Now);

                 productos.Orden = Convert.ToInt64(cmd.ExecuteScalar());
                con.Close();
            }
        }


        /// <summary>
        /// Remove Product from DataBases
        /// </summary>
        /// <returns></returns>
        public static void DeleteProduct(long code)
        {
         
           // ProductosEntity productos = new ProductosEntity();
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"DELETE from productos WHERE productos.idproducto=@idproducto";
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@idproducto", code);
                //  MySqlDataReader reader = cmd.ExecuteReader();

                cmd.ExecuteNonQuery();
            }
        }


        /// <summary>
        /// Verificate if exist product code
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static bool VerificateCode(long id)
        {
            bool result;
            int value;
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"SELECT idproduct from productos WHERE idproducto=@idproducto";

                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@idproducto", id);

                 value= Convert.ToInt32(cmd.ExecuteScalar());

                if (value != 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }


        /// <summary>
        /// Filter product by Expire Date (Month and Year)
        /// </summary>
        public static List<ProductosEntity> ExpireDate(int month, int year)
        {
            List<ProductosEntity> productos = new List<ProductosEntity>();
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"SELECT * FROM productos WHERE MONTH(f_vencimiento)=@month AND YEAR(f_vencimiento)=@year AND status='Activo'";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    productos.Add(LoadProduct(reader));
                }
            }
                return productos;
        }


        /// <summary>
        /// Filter product Expire Date by Year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static List<ProductosEntity> ExpireYear(int year)
        {
            List<ProductosEntity> productos = new List<ProductosEntity>();
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"SELECT * FROM productos WHERE YEAR(f_vencimiento)=@year AND status='Activo' ORDER BY f_vencimiento ASC";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@year", year);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    productos.Add(LoadProduct(reader));
                }
            }
            return productos;
        }


        /// <summary>
        /// Search Products by Orden
        /// </summary>
        public static ProductosEntity SearchByOrden(long id)
        {
            //List<ProductosEntity> productos = new List<ProductosEntity>();
            ProductosEntity productos = new ProductosEntity();
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
               
               // ProductosEntity productos = new ProductosEntity();
                string search_number = @"select * from productos where productos.numero=@numero";

                MySqlCommand cmd = new MySqlCommand(search_number, con);

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
        /// Search Products by Code
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ProductosEntity SearchByCode(long code)
        {
            //List<ProductosEntity> productos = new List<ProductosEntity>();
            ProductosEntity productos = new ProductosEntity();
            productos = null;
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                // ProductosEntity productos = new ProductosEntity();
                string search_code = @"select * from productos where productos.idproducto=@idproducto";

                MySqlCommand cmd = new MySqlCommand(search_code, con);

                cmd.Parameters.AddWithValue("@idproducto", code);


                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    productos.Idproducto = Convert.ToInt64(reader["idproducto"]);
                    productos.Descripcion = Convert.ToString(reader["descripcion"]);
                    productos.Precio_venta = Convert.ToDecimal(reader["p_venta"]);
                }
            }
            return productos;
        }


        /// <summary>
        /// Filter Products by Code
        /// </summary>
        /// <returns></returns>
        public static List<ProductosEntity> FilterProductbyCode(long id)
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
        /// Filter Products by Description
        /// </summary>
        /// <returns></returns>
        public static List<ProductosEntity> FilterProductbyDescp(string descripcion)
        {
            List<ProductosEntity> productos = new List<ProductosEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                string query = @"SELECT * FROM productos WHERE productos.descripcion LIKE @descripcion%";

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
        /// Filter Product By Status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static List<ProductosEntity> FilterByStatus(string status)
        {
            List<ProductosEntity> producto = new List<ProductosEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                string query = @"SELECT * FROM productos WHERE productos.status=@status ORDER BY productos.descripcion ASC";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@status", status);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    producto.Add(LoadProduct(reader));
                }
            }
            return producto;
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
            Productos.Status = Convert.ToString(Reader["status"]);
            Productos.Created = Convert.ToDateTime(Reader["created"]);

            return Productos;
        }
    }
}
