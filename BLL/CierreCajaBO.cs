using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using pjPalmera.Entities;
using pjPalmera.DAL;

namespace pjPalmera.BLL
{
    public class CierreCajaBO
    {
        /// <summary>
        /// Get Amount Total Invoices
        /// </summary>
        /// <returns></returns>
        public static decimal MontoVentas(CierreCajaEntity cCaja)
        {
            try
            {
                var result =  CierreCajaDAL.MontoVentas(cCaja);

                if(result <= 0)
                {
                    throw new ApplicationException("El usuario actual no tiene una Caja aperturada para el proceso de ventas.");
                }
                else
                {
                    return result;
                }
            }
            catch (ApplicationException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return 0;
            }

            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return 0;
            }
        }

        /// <summary>
        /// Remove Transtactions temp by user id
        /// </summary>
        public static void CleanTranstactions(CierreCajaEntity cCaja)
        {
            try
            {
                var result = CierreCajaDAL.CleanTranstactions(cCaja);
                
                if(result <= 0)
                {
                    throw new ArgumentNullException("Error interno al intentar actualizar los almacenes de datos");
                }
            }

            catch (ArgumentNullException ax)
            {
                MessageBox.Show(ax.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        /// <summary>
        /// Save History Header and Detail About process Close Box
        /// </summary>
        /// <param name="Ocaja"></param>
        /// <returns></returns>
        public static void CreateHistoryCloseBox(CierreCajaEntity cCaja)
        {

            try 
            {
                var result = CierreCajaDAL.CreateHistoryCloseBox(cCaja);

                if (result <= 0)
                {
                    throw new ArgumentNullException("Algo ocurrio y no se pudo completar la operación solicitada");
                }
                else
                {
                    throw new ApplicationException("Operación realizada satisfactoriamente!");
                }
            }

            catch (ApplicationException ax)
            {
                MessageBox.Show(ax.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            catch (ArgumentNullException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

            /// <summary>
            /// Clean Open Box
            /// </summary>
            public static void CleanOpenBox() 
        {
            CierreCajaDAL.CleanOpenBox();

        }
    }
}
