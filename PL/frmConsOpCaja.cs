using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    public partial class frmConsOpCaja : Form
    {
        public frmConsOpCaja()
        {
            InitializeComponent();
        }

        private void frmConsOpCaja_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///  Prepare controls before load form 
        /// </summary>
        public void iniControl()
        {
            this.lblUsers.Visible = true;
            this.cmbUsers.Visible = true;
            this.dtpDateBegin.Format = DateTimePickerFormat.Short;
            this.dtpDateEnd.Format = DateTimePickerFormat.Short;

            //---> Add current date before user open form to filter only 

        }

        /// <summary>
        ///  Filter set Date indicared by user
        /// </summary>
        private void FilterDate()
        {
            var begin = this.dtpDateBegin.Value.Date.ToShortDateString();
            var end = this.dtpDateEnd.Value.Date.ToShortDateString();

            //------> add here other functionaries

        }

        /// <summary>
        /// 
        /// </summary>
        private void FilterUser()
        {

        }

    }
}
