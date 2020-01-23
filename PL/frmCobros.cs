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

namespace pjPalmera.PL
{
    public partial class frmCobros : Form
    {
       

        

        public decimal cobrar, efectivo;

        public frmCobros()
        {
            InitializeComponent();
        }

        private void btnCancelarPago_Click(object sender, EventArgs e)
        {
            CleanControls();
            this.txtTotalCobrar.Focus();
            this.Close();
        }

        private void frmCobros_Load(object sender, EventArgs e)
        {

            DesableControls();
            this.txtTotalCobrar.Focus();
           
        }


        /// <summary>
        /// Desable All Controls
        /// </summary>
        private void DesableControls()
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.txtDevueltaEfectivo.ReadOnly = true;
        }

        /// <summary>
        /// Clean Content of Controls 
        /// </summary>
        private void CleanControls()
        {
            this.txtDevueltaEfectivo.Text = "";
            this.txtEfectivoRecibido.Text = "";
            this.txtTotalCobrar.Text = "";
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        //    
        private void txtEfectivoRecibido_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cobrar = decimal.Parse(this.txtTotalCobrar.Text);
                efectivo = decimal.Parse(this.txtEfectivoRecibido.Text);
                this.txtDevueltaEfectivo.Text = Convert.ToString(efectivo - cobrar);
            }
            catch
            {
                this.txtDevueltaEfectivo.Text = "";
                this.txtEfectivoRecibido.Focus();
            }
        }

        // 
        private void btnProcesarPagos_Click(object sender, EventArgs e)
        {
            frmVenta fventa = new frmVenta();

            if ((this.txtTotalCobrar.Text == string.Empty) || (this.txtEfectivoRecibido.Text == string.Empty))
            {
                MessageBox.Show("Verificar los valor indicados de la Venta", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtTotalCobrar.Focus();
                return;
            }
            else

                try
                {            
                    fventa.Save_Invoices();
                    fventa.PrintTicket();
                    fventa.NewInvoice();
                    CleanControls();
                    this.Close();
                    MessageBox.Show("Venta Efectuada Satisfactoriamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtTotalCobrar.Focus();
                    return;
                   
                }
        }

    }
}
