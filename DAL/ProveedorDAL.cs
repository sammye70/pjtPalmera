using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using pjPalmera.Entities;

namespace pjPalmera.DAL
{
   public class ProveedorDAL
    {
        /// <summary>
        /// Create proveedor
        /// </summary>
        /// <param name="Proveedor"></param>
        /// <returns></returns>
        public static ProveedorEntity Create(ProveedorEntity Proveedor)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"INSERT INTO fabricante (nombre_fab, nom_contacto, tel_contacto, direccion_fab, rnc, limitecredito, created, createby)
                               VALUE (@nombre_fab, @nom_contacto, @tel_contacto, @direccion_fab, @rnc, @limitecredito, @created, @createby)";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@nombre_fab", Proveedor.Nombre_proveedor);
                cmd.Parameters.AddWithValue("@nom_contacto", Proveedor.Nombre_contacto);
                cmd.Parameters.AddWithValue("@tel_contacto", Proveedor.Tel_contacto);
                cmd.Parameters.AddWithValue("@direccion_fab", Proveedor.Direccion_fab);
                cmd.Parameters.AddWithValue("@rnc", Proveedor.Rnc);
                cmd.Parameters.AddWithValue("@limitecredito", Proveedor.Limitecredito);
                cmd.Parameters.AddWithValue("@created", Proveedor.Created);
                cmd.Parameters.AddWithValue("@createby", Proveedor.Createby);

                Proveedor.Idproveedor = Convert.ToInt32(cmd.ExecuteScalar());
            }
           return Proveedor;
        }

    }
}
