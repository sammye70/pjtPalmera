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
        /// Process Desable Invoice
        /// </summary>
        private void DesableBill(string number)
        {
            var Question = new DialogResult();

            if (number == string.Empty)
            {
                MessageBox.Show("Debe Indicar un Número de Factura", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtNoFactAnular.Focus();
                return;
            }
            else if (number != string.Empty)
            {
                try
                {
                    var NumFactura = FacturaBO.ExitsInvoice(int.Parse(number));

                    if (NumFactura == true)
                    {
                        MessageBox.Show(FacturaBO.strMensajeBO + number, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        Question = MessageBox.Show("Esta Apunto de Anular la Factura No: " + number + ". Desea Continuar", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (Question == DialogResult.Yes)
                        {
                            // ProcessDesableInvoice(int.Parse(numero));
                            Load_Invoice(int.Parse(number));
                            MessageBox.Show("Factura "+ number +" Anulada Satisfactoriamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else if (Question == DialogResult.No)
                        {
                            return;
                        }
                    }
                    else if (NumFactura == false)
                    {
                        MessageBox.Show(FacturaBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.txtNoFactAnular.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // MessageBox.Show("Formato incorrecto del número de factura (Solo acepta números)", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtNoFactAnular.Focus();
                }
            }
        }

        private void btnAnularFac_Click(object sender, EventArgs e)
        {
            var number = this.txtNoFactAnular.Text; //

            DesableBill(number);
        }

        private void frmAnularFactura_Load(object sender, EventArgs e)
        {
            DesableControls();
            CleanControls();
            DetailControls();
            this.txtNoFactAnular.Focus();
        }

        /// <summary>
        /// Load Invoice for Desable
        /// </summary>
        /// <param name="number"></param>
        private void Load_Invoice(int number)
        {
            //
            // Process 1 Change Status invoices, and Inscrement stock product -OK
            // Process 2 Insert list Product in Detail Desable Table waiting for if invoices changes status to Actived  -OK
            // Process 3 Insert transactions and General Transactions Tables -ok

            var invoice = new VentaEntity();
            var Detail = new List<DetalleVentaEntity>();

            invoice = FacturaBO.Get_Head_Invoice_ById(number);
            Detail = FacturaBO.GetDetail_byInvoiceId(number);

            try
            {

                for (int i = 0; i < Detail.Count; i++)
                {
                    // create method to add list item to  insert in new table detail invoice desable, and increment stock in table product
                    invoice.addProduct(Detail[i]);
                }

                ProductosBO.InscrementAfterDesable(invoice);
                FacturaBO.UpdateTranst(invoice);
                FacturaBO.DesableInvoices(invoice);
                FacturaBO.DeleteDetailByIdInvoice(invoice);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNoFactAnular.Text = "";
            this.txtNoFactAnular.Focus();
        }

        private void txtNoFactAnular_KeyDown(object sender, KeyEventArgs e)
        {
            //var number = this.txtNoFactAnular.Text;

            if (e.KeyData == Keys.Enter)
            {
                //  DesableBill(number);
                this.btnAnularFac.Focus();
            }
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
