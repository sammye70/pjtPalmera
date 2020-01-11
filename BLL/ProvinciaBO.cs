using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pjPalmera.DAL;
using pjPalmera.Entities;

namespace pjPalmera.BLL
{
    public class ProvinciaBO
    {
        /// <summary>
        /// Save new Province
        /// </summary>
        /// <returns></returns>
        public static ProvinciaEntity Save(ProvinciaEntity Provincia)
        {
            return ProvinciaDAL.Create(Provincia);
        }
    }
}
