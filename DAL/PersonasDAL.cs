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
  public  class PersonasDAL
    {
       public static PersonasEntity Create(PersonasEntity Personas)
        {
            using (MySqlConnection con = new MySqlConnection(SettingDAL.connectionstring))
            {
                con.Open();
                string sql = @"INSERT INTO personas (id_persona, nombre, apellidos, direccion, edad, telefono, posicion, sueldo, cedula)
                                VALUES(@id_persona, @nombre, @apellidos, @direccion, @edad, @telefono, @posicion, @sueldo, @cedula)";

                MySqlCommand cmd = new MySqlCommand(sql,con);

                cmd.Parameters.AddWithValue("@id_persona", Personas.Id_persona);
                cmd.Parameters.AddWithValue("@nombre", Personas.Nombre);
                cmd.Parameters.AddWithValue("@apellidos", Personas.Apellidos);
                cmd.Parameters.AddWithValue("@direccion", Personas.Direccion);
                cmd.Parameters.AddWithValue("@edad", Personas.Edad);
                cmd.Parameters.AddWithValue("@telefono", Personas.Telefono);
                cmd.Parameters.AddWithValue("@posicion", Personas.Posicion);
                cmd.Parameters.AddWithValue("@sueldo", Personas.Sueldo);
                cmd.Parameters.AddWithValue("@cedula", Personas.Cedula);

                Personas.Id_persona = Convert.ToInt32(cmd.ExecuteScalar());

            }
           return Personas;
        }


    }
}
