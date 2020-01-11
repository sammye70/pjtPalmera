using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
    public class PersonasEntity
    {
        private int id_persona;
        private long cedula;
        private string nombre;
        private string apellidos;
        private string direccion;
        private int edad;
        private DateTime f_nacimiento;
        private string telefono;


        public long Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }

        public int Id_persona
        {
            get { return id_persona; }
            set { id_persona = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public DateTime F_nacimiento
        {
            get { return f_nacimiento; }
            set { f_nacimiento= value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

       public PersonasEntity()
       {
       }

        public PersonasEntity(int Id_persona, long Cedula, string Nombre, string Apellidos, string Direccion, int Edad, DateTime F_nacimiento, string Telefono )
        {
            this.id_persona = Id_persona;
            this.cedula = Cedula;
            this.nombre = Nombre;
            this.apellidos = Apellidos;
            this.direccion = Direccion;
            this.edad = Edad;
            this.f_nacimiento = F_nacimiento;
            this.telefono = Telefono;
        }

    }
}
