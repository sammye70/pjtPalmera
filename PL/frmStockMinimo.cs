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
            this.EnebFieldsDetailGrid();
        }

        /// <summary>
        ///  Hide Fields to display in datagridview
        /// </summary>
        private void  EnebFieldsDetailGrid()
        {
            this.dgvStockMinimo.Columns["Orden"].Visible = false;
            this.dgvStockMinimo.Columns["Costo"].Visible = false;
            this.dgvStockMinimo.Columns["Precio_venta"].Visible = false;
            this.dgvStockMinimo.Columns["Creado_por"].Visible = false;
            this.dgvStockMinimo.Columns["Creado"].Visible = false;
            this.dgvStockMinimo.Columns["Estado"].Visible = false;
            this.dgvStockMinimo.Columns["Stockminimo"].Visible = false;
        }

    }
}
