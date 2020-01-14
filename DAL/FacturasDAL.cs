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
                ///
                ///
                ///
                con.Open();
                string sql_head = @"INSER INTO venta (id_cliente, nombre, apellidos, total, created, status, ncf, tipo, vendedor, descuento, subtotal, total_itbis) 
                                        VALUES(@id_cliente, @nombre, @apellidos, @total, @created, @status, @ncf, @tipo, @vendedor, @descuento, @subtotal, @total_itbis)";

                using (MySqlCommand cmd = new MySqlCommand(sql_head, con))
                {
                    cmd.Parameters.AddWithValue("@id_cliente",Venta.Id_cliente);
                    cmd.Parameters.AddWithValue("@nombre",Venta.Nombre);
                    cmd.Parameters.AddWithValue("@apellidos",Venta.Apellidos);
                    cmd.Parameters.AddWithValue("@total", 0);
                    cmd.Parameters.AddWithValue("@created",Venta.Fecha);
                    cmd.Parameters.AddWithValue("@status",Venta.Status);
                    cmd.Parameters.AddWithValue("@ncf",Venta.Ncf);
                    cmd.Parameters.AddWithValue("@tipo",Venta.Tipo);
                    cmd.Parameters.AddWithValue("@vendedor",Venta.Vendedor);
                    cmd.Parameters.AddWithValue("@descuento", Venta.Descuento);
                    cmd.Parameters.AddWithValue("@subtotal", Venta.Subtotal);
                    cmd.Parameters.AddWithValue("@total_itbis", Venta.Total_itbis);

                    Venta.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
                ///--------------------------------------
                ///
                ///
                ///
                string sql_detail = @"INSERT INTO (id_producto, descripcion, cantidad, precio, itbis, importe)
                                        VALUES(@id_producto, @descripcion, @cantidad, @precio, @itbis, @importe)";

                using (MySqlCommand cmd = new MySqlCommand(sql_detail, con))
                {

                    foreach (DetalleVentaEntity dvental in Venta.Productos)
                    {
                        //
                        //Remove old parameters
                        //
                        cmd.Parameters.Clear();

                        //
                        cmd.Parameters.AddWithValue("@", Venta);
                        cmd.Parameters.AddWithValue("@", Venta);
                        cmd.Parameters.AddWithValue("@", Venta);
                        cmd.Parameters.AddWithValue("@", Venta);
                        cmd.Parameters.AddWithValue("@", Venta);
                        cmd.Parameters.AddWithValue("@", Venta);
                        cmd.Parameters.AddWithValue("@", Venta);

                        ///
                        ///
                        dvental.ID = Convert.ToInt32(cmd.ExecuteScalar());

                    }

                }
            }

            
        }
    }
}
