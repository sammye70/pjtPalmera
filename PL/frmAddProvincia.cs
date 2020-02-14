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
    public partial class frmAddProvincia : Form
    {
        ProvinciaEntity provincia = null;

        public frmAddProvincia()
        {
            InitializeComponent();
        }

        private void frmAddProvincia_Load(object sender, EventArgs e)
        {
            CleanControls();
            DesableControls();
            this.btnNuevo.Focus();
        }

        /// <summary>
        /// Not Allow close the form
        /// </summary>
        //private const int CP_NOCLOSE_BUTTON = 0x200;
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams myCp = base.CreateParams;
        //        myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
        //        return myCp;
        //    }
        //}

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.txtNomProvincia.Text != string.Empty)
            {
                try
                {
                    Newprovincia();
                    CleanControls();
                    DesableControls();
                    MessageBox.Show("Guardado Satisfactoriamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.btnNuevo.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un Nombre Valido", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtNomProvincia.Focus();
            }

        }


        /// <summary>
        /// New Province
        /// </summary>
        private void Newprovincia()
        {
            if (provincia == null)
            {
                provincia = new ProvinciaEntity();

                provincia.Nombre = this.txtNomProvincia.Text;

                ProvinciaBO.Save(provincia);
            }

        }
        
        /// <summary>
        /// Clean Content the All Controls
        /// </summary>
        private void CleanControls()
        {
            this.txtNomProvincia.Text = "";
        }

        /// <summary>
        /// Desable All Controls
        /// </summary>
        private void DesableControls()
        {
            this.txtNomProvincia.Enabled = false;
            this.btnGuardar.Enabled = false;
        }

        /// <summary>
        /// Enable All Controls
        /// </summary>
        private void EnableControls()
        {
            this.txtNomProvincia.Enabled = true;
            this.btnGuardar.Enabled = true;
        }

        /// <summary>
        /// Set Detail About Control
        /// </summary>
        private void SetTooltipControls()
        {
            toolTip1.SetToolTip(btnNuevo, "Nuevo Registro");
            toolTip1.SetToolTip(btnGuardar, "Guardar Registro");
          //  toolTip1.SetToolTip(btnCancelar, "Limpiar Campos");
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            provincia = null;
            EnableControls();
            this.txtNomProvincia.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CleanControls();
        }
    }
}
