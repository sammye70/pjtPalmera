using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using System.Data;
using MySql.Data.MySqlClient;
using pjPalmera.Entities;
using System.Configuration;


namespace pjPalmera.DAL
{
    public class ClientesDAL
    {
        /// <summary>
        /// Create New Costumer
        /// </summary>
        /// <param name="Costumer"></param>
        /// <returns>Number 1 or than if create</returns>
        public static String Create(ClientesEntity Costumer)
        {
            int ResRequest;
            var valMessage = new ResultEntity();
            string strMessage =null;

                using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
                {
                    using (var cmd = new MySqlCommand("spCreateCostumer", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.AddWithValue("@pcedula", Costumer.Cedula);
                        cmd.Parameters.AddWithValue("@pnombre", Costumer.Nombre);
                        cmd.Parameters.AddWithValue("@papellidos", Costumer.Apellidos);
                        cmd.Parameters.AddWithValue("@ptelefono", Costumer.Telefono);
                        cmd.Parameters.AddWithValue("@pdireccion", Costumer.Direccion);
                        cmd.Parameters.AddWithValue("@pciudad", Costumer.Ciudad);
                        cmd.Parameters.AddWithValue("@pprovincia", Costumer.Provincia);
                        cmd.Parameters.AddWithValue("@plimitedecredito", Costumer.Limite_credito);
                        cmd.Parameters.AddWithValue("@pcreatedby", Costumer.Createby);
                        cmd.Parameters.AddWithValue("@pcreated", DateTime.Now);
                        cmd.Parameters.AddWithValue("pstatus", 1);

                        ResRequest = Convert.ToInt32(cmd.ExecuteNonQuery());

                    if (ResRequest == 1)
                    {
                        //strMessage = valMessage.StrResult = setResult.Satisfactoriamente.ToString();
                        return strMessage;
                         
                    }
                    else if (ResRequest == 0)
                    {
                       // strMessage = valMessage.StrResult = setResult.NoSatisfactoriamente.ToString();
                       return strMessage;
                    }
                }
                }
            return strMessage;
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

                using (var cmd = new MySqlCommand("UpdateInfoCustomer", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pidcliente", costumer.Id);
                    cmd.Parameters.AddWithValue("@pcedula", costumer.Cedula);
                    cmd.Parameters.AddWithValue("@pnombre", costumer.Nombre);
                    cmd.Parameters.AddWithValue("@papellidos", costumer.Apellidos);
                    cmd.Parameters.AddWithValue("@ptelefono", costumer.Telefono);
                    cmd.Parameters.AddWithValue("@pdireccion", costumer.Direccion);
                    cmd.Parameters.AddWithValue("@pciudad", costumer.Ciudad);
                    cmd.Parameters.AddWithValue("@pprovincia", costumer.Provincia);
                    cmd.Parameters.AddWithValue("@plimitecredito", costumer.Limite_credito);

                    cmd.ExecuteNonQuery();
                }
            }

            return costumer;
        }


        /// <summary>
        /// Check if exits customer cedula
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool ExitsCedula(string cedula)
        {
            var result = true;
            string strMsg;

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spSearchExistCedula", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    cmd.Parameters.AddWithValue("@pcedula", cedula);
                    cmd.Parameters["@pcedula"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@resp", MySqlDbType.VarChar);
                    cmd.Parameters["@resp"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    strMsg = (string) cmd.Parameters["@resp"].Value;

                    // strMsg =Convert.ToString(cmd.ExecuteScalar());

                    if (strMsg == "Existe")
                    {
                        result = true;
                    }
                    else if( strMsg == "No Existe")
                    {
                        result = false;
                    }
                }
                return result;
            }
        }


        /// <summary>
        /// Filter Customer by Cedula 
        /// </summary>
        /// <returns></returns>
        public static List<ClientesEntity> GetCustomerByCedula(string cedula)
        {
            var list = new List<ClientesEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                
                using (var cmd = new MySqlCommand("spSearchCustomerByCedula", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pcedula", cedula);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(LoadCostumer(reader));
                    }
                }
            }
           return list;
        }


