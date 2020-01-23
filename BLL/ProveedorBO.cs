using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pjPalmera.DAL;
using pjPalmera.Entities;

namespace pjPalmera.BLL
{
    public class ProveedorBO
    {
        /// <summary>
        /// Save Proveedor
        /// </summary>
        /// <param name="Proveedor"></param>
        /// <returns></returns>
        public static ProveedorEntity Save(ProveedorEntity Proveedor)
        {
            return ProveedorDAL.Create(Proveedor);
        }

        /// <summary>
        /// Get all proveedores
        /// </summary>
        /// <returns></returns>
        public static List<ProveedorEntity> GetAllProveedor()
        {
            return ProveedorDAL.GetAll();
        }

        public static List<ProveedorEntity> GetAllProveedor_()
        {
            return ProveedorDAL.GetAll_();
        }
    }
}
