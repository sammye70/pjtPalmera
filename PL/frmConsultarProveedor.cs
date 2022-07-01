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
        
        long _code;

        public long Code
        {
            get { return _code; }
        }

        public frmConsultarProveedor()
        {
            InitializeComponent();
           
        }

        private void frmConsultarProveedor_Load(object sender, EventArgs e)
        {
            this.dgvContProveedor.DataSource = ProveedorBO.GetAllProveedor();
            this.HideFielsData();
            CleanControls();
            DesableControls();
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
        /// EnableAllControls from ConsultarProveedor
        /// </summary>
        public void EnableControls()
        {
            this.btnEditar.Visible = true;
            this.btnEliminar.Visible = true;
            this.btnRefresh.Visible = true;
        }


        /// <summary>
        /// Desable Controls in this form
        /// </summary>
        private void DesableControls()
        {
            this.dgvContProveedor.ReadOnly = true;
        }

        /// <summary>
        /// Hide Fields to display in Datagrid
        /// </summary>
        private void HideFielsData()
        {
            this.dgvContProveedor.Columns["Created"].Visible = false;
            this.dgvContProveedor.Columns["Createby"].Visible = false;

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
        /// Edit Proveedor
        /// </summary>
        public void EditProveedor()
        {
            frmRegProveedor fproveedor = new frmRegProveedor();
            try
            {
                DataGridViewRow x = this.dgvContProveedor.CurrentRow;
                _code = Convert.ToInt32(this.dgvContProveedor.Rows[x.Index].Cells["idproveedor"].Value);

               

                fproveedor.Show();
                fproveedor.Text = "Actualizar Información del Proveedor";
                fproveedor.EnableControls();
                fproveedor.IniControls();

                Proveedor = ProveedorBO.SrProviderCode(this.Code);

                fproveedor.txtIdProveedor.Text = Convert.ToString(Proveedor.Idproveedor);
                fproveedor.txtRnc.Text = Convert.ToString(Proveedor.Rnc);
                fproveedor.txtNomProveedor.Text = Proveedor.Nombre_proveedor;
                fproveedor.txtDirProveedor.Text = Proveedor.Direccion_prob;
                fproveedor.mktLimiteCredito.Text = Convert.ToString(Proveedor.Limitecredito);
                fproveedor.txtNomRepresentante.Text = Proveedor.Nombre_contacto;
                fproveedor.mktTelefRepresentante.Text = Proveedor.Tel_contacto;
                fproveedor.mktTelefono.Text = Proveedor.Tel_proveedor;    
            }

            catch (Exception ex)
            {
                Proveedor = null;
                MessageBox.Show(ex.Message,"Mensaje del Sistema");
                return;
            }
        }


       


        /// <summary>
        /// Filter proveedor by rnc
        /// </summary>
        private void FilterByRnc()
        {
            try
            {
        //        if (this.txtCriterioBuscar.Text != string.Empty)
         //       {
                    Proveedor.Rnc =Convert.ToInt64(this.txtCriterioBuscar.Text);
                    this.dgvContProveedor.DataSource = ProveedorBO.FilterByRnc(Proveedor.Rnc);
                    this.HideFielsData();
         //       }
           //    else
          //      {
           //         this.dgvContProveedor.DataSource = null;
           //         this.dgvContProveedor.DataSource = ProveedorBO.GetAllProveedor();
          //      }
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
           //     if (this.txtCriterioBuscar.Text != string.Empty)
         //       {
                    var provider = new ProveedorEntity();
                    provider.Nombre_proveedor = this.txtCriterioBuscar.Text;
                    this.dgvContProveedor.DataSource = ProveedorBO.SearchByName(provider);
                    this.HideFielsData();
            
                 //   this.dgvContProveedor.DataSource = null;
                 //   this.dgvContProveedor.DataSource = ProveedorBO.GetAllProveedor();
              //  }     
            }
            catch
            {

            }
        }

        /// <summary>
        /// Remove Proveedor by Code
        /// </summary>
        private void RemoveProveedor()
        {
            try
            {
                DataGridViewRow x = this.dgvContProveedor.CurrentRow;
                _code = Convert.ToInt32(this.dgvContProveedor.Rows[x.Index].Cells["idproveedor"].Value);

                ProveedorBO.RemoveProveedor(this.Code);
                this.dgvContProveedor.DataSource = ProveedorBO.GetAllProveedor();
                this.HideFielsData();
            }
            catch (Exception)
            {

             //   MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Question = new DialogResult();

            Question=MessageBox.Show("Seguro que desea eliminar definitivamente el proveedor", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Question == DialogResult.Yes)
            {
                RemoveProveedor();
             //   MessageBox.Show("Se elimino el proveedor", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgvContProveedor.DataSource = null;
                this.dgvContProveedor.DataSource = ProveedorBO.GetAllProveedor();
                this.HideFielsData();
                return;
            }
            else if (Question == DialogResult.No)
            {
                this.dgvContProveedor.DataSource = null;
                this.dgvContProveedor.DataSource = ProveedorBO.GetAllProveedor();
                this.HideFielsData();
                return;
            }

        }

        private void txtCriterioBuscar_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if ((this.rbRnc.Checked == true) && (this.txtCriterioBuscar.Text != string.Empty))
                {
                    this.FilterByRnc();
                }
                else if ((this.rbNomEmpresa.Checked == true) && (this.txtCriterioBuscar.Text != string.Empty))
                {
                    this.FilterByName();
                }
                else
                {
                    this.dgvContProveedor.DataSource = null;
                    this.dgvContProveedor.DataSource = ProveedorBO.GetAllProveedor();
                    this.HideFielsData();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditProveedor();
        }

        private void frmConsultarProveedor_Activated(object sender, EventArgs e)
        {
            DialogResult Result = new DialogResult();

            if (Result == DialogResult.OK)
            {
                this.dgvContProveedor.DataSource = null;
                this.dgvContProveedor.DataSource=ProveedorBO.GetAllProveedor();
                this.HideFielsData();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.dgvContProveedor.DataSource = null;
            this.dgvContProveedor.DataSource = ProveedorBO.GetAllProveedor();
            this.HideFielsData();
            return;
        }


    }
}
