using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;



namespace _DAL
{
    public class clsConnection
    {
        public String ConnectionString;
        private MySqlConnection Connections;

        public void Connect()
        {
            try
            {
                ConnectionString = "server=192.168.8.127;uid=usr;pwd=Abeja30$;databases=ebgsolut_abejas;";
                Connections = new MySqlConnection(ConnectionString);
                Connections.Open();
                MessageBox.Show("Conectado satisfactoriamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar conectar con la base de datos", ex.Message);
            }
        }

        public void Desconnect()
        {
            Connections.Close();

        }
    }
}
