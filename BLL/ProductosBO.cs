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
        /// Messeger to Result from ProductBO
        /// </summary>
        public static string strMensajeBO;

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
        /// check if exits stock for current product in storage
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public static bool getCheckStock(decimal stock)
        {
            var result = true;

            if ((stock <= 0) || (stock <= -1))
            {
                strMensajeBO = "No hay Stock disponible del producto";
                return true;
            }
            else if ((stock > 0) || (stock >= 1))
            {
                return false;
            }

            return result;
        }

        /// <summary>
        ///  Get Category Status Product
        /// </summary>
        public static List<ProductStatusEntity> GetStatusProduct()
        {
            try
            {
                return ProductosDAL.GetStatusProduct;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        /// <summary>
        ///  Check if quantity request is than big to stock
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public static bool getStockQuantity(decimal stock, decimal quantity)
        {
            var result = true;

            if (stock < quantity)
            {
                strMensajeBO = "La cantidad de Productos solicitados son mayor que el stock actual. Importante: Se dispone de " + stock + " Unidades. Comunicar a su Supervisor para que elabore una requsicion del producto.";
                return true;
            }
            else if (stock >= quantity)
            {
                // strMensajeBO = "Hay stock suficiente del producto para suplir la solicitud del cliente";
                return false;
            }

            return result;
        }

        /// <summary>
        /// Get Minimal Stock for current product
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static decimal getStock(long code)
        {
            try
            {
                return ProductosDAL.getStock(code);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
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
        /// Get Product Where Status Active/Desable
        /// </summary>
        /// <param name="productos"></param>
        /// <returns></returns>
        public static List<ProductosEntity> GetProductosByStatus(int status)
        {
            try
            {
                return ProductosDAL.GetProductosByStatus(status);
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
        /// Get All Products with details
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
        ///Update Decrease Stock in Databases
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
        /// Filter Only Active Products by Code
        /// </summary>
        /// <returns></returns>
        public static List<ProductosEntity> FilterProductbyCodeOnlyAct(long id)
        {
            try
            {
                return ProductosDAL.FilterProductbyCodeOnlyAct(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }



        /// <summary>
        /// Filter All Products by Code
        /// </summary>
        /// <returns></returns>
        public static List<ProductosEntity> FilterProductbyCodeAll(long id)
        {
            try
            {
                return ProductosDAL.FilterProductbyCodeAll(id);
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
        public static ProductosEntity SearchByCode(long code)
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
        public static List<ProductosEntity> ExpireYear(int year)
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
               var ls = ProductosDAL.StockMinimo();

               if(ls == null)
               {
                    throw new ArgumentNullException("Algo salió mal y no se puedo cargar los articulos.!");
               }
               else
               {
                    return ls;
               }
            }

            catch(ArgumentNullException an)
            {
                MessageBox.Show(an.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        /// <summary>
        /// Count only Active Product
        /// </summary>
        /// <returns></returns>
        public static int CountProduct()
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

        /// <summary>
        ///  Filter Product by Category
        /// </summary>
        /// <returns></returns>
        public static List<ProductosEntity> GetProductByCategory(int number)
        {
            bool error = false;
            try
            {
                return ProductosDAL.GetProductByCategory(number);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                error = true;
                return null;
            }
            finally 
            {
                if (error == true) 
                {
                    MessageBox.Show("No hay datos que mostrar.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }


    }
}
