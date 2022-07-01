using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pjPalmera.Entities;
using pjPalmera.DAL;

namespace pjPalmera.BLL
{
    public class PersonasBO
    {
        /// <summary>
        ///Save Person 
        /// </summary>
        /// <returns></returns>
        public static PersonasEntity Save(PersonasEntity Personas)
        {
            return PersonasDAL.Create(Personas);
        }
    }
}
