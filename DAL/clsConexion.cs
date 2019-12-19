using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DAL
{
    class clsConexion
    {
        public String ConnectionString;
        private  SqlConnection Connection;

        public void Conectar()
        {
            try
            {
                ConnectionString = @"Data Source=SRV-SQL\SQLEXPRESS;Initial Catalog=;Integrated Security=SSPI;";
                Connection = new SqlConnection(ConnectionString);
                Connection.Open();
                MessageBox.Show("Conectado satisfactoriamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar conectar con la base de datos", ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }
        public void Desconectar()
        {
            Connection.Close();
        }


    }
}
