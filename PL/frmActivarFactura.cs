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
    public partial class frmActivarFactura : Form
    {
        public frmActivarFactura()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Remove all content in Control
        /// </summary>
        private void CleanControls()
        {
            this.txtNoFactActivar.Text = "";
        }


        /// <summary>
        /// Desabble All Controls
        /// </summary>
        private void DesableControls()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }


        /// <summary>
        /// Description About Controls
        /// </summary>
        private void DetailControls()
        {
            this.toolTip1.SetToolTip(this.btnActivarFac, "Efectuar la Activación de la Factura");
            this.toolTip1.SetToolTip(this.btnLimpiar, "Limpiar Número de Factura Actual");
        }


        /// <summary>
        /// Process Enable Bill
        /// </summary>
        private void EnableBill()
        {
            //if (VerifyInvoice() == true)
            //{
            var Question = MessageBox.Show("Esta Apunto de Activar la Factura, Desea Continuar","Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Question == DialogResult.Yes)
            {
                ProcessEnableInvoice();
                MessageBox.Show("Factura Activada Satisfactoriamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (Question == DialogResult.No)
            {
                return;
                //MessageBox.Show("Factura No Anulada");
            }
            //}
            //else if (VerifyInvoice () == false)
            //{
            //    MessageBox.Show("No Existe Factura Asociado al Número Indicado", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        /// <summary>
        /// Change to Status Enable Current Invoice
        /// </summary>
        private void ProcessEnableInvoice()
        {
            var invoice = new VentaEntity();
            invoice.id = Convert.ToInt64(this.txtNoFactActivar.Text);
            //var number = Convert.ToInt64(this.txtNoFactActivar.Text);
            invoice.status = 1;
            FacturaBO.EnableInvoice(invoice);
        }

        /// <summary>
        ///  Verify if exits invoices
        /// </summary>
        /// <returns></returns>
        private bool VerifyInvoice()
        {
            bool result = true;
            var number = Convert.ToInt64(this.txtNoFactActivar.Text); //
            FacturaBO.ExitsInvoice(number); //
            var mensaje = FacturaBO.MensajeBO; //

            if (mensaje == true)
            {
                return result = true;  //
            }
            else if (mensaje == false)
            {
                return result = false; //
            }

            return result;
        }

        private void frmActivarFactura_Load(object sender, EventArgs e)
        {
            DesableControls();
            CleanControls();
            DetailControls();
            this.txtNoFactActivar.Focus();
        }

        private void btnActivarFac_Click(object sender, EventArgs e)
        {
            EnableBill();
        }
    }
}
