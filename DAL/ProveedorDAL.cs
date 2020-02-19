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
                cmd.Parameters.AddWithValue("@created", DateTime.Now);
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
                string sql = @"SELECT * FROM fabricante ORDER BY nombre_fab ASC";

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
        public static List<ProveedorEntity> GetAllByName()
        {
            List<ProveedorEntity> list = new List<ProveedorEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"SELECT nombre_fab FROM fabricante ORDER BY nombre_fab ASC ";

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
        /// Filter proveedor by rnc
        /// </summary>
        /// <param name="code"></param>
        public static List<ProveedorEntity> FilterByRnc(Int64 code)
        {
             List <ProveedorEntity> proveedor = new List<ProveedorEntity>();
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"select * from fabricante WHERE fabricante.rnc=@rnc";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@rnc", code);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    proveedor.Add(LoadProveedor(reader));
                }
            }

            return proveedor;
        }


        /// <summary>
        /// Remove proveedor from DataBases
        /// </summary>
        /// <param name="code"></param>
        public static void RemoveProveedor(Int64 code)
        {
           // ProveedorEntity proveedor = new ProveedorEntity();
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"DELETE from fabricante WHERE idfabricante=@idfabricante";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@idfabricante", code);

                //MySqlDataReader reader = cmd.ExecuteReader();

                cmd.ExecuteNonQuery();
            }
       
        }

        /// <summary>
        /// Search by Code to Update Proveedor
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static ProveedorEntity SearchByCodeUpdate(Int64 code)
        {
             ProveedorEntity proveedor = new ProveedorEntity();
            //List<ProveedorEntity> list = new List<ProveedorEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"SELECT * FROM fabricante WHERE fabricante.idfabricante=@idfabricante";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@idfabricante", code);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    proveedor = (LoadProveedor(reader));
                }
            }
            return proveedor;
        }


        /// <summary>
        /// Update Proveedor Information 
        /// </summary>
        /// <returns></returns>
        public static ProveedorEntity Update(ProveedorEntity Proveedor)
        {
            //ProveedorEntity Proveedor = new ProveedorEntity();
            using (MySqlConnection con = new MySqlConnection (SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"UPDATE fabricante SET fabricante.nombre_fab=@nombre_fab, fabricante.nom_contacto=@nom_contacto, fabricante.tel_contacto=@tel_contacto, 
                                                       fabricante.direccion_fab=@direccion_fab, fabricante.rnc=@rnc, fabricante.limitecredito=@limitecredito
                                WHERE idfabricante=@idfabricante ";
                                                                        // add column Proveedor Telephone in databases

                MySqlCommand cmd = new MySqlCommand(query,con);

                cmd.Parameters.AddWithValue("@idfabricante", Proveedor.Idproveedor);
                cmd.Parameters.AddWithValue("@nombre_fab", Proveedor.Nombre_proveedor);
                cmd.Parameters.AddWithValue("@nom_contacto", Proveedor.Nombre_contacto);
                cmd.Parameters.AddWithValue("@tel_contacto", Proveedor.Tel_contacto);
                cmd.Parameters.AddWithValue("@direccion_fab", Proveedor.Direccion_fab);
                cmd.Parameters.AddWithValue("@rnc", Proveedor.Rnc);
                cmd.Parameters.AddWithValue("@limitecredito", Proveedor.Limitecredito);
                cmd.Parameters.AddWithValue("@modificated", DateTime.Now);

                cmd.ExecuteNonQuery();
            }
            return Proveedor;
        }

        /// <summary>
        ///  Search proveedor by code
        ///  </summary>
        /// <returns></returns>
        public static List<ProveedorEntity> SearchByCode(Int64 code)
        {
           // ProveedorEntity proveedor = new ProveedorEntity();
           List<ProveedorEntity> list = new List<ProveedorEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();                
                string sql = @"SELECT * FROM fabricante WHERE fabricante.idfabricante=@idfabricante";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@idfabricante", code);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(LoadProveed(reader));
                }
            }
            return list;
        }

        /// <summary>
        /// Search Proveedor by Name
        /// </summary>
        /// <param name="rnc"></param>
        /// <returns></returns>
        public static List<ProveedorEntity> SearchByName(string name)
        {
            ProveedorEntity proveedor = new ProveedorEntity();
            List<ProveedorEntity> list = new List<ProveedorEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"SELECT * FROM fabricante WHERE fabricante.nombre_fab LIKE '@nombre_fab%'";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@nombre_fab", name);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(LoadProveed(reader));
                }
            }
            return list;
        }



        /// <summary>
        /// Load proveedor only name
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
            Proveedor.Rnc = Convert.ToInt64(Reader["rnc"]);
            Proveedor.Limitecredito = Convert.ToDecimal(Reader["limitecredito"]);
            Proveedor.Created = Convert.ToDateTime(Reader["created"]);
            //Proveedor.Createby =

            return Proveedor;
        }

    }
}
