using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pjPalmera.Entities;
using pjPalmera.BLL;
using System.Drawing.Printing;

namespace pjPalmera.PL
{
    public partial class frmAbrirCaja : Form
    {
        OperationsCajaEntity oCaja = new OperationsCajaEntity();
        OpServices Services = new OpServices();


        public frmAbrirCaja()
        {
            InitializeComponent();
        }

        private void frmAbrirCaja_Load(object sender, EventArgs e)
        {
            InfControls();
            DesableControls();
            CleanControls();
            this.txtMonedas1.Focus();
            // oCaja = null;
        }



        /// <summary>
        /// Desable All Controls
        /// </summary>
        private void DesableControls()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
         
        }


        /// <summary>
        /// Information about Controls
        /// </summary>
        private void InfControls()
        {
            this.toolTip1.SetToolTip(this.btnCalcularMonto,"Calcular Monto Apertura");
            this.toolTip1.SetToolTip(this.btnClean,"Limpiar Campos");
            this.toolTip1.SetToolTip(this.btnProcesar,"Efectuar Proceso de Apertura");
        }



        /// <summary>
        /// Clean Content in All Controls from OpenBox Process
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
            this.lblMontoTotal.Text = "0.00";
        }

        /// <summary>
        /// Amount for Open Box
        /// </summary>
        private void CalculateAmount()
        {
            try
            {
                var t = Services.monto(Convert.ToInt32(this.txtMonedas1.Text), Convert.ToInt32(this.txtMonedas5.Text), Convert.ToInt32(this.txtMonedas10.Text), 
                                        Convert.ToInt32(this.txtMonedas25.Text), Convert.ToInt32(this.txtBilletes50.Text), Convert.ToInt32(this.txtBilletes100.Text), 
                                        Convert.ToInt32(this.txtBilletes200.Text), Convert.ToInt32(this.txtBilletes500.Text), Convert.ToInt32(this.txtBilletes1000.Text), Convert.ToInt32(this.txtBilletes2000.Text));

                this.lblMontoTotal.Text = Convert.ToString(t);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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


        /// 
        /// By: sammye70
        /// Initial Release Date: 12/12/2020
        /// Last Release Date: 
        /// <summary>
        /// Open Box for Casher, this method need to valitate if box is open, in this case will to send a message that was opened or closed
        /// </summary>
        private void OpenBox(OperationsCajaEntity oCaja)
        {
            
            try
            {
                if (oCaja != null)
                {
                    oCaja.TypeOp = "2";
                    oCaja.UserId = Int32.Parse(this.txtIdUser.Text);
                    // oCaja.Status = Int32.Parse(this.txtStatus.Text);
                    oCaja.Uno = Convert.ToInt32(this.txtMonedas1.Text);
                    oCaja.Cinco = Convert.ToInt32(this.txtMonedas5.Text);
                    oCaja.Diez = Convert.ToInt32(this.txtMonedas10.Text);
                    oCaja.Venticinco = Convert.ToInt32(this.txtMonedas25.Text);
                    oCaja.Cincuenta = Convert.ToInt32(this.txtBilletes50.Text);
                    oCaja.Cien = Convert.ToInt32(this.txtBilletes100.Text);
                    oCaja.Doscientos = Convert.ToInt32(this.txtBilletes200.Text);
                    oCaja.Quinientos = Convert.ToInt32(this.txtBilletes500.Text);
                    oCaja.Mil = Convert.ToInt32(this.txtBilletes1000.Text);
                    oCaja.Dosmil = Convert.ToInt32(this.txtBilletes2000.Text);
                    oCaja.Monto = Convert.ToDecimal(this.lblMontoTotal.Text);
                    oCaja.Venta = 0;
                    oCaja.Faltante = 0;

                    OperationsCajaBO.CreateOpenBox(oCaja);     
                    OperationsCajaBO.CreateHistoryOpenBox(oCaja);       //----------------------> Create Method to save openbox details DONE
                    this.txtIdTicket.Text = oCaja.Id.ToString();
                    PrintTicketOp();                          //--------> send to print ticket, if process was well. ---------------------------------->
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            {
                this.txtMonedas1.Focus();
            }
            
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            CleanControls();
        }

        private void btnCalcularMonto_Click(object sender, EventArgs e)
        {
            if (ValidatorCharacters() != false)
           // {
                CalculateAmount();
            //}
            //else if (ValidatorCharacters() == false)
            //{
            //   MessageBox.Show("Debe Ingresar Valores Validos", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    this.txtMonedas1.Focus();
            //}
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            var Openbox = new frmCierreCaja();
            var oCaja = new OperationsCajaEntity();

            try
            {
                if((this.lblMontoTotal.Equals("0.00")) || (this.lblMontoTotal.Equals("0")))
                {
                    MessageBox.Show("El monto total debe ser diferente de 0. \n De esta forma poder continuar con el proceso de apertura de Caja", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtMonedas1.Focus();
                }
                else
                {
                    switch (ValidatorCharacters())
                    {
                        case true:
                            var Answer = new DialogResult();

                            Answer = MessageBox.Show("Esta Apunto de Aperturar la Caja, Seguro que quiere continuar", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (Answer == DialogResult.Yes)
                            {

                                this.txtDate.Text = DateTime.Today.Date.ToShortDateString();
                                oCaja.UserId = int.Parse(this.txtIdUser.Text);

                                #region Old Validate status box not used rigth now

                                // function valide if current user has some box with opened status
                                this.txtDate.Text = DateTime.Today.Date.ToShortDateString();
                                // oCaja.UserId  = Convert.ToInt32(this.txtIdUser.Text);


                                //var statusbox = OperationsCajaBO.GetStatusBox(oCaja);

                                //switch (statusbox) 
                                //{
                                //    case 0:
                                //        this.OpenBox(oCaja);

                                //        MessageBox.Show("Caja Abierta! Recuerde que debe Cerrar la Caja al Finalizar las Labores", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //        CleanControls();
                                //        this.Close();
                                //        break;

                                //    case 1:
                                //        MessageBox.Show(OperationsCajaBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                //        this.Close();
                                //        break;
                                //}
                                #endregion

                                this.OpenBox(oCaja);

                                // MessageBox.Show("Caja Abierta! Recuerde que debe Cerrar la Caja al Finalizar las Labores", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CleanControls();
                                this.Close();
                            }

                            else if (Answer == DialogResult.No)
                            {
                                this.txtMonedas1.Focus();
                                return;
                            }

                            break;

                        case false:
                            MessageBox.Show("Debe Revisar los Valor Ingresados al parecer están vacios o los Proporcionados no son correctos. Para poder Aperturar la Caja.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtMonedas1.Focus();
            }
        }

  
        #region Printing Open Box Ticket
        /// <summary>
        /// Print Detail from Open Box Process
        /// </summary>
        /// Bill print Setting
        /// Author: Samuel Estrella
        /// Date: 17/01/2020
        public void PrintTicketOp()
        {
            //Parameters
            PrintDocument pd = new PrintDocument();
            PaperSize pz = new PaperSize("", 420, 520); // Set Paper Size
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
        /// Print Ticket Open Box Process
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

            // Invoice Titles
            string Type1 = "APERTURA DE LA CAJA";
            // string Type2 = "CIERRE DE LA CAJA";

            //Id Invoice
            // this.txtId_Invoice.Text = Convert.ToString(Id_invoice);  //


            RawPrinterHelper j = new RawPrinterHelper(); //OperationsCajaBO

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
            g.DrawString(this.txtUserFirstNameLast.Text, fBody, sb, 107, 234);
            g.DrawString("NO. OPERACION:", fTitle, sb, 10, 245); //
            g.DrawString(this.txtIdTicket.Text, fBody, sb, 115, 245); //

            var opBoxop = new OperationsCajaEntity();

            opBoxop.TypeOp = Convert.ToString(this.txtType.Text);


            var op = opBoxop.TypeOp;

            // Open box title
            g.DrawString(Type1, fTitle, sb, 75, 262);


            // Detail cash

            g.DrawString("-----------------------------------------", fBody, sb, 5, 280);
            g.DrawString("     DETALLES DE OPERACION EN CAJA       ", fdpTitle, sb, 10, 290);
            g.DrawString("-----------------------------------------", fBody, sb, 5, 298);
            g.DrawString("   DENOMINACION    CANTIDAD   MONTO      ", fdpTitle, sb, 10, 304);
            g.DrawString("-----------------------------------------", fBody, sb, 5, 310);

            int AutoScrollOffset = +14;

            // detail open box process
            #region old code details not used ...
                //AutoScrollOffset = AutoScrollOffset + 12;
                //g.DrawString("Monedas de 1: ", fdpTitle, sb, 90, 330 + AutoScrollOffset);   // 
                //g.DrawString(this.txtMonedas1.Text, fBody, sb, 202, 330 + AutoScrollOffset);  //
                //g.DrawString("Monedas de 5: ", fdpTitle, sb, 90, 350 + AutoScrollOffset);
                //g.DrawString(this.txtMonedas5.Text, fBody, sb, 202, 350 + AutoScrollOffset); //
                //g.DrawString("Monedas de 10: ", fpTitle, sb, 90, 368 + AutoScrollOffset); //
                //g.DrawString(this.txtMonedas10.Text, fpBody, sb, 202, 368 + AutoScrollOffset);  //
                //g.DrawString("Monedas de 25 ", fdpTitle, sb, 100, 370 + AutoScrollOffset);
                //g.DrawString(this.txtMonedas25.Text, fBody, sb, 202, 389 + AutoScrollOffset);
                //g.DrawString("Billetes de 50: ", fdpTitle, sb, 90, 389 + AutoScrollOffset); //
                //g.DrawString(this.txtBilletes50.Text, fBody, sb, 202, 389 + AutoScrollOffset); //
                //g.DrawString("Billetes de 100: ", fdpTitle, sb, 90, 405 + AutoScrollOffset); //
                //g.DrawString(this.txtBilletes100.Text, fBody, sb, 202, 405 + AutoScrollOffset); //
                //g.DrawString("Billetes de 200: ", fdpTitle, sb, 90, 420 + AutoScrollOffset);
                //g.DrawString(this.txtBilletes200.Text, fdpTitle, sb, 202, 420 + AutoScrollOffset);
                //g.DrawString("Billetes de 500: ", fdpTitle, sb, 90, 420 + AutoScrollOffset);
                //g.DrawString(this.txtBilletes500.Text, fdpTitle, sb, 202, 420 + AutoScrollOffset);
                //g.DrawString("Billetes de 1000: ", fdpTitle, sb, 90, 420 + AutoScrollOffset);
                //g.DrawString(this.txtBilletes1000.Text, fdpTitle, sb, 202, 420 + AutoScrollOffset);
                //g.DrawString("Billetes de 2000: ", fdpTitle, sb, 90, 420 + AutoScrollOffset);
                //g.DrawString(this.txtBilletes2000.Text, fdpTitle, sb, 202, 420 + AutoScrollOffset);
            #endregion

            //
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
            g.DrawString("Monto Total:", fdpTitle, sb, 10, 480 + AutoScrollOffset);
            g.DrawString(this.lblMontoTotal.Text + ".00", fpBody, sb, 212, 480 + AutoScrollOffset);


            #region feet Ticket not used...

            /*  }
              else if (opBoxcl.TypeOp == 2)
              {
                  // detail close box process
                  var closebox = new frmCierreCaja();

                  AutoScrollOffset = AutoScrollOffset + 12;
                  g.DrawString("Monedas de 1:", fdpTitle, sb, 90, 330 + AutoScrollOffset);   // 
                  g.DrawString(closebox.txtMonedas1.Text, fBody, sb, 202, 330 + AutoScrollOffset);  //
                  g.DrawString("Monedas de 5:", fdpTitle, sb, 90, 350 + AutoScrollOffset);
                  g.DrawString(closebox.txtMonedas5.Text, fBody, sb, 202, 350 + AutoScrollOffset); //
                  g.DrawString("Monedas de 10:", fpTitle, sb, 90, 368 + AutoScrollOffset); //
                  g.DrawString(closebox.txtMonedas10.Text, fpBody, sb, 202, 368 + AutoScrollOffset);  //
                  g.DrawString("Monedas de 25", fdpTitle, sb, 100, 370 + AutoScrollOffset);
                  g.DrawString(closebox.txtMonedas25.Text, fBody, sb, 202, 389 + AutoScrollOffset);
                  g.DrawString("Billetes de 50:", fdpTitle, sb, 90, 389 + AutoScrollOffset); //
                  g.DrawString(closebox.txtBilletes50.Text, fBody, sb, 202, 389 + AutoScrollOffset); //
                  g.DrawString("Billetes de 100:", fdpTitle, sb, 90, 405 + AutoScrollOffset); //
                  g.DrawString(closebox.txtBilletes100.Text, fBody, sb, 202, 405 + AutoScrollOffset); //
                  g.DrawString("Billetes de 200:", fdpTitle, sb, 90, 420 + AutoScrollOffset);
                  g.DrawString(closebox.txtBilletes200.Text, fdpTitle, sb, 200, 420 + AutoScrollOffset);
                  g.DrawString("Billetes de 500:", fdpTitle, sb, 90, 420 + AutoScrollOffset);
                  g.DrawString(closebox.txtBilletes500.Text, fdpTitle, sb, 200, 420 + AutoScrollOffset);
                  g.DrawString("Billetes de 1000:", fdpTitle, sb, 90, 420 + AutoScrollOffset);
                  g.DrawString(closebox.txtBilletes1000.Text, fdpTitle, sb, 200, 420 + AutoScrollOffset);
                  g.DrawString("Billetes de 2000:", fdpTitle, sb, 90, 420 + AutoScrollOffset);
                  g.DrawString(closebox.txtBilletes2000.Text, fdpTitle, sb, 200, 420 + AutoScrollOffset);

                  //Total Amount for this process

                  AutoScrollOffset = AutoScrollOffset + 8;
                  g.DrawString("Monto Total de Ventas:", fBody, sb, 5, 426 + AutoScrollOffset);
                  g.DrawString(closebox.lblTotalVentas.Text, fpBody, sb, 100, 426 + AutoScrollOffset);   //
                  g.DrawString("Efectivo en Caja:", fBody, sb, 5, 426 + AutoScrollOffset);
                  g.DrawString(closebox.lblEfectivoCaja.Text, fpBody, sb, 100, 426 + AutoScrollOffset);   //
                  g.DrawString("Diferencia entre Efectivo y Ventas:", fBody, sb, 5, 426 + AutoScrollOffset);
                  g.DrawString(closebox.lblFaltante.Text, fpBody, sb, 100, 426 + AutoScrollOffset);   //
              }
              */

            /*  
             *  //------------------------------------------------------------------------------------> Here begin comment

             // Feet Messenge
             AutoScrollOffset = AutoScrollOffset + 8;
             g.DrawString("Le Atendio:", fBody, sb, 5, 426 + AutoScrollOffset);
             g.DrawString(this.lblCajeroName.Text, fpBody, sb, 100, 426 + AutoScrollOffset);   // Casher First Name and Last Name
             g.DrawString("Nota: no hacemos devoluciones después de la 24 horas,", tbottom, sb, 5, 442 + AutoScrollOffset);
             g.DrawString("y mucho menos si los medicamentos se encuentran en", tbottom, sb, 5, 452 + AutoScrollOffset);
             g.DrawString("mal estado.", tbottom, sb, 5, 462 + AutoScrollOffset);

             g.DrawString("Tú eres la persona más linda que Jesús", fTitle, sb, 5, 482 + AutoScrollOffset);
             g.DrawString("tiene en este mundo Buscale.", fTitle, sb, 5, 497 + AutoScrollOffset);

             g.DrawString(".", tblank, sb, 5, 506 + AutoScrollOffset);
             // 
             */
            #endregion
        }
        #endregion

    }
}
