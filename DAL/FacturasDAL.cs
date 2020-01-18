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
                string sql_head = @"INSERT INTO venta (nombre, apellidos, total, created, status, tipo, descuento, subtotal, total_itbis) 
                                        VALUES(@nombre, @apellidos, @total, @created, @status, @tipo, @descuento, @subtotal, @total_itbis)";

                using (MySqlCommand cmd = new MySqlCommand(sql_head, con))
                {
                    cmd.Parameters.AddWithValue("@nombre", Venta.clientes);
                    cmd.Parameters.AddWithValue("@apellidos", Venta.apellidos);
                    cmd.Parameters.AddWithValue("@total",Venta.total);
                    cmd.Parameters.AddWithValue("@created",Venta.f_factura);
                    cmd.Parameters.AddWithValue("@status", Venta.status);
                    cmd.Parameters.AddWithValue("@tipo",Venta.tipo);
                    cmd.Parameters.AddWithValue("@descuento", Venta.descuento);
                    cmd.Parameters.AddWithValue("@subtotal", Venta.subtotal);
                    cmd.Parameters.AddWithValue("@total_itbis", Venta.total_itbis);

                    cmd.ExecuteNonQuery();
                  
                }
                //--------------------------------------
                //
                //
                //
                string sql_detail = @"INSERT INTO detail_venta (id_producto, descripcion, cantidad, precio, itbis, importe)
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
                        cmd.Parameters.AddWithValue("@id_producto", dvental.ID);
                        cmd.Parameters.AddWithValue("@descripcion", dvental.DESCRIPCION);
                        cmd.Parameters.AddWithValue("@cantidad", dvental.CANTIDAD);
                        cmd.Parameters.AddWithValue("@precio", dvental.PRECIO);
                        cmd.Parameters.AddWithValue("@itbis", dvental.ITBIS);
                        cmd.Parameters.AddWithValue("@importe", dvental.IMPORTE);

                        ///
                        ///
                        cmd.ExecuteNonQuery();

                    }

                }
            }

            
        }
    }
}
