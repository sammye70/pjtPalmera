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
    public partial class frmAbrirCaja : Form
    {
        AperturaCajaEntity opcaja = new AperturaCajaEntity();
        OpServices Services = new OpServices();

        public frmAbrirCaja()
        {
            InitializeComponent();
        }

        private void frmAbrirCaja_Load(object sender, EventArgs e)
        {
            InfControls();
            DesableControls();
            CleanControls();
            this.txtMonedas1.Focus();
            opcaja = null;
        }



        /// <summary>
        /// Desable All Controls
        /// </summary>
        private void DesableControls()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }


        /// <summary>
        /// Information about Controls
        /// </summary>
        private void InfControls()
        {
            this.toolTip1.SetToolTip(this.btnCalcularMonto,"Calcular Monto Apertura");
            this.toolTip1.SetToolTip(this.btnClean,"Limpiar Campos");
            this.toolTip1.SetToolTip(this.btnProcesar,"Efectuar Proceso de Apertura");
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
            this.lblMontoTotal.Text = "0.00";
        }

        /// <summary>
        /// Amount for Open Box
        /// </summary>
        private void CalculateAmount()
        {
            try
            {
                var t = Services.monto(Convert.ToInt32(this.txtMonedas1.Text), Convert.ToInt32(this.txtMonedas5.Text), Convert.ToInt32(this.txtMonedas10.Text), 
                                        Convert.ToInt32(this.txtMonedas25.Text), Convert.ToInt32(this.txtBilletes50.Text), Convert.ToInt32(this.txtBilletes100.Text), 
                                        Convert.ToInt32(this.txtBilletes200.Text), Convert.ToInt32(this.txtBilletes500.Text), Convert.ToInt32(this.txtBilletes1000.Text), Convert.ToInt32(this.txtBilletes2000.Text));

                this.lblMontoTotal.Text = Convert.ToString(t);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Validator Controls
        /// </summary>
        /// <returns></returns>
        private bool Validator()
        {
            bool resulta = true;
            int uno, cinco, diez, venticinco, cincuenta, cien, doscientos, quinientos, mil, dosmil;
            
            if (int.TryParse(this.txtMonedas1.Text, out uno))
            {
                this.errorProvider1.SetError(this.txtMonedas1, "Ingresar la cantidad de monedas de 1 peso");
                this.txtMonedas1.Focus();
                resulta = false;
            }
            
            if (int.TryParse(this.txtMonedas5.Text, out cinco))
            {
                this.errorProvider1.SetError(this.txtMonedas5, "Ingresar la cantidad de monedas de 5 pesos");
                this.txtMonedas5.Focus();
                resulta = false;
            }
            
            if (int.TryParse(this.txtMonedas10.Text, out diez))
            {
                this.errorProvider1.SetError(this.txtMonedas10, "Ingresar la cantidad de monedas de 10 pesos");
                this.txtMonedas10.Focus();
                resulta = false;
            }

            if (int.TryParse(this.txtMonedas25.Text, out venticinco))
            {
                this.errorProvider1.SetError(this.txtMonedas25, "Ingresar la cantidad de monedas de 25 pesos");
                this.txtMonedas25.Focus();
                resulta = false;
            }

            if (int.TryParse(this.txtBilletes50.Text, out cincuenta))
            {
                this.errorProvider1.SetError(this.txtBilletes50, "Ingresar la cantidad de billetes de 50 pesos");
                this.txtBilletes50.Focus();
                resulta = false;
            }

            if (int.TryParse(this.txtBilletes100.Text, out cien))
            {
                this.errorProvider1.SetError(this.txtBilletes100, "Ingresar la cantidad de billetes de 100 pesos");
                this.txtBilletes100.Focus();
                resulta = false;
            }

            if (int.TryParse(this.txtBilletes200.Text, out doscientos))
            {
                this.errorProvider1.SetError(this.txtBilletes200, "Ingresar la cantidad de billetes de 200 pesos");
                this.txtBilletes200.Focus();
                resulta = false;
            }

            if (int.TryParse(this.txtBilletes500.Text, out quinientos))
            {
                this.errorProvider1.SetError(this.txtBilletes500, "Ingresar la cantidad de billetes de 500 pesos");
                this.txtBilletes500.Focus();
                resulta = false;
            }

            if (int.TryParse(this.txtBilletes1000.Text, out mil))
            {
                this.errorProvider1.SetError(this.txtBilletes1000, "Ingresar la cantidad de billetes de 1000 pesos");
                this.txtBilletes1000.Focus();
                resulta = false;
            }

            if (int.TryParse(this.txtBilletes2000.Text, out dosmil))
            {
                this.errorProvider1.SetError(this.txtBilletes2000, "Ingresar la cantidad de billetes de 2000 pesos");
                this.txtBilletes2000.Focus();
                resulta = false;
            }

            return resulta;
        }

        /// <summary>
        /// Open Box for Casher
        /// </summary>
        private void OpenBox()
        {

            //this method need to valitate if box is open, in this case send a message that is open o close
            //

            try
            {
                if (opcaja == null)
                {
                    opcaja = new AperturaCajaEntity();

                    opcaja.Uno = Convert.ToInt32(this.txtMonedas1.Text);
                    opcaja.Cinco = Convert.ToInt32(this.txtMonedas5.Text);
                    opcaja.Diez = Convert.ToInt32(this.txtMonedas10.Text);
                    opcaja.Venticinco = Convert.ToInt32(this.txtMonedas25.Text);
                    opcaja.Cincuenta = Convert.ToInt32(this.txtBilletes50.Text);
                    opcaja.Cien = Convert.ToInt32(this.txtBilletes100.Text);
                    opcaja.Doscientos = Convert.ToInt32(this.txtBilletes200.Text);
                    opcaja.Quinientos = Convert.ToInt32(this.txtBilletes500.Text);
                    opcaja.Mil = Convert.ToInt32(this.txtBilletes1000.Text);
                    opcaja.Dosmil = Convert.ToInt32(this.txtBilletes2000.Text);
                    opcaja.Monto = Convert.ToDecimal(this.lblMontoTotal.Text);

                    AperturaCajaBO.CreateOpenBox(opcaja);     //
                    AperturaCajaBO.CreateHistoryOpenBox(opcaja); //
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            {
                this.txtMonedas1.Focus();
            }
            
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            CleanControls();
        }

        private void btnCalcularMonto_Click(object sender, EventArgs e)
        {
            if (Validate() == true)
            {
                CalculateAmount();
            }
            else if (Validate() == false)
            {
               MessageBox.Show("Debe Ingresar Valores Validos", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            var Answer = new DialogResult();

            try
            {
                Answer = MessageBox.Show("Esta Apunto de Aperturar la Caja, Seguro que quiere hacerlo", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Answer == DialogResult.Yes)
                {
                    if (Validate() == true)
                    {
                        //Missing function valide if current box was opened

                        OpenBox();
                        MessageBox.Show("Caja Abierta! Recuerde Cerrar la Caja al Finalizar las Labores", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CleanControls();
                        this.Close();
                    }
                    else if (Validate() != true)
                    {
                        MessageBox.Show("Debe Revisar los Valor Ingresados. Para poder Aperturar la Caja", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else if (Answer == DialogResult.No)
                {
                    this.txtMonedas1.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtMonedas1.Focus();
                
            }
            finally 
            {
                this.txtMonedas1.Focus();
            }
        }
    }
}
