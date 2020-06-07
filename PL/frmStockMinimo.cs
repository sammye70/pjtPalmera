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
    public partial class frmStockMinimo : Form
    {
        public frmStockMinimo()
        {
            InitializeComponent();
        }

        private void frmStockMinimo_Load(object sender, EventArgs e)
        {
            
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            this.dgvStockMinimo.ReadOnly = true;
            this.dgvStockMinimo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvStockMinimo.DataSource = ProductosBO.StockMinimo();
        }
    }
}
