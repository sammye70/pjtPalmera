using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using pjPalmera.BLL;

namespace pjPalmera.PL
{
    public partial class frmRepClientes : Form
    {
        public frmRepClientes()
        {
            InitializeComponent();
        }

        private void frmRepClientes_Load(object sender, EventArgs e)
        {

            this.reportViewer1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportDataSource fuente;
            fuente = new ReportDataSource("clientes");

        }
    }
}
