using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pjPalmera.Entities;
using pjPalmera.DAL;
using System.Windows.Forms;

namespace pjPalmera.BLL
{
    public class CategoriaBO
    {

        /// <summary>
        /// Messeger to Result from ProductBO
        /// </summary>
        public static string strMensajeBO;


        #region Save Categories
        /// <summary>
        /// Save Category
        /// </summary>
        /// <param name="Categoria"></param>
        /// <returns></returns>
        public static CategoriaEntity Save(CategoriaEntity Categoria)
        {
            CategoriaDAL.Create(Categoria);
            return Categoria;
        } 
        #endregion

        #region GetCategories
        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns></returns>
        public static List<CategoriaEntity> GetCategories()
        {
            try
            {
                return CategoriaDAL.GetCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        } 
        #endregion

        #region ExistCategory
        /// <summary>
        /// Verify if exits category
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ExitsCategory(string name)
        {
            var valcriterio = CategoriaDAL.ExitsCategory(name);

            if (valcriterio == true)
            {
                strMensajeBO = "Esta Categoría fue registrada anteriormente";
                return valcriterio;
            }
            else if (valcriterio == false)
            {
                strMensajeBO = "No existe registro asociado con esta categoría";
                return valcriterio;
            }

          return valcriterio;
        }
        #endregion
    }
}
