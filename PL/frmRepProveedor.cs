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
    public partial class frmRepProveedor : Form
    {
        public frmRepProveedor()
        {
            InitializeComponent();
        }

        private void frmRepProveedor_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
