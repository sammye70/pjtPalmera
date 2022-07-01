using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pjPalmera.Entities;
using pjPalmera.BLL;

namespace pjPalmera.PL
{
    public partial class frmCierreCaja : Form
    {
        OpServices Services = new OpServices();

        OperationsCajaEntity cBox = new OperationsCajaEntity();

        public frmCierreCaja()
        {
            InitializeComponent();
            Desable();
        }

        /// <summary>
        /// Desable Controls
        /// </summary>
        private void Desable()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        /// <summary>
        /// Clean Content in All Controls
        /// </summary>
        private void CleanControls()
        {
            this.txtBilletes100.Text = "";
            this.txtBilletes1000.Text = "";
            this.txtBilletes200.Text = "";
            this.txtBilletes2000.Text = "";
            this.txtBilletes50.Text = "";
            this.txtBilletes500.Text = "";
            this.txtMonedas1.Text = "";
            this.txtMonedas10.Text = "";
            this.txtMonedas5.Text = "";
            this.txtMonedas25.Text = "";
            this.lblEfectivoCaja.Text = "0.00";
            this.lblFaltante.Text = "0.00";
            this.lblTotalVentas.Text = "0.00";
            this.lblPagosCxC.Text = "0.00";
           // this.lblPaysCash.Text = "0.00";
           // this.lblPaysCreditCard.Text = "0.00";
            this.lblSellsTotalCash.Text = "0.00";
            this.lblSellsTotalCreditCard.Text = "0.00";
        }

        /// <summary>
        /// Close Box Process 
        /// </summary>
        private void CloseBoxProc()
        {
                      

            if(cBox != null)
            {
                cBox.TypeOp = "3";
                cBox.UserId = Int32.Parse(this.txtIdUser.Text);
                cBox.Uno = Int32.Parse(this.txtMonedas1.Text);
                cBox.Cinco = Int32.Parse(this.txtMonedas5.Text);
                cBox.Diez = Int32.Parse(this.txtMonedas10.Text);
                cBox.Venticinco = Int32.Parse(this.txtMonedas25.Text);
                cBox.Cincuenta = Int32.Parse(this.txtBilletes50.Text);
                cBox.Cien = Int32.Parse(this.txtBilletes100.Text);
                cBox.Doscientos = Int32.Parse(this.txtBilletes100.Text);
                cBox.Quinientos = Int32.Parse(this.txtBilletes500.Text);
                cBox.Mil = Int32.Parse(this.txtBilletes1000.Text);
                cBox.Dosmil = Int32.Parse(this.txtBilletes2000.Text);
                cBox.Monto = decimal.Parse(this.lblEfectivoCaja.Text);
                cBox.Faltante = decimal.Parse(this.lblFaltante.Text);
                cBox.Venta = decimal.Parse(this.lblTotalVentas.Text);
                cBox.AmountSellsCard = decimal.Parse(this.lblSellsTotalCreditCard.Text);
                cBox.AmountSellsCash = decimal.Parse(this.lblSellsTotalCash.Text);
                // cBox.TotalAmountPaysCard =0M;
               // cBox.TotalAmountPaysCash =0M;
                cBox.MontosPagos = decimal.Parse(this.lblPagosCxC.Text);
               

                OperationsCajaBO.CreateHistoryCloseBox(cBox);
                this.txtIdTicket.Text = cBox.Id.ToString();
                OperationsCajaBO.CleanTranstactions(cBox); //-------> Create method to remove transtaction by id 
                //  this.txtIdProcess.Text = this.IdProcess.ToString();
                // OperationsCajaBO.CleanOpenBox();

                Print();
                CleanControls();

            }
            else 
            {
                this.txtMonedas1.Focus();
                return;
            }


        }

