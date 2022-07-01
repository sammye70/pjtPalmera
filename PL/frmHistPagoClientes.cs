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
    public partial class frmHistPagoClientesCr : Form
    {

        public frmHistPagoClientesCr()
        {
            InitializeComponent();
        }

        private void rbId_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbId.Checked == true)
            {
                this.lblCriterial.Text = "Id";
                this.txtCriterial.Text = "";
                this.txtCriterial.Focus();
            }
        }

        private void rbCedula_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbCedula.Checked == true)
            {
                this.lblCriterial.Text = "Cédula";
                this.txtCriterial.Text = "";
                this.txtCriterial.Focus();
            }
        }

        private void frmHistPagoClientesCr_Load(object sender, EventArgs e)
        {
            
            //this.dgvHistPagosClientCr.DataSource = CreditAccountBO.GetAllAccount();   // ------> Needs to modicate this query for Table History pay
            this.txtCriterial.Focus();
            this.lblCriterial.Text = "Código del Cliente";
            this.rbCedula.Visible = false;
            this.rbId.Visible = false;
            this.dgvHistPagosClientCr.ReadOnly = true;
            
            Clean();
        }

        /// <summary>
        /// Clean content inside all Controls
        /// </summary>
        private void Clean()
        {
            this.txtCriterial.Text = "";
           // this.lblCriterial.Text = "";
        }
         
        /// <summary>
        ///  Set data name in datagrid
        /// </summary>
        public void setDetailsData()
        {
            this.dgvHistPagosClientCr.Columns["Id_cliente"].HeaderText = "Código Cliente";
        }

        /// <summary>
        ///  Get Credit Accounts by id or id card
        /// </summary>
        private void Filter()
        {
            var val = this.txtCriterial.Text;
            var query = int.Parse(this.txtTypeQuery.Text);

            if (string.IsNullOrEmpty(val) != false)
                return;

            switch (query)
            {
                case 1:
                    this.dgvHistPagosClientCr.DataSource = CreditAccountBO.GetPayCrAcCustomerById(int.Parse(val));
                    this.typeQuery(query);
                    break;

                case 2:
                    this.dgvHistPagosClientCr.DataSource = CreditAccountBO.GetPayCrAcCustomerByIdEx(int.Parse(val));
                    this.typeQuery(query);
                    break;
            }
        }


        /// <summary>
        /// Get type of Query for History
        /// </summary>
        private void typeQuery(int type)
        {
            switch (type)
            {
                case 1:
                    this.dgvHistPagosClientCr.Columns["Monto"].Visible = false;
                    this.setDetailsData();
                    break;

                case 2:
                    this.dgvHistPagosClientCr.Columns["Pago"].Visible = false;
                    this.dgvHistPagosClientCr.Columns["Ultimo_Pago"].Visible = false;
                    break;
            }
        }


        private void txtCriterial_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Filter();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
