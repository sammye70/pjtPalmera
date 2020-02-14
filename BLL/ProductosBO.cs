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

        public static bool result = true;

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
        /// Search Product by Id
        /// </summary>
        /// <returns></returns>
        public static ProductosEntity SearchByOrden(Int64 id)
        {
            try
            {
                return ProductosDAL.SearchByOrden(id);
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

        /// <summary>
        /// Update Information about some product
        /// </summary>
        /// <param name="producto"></param>
        public static void Update_Info_Product(ProductosEntity producto)
        {
            try
            {
                ProductosDAL.Update_info_product(producto);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        /// <summary>
        /// Filter Products by Code
        /// </summary>
        /// <returns></returns>
        public static List<ProductosEntity> FilterProductbyCode(Int64 id)
        {
            try
            {
               return ProductosDAL.FilterProductbyCode(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }


        /// <summary>
        /// Search Products by Code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static ProductosEntity SearchByCode(Int64 code)
        {
                try
                {
                    return ProductosDAL.SearchByCode(code);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return null;
                }
        }


        /// <summary>
        /// Filter Products by Description
        /// </summary>
        /// <returns></returns>
        public static List<ProductosEntity> FilterProductbyDescp(string descripcion)
        {
            try
            {
                return ProductosDAL.FilterProductbyDescp(descripcion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        /// <summary>
        /// Delete Product from Databases
        /// </summary>
        /// <param name="code"></param>
        public static void DeleteProduct(Int64 code)
        {        
            try
            {
                    ProductosDAL.DeleteProduct(code);
            }
               catch (Exception)
            {
                    throw;
            }
        }
    }
}
