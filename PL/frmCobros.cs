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
       private VentaEntity  venta=null;

        public frmCobros()
        {
            InitializeComponent();
        }

        private void btnCancelarPago_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCobros_Load(object sender, EventArgs e)
        {
            OnlyRead();
            Operacion();

        }

        //
        private void OnlyRead()
        {
            this.txtMontoCobrar.ReadOnly = true;
            this.txtDevueltaEfectivo.ReadOnly = true;

        }

        //
        private void Operacion()
        {
            
            decimal subtotal, t_pagar;
            decimal t_itbis;
            subtotal = venta.SubTotal();
            t_itbis = venta.Itbis();
            t_pagar = venta.Pagar(t_itbis, subtotal);
            this.txtMontoCobrar.Text = string.Format("{0:C2}",t_pagar);
        }

        private void txtEfectivoRecibido_TextChanged(object sender, EventArgs e)
        {
            if (this.txtEfectivoRecibido.Text != "")
            {
                decimal efectivo,recibido;
                decimal subtotal, t_pagar;
                decimal t_itbis;
                recibido= Convert.ToDecimal (this.txtEfectivoRecibido.Text);
                subtotal = venta.SubTotal();
                t_itbis = venta.Itbis();
                t_pagar = venta.Pagar(t_itbis, subtotal);
                efectivo = venta.Cambio_Compras(t_pagar,recibido);
                this.txtDevueltaEfectivo.Text = string.Format("{0:C2}",efectivo);
            }
        }
    }
}
