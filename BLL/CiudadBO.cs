using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pjPalmera.DAL;
using pjPalmera.Entities;

namespace pjPalmera.BLL
{
    public class CiudadBO
    {
        /// <summary>
        /// Messeger to Result from CostumerBO
        /// </summary>
        public static string strMensajeBO;


        /// <summary>
        /// Create new Customers
        /// </summary>
        /// <param name="Ciudad"></param>
        /// <returns></returns>
        public static void Save(CiudadEntity Ciudad)
        {
            try
            {
                CiudadDAL.Create(Ciudad);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Get All Ciudades
        /// </summary>
        /// <returns></returns>
        public static List<CiudadEntity> GetAll()
        {
            try
            {
                return CiudadDAL.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Verify if exits City
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool CiudadExits(string name)
        {
            try
            {
                var valcriterio = CiudadDAL.CiudadExits(name);

                if (valcriterio == true)
                {
                    strMensajeBO = "La Ciudad indicada fue registrada anteriormente.";
                    return valcriterio;
                }
                else if (valcriterio == false)
                {
                    strMensajeBO = "No existe registro asociado con el indicado";
                    return valcriterio;
                }

                return valcriterio;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
