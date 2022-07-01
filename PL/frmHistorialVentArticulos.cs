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
    public partial class frmHistorialVentArticulos : Form
    {
        public frmHistorialVentArticulos()
        {
            InitializeComponent();
        }

        private void frmHistorialVentArticulos_Load(object sender, EventArgs e)
        {
            InitialControls();
        }

        private void btnGenerarConsulta_Click(object sender, EventArgs e)
        {
            GetAllProductInvoices();
        }


        private void InitialControls()
        {
            this.dgvHistoryArtVend.ReadOnly = true;
            this.dgvHistoryArtVend.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvHistoryArtVend.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        /// <summary>
        /// 
        /// </summary>
        private void GetAllProductInvoices()
        {
            this.dgvHistoryArtVend.DataSource = FacturaBO.GetAllProducInvoices();
        }
        
    }
}
