using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pjPalmera.Entities;
using pjPalmera.DAL;

namespace pjPalmera.BLL
{
    public class OperationsCajaBO
    {
        /// <summary>
        /// Messeger to Result from CostumerBO
        /// </summary>
        public static string strMensajeBO;

        /// <summary>
        /// Save History Detail About process Open Box
        /// </summary>
        /// <param name="Ocaja"></param>
        /// <returns></returns>
        public static void CreateHistoryOpenBox(OperationsCajaEntity Ocaja)
        {
            try
            {
                var result = OperationsCajaDAL.CreateHistoryOpenBox(Ocaja);

                if (result != 1)
                {
                    throw new Exception("No fue posible realizar la operación indicada.");
                }
            }

            catch (ApplicationException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        /// <summary>
        /// Save process Open Box until Close Box
        /// </summary>
        /// <param name="Ocaja"></param>
        public static void CreateOpenBox(OperationsCajaEntity oCaja)
        {
            try
            {
                var result = OperationsCajaDAL.CreateOpenBox(oCaja);
                if (result >= 1)
                {
                    throw new ApplicationException("Operación realizada satisfactoriamente.");
                }
                else
                {
                    throw new Exception("No fue posible realizar la operación indicada.");
                }
            }

            catch (ApplicationException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            catch (Exception ex)
            {
                // throw new Exception(ex.Message);
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// By: sammye70
        /// created: 10/02/2021
        /// Modificated by: sammye70
        /// Modificated Date:
        /// <summary>
        ///  Get Status Box (It will return 0 when was closed and otherwise 1 because was opened )
        /// </summary>
        /// <returns></returns>
        public static int GetStatusBox(OperationsCajaEntity oCaja)
        {
            var status = OperationsCajaDAL.GetStatusBox(oCaja);

            if (status == 0)
            {
                strMensajeBO = "No tiene Caja aperturada";
                return status;
            }
            else if (status == 1)
            {
                strMensajeBO = "El Usuario tiene una Caja Aperturada actualmente.\n Para continuar primero debe cerrar la misma.\n" +
                                "\nCualquier asistencia contactar supervisor.";
                return status;
            }

            return status;
        }

        /// <summary>
        /// Get Current Amount used open box
        /// </summary>
        /// <returns></returns>
        public static decimal GetAmount()
        {
            try
            {
                return OperationsCajaDAL.GetAmount();
            }
            catch
            {
                // MessageBox.Show("No se ha Abierto la Caja", "Mensaje del Sistema");
                return 0;
            }
        }

        /// <summary>
        ///  Gell all operations opened and closed box when admin selected user id
        /// </summary>
        public static List<OperationsCajaEntity> GetAllOpBox(OperationsCajaEntity oCaja)
        {
            try
            {
                var ls = OperationsCajaDAL.GetAllOpBox(oCaja);

                if (ls == null)
                {
                    throw new ApplicationException("No posible inicializar la lista  de Operaciones de la caja.");
                }
                else
                {
                    return ls;
                }
            }

            catch (ApplicationException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Código de Error " + ex.Data, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        ///  Get All Operations By user and date (admin or casher request)
        /// </summary>
        public static List<OperationsCajaEntity> getOperationsByUserDate(OperationsCajaEntity oCaja)
        {
            try
            {

                var ls = OperationsCajaDAL.getOperationsByUserDate(oCaja);

                if (ls == null)
                {
                    throw new ApplicationException("No posible inicializar la lista  de Operaciones de la caja.");
                }
                else
                {
                    return ls;
                }
            }

            catch (ApplicationException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        /// <summary>
        ///  Get Operations opened or closed by Type
        /// </summary>
        /// <param name="oCaja"></param>
        /// <returns></returns>
        public static List<OperationsCajaEntity> GetOpByUserDateType(OperationsCajaEntity oCaja)
        {
            try
            {
                var ls = OperationsCajaDAL.GetOpByUserDateType(oCaja);

                if (ls == null)
                {
                    throw new ApplicationException("No posible inicializar la lista  de Operaciones de la caja.");
                }
                else
                {
                    return ls;
                }
            }

            catch (ApplicationException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }


        /// <summary>
        ///  Get Operations Types in History Box
        /// </summary>
        public static List<OperationsTypeEntity> getListOpType
        {
            get
            {
                try
                {
                    var ls = OperationsCajaDAL.getListOpType;

                    if (ls == null)
                    {
                        throw new ApplicationException("No posible inicializar la lista  categoria operaciones en caja.");
                    }
                    else
                    {
                        return ls;
                    }

                }
                catch (ApplicationException ae)
                {
                    MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return null;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }


        /// <summary>
        ///  Get Current selected operations, then return details                
        /// </summary>
        /// <param name="oCaja"></param>
        /// <returns></returns>
        public static OperationsCajaEntity getCurrentOperation(OperationsCajaEntity oCaja)
        {
            try
            {
                var rs = OperationsCajaDAL.getCurrentOperation(oCaja);

                if (rs.Monto <= 0)
                {
                    throw new ApplicationException("No posible mostrar la operación de caja que fue seleccionada.");
                }
                else
                {
                    return rs;
                }
            }
            catch (ApplicationException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        /// <summary>
        /// Get Amount Total pays to any credit account
        /// </summary>
        /// <returns></returns>
        public static decimal MontoPays(OperationsCajaEntity cCaja)
        {
            try
            {
                var val1 = OperationsCajaBO.MontoPaysCash(cCaja);
                var val2 = OperationsCajaBO.MontoPaysCreditCard(cCaja);
                var result = val1 + val2;

                if (result <= 0)
                {
                    return 0;
                }
                else
                {
                    return result;
                }
            }

            catch //(Exception ex)
            {
                //MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Get Amount Total pays to any credit account but with credit card
        /// </summary>
        /// <returns></returns>
        public static decimal MontoPaysCreditCard(OperationsCajaEntity cCaja)
        {
            try
            {
                var result = OperationsCajaDAL.MontoPaysCreditCard(cCaja);
  
                if (result <= 0)
                {
                    return 0;
                }
                else
                {
                    return result;
                }
            }
            
            catch //(Exception ex)
            {
               // MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

 
        /// <summary>
        /// Get Amount Total pays to any credit account but with cash
        /// </summary>
        /// <returns></returns>
        public static decimal MontoPaysCash(OperationsCajaEntity cCaja)
        {
            try
            {
                var result = OperationsCajaDAL.MontoPaysCash(cCaja);

                if (result <= 0)
                {
                    return 0;
                }
                else
                {
                    return result;
                }
            }
           
            catch //(Exception ex)
            {
                //MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }


        /// <summary>
        /// Get Amount Total Invoices
        /// </summary>
        /// <returns></returns>
        public static decimal MontoVentas(OperationsCajaEntity cCaja)
        {
            try
            {
                var result = OperationsCajaDAL.MontoVentas(cCaja);

                if (result <= 0)
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
        /// Get Amount Total sells with Cash
        /// </summary>
        /// <param name="cCaja"></param>
        /// <returns></returns>
        public static decimal MontoSellsCash(OperationsCajaEntity cCaja)
        {
            try
            {
                var result = OperationsCajaDAL.MontoSellsCash(cCaja);

                if (result <= 0)
                {
                    return 0;
                }
                else
                {
                    return result;
                }
            }
            
            catch //(Exception ex)
            {
                //MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }


        /// <summary>
        /// Get Amount Total sells with Credit Card
        /// </summary>
        /// <param name="cCaja"></param>
        /// <returns></returns>
        public static decimal MontoSellsCreditCard(OperationsCajaEntity cCaja)
        {
            try
            {
                var result = OperationsCajaDAL.MontoSellsCreditCard(cCaja);

                if (result <= 0)
                {
                    return 0;
                }
                else
                {
                    return result;
                }
            }

            catch //(Exception ex)
            {
                //MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Remove Transtactions temp by user id
        /// </summary>
        public static void CleanTranstactions(OperationsCajaEntity cCaja)
        {
            try
            {
                var result = OperationsCajaDAL.CleanTranstactions(cCaja);

                if (result <= 0)
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
        public static void CreateHistoryCloseBox(OperationsCajaEntity cCaja)
        {

            try
            {
                var rs = OperationsCajaDAL.CreateHistoryCloseBox(cCaja);

                if (rs <= 0)
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
            OperationsCajaDAL.CleanOpenBox();
        }

    }
}
