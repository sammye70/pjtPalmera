using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pjPalmera.Entities;

namespace pjPalmera.Entities
{
    public class UserTypeEntity
    {

        private int id;
        private string name_type;

        UserTypeEntity() 
        { 
        }

        public UserTypeEntity(int id, string name_type)
        {
            this.Id = id;
            this.Name_type = name_type;
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name_type
        {
            get { return name_type; }
            set { name_type = value; }
        }
    }
}
