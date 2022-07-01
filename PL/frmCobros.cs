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
    public partial class frmCobros : Form
    {
       // public decimal cobrar, efectivo;
        private decimal _recibido;
        private decimal _devuelta;
       // private int _typepay;

        /// <summary>
        /// Get change from Cobros
        /// </summary>
        public decimal getRecibido
        {
            get { return _recibido; }
        }

        /// <summary>
        /// Get cash from Cobros
        /// </summary>
        public decimal getDevuelta
        {
            get { return _devuelta; }
        }

        /// <summary>
        /// Get Pay Method from Cobros
        /// </summary>
        //public int getTypePay
        //{
        //    get { return _typepay; }
        //}

        public frmCobros()
        {
            InitializeComponent();
        }

        private void btnCancelarPago_Click(object sender, EventArgs e)
        {
            CleanControls();
            this.Close();
        }

        private void frmCobros_Load(object sender, EventArgs e)
        {

            DesableControls();
            DescControls();
            IniControls();
            this.txtEfectivoRecibido.Focus();
           
        }


        /// <summary>
        /// Describe all Controls in current form
        /// </summary>
        private void DescControls()
        {
            this.toolTip1.SetToolTip(this.btnCancelarPago, "Cancelar el Proceso de Cobro");
            this.toolTip1.SetToolTip(this.btnProcesarPagos, "Procesar la Venta y Cobrar");
        }

        /// <summary>
        /// Desable All Controls
        /// </summary>
        private void DesableControls()
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.txtDevueltaEfectivo.ReadOnly = true;
            this.txtAprobacionNo.Visible = false;
            this.lblAprobacion.Visible = false;
        }

        /// <summary>
        /// Clean Content of Controls 
        /// </summary>
        private void CleanControls()
        {
            this.txtDevueltaEfectivo.Text = "";
            this.txtEfectivoRecibido.Text = "";
            this.lblDevueltaEfectivo.Text = "";
        }

        /// <summary>
        /// Set initial values of Controls
        /// </summary>
        private void IniControls()
        {
             // this.lblTotalCobrar.Text = "0.00";
            this.lblDevueltaEfectivo.Text = "0.00";

            //var tpay = new type_payEntity();

            //tpay.setMethod();

            //for (int i = 0; i < tpay.arr_pay.Length; i++)
            //{
            //    this.cmbfPagos.DataSource = tpay.getMethod(i);
            //}
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
                var cobrar = decimal.Parse(this.lblTotalCobrar.Text);
                var efectivo = decimal.Parse(this.txtEfectivoRecibido.Text);
                // this.txtDevueltaEfectivo.Text = Convert.ToString(efectivo - cobrar);
                this.lblDevueltaEfectivo.Text = "";
                this.lblDevueltaEfectivo.Text = Convert.ToString(efectivo - cobrar);
            }
            catch
            {
                this.txtDevueltaEfectivo.Text = "";
                this.txtEfectivoRecibido.Focus();
            }
        }



        /// <summary>
        /// Get All Pay Methods
        /// </summary>
        private void LoadMethodPay()
        {
            this.cmbfPagos.DataSource = FacturaBO.GetMethod_Pays();
            this.cmbfPagos.DisplayMember = "Nombre";
            this.cmbfPagos.ValueMember = "Id";
            
        }


        private void txtEfectivoRecibido_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                this.btnProcesarPagos.Focus();
            }
        }

        // 
        private void btnProcesarPagos_Click(object sender, EventArgs e)
        {
            // Falta agregar la verificacion del credito si el monto acumulado hasta la fecha 
            // le permite que le procesen la venta (Agregar Regla de Negocio en BLL)
            //

            frmVenta invoice = new frmVenta();
            var venta = new frmVenta();
            bool resp = false;
            var answer = new DialogResult();

            if ((this.txtEfectivoRecibido.Text == string.Empty) && (this.cmbfPagos.Text == "efectivo"))
            {
                MessageBox.Show("Verificar los valor indicados de la Venta", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtEfectivoRecibido.Focus();
                return;
            }
            else if ((this.cmbfPagos.Text == "tarjeta"))
            {
                //if (!ValidatorPost())
                //    return;

                if (answer == DialogResult.Yes)
                {
                    try
                    {
                        _recibido = decimal.Parse(this.txtEfectivoRecibido.Text);
                        _devuelta = decimal.Parse(this.lblDevueltaEfectivo.Text);

                        // ----------------------------> Working Here
                        resp = true;
                        venta.ProcessSell(resp);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                }
                else if(answer == DialogResult.No)
                {
                    _recibido = decimal.Parse(this.txtEfectivoRecibido.Text);
                    _devuelta = decimal.Parse(this.lblDevueltaEfectivo.Text);

        
                    resp = false;
                    venta.ProcessSell(resp);
                }
            }
            else if((this.txtEfectivoRecibido.Text != string.Empty) && (this.cmbfPagos.Text == "efectivo"))
            {
                   
                //if (!ValidatorPost())
                //    return;

                answer = MessageBox.Show("Imprimir Recibo", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (answer == DialogResult.Yes)
                {
                    try
                    {
                        _recibido = decimal.Parse(this.txtEfectivoRecibido.Text);
                        _devuelta = decimal.Parse(this.lblDevueltaEfectivo.Text);
                       
                        resp = true;
                        venta.ProcessSell(resp);
                        
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else if (answer == DialogResult.No)
                {

                    _recibido = decimal.Parse(this.txtEfectivoRecibido.Text);
                    _devuelta = decimal.Parse(this.lblDevueltaEfectivo.Text);
             
                    resp = false;
                    venta.ProcessSell(resp);
                    this.Close();
                }
            }
        }

        private void cmbfPagos_DropDown(object sender, EventArgs e)
        {
            this.LoadMethodPay();
        }

        private void cmbfPagos_SelectedIndexChanged(object sender, EventArgs e)
        {

            var type = this.cmbfPagos.Text;

            switch (type)
            {
                case "efectivo":
                    this.txtAprobacionNo.Visible = false;
                    this.lblAprobacion.Visible = false;
                    this.btnProcesarPagos.Focus();
                    break;

                case "tarjeta":
                    this.txtAprobacionNo.Visible = true;
                    this.lblAprobacion.Visible = true;
                    this.txtAprobacionNo.Focus();
                    break;
                default :
                    return;
            }
            #region Old Method Pay
            //var typeP = new type_payEntity();
            //var invoice = new VentaEntity();
            //var method = this.cmbfPagos.Text;

            //if (method == "efectivo")
            //{ 
            //    _typepay = 1;

            //    invoice.method_pago = this.getTypePay;


            //    // set
            //}
            //else if ( method == "tarjeta")
            //{
            //    _typepay = 2;

            //    invoice.method_pago = this.getTypePay;

            //    // set
            //} 
            #endregion

        }

    }
}
