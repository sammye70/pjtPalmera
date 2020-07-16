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
        /// Amount Total Cost All Products where only status Active
        /// </summary>
        /// <returns></returns>
        public static decimal GetAmountAllProducts()
        {
            try
            {
                return ProductosDAL.GetAmountAllProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
        }



        /// <summary>
        /// Get Product Where Status Active
        /// </summary>
        /// <param name="productos"></param>
        /// <returns></returns>
        public static List<ProductosEntity> GetProductosActive(ProductosEntity productos)
        {
            try
            {
                return ProductosDAL.GetProductosActive(productos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }



        /// <summary>
        /// Get Product Where Status Desable
        /// </summary>
        /// <param name="productos"></param>
        /// <returns></returns>
        public static List<ProductosEntity> GetProductosDesable(ProductosEntity productos)
        {

            try
            {
                return ProductosDAL.GetProductosDesable(productos);
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
                return ProductosDAL.All;
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
        public static ProductosEntity SearchByOrden(long id)
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
                MessageBox.Show(ex.ToString(), "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        /// Update Stock (inscrement) on table productos after Desable Invoice
        /// </summary>
        /// 
        /// Author: Samuel Estrella
        /// Created: 07/07/2020
        public static void InscrementAfterDesable(VentaEntity venta)
        {
            try
            {
               ProductosDAL.InscrementAfterDesable(venta);
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
               catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        /// <summary>
        /// Filter Product near to expire date
        /// </summary>
        /// <param name="DateNow"></param>
        /// <param name="DateExpire"></param>
        /// <returns></returns>
        public static List<ProductosEntity> ProductExpire()
        {
            try
            {
                return ProductosDAL.ProductExpire;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        /// <summary>
        /// Filter product by Expire Date (Month and Year)
        /// </summary>
        public static List<ProductosEntity> ExpireDate(Int32 month, Int32 year)
        {
            try
            {
                return ProductosDAL.ExpireDate(month, year);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        /// <summary>
        /// Filter product Expire Date by Year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static List<ProductosEntity> ExpireYear(Int32 year)
        {
            try
            {
                return ProductosDAL.ExpireYear(year);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
        /// <summary>
        /// Filter product and show only active
        /// </summary>
        /// <returns></returns>
        public static List<ProductosEntity> OnlyActive()
        {
            try
            {
                return ProductosDAL.OnlyActive();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        /// <summary>
        /// Filter Product by Status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static List<ProductosEntity> FilterByStatus(string status)
        {
            try
            {
                return ProductosDAL.FilterByStatus(status);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }


        /// <summary>
        /// Filter Product near to stock minimal
        /// </summary>
        /// <returns></returns>
        public static List<ProductosEntity> StockMinimo()
        {
            try
            {
                return ProductosDAL.StockMinimo();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }


        /// <summary>
        /// Count only Active Product
        /// </summary>
        /// <returns></returns>
        public static Int32 CountProduct()
        {
            try
            {
                return ProductosDAL.CountProduct();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
        }
        
     }
}
