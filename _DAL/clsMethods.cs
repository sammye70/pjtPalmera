using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace _DAL
{
    
    /// <summary>
    /// Author: Samuel Estrella
    /// Created: 21/12/2019
    /// 
    /// </summary>
    public class clsMethods
    {
        public static MySqlCommand CreateCommand()
        {
            String _ConnectionStr = clsSettings.connectionstring;
            MySqlConnection _Connection = new MySqlConnection(_ConnectionStr);
            _Connection.ConnectionString = _ConnectionStr;
            MySqlCommand _command = new MySqlCommand();
            _command = _Connection.CreateCommand();
            _command.CommandType = CommandType.Text;
            return _command;
        }

    }
}
