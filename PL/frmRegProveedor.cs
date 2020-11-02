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
    public partial class frmRegProveedor : Form
    {
        ProveedorEntity proveedor = null;
        frmConsultarProveedor cProveedor = new frmConsultarProveedor();

        public frmRegProveedor()
        {
            InitializeComponent();
        }


        private void frmRegProveedor_Load(object sender, EventArgs e)
        {
            SetTooltipControls();
            CleanControls();
            DesableControls();
            InizatationControls();
            this.btnNuevo.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                NewProveedor();
                CleanControls();
                DesableControls();
                MessageBox.Show("Guardado Satisfactoriamente","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje:"+ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            proveedor = null;
            EnableControls();
            this.txtRnc.Focus();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CleanControls();
            this.Close();
        }


        /// <summary>
        /// Hide Controls from EditProveedor
        /// </summary>
        public void IniControls()
        {
            this.btnNuevo.Visible = false;
            this.btnGuardar.Visible = false;
            this.btnUpdate.Visible = true;
        }


        /// <summary>
        /// Clean Content in the Controls
        /// </summary>
        private void CleanControls()
        {
            this.txtRnc.Text = "";
            this.txtDirProveedor.Text = "";
            this.txtNomProveedor.Text = "";
            this.mktTelefRepresentante.Text = "";
            this.txtNomRepresentante.Text = "";
            this.mktLimiteCredito.Text = "";
            this.mktTelefono.Mask = "###-###-####";
            this.mktTelefRepresentante.Mask = "###-###-####";
            this.mktTelefRepresentante.Text = "";
            this.mktTelefono.Text = "";
            this.cmbCredito.Text = "";
        }

        /// <summary>
        /// 
        /// </summary>
        private void InizatationControls()
        {

            //Mask
            this.mktTelefono.Mask = "###-###-####";
            this.mktTelefRepresentante.Mask = "###-###-####";

            //BackColor
            this.txtDirProveedor.BackColor = Color.Bisque;
            this.txtNomProveedor.BackColor = Color.Bisque;
            this.txtNomRepresentante.BackColor = Color.Bisque;
            this.cmbCredito.BackColor = Color.Bisque;
            this.mktLimiteCredito.BackColor = Color.Bisque;
            this.mktTelefono.BackColor = Color.Bisque;
            this.mktTelefRepresentante.BackColor = Color.Bisque;
            this.txtRnc.BackColor = Color.Bisque;

            //ForeColor
            this.txtDirProveedor.ForeColor = Color.Maroon;
            this.txtNomProveedor.ForeColor = Color.Maroon;
            this.txtNomRepresentante.ForeColor = Color.Maroon;
            this.cmbCredito.ForeColor = Color.Maroon;
            this.mktLimiteCredito.ForeColor = Color.Maroon;
            this.mktTelefono.ForeColor = Color.Maroon;
            this.mktTelefRepresentante.ForeColor = Color.Maroon;
            this.txtRnc.ForeColor = Color.Maroon;


        }

        /// <summary>
        /// Desable Controls
        /// </summary>
        private void DesableControls()
        {
            this.txtRnc.Enabled = false;
            this.txtDirProveedor.Enabled = false;
            this.txtNomProveedor.Enabled = false;
            this.mktTelefRepresentante.Enabled = false;
            this.txtNomRepresentante.Enabled = false;
            this.mktLimiteCredito.Enabled = false;
            this.mktTelefono.Enabled = false;
            this.mktTelefRepresentante.Enabled = false;
            this.cmbCredito.Enabled = false;
            this.btnGuardar.Enabled = false;
            this.btnUpdate.Visible = false;
           // this.btnCancelar.Enabled = false;
        }

        /// <summary>
        /// Enable all Controls
        /// </summary>
        public void EnableControls()
        {
            this.txtRnc.Enabled = true;
            this.txtDirProveedor.Enabled = true;
            this.txtNomProveedor.Enabled = true;
            this.mktTelefRepresentante.Enabled = true;
            this.txtNomRepresentante.Enabled = true;
            //this.mktLimiteCredito.Enabled = true;
            this.mktTelefono.Enabled = true;
            this.mktTelefRepresentante.Enabled = true;
            this.cmbCredito.Enabled = true;
            this.btnGuardar.Enabled = true;
          //  this.btnCancelar.Enabled = true;
        }

        /// <summary>
        /// Set Detail About Control
        /// </summary>
        private void SetTooltipControls()
        {
            this.toolTip1.SetToolTip(this.btnNuevo, "Nuevo Registro");
            this.toolTip1.SetToolTip(this.btnGuardar, "Guardar Registro");
            // this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar el Proceso de Registro del Nuevo Proveedor");
            this.toolTip1.SetToolTip(this.btnUpdate,"Actualizar Registro");
        }

        /// <summary>
        /// Create new Proveedor
        /// </summary>
        private void NewProveedor()
        {
            var number = this.txtRnc.Text;

            if (number == string.Empty)
            {
                MessageBox.Show("Indicar información Válida", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var verify = ProveedorBO.ProveedorExits(number);

                if (verify == false)
                {
                    try
                    {
                        //if (!validator())
                        //    return;

                        var proveedor = new ProveedorEntity();

                        if (proveedor == null)
                        {
                            proveedor.Rnc = Convert.ToInt64(this.txtRnc.Text);
                            proveedor.Nombre_proveedor = this.txtNomProveedor.Text;
                            proveedor.Nombre_contacto = this.txtNomRepresentante.Text;
                            proveedor.Tel_contacto = this.mktTelefRepresentante.Text;
                            proveedor.Direccion_prob = this.txtDirProveedor.Text;

                            if (this.cmbCredito.Text == "No")
                            {
                                this.mktLimiteCredito.Text = "0";
                            }

                            proveedor.Limitecredito = Convert.ToDecimal(this.mktLimiteCredito.Text);
                            proveedor.Tel_proveedor = this.mktTelefono.Text;

                            ProveedorBO.Save(proveedor);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        MessageBox.Show("Verificar la informaciones suminstradas he intentar nuevamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.txtRnc.Focus();
                    }
                }
                else if (verify == true)
                {
                    MessageBox.Show(ProveedorBO.strMessage, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtRnc.Focus();
                }

            }

        }

        /// <summary>
        /// Validator Content inside the Controls
        /// </summary>
        /// <returns></returns>
        private bool validator()
        {
            bool result = true;

            if (this.txtRnc.Text == string.Empty)
            {
                MessageBox.Show("Introducir el RNC del Proveedor", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtRnc.Focus();
                return result = false;
            }
            else if (this.txtNomProveedor.Text == string.Empty)
            {
                MessageBox.Show("Indicar el Nombre de la Empresa", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            else if (this.txtDirProveedor.Text == string.Empty)
            {
                MessageBox.Show("Introducir la Dirección del Proveedor", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }

            return result;
        }

        /// <summary>
        /// Update Proveedor Information
        /// </summary>
        private void UpdateProveedor()
        {
            try
            {
                proveedor = new ProveedorEntity();

                proveedor.Idproveedor = Convert.ToInt32(this.txtIdProveedor.Text);
                proveedor.Rnc = Convert.ToInt64(this.txtRnc.Text);
                proveedor.Nombre_proveedor = this.txtNomProveedor.Text;
                proveedor.Nombre_contacto = this.txtNomRepresentante.Text;
                proveedor.Tel_contacto = this.mktTelefRepresentante.Text;
                proveedor.Direccion_prob = this.txtDirProveedor.Text;
                proveedor.Limitecredito = Convert.ToDecimal(this.mktLimiteCredito.Text);
                proveedor.Tel_proveedor = this.mktTelefono.Text;

                ProveedorBO.Update(proveedor);

                MessageBox.Show("Actualizado Satisfactoriamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           

        }

        private void cmbCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbCredito.Text == "Si")
            {
                this.mktLimiteCredito.Enabled = true;
                this.mktLimiteCredito.Focus();
            }

            if (this.cmbCredito.Text == "No")
            {
                this.mktLimiteCredito.Enabled = false;
                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var number = this.txtRnc.Text;

            if (number == string.Empty)
            {
                MessageBox.Show("Indicar información válida.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtRnc.Focus();
            }
            else
            {
                var verify = ProveedorBO.ProveedorExits(number);

                if (verify == false)
                {
                    var Question = new DialogResult();

                    Question = MessageBox.Show("Seguro desea Guardar los Cambios Realizados", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (Question == DialogResult.Yes)
                    {
                        UpdateProveedor();
                        cProveedor.dgvContProveedor.DataSource = null;
                        cProveedor.dgvContProveedor.DataSource = ProveedorBO.GetAllProveedor();
                    }
                    else if (Question == DialogResult.No)
                    {
                        this.Close();
                        cProveedor.dgvContProveedor.DataSource = null;
                        cProveedor.dgvContProveedor.DataSource = ProveedorBO.GetAllProveedor();
                        return;
                    }
                }
                else if (verify == true)
                {
                    MessageBox.Show(ProveedorBO.strMessage, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtRnc.Focus();
                }
            }

            
            
        }
    }
            
}
