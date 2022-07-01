using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
    /// <summary>
    /// Entity User by Class for login
    /// </summary>
    public class UsuariosEntity
    {
        //Field
        private int id_user;
        private string firstname;   //
        private string lastname;    //
        private string long_name;   //
        private string user_name;   //
        private string password;    //
        private string status;      //
        private string privileges;     //
        private string email;       //
        private string secret_question1;
        private string secret_answer1;
        private int createby;
        private DateTime created;
        private int op;
     // private UserTypeEntity GetUserType;

        //Constructor
        public  UsuariosEntity()
        {
        }

        public UsuariosEntity(int id_user, string user_name, string password, string status, string privileges, int createby, DateTime created, string email/*, UserTypeEntity getusertype*/)
        {
            this.Id_user = id_user;
            this.User_name = user_name;
            this.Password = password;
            this.Status = status;
            this.Privileges = privileges;
            this.Createby = createby;
            this.Created = created;
            this.Email = email;
          //  this.GetUserType.Id = getusertype.Id;
        }

        //Properties

        public int Id_user
        {
            get { return id_user; }

            set { this.id_user = value; }
        }

        public string User_name
        {
            get
            {
                return user_name;
            }

            set
            {
                this.user_name = value;
            }
        }

        public string Firstname 
        {
            set { this.firstname = value; }
            get { return this.firstname; }
        }

        public string Lastname
        {
            set { this.lastname = value; }
            get { return this.lastname; }
        }

        public string LongName
        {
            set { this.long_name= value; }
            get { return this.long_name; }
        }

        public string Password
        {
            get { return password;}

            set { this.password = value;}
        }

        public string Status
        {
            get { return status; }

            set { this.status = value;}
        }

        public int Createby
        {
            get { return createby;}

            set { this.createby = value;}
        }

        public DateTime Created
        {
            get
            {
                return created;
            }

            set
            {
                this.created = value;
            }
        }

        public string Privileges
        {
            get
            {
                return privileges;
            }

            set
            {
               this.privileges = value;
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
                this.email = value;
            }
        }

        public string Secret_question 
        {
            get { return secret_question1; }
            set { this.secret_question1 = value; }
        }

        public string Secret_answer
        {
            get { return secret_answer1; }
            set { this.secret_answer1 = value; }
        }

        public int Op
        {
            get { return op;}
            set { value = op; }
        }


        /// <summary>
        ///  Concatenation string
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <returns>long_name</returns>
        public string ContName(string firstname, string lastname)
        {
            string long_name;
            long_name = firstname + " " + lastname;
            return long_name;
        }

        /// <summary>
        /// Generate Encrypt for String
        /// </summary>
        /// <param name="str"></param>
        /// <returns>hash</returns>
        public  string setHash(string str)
        {
            byte[] data = Encoding.ASCII.GetBytes(str);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string hash = System.Text.Encoding.ASCII.GetString(data);

            return hash;
        }
    }
}