        /// <summary>
        /// Check if Exist Customer Code
        /// </summary>
        /// <returns></returns>
        public static bool ExitsCode(string code)
        {
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                var result = true;
                string val;
           //   var query = "SELECT * FROM Clientes WHERE id=@code";

                con.Open();

                using (var cmd = new MySqlCommand("spSearchExistCodCustomer", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters["[@code"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@resp", MySqlDbType.VarChar);
                    cmd.Parameters["@resp"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    val = (string)cmd.Parameters["@resp"].Value;

                    if (val == "Existe")
                    {
                        return true;
                    }
                    else if (val == "No Existe")
                    {
                        return false;
                    }
                }
                return result;
            }
        }

   

        /// <summary>
        ///Delete Customer by Id
        /// </summary>
        /// <param name="id"></param>
        public static void Delete(long id)
        {
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                using (var cmd = new MySqlCommand("DeleteCustomer", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pidcliente", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Get All Custumer Order by LastName
        /// </summary>
        /// <returns></returns>
        public static List<ClientesEntity> All
        {
            get
            {
                var list = new List<ClientesEntity>();

                using (var con = new MySqlConnection(SettingDAL.connectionstring))
                {
                    con.Open();
                    using (var cmd = new MySqlCommand("spGetAllCustomer", con))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            list.Add(LoadCostumer(reader));
                        }
                    }
                }
                return list;
            }
        }

        /// <summary>
        /// Get Costumer by Id for Update Information
        /// </summary>
        /// <returns></returns>
        public static ClientesEntity GetbyCodeUpdate(long Id)
        {
            var costumer = new ClientesEntity();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
          
                using (MySqlCommand cmd = new MySqlCommand("spSearchCustomerByCode", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pidcliente", Id);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        costumer = LoadCostumer(reader);
                    }
                }
                return costumer;
            }
        }


        /// <summary>
        /// Get Costumer by Id (List)
        /// </summary>
        /// <returns></returns>
        public static ClientesEntity GetbyId(long Id)
        {
            var customer = new ClientesEntity();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"SELECT id, cedula, nombre, apellidos, limitecredito
                                FROM clientes
                                WHERE id = @idcliente";

                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@idcliente", Id);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                       customer = LoadCustomers(reader);
                    }
                }
            }
                return customer;
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
        ///  Filter Costumer by Lastname (List)
        /// </summary>
        /// <returns></returns>
        public static List<ClientesEntity> GetbyApellidos(string lastname)
        {
            var list = new List<ClientesEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                using (var cmd = new MySqlCommand("spSearchCustomerByApellidos", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@plastname", lastname);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(LoadCostumer(reader));
                    }
                }

                return list;
            }
        }

        /// <summary>
        ///  Filter Costumer by Firstname (List)
        /// </summary>
        /// <returns></returns>
        public static List<ClientesEntity> GetbyNombre(string fistname)
        {
            List<ClientesEntity> list = new List<ClientesEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                using (var cmd = new MySqlCommand("spSearchCustomerByNombre", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pfirstname", fistname);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(LoadCostumer(reader));
                    }
                }

                return list;
            }
        }

        /// <summary>
        /// Load basic detail customer
        /// </summary>
        /// <param name="Reader"></param>
        /// <returns></returns>
        private static ClientesEntity LoadCustomers(IDataReader Reader)
        {
            ClientesEntity customer = new ClientesEntity();

            customer.Id = Convert.ToInt32(Reader["id"]);
            customer.Cedula = Convert.ToString(Reader["cedula"]);
            customer.Nombre = Convert.ToString(Reader["nombre"]);
            customer.Apellidos = Convert.ToString(Reader["apellidos"]);
            customer.Limite_credito = Convert.ToDecimal(Reader["limitecredito"]);

            return customer;
        }


        /// <summary>
        ///  Load complete customers in Reader
        /// </summary>
        /// <param name="Reader"></param>
        /// <returns></returns>
        private static ClientesEntity LoadCostumer(IDataReader Reader)
        {
            ClientesEntity customer = new ClientesEntity();

            customer.Id = Convert.ToInt32(Reader["id"]);
            customer.Cedula = Convert.ToString(Reader["cedula"]);
            customer.Nombre = Convert.ToString(Reader["nombre"]);
            customer.Apellidos = Convert.ToString(Reader["apellidos"]);
            customer.Telefono = Convert.ToString(Reader["telefono"]);
            customer.Direccion = Convert.ToString(Reader["direccion"]);
            customer.Ciudad = Convert.ToString(Reader["ciudad"]);
            customer.Provincia = Convert.ToString(Reader["provincia"]);
            customer.Limite_credito = Convert.ToDecimal(Reader["limitecredito"]);
            customer.Created = Convert.ToDateTime(Reader["created"]);
            customer.Estado = Convert.ToString(Reader["status"]);

            return customer;
        } 
    }
}
