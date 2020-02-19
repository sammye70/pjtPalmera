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
        /// Search proveedor by Code    //Create in ProveedorDAL
        /// </summary>
        /// <returns></returns>
        public static List<ProveedorEntity> SearchByCode(Int64 code)
        {
            try
            {
                return ProveedorDAL.SearchByCode(code);
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

        /// <summary>
        /// Remove Proveedor from DataBases
        /// </summary>
        /// <param name="code"></param>
        public static void RemoveProveedor(Int64 code)
        {
            try
            {
                ProveedorDAL.RemoveProveedor(code);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Update Proveedor Information 
        /// </summary>
        /// <param name="proveedor"></param>
        /// <returns></returns>
        public static ProveedorEntity Update(ProveedorEntity proveedor)
        {
            try
            {
                return ProveedorDAL.Update(proveedor);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Search by Code to Update Proveedor
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static ProveedorEntity SearchByCodeUpdate(Int64 code)
        {

            try
            {
                return ProveedorDAL.SearchByCodeUpdate(code);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        /// <summary>
        /// Filter Proveedor by Rnc
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static List<ProveedorEntity> FilterByRnc(Int64 code)
        {
            try
            {
                return ProveedorDAL.FilterByRnc(code);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
