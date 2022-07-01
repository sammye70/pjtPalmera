using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pjPalmera.DAL;
using pjPalmera.Entities;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace pjPalmera.DAL
{
    public class OperationsCajaDAL
    {
        /// <summary>
        /// Save History Header and Detail About process Open Box
        /// </summary>
        /// <param name="Ocaja"></param>
        /// <returns></returns>
        public static int CreateHistoryOpenBox(OperationsCajaEntity oCaja)
        {
            int result;
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spCreateOpBox", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pcajero", oCaja.UserId);
                    cmd.Parameters.AddWithValue("@pmonto", oCaja.Monto);
                    cmd.Parameters.AddWithValue("@ptypeop", oCaja.TypeOp);
                    cmd.Parameters.AddWithValue("@pventa", oCaja.Venta);
                    cmd.Parameters.AddWithValue("@pfaltante", oCaja.Faltante);
                    cmd.Parameters.AddWithValue("@pamountsellscard", 0);
                    cmd.Parameters.AddWithValue("@pamountsellscash", 0);
                    cmd.Parameters.AddWithValue("@pamountpays", 0);
                    // cmd.Parameters.AddWithValue("@pcreated", DateTime.Now);

                    oCaja.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }

                using (var cmd = new MySqlCommand("spCreateDetailOpBox", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pid_process", oCaja.Id);
                    cmd.Parameters.AddWithValue("@pcajero", oCaja.UserId);
                    cmd.Parameters.AddWithValue("@puno", oCaja.Uno);
                    cmd.Parameters.AddWithValue("@pcinco", oCaja.Cinco);
                    cmd.Parameters.AddWithValue("@pdiez", oCaja.Diez);
                    cmd.Parameters.AddWithValue("@pventicinco", oCaja.Venticinco);
                    cmd.Parameters.AddWithValue("@pcincuenta", oCaja.Cincuenta);
                    cmd.Parameters.AddWithValue("@pcien", oCaja.Cien);
                    cmd.Parameters.AddWithValue("@pdoscientos", oCaja.Doscientos);
                    cmd.Parameters.AddWithValue("@pquinientos", oCaja.Quinientos);
                    cmd.Parameters.AddWithValue("@pmil", oCaja.Mil);
                    cmd.Parameters.AddWithValue("@pdosmil", oCaja.Dosmil);
                    cmd.Parameters.AddWithValue("@pmonto", oCaja.Monto);
                    // cmd.Parameters.AddWithValue("@pcreated", DateTime.Now);

                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }



        /// By: sammye70
        /// created: 10/02/2021
        /// Modificated by: sammye70
        /// Modificated Date:
        /// <summary>
        ///  Get Status Box (It will return 0 when was closed and 1 if was opened )
        /// </summary>
        /// <returns></returns>
        public static int GetStatusBox(OperationsCajaEntity oCaja)
        {
            int status = 0;
            // string strmgs;

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spGetStatusBox", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pcajero", oCaja.UserId);
                    cmd.Parameters.Add("@resp", MySqlDbType.Int32);
                    cmd.Parameters["@resp"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();

                    status = (Int32)cmd.Parameters["@resp"].Value;
                }
            }
            return status;
        }

        /// <summary>
        ///  Get All Operations By user and date (admin or casher request)
        /// </summary>
        public static List<OperationsCajaEntity> getOperationsByUserDate(OperationsCajaEntity oCaja)
        {
            var ls = new List<OperationsCajaEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spGetOperationsByDateUser", con))
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@puserid", oCaja.UserId);
                    cmd.Parameters.AddWithValue("@pdateo", oCaja.Bdate);
                    cmd.Parameters.AddWithValue("@pdateu", oCaja.Udate);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ls.Add(LoadOperationsHeaderl(reader));
                    }
                }
            }

            return ls;
        }


        /// By: sammye70
        /// created: 
        /// Modificated by: sammye70
        /// Modificated Date: 
        /// <summary>
        /// Save process Open Box until box status change to closed
        /// </summary>
        /// <param name="Ocaja"></param>
        public static int CreateOpenBox(OperationsCajaEntity oCaja)
        {
            int result;
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spCreateOpenB", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pcajero", oCaja.UserId);
                    cmd.Parameters.AddWithValue("@pmonto", oCaja.Monto);
                    // cmd.Parameters.AddWithValue("@pstatus", oCaja.Status);
                    // cmd.Parameters.AddWithValue("@pcreated", DateTime.Now);

                    result = cmd.ExecuteNonQuery();
                }
            }

            return result;
        }


        /// <summary>
        /// Get Current Amount used open box
        /// </summary>
        /// <returns></returns>
        public static decimal GetAmount()
        {
            decimal amount;
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string query = @"SELECT SUM(monto) FROM open_box;";

                MySqlCommand cmd = new MySqlCommand(query, con);

                amount = Convert.ToDecimal(cmd.ExecuteScalar());
            }
            return amount;
        }


        /// <summary>
        ///  Gell all operations opened and closed box when admin selected user id
        /// </summary>
        public static List<OperationsCajaEntity> GetAllOpBox(OperationsCajaEntity oCaja)
        {

            var list = new List<OperationsCajaEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spGetOperationsByDateUser", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@puserid", oCaja.UserId);
                    cmd.Parameters.AddWithValue("@pdateo", oCaja.Bdate);
                    cmd.Parameters.AddWithValue("@pdateu", oCaja.Udate);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(LoadOperationsHeaderl(reader));
                    }
                }
            }
            return list;
        }

        /// <summary>
        ///  Get Operations opened or closed by Type
        /// </summary>
        /// <param name="oCaja"></param>
        /// <returns></returns>
        public static List<OperationsCajaEntity> GetOpByUserDateType(OperationsCajaEntity oCaja)
        {

            var list = new List<OperationsCajaEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spGetOperationsByDateUser", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@puserid", oCaja.UserId);
                    cmd.Parameters.AddWithValue("@poptype", oCaja.TypeOp);
                    cmd.Parameters.AddWithValue("@pdateo", oCaja.Bdate);
                    cmd.Parameters.AddWithValue("@pdateu", oCaja.Udate);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(LoadOperationsHeaderl(reader));
                    }
                }
            }
            return list;
        }

        /// <summary>
        ///  Get Current selected operations, then return details                
        /// </summary>
        /// <param name="oCaja"></param>
        /// <returns></returns>
        public static OperationsCajaEntity getCurrentOperation(OperationsCajaEntity oCaja)
        {
            var result = new OperationsCajaEntity();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spGetOperationsBoxDetails", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pid", oCaja.Id);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result = LoadOperationsDetail(reader);
                    }
                }

                return result;
            }
        }

        /// <summary>
        ///  Get Operation Type in History Box
        /// </summary>
        public static List<OperationsTypeEntity> getListOpType
        {
            get
            {
                var ls = new List<OperationsTypeEntity>();

                using (var con = new MySqlConnection(SettingDAL.connectionstring))
                {
                    using (var cmd = new MySqlCommand("spGetTypeOp", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            ls.Add(LoadTypeOp(reader));
                        }
                    }
                }
                return ls;
            }
        }


        /// <summary>
        /// Load all operations opened/closed box, but only details
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static OperationsCajaEntity LoadOperationsDetail(IDataReader reader)
        {
            var ah = new OperationsCajaEntity();

            ah.Id = (int)(reader["id_process"]);
            ah.UserId = (int)(reader["cajero"]);
            ah.TypeOp = (reader["typeop"]).ToString();
            ah.Uno = Convert.ToDecimal((reader["uno"]));
            ah.Cinco = Convert.ToDecimal(reader["cinco"]);
            ah.Diez = Convert.ToDecimal(reader["diez"]);
            ah.Venticinco = Convert.ToDecimal(reader["venticinco"]);
            ah.Cincuenta = Convert.ToDecimal(reader["cincuenta"]);
            ah.Cien = Convert.ToDecimal(reader["cien"]);
            ah.Doscientos = Convert.ToDecimal(reader["doscientos"]);
            ah.Quinientos = Convert.ToDecimal(reader["quinientos"]);
            ah.Mil = Convert.ToDecimal(reader["mil"]);
            ah.Monto = Convert.ToDecimal(reader["monto"]);
            ah.Fecha = (reader["created"]).ToString();

            return ah;
        }



        /// <summary>
        ///  Load all open box but only header
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static OperationsCajaEntity LoadOperationsHeaderl(IDataReader reader)
        {
            var ap = new OperationsCajaEntity();

            ap.Id = (int) (reader["id"]);
            ap.TypeOp = (reader["operation"]).ToString();
            ap.Monto = (decimal )(reader["monto"]);
            ap.Faltante = (decimal) reader["faltante"];
            ap.Venta = (decimal) reader["venta"];
            ap.Fecha = (reader["created"]).ToString();

            return ap;
        }

        /// <summary>
        ///  Load all operations caterogies
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static OperationsTypeEntity LoadTypeOp(IDataReader reader)
        {
            var tp = new OperationsTypeEntity();

            tp.Id = (int)(reader["id"]);
            tp.Type = (reader["type"]).ToString();

            return tp;
        }



        /// <summary>
        /// Get Amount Total Invoices
        /// </summary>
        /// <returns></returns>
        public static decimal MontoVentas(OperationsCajaEntity cCaja)
        {
            decimal amount;

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spGetAmountTempSells", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@puserid", cCaja.UserId);

                    amount = Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            return amount;
        }

        /// <summary>
        /// Get Amount Total pays to any credit account
        /// </summary>
        /// <returns></returns>
        public static decimal MontoPays(OperationsCajaEntity cCaja)
        {
            decimal amount;

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("GetAmountTempPaysCredit", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@puserid", cCaja.UserId);

                    amount = Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            return amount;
        }

        /// <summary>
        /// Get Amount Total pays to any credit account but with Credit Card 
        /// </summary>
        /// <returns></returns>
        public static decimal MontoPaysCreditCard(OperationsCajaEntity cCaja)
        {
            decimal amount;

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("GetAmountTempPaysCreditCard", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@puserid", cCaja.UserId);

                    amount = Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            return amount;
        }

       

        /// <summary>
        /// Get Amount Total pays to any credit account but with Cash 
        /// </summary>
        /// <returns></returns>
        public static decimal MontoPaysCash(OperationsCajaEntity cCaja)
        {
            decimal amount;

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("GetAmountTempPaysCash", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@puserid", cCaja.UserId);

                    amount = Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            return amount;
        }


        
        /// <summary>
        /// Get Amount Total sells with Cash
        /// </summary>
        /// <returns></returns>
        public static decimal MontoSellsCash(OperationsCajaEntity cCaja)
        {
            decimal amount;

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("GetAmountTempSellsCash", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@puserid", cCaja.UserId);

                    amount = Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            return amount;
        }

        //

        /// <summary>
        /// Get Amount Total sells with Credit Card
        /// </summary>
        /// <returns></returns>
        public static decimal MontoSellsCreditCard(OperationsCajaEntity cCaja)
        {
            decimal amount;

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("GetAmountTempSellsCreditCard", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@puserid", cCaja.UserId);

                    amount = Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            return amount;
        }


        /// <summary>
        /// Remove Transtactions temp by user id
        /// </summary>
        public static int CleanTranstactions(OperationsCajaEntity cCaja)
        {
            int result;
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spRemoveTransactionTemp", con))
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@puserid", cCaja.UserId);

                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }




        /// <summary>
        /// Clean Open Box
        /// </summary>
        public static void CleanOpenBox()
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();

                string query = @"TRUNCATE TABLE open_box;";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.ExecuteNonQuery();
            }
        }


        /// <summary>
        /// Save History Header and Detail About process Close Box
        /// </summary>
        /// <param name="Ocaja"></param>
        /// <returns></returns>
        public static int CreateHistoryCloseBox(OperationsCajaEntity cCaja)
        {
            int result;
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spCreateOpBox", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pcajero", cCaja.UserId);
                    cmd.Parameters.AddWithValue("@pmonto", cCaja.Monto);
                    cmd.Parameters.AddWithValue("@pfaltante", cCaja.Faltante);
                    cmd.Parameters.AddWithValue("@pventa", cCaja.Venta);
                    cmd.Parameters.AddWithValue("@pamountsellscard", cCaja.AmountSellsCard);
                    cmd.Parameters.AddWithValue("@pamountsellscash", cCaja.AmountSellsCash);
                    // cmd.Parameters.AddWithValue("@pamountpayscard", cCaja.TotalAmountPaysCard);
                    // cmd.Parameters.AddWithValue("@pamountpayscash", cCaja.TotalAmountPaysCash);
                    cmd.Parameters.AddWithValue("@pamountpays", cCaja.MontosPagos);
                    cmd.Parameters.AddWithValue("@ptypeop", cCaja.TypeOp);
                    cmd.Parameters.AddWithValue("@pcreated", DateTime.Now);

                    cCaja.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }

                using (var cmd = new MySqlCommand("spCreateDetailOpBox", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pid_process", cCaja.Id);
                    cmd.Parameters.AddWithValue("@pcajero", cCaja.UserId);
                    cmd.Parameters.AddWithValue("@puno", cCaja.Uno);
                    cmd.Parameters.AddWithValue("@pcinco", cCaja.Cinco);
                    cmd.Parameters.AddWithValue("@pdiez", cCaja.Diez);
                    cmd.Parameters.AddWithValue("@pventicinco", cCaja.Venticinco);
                    cmd.Parameters.AddWithValue("@pcincuenta", cCaja.Cincuenta);
                    cmd.Parameters.AddWithValue("@pcien", cCaja.Cien);
                    cmd.Parameters.AddWithValue("@pdoscientos", cCaja.Doscientos);
                    cmd.Parameters.AddWithValue("@pquinientos", cCaja.Quinientos);
                    cmd.Parameters.AddWithValue("@pmil", cCaja.Mil);
                    cmd.Parameters.AddWithValue("@pdosmil", cCaja.Dosmil);
                    cmd.Parameters.AddWithValue("@pmonto", cCaja.Monto);
                    cmd.Parameters.AddWithValue("@pcreated", DateTime.Now);

                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }
    }
}
