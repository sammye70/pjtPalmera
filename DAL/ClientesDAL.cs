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
                string sql = @"INSERT INTO clientes (cedula, nombre, apellidos, telefono, direccion, ciudad, limitecredito,createby, created)
                                VALUES (@cedula, @nombre, @apellidos, @telefono, @direccion, @ciudad, @limitecredito, @createby, @created)";
                MySqlCommand cmd = new MySqlCommand(sql,con);

                cmd.Parameters.AddWithValue("@cedula",Costumer.Cedula);
                cmd.Parameters.AddWithValue("@nombre",Costumer.Nombre);
                cmd.Parameters.AddWithValue("@apellidos", Costumer.Apellidos);
                cmd.Parameters.AddWithValue("@telefono",Costumer.Telefono);
                cmd.Parameters.AddWithValue("@direccion", Costumer.Direccion);
                cmd.Parameters.AddWithValue("@ciudad", Costumer.Ciudad);
                cmd.Parameters.AddWithValue("@limitecredito",Costumer.Limitecredito);
                cmd.Parameters.AddWithValue("@createby",Costumer.Createby);
                cmd.Parameters.AddWithValue("@created",Costumer.Created);

                Costumer.Idclientes = Convert.ToInt32(cmd.ExecuteScalar());

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
                string sql= @"SELECT Count(*)
                            FROM clientes 
                            WHERE IdClientes=idclientes";
                MySqlCommand cmd = new MySqlCommand(sql,con);

                cmd.Parameters.AddWithValue("idclientes",id);
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
                string sql = @"UPDATE clientes SET
                                cedula = @cedula,
                                nombre = @nombre, apellidos = @apellidos, telefono = @telefono,
                                direccion = @direccion, ciudad = @ciudad, limitecredito = @limitecredito
                                idclientes = @ideclientes                                

                                ";

                MySqlCommand cmd = new MySqlCommand(sql, con);

            }

            return costumer;
        }
    }
}
