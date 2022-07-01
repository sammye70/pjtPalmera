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
    public partial class frmAutorizar : Form
    {
        public frmAutorizar()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Verify it controls has string inside
        /// </summary>
        private bool Verify()
        {
            bool result = true;

            if((this.txtCode.Text == string.Empty) || (this.txtCode.Text == null))
            {
                this.errorProvider1.SetError(this.txtCode, "Indicar un Código Válido");
                this.txtCode.Focus();
                result = false;
            }
            return result;
        }

        /// <summary>
        ///  Set All Descriptions about controls
        /// </summary>
        private void SetDetails()
        {
            this.toolTip1.SetToolTip(this.btnProcess, "Procesar la Autorización");
            this.toolTip1.SetToolTip(this.txtCode, "Código para poder validar los permisos");
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                var ventas = new frmVenta();
                var venta = new VentaCrEntity();
                var user = new UsuariosEntity();
                var pass = user.setHash(this.txtCode.Text);

                user.Id_user = int.Parse(this.txtUserId.Text);
                user.User_name = this.txtUserName.Text;
                user.Password = pass;
                user.LongName = this.txtLongName.Text;
                var type = Int32.Parse(venta.Set_Type_invoice(FacturaBO.eType_invoices.credit.ToString())); // Get type invoice and convert to int value
                venta.tipo = type.ToString();
                ventas.txtTypeInvoice.Text = venta.tipo;
                ventas.lblCajeroName.Text = user.LongName.ToString();
                ventas.txtUserId.Text = user.Id_user.ToString();


                if (Verify() != true)
                    return;
                
                var status = UsuariosBO.GetStatusUser(user.User_name);
                if (status == true)
                {
                    var value = UsuariosBO.Login_User(user);
                    switch (value)
                    {
                        case true:
                            UsuariosBO.getVisibleControls(user);
                            var rol = UsuariosBO.result;

                            if ((rol == "2") || (rol == "4"))
                            {
                                ventas.Text = "Ventas a Crédito";
                                ventas.DesVisibleCtrlInvCash();
                                ventas.EnVisibleCtrlInvCr();
                                ventas.btnNewInvoiceCr.Focus();
                                this.Close();
                                ventas.ShowDialog(this);
                            }
                            else
                            {
                                MessageBox.Show("No tiene permisos para realizar la operación.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                if (DialogResult == DialogResult.OK)
                                {
                                    this.Close();
                                }
                            }

                            break;

                        case false:
                            MessageBox.Show("El código indicado no es válido. \n Verificar e intentar nuevamente.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.txtCode.Focus();
                            break;
                    }
                }
                else 
                {
                    MessageBox.Show("El código indicado expiro. \n Verificar e intentar nuevamente.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.txtCode.Focus();
                    return;
                } 
            }
            catch(Exception ex)
            {
                    MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    

        private void frmAutorizar_Load(object sender, EventArgs e)
        {
            this.SetDetails();

        }


        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                this.btnProcess.Focus();
            }
            
        }
    }
}
