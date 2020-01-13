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
        public static ClientesEntity Save(ClientesEntity costumer)
        {
            return ClientesDAL.Create(costumer);
            #region
            //Find Costumer
            //if (ClientesDAL.Exits(costumer.idclientes))
            //{
            //    return ClientesDAL.Create(costumer);
            //}
            //else
            //{
            //    return ClientesDAL.Update(costumer);
            //}
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ClientesEntity GetAllCostumer( ClientesEntity costumer)
        {
           return ClientesDAL.GetAllCostumer(costumer);

        }



    }
}