        /// <summary>
        /// Amount for Close Box
        /// </summary>
        private void CalculateAmount()
        {
            try
            {
                int t;
                t = Services.monto(Convert.ToInt32(this.txtMonedas1.Text), Convert.ToInt32(this.txtMonedas5.Text), Convert.ToInt32(this.txtMonedas10.Text), 
                    Convert.ToInt32(this.txtMonedas25.Text), Convert.ToInt32(this.txtBilletes50.Text),Convert.ToInt32(this.txtBilletes100.Text),
                    Convert.ToInt32(this.txtBilletes200.Text),Convert.ToInt32(this.txtBilletes500.Text), Convert.ToInt32(this.txtBilletes1000.Text),
                    Convert.ToInt32(this.txtBilletes2000.Text));

                this.lblEfectivoCaja.Text = Convert.ToString(t);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtMonedas1.Focus();
            }
        }


        /// <summary>
        /// Get Amount Total Invoices (cash or internal credit line - cash or credit card)
        /// </summary>
        private void GetAmount()
        {
            try
            {
                var cCaja = new OperationsCajaEntity();
                cCaja.UserId = int.Parse(this.txtIdUser.Text);
                decimal Amount = 0M;
                Amount = OperationsCajaBO.MontoVentas(cCaja);
                lblTotalVentas.Text = Convert.ToString(Amount);
            }
            catch //(Exception ex)
            {

            }
        }

        /// <summary>
        /// Get Amount Total sells with Cash
        /// </summary>
        private void GetAmountSellsCash()
        {
            try
            {
                var cCaja = new OperationsCajaEntity();
                cCaja.UserId = int.Parse(this.txtIdUser.Text);
                decimal Amount = 0M;
                Amount = OperationsCajaBO.MontoSellsCash(cCaja);
                this.lblSellsTotalCash.Text = Convert.ToString(Amount);
            }
            catch //(Exception ex)
            {

            }
        }

        /// <summary>
        /// Get Amount Total sells with Credit Card
        /// </summary>
        private void GetAmountSellsCreditCard()
        {
            try
            {
                var cCaja = new OperationsCajaEntity();
                cCaja.UserId = int.Parse(this.txtIdUser.Text);
                decimal Amount = 0M;
                Amount = OperationsCajaBO.MontoSellsCreditCard(cCaja);
                this.lblSellsTotalCreditCard.Text = Convert.ToString(Amount);
            }
            catch //(Exception ex)
            {

            }
        }

        /// <summary>
        /// Get Amount Total pay to credit account (Cash or Credit Card)
        /// </summary>
        private void GetAmountPays()
        {
            try
            {
                var cCaja = new OperationsCajaEntity();
                cCaja.UserId = int.Parse(this.txtIdUser.Text);
                decimal Amount = 0M;
                Amount = OperationsCajaBO.MontoPays(cCaja);
                this.lblPagosCxC.Text = Convert.ToString(Amount);
            }
            catch //(Exception ex)
            {

            }
        }

        /// <summary>
        /// Get Amount Total pay to credit account but with Credit Card
        /// </summary>
        private void GetAmountPaysCreditCard()
        {
            try
            {
                var cCaja = new OperationsCajaEntity();
                cCaja.UserId = int.Parse(this.txtIdUser.Text);
                decimal Amount = 0M;
                Amount = OperationsCajaBO.MontoPaysCreditCard(cCaja);
                //this.lblPaysCreditCard.Text = Convert.ToString(Amount);
            }
            catch //(Exception ex)
            {

            }
        }

        /// <summary>
        /// Get Amount Total pay to credit account but with Credit Card
        /// </summary>
        private void GetAmountPaysCash()
        {
            try
            {
                var cCaja = new OperationsCajaEntity();
                cCaja.UserId = int.Parse(this.txtIdUser.Text);
                decimal Amount = 0M;
                Amount = OperationsCajaBO.MontoPaysCash(cCaja);
                //this.lblPaysCash.Text = Convert.ToString(Amount);
            }
            catch //(Exception ex)
            {

            }
        }


