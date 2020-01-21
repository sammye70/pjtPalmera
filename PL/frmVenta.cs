using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
       // public VentaEntity detail = null;
        VentaEntity detail = new VentaEntity();
        ProductosEntity producto = new ProductosEntity();
        public ClientesEntity clientes = new ClientesEntity();
        public decimal precio = 0;
        public float cantidad = 0;
        public long id;
        public Decimal t_pagar = 0;

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

            int item = this.dgvDetalle.CurrentRow.Index;
            MessageBox.Show("Selecciono el Item:" + item.ToString());

            //if (this.dgvDetalle.CurrentRow.Index != -1)
            //{
            //    this.dgvDetalle.Rows.RemoveAt(1);
            //    MessageBox.Show("Item seleccionado fue Eliminado");
            //}
        }

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
            itbis = 0;
            descuento = venta.Descuento();
            t_pagar = venta.Pagar(itbis, subtotal);

            this.txtSubtotal.Text = Convert.ToString(subtotal);
            this.txtItbis.Text = Convert.ToString(itbis);
            this.txtTotalPagar.Text = string.Format("{0}", t_pagar);
            this.txtDescuento.Text = Convert.ToString(descuento);
        }



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



            frmCobros pay = new frmCobros();
            pay.ShowDialog(this);

            //if (this.txtRecibidoEfectivo.Text == string.Empty)
            //{
            //    MessageBox.Show("Debe ingresar efectivo que recibio", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    this.txtRecibidoEfectivo.Focus();
            //}
            //else
            //{
            //    Pagar();
            //    MessageBox.Show("Pago realizado", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
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
                MessageBox.Show("Selecciono el Item:" + item);
            }
        }

        private void btnBuscarClientes_Click_1(object sender, EventArgs e)
        {
            frmConsulClientes Con_Clientes = new PL.frmConsulClientes();

            if (Con_Clientes.ShowDialog() == DialogResult.OK)
            {
                this.txtIdCliente.Text = Convert.ToString(ClientesBO.GetbyId(clientes.Id));
                this.txtClientes.Text = clientes.Nombre;
                this.txtApClientes.Text = clientes.Apellidos;
            }
        }

        

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Save_Invoices();
           // PrintTicket();
           
        }


        #region Invoice paid cash
        /// <summary>
        /// Print Bill
        /// </summary>
        /// Bill print Setting
        /// Author: Samuel Estrella
        /// Date: 17/01/2020
        private void PrintTicket()
        {

            //Parameters
            PrintDocument pd = new PrintDocument();
            PaperSize pz = new PaperSize("", 420, 520);
            pd.PrintPage += Pd_PrintPage;

            pd.PrintController = new StandardPrintController();

            pd.DefaultPageSettings.Margins.Left = 0;

            pd.DefaultPageSettings.Margins.Right = 0;

            pd.DefaultPageSettings.Margins.Top = 0;

            pd.DefaultPageSettings.Margins.Bottom = 0;


            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Bill Cash Header, Detail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            //TicketVentaEntity tk = new TicketVentaEntity();
            //Parameters
            Font fBody = new Font("Lucida Console", 8, FontStyle.Regular);// Format Font for Body
            Font ffTitle = new Font("Lucida Console", 11, FontStyle.Bold); // Format Font for Title Company Name
            Font fTitle = new Font("Lucida Console", 9, FontStyle.Bold); // Format Font for Title
            Font fdpTitle = new Font("Lucida Console", 8, FontStyle.Bold); // Format Font Detail Products
            Font fdTitle = new Font("Lucida Console", 7, FontStyle.Bold);//Format Font for Detail Title (Address,Telephone, etc.. About Company Information)
            Graphics g = e.Graphics;
            SolidBrush sb = new SolidBrush(Color.Black); // Set Brush color for Drawing Charaters
            string Type = "FACTURA AL CONTADO"; //Type of invoice

            RawPrinterHelper j = new RawPrinterHelper(); //

            //Header invoice
            g.DrawString("Farmacia CRM", ffTitle, sb, 75, 120);
            g.DrawString("Donde tu Salud es Nuestra Prioridad", fTitle, sb, 10, 133);
            g.DrawString("C/9, #5, Las Escobas, Jima Arriba", fdTitle, sb, 50, 148);
            g.DrawString("RNC:80700148433", fdTitle, sb, 80, 160);
            g.DrawString("Tel: 809-954-9952", fdTitle, sb, 80, 175);
            g.DrawString("Whatsapp:809-851-2775", fdTitle, sb, 70, 185);

            g.DrawString("FECHA:", fTitle, sb, 10, 210);
            g.DrawString(DateTime.Now.ToShortDateString(), fBody, sb, 80, 210);
            g.DrawString("CLIENTE:", fTitle, sb, 10, 220);
            g.DrawString(this.txtClientes.Text, fBody, sb, 80, 220);
            g.DrawString(this.txtApClientes.Text, fBody, sb, 180, 220);
            g.DrawString("NCF:", fTitle, sb, 10, 232);
            g.DrawString("NIF:", fTitle, sb, 10, 244);

            if ((this.txtClientes.Text != "CONTADO") && (this.txtApClientes.Text != "CONTADO"))
            {
                Type = "FACTURA A CREDITO";
            }
            if ((this.txtClientes.Text == "CONTADO") && (this.txtApClientes.Text == "CONTADO"))
            {
                this.txtApClientes.Text = "";
            }

            g.DrawString(Type, fTitle, sb, 75, 255);

            //Detail Invoice
            g.DrawString("----------------------------------------------", fBody, sb, 5, 280);
            g.DrawString("CODIGO   DESCRIPCION    CANT PRECIO  IMPORTE", fdpTitle, sb, 11, 290);
            g.DrawString("----------------------------------------------", fBody, sb, 5, 298);
            int AutoScrollOffset = +14;
            int a = this.dgvDetalle.Rows.Count;
            for (int i = 0; i < a; i++)
            {
                g.DrawString(Convert.ToString(this.dgvDetalle.Rows[i].Cells[0].Value), fdpTitle, sb, 5, 305 + AutoScrollOffset);
                g.DrawString(Convert.ToString(this.dgvDetalle.Rows[i].Cells[1].Value), fdpTitle, sb, 74, 305 + AutoScrollOffset);
                g.DrawString(Convert.ToString(this.dgvDetalle.Rows[i].Cells[2].Value), fdpTitle, sb, 180, 305 + AutoScrollOffset);
                g.DrawString(Convert.ToString(this.dgvDetalle.Rows[i].Cells[3].Value), fdpTitle, sb, 220, 305 + AutoScrollOffset);
                g.DrawString(Convert.ToString(this.dgvDetalle.Rows[i].Cells[5].Value), fdpTitle, sb, 280, 305 + AutoScrollOffset);
                AutoScrollOffset = AutoScrollOffset + 12;
            }

            AutoScrollOffset = AutoScrollOffset + 12;
            g.DrawString("SubTotal", fdpTitle, sb, 100, 330 + AutoScrollOffset);
            g.DrawString(this.txtSubtotal.Text, fBody, sb, 250, 330 + AutoScrollOffset);
            g.DrawString("Total a Pagar", fdpTitle, sb, 100, 350 + AutoScrollOffset);
            g.DrawString(this.txtTotalPagar.Text, fBody, sb, 250, 350 + AutoScrollOffset);
            g.DrawString("Descuento", fdpTitle, sb, 100, 365 + AutoScrollOffset);
            g.DrawString(this.txtDescuento.Text, fBody, sb, 250, 365 + AutoScrollOffset);

        }
        #endregion

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
            try
            {
                if (!Validator())
                    return;

                //add products to Gridview
                DetalleVentaEntity Detail = new DetalleVentaEntity();

                Detail.ID = Convert.ToInt64(txtProductos.Text);
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
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region Save Invoice

        /// <summary>
        /// Save Invoices Head and Detail
        /// </summary>
        public void Save_Invoices()
        {

            try
            {

                Save_Detail();
                UpdateStock();
                Save_Head();
                

                MessageBox.Show("Guardado Exitosamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        ///  Head Generate from Textbox
        /// </summary>
        private void Save_Head()
        {
           

            int status = 1;

            venta = new VentaEntity();

            venta.clientes = this.txtClientes.Text; //
            venta.apellidos = this.txtApClientes.Text; //
            venta.total = decimal.Parse(this.txtTotalPagar.Text); //
            venta.status = status; //
            venta.descuento = decimal.Parse(this.txtDescuento.Text); //
            venta.subtotal = decimal.Parse(this.txtSubtotal.Text); //
            venta.total_itbis = decimal.Parse(this.txtItbis.Text); //

            if ((this.txtClientes.Text == "CONTADO") && (this.txtApClientes.Text == "CONTADO"))
            {
                venta.tipo = "1";
            }
            else
            {
                venta.tipo = "2";
            }
            FacturaBO.Create(venta);
        }

        /// <summary>
        /// Detail Generate from DataGridView for Save
        /// </summary>
        public void Save_Detail()
        {
            int x = this.dgvDetalle.Rows.Count;

            DetalleVentaEntity Detail = new DetalleVentaEntity();

            for (int i = 0; i < x; i++)
            {
                Detail.ID = Convert.ToInt64(this.dgvDetalle.Rows[i].Cells[0].Value.ToString()); //Id
                Detail.DESCRIPCION = this.dgvDetalle.Rows[i].Cells[1].Value.ToString(); //Description
                Detail.CANTIDAD = Convert.ToInt32(this.dgvDetalle.Rows[i].Cells[2].Value.ToString()); //Quality
                Detail.PRECIO = Convert.ToDecimal(this.dgvDetalle.Rows[i].Cells[3].Value.ToString()); //Price
                Detail.ITBIS = Convert.ToDecimal(this.dgvDetalle.Rows[i].Cells[4].Value.ToString()); //Itbis
                Detail.IMPORTE = Convert.ToDecimal(this.dgvDetalle.Rows[i].Cells[5].Value.ToString()); //amount 
            }
            FacturaBO.Create_detail(venta);

        }

        /// <summary>
        /// 
        /// </summary>

        public void UpdateStock()
        {
            int x = this.dgvDetalle.Rows.Count;

            DetalleVentaEntity Detail = new DetalleVentaEntity();

            for (int i = 0; i < x; i++)
            {
                Detail.ID =Convert.ToInt64(this.dgvDetalle.Rows[i].Cells[0].Value.ToString());
                Detail.CANTIDAD = Convert.ToInt32(this.dgvDetalle.Rows[i].Cells[2].Value.ToString()); //Quality
            }
            ProductosBO.Discrement_Stock(detail);
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
    }

}





