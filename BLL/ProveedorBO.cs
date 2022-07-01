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
        /// Messeger to Result from ProviderBO
        /// </summary>
        public static string strMessage;

        /// <summary>
        /// Create new  Proveedor
        /// </summary>
        /// <param name="Proveedor"></param>
        /// <returns></returns>
        public static void Create(ProveedorEntity Proveedor)
        {            
            try
            {
                if((Proveedor == null) || (Proveedor.Idproveedor == 0))
                {
                    throw new ArgumentNullException("No hay datos que salvar.");
                }
                else
                {
                    var result = ProveedorDAL.Create(Proveedor);

                    if(result == 1)
                    {
                        throw new Exception("Registro Guardado Satisfactoriamente!");
                    }
                    else
                    {
                        throw new Exception("Uff, algo salio mal!!!!!!");
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
                var ls = ProveedorDAL.GetAll();

                if(ls == null)
                {
                    return null;
                    throw new Exception("Uff, algo salio mal!!!!!!");
                }
                else 
                {
                    return ls;
                }
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
        public static List<ProveedorEntity> GetProveedorsByName()
        {
            try
            {
                return ProveedorDAL.GetProveedorsByName();
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
        public static List<ProveedorEntity> SearchByName(ProveedorEntity provider)
        {
            try
            {
                return ProveedorDAL.SearchByName(provider);
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
        public static void RemoveProveedor(long code)
        {
            try
            {
                var result = ProveedorDAL.RemoveProveedor(code);

                if(result == 1)
                {
                    throw new ApplicationException("El Suplidor fue Eliminado");
                }
                else
                {
                    throw new Exception("Uff algo salio mal Suplidor no eliminado");
                }

               // ProveedorDAL.RemoveProveedor(code);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        /// <summary>
        /// Update Proveedor Information 
        /// </summary>
        /// <param name="proveedor"></param>
        /// <returns></returns>
        public static void Update(ProveedorEntity proveedor)
        {
            try
            { 
                if((proveedor == null) || (proveedor.Idproveedor == 0))
                {
                    throw new ArgumentNullException("No hay datos que salvar");
                }
                else
                {
                    var result = ProveedorDAL.Update(proveedor);

                    if (result == 1)
                    {
                        throw new AggregateException("Cambios Realizados Satisfactoriamente!");
                    }
                    else 
                    {
                        throw new ArgumentNullException("Uff, algo salido mal!!");
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            catch (AggregateException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Search Proveedor by Code 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static ProveedorEntity SrProviderCode(Int64 code)
        {

            try
            {
                var rs = ProveedorDAL.ProviderByCode(code);

                if(rs == null)
                {
                    throw new ArgumentException("Algo salió mal y no se pudo completar la operaón solicitad.");
                }
                else
                {
                    return rs;
                }
            }

            catch(ArgumentException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
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
                var rs = ProveedorDAL.FilterByRnc(code);

                if (rs == null)
                {
                    throw new ArgumentException("Algo salió mal y no se pudo completar la operaón solicitad.");
                }
                else
                {
                    return rs;
                }
            }

            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Verify if exits Proveedor
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool ProveedorExits(string number)
        {
            var valcriterio = ProveedorDAL.ProveedorExits(number);

            if (valcriterio == true)
            {
                strMessage = "El Proveedor indicado fue registrado anteriormente.";
                return valcriterio;
            }
            else if (valcriterio == false)
            {
                strMessage = "No existen proveedores asociados al que se indica.";
                return valcriterio;
            }

            return valcriterio;
        }

    }
}
