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

        public frmRegProveedor()
        {
            InitializeComponent();
        }


        private void frmRegProveedor_Load(object sender, EventArgs e)
        {
            SetTooltipControls();
            CleanControls();
            DesableControls();
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
            this.mktTelefono.Text = "";
            this.mktTelefRepresentante.Text = "";
            this.cmbCredito.Text = "";
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
           // this.btnCancelar.Enabled = false;
        }

        /// <summary>
        /// Enable all Controls
        /// </summary>
        private void EnableControls()
        {
            this.txtRnc.Enabled = true;
            this.txtDirProveedor.Enabled = true;
            this.txtNomProveedor.Enabled = true;
            this.mktTelefRepresentante.Enabled = true;
            this.txtNomRepresentante.Enabled = true;
            this.mktLimiteCredito.Enabled = true;
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
            toolTip1.SetToolTip(btnNuevo, "Nuevo Registro");
            toolTip1.SetToolTip(btnGuardar, "Guardar Registro");
            toolTip1.SetToolTip(btnCancelar, "Limpiar Campos");
        }

        /// <summary>
        /// Create new Proveedor
        /// </summary>
        private void NewProveedor()
        {
            if (proveedor == null)
            {
                proveedor = new ProveedorEntity();

                proveedor.Rnc = this.txtRnc.Text;
                proveedor.Nombre_proveedor = this.txtNomProveedor.Text;
                proveedor.Nombre_contacto = this.txtNomRepresentante.Text;
                proveedor.Tel_contacto = this.mktTelefRepresentante.Text;
                proveedor.Direccion_fab = this.txtDirProveedor.Text;
                proveedor.Limitecredito =Convert.ToDecimal (this.mktLimiteCredito.Text);
                proveedor.Tel_proveedor = this.mktTelefono.Text;

                ProveedorBO.Save(proveedor);
            }

        }
    }
            
}
