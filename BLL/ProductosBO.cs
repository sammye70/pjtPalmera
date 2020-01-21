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

        /// <summary>
        ///Update Decrease Stock on Databases
        /// </summary>
        public static void Decrease_Stock(VentaEntity producto)
        {
            try
            {
                ProductosDAL.Decrease_Stock(producto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        /// <summary>
        /// Increment Stock in product
        /// </summary>
        /// <param name="producto"></param>
        public static void Increment_Stock(ProductosEntity producto)
        {
            try
            {
                ProductosDAL.Increment_Stock(producto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
    }
}
