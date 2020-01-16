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
    public class ProductosBO
    {
        /// <summary>
        /// Save Product
        /// </summary>
        /// <param name="Producto"></param>
        /// <returns></returns>
        public static ProductosEntity Save(ProductosEntity Producto)
        {
            try
            {
                return ProductosDAL.Create(Producto);
            }
            catch (Exception ex)
            {
            
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;

            }
        }

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns></returns>
        public static List<ProductosEntity> GetAll()
        {
            try
            {
                return ProductosDAL.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
    }
}
