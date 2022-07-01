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
    public partial class frmCategoria : Form

    {
        CategoriaEntity categoria = null;

        public frmCategoria()
        {
            InitializeComponent();
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            CleanControls();
            DesableControls();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            categoria = null;
            EnableControls();
            this.txtNombreFamilia.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var name = this.txtNombreFamilia.Text;
            
            if (name == string.Empty)
            {
                MessageBox.Show("Por favor introducir una categoría Válida", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNombreFamilia.Focus();
            }
            else
            {
                var verify = CategoriaBO.ExitsCategory(name);

                if (verify == false)
                {
                    var message = new DialogResult();

                    message = MessageBox.Show("Esta a punto de crear una nueva categoría. Seguro desea continuar?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (message == DialogResult.Yes)
                    {
                        try
                        {
                            NewCategory();
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
                    else if (message == DialogResult.No)
                    {
                        this.txtNombreFamilia.Focus();
                        return;
                    }
                }
                else if (verify == true)
                {
                    MessageBox.Show(CategoriaBO.strMensajeBO, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtNombreFamilia.Focus();
                }
            }

        }


        /// <summary>
        /// Enable all controls
        /// </summary>
        private void EnableControls()
        {

            this.txtNombreFamilia.Enabled = true;
            this.btnGuardar.Enabled = true;
        }

        /// <summary>
        /// Desable all Controls
        /// </summary>
        private void DesableControls()
        {
            this.txtNombreFamilia.Enabled = false;
            this.btnGuardar.Enabled = false;
        }

        /// <summary>
        /// Clean All Controls
        /// </summary>
        private void CleanControls()
        {
            this.txtNombreFamilia.Text = "";
        }

        /// <summary>
        /// New Category
        /// </summary>
        private void NewCategory()
        {
            if (categoria == null)
            {
                categoria = new CategoriaEntity();

                categoria.Categoria = this.txtNombreFamilia.Text;

                CategoriaBO.Save(categoria);

            }
        }


        ///// <summary>
        ///// 
        ///// </summary>
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CleanControls();
            this.txtNombreFamilia.Focus();
        }
    }
}
