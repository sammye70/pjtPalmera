using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
    /// <summary>
    /// Entity User by Class
    /// </summary>
    public class UsuariosEntity
    {
        //Field
        private int id_user;
        private string user_name;
        private string password;
        private string status;
        private int privileges;
        private int createby;
        private DateTime created;
        private string email;

        //Constructor
        public UsuariosEntity()
        {
        }

        public UsuariosEntity(int id_user, string user_name, string password, string status, int privileges, int createby, DateTime created, string email)
        {
            this.Id_user = id_user;
            this.User_name = user_name;
            this.Password = password;
            this.Status = status;
            this.Privileges = privileges;
            this.Createby = createby;
            this.Created = created;
            this.Email = email;
        }

        //Properties
        public int Id_user
        {
            get { return id_user;}

            set { id_user = value;}
        }

        public string Password
        {
            get { return password;}

            set { password = value;}
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public int Createby
        {
            get
            {
                return createby;
            }

            set
            {
                createby = value;
            }
        }

        public DateTime Created
        {
            get
            {
                return created;
            }

            set
            {
                created = value;
            }
        }

        public int Privileges
        {
            get
            {
                return privileges;
            }

            set
            {
                privileges = value;
            }
        }

        public string User_name
        {
            get
            {
                return user_name;
            }

            set
            {
                user_name = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }
    }
}
