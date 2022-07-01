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
        public static int Create(ClientesEntity Costumer)
        {
            int ResRequest;
            var valMessage = new ResultEntity();
            

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
                       // cmd.Parameters.AddWithValue("pstatus", 1);

                        ResRequest = Convert.ToInt32(cmd.ExecuteNonQuery());

                    }
                }
            return ResRequest;
        }


        /// <summary>
        ///  Update costumer information
        /// </summary>
        /// <param name="costumer"></param>
        /// <returns></returns>
        public static int Update(ClientesEntity costumer)
        {
            int result;
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
                    cmd.Parameters.AddWithValue("@pmodficatedby", costumer.Createby);

                    result = cmd.ExecuteNonQuery();
                }
            }

            return result;
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
        public static bool ExitsCode(int code)
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

                    cmd.Parameters.AddWithValue("@pcode", code);
                    cmd.Parameters["@pcode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@presp", MySqlDbType.VarChar);
                    cmd.Parameters["@presp"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    val = (string)cmd.Parameters["@presp"].Value;

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
        /// Get customer amount from entity customer.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static decimal Get_setCustomerAmount(long idcustomer)
        {
            decimal amount;

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using(var cmd = new MySqlCommand("spGetCustomerCredit", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pidcustomer", idcustomer);

                    cmd.Parameters.Add("@pamount", MySqlDbType.Decimal);
                    cmd.Parameters["@pamount"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    amount = (decimal) cmd.Parameters["@pamount"].Value;
                }
                
                return amount;

            }
        }




        // ------------------------> ADD INSERT FOR TABLE ACCOUNT_CREDIT_CUSTOMER, VERIFY TABLE ACCOUNT_CREDIT_INVOICE_CUSTOMER

        /// <summary>
        ///  Get Customer Credit Amount from Manager Customers
        /// </summary>
        /// <param name="customer"></param>                       
        /// <returns></returns>
        public static  decimal Get_CrAmountCustomer(long idcustomer)
        {
            decimal amount;

            using (var con =  new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spGetAmountCurrentCr", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pidcustomer", idcustomer);
                    cmd.Parameters.Add("@pamount", MySqlDbType.Decimal);
                    cmd.Parameters["@pamount"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    amount = (decimal) cmd.Parameters["@pamount"].Value;

                   
                }
                
                return amount;
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
        /// Get Customer by Id for Update Information
        /// </summary>
        /// <returns></returns>
        public static ClientesEntity GetbyCodeUpdate(long Id)
        {
            var customer = new ClientesEntity();

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
                        customer = LoadCostumer(reader);
                    }
                }
                return customer;
            }
        }


        /// <summary>
        /// Get Customer by Id (List) from Customers table
        /// </summary>
        /// <returns></returns>
        public static ClientesEntity GetbyId(long Id)
        {
            var customer = new ClientesEntity();

            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spSearchCustomerByCode", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    cmd.Parameters.AddWithValue("@pidcliente", Id);

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
