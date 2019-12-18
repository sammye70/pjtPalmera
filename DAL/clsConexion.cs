using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.sqlClient;
using System.Windows.Forms;

namespace DAL
{
    class clsConexion
    {
        public String ConnectionString;
        private sqlConnection Connection;

        public void Conectar()
        {
           try {

            ConnectionString = "";
            Connection = new sqlConnection(ConnectionString);
            Connection.Open();
            MessagerBox.Show("");
           }
           Catch(Exception ex){
               MessagerBox.Show("", ex.Message);
           }
           Finally{

               Desconectar();
           }
        }

        public void Desconectar()
        {
            Connection.Close();

        }


    }
}
