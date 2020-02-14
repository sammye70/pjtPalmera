using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
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
            try
            {
                return ClientesDAL.Create(costumer);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
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
        ///Get all Costumers 
        /// </summary>
        /// <returns></returns>
        public static List<ClientesEntity> GetAll()
        {
            try
            {
                return ClientesDAL.GetAll();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        /// <summary>
        /// Get Users by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static ClientesEntity GetbyId(Int64 Id)
        {
            try
            {
                return ClientesDAL.GetbyId(Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        /// <summary>
        /// Filter Costumer by cedula
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        public static List<ClientesEntity> GetbyCedula(Int64 cedula)
        {
            try
            {
                return ClientesDAL.GetbyCedula(cedula);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }


    }
}
