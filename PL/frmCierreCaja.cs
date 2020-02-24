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
        /// Amount for Open Box
        /// </summary>
        private void CalculateAmount()
        {
            try
            {
                int t, uno, cinco, diez, venticinco, cincuenta, cien, doscientos, quinientos, mil, dosmil;

                uno = Convert.ToInt32(this.txtMonedas1.Text); cinco = Convert.ToInt32(this.txtMonedas5.Text); diez = Convert.ToInt32(this.txtMonedas10.Text); venticinco = Convert.ToInt32(this.txtMonedas25.Text);
                cincuenta = Convert.ToInt32(this.txtBilletes50.Text); cien = Convert.ToInt32(this.txtBilletes100.Text); doscientos = Convert.ToInt32(this.txtBilletes200.Text); quinientos = Convert.ToInt32(this.txtBilletes500.Text);
                mil = Convert.ToInt32(this.txtBilletes1000.Text); dosmil = Convert.ToInt32(this.txtBilletes2000.Text);

                t = Services.monto(uno, cinco, diez, venticinco, cincuenta, cien, doscientos, quinientos, mil, dosmil);

                this.lblEfectivoCaja.Text = Convert.ToString(t);
            }
            catch// (Exception ex)
            {
                MessageBox.Show("Indicar Valores Numericos","Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void btnClean_Click(object sender, EventArgs e)
        {
            CleanControls();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (this.lblEfectivoCaja.Text != "0.00")
            {
                MessageBox.Show("Seguro que Desea Cerrar la Caja", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                DialogResult Question = new DialogResult();

                if (Question == DialogResult.Yes)
                {
                    CierreCajaBO.CleanTranstactions();
                    CleanControls();
                    MessageBox.Show("Cierre Realizado Satisfactoriamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else if (Question == DialogResult.No)
                {
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
    }
}
