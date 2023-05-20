using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pjPalmera.BLL;
using pjPalmera.Entities;


namespace pjPalmera.PL
{
    public partial class frmConsulFactCredito : Form
    {
        public frmConsulFactCredito()
        {
            InitializeComponent();
        }

        private void frmConsulFactCredito_Load(object sender, EventArgs e)
        {
            DesableControls();
            this.dgvFacturasEmitidasCred.DataSource = FacturaBO.GetCreditInvoices();
            GetAmount();
        }

        /// <summary>
        /// Desable All Controls
        /// </summary>
        private void DesableControls()
        {
            this.mktxtFechaDesde.Visible = false;
            this.mktxtFechaHasta.Visible = false;
            this.txtNumFactura.Visible = false;
            this.lblCriterio1.Visible = false;
            this.lblCriterio2.Visible = false;
            this.rbFecha.Checked = false;
            this.rbNumFact.Checked = false;
        }

        /// <summary>
        /// Enable Control to Search by Number
        /// </summary>
        private void EnableControlByNum()
        {
            this.lblCriterio1.Visible = true;
            this.lblCriterio1.Text = "Numero";
            this.txtNumFactura.Visible = true;
            this.txtNumFactura.Focus();
        }

        /// <summary>
        /// Desable Control to Search by Number
        /// </summary>
        private void DesableControlByNum()
        {
            this.lblCriterio1.Visible = false;
            this.lblCriterio1.Text = "";
            this.txtNumFactura.Text = "";
            this.txtNumFactura.Visible = false;
        }

        /// <summary>
        /// Enable Control to Search by Date
        /// </summary>
        private void EnableControlDate()
        {
            this.mktxtFechaDesde.Visible = true;
            this.mktxtFechaHasta.Visible = true;
            this.lblCriterio1.Visible = true;
            this.lblCriterio2.Visible = true;
            this.lblCriterio1.Text = "Desde";
            this.lblCriterio2.Text = "Hasta";
        }

        /// <summary>
        /// Desable Control to Search by Date
        /// </summary>
        private void DesableControlDate()
        {
            this.mktxtFechaDesde.Visible = false;
            this.mktxtFechaHasta.Visible = false;
            this.lblCriterio1.Visible = true;
            this.lblCriterio2.Visible = false;
            this.lblCriterio1.Text = "";
            this.lblCriterio2.Text = "";
        }


        /// <summary>
        /// Get Amount All Invoices type credit
        /// </summary>
        private void GetAmount()
        {
            decimal Amount;

            Amount = FacturaBO.AmountAllInvoicesCr();

            this.lblMontoTotalinvoicesRes.Text = Convert.ToString(Amount);
        }



        private void rbNumFact_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbNumFact.Checked == true)
            {
                DesableControlDate();
                EnableControlByNum();
            }
            else
            {
                DesableControlByNum();
            }
        }

        private void txtNumFactura_TextChanged(object sender, EventArgs e)
        {
            if ((this.rbNumFact.Checked == true) && (this.rbFecha.Checked == false))
            {
                try
                {
                    this.dgvFacturasEmitidasCred.DataSource=FacturaBO.SearchByNumberCr(Convert.ToInt64(this.txtNumFactura.Text));
                }
                catch (Exception)
                {
                    this.dgvFacturasEmitidasCred.DataSource = null;
                    this.dgvFacturasEmitidasCred.DataSource = FacturaBO.GetCreditInvoices();
                    return;
                }
            }
        }

        private void rbFecha_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.rbFecha.Checked == true) && (this.rbNumFact.Checked == false))
            {
                DesableControlByNum();
                EnableControlDate();
            }
        }
    }
}
