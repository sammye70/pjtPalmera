using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using pjPalmera.Entities;
using pjPalmera.BLL;
//using pjPalmera.DAL;

namespace pjPalmera.PL
{
    public partial class frmVenta : Form
    {
        public VentaEntity venta = null;
        public decimal precio = 0;
        public float cantidad = 0;
        public long id;
        public Decimal t_pagar=0;

        public frmVenta()
        {
            InitializeComponent();
        }


        private void frmVenta_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            Limpiar();
            LimpiarEfectivo();
            Deshabilitar();
            SetToolControls();
            this.btnNuevo.Focus();
        }

        private void btnBuscarClientes_Click(object sender, EventArgs e)
        {
            if (txtClientes.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un cliente");
                this.txtClientes.Focus();
                return;
            }

            venta = new VentaEntity();
            dgvDetalle.DataSource = venta.Productos;
        }

        /// <summary>
        /// Clear Textbox
        /// </summary>
        private void Limpiar()
        {

            //this.txtClientes.Clear();
            this.txtProductos.Clear();
            this.txtDescripcion.Clear();
            this.txtPrecio.Clear();
            this.txtCantidad.Clear();
            //this.txtSubtotal.Clear();
            //this.txtTotalPagar.Clear();
            // this.txtItbis.Clear();
        }

        /// <summary>
        /// Deshabilita TextBox, Buttons
        /// </summary>
        private void Deshabilitar()
        {
            this.txtClientes.Enabled = false;
            this.txtCantidad.Enabled = false;
            this.txtPrecio.Enabled = false;
            this.txtProductos.Enabled = false;
            this.btnAgregar.Enabled = false;
            this.btnPagar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.cmbTipoVenta.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.txtItbis.Enabled = false;
            this.txtSubtotal.Enabled = false;
            this.txtTotalPagar.Enabled = false;
            this.txtDescuento.Enabled = false;
            this.chbDescuento.Enabled = false;
            this.txtRecibidoEfectivo.Enabled = false;
            this.txtDevueltaEfectivo.Enabled = false;
            this.btnBuscarProducto.Enabled = false;
            this.btnBuscarClientes.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.txtApClientes.Enabled = false;
            this.btnGuardar.Enabled = false;
            if (dgvDetalle == null)
            {
                this.chbDescuento.Enabled = false;
            }
        }

        /// <summary>
        /// Enable TextBox, Buttons
        /// </summary>
        private void Habilitar()
        {
            this.txtClientes.Enabled = true;
            this.txtCantidad.Enabled = true;
            this.txtPrecio.Enabled = true;
            this.txtProductos.Enabled = true;
            this.btnAgregar.Enabled = true;
            this.btnPagar.Enabled = true;
            this.cmbTipoVenta.Enabled = true;
            this.txtDescripcion.Enabled = true;
            this.txtItbis.Enabled = true;
            this.txtSubtotal.Enabled = true;
            this.txtTotalPagar.Enabled = true;
            this.txtDescuento.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.txtRecibidoEfectivo.Enabled = true;
            this.txtDevueltaEfectivo.Enabled = true;
            this.btnBuscarProducto.Enabled = true;
            this.btnBuscarClientes.Enabled = true;
            this.btnEliminar.Enabled = true;
            this.txtApClientes.Enabled = true;
            this.btnGuardar.Enabled = true;
            if (dgvDetalle != null)
            {
                this.chbDescuento.Enabled = true;
            }

        }

        /// <summary>
        /// Change ReadOnly TextBox
        /// </summary>
        private void OnlyRead()
        {
            this.txtSubtotal.ReadOnly = true;
            this.txtTotalPagar.ReadOnly = true;
            this.txtItbis.ReadOnly = true;
            this.txtDescuento.ReadOnly = true;
            this.txtDevueltaEfectivo.ReadOnly = true;
            this.txtApClientes.ReadOnly = true;
            this.txtClientes.ReadOnly = true;
        }

        /// <summary>
        /// Pay Process 
        /// </summary>
        private void Pagar()
        {
            Limpiar();
            OnlyRead();
            this.txtClientes.Clear();
            this.cmbTipoVenta.Text = "";
            this.dgvDetalle.DataSource = null;
            LimpiarEfectivo();
            this.cmbTipoVenta.Focus();
            this.txtRecibidoEfectivo.Text = "0.00";
            this.txtDevueltaEfectivo.Text = "0.00";
        }

        /// <summary>
        /// Remove Items from the Grid  ---> Pendding
        /// </summary>
        private void RemoveItems()
        {

           int  item = this.dgvDetalle.CurrentRow.Index;
           MessageBox.Show("Selecciono el Item:" + item.ToString());

            //if (this.dgvDetalle.CurrentRow.Index != -1)
            //{
            //    this.dgvDetalle.Rows.RemoveAt(1);
            //    MessageBox.Show("Item seleccionado fue Eliminado");
            //}
        }

