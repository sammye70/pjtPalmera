using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using pjPalmera.BLL;
using pjPalmera.Entities;

namespace pjPalmera.PL
{
    public partial class frmEfectPagosFactCred : Form
    {
        PagosEntity Pagos = new PagosEntity();
        VentaEntity venta = new VentaEntity();

        public frmEfectPagosFactCred()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Set Initial Controls Values
        /// </summary>
        private void DesableControls()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.txtIdClient.ReadOnly = true;
            this.txtCliente.ReadOnly = true;
           // this.txtApellidos.ReadOnly = true;
        }


        /// <summary>
        /// Clean content in controls
        /// </summary>
        private void Limpiar()
        {
            this.txtIdClient.Text = "";
            this.txtCliente.Text = "";
           // this.txtApellidos.Text = "";
            this.txtRecibidoEfectivo.Text = "";
            this.txtValorPago.Text = "";
            this.txtIdRecibo.Text = "";
            this.txtBalanceAfterPaid.Text = "";
            this.lblDevueltResult.Text = "0.00";
            this.lblBalenceResultados.Text = "0.00";
            this.rbEfectivo.Checked = false;
            this.rbTarjeta.Checked = false;
        }

        private void frmEfectPagosFactCred_Load(object sender, EventArgs e)
        {
            Limpiar();
            DesableControls();
            DespControls();
            iniControls();
        }


        /// <summary>
        /// Search Costumer has credit pendding to pay
        /// </summary>
        private void SearchClientCxc()
        {
            var CuentasPend = new frmClientCredPend();

            if (CuentasPend.ShowDialog() == DialogResult.OK)
            {
                
                var customer = ClientesBO.GetbyId(CuentasPend.Id);

                // this.txtIdClient.Text = Convert.ToString(CuentasPend.Id);
                this.txtIdClient.Text = Convert.ToString(customer.Id);
                this.txtCliente.Text = customer.Nombre + " " + customer.Apellidos;
                this.txtBalanceBeforePaid.Text = CreditAccountBO.GetAmount(customer.Id).ToString();
                // this.txtApellidos.Text = clientes.Apellidos;
               // this.lblBalenceResultados.Text = Convert.ToString(CuentasBO.Amount(CuentasPend.Id)); //
            }

        }

        /// <summary>
        /// Set inicials values inside controls
        /// </summary>
        public void iniControls()
        {
            this.txtIdRecibo.Text = "0.00";
            this.txtValorPago.Text = "0.00";

        }

        /// <summary>
        /// Desable All Controls before to show form
        /// </summary>
        public void InitialDesControls() 
        {
            this.txtBalanceBeforePaid.Visible = false;
            this.txtIdClient.Visible = false;
            this.txtIdRecibo.Visible = false;
            this.txtIdUser.Visible = false;
            this.txtPermissions.Visible = false;
            this.txtUserLong.Visible = false;
        
        }

        /// <summary>
        /// Set Description About Controls
        /// </summary>
        private void DespControls()
        {
            this.toolTip1.SetToolTip(this.btnSearchClient, "Buscar Clientes con Cuentas Pendientes");
            this.toolTip1.SetToolTip(this.btnSearchInvoices, "Buscar Facturas a Credito del Cliente Actual");
            this.toolTip1.SetToolTip(this.btnNuevo,"Crear Nuevo Recibo en Blanco");
            this.toolTip1.SetToolTip(this.btnCobrar,"Procesar Cobro efectuado por el cliente");
        }

        #region Invoice paid cash
        /// <summary>
        /// Print Receipt Current Costumer
        /// </summary>
        /// Bill print Setting
        /// Author: Samuel Estrella
        /// Date: 13/01/2020
        public void PrintTicket()
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
        /// Receipt Cash Header, Detail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            //TicketVentaEntity tk = new TicketVentaEntity();
            //Parameters
            Font fBody = new Font("Lucida Console", 8, FontStyle.Regular);// Format Font for Body
            Font ffTitle = new Font("Lucida Console", 11, FontStyle.Bold); // Format Font for Title Company Name
            Font fTitle = new Font("Lucida Console", 8, FontStyle.Bold); // Format Font for Title
            Font fdpTitle = new Font("Lucida Console", 8, FontStyle.Regular); // Format Font Detail Products
            Font fpTitle = new Font("Lucida Console", 8, FontStyle.Bold); // Format Font Title Amount
            Font fpBody = new Font("Lucida Console", 8, FontStyle.Bold);// Format number Amount
            Font tbottom = new Font("Lucida Console", 7, FontStyle.Regular); // Format Font Messege Bottom
            Font tblank = new Font("Lucida Console", 19, FontStyle.Bold); // Format Font  Bottom
            Font fdTitle = new Font("Lucida Console", 8, FontStyle.Regular);//Format Font for Detail Title (Address,Telephone, etc.. About Company Information)
            Graphics g = e.Graphics;
            SolidBrush sb = new SolidBrush(Color.Black); // Set Brush color for Drawing Charaters
            string Type = "COMPROBANTE DE PAGO"; //Type of invoice
            string Type1 = "";

