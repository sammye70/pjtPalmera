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
    public partial class frmConsultFactAnuladas : Form
    {
        public frmConsultFactAnuladas()
        {
            InitializeComponent();
        }

        private void btnGenerarConsulta_Click(object sender, EventArgs e)
        {

            GetInvoicesDesable();
        }


        /// <summary>
        /// Load All Invoices Desables
        /// </summary>
        private void GetInvoicesDesable()
        {
            this.dgvFactAnuladas.DataSource = FacturaBO.Get_All_Invoice_Desable();

            if (this.dgvFactAnuladas.RowCount < 1)
            {
                MessageBox.Show("No hay Datos que Mostrar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Desable All Controls
        /// </summary>
        private void DesableControl()
        {
            this.dgvFactAnuladas.ReadOnly = true;
        }


        private void frmConsultFactAnuladas_Load(object sender, EventArgs e)
        {
            DesableControl();
        }
    }
}
