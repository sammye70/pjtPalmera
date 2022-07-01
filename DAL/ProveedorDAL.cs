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
        public static int Create(ProveedorEntity Proveedor)
        {
            int result;
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spCreateProveedor", con)) 
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pnombre", Proveedor.Nombre_proveedor);
                    cmd.Parameters.AddWithValue("@pnom_contacto", Proveedor.Nombre_contacto);
                    cmd.Parameters.AddWithValue("@ptel_contacto", Proveedor.Tel_contacto);
                    cmd.Parameters.AddWithValue("@pdireccion_prob", Proveedor.Direccion_prob);
                    cmd.Parameters.AddWithValue("@ptelefono", Proveedor.Tel_proveedor);
                    cmd.Parameters.AddWithValue("@prnc", Proveedor.Rnc);
                    cmd.Parameters.AddWithValue("@plimitecredito", Proveedor.Limitecredito);
                    cmd.Parameters.AddWithValue("@pcreated", DateTime.Now);
                    cmd.Parameters.AddWithValue("@pcreateby", Proveedor.Createby);

                    //Proveedor.Idproveedor = Convert.ToInt32(cmd.ExecuteScalar());
                   result = cmd.ExecuteNonQuery();
                }             
            }
           return result;
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
                    con.Open();
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
            var list = new List<ProveedorEntity>();

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
        /// Get All Provider by fields id and name
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
        /// Filter proveedor by rnc
        /// </summary>
        /// <param name="code"></param>
        public static List<ProveedorEntity> FilterByRnc(long code)
        {
            var ls = new List<ProveedorEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("GetProviderByRnc", con))
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@rnc", code);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ls.Add(LoadProveedor(reader));
                    }
                }
            }
            return ls;
        }


        /// <summary>
        /// Remove proveedor from DataBases
        /// </summary>
        /// <param name="code"></param>
        public static int RemoveProveedor(long code)
        {
            int result;
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spRemoveProvider", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pid", code);

                    result=cmd.ExecuteNonQuery();
                }
                    
            }
            return result;
        }

        /// <summary>
        /// Search Proveedor by Code 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static ProveedorEntity ProviderByCode(long code)
        {
            var proveedor = new ProveedorEntity();
            
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {

                using (var cmd = new MySqlCommand("spGetProviderByCode", con))
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pidprovider", code);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        proveedor = (LoadProveedor(reader));
                    }
                }
            }
            return proveedor;
        }


        /// <summary>
        /// Update Proveedor Information 
        /// </summary>
        /// <returns></returns>
        public static int Update(ProveedorEntity Proveedor)
        {
            int result;
            using (var con = new MySqlConnection (SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spUpdateProveedor", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pid", Proveedor.Idproveedor);
                    cmd.Parameters.AddWithValue("@pnombre_prob", Proveedor.Nombre_proveedor);
                    cmd.Parameters.AddWithValue("@ptelefono", Proveedor.Tel_proveedor);
                    cmd.Parameters.AddWithValue("@pnom_contacto", Proveedor.Nombre_contacto);
                    cmd.Parameters.AddWithValue("@ptel_contacto", Proveedor.Tel_contacto);
                    cmd.Parameters.AddWithValue("@pdireccion_prob", Proveedor.Direccion_prob);
                    cmd.Parameters.AddWithValue("@prnc", Proveedor.Rnc);
                    cmd.Parameters.AddWithValue("@plimitecredito", Proveedor.Limitecredito);
                   // cmd.Parameters.AddWithValue("@pmodificated", DateTime.Now);

                    result = cmd.ExecuteNonQuery();
                }             
            }
            return result;
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
        public static List<ProveedorEntity> SearchByName(ProveedorEntity provider)
        {
        
            var list = new List<ProveedorEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spSearchProveedorByNom", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pname", provider.Nombre_proveedor);

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
            Proveedor.Createby = Convert.ToInt32(Reader["createby"]);

            return Proveedor;
        }

    }
}
