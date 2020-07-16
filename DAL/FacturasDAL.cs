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



        /***********************************************************************************************************
        // Name: Create New Invoice (Head and Detail)
        // Created: 02/07/2020
        // Author: Samuel Estrella
        // Modificated date: 
        // Modificated by: Samuel Estrella
        //*********************************************************************************************************/


        //public static bool result; // Values to invoice return if exist 

        /// <summary>
        /// New Process Insert  Invoice Head and Detail
        /// </summary>
        /// <return>invoices fill</return>
        /// <param name="Venta"></param>
        public static VentaEntity Create(VentaEntity Venta)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                int id_venta;
                con.Open();
                var sql_head = @"INSERT INTO venta (id_cliente, nombre, apellidos, total, created, status, tipo, descuento, subtotal, total_itbis, recibido, devuelta, modificated, id_caja, vendedor) 
                                        VALUES (@id_cliente, @nombre, @apellidos, @total, @created, @status, @tipo, @descuento, @subtotal, @total_itbis, @recibido, @devuelta, @modificated, @id_caja, @vendedor);
                                SELECT LAST_INSERT_ID() 
                                    FROM venta;";

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
                    cmd.Parameters.AddWithValue("@devuelta", Venta.devuelta);
                    cmd.Parameters.AddWithValue("@recibido", Venta.recibido);
                    cmd.Parameters.AddWithValue("@modificated", DateTime.Now);
                    cmd.Parameters.AddWithValue("@id_caja", Venta.id_caja);
                    cmd.Parameters.AddWithValue("@vendedor",Venta.id_vendedor );

                    id_venta = Convert.ToInt32(cmd.ExecuteScalar());
                    Venta.id = id_venta;
                }

                var sql_detail = @"INSERT INTO detail_venta (idproducto, descripcion, cantidad, precio, itbis, importe, id_venta, created)
                                        VALUES(@idproducto, @descripcion, @cantidad, @precio, @itbis, @importe, @id_venta, @created);";

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
                        cmd.Parameters.AddWithValue("@idproducto", dvental.CODIGO);
                        cmd.Parameters.AddWithValue("@descripcion", dvental.DESCRIPCION);
                        cmd.Parameters.AddWithValue("@cantidad", dvental.CANTIDAD);
                        cmd.Parameters.AddWithValue("@precio", dvental.PRECIO);
                        cmd.Parameters.AddWithValue("@itbis", dvental.ITBIS);
                        cmd.Parameters.AddWithValue("@importe", dvental.IMPORTE);
                        cmd.Parameters.AddWithValue("@id_venta", id_venta);
                        cmd.Parameters.AddWithValue("@created", DateTime.Now); 

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            return Venta;
        }

        //--------------------------------------------- Until Method Create Invoice ------------------------------------------ 

        /// <summary>
        /// Delete Empty Rows in Detail Invoices
        /// </summary>
        public static void DeleteEmptyRow()
        {
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                var query = @"DELETE FROM detail_venta WHERE idproducto = 0;";
                
                var cmd = new MySqlCommand(query, con);

                cmd.ExecuteNonQuery();
            }
        }

        /***********************************************************************************************************
        // Name: Register Daily Transactions 
        // Created: 09/07/2020
        // Author: Samuel Estrella
        // Modificated date: 09/07/2020
        // Modificated by: Samuel Estrella
        //*********************************************************************************************************/


        /// <summary>
        /// Create Daily Transactions Permanents and Temporal
        /// </summary>
        /// <param name="Transaction"></param>
        /// <returns></returns>
        public static void CreateTranstPermant(VentaEntity invoice)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"INSERT INTO daily_transactions_permanent ( status, total, descuento, devuelta, recibido, id_venta, created) 
                                    VALUES (@status, @total, @descuento, @devuelta, @recibido, @id_venta, @created);

                                INSERT INTO daily_transactions_temp (status, total, descuento, devuelta, recibido, id_venta, created)
                                    VALUES (@status, @total, @descuento, @devuelta, @recibido, @id_venta, @created);";

                using (var cmd = new MySqlCommand(query, con)) 
                {
                    cmd.Parameters.AddWithValue("@status", invoice.status);
                    cmd.Parameters.AddWithValue("@total", invoice.total);
                    cmd.Parameters.AddWithValue("@descuento", invoice.descuento);
                    cmd.Parameters.AddWithValue("@devuelta", invoice.devuelta);
                    cmd.Parameters.AddWithValue("@recibido", invoice.recibido);
                    cmd.Parameters.AddWithValue("@id_venta", invoice.id);
                    cmd.Parameters.AddWithValue("@created", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Update Daily Transactions Permanenet and Temporal
        /// </summary>
        /// <param name="transaction"></param>
        public static void UpdateTranst(VentaEntity invoice)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"UPDATE daily_transactions_permanent  SET status=@status, modificated=@modificated WHERE id_venta=@id_venta; 

                                DELETE FROM daily_transactions_temp  WHERE id_venta=@id_venta;";

                using (var cmd = new MySqlCommand(query, con)) 
                {
                    cmd.Parameters.AddWithValue("@modificated", DateTime.Now);
                    cmd.Parameters.AddWithValue("@status", 2);
                    cmd.Parameters.AddWithValue("@id_venta", invoice.id);

                    cmd.ExecuteNonQuery();
                }
            }

        }


        //--------------------------------------------- Until Method Daily Transactions ------------------------------------------ 



        /// <summary>
        /// Change to Status Enable Current Invoice
        /// </summary>
        public static void EnableInvoice(VentaEntity invoice)
        {
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                var query = "UPDATE venta SET venta.status=@status WHERE venta.id=@id";
                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", invoice.id);
                    cmd.Parameters.AddWithValue("status", invoice.status);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Search Last Invoice Id                      -------------------------------> Pedding Working here,    DONE!! this code not work, DELETE there are
        /// </summary>                                                                   new method
        /// <param name="id_invoice"></param>
        /// <returns></returns>
        public static int LastId()
        {
            int id;
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                var query = "SELECT max(id) from venta;";
                
               // string query = @"SELECT last_insert_id() from venta;";
                MySqlCommand cmd = new MySqlCommand(query, con);
              //cmd.CommandType = CommandType.StoredProcedure;
                

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
                var query = "SELECT SUM(total) FROM venta WHERE status='1' AND tipo='1';";

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
                var query = "SELECT SUM(total) FROM venta WHERE status='1' AND tipo='2';";

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
                var query = "select * from venta ORDER BY created DESC";

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
                string query = "select * from venta WHERE venta.tipo='2' ORDER BY created DESC";

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
                string query = "select * from venta WHERE venta.tipo='1' AND venta.status='1' ORDER BY created DESC;" +
                                "DELETE FROM detail_venta  WHERE idproducto = 0; ";

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
        /// Filter Detail Invoice by Id Invoice use to desable current invoice
        /// </summary>
        /// <returns></returns>
        public static List<DetalleVentaEntity> Get_Detail_Invoices(int idventa)
        {
            List<DetalleVentaEntity> list = new List<DetalleVentaEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                var query = @"SELECT * FROM detail_venta WHERE id_venta = @id_venta;";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id_venta", idventa);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(LoadDetailVenta(reader));
                }

            }
                return list;
        }

        /**********************************************************************************************************
        // Name: Desable Invoice ()
        // Created: 02/07/2020
        // Author: Samuel Estrella
        // Modificated date: 
        // Modificated by: Samuel Estrella
        /*********************************************************************************************************/

        /// <summary>
        /// Verificaty Invoices if Exits return true or false else exits (Only active)
        /// </summary>
        /// <param name="number"></param>
        /// <return>Return True if exits and false else</return>
        public static bool ExitsInvoiceAct(int number)
        {
            var result = true;

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                var query = "SELECT id FROM daily_transactions_temp WHERE id_venta=@numero;";

                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@numero", number);

                    result = Convert.ToBoolean(cmd.ExecuteScalar());

                    if (result == true)
                    {
                        result = true;
                    }
                    else if (result == false)
                    {
                        result = false;
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// Verificaty Invoices if Exits return true or false else exits (Only active)
        /// </summary>
        /// <param name="number"></param>
        /// <return>Return True if exits and false else</return>
        public static bool ExitsInvoiceDes(int number)
        {
            var result = true;

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                var query = "SELECT id FROM daily_transactions_permanent WHERE id_venta=@numero;";

                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@numero", number);

                    result = Convert.ToBoolean(cmd.ExecuteScalar());

                    if (result == true)
                    {
                        result = true;
                    }
                    else if (result == false)
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Get Head Invoice by Id use to desable current invoice
        /// </summary>
        /// <param name="idventa"></param>
        /// <returns></returns>
        public static VentaEntity Get_Head_Invoice_ById(int invoice_id)
        {
            var Head_Invoice = new VentaEntity();
            var query = @"SELECT * FROM venta WHERE id=@id_venta;";

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id_venta", invoice_id);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Head_Invoice = (LoadVentas(reader));
                    }
                }
            }

            return Head_Invoice;
        }


        /// <summary>
        ///Get All Detail Invoice by  Invoice id  use to desable current invoices
        /// </summary>
        /// <returns></returns>
        public static List<DetalleVentaEntity> Get_Detail_by_InvoiceId(int invoice_id)
        {
            List<DetalleVentaEntity> list = new List<DetalleVentaEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                var query = @"SELECT * FROM detail_venta WHERE id_venta=@invoice_id;";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@invoice_id", invoice_id);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(LoadDetailVenta(reader));
                }
            }
            return list;
        }


        /// <summary>
        ///  Process Desable  Invoice Head and Detail
        /// </summary>
        /// <param name="Venta"></param>
        public static void DesableInvoice(VentaEntity invoice)
        {
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                //int id_venta;
                con.Open();

                var sql_head = @"UPDATE venta SET venta.status=@status, modificated=@modificated WHERE venta.id = @id;";

                using (var cmd = new MySqlCommand(sql_head, con))
                {
                    cmd.Parameters.AddWithValue("@id", invoice.id);
                    cmd.Parameters.AddWithValue("@status", 2);  // status: 1 Actived, 2 Desabled
                    cmd.Parameters.AddWithValue("@modificated", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }


                var sql_detail = @"INSERT INTO desabled_detail_venta (idproducto, descripcion, cantidad, precio, itbis, importe, id_venta, created, modificated)
                                        VALUES(@idproducto, @descripcion, @cantidad, @precio, @itbis, @importe, @id_venta, @created, @modificated);";

                //MySqlCommand cmd = new MySqlCommand(sql_detail, con);
                using (var cmd = new MySqlCommand(sql_detail, con))
                {
                    foreach (DetalleVentaEntity dvental in invoice.listProductos)
                    {
                        //
                        //Remove old parameters
                        //
                        cmd.Parameters.Clear();
                        //
                        cmd.Parameters.AddWithValue("@idproducto", dvental.CODIGO);
                        cmd.Parameters.AddWithValue("@descripcion", dvental.DESCRIPCION);
                        cmd.Parameters.AddWithValue("@cantidad", dvental.CANTIDAD);
                        cmd.Parameters.AddWithValue("@precio", dvental.PRECIO);
                        cmd.Parameters.AddWithValue("@itbis", dvental.ITBIS);
                        cmd.Parameters.AddWithValue("@importe", dvental.IMPORTE);
                        cmd.Parameters.AddWithValue("@id_venta", dvental.ID_FACTURA);   ///
                        cmd.Parameters.AddWithValue("@created", dvental.CREATED);  //
                        cmd.Parameters.AddWithValue("@modificated", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }
                }

            }
        }

        /// <summary>
        /// Delete Detail Item by id invoice After Disabled Invoice
        /// </summary>
        /// <param name="invoice"></param>
        public static void DeleteDetailByIdInvoice(VentaEntity invoice)
        {
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                var query = "DELETE FROM detail_venta  WHERE detail_venta.id_venta=@id_venta;";

                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id_venta", invoice.id);

                    cmd.ExecuteNonQuery();
                }

            }
        }

        //-----------------------------------------Until Desable Invoice------------------------------------------------------





        /// <summary>
        ///Get All Detail Invoice (cash)   (Long Description)
        /// </summary>
        /// <returns></returns>
        public static List<DetalleVentaEntity> Get_All_Detail_Invoices()
        {
            List<DetalleVentaEntity> list = new List<DetalleVentaEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                var query = @"SELECT * FROM detail_venta ORDER BY id_venta DESC;";

                MySqlCommand cmd = new MySqlCommand(query, con);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(LoadDetailVenta(reader));
                }

            }
            return list;
        }




        /// <summary>
        /// Get All Invoices Desable only Head by this.
        /// </summary>
        /// <returns></returns>
        public static List<VentaEntity> Get_Invoice_Desable()
        {
            List<VentaEntity> list = new List<VentaEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = "select * from venta WHERE venta.status='2' ORDER BY created DESC";

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
                string query = "SELECT * FROM venta WHERE venta.id=@id and venta.tipo='1'";

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
                string query = "SELECT * FROM venta WHERE venta.id=@id and venta.tipo='2'";

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
                string query = "SELECT * FROM venta WHERE venta.id=@id";

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
        /// Get All Product in Invoices   (Short Description)
        /// </summary>
        /// <returns></returns>
        public static List<ProductosVendidosEntity> AllProducInvoices()
        {
            List<ProductosVendidosEntity> list = new List<ProductosVendidosEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = "SELECT idproducto, descripcion, cantidad, created FROM detail_venta";

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
        /// Load All Product in Invoices  (Short Description)
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
        /// Load table Invoice
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
            venta.id_cliente = Convert.ToInt32(reader["id_cliente"]);
            venta.id_caja = Convert.ToInt32(reader["id_caja"]);
            venta.modificado = Convert.ToDateTime(reader["modificated"]);
            
            return venta;
        }

        /// <summary>
        /// Load Table Detail Invoice (Long Description)
        /// </summary>
        /// <returns></returns>
        private static DetalleVentaEntity LoadDetailVenta(IDataReader reader)
        {
            DetalleVentaEntity detalle = new DetalleVentaEntity();

            // detalle.No = Convert.ToInt32(reader["id"]);
            detalle.ID_FACTURA = Convert.ToInt64(reader["id_venta"]);
            detalle.CODIGO = Convert.ToInt64(reader["idproducto"]);
            detalle.DESCRIPCION = Convert.ToString(reader["descripcion"]);
            detalle.CANTIDAD = Convert.ToInt32(reader["cantidad"]);
            detalle.PRECIO = Convert.ToDecimal(reader["precio"]);
            detalle.ITBIS = Convert.ToDecimal(reader["itbis"]);
            detalle.IMPORTE = Convert.ToDecimal(reader["importe"]);
            detalle.CREATED = Convert.ToDateTime(reader["created"]);

            return detalle;
        }

    }
}