            //    //Id Invoice
            //    venta.id = FacturaBO.LastId();
            //    this.txtId_Invoice.Text = Convert.ToString(venta.id);

            //    RawPrinterHelper j = new RawPrinterHelper(); //

            //Header invoice

            int AutoScrollOffset1 = -100;
            AutoScrollOffset1 = AutoScrollOffset1 - 100;
            g.DrawString("Farmacia CRM", ffTitle, sb, 75, 120);
            g.DrawString("Donde tu Salud es Nuestra Prioridad", fTitle, sb, 20, 134);
            g.DrawString("C/9, #15, Las Escobas, Jima Arriba", fdTitle, sb, 27, 148);
            g.DrawString("RNC:80700148433", fdTitle, sb, 80, 160);
            g.DrawString("Tel: 809-954-9952", fdTitle, sb, 80, 175);
            g.DrawString("Whatsapp:809-851-2775", fdTitle, sb, 70, 185);

            g.DrawString("FECHA:", fTitle, sb, 10, 210);
            g.DrawString(DateTime.Now.ToShortDateString(), fBody, sb, 80, 210);
            g.DrawString("HORA:", fTitle, sb, 155, 210);
            g.DrawString(DateTime.Now.ToShortTimeString(), fBody, sb, 195, 210);
            g.DrawString("CLIENTE:", fTitle, sb, 10, 220);
            g.DrawString(this.txtCliente.Text, fBody, sb, 80, 220);
           // g.DrawString(this.txtApellidos.Text, fBody, sb, 180, 220);
            g.DrawString("NIR:", fTitle, sb, 10, 232);
            g.DrawString(this.txtIdRecibo.Text, fBody, sb, 50, 232);
         

            //
            g.DrawString(Type, fTitle, sb, 75, 255);

            // Detail Invoice
            g.DrawString("----------------------------------------", fBody, sb, 5, 280);
            g.DrawString("CONCEPTO DEL PAGO", fdpTitle, sb, 60, 290);
            g.DrawString("----------------------------------------", fBody, sb, 5, 298);
            int AutoScrollOffset = +14;

            //
            if (this.txtValorPago.Text == this.lblBalenceResultados.Text)
            {
                Type1 = "SALDO DEL BALANCE PENDIENTE";
            }
            else
            {
                Type1 = "ABONO AL BALANCE PENDIENTE";
            }
            g.DrawString(Type1, fTitle, sb, 49, 320);

            //    int a = this.dgvDetalle.Rows.Count;

            //    for (int i = 0; i < a; i++)
            //    {
            //        //g.DrawString(Convert.ToString(this.dgvDetalle.Rows[i].Cells[0].Value), fdpTitle, sb, 5, 305 + AutoScrollOffset);
            //        g.DrawString(Convert.ToString(this.dgvDetalle.Rows[i].Cells[2].Value), fdpTitle, sb, 5, 305 + AutoScrollOffset); //Description
            //        g.DrawString(Convert.ToString(this.dgvDetalle.Rows[i].Cells[3].Value), fdpTitle, sb, 153, 305 + AutoScrollOffset); //Quality
            //        g.DrawString(Convert.ToString(this.dgvDetalle.Rows[i].Cells[4].Value), fdpTitle, sb, 178, 305 + AutoScrollOffset);// Price
            //        g.DrawString(Convert.ToString(this.dgvDetalle.Rows[i].Cells[6].Value), fpTitle, sb, 225, 305 + AutoScrollOffset); // Total Price x Unit
            //        AutoScrollOffset = AutoScrollOffset + 12;
            //    }

            //Paid Detail
            AutoScrollOffset = AutoScrollOffset + 12;
            g.DrawString("Pago Realizado por:", fdpTitle, sb, 90, 318 + AutoScrollOffset); //
            g.DrawString(this.txtValorPago.Text, fBody, sb, 225, 318 + AutoScrollOffset);  //
            g.DrawString("Recibido RD$:", fdpTitle, sb, 90, 332 + AutoScrollOffset);   // 
            g.DrawString(this.txtRecibidoEfectivo.Text, fBody, sb, 225, 332 + AutoScrollOffset);  //
            g.DrawString("Devuelta RD$ :", fdpTitle, sb, 90, 350 + AutoScrollOffset);
            g.DrawString(this.lblDevueltResult.Text, fBody, sb, 225, 350 + AutoScrollOffset); //
            g.DrawString("Balance Actual RD$:", fpTitle, sb, 90, 368 + AutoScrollOffset); //
            g.DrawString(this.txtBalanceAfterPaid.Text, fpBody, sb, 225, 368 + AutoScrollOffset);  //
            //g.DrawString("", fdpTitle, sb, 100, 370 + AutoScrollOffset);
            //Cachier Signature
            g.DrawString("Firma del Cajero", fdpTitle, sb, 49, 405 + AutoScrollOffset);    //Aqui estoy trabajando

