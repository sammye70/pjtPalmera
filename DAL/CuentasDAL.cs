using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using pjPalmera.Entities;


namespace pjPalmera.DAL
{
   public class CuentasDAL
    {
        /// <summary>
        /// Get Amount Credit by Client
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static decimal Amount(Int64 id)
        {
            decimal balance;
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                var query = @"SELECT SUM(total) FROM venta WHERE venta.id_cliente = @id AND venta.total <> 0;";

                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    balance = Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            return balance;
        }

        /// <summary>
        /// Set Status Credit Value on Costumers
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static ClientesEntity StatusCxc(int status, long id)
        {
            ClientesEntity costumer = new ClientesEntity();
            using (var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                var query = @"UPDATE clientes SET clientes.cxc=@status WHERE id=@id;";
                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@status", status);

                    cmd.ExecuteNonQuery();
                }
            }
            return costumer;
        }


        


        /// <summary>
        ///  Load Account
        /// </summary>
        /// <returns></returns>
        private static ClientesEntity LoadAccount(IDataReader Reader)
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
            costumer.Created = Convert.ToDateTime(Reader["created"]);

            return costumer;
        }
    }
}
