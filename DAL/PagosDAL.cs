using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using pjPalmera.Entities;
using pjPalmera.DAL;

namespace pjPalmera.DAL
{
    public class PagosDAL
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagos"></param>
        /// <returns></returns>
        public static PagosEntity Create(PagosEntity pagos)
        {
            using ( var con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                var query = @"INSERT INTO history_pagos ()
                                    VALUES()";

                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("", pagos.Id_cliente);
                    cmd.Parameters.AddWithValue("", pagos.Pago);
                    cmd.Parameters.AddWithValue("", pagos.Recibido);
                    cmd.Parameters.AddWithValue("", pagos.Devuelta);
                    cmd.Parameters.AddWithValue("", pagos.Balance_actual);
                    cmd.Parameters.AddWithValue("", pagos.Balance_antes_pago);
                    cmd.Parameters.AddWithValue("", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }

            }
            return pagos;
        }
    }
}
