using System;
using System.Configuration;
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
    public class FacturasDAL
    {
        public static bool result; // Values to invoice return if exist 

        /// <summary>
        /// Create Insert head on databases (Cash)
        /// </summary>
        /// Cretaed: 19/12/2019
        /// <param name="Venta"></param>
        public static void Create(VentaEntity Venta)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                
                con.Open();
                string sql_head = @"INSERT INTO venta (id_cliente, nombre, apellidos, total, created, status, tipo, descuento, subtotal, total_itbis, recibido, devuelta) 
                                        VALUES(@id_cliente, @nombre, @apellidos, @total, @created, @status, @tipo, @descuento, @subtotal, @total_itbis, @recibido, @devuelta)";

                using (MySqlCommand cmd = new MySqlCommand(sql_head, con))
                {
                    cmd.Parameters.AddWithValue("@id_cliente", Venta.id_cliente);
                    cmd.Parameters.AddWithValue("@nombre", Venta.clientes);
                    cmd.Parameters.AddWithValue("@apellidos", Venta.apellidos);
                    cmd.Parameters.AddWithValue("@total", Venta.total);
                    cmd.Parameters.AddWithValue("@created", DateTime.Now);
                    cmd.Parameters.AddWithValue("@status", Venta.status);
                    cmd.Parameters.AddWithValue("@tipo", Venta.tipo);
                    cmd.Parameters.AddWithValue("@descuento", Venta.descuento);
                    cmd.Parameters.AddWithValue("@subtotal", Venta.subtotal);
                    cmd.Parameters.AddWithValue("@total_itbis", Venta.total_itbis);
                    cmd.Parameters.AddWithValue("devuelta", Venta.devuelta);
                    cmd.Parameters.AddWithValue("recibido", Venta.recibido);

                    
                    cmd.ExecuteNonQuery();
                }

             //   con.Close();
            }
        }


        /// <summary>
        /// Create Insert detail on databases
        /// </summary>
        ///Cretaed: 19/01/2020
        /// <param name="detail"></param>
        public static void Created_Detail(VentaEntity detail)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql_detail = @"INSERT INTO detail_venta (idproducto, descripcion, cantidad, precio, itbis, importe, created)
                                        VALUES(@idproducto, @descripcion, @cantidad, @precio, @itbis, @importe, @created)";

                //MySqlCommand cmd = new MySqlCommand(sql_detail, con);
                using ( var cmd = new MySqlCommand(sql_detail, con))
                {
                    foreach (DetalleVentaEntity dvental in detail.listProductos)
                    {
                        //
                        //Remove old parameters
                        //
                        cmd.Parameters.Clear();
                        //
                        cmd.Parameters.AddWithValue("@idproducto", dvental.ID);
                        cmd.Parameters.AddWithValue("@descripcion", dvental.DESCRIPCION);
                        cmd.Parameters.AddWithValue("@cantidad", dvental.CANTIDAD);
                        cmd.Parameters.AddWithValue("@precio", dvental.PRECIO);
                        cmd.Parameters.AddWithValue("@itbis", dvental.ITBIS);
                        cmd.Parameters.AddWithValue("@importe", dvental.IMPORTE);
                        cmd.Parameters.AddWithValue("@created", DateTime.Now);
                        // cmd.Parameters.AddWithValue("@id_venta", detail.id);
                        // cmd.Parameters.AddWithValue("@status", 1);
                        ///
                        ///
                        cmd.ExecuteNonQuery();
                    }
                }
                   
               // con.Close();
            }
        }


        /*-----------------------------------New Test Code---------------------------------------*/
        /// <summary>
        /// Test Process Insert  Invoice Head and Detail
        /// </summary>
        /// <param name="Venta"></param>
        public static void CreateTest(VentaEntity Venta)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                int id;
                con.Open();
                string sql_head = @"INSERT INTO venta (id_cliente, nombre, apellidos, total, created, status, tipo, descuento, subtotal, total_itbis, recibido, devuelta) 
                                        VALUES(@id_cliente, @nombre, @apellidos, @total, @created, @status, @tipo, @descuento, @subtotal, @total_itbis, @recibido, @devuelta)
                                    ";

                using (MySqlCommand cmd = new MySqlCommand(sql_head, con))
                {
                    cmd.Parameters.AddWithValue("@id_cliente", Venta.id_cliente);
                    cmd.Parameters.AddWithValue("@nombre", Venta.clientes);
                    cmd.Parameters.AddWithValue("@apellidos", Venta.apellidos);
                    cmd.Parameters.AddWithValue("@total", Venta.total);
                    cmd.Parameters.AddWithValue("@created", DateTime.Now);
                    cmd.Parameters.AddWithValue("@status", Venta.status);
                    cmd.Parameters.AddWithValue("@tipo", Venta.tipo);
                    cmd.Parameters.AddWithValue("@descuento", Venta.descuento);
                    cmd.Parameters.AddWithValue("@subtotal", Venta.subtotal);
                    cmd.Parameters.AddWithValue("@total_itbis", Venta.total_itbis);
                    cmd.Parameters.AddWithValue("devuelta", Venta.devuelta);
                    cmd.Parameters.AddWithValue("recibido", Venta.recibido);

                    id = Convert.ToInt32(cmd.ExecuteScalar());
                }

                //   con.Close();

                string sql_detail = @"INSERT INTO detail_venta (idproducto, id_venta, descripcion, cantidad, precio, itbis, importe, created)
                                        VALUES(@idproducto, @descripcion, @id_venta, @cantidad, @precio, @itbis, @importe, @created)";

                //MySqlCommand cmd = new MySqlCommand(sql_detail, con);
                using (var cmd = new MySqlCommand(sql_detail, con))
                {
                    foreach (DetalleVentaEntity dvental in Venta.listProductos)
                    {
                        //
                        //Remove old parameters
                        //
                        cmd.Parameters.Clear();
                        //
                        cmd.Parameters.AddWithValue("@idproducto", dvental.ID);
                        cmd.Parameters.AddWithValue("@descripcion", dvental.DESCRIPCION);
                        cmd.Parameters.AddWithValue("@cantidad", dvental.CANTIDAD);
                        cmd.Parameters.AddWithValue("@precio", dvental.PRECIO);
                        cmd.Parameters.AddWithValue("@itbis", dvental.ITBIS);
                        cmd.Parameters.AddWithValue("@importe", dvental.IMPORTE);
                        cmd.Parameters.AddWithValue("@created", DateTime.Now);
                        cmd.Parameters.AddWithValue("@id_venta", id);
                        // cmd.Parameters.AddWithValue("@status", 1);
                        ///
                        ///
                        cmd.ExecuteNonQuery();
                    }

                }
            }
        }

        /*----------------------------------Until Test Code-------------------------------------------------*/



        /// <summary>
        /// Create Insert head on databases (Credit)
        /// </summary>
        /// Cretaed: 19/12/2019
        /// <param name="Venta"></param>
        public static void CreateCr(VentaEntity Venta)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {

                con.Open();
                string sql_head = @"INSERT INTO cxc (id_cliente, nombre, apellidos, monto, created, status) 
                                        VALUES(@id_cliente, @nombre, @apellidos, @monto, @created, @status)";

                using (MySqlCommand cmd = new MySqlCommand(sql_head, con))
                {
                    cmd.Parameters.AddWithValue("@id_cliente", Venta.id_cliente);
                    cmd.Parameters.AddWithValue("@nombre", Venta.clientes);
                    cmd.Parameters.AddWithValue("@apellidos", Venta.apellidos);
                    cmd.Parameters.AddWithValue("@monto", Venta.total);
                    cmd.Parameters.AddWithValue("@created", DateTime.Now);
                    cmd.Parameters.AddWithValue("@status", Venta.status);

                    cmd.ExecuteNonQuery();
                }

              //  con.Close();
            }
        }


        /// <summary>
        /// Verificaty Invoices if Exits or not
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool ExitsInvoice(Int64 number)
        {
           
            //int values;
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                var query = @"SELECT id FROM venta WHERE venta.id=@numero";

                using (var cmd = new MySqlCommand(query, con))
                {
                   cmd.Parameters.AddWithValue("@numero", number);

                    result = Convert.ToBoolean(cmd.ExecuteScalar());

                    if (result == true)
                    {
                        return result = true;
                    }
                    else if (result == false)
                    {
                        return result = false;
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// Change to Status Desable Current Invoice
        /// </summary>
        public static void DesableInvoice(VentaEntity invoice)
        {
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                var query = @"UPDATE venta SET venta.status=@status WHERE venta.id=@id";
                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", invoice.id);
                    cmd.Parameters.AddWithValue("status", invoice.status);

                    cmd.ExecuteNonQuery();
                }
            }
        }



        /// <summary>
        /// Change to Status Enable Current Invoice
        /// </summary>
        public static void EnableInvoice(VentaEntity invoice)
        {
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                var query = @"UPDATE venta SET venta.status=@status WHERE venta.id=@id";
                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", invoice.id);
                    cmd.Parameters.AddWithValue("status", invoice.status);

                    cmd.ExecuteNonQuery();
                }
            }
        }



        /// <summary>
        /// Search Last Invoice Id
        /// </summary>
        /// <param name="id_invoice"></param>
        /// <returns></returns>
        public static int LastId()
        {
            int id;
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"SELECT max(id) from venta;";
               // string query = @"SELECT last_insert_id() from venta;";
                MySqlCommand cmd = new MySqlCommand(query, con);

                id= Convert.ToInt32(cmd.ExecuteScalar());
            }

            return id;
        }


        /// <summary>
        /// Amount Total All Invoices where Active and type iqual cash
        /// </summary>
        /// <returns></returns>
        public static decimal AmountAllInvoices()
        {
            decimal amount;
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"SELECT SUM(total) FROM venta WHERE status='1' AND tipo='1';";

                MySqlCommand cmd = new MySqlCommand(query, con);

                amount = Convert.ToDecimal(cmd.ExecuteScalar());
            }
            return amount;
        }


        /// <summary>
        /// Amount Total All Invoices where Active and type iqual Credit
        /// </summary>
        /// <returns></returns>
        public static decimal AmountAllInvoicesCr()
        {
            decimal amount;
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"SELECT SUM(total) FROM venta WHERE status='1' AND tipo='2';";

                MySqlCommand cmd = new MySqlCommand(query, con);

                amount = Convert.ToDecimal(cmd.ExecuteScalar());
            }
            return amount;
        }


        /// <summary>
        /// Get All Bills
        /// </summary>
        public static List<VentaEntity> GetAll()
        {
            List<VentaEntity> list = new List<VentaEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"select * from venta ORDER BY created DESC";

                MySqlCommand cmd = new MySqlCommand(query,con);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(LoadVentas(reader));
                }

                return list;
            }
        }

        /// <summary>
        /// Get All Credit Invoices
        /// </summary>
        public static List<VentaEntity> GetCreditInvoices()
        {
            List<VentaEntity> list = new List<VentaEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"select * from venta WHERE venta.tipo='2' ORDER BY created DESC";

                MySqlCommand cmd = new MySqlCommand(query, con);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(LoadVentas(reader));
                }

                return list;
            }
        }


        /// <summary>
        /// Get All Cash Invoices
        /// </summary>
        public static List<VentaEntity> GetCashInvoices()
        {
            List<VentaEntity> list = new List<VentaEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"select * from venta WHERE venta.tipo='1' AND venta.status='1' ORDER BY created DESC";

                MySqlCommand cmd = new MySqlCommand(query, con);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(LoadVentas(reader));
                }

                return list;
            }
        }

        /// <summary>
        /// Get All Invoices Desable
        /// </summary>
        /// <returns></returns>
        public static List<VentaEntity> GetInvoiceDesable()
        {
            List<VentaEntity> list = new List<VentaEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"select * from venta WHERE venta.status='2' ORDER BY created DESC";

                MySqlCommand cmd = new MySqlCommand(query, con);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(LoadVentas(reader));
                }
            }

            return list;

        }


        /// <summary>
        /// Search Invoices by Number and type equial to Cash
        /// </summary>
        /// <returns></returns>
        public static List<VentaEntity> SearhByNumber(Int64 number)
        {
            List<VentaEntity> list = new List<VentaEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"SELECT * FROM venta WHERE venta.id=@id and venta.tipo='1'";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", number);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(LoadVentas(reader));
                }
                return list;
            }
        }


        /// <summary>
        /// Search Invoices by Number and type equial to credit
        /// </summary>
        /// <returns></returns>
        public static List<VentaEntity> SearhByNumberCr(Int64 number)
        {
            List<VentaEntity> list = new List<VentaEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"SELECT * FROM venta WHERE venta.id=@id and venta.tipo='2'";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", number);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(LoadVentas(reader));
                }
                return list;
            }
        }


        /// <summary>
        /// Search Invoices by Date
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static List<VentaEntity> SearhByDate(string DateBegin, string DateUntil)
        {
            List<VentaEntity> list = new List<VentaEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"SELECT * FROM venta WHERE venta.id=@id";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@created1", DateBegin);
                cmd.Parameters.AddWithValue("@created2", DateUntil);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(LoadVentas(reader));
                }
                return list;
            }
        }

        /// <summary>
        /// Get All Product in Invoices
        /// </summary>
        /// <returns></returns>
        public static List<ProductosVendidosEntity> GetAllProducInvoices()
        {
            List<ProductosVendidosEntity> list = new List<ProductosVendidosEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"SELECT idproducto, descripcion, cantidad, created FROM detail_venta";

                MySqlCommand cmd = new MySqlCommand(query, con);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(LoadProductVend(reader));
                }

                return list;
            }
        }

        /// <summary>
        /// Load All Product in Invoices
        /// </summary>
        /// <returns></returns>
        private static ProductosVendidosEntity LoadProductVend(IDataReader reader)
        {
            ProductosVendidosEntity productVent = new ProductosVendidosEntity();

            productVent.ID = Convert.ToInt64(reader ["idproducto"]);
            productVent.DESCRIPCION = Convert.ToString (reader["descripcion"]);
            productVent.CANTIDAD = Convert.ToInt32(reader["cantidad"]);
            productVent.FECHA_VENTA = Convert.ToDateTime(reader["created"]);

            return productVent;
        }


        /// <summary>
        /// Load table Ventas
        /// </summary>
        /// <returns></returns>
        private static VentaEntity LoadVentas(IDataReader reader)
        {
            VentaEntity venta = new VentaEntity();

            venta.id = Convert.ToInt32(reader["id"]);
            venta.clientes = Convert.ToString(reader["nombre"]);
            venta.apellidos = Convert.ToString(reader["apellidos"]);
            venta.fecha = Convert.ToDateTime(reader["created"]);
            venta.total = Convert.ToDecimal(reader["total"]);
            venta.status = Convert.ToInt32(reader["status"]);
            venta.descuento = Convert.ToDecimal(reader["descuento"]);
            venta.tipo = Convert.ToString(reader["tipo"]);
            venta.recibido = Convert.ToDecimal(reader["recibido"]);
            venta.devuelta = Convert.ToDecimal(reader["devuelta"]);
            venta.subtotal = Convert.ToDecimal(reader["subtotal"]);
            venta.total_itbis = Convert.ToDecimal(reader["total_itbis"]);
            
            return venta;
        }
    }
}
