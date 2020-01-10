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

                categoria.Category = this.txtNombreFamilia.Text;

                CategoriaBO.Save(categoria);

            }
        }


        /// <summary>
        /// 
        /// </summary>
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
    }
}
