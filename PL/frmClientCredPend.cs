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

        /// <summary>
        ///  Set Id Customer in Method inside of frmClientCredPend
        /// </summary>
        long _id;

        /// <summary>
        /// Getting Customer Id from Selected one inside Gridview that has pedding amount 
        /// </summary>
        public long Id
        {
            get { return _id; }
        }

        /// <summary>
        /// Set Initial Controls Values
        /// </summary>
        private void DisableControls()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.dgvCuentasPendClient.ReadOnly = true;
            dgvCuentasPendClient.Columns["Ultimo_Pago"].Visible = false;
            dgvCuentasPendClient.Columns["Pago"].Visible = false;
            dgvCuentasPendClient.Columns["Monto"].Visible = false;
        }

        /// <summary>
        ///  Get All Credit Account Pendding
        /// </summary>
        private void GetAccounts()
        {
            this.dgvCuentasPendClient.DataSource = CreditAccountBO.GetAllAccount();
        }


        private void frmClientCredPend_Load(object sender, EventArgs e)
        {
            GetAccounts();
            DisableControls();
        }

        private void dgvCuentasPendClient_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            _id = Convert.ToInt64(this.dgvCuentasPendClient.Rows[e.RowIndex].Cells["Id_Cliente"].Value);
            DialogResult = DialogResult.OK;
            this.Close();
        }


    }
}
