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
using System.Net.Http.Headers;

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
                string sql = @"INSERT INTO productos (idproducto, idproveedor, descripcion,idfamilia, stock, stockminimo, 
                                                      f_vencimiento, costo, p_venta, createby, created, status)
                                VALUES(@idproducto, @idproveedor, @descripcion, @idfamilia, @stock, @stockminimo, 
                                       @f_vencimiento, @costo, @p_venta, @createby, @created, @status)";

                MySqlCommand cmd = new MySqlCommand(sql,con);

                cmd.Parameters.AddWithValue("@idproducto", Producto.Codigo);
                cmd.Parameters.AddWithValue("@idproveedor", Producto.Proveedor);
                cmd.Parameters.AddWithValue("@descripcion", Producto.Descripcion);
                cmd.Parameters.AddWithValue("@idfamilia", Producto.Categoria);
                cmd.Parameters.AddWithValue("@stock", Producto.Stock);
                cmd.Parameters.AddWithValue("@stockminimo", Producto.Stockminimo);
                cmd.Parameters.AddWithValue("@f_vencimiento", Producto.Vencimiento);
                cmd.Parameters.AddWithValue("@costo", Producto.Costo);
                cmd.Parameters.AddWithValue("@p_venta", Producto.Precio_venta);
                cmd.Parameters.AddWithValue("@createby", Producto.Creado_por);
                cmd.Parameters.AddWithValue("@created", DateTime.Now);
                cmd.Parameters.AddWithValue("@status",Producto.Estado);

                //Producto.Id=Convert.ToInt32(cmd.ExecuteScalar());
                cmd.ExecuteNonQuery();
            }
          return Producto;
        }

        /// <summary>
        ///  Get Category Status Product
        /// </summary>
        public static List<ProductStatusEntity> GetStatusProduct
        {
            get 
            {
                List<ProductStatusEntity> list = new List<ProductStatusEntity>();

                using (var con = new MySqlConnection(SettingDAL.connectionstring))
                {
                    using (var cmd = new MySqlCommand("spGet_statusProd", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            list.Add(LoadStatus(reader));
                        }
                    }
                    return list;
                }
            }
        }

        /// <summary>
        ///  Filter Product by Category
        /// </summary>
        /// <returns></returns>
        public static List<ProductosEntity> GetProductByCategory(int number)
        {
            var list = new List<ProductosEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                using (var cmd = new MySqlCommand("spSearchByCategory", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@category", number);
                    
                    MySqlDataReader Reader = cmd.ExecuteReader();

                    while (Reader.Read())
                    {
                        list.Add(LoadProduct(Reader));
                    }  
                }

                return list;
            }
        }


        /// <summary>
        /// Get All Products with details
        /// </summary>
        public static List<ProductosEntity> All
        {
            get
            {
                var list = new List<ProductosEntity>();

                using (var con = new MySqlConnection(SettingDAL.connectionstring))
                {
                    using (var cmd = new MySqlCommand("spGet_AllProduct", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            list.Add(LoadProduct(reader));
                        }
                    }
                }
                return list;
            }
        }


        

        /// <summary>
        /// Get Stock for current product
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static decimal getStock(long code)
        {
            decimal result;

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                
                using (var cmd = new MySqlCommand("spGet_stock_product", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idproducto", code);

                    result = Convert.ToDecimal(cmd.ExecuteScalar());
                }
                
                return result;
            }
         
        }

        //----------------------------------------
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
                using (var cmd = new MySqlCommand("spGet_ActProduct", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(LoadProduct(reader));
                    }
                }
            }
            return list;
        }


        /// <summary>
        /// Update Stock (Decrease) on table productos
        /// </summary>
        /// 
        /// Author: Samuel Estrella
        /// First Release: 01/20/2020
        /// Last Release: 05/21/2021
        ///
        public static void Decrease_Stock(VentaEntity venta)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

               // var update_stock = @"UPDATE productos SET productos.stock=productos.stock-@cantidad WHERE productos.idproducto=@idproducto";

                using (var cmd = new MySqlCommand("spDecreaseStockProd", con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (DetalleVentaEntity lsproducto in venta.listProductos)
                    {
                        cmd.Parameters.Clear(); //

                        cmd.Parameters.AddWithValue("@pidproducto", lsproducto.CODIGO);
                        cmd.Parameters.AddWithValue("@pcantidad", lsproducto.CANTIDAD);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Update Stock (inscrement) on table productos
        /// </summary>
        /// 
        /// Author: Samuel Estrella
        /// Created: 07/07/2020
        public static void InscrementAfterDesable(VentaEntity venta)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                string update_stock = @"UPDATE productos SET productos.stock=productos.stock+@cantidad, modificated=@modificated WHERE productos.idproducto=@idproducto";

                MySqlCommand cmd = new MySqlCommand(update_stock, con);

                foreach (DetalleVentaEntity producto in venta.listProductos)
                {
                    cmd.Parameters.Clear(); //

                    cmd.Parameters.AddWithValue("@idproducto", producto.CODIGO);
                    cmd.Parameters.AddWithValue("@cantidad", producto.CANTIDAD);
                    cmd.Parameters.AddWithValue("@modificated", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
        }




        /// <summary>
        /// Update Increment Stock only one product
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

                cmd.Parameters.AddWithValue("@idproducto",producto.Codigo);
                cmd.Parameters.AddWithValue("@cantidad", producto.Stock);
                cmd.Parameters.AddWithValue("@modificated", DateTime.Now);

                // cmd.ExecuteNonQuery();

                producto.Codigo = Convert.ToInt64(cmd.ExecuteScalar());
                //con.Close();   
            }
        }

        /// <summary>
        /// Get Product Where Status Active/Desable
        /// </summary>
        /// <param name="productos"></param>
        /// <returns></returns>
        public static List<ProductosEntity> GetProductosByStatus( int status)
        {
            var list = new List<ProductosEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand ("spGet_ProductByStatus", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@statusp", status);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    { 
                     list.Add(LoadProduct(reader));
                    }
                }
            }

          return list;
        }


        /// <summary>
        /// Get Product Where Status Desable
        /// </summary>
        /// <param name="productos"></param>
        /// <returns></returns>
        public static List<ProductosEntity> GetProductosDesable(ProductosEntity productos)
        {
            var list = new List<ProductosEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                var query = @"SELECT * FROM productos WHERE status=2";

                using (var cmd = new MySqlCommand(query, con))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(LoadProduct(reader));
                    }
                }
            }
            return list;
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

                string query= @"  SELECT SUM(stock) from productos WHERE status=1;";

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
            var ls = new List<ProductosEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spGetMinProduct", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ls.Add(LoadProduct(reader));
                    }
                }
                //cmd.Parameters.AddWithValue("@DateExpire", DateExpire);
            }
            return ls;
        }


        /// <summary>
        /// Filter Product near to expire date
        /// </summary>
        /// <returns></returns>
        public static List<ProductosEntity> ProductExpire   /// Pending to Build
        {
            get
            {
                var list = new List<ProductosEntity>();

                using (var con = new MySqlConnection(SettingDAL.connectionstring))
                {
                    con.Open();
                    string query = @"SELECT * 
                                    FROM productos 
                                    WHERE productos.status='Activo' AND idfamilia !='Escolar'  
                                    ORDER BY productos.f_vencimiento ASC; ";

                    using (var cmd = new MySqlCommand(query, con))
                    {
                        //cmd.Parameters.AddWithValue("@DateExpire", DateExpire);

                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            list.Add(LoadProduct(reader));
                        }
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
                string query = @"UPDATE productos 
                                SET productos.numero=@numero, productos.idproducto=@idproducto, productos.descripcion=@descripcion, productos.f_vencimiento=@f_vencimiento,
                                        productos.p_venta=@p_venta, productos.costo=@costo, productos.idfamilia=@idfamilia, productos.idproveedor=@idproveedor,
                                        productos.stock=@stock, productos.stockminimo=@stockminimo, productos.modificated=@modificated, productos.status=@status   
                                WHERE numero=@numero";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("numero", productos.Orden);
                cmd.Parameters.AddWithValue("@idproducto", productos.Codigo);
                cmd.Parameters.AddWithValue("@descripcion", productos.Descripcion);
                cmd.Parameters.AddWithValue("@f_vencimiento", productos.Vencimiento);
                cmd.Parameters.AddWithValue("@p_venta", productos.Precio_venta);
                cmd.Parameters.AddWithValue("@costo", productos.Costo);
                cmd.Parameters.AddWithValue("@idfamilia", productos.Categoria);
                cmd.Parameters.AddWithValue("@idproveedor", productos.Proveedor);
                cmd.Parameters.AddWithValue("@stock",productos.Stock);
                cmd.Parameters.AddWithValue("@stockminimo", productos.Stockminimo);
                cmd.Parameters.AddWithValue("@status",productos.Estado);
                cmd.Parameters.AddWithValue("@modificated",DateTime.Now);

                 productos.Orden = Convert.ToInt64(cmd.ExecuteScalar());
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
                var query = @"DELETE 
                                    FROM productos 
                                WHERE productos.idproducto=@idproducto;";
                con.Open();
                using(var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@idproducto", code);
                    cmd.ExecuteNonQuery();
                }
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

                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@idproducto", id);

                    value = Convert.ToInt32(cmd.ExecuteScalar());

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
            var productos = new ProductosEntity();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("Get_SearchByOrden", con)) 
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@numero", id);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        productos = (LoadProduct(reader));
                    }
                }
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
       
            var productos = new ProductosEntity();
            productos = null;

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spSearchByCodeActProduct", con))
                { 
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@idproducto", code);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        productos.Codigo = Convert.ToInt64(reader["idproducto"]);
                        productos.Descripcion = Convert.ToString(reader["descripcion"]);
                        productos.Precio_venta = Convert.ToDecimal(reader["p_venta"]);
                    }
                }    
            }
            return productos;
        }


        /// <summary>
        /// Filter Only Active Products by Code
        /// </summary>
        /// <returns></returns>
        public static List<ProductosEntity> FilterProductbyCodeOnlyAct(long id)
        {
           var list = new List<ProductosEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                using (var cmd = new MySqlCommand("spSearchByCodeActProduct", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idproducto", id);

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
        /// Filter All Products by Code
        /// </summary>
        /// <returns></returns>
        public static List<ProductosEntity> FilterProductbyCodeAll(long id)
        {
            var list = new List<ProductosEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {

                using (var cmd = new MySqlCommand("spSearchByCodeAllProduct", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idproducto", id);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(LoadProduct(reader));
                    }
                }
            }
            return list;
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

                using (var cmd = new MySqlCommand("spSearchByDescripcion", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descrip", descripcion);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        productos.Add(LoadProduct(reader));
                    }
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

                var query = @"SELECT * 
                               FROM productos 
                               WHERE productos.status=@status 
                               ORDER BY productos.descripcion ASC;";

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
        /// Load Product Status
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static ProductStatusEntity LoadStatus(IDataReader reader)
        {
            ProductStatusEntity productstatus = new ProductStatusEntity();

            productstatus.Id = Convert.ToInt32(reader["id"]);
            productstatus.Status = Convert.ToString(reader["status"]);

            return productstatus;
        }


        /// <summary>
        /// Load all Detail  about Product
        /// </summary>
        /// <param name="Reader"></param>
        /// <returns></returns>
        private static ProductosEntity LoadProduct(IDataReader Reader)
        {
            var Productos = new ProductosEntity();

            Productos.Orden = Convert.ToInt64(Reader["numero"]);
            Productos.Codigo = Convert.ToInt64(Reader["idproducto"]);
            Productos.Proveedor = Convert.ToString(Reader["idproveedor"]);
            Productos.Categoria= Convert.ToString(Reader["category"]);
            Productos.Descripcion = Convert.ToString(Reader["descripcion"]);
            Productos.Stock = Convert.ToInt32(Reader["stock"]);
            Productos.Stockminimo = Convert.ToInt32(Reader["stockminimo"]);
            Productos.Vencimiento = Convert.ToDateTime(Reader["f_vencimiento"]);
            Productos.Costo = Convert.ToDecimal(Reader["costo"]);
            Productos.Precio_venta = Convert.ToDecimal(Reader["p_venta"]);
            Productos.Estado = Convert.ToString(Reader["estado"]);
            Productos.Creado = Convert.ToDateTime(Reader["created"]);
           // Productos.Modificated = Convert.ToDateTime(Reader["modificated"]);

            return Productos;
        }


       
        /// <summary>
        /// Load  Detail about Product Except cost
        /// </summary>
        /// <param name="Reader"></param>
        /// <returns></returns>
        private static ProductosEntity LoadProductEx(IDataReader Reader)
        {
            ProductosEntity Productos = new ProductosEntity();

            Productos.Orden = Convert.ToInt64(Reader["numero"]);
            Productos.Codigo = Convert.ToInt64(Reader["idproducto"]);
            Productos.Proveedor = Convert.ToString(Reader["idproveedor"]);
            Productos.Categoria = Convert.ToString(Reader["category"]);
            Productos.Descripcion = Convert.ToString(Reader["descripcion"]);
            Productos.Stock = Convert.ToInt32(Reader["stock"]);
            Productos.Stockminimo = Convert.ToInt32(Reader["stockminimo"]);
            Productos.Vencimiento = Convert.ToDateTime(Reader["f_vencimiento"]);
            // Productos.Costo = Convert.ToDecimal(Reader["costo"]);
            Productos.Precio_venta = Convert.ToDecimal(Reader["p_venta"]);
            Productos.Estado = Convert.ToString(Reader["estado"]);
            Productos.Creado = Convert.ToDateTime(Reader["created"]);
           // Productos.Modificated = Convert.ToDateTime(Reader["modificated"]);

            return Productos;
        }




    }
}
