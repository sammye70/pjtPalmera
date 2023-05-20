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

        #region Create New User
        /// <summary>
        /// Create New Account User
        /// </summary>
        /// <param name="Users"></param>
        /// <returns></returns>
        public static int Create(UsuariosEntity user)
        {
            int result;
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spCreateUser", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pusername", user.User_name);
                    cmd.Parameters.AddWithValue("@pfirstname", user.Firstname);
                    cmd.Parameters.AddWithValue("@plastname", user.Lastname);
                    cmd.Parameters.AddWithValue("@ppassword", user.Password);
                    cmd.Parameters.AddWithValue("@pid_permission", user.Privileges);
                    cmd.Parameters.AddWithValue("@pemail", user.Email);
                    cmd.Parameters.AddWithValue("@pstatus", user.Status);
                    cmd.Parameters.AddWithValue("@plong_name", user.LongName);
                    cmd.Parameters.AddWithValue("@psecret_question1", user.Secret_question);
                    cmd.Parameters.AddWithValue("@psecret_answer1", user.Secret_answer);
                    cmd.Parameters.AddWithValue("@pcreateby", user.Createby);
                    cmd.Parameters.AddWithValue("@pcreated", DateTime.Now);

                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }
        #endregion

        #region Verify if exists username was indicated (Register process)
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
        #endregion

        #region Get users status
        /// <summary>
        ///  Get status current user
        /// </summary>
        /// <returns>when user status enable it is true and otherwise false</returns>
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

                    val = (Int32)cmd.Parameters["@resp"].Value;

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
        #endregion

        #region Search user account and password when login
        /// <summary>
        /// Search user and password. Then they are true allow to login, else not allow to login.
        /// </summary>
        /// <returns>it is true when user found but and otherwise false</returns>
        public static bool Login_User(UsuariosEntity user)
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

                    num = (Int32)cmd.Parameters["@resp"].Value;

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
        #endregion


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
        ///   Get All User by longname
        /// </summary>
        public static List<UsuariosEntity> getUserByLongName(UsuariosEntity User)
        {
            var ls = new List<UsuariosEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spGet_UserbyLongNombre", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@plongname", User.LongName);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ls.Add(LoadinfoUser(reader));
                    }
                }
            }
            return ls;
        }

        /// <summary>
        ///   Get All User by userName
        /// </summary>
        public static List<UsuariosEntity> getUserByName(UsuariosEntity User)
        {
            var ls = new List<UsuariosEntity>();

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spGet_userinfo", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pusername", User.User_name);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ls.Add(LoadinfoUser(reader));
                    }
                }
            }
            return ls;
        }

        /// <summary>
        ///  Get all secret questions
        /// </summary>
        public static List<QuestionsEntity> getSecretQuestions
        {
            get
            {
                var ls = new List<QuestionsEntity>();

                using (var con = new MySqlConnection(SettingDAL.connectionstring))
                {
                    using (var cmd = new MySqlCommand("spGetQuestions", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            ls.Add(LoadQuestion(reader));
                        }
                    }
                }
                return ls;
            }
        }

        /// <summary>
        /// Get all user roles
        /// </summary>
        public static List<RolesEntity> getRoles
        {
            get
            {
                var ls = new List<RolesEntity>();

                using (var con = new MySqlConnection(SettingDAL.connectionstring))
                {
                    using (var cmd = new MySqlCommand("spGetTypeUser", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            ls.Add(LoadRol(reader));
                        }
                    }
                }
                return ls;
            }
        }


        /// <summary>
        ///  Get all information about User after login normal by id
        /// </summary>
        /// <returns></returns>
        // public static UsuariosEntity LoadUserInf(string username)

        public static UsuariosEntity LoadUserInfid(UsuariosEntity userInfo)

        {
            var userinfo = new UsuariosEntity();

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

        /// <summary>
        /// Get All Users
        /// </summary>
        public static List<UsuariosEntity> getAllUsers
        {
            get
            {
                var ls = new List<UsuariosEntity>();

                using (var con = new MySqlConnection(SettingDAL.connectionstring))
                {
                    using (var cmd = new MySqlCommand("getAllUsers", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlDataReader reader = cmd.ExecuteReader();

                        while(reader.Read())
                        {
                            ls.Add(LoadinfoUser(reader));
                        }
                    }
                }
              return ls;
            }
        }

        /// <summary>
        ///  Remove user by id
        /// </summary>
        public static int RemoveUser(UsuariosEntity user)
        {
            int result = 0;
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spDeleteUser", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@puserid", user.Id_user);
                    result = cmd.ExecuteNonQuery();
                }
                return result;
            }
        }

        /// <summary>
        ///  Disable user by id
        /// </summary>
        public static int DisableUser(UsuariosEntity user)
        {
            int result = 0;
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spDisableUser", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@puserid", user.Id_user);
                    cmd.Parameters.AddWithValue("@pstatus", user.Status);

                    result = cmd.ExecuteNonQuery();
                }
                return result;
            }
        }

        /// <summary>
        ///  Enable user by id
        /// </summary>
        public static int EnableUser(UsuariosEntity user)
        {
            int result = 0;
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spEnableUser", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@puserid", user.Id_user);
                    cmd.Parameters.AddWithValue("@pstatus", user.Status);

                    result = cmd.ExecuteNonQuery();
                }
                return result;
            }
        }

        /// <summary>
        ///  Update All informations about Users
        /// </summary>
        public static int UpdateUser(UsuariosEntity user)
        {
            int result = 0;

            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                using (var cmd = new MySqlCommand("spupdateUser", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@puserid",user.Id_user);
                    cmd.Parameters.AddWithValue("@pusername", user.User_name);
                    cmd.Parameters.AddWithValue("@pid_permission", user.Privileges);
                    cmd.Parameters.AddWithValue("@ppassword", user.Password);
                    cmd.Parameters.AddWithValue("@pemail", user.Email);
                    cmd.Parameters.AddWithValue("@pstatus", user.Status);
                    cmd.Parameters.AddWithValue("@plong_name", user.LongName);
                    cmd.Parameters.AddWithValue("@pfirstname", user.Firstname);
                    cmd.Parameters.AddWithValue("@plastname", user.Lastname);
                    cmd.Parameters.AddWithValue("@psecret_question1", user.Secret_question);
                    cmd.Parameters.AddWithValue("@psecret_answer1", user.Secret_answer);
                    cmd.Parameters.AddWithValue("@pmodificateby", user.Createby);

                   result = cmd.ExecuteNonQuery();
                }
            }

           return result;
        }
      
        private static UsuariosEntity LoadinfoUser(IDataReader reader)
        {
            var user = new UsuariosEntity();

            user.Id_user = Convert.ToInt32(reader["id_user"]);
            user.User_name = Convert.ToString(reader["username"]);
            user.Status = Convert.ToString(reader["status"]);
            user.Privileges = Convert.ToString(reader["id_permission"]);
            user.LongName = Convert.ToString(reader["long_name"]);
            user.Firstname = Convert.ToString(reader["firstname"]);
            user.Lastname = Convert.ToString(reader["lastname"]);

            return user;
        }

        /// <summary>
        ///  Load all secret questions
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static QuestionsEntity LoadQuestion(IDataReader reader)
        {
            var q = new QuestionsEntity();

            q.Id = Convert.ToInt32(reader["id"]);
            q.Question = Convert.ToString(reader["question"]);

            return q;
        }

        /// <summary>
        ///  Load all roles
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static RolesEntity LoadRol(IDataReader reader)
        {
            var r = new RolesEntity();

            r.Id = Convert.ToInt32(reader["id_type_user"]);
            r.Rol = Convert.ToString(reader["name_type"]);

            return r;
        }


    }
}
