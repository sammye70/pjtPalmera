using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pjPalmera.DAL;
using pjPalmera.Entities;

namespace pjPalmera.BLL
{
    public class CiudadBO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Ciudad"></param>
        /// <returns></returns>
        public static CiudadEntity Save(CiudadEntity Ciudad)
        {
            return CiudadDAL.Create(Ciudad);

        }
    }
}