            //Feet Messenge
            AutoScrollOffset = AutoScrollOffset + 8;
            g.DrawString("IMPORTANTE: Guardar sus Comprobantes de Pagos", tbottom, sb, 5, 440 + AutoScrollOffset);
            g.DrawString("Gracias por su Pago!", tbottom, sb, 5, 450 + AutoScrollOffset);
            //  g.DrawString("mal estado.", tbottom, sb, 5, 460 + AutoScrollOffset);

            g.DrawString("Tu eres la persona mas linda que Jesús", fTitle, sb, 5, 480 + AutoScrollOffset);
            g.DrawString("tiene en este mundo Buscale.", fTitle, sb, 5, 495 + AutoScrollOffset);
            g.DrawString(".", tblank, sb, 5, 505 + AutoScrollOffset);
            // 
        }
        #endregion

        private void btnSearchInvoices_Click(object sender, EventArgs e)
        {
            frmConsFactCredClient FactCreditoClientPend = new frmConsFactCredClient();
            FactCreditoClientPend.ShowDialog(this);

        }

        private void btnSearchClient_Click(object sender, EventArgs e)
        {
            try
            {
                SearchClientCxc();
            }
            catch (Exception)
            {


            }
        }


        /// <summary>
        /// Check if all controls has content before continues with process
        /// </summary>
        /// <returns>true if all controls are diferent empty and false when empty </returns>
        private bool Validador() 
        {
            bool result = true;

            if(this.txtCliente.Text == string.Empty)
            {
                result = false;
            }

            if(decimal.TryParse(this.txtValorPago.Text, out decimal resul) && (this.txtValorPago.Text == string.Empty))
            {
                result = false;

            }

            if ((int.TryParse(this.txtIdClient.Text, out int res)) && (this.txtIdClient.Text == string.Empty))
            {
                result = false;
            }

            if ((decimal.TryParse(this.txtRecibidoEfectivo.Text, out decimal resu)) && (this.txtRecibidoEfectivo.Text == string.Empty))
            {
                result = false;
            }

            if ((this.rbEfectivo.Enabled == false) && (this.rbTarjeta.Enabled == false))
            {
                result = false;
            }

            return result;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            var Result = new DialogResult();

            Result= MessageBox.Show("Seguro que Desea Procesar el Pago", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (Result == DialogResult.Yes)
            {
                // MessageBox.Show("Pago Procesado Satisfactoriamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process_Pay(); // --------------------------- >>> Here pendding  test when running DONE
                PrintTicket();
                Limpiar();
            }
            else if (Result == DialogResult.No)
            {
               MessageBox.Show("Pago No Procesado", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               return;
            }
        }

        private void txtRecibidoEfectivo_TextChanged(object sender, EventArgs e)
        {

            try
            {
                var docs = new VentaCrEntity();
                this.lblDevueltResult.Text = "";

                if ((this.txtRecibidoEfectivo.Text != String.Empty))
                {
                    this.lblDevueltResult.Text = (docs.Change(decimal.Parse(this.txtRecibidoEfectivo.Text), decimal.Parse(this.txtValorPago.Text))).ToString();
                }
            }
            catch (Exception)
            {

                
            }

            
        }


        /// <summary>
        ///  Process for pay customer amount pendding in account
        /// </summary>
        private void Process_Pay()
        {

            try
            {
                var fpago = new frmEfectPagosFactCred();
                var craccount = new CreditAccountEntity();


                craccount.id_cliente = int.Parse(this.txtIdClient.Text);
                craccount.PayValue = decimal.Parse(this.txtValorPago.Text);


                if (Validador() != false) //--------> working with validate controls (Done)
                    return;

                CreditAccountBO.UpdateCrAccountPay(craccount);
                fpago.txtBalanceAfterPaid.Text = craccount.NewAmountcr.ToString();
                fpago.txtBalanceBeforePaid.Text = craccount.PastAmountcr.ToString();

                CreditAccountBO.GetcrAccountBasic(craccount);
                fpago.txtIdAccount.Text = craccount.IdAccount.ToString();

                //--------------> Here call rule from  CreditAccountBO that to allow save in history_pay_credit_account (Done below)

                CreditAccountBO.SavePayHistory(craccount);
                fpago.txtIdRecibo.Text = craccount.id.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            
        }

    }
}
