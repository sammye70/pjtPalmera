using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pjPalmera.DAL;
using pjPalmera.Entities;

namespace pjPalmera.BLL
{
    public class UsuariosBO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Usuarios"></param>
        /// <returns></returns>
        public static UsuariosEntity Save(UsuariosEntity Usuarios)
        {

            return UsuariosDAL.Create(Usuarios);

        }
    }
}
