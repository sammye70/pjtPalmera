using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;
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
            DetailControls();
            InitialControls();
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
            var name = this.txtNombreCiudad.Text;

            if (name == string.Empty)
            {
                MessageBox.Show("Ingresar un Nombre Válido", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtNombreCiudad.Focus();
            }
            else
            {
                var verify = CiudadBO.CiudadExits(name);

                if (verify == false)
                {
                    bool error = false;
                    var message = new DialogResult();

                    message = MessageBox.Show("Se dispone a Guardar el nombre de la ciudad" + "'" + name + "'." + " Seguro desea hacerlo?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (message == DialogResult.Yes)
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
                            error = true;
                        }
                        finally
                        {
                            if (error == true)
                            {
                                MessageBox.Show("Indicar información válida.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.txtNombreCiudad.Focus();
                            }
                        }

                    }
                    else if (message == DialogResult.No)
                    {
                        this.txtNombreCiudad.Focus();
                        return;
                    }
                }
                else if (verify == true)
                {
                    MessageBox.Show(CiudadBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtNombreCiudad.Focus();
                }
            }

                
        }

        /// <summary>
        /// Set Initial Controls
        /// </summary>
        private void InitialControls()
        {
            //Backcolor
            this.txtNombreCiudad.BackColor = Color.Bisque;

            //Fonts Color
            this.txtNombreCiudad.ForeColor = Color.Maroon;
        }

        /// <summary>
        /// Describe All Controls
        /// </summary>
        private void DetailControls()
        {
            this.toolTip1.SetToolTip(this.btnNuevo, "Permite preparar para Crear un nuevo Registro");
            this.toolTip1.SetToolTip(this.btnGuardar, "Salva el Nombre indicado de la Ciudad");
            this.toolTip1.SetToolTip(this.txtNombreCiudad, "Aquí se indica el Nombre de la Ciudad que desea Guardar");
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
