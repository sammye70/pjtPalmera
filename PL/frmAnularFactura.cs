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
    public partial class frmAnularFactura : Form
    {
        public frmAnularFactura()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Remove all content in Control
        /// </summary>
        private void CleanControls()
        {
            this.txtNoFactAnular.Text = "";
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
            this.toolTip1.SetToolTip(this.btnAnularFac, "Efectuar la Anulación de la Factura");
            this.toolTip1.SetToolTip(this.btnLimpiar, "Limpiar Número de Factura Actual");
        }


        /// <summary>
        /// Process Desable Bill
        /// </summary>
        private void DesableBill()
        {
            //if (VerifyInvoice() == true)
            //{
                var Question = MessageBox.Show("Esta Apunto de Anular para Factura. Desea Continuar", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Question == DialogResult.Yes)
                {
                    ProcessDesableInvoice();
                    MessageBox.Show("Factura Anulada Satisfactoriamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnAnularFac_Click(object sender, EventArgs e)
        {
            DesableBill();
        }

        private void frmAnularFactura_Load(object sender, EventArgs e)
        {
            DesableControls();
            CleanControls();
            DetailControls();
            this.txtNoFactAnular.Focus();
        }



        /// <summary>
        /// Change to Status Desable current Invoice
        /// </summary>
        private void ProcessDesableInvoice()
        {
            var invoice = new VentaEntity();
            //var number = Convert.ToInt64(this.txtNoFactAnular.Text);
            invoice.id = Convert.ToInt32(this.txtNoFactAnular.Text);
            invoice.status = 2;
            FacturaBO.DesableInvoices(invoice);
        }


        /// <summary>
        ///  Verify if exits invoices
        /// </summary>
        /// <returns></returns>
        private bool VerifyInvoice()
        {
            bool result= true;
            var number = Convert.ToInt64(this.txtNoFactAnular.Text); //
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
    }
}
