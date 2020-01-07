using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using pjPalmera.Entities;
using pjPalmera.DAL;

namespace pjPalmera.BLL
{
    public class ClientesBO
    {
        /// <summary>
        /// Save costumer
        /// </summary>
        /// <param name="costumer"></param>
        /// <returns></returns>
        public static ClientesEntity Save (ClientesEntity costumer )
        {
            if (ClientesDAL.Exits(costumer.Idclientes))
            {
                return ClientesDAL.Create(costumer);
            }
            else
                {
                  return ClientesDAL.Update(costumer);
                }
        }


    }
}
