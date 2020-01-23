using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using System.Data;
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


        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        public static List<ProveedorEntity> GetAll()
        {
            List<ProveedorEntity> list = new List<ProveedorEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"SELECT * FROM fabricante";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(LoadProveedor(reader));
                }

            }

             return list;
        }



        /// <summary>
        /// Get All only: nombre
        /// </summary>
        /// <returns></returns>
        public static List<ProveedorEntity> GetAll_()
        {
            List<ProveedorEntity> list = new List<ProveedorEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"SELECT nombre_fab FROM fabricante";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(LoadProveed(reader));
                }

            }

            return list;
        }


        /// <summary>
        /// Load proveedor
        /// </summary>
        /// <returns></returns>
        private static ProveedorEntity LoadProveed(IDataReader Reader)
        {
            ProveedorEntity Proveedor = new ProveedorEntity();
            Proveedor.Nombre_proveedor = Convert.ToString(Reader["nombre_fab"]);

            return Proveedor;
        }



        /// <summary>
        /// Load proveedor
        /// </summary>
        /// <returns></returns>
        private static ProveedorEntity LoadProveedor(IDataReader Reader)
        {
            ProveedorEntity Proveedor = new ProveedorEntity();

            Proveedor.Idproveedor = Convert.ToInt32(Reader["idfabricante"]);
            Proveedor.Nombre_proveedor = Convert.ToString(Reader["nombre_fab"]);
            Proveedor.Nombre_contacto = Convert.ToString(Reader["nom_contacto"]);
            Proveedor.Tel_contacto = Convert.ToString(Reader["tel_contacto"]);
            Proveedor.Direccion_fab = Convert.ToString(Reader["direccion_fab"]);
            Proveedor.Rnc = Convert.ToString(Reader["rnc"]);
            Proveedor.Limitecredito = Convert.ToDecimal(Reader["limitecredito"]);

            return Proveedor;
        }

    }
}
