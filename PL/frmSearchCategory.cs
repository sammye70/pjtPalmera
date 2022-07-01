using pjPalmera.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    public partial class frmSearchCategory : Form
    {
        public frmSearchCategory()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  Set Properties in Controls
        /// </summary>
        public void InitializeControls()
        {
            this.lblCategoryFiltre.Text = "Categoria";
            this.dgvCategoria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //BackColor
            this.txtCriterio.BackColor = Color.Bisque;
            this.dgvCategoria.DefaultCellStyle.BackColor = Color.Bisque;

            //ForeColor
            this.txtCriterio.ForeColor = Color.Maroon;
            this.dgvCategoria.ForeColor = Color.Maroon;

            // DataSources
            this.dgvCategoria.DataSource = CategoriaBO.GetCategories();
        }

        /// <summary>
        /// Desables All Controls
        /// </summary>
        private void DesableControls()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.dgvCategoria.ReadOnly = true;
        }

        /// <summary>
        /// Clean Content in All Controls
        /// </summary>
        private void CleanControls()
        {
            this.txtCriterio.Text = "";
        }

        private void frmSearchCategory_Load(object sender, EventArgs e)
        {
            CleanControls();
            InitializeControls();
            DesableControls();
        }
    }
}
