using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjPalmera.PL
{
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {
            SetTool();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Set Details about Constrols
        /// </summary>
        private void SetTool()
        {
            toolTip1.SetToolTip(this.btnCancelar,"Cancela el ingreso al Sistema");
            toolTip1.SetToolTip(this.btnIniciar, "Ingreso al Sistema");
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
