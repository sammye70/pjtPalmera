using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MySql.Data;
using MySql.Data.MySqlClient;
using pjPalmera.Entities;

namespace pjPalmera.DAL
{
    public class UsuariosDAL
    {

        /// <summary>
        /// Create New Account User
        /// </summary>
        /// <param name="Users"></param>
        /// <returns></returns>
        public static void Create(UsuariosEntity user)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (MySqlCommand cmd = new MySqlCommand("spCreateUser", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pusername", user.User_name);
                    cmd.Parameters.AddWithValue("@ppassword", user.Password);
                    cmd.Parameters.AddWithValue("@pid_permission", user.Privileges);
                    cmd.Parameters.AddWithValue("@pemail", user.Email);
                    cmd.Parameters.AddWithValue("@pstatus", user.Status);
                    cmd.Parameters.AddWithValue("@plong_name", user.LongName);
                    cmd.Parameters.AddWithValue("@psecret_question1", user.Secret_question);
                    cmd.Parameters.AddWithValue("@psecret_answer1", user.Secret_answer);
                    cmd.Parameters.AddWithValue("@pcreateby", user.Createby);
                    cmd.Parameters.AddWithValue("@pcreated", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }   
            }
        }


        /// <summary>
        /// Check if exists username
        /// </summary>
        /// <returns>true or false</returns>
        public static bool ExistsUser(string username)
        {
            bool resp = false;
            int vnum = 0;

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spSearchExistUserName", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pusername", username);
                    cmd.Parameters.Add("@resp", MySqlDbType.Int32);
                    cmd.Parameters["@resp"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();

                    vnum = (Int32) cmd.Parameters["@resp"].Value;

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
        ///  Get status current user
        /// </summary>
        /// <returns></returns>
        public static bool StatusUser(string user)
        {
            bool resp = false;
            int val = 0;

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spGetStatusPerson", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pusername", user);
                    cmd.Parameters.Add("@resp", MySqlDbType.Int32);
                    cmd.Parameters["@resp"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();

                    val = (Int32) cmd.Parameters["@resp"].Value;

                    switch (val)
                    {
                        case 0:
                             resp = false; // user status is disable
                            break;
                        case 1:
                            resp = true; // user status is enable
                            break;
                    }
                }
            }
            return resp;
        }


        /// <summary>
        /// Search user and password. Then they are true allow to login, else not allow to login.
        /// </summary>
        public static bool Login_User(UsuariosEntity user )
        {
            bool ans = false;
            int num = 0;
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("splogin", con))
                { 
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pusername", user.User_name);
                    cmd.Parameters.AddWithValue("@ppassword", user.Password);
                    cmd.Parameters.Add("@resp", MySqlDbType.Int32);
                    cmd.Parameters["@resp"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    num = (Int32) cmd.Parameters["@resp"].Value;

                    switch (num)
                    {
                        case 0:
                            ans = false;
                            break;
                        case 1:
                            ans = true;
                            break;
                    }
                }   
            }
            return ans;
        }


        /// <summary>
        ///  Get all information about User after login normal
        /// </summary>
        /// <returns></returns>
        // public static UsuariosEntity LoadUserInf(string username)

        public static UsuariosEntity LoadUserInf(UsuariosEntity userInfo)

        {
            // var userinfo = new UsuariosEntity();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spGet_userinfo", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pusername", userInfo.User_name);
                   // cmd.Parameters.AddWithValue ("@id_permission", userInfo.Privileges);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        userInfo = LoadinfoUser(reader);
                    }

                   // cmd.ExecuteNonQuery();
                }
                return userInfo;
            }
        }



        /// <summary>
        ///  Get all information about User after login normal by id
        /// </summary>
        /// <returns></returns>
        // public static UsuariosEntity LoadUserInf(string username)

        public static UsuariosEntity LoadUserInfid(UsuariosEntity userInfo)

        {
            // var userinfo = new UsuariosEntity();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spGet_userinfoid", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@puserid", userInfo.Id_user);
                    // cmd.Parameters.AddWithValue ("@id_permission", userInfo.Privileges);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        userInfo = LoadinfoUser(reader);
                    }

                    // cmd.ExecuteNonQuery();
                }
                return userInfo;
            }
        }

        private static UsuariosEntity LoadinfoUser(IDataReader reader)
        {
            var user = new UsuariosEntity();

            user.Id_user = Convert.ToInt32(reader["id_user"]);
            user.User_name = Convert.ToString(reader["username"]);
            user.Status = Convert.ToString(reader["status"]);
            user.Privileges = Convert.ToInt32(reader["id_permission"]);
            user.LongName = Convert.ToString(reader["long_name"]);

            return user;
        }
    }
}
