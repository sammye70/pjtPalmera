using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pjPalmera.Entities;
using pjPalmera.BLL;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace pjPalmera.PL
{
    public partial class frmConsultFacturasCont : Form
    {
        VentaEntity venta = new VentaEntity();
        int _idVenta;

        public int Id_venta
        {
            get { return _idVenta; }
        }

        public frmConsultFacturasCont()
        {
            InitializeComponent();
            LoadInvoices();
            DescribeControls();
            DataGridStyle();
        }

        private void rbNumFact_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbNumFact.Checked == true)
            {
                EnableControls();
                this.lblCriterio1.Text = "Numero";
                CleanControls();
                DesableControlsDate();
                this.txtValorCriterio1.Focus();
                this.dgvFacturasEmitidas.DataSource = null;
                this.dgvFacturasEmitidas.DataSource = FacturaBO.GetCashInvoices();
            }
        }

        /// <summary>
        /// Desable Controls Relavite Date
        /// </summary>
        private void DesableControlsDate()
        {
            this.mktxtFechaDesde.Visible = false;
            this.mktxtFechaHasta.Visible = false;
            this.lblCriterio2.Visible = false;
            this.btnSearch.Visible = false;
        }

        /// <summary>
        /// Clean Content in Controls
        /// </summary>
        private void CleanControls()
        {
            this.txtValorCriterio1.Text = "";
        }

        /// <summary>
        /// Clean Content in Controls Date
        /// </summary>
        private void CleanControlsDate()
        {
            this.mktxtFechaDesde.Text = "  / /    ";
            this.mktxtFechaHasta.Text = "  / /    ";
        }

        /// <summary>
        /// Desable Controls in this form
        /// </summary>
        private void DesableControls()
        {
            this.lblCriterio1.Visible = false;
            this.lblCriterio2.Visible = false;
            this.mktxtFechaDesde.Visible = false;
            this.mktxtFechaHasta.Visible = false;
            this.dgvFacturasEmitidas.ReadOnly=true;
            this.dgvDetailFactCont.ReadOnly = true;
        }

        /// <summary>
        /// Enable Controls in this form
        /// </summary>
        private void EnableControls()
        {
            this.lblCriterio1.Visible = true;
            this.txtValorCriterio1.Visible = true;
        }

        /// <summary>
        /// Desable All Filter
        /// </summary>
        private void DesableOptions()
        {
            this.rbFecha.Checked = false;
            this.rbNumFact.Checked = false;
        }

        /// <summary>
        /// Enable Control to Date
        /// </summary>
        private void EnableControlsDate()
        {
            this.mktxtFechaDesde.Visible = true;
            this.mktxtFechaHasta.Visible = true;
            this.btnSearch.Visible = true;
            this.lblCriterio1.Visible = true;
            this.lblCriterio2.Visible = true;
            this.lblCriterio1.Text = "Desde";
            this.lblCriterio2.Text = "Hasta";
        }

        /// <summary>
        /// Get Amount Total all Invoices
        /// </summary>
        private void GetAllAmountInvoices()
        {
            decimal amount;
            amount = FacturaBO.AmountAllInvoices();
            this.lblMontoTotalinvoicesRes.Text = Convert.ToString(amount);
        }

        /// <summary>
        /// Describe All Controls in this form
        /// </summary>
        private void DescribeControls()
        {
            this.toolTip1.SetToolTip(this.btnSearch,"Filtrar segun fechas indicas");
            this.toolTip1.SetToolTip(this.btnConsulDetailinvoice, "Muestra los productos contenidos en la factura seleccionada");
            this.toolTip1.SetToolTip(this.btnReprintInvoice, "Permite Reimprimir la Factura actual que se filtro su detalle");
            this.toolTip1.SetToolTip(this.btnFiltroInvoices, "Permite desactivar el filtro aplicado a la factura para conocer su detalle");
        }

        /// <summary>
        /// Load All Invoices 
        /// </summary>
        private void LoadInvoices()
        {
            this.dgvFacturasEmitidas.DataSource = null;
            this.dgvDetailFactCont.DataSource = null;
            this.dgvFacturasEmitidas.DataSource = FacturaBO.GetCashInvoices();
            //this.dgvDetailFactCont.DataSource = FacturaBO.GetAllDetailInvoices();
        }

        /// <summary>
        /// Set DataGridView Styles All
        /// </summary>
        private void DataGridStyle()
        {
            this.dgvDetailFactCont.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvFacturasEmitidas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        /// <summary>
        /// Search Invoices by Number
        /// </summary>
        private void SearchByNumber()
        {
            try
            {
                venta.id = Convert.ToInt32(this.txtValorCriterio1.Text);
                this.dgvFacturasEmitidas.DataSource = FacturaBO.SearchByNumber(venta.id);
            }
            catch
            {
                
            }
        }

        /// <summary>
        /// Search Invoices by Date
        /// </summary>
        private void SearchByDate()
        {
            try
            {
                DateTime date1=venta.fecha = Convert.ToDateTime(mktxtFechaDesde.Text);
                DateTime date2=venta.fecha = Convert.ToDateTime(mktxtFechaHasta.Text);

                this.dgvFacturasEmitidas.DataSource = FacturaBO.SearchByDate(Convert.ToString(date1), Convert.ToString(date2));
            }
            catch
            {
               
            }
        }

        /// <summary>
        /// Filter Detail Invoices (only cash)
        /// </summary>
        private void Filter_Detail_Invoices()
        {
            try
            {
                
                int x = this.dgvFacturasEmitidas.CurrentRow.Index;

                _idVenta = Convert.ToInt32(this.dgvFacturasEmitidas.Rows[x].Cells[0].Value);

                this.dgvDetailFactCont.DataSource = FacturaBO.GetDetailInvoices(Id_venta);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rbFecha_CheckedChanged(object sender, EventArgs e)
        {
            CleanControlsDate();
            this.txtValorCriterio1.Visible = false;
            EnableControlsDate();
            this.mktxtFechaDesde.Focus();
            this.dgvFacturasEmitidas.DataSource = null;
            this.dgvFacturasEmitidas.DataSource = FacturaBO.GetCashInvoices();
        }


        private void frmConsulFactEmitidas_Load(object sender, EventArgs e)
        {
            CleanControls();
            DesableControls();
           // GetAllAmountInvoices();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.rbFecha.Checked == true)
            {
                SearchByDate();
            }
            else
            {
                this.dgvFacturasEmitidas.DataSource = null;
                this.dgvFacturasEmitidas.DataSource = FacturaBO.GetAll();
            }
        }

        private void txtValorCriterio1_TextChanged(object sender, EventArgs e)
        {
            if ((this.rbNumFact.Checked == true) && (this.txtValorCriterio1.Text != String.Empty))
            {
                SearchByNumber();
            }
            else
            {
                this.dgvFacturasEmitidas.DataSource = null;
                this.dgvFacturasEmitidas.DataSource = FacturaBO.GetAll();
            }
        }

        private void btnConsulDetailinvoice_Click(object sender, EventArgs e)
        {
            Filter_Detail_Invoices();
        }

        private void btnFiltroInvoices_Click(object sender, EventArgs e)
        {
            LoadInvoices();
            CleanControls();
            CleanControlsDate();
            DesableControls();
            DesableControlsDate();
            DesableOptions();
        }

        #region Reprint Invoice Ticket (Invoice paid cash)
        /// <summary>
        /// Reprint Invoices Ticket (By Original Print Bill)
        /// </summary>
        /// Bill print Setting
        /// Author: Samuel Estrella
        /// Create Date: 17/01/2020
        /// Modificated Date: 29/06/2020
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

            string Type = "FACTURA AL CONTADO";
            int x = this.dgvFacturasEmitidas.CurrentRow.Index;

            //Id Invoice
           // venta.id = FacturaBO.LastId();
            //this.txtId_Invoice.Text = Convert.ToString(venta.id);

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
            g.DrawString(DateTime.Now.ToShortDateString(), fBody, sb, 80, 210); // Date    
            g.DrawString("HORA:", fTitle, sb, 155, 210);
            g.DrawString(DateTime.Now.ToShortTimeString(), fBody, sb, 195, 210); // Hour
            g.DrawString("CLIENTE:", fTitle, sb, 10, 220);
            g.DrawString(this.dgvFacturasEmitidas.Rows[x].Cells[1].Value.ToString(), fBody, sb, 80, 220); // Customer Name
           // g.DrawString(this.txtApClientes.Text, fBody, sb, 180, 220);
            g.DrawString("NCF:", fTitle, sb, 10, 232);
            g.DrawString("NIF:", fTitle, sb, 10, 244);
            g.DrawString(this.dgvFacturasEmitidas.Rows[x].Cells[0].Value.ToString(), fBody, sb, 50, 244); // Invoice id

            //Title Invoice Type Ticket
            g.DrawString(Type, fTitle, sb, 75, 255);

            //Detail Invoice
            g.DrawString("----------------------------------------", fBody, sb, 5, 280);
            g.DrawString("DESCRIPCION        CANT  PRECIO IMPORTE ", fdpTitle, sb, 10, 290);
            g.DrawString("----------------------------------------", fBody, sb, 5, 298);
            int AutoScrollOffset = +14;

            int a = this.dgvDetailFactCont.Rows.Count;

            for (int i = 0; i < a; i++)
            {
                //g.DrawString(Convert.ToString(this.dgvDetalle.Rows[i].Cells[0].Value), fdpTitle, sb, 5, 305 + AutoScrollOffset); // ITEM ID
                g.DrawString(Convert.ToString(this.dgvDetailFactCont.Rows[i].Cells[1].Value), fdpTitle, sb, 5, 305 + AutoScrollOffset); //Description
                g.DrawString(Convert.ToString(this.dgvDetailFactCont.Rows[i].Cells[2].Value), fdpTitle, sb, 153, 305 + AutoScrollOffset); //Quality
                g.DrawString(Convert.ToString(this.dgvDetailFactCont.Rows[i].Cells[3].Value), fdpTitle, sb, 178, 305 + AutoScrollOffset);// Price
                g.DrawString(Convert.ToString(this.dgvDetailFactCont.Rows[i].Cells[4].Value), fpTitle, sb, 225, 305 + AutoScrollOffset); // Total Price x Unit
                AutoScrollOffset = AutoScrollOffset + 12;
            }

            //Paid Detail
            AutoScrollOffset = AutoScrollOffset + 12;
            g.DrawString("SubTotal:", fdpTitle, sb, 100, 330 + AutoScrollOffset);   // 
            g.DrawString(this.dgvFacturasEmitidas.Rows[x].Cells[10].Value.ToString(), fBody, sb, 200, 330 + AutoScrollOffset);  //
            g.DrawString("Descuento:", fdpTitle, sb, 100, 350 + AutoScrollOffset);
            g.DrawString(this.dgvFacturasEmitidas.Rows[x].Cells[9].Value.ToString(), fBody, sb, 200, 350 + AutoScrollOffset); //
            g.DrawString("Total a Pagar:", fpTitle, sb, 100, 368 + AutoScrollOffset); //
            g.DrawString(this.dgvFacturasEmitidas.Rows[x].Cells[8].Value.ToString(), fpBody, sb, 200, 368 + AutoScrollOffset);  //
            g.DrawString("", fdpTitle, sb, 100, 370 + AutoScrollOffset);
            g.DrawString("Recibido:", fdpTitle, sb, 100, 389 + AutoScrollOffset); //
            g.DrawString(this.dgvFacturasEmitidas.Rows[x].Cells[13].Value.ToString(), fBody, sb, 200, 389 + AutoScrollOffset); //
            g.DrawString("Devuelta:", fdpTitle, sb, 100, 405 + AutoScrollOffset); //
            g.DrawString(this.dgvFacturasEmitidas.Rows[x].Cells[14].Value.ToString(), fBody, sb, 200, 405 + AutoScrollOffset); //

            //Feet Messenge
            AutoScrollOffset = AutoScrollOffset + 8;
            g.DrawString("Nota: no hacemos devoluciones después de la 24 horas,", tbottom, sb, 5, 440 + AutoScrollOffset);
            g.DrawString("y mucho menos si los medicamentos se encuentran en", tbottom, sb, 5, 450 + AutoScrollOffset);
            g.DrawString("mal estado.", tbottom, sb, 5, 460 + AutoScrollOffset);

            g.DrawString("Tu eres la persona mas linda que Jesús", fTitle, sb, 5, 480 + AutoScrollOffset);
            g.DrawString("tiene en este mundo Buscale.", fTitle, sb, 5, 495 + AutoScrollOffset);

            g.DrawString(".", tblank, sb, 5, 505 + AutoScrollOffset);
            // 
        }
        #endregion

        private void btnReprintInvoice_Click(object sender, EventArgs e)
        {
            var detallerow = this.dgvDetailFactCont.RowCount;

            if (detallerow < 1)
            {
                MessageBox.Show("IMPORTANTE: Debe Consultar el Detalle de la Factura deseada, para poder Reimprimir el documento.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else 
            {
                var question = MessageBox.Show("Seguro que desea Reimprimir la Factura", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                try
                {
                    if (question == DialogResult.Yes)
                    {
                        PrintTicket();
                        MessageBox.Show("Se Reimprimio la Factura", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (question == DialogResult.No)
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
        }
    }
}
