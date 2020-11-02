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
                string sql = @"INSERT INTO proveedor (nombre_prob, telefono, nom_contacto, tel_contacto, direccion_prob, rnc, limitecredito, created, createby)
                               VALUE (@nombre_prob, @nom_contacto, @telefono, @tel_contacto, @direccion_prob, @rnc, @limitecredito, @created, @createby)";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@nombre_prob", Proveedor.Nombre_proveedor);
                cmd.Parameters.AddWithValue("@nom_contacto", Proveedor.Nombre_contacto);
                cmd.Parameters.AddWithValue("@tel_contacto", Proveedor.Tel_contacto);
                cmd.Parameters.AddWithValue("@direccion_prob", Proveedor.Direccion_prob);
                cmd.Parameters.AddWithValue("@telefono", Proveedor.Tel_proveedor);
                cmd.Parameters.AddWithValue("@rnc", Proveedor.Rnc);
                cmd.Parameters.AddWithValue("@limitecredito", Proveedor.Limitecredito);
                cmd.Parameters.AddWithValue("@created", DateTime.Now);
                cmd.Parameters.AddWithValue("@createby", Proveedor.Createby);

                //Proveedor.Idproveedor = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.ExecuteNonQuery();
            }
           return Proveedor;
        }


        /// <summary>
        /// Verify if exits Proveedor
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool ProveedorExits(string number)
        {
            bool resp = false;
            int vnum = 0;

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spSearchExistProveedor", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prnc", number);
                    cmd.Parameters.Add("@resp", MySqlDbType.Int32);
                    cmd.Parameters["@resp"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    vnum = (Int32)cmd.Parameters["@resp"].Value;

                    if (vnum == 1)
                    {
                        return resp = true;
                    }
                    else if (vnum == 0)
                    {
                        return resp = false;
                    }
                }
            }
            return resp;
        }


        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        public static List<ProveedorEntity> GetAll()
        {
            List<ProveedorEntity> list = new List<ProveedorEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spGet_proveedores", con))
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(LoadProveedor(reader));
                    }
                }
            }
            return list;
        }


        /// <summary>
        /// Get All Preveedor by Name
        /// </summary>
        /// <returns></returns>
        public static List<ProveedorEntity> GetProveedorsByName()
        {
            var list = new List<ProveedorEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spGet_proveedores", con))
                {
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(LoadProveed(reader));
                        
                    }
                }
            }
            return list;
        }


        /// <summary>
        /// Filter proveedor by rnc
        /// </summary>
        /// <param name="code"></param>
        public static List<ProveedorEntity> FilterByRnc(long code)
        {
             List <ProveedorEntity> list = new List<ProveedorEntity>();
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"select * from proveedor WHERE proveedor.rnc=@rnc";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@rnc", code);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    list.Add(LoadProveedor(reader));
                }
            }

            return list;
        }


        /// <summary>
        /// Remove proveedor from DataBases
        /// </summary>
        /// <param name="code"></param>
        public static void RemoveProveedor(long code)
        {
           // ProveedorEntity proveedor = new ProveedorEntity();
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"DELETE from proveedor WHERE idproveedor=@idproveedor";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@idproveedor", code);

                //MySqlDataReader reader = cmd.ExecuteReader();

                cmd.ExecuteNonQuery();
            }
       
        }

        /// <summary>
        /// Search by Code to Update Proveedor
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static ProveedorEntity SearchByCodeUpdate(long code)
        {
             ProveedorEntity proveedor = new ProveedorEntity();
            //List<ProveedorEntity> list = new List<ProveedorEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"SELECT * FROM proveedor WHERE proveedor.idproveedor=@idproveedor";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@idproveedor", code);

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
                string query = @"UPDATE proveedor SET proveedor.nombre=@nombre_prob, telefono=@telefono, proveedor.nom_contacto=@nom_contacto, proveedor.tel_contacto=@tel_contacto, 
                                                       proveedor.direccion_prob=@direccion_prob, proveedor.rnc=@rnc, fabricante.limitecredito=@limitecredito
                                WHERE proveedor.id=@idproveedor ";
                                                                        

                MySqlCommand cmd = new MySqlCommand(query,con);

                cmd.Parameters.AddWithValue("@idfabricante", Proveedor.Idproveedor);
                cmd.Parameters.AddWithValue("@nombre_prob", Proveedor.Nombre_proveedor);
                cmd.Parameters.AddWithValue("@telefono", Proveedor.Tel_proveedor);
                cmd.Parameters.AddWithValue("@nom_contacto", Proveedor.Nombre_contacto);
                cmd.Parameters.AddWithValue("@tel_contacto", Proveedor.Tel_contacto);
                cmd.Parameters.AddWithValue("@direccion_prob", Proveedor.Direccion_prob);
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
        public static List<ProveedorEntity> SearchByCode(long code)
        {
           // ProveedorEntity proveedor = new ProveedorEntity();
           List<ProveedorEntity> list = new List<ProveedorEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();                
                string sql = @"SELECT * FROM proveedor WHERE proveedor.id=@idproveedor";

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
                string sql = @"SELECT * FROM proveedor WHERE proveedor.nombre_fab LIKE '@nombre_prob%'";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@nombre_prob", name);

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

            Proveedor.Idproveedor = Convert.ToInt32(Reader["id"]);
            Proveedor.Nombre_proveedor = Convert.ToString(Reader["nombre"]);
            

            return Proveedor;
        }


        /// <summary>
        /// Load proveedor
        /// </summary>
        /// <returns></returns>
        private static ProveedorEntity LoadProveedor(IDataReader Reader)
        {
            ProveedorEntity Proveedor = new ProveedorEntity();

            Proveedor.Idproveedor = Convert.ToInt32(Reader["id"]);
            Proveedor.Nombre_proveedor = Convert.ToString(Reader["nombre"]);
            Proveedor.Nombre_contacto = Convert.ToString(Reader["nom_contacto"]);
            Proveedor.Tel_contacto = Convert.ToString(Reader["tel_contacto"]);
            Proveedor.Direccion_prob = Convert.ToString(Reader["direccion_prob"]);
            Proveedor.Rnc = Convert.ToInt64(Reader["rnc"]);
            Proveedor.Tel_proveedor = Convert.ToString(Reader["telefono"]);
            Proveedor.Limitecredito = Convert.ToDecimal(Reader["limitecredito"]);
            Proveedor.Created = Convert.ToDateTime(Reader["created"]);
            //Proveedor.Createby =

            return Proveedor;
        }

    }
}
