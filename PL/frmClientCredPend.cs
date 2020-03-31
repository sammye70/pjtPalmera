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
    public partial class frmClientCredPend : Form
    {
        
        public frmClientCredPend()
        {
            InitializeComponent();
        }

        long _id;

        public long Id
        {
            get { return _id; }
        }

        /// <summary>
        /// Set Initial Controls Values
        /// </summary>
        private void DesableControls()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.dgvCuentasPendClient.ReadOnly = true;
        }

        private void GetAccounts()
        {
            var account = 1;
            this.dgvCuentasPendClient.DataSource = CuentasBO.GetAllAccount(account);
        }

        private void frmClientCredPend_Load(object sender, EventArgs e)
        {
            DesableControls();
            GetAccounts();

            
        }

        private void dgvCuentasPendClient_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            _id = Convert.ToInt64(this.dgvCuentasPendClient.Rows[e.RowIndex].Cells["id"].Value);
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
