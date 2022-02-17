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
        }

        /// <summary>
        /// Close Box Process 
        /// </summary>
        private void CloseBoxProc()
        {

            var cBox = new CierreCajaEntity();

            cBox.TypeOp = 2;
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

            CierreCajaBO.CreateHistoryCloseBox(cBox);
            CierreCajaBO.CleanTranstactions(cBox); //-------> Create method to remove transtaction by id
            // CierreCajaBO.CleanOpenBox();

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
        /// Get Amount Total Invoices
        /// </summary>
        private void GetAmount()
        {
            try
            {
                var cCaja = new CierreCajaEntity();
                cCaja.UserId = int.Parse(this.txtIdUser.Text);
                decimal Amount = 0;
                Amount = CierreCajaBO.MontoVentas(cCaja);
                lblTotalVentas.Text = Convert.ToString(Amount);
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
                this.lblFaltante.Text = Convert.ToString(Services.cuadre(Convert.ToDecimal(this.lblEfectivoCaja.Text), Convert.ToDecimal(this.lblTotalVentas.Text)));
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void frmCierreCaja_Load(object sender, EventArgs e)
        {
            InfControls();
            Desable();
            CleanControls();
            GetAmount();
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
                MessageBox.Show("Se imprimio", "Mensaje del Sistema");
            }
            else if (QuestionPrint == DialogResult.No)
            {
                MessageBox.Show("No imprimio", "Mensaje del Sistema");
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
                        Print();
                        CleanControls();
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
            string Type1 = "CIERRE DE LA CAJA";
            // string Type2 = "CIERRE DE LA CAJA";

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
            g.DrawString("NO. OPERACION:", fTitle, sb, 10, 246); //
            // g.DrawString(this.txtId_Invoice.Text, fBody, sb, 50, 244); //

            var opBoxop = new AperturaCajaEntity();

            opBoxop.TypeOp = Convert.ToInt32(this.txtType.Text);


            int op = opBoxop.TypeOp;

            // Open box title
            g.DrawString(Type1, fTitle, sb, 75, 262);


            // Detail cash

            g.DrawString("-----------------------------------------", fBody, sb, 5, 280);
            g.DrawString("     DETALLES DE OPERACION EN CAJA       ", fdpTitle, sb, 10, 290);
            g.DrawString("-----------------------------------------", fBody, sb, 5, 298);
            g.DrawString("   DENOMINACION    CANTIDAD    MONTO     ", fdpTitle, sb, 10, 304);
            g.DrawString("-----------------------------------------", fBody, sb, 5, 310);

            int AutoScrollOffset = +14;

            // detail open box process
            AutoScrollOffset = AutoScrollOffset + 12;
            g.DrawString("Monedas de 1: ", fdpTitle, sb, 90, 330 + AutoScrollOffset);   // 
            g.DrawString(this.txtMonedas1.Text, fBody, sb, 202, 330 + AutoScrollOffset);  //
            g.DrawString("Monedas de 5: ", fdpTitle, sb, 90, 350 + AutoScrollOffset);
            g.DrawString(this.txtMonedas5.Text, fBody, sb, 202, 350 + AutoScrollOffset); //
            g.DrawString("Monedas de 10: ", fpTitle, sb, 90, 368 + AutoScrollOffset); //
            g.DrawString(this.txtMonedas10.Text, fpBody, sb, 202, 368 + AutoScrollOffset);  //
            g.DrawString("Monedas de 25 ", fdpTitle, sb, 100, 370 + AutoScrollOffset);
            g.DrawString(this.txtMonedas25.Text, fBody, sb, 202, 389 + AutoScrollOffset);
            g.DrawString("Billetes de 50: ", fdpTitle, sb, 90, 389 + AutoScrollOffset); //
            g.DrawString(this.txtBilletes50.Text, fBody, sb, 202, 389 + AutoScrollOffset); //
            g.DrawString("Billetes de 100: ", fdpTitle, sb, 90, 405 + AutoScrollOffset); //
            g.DrawString(this.txtBilletes100.Text, fBody, sb, 202, 405 + AutoScrollOffset); //
            g.DrawString("Billetes de 200: ", fdpTitle, sb, 90, 420 + AutoScrollOffset);
            g.DrawString(this.txtBilletes200.Text, fdpTitle, sb, 202, 420 + AutoScrollOffset);
            g.DrawString("Billetes de 500: ", fdpTitle, sb, 90, 420 + AutoScrollOffset);
            g.DrawString(this.txtBilletes500.Text, fdpTitle, sb, 202, 420 + AutoScrollOffset);
            g.DrawString("Billetes de 1000: ", fdpTitle, sb, 90, 420 + AutoScrollOffset);
            g.DrawString(this.txtBilletes1000.Text, fdpTitle, sb, 202, 420 + AutoScrollOffset);
            g.DrawString("Billetes de 2000: ", fdpTitle, sb, 90, 420 + AutoScrollOffset);
            g.DrawString(this.txtBilletes2000.Text, fdpTitle, sb, 202, 420 + AutoScrollOffset);

            //Total Amount for this process

            AutoScrollOffset = AutoScrollOffset + 8;
            g.DrawString("Efectivo en Caja:", fBody, sb, 5, 426 + AutoScrollOffset);
            g.DrawString(this.lblEfectivoCaja.Text, fpBody, sb, 200, 426 + AutoScrollOffset);
            g.DrawString("Total de Ventas:", fBody, sb, 5, 426 + AutoScrollOffset);
            g.DrawString(this.lblTotalVentas.Text, fpBody, sb, 200, 426 + AutoScrollOffset);
            g.DrawString("Faltante:", fBody, sb, 5, 426 + AutoScrollOffset);
            g.DrawString(this.lblFaltante.Text, fpBody, sb, 200, 426 + AutoScrollOffset);
            // 
        }
        #endregion
    }
}
