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
        public static ClientesEntity Create( ClientesEntity Costumer)
        {

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"INSERT INTO clientes (cedula, nombre, apellidos, telefono, direccion, ciudad, provincia, limitecredito, createby, created, cxc)
                                VALUES (@cedula, @nombre, @apellidos, @telefono, @direccion, @ciudad, @provincia, @limitecredito, @createby, @created, @cxc)";
                MySqlCommand cmd = new MySqlCommand(sql,con);

                cmd.Parameters.AddWithValue("@cedula",Costumer.Cedula);
                cmd.Parameters.AddWithValue("@nombre",Costumer.Nombre);
                cmd.Parameters.AddWithValue("@apellidos", Costumer.Apellidos);
                cmd.Parameters.AddWithValue("@telefono",Costumer.Telefono);
                cmd.Parameters.AddWithValue("@direccion", Costumer.Direccion);
                cmd.Parameters.AddWithValue("@ciudad", Costumer.Ciudad);
                cmd.Parameters.AddWithValue("@provincia", Costumer.Provincia);
                cmd.Parameters.AddWithValue("@limitecredito",Costumer.Limitecredito);
                cmd.Parameters.AddWithValue("@createby",Costumer.Createby);
                cmd.Parameters.AddWithValue("@created",DateTime.Now);
                cmd.Parameters.AddWithValue("@cxc", Costumer.Cxc);

                Costumer.Id = Convert.ToInt32(cmd.ExecuteScalar());

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
                string sql= @"SELECT id, cedula, nombre, apellidos
                            FROM clientes 
                            WHERE id=@idcliente";
                MySqlCommand cmd = new MySqlCommand(sql,con);

                cmd.Parameters.AddWithValue("@idclientes",id);

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
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"UPDATE clientes SET
                                cedula = @cedula,
                                nombre = @nombre, apellidos = @apellidos, telefono = @telefono,
                                direccion = @direccion, ciudad = @ciudad, provincia =@provincia, limitecredito = @limitecredito
                                idclientes = @idclientes                                
                                ";

                MySqlCommand cmd = new MySqlCommand(sql, con);

            }

            return costumer;
        }


        /// <summary>
        /// Get All Costumer Order by LastName
        /// </summary>
        /// <returns></returns>
        public static List<ClientesEntity> GetAll()
        {
            List<ClientesEntity> list = new List<ClientesEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"SELECT id, cedula, nombre, apellidos, telefono, direccion, ciudad, provincia, created, cxc 
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

        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <returns></returns>
        public static ClientesEntity GetbyId(Int64 Id)
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
        public static List<ClientesEntity> GetbyCedula(Int64 cedula)
        {
            //ClientesEntity Clientes = null;
            List<ClientesEntity> list = new List<ClientesEntity>();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
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
        private static ClientesEntity LoadCostumers(IDataRecord Reader)
        {
            ClientesEntity costumer = new ClientesEntity();

            costumer.Id = Convert.ToInt32(Reader["id"]);
            costumer.Cedula = Convert.ToInt32(Reader["cedula"]);
            costumer.Nombre = Convert.ToString(Reader["nombre"]);
            costumer.Apellidos = Convert.ToString(Reader["apellidos"]);

            return costumer;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Reader"></param>
        /// <returns></returns>
        private static ClientesEntity LoadCostumer(IDataRecord Reader)
        {
            ClientesEntity costumer = new ClientesEntity();

            costumer.Id = Convert.ToInt32(Reader["id"]);
            costumer.Cedula = Convert.ToInt32(Reader["cedula"]);
            costumer.Nombre = Convert.ToString(Reader["nombre"]);
            costumer.Apellidos = Convert.ToString(Reader["apellidos"]);
            costumer.Telefono = Convert.ToString(Reader["telefono"]);
            costumer.Direccion = Convert.ToString(Reader["direccion"]);
            costumer.Ciudad = Convert.ToString(Reader["ciudad"]);
            costumer.Provincia = Convert.ToString(Reader["provincia"]);
            costumer.Created = Convert.ToDateTime(Reader["created"]);
            costumer.Cxc = Convert.ToInt32(Reader["cxc"]);

            return costumer;
        } 
    }
}
