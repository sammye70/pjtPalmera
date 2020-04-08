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
    public class ClientesDAL
    {
        /// <summary>
        /// Create New Costumer
        /// </summary>
        /// <returns></returns>
        public static ClientesEntity Create(ClientesEntity Costumer)
        {

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"INSERT INTO clientes (cedula, nombre, apellidos, telefono, direccion, ciudad, provincia, limitecredito, createby, created, cxc)
                                VALUES (@cedula, @nombre, @apellidos, @telefono, @direccion, @ciudad, @provincia, @limitecredito, @createby, @created, @cxc)";
                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@cedula", Costumer.Cedula);
                cmd.Parameters.AddWithValue("@nombre", Costumer.Nombre);
                cmd.Parameters.AddWithValue("@apellidos", Costumer.Apellidos);
                cmd.Parameters.AddWithValue("@telefono", Costumer.Telefono);
                cmd.Parameters.AddWithValue("@direccion", Costumer.Direccion);
                cmd.Parameters.AddWithValue("@ciudad", Costumer.Ciudad);
                cmd.Parameters.AddWithValue("@provincia", Costumer.Provincia);
                cmd.Parameters.AddWithValue("@limitecredito", Costumer.Limite_credito);
                cmd.Parameters.AddWithValue("@createby", Costumer.Createby);
                cmd.Parameters.AddWithValue("@created", DateTime.Now);
                cmd.Parameters.AddWithValue("@cxc", Costumer.Cxc);

                cmd.ExecuteNonQuery();

                //      Costumer.Id = Convert.ToInt32(cmd.ExecuteScalar());

            }
            return Costumer;
        }

        /// <summary>
        /// Search idCostumer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Exits(int id)
        {
            int nrecord = 0;
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"SELECT id, cedula, nombre, apellidos
                            FROM clientes 
                            WHERE id=@idcliente";
                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@idclientes", id);

                nrecord = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return nrecord > 0;
        }

        /// <summary>
        ///  Update costumer information
        /// </summary>
        /// <param name="costumer"></param>
        /// <returns></returns>
        public static ClientesEntity Update(ClientesEntity costumer)
        {
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"UPDATE clientes SET
                               clientes.cedula=@cedula,
                                clientes.nombre=@nombre, clientes.apellidos=@apellidos, clientes.telefono=@telefono,
                                clientes.direccion=@direccion, clientes.ciudad=@ciudad, clientes.provincia=@provincia, clientes.limitecredito=@limitecredito
                               WHERE id=@idclientes                                
                              ";

                using (var cmd = new MySqlCommand(sql, con))
                {

                    cmd.Parameters.AddWithValue("@idclientes", costumer.Id);
                    cmd.Parameters.AddWithValue("@cedula", costumer.Cedula);
                    cmd.Parameters.AddWithValue("@nombre", costumer.Nombre);
                    cmd.Parameters.AddWithValue("@apellidos", costumer.Apellidos);
                    cmd.Parameters.AddWithValue("@telefono", costumer.Telefono);
                    cmd.Parameters.AddWithValue("@direccion", costumer.Direccion);
                    cmd.Parameters.AddWithValue("@ciudad", costumer.Ciudad);
                    cmd.Parameters.AddWithValue("@provincia", costumer.Provincia);
                    cmd.Parameters.AddWithValue("@limitecredito", costumer.Limite_credito);

                    cmd.ExecuteNonQuery();
                }
            }
            return costumer;
        }

        /// <summary>
        ///Delete Client by Id 
        /// </summary>
        /// <param name="id"></param>
        public static void Delete(long id)
        {
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                var query = @"DELETE FROM clientes WHERE id=@idclientes";

                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@idclientes", id);
                    cmd.ExecuteNonQuery();
                }
            
            }
        
        }


        /// <summary>
        /// Get All Costumer Order by LastName
        /// </summary>
        /// <returns></returns>
        public static List<ClientesEntity> All
        {
            get
            {
                List<ClientesEntity> list = new List<ClientesEntity>();

                using (var con = new MySqlConnection(SettingDAL.connectionstring))
                {
                    con.Open();
                    string sql = @"SELECT id, cedula, nombre, apellidos, telefono, direccion, ciudad, provincia, created, limitecredito, cxc 
                                FROM clientes";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    MySqlDataReader Reader = cmd.ExecuteReader();

                    while (Reader.Read())
                    {
                        list.Add(LoadCostumer(Reader));
                    }
                }
                return list;
            }
        }

        /// <summary>
        /// Get User by Id for Update Information
        /// </summary>
        /// <returns></returns>
        public static ClientesEntity GetbyCodeUpdate(long Id)
        {
            ClientesEntity Clientes = new ClientesEntity();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"SELECT *
                                FROM clientes
                                WHERE id = @idcliente";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("idcliente", Id);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Clientes = LoadCostumer(reader);
                }
            }
            return Clientes;
        }




        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <returns></returns>
        public static ClientesEntity GetbyId(long Id)
        {
            ClientesEntity Clientes = null;

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"SELECT id, cedula, nombre, apellidos
                                FROM clientes
                                WHERE id = @idcliente";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("idcliente", Id);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Clientes = LoadCostumers(reader);
                }
            }
                return Clientes;
        }

        /// <summary>
        /// Filter Costumer by cedula
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static List<ClientesEntity> GetbyCedula(string cedula)
        {
            //ClientesEntity Clientes = null;
            List<ClientesEntity> list = new List<ClientesEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"SELECT *
                                FROM clientes
                                WHERE cedula = @cedula";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@cedula", cedula);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    list.Add(LoadCostumer(reader));
                }
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Reader"></param>
        /// <returns></returns>
        private static ClientesEntity LoadCostumers(IDataReader Reader)
        {
            ClientesEntity costumer = new ClientesEntity();

            costumer.Id = Convert.ToInt32(Reader["id"]);
            costumer.Cedula = Convert.ToString(Reader["cedula"]);
            costumer.Nombre = Convert.ToString(Reader["nombre"]);
            costumer.Apellidos = Convert.ToString(Reader["apellidos"]);

            return costumer;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Reader"></param>
        /// <returns></returns>
        private static ClientesEntity LoadCostumer(IDataReader Reader)
        {
            ClientesEntity costumer = new ClientesEntity();

            costumer.Id = Convert.ToInt32(Reader["id"]);
            costumer.Cedula = Convert.ToString(Reader["cedula"]);
            costumer.Nombre = Convert.ToString(Reader["nombre"]);
            costumer.Apellidos = Convert.ToString(Reader["apellidos"]);
            costumer.Telefono = Convert.ToString(Reader["telefono"]);
            costumer.Direccion = Convert.ToString(Reader["direccion"]);
            costumer.Ciudad = Convert.ToString(Reader["ciudad"]);
            costumer.Provincia = Convert.ToString(Reader["provincia"]);
            costumer.Limite_credito = Convert.ToDecimal(Reader["limitecredito"]);
            costumer.Created = Convert.ToDateTime(Reader["created"]);
            costumer.Cxc = Convert.ToInt32(Reader["cxc"]);

            return costumer;
        } 
    }
}
