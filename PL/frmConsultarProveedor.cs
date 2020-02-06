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
    public partial class frmConsultarProveedor : Form
    {
        ProveedorEntity Proveedor = new ProveedorEntity();

        public frmConsultarProveedor()
        {
            InitializeComponent();
            DesableControls();
        }

        private void frmConsultarProveedor_Load(object sender, EventArgs e)
        {
            this.dgvContProveedor.DataSource = ProveedorBO.GetAllProveedor();
            CleanControls();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CleanControls();
            this.txtCriterioBuscar.Focus();
        }


        private void txtCriterioBuscar_TextChanged(object sender, EventArgs e)
        {

            if (this.rbRnc.Checked == true)
            {
                FiltterByRnc();
            }

            if (this.rbNomEmpresa.Checked == true)
            {
                FilterByName();
            }

        }


        private void rbRnc_CheckedChanged(object sender, EventArgs e)
        {
            CleanControls();
            this.lblCriterioBuscar.Text = "RNC";
            this.txtCriterioBuscar.Focus();
        }

        private void rbNomEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            CleanControls();
            this.lblCriterioBuscar.Text = "Proveedor";
            this.txtCriterioBuscar.Focus();
        }



        /// <summary>
        /// Desable Controls in this form
        /// </summary>
        private void DesableControls()
        {
            this.dgvContProveedor.ReadOnly = true;
        }

        /// <summary>
        /// Clean Content in Controls
        /// </summary>
        private void CleanControls()
        {
            this.txtCriterioBuscar.Text = "";
            this.lblCriterioBuscar.Text = "";
        }


        /// <summary>
        /// Filter proveedor by rnc
        /// </summary>
        private void FiltterByRnc()
        {
            try
            {
                if (this.txtCriterioBuscar.Text != string.Empty)
                {
                    Proveedor.Rnc = this.txtCriterioBuscar.Text;
                    this.dgvContProveedor.DataSource = ProveedorBO.SearhByrnc(Proveedor.Rnc);
                }
                else
                {
                    this.dgvContProveedor.DataSource = null;
                    this.dgvContProveedor.DataSource = ProveedorBO.GetAllProveedor();
                }
            }
            catch 
            {
            }
        }

        /// <summary>
        /// Filter proveedor by Name
        /// </summary>
        private void FilterByName()
        {
            try
            {
                if (this.txtCriterioBuscar.Text != string.Empty)
                {
                    Proveedor.Nombre_proveedor = this.txtCriterioBuscar.Text;
                    this.dgvContProveedor.DataSource = ProveedorBO.SearchByName(Proveedor.Nombre_proveedor);
                }
                else
                {
                    this.dgvContProveedor.DataSource = null;
                    this.dgvContProveedor.DataSource = ProveedorBO.GetAllProveedor();
                }
            }
            catch
            {

            }
        }

    }
}
