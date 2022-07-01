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
    public class ProvinciaBO
    {

        /// <summary>
        /// Messeger to Result from ProvinciaBO
        /// </summary>
        public static string strMessage;

        /// <summary>
        /// Save new Province
        /// </summary>
        /// <returns></returns>
        public static ProvinciaEntity Save(ProvinciaEntity Provincia)
        {
            try
            {
                return ProvinciaDAL.Create(Provincia);
            }
            catch (Exception ex)
            {
                strMessage = ex.Message;
                MessageBox.Show(strMessage, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static List<ProvinciaEntity> GetAll()
        {
            try
            {
                return ProvinciaDAL.GetAll();
            }
            catch (Exception ex)
            {
                strMessage = ex.Message;
                MessageBox.Show(strMessage, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        /// <summary>
        ///  Verify if exits provincia rnc
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ExitsProvincia(string name)
        {
            var valcriterio = ProvinciaDAL.ExitsProvincia(name);

            if (valcriterio == true)
            {
                strMessage = "La Provincia indicada fue registrada anteriormente.";
                return valcriterio;
            }
            else if (valcriterio == false)
            {
                strMessage = "No hay registros asociados con la provincia indicada";
                return valcriterio;
            }

            return valcriterio;
        }

    }
}
