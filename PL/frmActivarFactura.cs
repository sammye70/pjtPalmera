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
        private void EnableBill(string number)
        {
            var Answer = new DialogResult();

            if (number == string.Empty)
            {
                MessageBox.Show("Debe indicar un número de factura valido", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNoFactActivar.Focus();
            }
            else if (number != string.Empty)
            {
                var NumFactura = FacturaBO.ExitsInvoice(int.Parse(number));

                if (NumFactura == true)
                {
                    MessageBox.Show(FacturaBO.strMensajeBO + number, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    Answer = MessageBox.Show("Esta Apunto de Activar la Factura " + number + ", Desea Continuar", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (Answer == DialogResult.Yes)
                    {
                        ProcessEnableInvoice(int.Parse(number));
                        MessageBox.Show("Factura " + number + " Activada Satisfactoriamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else if (Answer == DialogResult.No)
                    {
                        return;
                    }
                }
                else if (NumFactura == false)
                {
                    MessageBox.Show(FacturaBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNoFactActivar.Focus();
                }
            }
        }

        /// <summary>
        /// Change to Status Enable Current Invoice
        /// </summary>
        private void ProcessEnableInvoice(int number)
        {
            var invoice = new VentaEntity();
            var detail = new DetalleVentaEntity();

            invoice.id = Convert.ToInt32(this.txtNoFactActivar.Text);
            //var number = Convert.ToInt64(this.txtNoFactActivar.Text);
            invoice.status = 1;
            FacturaBO.EnableInvoice(invoice);
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
            var number = this.txtNoFactActivar.Text;

            EnableBill(number);
        }

        private void txtNoFactActivar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnActivarFac.Focus();
            }

            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
