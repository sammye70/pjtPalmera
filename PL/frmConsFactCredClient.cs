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
    public partial class frmConsFactCredClient : Form
    {
       
        public frmConsFactCredClient()
        {
            InitializeComponent();
        }

        //private long _id;

        //public long Id
        //{
        //    get { return _id; }
        //}


        /// <summary>
        /// Load Credit Invoices by Current Client
        /// </summary>
        private void LoadInvoicesCr()
        {
            try
            {
                frmEfectPagosFactCred fPago = new frmEfectPagosFactCred();

                int _id = Convert.ToInt32(fPago.txtIdClient.Text);
                // this.dgvFacCrByClient.DataSource = CuentasBO.GetInvoicesCr(_id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmConsFactCredClient_Load(object sender, EventArgs e)
        {
            LoadInvoicesCr();
        }
    }
}
