using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pjPalmera.Entities;
using pjPalmera.DAL;

namespace pjPalmera.BLL
{
    public class CategoriaBO
    {
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

        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns></returns>
        public static List<CategoriaEntity> GetAll()
        {
            return CategoriaDAL.GetAll_();
        }
    }
}
