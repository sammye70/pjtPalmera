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

namespace pjPalmera.PL
{
    public partial class frmConsultFacturasCont : Form
    {
        VentaEntity venta = new VentaEntity();

        public frmConsultFacturasCont()
        {
            InitializeComponent();
            LoadInvoices();
            DescribeControls();
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
        }

        /// <summary>
        /// Load All Invoices 
        /// </summary>
        private void LoadInvoices()
        {
            this.dgvFacturasEmitidas.DataSource = null;
            this.dgvFacturasEmitidas.DataSource = FacturaBO.GetCashInvoices();
        }

        /// <summary>
        /// Search Invoices by Number
        /// </summary>
        private void SearchByNumber()
        {
            try
            {
                venta.id = Convert.ToInt64(this.txtValorCriterio1.Text);
                this.dgvFacturasEmitidas.DataSource = FacturaBO.SearhByNumber(venta.id);
            }
            catch
            {
                
            }
        }

        /// <summary>
        /// Search Invoices by Date
        /// </summary>
        private void SearhByDate()
        {
            try
            {
                DateTime date1=venta.fecha = Convert.ToDateTime(mktxtFechaDesde.Text);
                DateTime date2=venta.fecha = Convert.ToDateTime(mktxtFechaHasta.Text);

                this.dgvFacturasEmitidas.DataSource = FacturaBO.SearhByDate(Convert.ToString(date1), Convert.ToString(date2));
            }
            catch
            {
               
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
            GetAllAmountInvoices();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.rbFecha.Checked == true)
            {
                SearhByDate();
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
    }
}