        /// <summary>
        /// Get Amount Missing before Calculate Amount Total Invoices
        /// </summary>
        private void GetMAmount()
        {
            try
            {
                this.lblFaltante.Text = Convert.ToString(Services.cuadre(Convert.ToDecimal(this.lblEfectivoCaja.Text), Convert.ToDecimal(this.lblSellsTotalCash.Text), Convert.ToDecimal(this.lblPagosCxC.Text)));
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void frmCierreCaja_Load(object sender, EventArgs e)
        {
            this.InfControls();
            this.Desable();
            this.CleanControls();
            this.GetAmount();
            this.GetAmountSellsCash();
            this.GetAmountSellsCreditCard();
            this.GetAmountPays();
            this.GetAmountPaysCreditCard();
            this.GetAmountPaysCash();
        }

        private void btnCalcularMonto_Click(object sender, EventArgs e)
        {
            try
            {
                if(ValidatorCharacters() != false)
                CalculateAmount();
                GetMAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Information about Controls
        /// </summary>
        private void InfControls()
        {
            this.toolTip1.SetToolTip(this.btnCalcularMonto, "Calcular Monto del Efectivo en Caja");
            this.toolTip1.SetToolTip(this.btnClean, "Limpiar Campos");
            this.toolTip1.SetToolTip(this.btnProcesar, "Efectuar Proceso de Cierre");
        }




        /// <summary>
        /// Verify if values inside Controls are numbers or not
        /// </summary>
        /// <returns></returns>
        private bool ValidatorCharacters()
        {
            bool result = true;
            int uno, cinco, diez, venticinco, cincuenta, cien, doscientos, quinientos, mil, dosmil;

            if ((Int32.TryParse(this.txtMonedas1.Text, out uno) == false) || (this.txtMonedas1.Text == string.Empty))
            {
                this.errorProvider1.SetError(this.txtMonedas1, "Ingresar la cantidad de monedas de 1 peso");
                this.txtMonedas1.Focus();
                return result = false;
            }

            if ((Int32.TryParse(this.txtMonedas5.Text, out cinco) == false) || (this.txtMonedas5.Text == string.Empty))
            {
                this.errorProvider1.SetError(this.txtMonedas5, "Ingresar la cantidad de monedas de 5 pesos");
                this.txtMonedas5.Focus();
                return result = false;
            }

            if ((Int32.TryParse(this.txtMonedas10.Text, out diez) == false) || (this.txtMonedas10.Text == string.Empty))
            {
                this.errorProvider1.SetError(this.txtMonedas10, "Ingresar la cantidad de monedas de 10 pesos");
                this.txtMonedas10.Focus();
                return result = false;
            }

            if ((Int32.TryParse(this.txtMonedas25.Text, out venticinco) == false) || (this.txtMonedas25.Text == string.Empty))
            {
                this.errorProvider1.SetError(this.txtMonedas25, "Ingresar la cantidad de monedas de 25 pesos");
                this.txtMonedas25.Focus();
                return result = false;
            }

            if ((Int32.TryParse(this.txtBilletes50.Text, out cincuenta) == false) || (this.txtBilletes50.Text == string.Empty))
            {
                this.errorProvider1.SetError(this.txtBilletes50, "Ingresar la cantidad de billetes de 50 pesos");
                this.txtBilletes50.Focus();
                return result = false;
            }

            if ((Int32.TryParse(this.txtBilletes100.Text, out cien) == false) || (this.txtBilletes100.Text == string.Empty))
            {
                this.errorProvider1.SetError(this.txtBilletes100, "Ingresar la cantidad de billetes de 100 pesos");
                this.txtBilletes100.Focus();
                return result = false;
            }

            if ((Int32.TryParse(this.txtBilletes200.Text, out doscientos) == false) || (this.txtBilletes200.Text == string.Empty))
            {
                this.errorProvider1.SetError(this.txtBilletes200, "Ingresar la cantidad de billetes de 200 pesos");
                this.txtBilletes200.Focus();
                return result = false;
            }

            if ((Int32.TryParse(this.txtBilletes500.Text, out quinientos) == false) || (this.txtBilletes500.Text == string.Empty))
            {
                this.errorProvider1.SetError(this.txtBilletes500, "Ingresar la cantidad de billetes de 500 pesos");
                this.txtBilletes500.Focus();
                return result = false;
            }

            if ((Int32.TryParse(this.txtBilletes1000.Text, out mil) == false) || (this.txtBilletes1000.Text == string.Empty))
            {
                this.errorProvider1.SetError(this.txtBilletes1000, "Ingresar la cantidad de billetes de 1000 pesos");
                this.txtBilletes1000.Focus();
                return result = false;
            }

            if ((Int32.TryParse(this.txtBilletes2000.Text, out dosmil) == false) || (this.txtBilletes2000.Text == string.Empty))
            {
                this.errorProvider1.SetError(this.txtBilletes2000, "Ingresar la cantidad de billetes de 2000 pesos");
                this.txtBilletes2000.Focus();
                return result = false;
            }

            return result;
        }


        /// <summary>
        /// Print Ticket Detail Process Box Close
        /// </summary>
        private void Print()
        {
            var QuestionPrint = new DialogResult();

            QuestionPrint = MessageBox.Show("Desea Imprimir Detalle de Cierre de la Caja","Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (QuestionPrint == DialogResult.Yes)
            {
                PrintTicket();
                MessageBox.Show("Se imprimio el ticket correspondiente al cierre de Caja", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (QuestionPrint == DialogResult.No)
            {
                // MessageBox.Show("No imprimio", "Mensaje del Sistema");
                return;
            }
        }


        private void btnClean_Click(object sender, EventArgs e)
        {
            CleanControls();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            var Answer = new DialogResult();

            try
            {
                if (this.lblEfectivoCaja.Text != "0.00")
                {
                    Answer = MessageBox.Show("Seguro que quiere continuar con el proceso de Cerrar la Caja?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (Answer == DialogResult.Yes)
                    {
                        CloseBoxProc();
                        this.Close();
                    }
                    else if (Answer == DialogResult.No)
                    {
                        this.txtMonedas1.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Debe indicar Efectivo en Caja", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtMonedas1.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtMonedas1.Focus();
            }
        }


        #region Close box Ticket
        /// <summary>
        /// Print ticket close box
        /// </summary>

        // Ticket print Setting
        // Author: Samuel Estrella
        // Date: 17/01/2020
        
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
        /// Bill Cash Header, Detail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Parameters
            Font fBody = new Font("Lucida Console", 8, FontStyle.Regular);// Format Font for Body
            Font ffTitle = new Font("Lucida Console", 11, FontStyle.Bold); // Format Font for Title Company Name
            Font fTitle = new Font("Lucida Console", 8, FontStyle.Bold); // Format Font for Title
            Font fdpTitle = new Font("Lucida Console", 8, FontStyle.Regular); // Format Font Detail Products
            Font fpTitle = new Font("Lucida Console", 8, FontStyle.Bold); // Format Font Title Amount
            Font fpBody = new Font("Lucida Console", 8, FontStyle.Bold);// Format number Amount
            Font tbottom = new Font("Lucida Console", 6, FontStyle.Regular); // Format Font Messege Bottom
            Font tblank = new Font("Lucida Console", 19, FontStyle.Bold); // Format Font  Bottom
            Font fdTitle = new Font("Lucida Console", 8, FontStyle.Regular); // Format Font for Detail Title (Address,Telephone, etc.. About Company Information)
            Graphics g = e.Graphics;
            SolidBrush sb = new SolidBrush(Color.Black); // Set Brush color for Drawing Charaters

            // Ticket Titles
            // string Type1 = "APERTURA DE LA CAJA";
            string Type2 = "CIERRE DE LA CAJA";

            //Id Invoice
            // this.txtId_Invoice.Text = Convert.ToString(Id_invoice);  //


            RawPrinterHelper j = new RawPrinterHelper(); //

            // Header Ticket

            //int AutoScrollOffset1= -100;
            //AutoScrollOffset1 = AutoScrollOffset1 -100;
            g.DrawString("Farmacia CRM", ffTitle, sb, 75, 120);
            g.DrawString("Donde tu Salud es Nuestra Prioridad", fTitle, sb, 20, 134);
            g.DrawString("C/9, #15, Las Escobas, Jima Arriba", fdTitle, sb, 27, 148);
            g.DrawString("RNC:80700148433", fdTitle, sb, 80, 160);
            g.DrawString("Tel: 809-954-9952", fdTitle, sb, 80, 175);
            g.DrawString("Whatsapp:809-851-2775", fdTitle, sb, 70, 185);

            g.DrawString("FECHA:", fTitle, sb, 10, 210); //
            g.DrawString(DateTime.Now.ToShortDateString(), fBody, sb, 80, 210); //
            g.DrawString("HORA:", fTitle, sb, 155, 210); //
            g.DrawString(DateTime.Now.ToShortTimeString(), fBody, sb, 195, 210); //
            g.DrawString("COD. CAJERO:", fTitle, sb, 10, 222); //
            g.DrawString(this.txtIdUser.Text, fBody, sb, 110, 222);
            // g.DrawString(this.txtApClientes.Text, fBody, sb, 180, 220); //
            g.DrawString("CAJERO:", fTitle, sb, 10, 234); //
            g.DrawString(this.txtUserFirstNameLast.Text, fBody, sb, 95, 234);
            g.DrawString("NO. OPERACION:", fTitle, sb, 10, 245); //
            g.DrawString(this.txtIdTicket.Text, fBody, sb, 115, 245); //



            // Open box title
            g.DrawString(Type2, fTitle, sb, 75, 262);

            // Detail cash

            g.DrawString("-----------------------------------------", fBody, sb, 5, 280);
            g.DrawString("     DETALLES DE OPERACION EN CAJA       ", fdpTitle, sb, 10, 290);
            g.DrawString("-----------------------------------------", fBody, sb, 5, 298);
            g.DrawString("   DENOMINACION    CANTIDAD   MONTO      ", fdpTitle, sb, 10, 304);
            g.DrawString("-----------------------------------------", fBody, sb, 5, 310);

            int AutoScrollOffset = +14;

            // detail open box process
            AutoScrollOffset = AutoScrollOffset + 12;
            g.DrawString("Monedas de 1: ", fdpTitle, sb, 10, 308 + AutoScrollOffset);   // 
            g.DrawString(this.txtMonedas1.Text, fBody, sb, 158, 308 + AutoScrollOffset);  //
            decimal r1 = 1 * decimal.Parse(this.txtMonedas1.Text);
            g.DrawString(r1.ToString() + ".00", fBody, sb, 212, 308 + AutoScrollOffset);
            g.DrawString("Monedas de 5: ", fdpTitle, sb, 10, 324 + AutoScrollOffset);
            g.DrawString(this.txtMonedas5.Text, fBody, sb, 158, 324 + AutoScrollOffset); //
            decimal r2 = 5 * decimal.Parse(this.txtMonedas5.Text);
            g.DrawString(r2.ToString() + ".00", fBody, sb, 212, 324 + AutoScrollOffset);
            g.DrawString("Monedas de 10: ", fdpTitle, sb, 10, 339 + AutoScrollOffset); //
            g.DrawString(this.txtMonedas10.Text, fpBody, sb, 158, 339 + AutoScrollOffset);  //
            decimal r3 = 10 * decimal.Parse(this.txtMonedas10.Text);
            g.DrawString(r3.ToString() + ".00", fBody, sb, 212, 339 + AutoScrollOffset);
            g.DrawString("Monedas de 25: ", fdpTitle, sb, 10, 356 + AutoScrollOffset);
            g.DrawString(this.txtMonedas25.Text, fBody, sb, 158, 356 + AutoScrollOffset);
            decimal r4 = 25 * decimal.Parse(this.txtMonedas25.Text);
            g.DrawString(r4.ToString() + ".00", fBody, sb, 212, 356 + AutoScrollOffset);
            g.DrawString("Billetes de 50: ", fdpTitle, sb, 10, 369 + AutoScrollOffset); //
            g.DrawString(this.txtBilletes50.Text, fBody, sb, 158, 369 + AutoScrollOffset); //
            decimal r5 = 50 * decimal.Parse(this.txtBilletes50.Text);
            g.DrawString(r5.ToString() + ".00", fBody, sb, 212, 369 + AutoScrollOffset);
            g.DrawString("Billetes de 100: ", fdpTitle, sb, 10, 385 + AutoScrollOffset); //
            g.DrawString(this.txtBilletes100.Text, fBody, sb, 158, 385 + AutoScrollOffset); //
            decimal r6 = 100 * decimal.Parse(this.txtBilletes100.Text);
            g.DrawString(r6.ToString() + ".00", fBody, sb, 212, 385 + AutoScrollOffset);
            g.DrawString("Billetes de 200: ", fdpTitle, sb, 10, 405 + AutoScrollOffset);
            g.DrawString(this.txtBilletes200.Text, fBody, sb, 158, 405 + AutoScrollOffset);
            decimal r7 = 200 * decimal.Parse(this.txtBilletes200.Text);
            g.DrawString(r7.ToString() + ".00", fBody, sb, 212, 405 + AutoScrollOffset);
            g.DrawString("Billetes de 500: ", fdpTitle, sb, 10, 420 + AutoScrollOffset);
            g.DrawString(this.txtBilletes500.Text, fBody, sb, 158, 420 + AutoScrollOffset);
            decimal r8 = 500 * decimal.Parse(this.txtBilletes500.Text);
            g.DrawString(r8.ToString() + ".00", fBody, sb, 212, 420 + AutoScrollOffset);
            g.DrawString("Billetes de 1,000: ", fdpTitle, sb, 10, 438 + AutoScrollOffset);
            g.DrawString(this.txtBilletes1000.Text, fBody, sb, 158, 438 + AutoScrollOffset);
            decimal r9 = 1000 * decimal.Parse(this.txtBilletes1000.Text);
            g.DrawString(r9.ToString() + ".00", fBody, sb, 212, 438 + AutoScrollOffset);
            g.DrawString("Billetes de 2,000: ", fdpTitle, sb, 10, 457 + AutoScrollOffset);
            g.DrawString(this.txtBilletes2000.Text, fBody, sb, 158, 457 + AutoScrollOffset);
            decimal r10 = 2000 * decimal.Parse(this.txtBilletes2000.Text);
            g.DrawString(r10.ToString() + ".00", fBody, sb, 212, 457 + AutoScrollOffset);

            //Total Amount for this process

            AutoScrollOffset = AutoScrollOffset + 8;
            g.DrawString("Efectivo en Caja:", fdpTitle, sb, 10, 490 + AutoScrollOffset);
            g.DrawString(this.lblEfectivoCaja.Text + ".00", fpBody, sb, 212, 490 + AutoScrollOffset);
            g.DrawString("Total de Venta con Tarjeta:", fdpTitle, sb, 10, 505 + AutoScrollOffset);
            g.DrawString(this.lblSellsTotalCreditCard.Text + ".00", fpBody, sb, 212, 505 + AutoScrollOffset);
            g.DrawString("Total de Venta en Efectivo:", fdpTitle, sb, 10, 519 + AutoScrollOffset);
            g.DrawString(this.lblSellsTotalCash.Text + ".00", fpBody, sb, 212, 519 + AutoScrollOffset);
            //g.DrawString("Total de Venta a Crédito:", fdpTitle, sb, 10, 490 + AutoScrollOffset);
            //g.DrawString(this.lblEfectivoCaja.Text + ".00", fpBody, sb, 212, 490 + AutoScrollOffset);
            g.DrawString("Total de Ventas:", fdpTitle, sb, 10, 528 + AutoScrollOffset);
            g.DrawString(this.lblTotalVentas.Text, fpBody, sb, 212, 528 + AutoScrollOffset);
            g.DrawString("Total de Pago cta crédito:", fdpTitle, sb, 10, 539 + AutoScrollOffset);
            g.DrawString(this.lblPagosCxC.Text, fpBody, sb, 212, 539 + AutoScrollOffset);
            g.DrawString("Faltante:", fdpTitle, sb, 10, 548 + AutoScrollOffset);
            g.DrawString(this.lblFaltante.Text, fpBody, sb, 212, 548 + AutoScrollOffset);
            // 

        }
        #endregion
    }
}
