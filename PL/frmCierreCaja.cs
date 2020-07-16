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
            CierreCajaBO.CleanTranstactions();
            CierreCajaBO.CleanOpenBox();
        }

        /// <summary>
        /// Amount for Open Box
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
            catch// (Exception ex)
            {
                MessageBox.Show("Indicar Valores Numericos","Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                decimal Amount = 0;
                Amount = CierreCajaBO.MontoVentas();
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
                CalculateAmount();
                GetMAmount();
            }
            catch //(Exception ex)
            {
                MessageBox.Show("Indicar Valores Validos","Mensaje del Sistema");
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
                    Answer = MessageBox.Show("Seguro que Desea Cerrar la Caja", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (Answer == DialogResult.Yes)
                    {
                        CloseBoxProc();
                        //Print();
                        CleanControls();
                        MessageBox.Show("Cierre Realizado Satisfactoriamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //TicketVentaEntity tk = new TicketVentaEntity();
            //Parameters
            Font fBody = new Font("Lucida Console", 8, FontStyle.Regular);// Format Font for Body
            Font ffTitle = new Font("Lucida Console", 11, FontStyle.Bold); // Format Font for Title Company Name
            Font fTitle = new Font("Lucida Console", 8, FontStyle.Bold); // Format Font for Title
            Font fdpTitle = new Font("Lucida Console", 8, FontStyle.Regular); // Format Font Detail Products
            Font fpTitle = new Font("Lucida Console", 8, FontStyle.Bold); // Format Font Title Amount
            Font fpBody = new Font("Lucida Console", 8, FontStyle.Bold);// Format number Amount
            Font tbottom = new Font("Lucida Console", 6, FontStyle.Regular); // Format Font Messege Bottom
            Font tblank = new Font("Lucida Console", 19, FontStyle.Bold); // Format Font  Bottom
            Font fdTitle = new Font("Lucida Console", 8, FontStyle.Regular);//Format Font for Detail Title (Address,Telephone, etc.. About Company Information)
            Graphics g = e.Graphics;
            SolidBrush sb = new SolidBrush(Color.Black); // Set Brush color for Drawing Charaters

            string Type = "CIERRE DE CAJA";

            //Id Invoice

          //  this.txtId_Invoice.Text = Convert.ToString(Id_invoice);

            RawPrinterHelper j = new RawPrinterHelper(); //

            //Header invoice

            //int AutoScrollOffset1= -100;
            //AutoScrollOffset1 = AutoScrollOffset1 -100;
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
            g.DrawString("CAJERO:", fTitle, sb, 10, 220);
            //g.DrawString(this.txtClientes.Text, fBody, sb, 80, 220);
            //g.DrawString(this.txtApClientes.Text, fBody, sb, 180, 220);
            g.DrawString("NCF:", fTitle, sb, 10, 232);
            g.DrawString("NIF:", fTitle, sb, 10, 244);
            //g.DrawString(this.txtId_Invoice.Text, fBody, sb, 50, 244);


            g.DrawString(Type, fTitle, sb, 75, 255);

            //Detail Invoice
            g.DrawString("----------------------------------------", fBody, sb, 5, 280);
            g.DrawString("          DETALLE DEL CIERRE            ", fdpTitle, sb, 10, 290);
            g.DrawString("----------------------------------------", fBody, sb, 5, 298);
            int AutoScrollOffset = +14;

          //  int a = this.dgvDetalle.Rows.Count;

            //for (int i = 0; i < a; i++)
            //{
                //g.DrawString(Convert.ToString(this.dgvDetalle.Rows[i].Cells[0].Value), fdpTitle, sb, 5, 305 + AutoScrollOffset);
                //g.DrawString(Convert.ToString(this.dgvDetalle.Rows[i].Cells[1].Value), fdpTitle, sb, 5, 305 + AutoScrollOffset); //Description
                //g.DrawString(Convert.ToString(this.dgvDetalle.Rows[i].Cells[2].Value), fdpTitle, sb, 153, 305 + AutoScrollOffset); //Quality
                //g.DrawString(Convert.ToString(this.dgvDetalle.Rows[i].Cells[3].Value), fdpTitle, sb, 178, 305 + AutoScrollOffset);// Price
                //g.DrawString(Convert.ToString(this.dgvDetalle.Rows[i].Cells[4].Value), fpTitle, sb, 225, 305 + AutoScrollOffset); // Total Price x Unit
                //AutoScrollOffset = AutoScrollOffset + 12;
            //}

            //Paid Detail
            //AutoScrollOffset = AutoScrollOffset + 12;
            //g.DrawString("SubTotal:", fdpTitle, sb, 100, 330 + AutoScrollOffset);   // 
            //g.DrawString(this.txtSubtotal.Text, fBody, sb, 200, 330 + AutoScrollOffset);  //
            //g.DrawString("Descuento:", fdpTitle, sb, 100, 350 + AutoScrollOffset);
            //g.DrawString(this.txtDescuento.Text, fBody, sb, 200, 350 + AutoScrollOffset); //
            //g.DrawString("Total a Pagar:", fpTitle, sb, 100, 368 + AutoScrollOffset); //
            //g.DrawString(this.txtTotalPagar.Text, fpBody, sb, 200, 368 + AutoScrollOffset);  //
            //g.DrawString("", fdpTitle, sb, 100, 370 + AutoScrollOffset);
            //g.DrawString("Recibido:", fdpTitle, sb, 100, 389 + AutoScrollOffset); //
            //g.DrawString(this.txtEfectivoRecibido.Text, fBody, sb, 200, 389 + AutoScrollOffset); //
            //g.DrawString("Devuelta:", fdpTitle, sb, 100, 405 + AutoScrollOffset); //
            //g.DrawString(this.txtDevueltaEfectivo.Text, fBody, sb, 200, 405 + AutoScrollOffset); //

            //Feet Messenge
            AutoScrollOffset = AutoScrollOffset + 8;
            g.DrawString("Atendido por:", fBody, sb, 5, 420 + AutoScrollOffset);
            g.DrawString("Nombre del Cajero", fpBody, sb, 100, 420 + AutoScrollOffset);
            g.DrawString("Nota: no hacemos devoluciones después de la 24 horas,", tbottom, sb, 5, 440 + AutoScrollOffset);
            g.DrawString("y mucho menos si los medicamentos se encuentran en", tbottom, sb, 5, 450 + AutoScrollOffset);
            g.DrawString("mal estado.", tbottom, sb, 5, 460 + AutoScrollOffset);

            g.DrawString("Tú eres la persona más linda que Jesús", fTitle, sb, 5, 480 + AutoScrollOffset);
            g.DrawString("tiene en este mundo Buscale.", fTitle, sb, 5, 495 + AutoScrollOffset);

            g.DrawString(".", tblank, sb, 5, 505 + AutoScrollOffset);
            // 
        }
        #endregion
    }
}
