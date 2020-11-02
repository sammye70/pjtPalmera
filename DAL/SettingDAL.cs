using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace pjPalmera.DAL
{
    public class SettingDAL
    {
        /// <summary>
        /// Author: Samuel Estrella
        /// StringConnection
        /// Version: 1.0
        /// Create Date:20/12/2019
        /// Modificated: 
        /// </summary>
        private static readonly string ConnectionString = @"server=192.168.8.110;port=3306;uid=usr;pwd=Abeja30$;database=ebgsolut_abejas"; //Home dev last;
        // static String ConnectionString = @"server=localhost;port=3306;uid=usr;pwd=Abeja30$;database=ebgsolut_abejas;"; // Drog Store ip
        //static String ConnectionString = @"server=192.168.8.124;port=3306;uid=usr;pwd=Abeja30$;database=ebgsolut_abejas_last"; //Home dev

        /// <summary>
        /// ConnectionString to Databases
        /// </summary>
        public static String connectionstring
        { 
            get { return ConnectionString; }
        }

        #region
        //    public void Connect()
        //    {
        //        try
        //        {
        //            ConnectionString = "server=192.168.8.127;port=3306;uid=usr;pwd=Abeja30$;database=ebgsolut_abejas;";
        //            Connections = new MySqlConnection(ConnectionString);
        //            Connections.Open();
        //            MessageBox.Show("Conectado satisfactoriamente");
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }

        //    public void Desconnect()
        //    {
        //        Connections.Close();
        //        MessageBox.Show("Desconectado satisfactoriamente");

        //    }
        //}
        #endregion
    }
}
