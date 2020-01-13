using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using pjPalmera.Entities;

namespace pjPalmera.DAL
{
    public class UsuariosDAL
    {
        public static UsuariosEntity Create(UsuariosEntity Usuarios)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"INSERT INTO users (id_user, username, email, password, created, createby, privileges, status )
                        VALUES(@id_user, @username, @email, @password, @created, @createby, @privileges, @status)";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id_user", Usuarios.Id_user);
                cmd.Parameters.AddWithValue("@username", Usuarios.User_name);
                cmd.Parameters.AddWithValue("@email", Usuarios.Email);
                cmd.Parameters.AddWithValue("@password", Usuarios.Password);
                cmd.Parameters.AddWithValue("@created", Usuarios.Created);
                cmd.Parameters.AddWithValue("@createby", Usuarios.Createby);
                cmd.Parameters.AddWithValue("@privileges", Usuarios.Privileges);
                cmd.Parameters.AddWithValue("@status", Usuarios.Status);

                Usuarios.Id_user = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
           return Usuarios;
        }
    }
}