        #region New Invoice
        /// <summary>
        /// Prepare for New Invoice
        /// </summary>
        private void NewInvoice()
        {
            Habilitar();
            Limpiar();
            LimpiarEfectivo();
            OnlyRead();
            this.txtClientes.Text = "CONTADO";
            this.txtApClientes.Text = "CONTADO";
            venta = new VentaEntity(); //Head invoice
            this.dgvDetalle.DataSource = null;
            this.txtProductos.Focus();
        } 
        #endregion

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NewInvoice();
        }

     

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            InsertItem();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            frmConsultarProductos consulProductos = new frmConsultarProductos();
            //consulProductos.Show();
            consulProductos.ShowDialog(this);
            consulProductos.Text = "Buscar Productos";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            this.txtProductos.Focus();
            //Deshabilitar();
            //this.btnNuevo.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label14.Text = DateTime.Now.ToString("hh:mm:ss tt");
            label15.Text = DateTime.Now.ToLongDateString();
        }

        /// <summary>
        /// Total Pagar
        /// </summary>
        private void SetPagar()
        {
            decimal subtotal, itbis, t_pagar, descuento;
            subtotal = venta.SubTotal();
            // itbis = venta.Itbis();
            itbis=0;
            descuento = venta.Descuento();
            t_pagar = venta.Pagar(itbis, subtotal);
            
            this.txtSubtotal.Text = Convert.ToString(subtotal);
            this.txtItbis.Text = Convert.ToString(itbis);
            this.txtTotalPagar.Text = string.Format( "{0}",t_pagar);
            this.txtDescuento.Text = Convert.ToString(descuento);
        }

        #region Clean Labels
        /// <summary>
        /// Clean labels
        /// </summary>
        private void LimpiarEfectivo()
        {
            this.txtDevueltaEfectivo.Text = "0.00";
            this.txtDescuento.Text = "0.00";
            this.txtTotalPagar.Text = "0.00";
            this.txtItbis.Text = "0.00";
            this.txtSubtotal.Text = "0.00";
            // this.txtRecibidoEfectivo.Text="0.0";
        }
        #endregion

        #region Set Detail of Controls
        /// <summary>
        /// Set Detail about controls
        /// </summary>
        private void SetToolControls()
        {
            this.toolTip1.SetToolTip(this.btnBuscarClientes, "Buscar Clientes");
            this.toolTip1.SetToolTip(this.btnBuscarProducto, "Buscar Productos");
            this.toolTip1.SetToolTip(this.btnCancelar, "Limpia de los campos de cliente, y producto a ser agregados");
            this.toolTip1.SetToolTip(this.btnEliminar, "Eliminar item del carro de compra");
            this.toolTip1.SetToolTip(this.btnPagar, "Efectuar pago de la compra ");
            this.toolTip1.SetToolTip(this.btnAgregar, "Agregar Items a la compra");
            this.toolTip1.SetToolTip(this.btnNuevo, "Crear Nueva Venta");
            this.toolTip1.SetToolTip(this.btnGuardar, "Guardar Compra");
        } 
        #endregion

        #region Descuento

        ///private void chbDescuento_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        decimal descuento, td_pagar, tpagar;
        //        decimal total_pagar, t_itbis, t_itbis_c_pagar;

        //        total_pagar = venta.Pagar(itbis, );
        //        t_itbis = venta.Itbis();
        //        tpagar = venta.SubTotal();

        //        if (this.chbDescuento.Checked == true)
        //        {
        //            descuento = venta.Descuento();
        //            t_itbis_c_pagar = total_pagar + t_itbis;
        //            td_pagar = t_itbis_c_pagar - descuento;
        //            this.txtDescuento.Text = string.Format("{0:C2}", descuento);
        //            this.txtTotalPagar.Text = string.Format("{0:C2}", td_pagar);
        //        }
        //        else
        //        {
        //            t_itbis_c_pagar = t_itbis + total_pagar;
        //            this.txtTotalPagar.Text = string.Format("{0:C2}", t_itbis_c_pagar);
        //            txtDescuento.Clear();
        //            return;
        //        }
        //    }

        //    catch (Exception)
        //    {
        //        MessageBox.Show("Debe indicar un Total a Pagar, asi poder aplicar Descuento", "Mensaje del Sistema", 
        //        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        this.txtProductos.Focus();
        //        return;
        //    }

        //} 
        #endregion

        private void txtRecibidoEfectivo_TextChanged(object sender, EventArgs e)
        {
            //check cash delivery to casher and set change
            try
            {
                decimal itbis, subtotal, cobrar, recibido, devuelta;
                itbis = venta.Itbis();
                subtotal = venta.SubTotal();
                cobrar = venta.Pagar(itbis, subtotal);
                recibido = Convert.ToDecimal(this.txtRecibidoEfectivo.Text);
                devuelta = venta.Cambio_Compras(recibido, cobrar);
                this.txtDevueltaEfectivo.Text = string.Format("{0:C2}", devuelta);
            }
            catch (Exception)
            {

                MessageBox.Show("Debe ingresar efectivo que recibio", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtRecibidoEfectivo.Focus();
            }
        }

        private void txtDevueltaEfectivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {

            if (this.txtRecibidoEfectivo.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar efectivo que recibio", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtRecibidoEfectivo.Focus();
            }
            else
            {
                Pagar();
                MessageBox.Show("Pago realizado", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveItems();
                MessageBox.Show("Item Eliminado");
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione el Item  para Eliminar");
            }

        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // RemoveItems();


            int item;
            if (this.dgvDetalle.SelectedRows.Count > 0)
            {
                item = this.dgvDetalle.CurrentRow.Index;
                MessageBox.Show("Selecciono el Item:"+item);
            }
        }

        private void btnBuscarClientes_Click_1(object sender, EventArgs e)
        {
            frmConsulClientes Consul_Clientes = new PL.frmConsulClientes();
            Consul_Clientes.ShowDialog(this);
        }

        private void txtApClientes_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SaveHeadInvoice();


        }

        #region Validator content in Controls
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Validator()
        {
            bool result = true;

            if (venta == null)
            {
                MessageBox.Show("Debe ingresar un cliente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtClientes.Focus();
                result = false;
            }

            if (this.txtProductos.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un Producto", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtProductos.Focus();
                result = false;
            }


            if (!long.TryParse(txtProductos.Text, out id))
            {
                MessageBox.Show("Debe ingresar un Codigo numerico", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtProductos.Focus();
                result = false;
            }

            if (id <= 0)
            {
                MessageBox.Show("Debe ingresar un Codigo Valido", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtProductos.Focus();
                result = false;
            }


            if (this.txtDescripcion.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar una Descripcion", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtDescripcion.Focus();
                result = false;
            }

            if (this.txtCantidad.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar una cantidad", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCantidad.Focus();
                result = false;
            }


            if (!float.TryParse(txtCantidad.Text, out cantidad))
            {
                MessageBox.Show("Debe ingresar una cantidad numerica", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCantidad.Focus();
                result = false;
            }

            if (cantidad <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad mayor que 0", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCantidad.Focus();
                result = false;
            }

            if (this.txtPrecio.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un precio", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtPrecio.Focus();
                result = false;
            }


            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Debe ingresar un precio valido", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCantidad.Focus();
                result = false;
            }

            if (precio <= 0)
            {
                MessageBox.Show("Debe ingresar un precio mayor que 0", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtPrecio.Focus();
                result = false;
            }

            return result;
        }
        #endregion


        #region Insert item the list
            /// <summary>
            /// Insert Item to list
            /// </summary>
            public void InsertItem()
            {
            if (!Validator())
                return;
                
                    //add products to Gridview
                    DetalleVentaEntity Detail = new DetalleVentaEntity();

                    Detail.ID = int.Parse(txtProductos.Text);
                    Detail.DESCRIPCION = txtDescripcion.Text;
                    Detail.CANTIDAD = Int32.Parse(this.txtCantidad.Text);
                    Detail.PRECIO = decimal.Parse(this.txtPrecio.Text);
                    dgvDetalle.DataSource = null;
                    venta.addProduct(Detail);

                    dgvDetalle.DataSource = venta.Productos;  //Data from List to DataGridView

                    SetPagar();
                    Limpiar();
                    this.txtProductos.Focus();
                
             }
        #endregion


        /// <summary>
        /// Save head invoice
        /// </summary>
        public void SaveHeadInvoice()
        {
            try
            {

                venta = new VentaEntity();
                venta.clientes = this.txtClientes.Text;
                venta.apellidos = this.txtApClientes.Text;
                venta.total= decimal.Parse(this.txtTotalPagar.Text);
                venta.status = 1;
                if ((this.txtClientes.Text == "CONTADO") && (this.txtApClientes.Text == "CONTADO"))
                {
                    venta.tipo = "1";
                }
                else
                {
                    venta.tipo = "2";
                }

                FacturaBO.Create(venta);
                MessageBox.Show("Guardado Exitosamente","Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }

}



