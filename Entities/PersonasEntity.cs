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
        private string cedula;
        private string nombre;
        private string apellidos;
        private string direccion;
        private int edad;
        private DateTime f_nacimiento;
        private string telefono;
        private string posicion;
        private decimal sueldo;


        public string Cedula
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

        public string Posicion
        {
            get
            {
                return posicion;
            }

            set
            {
                posicion = value;
            }
        }

        public decimal Sueldo
        {
            get
            {
                return sueldo;
            }

            set
            {
                sueldo = value;
            }
        }

        public PersonasEntity()
        {
        }

        public PersonasEntity(int id_persona, string cedula, string nombre, string apellidos, string direccion, int edad, DateTime f_nacimiento, string telefono,
            string posicion, decimal sueldo)
        {
            this.Id_persona = id_persona;
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Direccion = direccion;
            this.Edad = edad;
            this.F_nacimiento = f_nacimiento;
            this.Telefono = telefono;
            this.Posicion = posicion;
            this.Sueldo = sueldo;
        }

    }
}
