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
    public partial class frmAddCiudad : Form
    {
       CiudadEntity ciudad = null;

        public frmAddCiudad()
        {
            InitializeComponent();
        }




        private void frmAddCiudad_Load(object sender, EventArgs e)
        {
            CleanControls();
            DesableControls();
            this.btnNuevo.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EnableControls();
            CleanControls();
            ciudad = null;
            this.txtNombreCiudad.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.txtNombreCiudad.Text != string.Empty)
            {
                try
                {
                    NewCiudad();
                    CleanControls();
                    DesableControls();
                    this.btnNuevo.Focus();
                    MessageBox.Show("Guardado Satisfactoriamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Mensaje:" + ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Ingresar un Nombre Valido", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtNombreCiudad.Focus();
            }
        }



        /// <summary>
        /// Save a New City
        /// </summary>
        private void NewCiudad()
        {
            if (ciudad == null)
            {
                ciudad = new CiudadEntity();

                ciudad.Nombre = this.txtNombreCiudad.Text;

                CiudadBO.Save(ciudad);

            }


        }

        /// <summary>
        /// Enable All Constrols
        /// </summary>
        private void EnableControls()
        {
            this.txtNombreCiudad.Enabled = true;
            this.btnGuardar.Enabled = true;
        }


        /// <summary>
        /// Desable all Controls
        /// </summary>
        private void DesableControls()
        {
            this.txtNombreCiudad.Enabled = false;
            this.btnGuardar.Enabled = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        /// <summary>
        /// Clean all Content in the Controls
        /// </summary>
        private void CleanControls()
        {
            this.txtNombreCiudad.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
