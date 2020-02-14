using System;
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
        /// <summary>
        /// Create Insert head on databases
        /// </summary>
        /// Cretaed: 19/12/2019
        /// <param name="Venta"></param>
        public static void Create(VentaEntity Venta)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {

                con.Open();
                string sql_head = @"INSERT INTO venta (nombre, apellidos, total, created, status, tipo, descuento, subtotal, total_itbis, recibido, devuelta) 
                                        VALUES(@nombre, @apellidos, @total, @created, @status, @tipo, @descuento, @subtotal, @total_itbis, @recibido, @devuelta)";

                using (MySqlCommand cmd = new MySqlCommand(sql_head, con))
                {
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
                    //cmd.Parameters.AddWithValue("@created",DateTime.Now);

                    cmd.ExecuteNonQuery();
                }

                con.Close();
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

                MySqlCommand cmd = new MySqlCommand(sql_detail, con);

                foreach (DetalleVentaEntity dvental in detail.Productos)
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
                    ///
                    ///
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
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
        /// Search Invoices by Number
        /// </summary>
        /// <returns></returns>
        public static List<VentaEntity> SearhByNumber(Int64 number)
        {
            List<VentaEntity> list = new List<VentaEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"SELECT * FROM venta WHERE venta.id=@id";

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
        /// Load table Ventas
        /// </summary>
        /// <returns></returns>
        private static VentaEntity LoadVentas(IDataReader reader)
        {
            VentaEntity venta = new VentaEntity();

            venta.id = Convert.ToInt64(reader["id"]);
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
