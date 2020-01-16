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
        public static void Create(VentaEntity Venta)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                 
                con.Open();
                string sql_head = @"INSERT INTO venta (nombre, apellidos, total, created, status, tipo) 
                                        VALUES(@nombre, @apellidos, @total, @created, @status, @tipo)";

                using (MySqlCommand cmd = new MySqlCommand(sql_head, con))
                {
                    cmd.Parameters.AddWithValue("@nombre", Venta.clientes);
                    cmd.Parameters.AddWithValue("@apellidos", Venta.apellidos);
                    cmd.Parameters.AddWithValue("@total",Venta.total);
                    cmd.Parameters.AddWithValue("@created",Venta.f_factura);
                    cmd.Parameters.AddWithValue("@status", Venta.status);
                    cmd.Parameters.AddWithValue("@tipo",Venta.tipo);

                    cmd.ExecuteNonQuery();
                  
                }
                ///--------------------------------------
                ///
                ///
                ///
                //string sql_detail = @"INSERT INTO (id_producto, descripcion, cantidad, precio, itbis, importe)
                //                        VALUES(@id_producto, @descripcion, @cantidad, @precio, @itbis, @importe)";

                //using (MySqlCommand cmd = new MySqlCommand(sql_detail, con))
                //{

                //    foreach (DetalleVentaEntity dvental in Venta.Productos)
                //    {
                //        //
                //        //Remove old parameters
                //        //
                //        cmd.Parameters.Clear();

                //        //
                //        cmd.Parameters.AddWithValue("@", Venta);
                //        cmd.Parameters.AddWithValue("@", Venta);
                //        cmd.Parameters.AddWithValue("@", Venta);
                //        cmd.Parameters.AddWithValue("@", Venta);
                //        cmd.Parameters.AddWithValue("@", Venta);
                //        cmd.Parameters.AddWithValue("@", Venta);
                //        cmd.Parameters.AddWithValue("@", Venta);

                //        ///
                //        ///
                //        dvental.ID = Convert.ToInt32(cmd.ExecuteScalar());

                //    }

                //}
            }

            
        }
    }
}
