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
    public class ProveedorBO
    {
        /// <summary>
        /// Save Proveedor
        /// </summary>
        /// <param name="Proveedor"></param>
        /// <returns></returns>
        public static ProveedorEntity Save(ProveedorEntity Proveedor)
        {
            try
            {
                return ProveedorDAL.Create(Proveedor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Get all proveedores
        /// </summary>
        /// <returns></returns>
        public static List<ProveedorEntity> GetAllProveedor()
        {
            try
            {
                return ProveedorDAL.GetAll();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Get All Preveedor by Name
        /// </summary>
        /// <returns></returns>
        public static List<ProveedorEntity> GetAllByName()
        {
            try
            {
                return ProveedorDAL.GetAllByName();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Search proveedor by rnc
        /// </summary>
        /// <returns></returns>
        public static List<ProveedorEntity> SearhByrnc(string rnc)
        {
            try
            {
                return ProveedorDAL.SearchByrnc(rnc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Search Proveedor by Name
        /// </summary>
        /// <returns></returns>
        public static List<ProveedorEntity> SearchByName(string name)
        {
            try
            {
                return ProveedorDAL.SearchByName(name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
