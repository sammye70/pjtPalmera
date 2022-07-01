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
    public partial class frmProcesarCambios : Form
    {
        public frmProcesarCambios()
        {
            InitializeComponent();
        }

        private void DesableControls()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void CleanControls()
        { 
        }

        private void frmProcesarCambios_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            DesableControls();
        }
    }
}
