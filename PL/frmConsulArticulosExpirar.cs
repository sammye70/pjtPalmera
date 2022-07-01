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
    public partial class frmConsulArticulosExpirar : Form
    {
        public frmConsulArticulosExpirar()
        {
            InitializeComponent();
        }

        ProductosEntity productos = new ProductosEntity();

        int _month;
        int _year;

        public int Month
        {
            get { return _month; }
        }

        public int Year
        {
            get { return _year; }
        }
        
        /// <summary>
        /// Desable All Controls
        /// </summary>
        private void DesableControls()
        {
            this.MaximizeBox = true;
            this.MinimizeBox = false;
            this.cmbMonth.Visible = false;
            this.cmbYear.Visible = false;
            this.cmbYear.Visible = false;
            this.lblCriterio.Text = "";
            this.lblCriterio2.Text = "";
            this.btnSearchMonth.Visible = false;
            this.btnSearchYear.Visible = false;
            this.dgvProductExpirar.ReadOnly = true;
        }

        /// <summary>
        /// Enable Month Controls 
        /// </summary>
        private void EnableMonthControls()
        {
            this.lblCriterio.Text = "Mes";
            this.lblCriterio2.Text = "Año";
            this.cmbMonth.Visible = true;
            this.cmbYear.Visible = true;
            this.btnSearchMonth.Visible = true;
        }

        /// <summary>
        /// Desable Month Controls 
        /// </summary>
        private void DesableMonthControls()
        {
            this.cmbMonth.Text= "";
            this.lblCriterio.Text="";
            this.cmbMonth.Visible = false;
            this.btnSearchMonth.Visible = false;
        }

        /// <summary>
        /// Enable Year Controls 
        /// </summary>
        private void EnableYearControls()
        {
            this.cmbYear.Visible = true;
            this.lblCriterio2.Text = "Año";
            this.btnSearchMonth.Visible = false;
            this.btnSearchYear.Visible = true;
        }

        private void DesableYearControls()
        {
            //  this.cmbYear.Visible = false;
            //  this.cmbYear.Text = "";
            this.btnSearchYear.Visible = false;
        }

        private void CleanControls()
        {
            this.cmbMonth.Items.Clear();
            this.cmbYear.Items.Clear();
        }

        private void frmArticulosVencer_Load(object sender, EventArgs e)
        {
            DesableControls();
            ExpirareProduct();
            this.dgvProductExpirar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }



        /// <summary>
        /// Product to be Expere
        /// </summary>
        private void ExpirareProduct()
        {
            this.dgvProductExpirar.DataSource = null;
            this.dgvProductExpirar.DataSource = ProductosBO.ProductExpire();
        }

        private void rdMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdMonth.Checked == true)
            {
                EnableMonthControls();
                DesableYearControls();
                CleanControls();
                this.dgvProductExpirar.DataSource = ProductosBO.GetAll();
                this.cmbMonth.Focus();
                LoadMonth();
                LoadYear();
            }
        }

        private void rdYear_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdYear.Checked == true)
            {
                EnableYearControls();
                DesableMonthControls();
                CleanControls();
                this.dgvProductExpirar.DataSource = ProductosBO.GetAll();
                this.cmbYear.Focus();
                LoadYear();
            }
        }

        /// <summary>
        /// Load Month by Number
        /// </summary>
        private void LoadMonth()
        {
            int m = 13;
            for (int i = 1; i < m; i++)
            {
               this.cmbMonth.Items.Add(i);
            }
        }

        /// <summary>
        /// Load Year since 2020 until 2071
        /// </summary>
        private void LoadYear()
        {
            int y = 2071;

            for (int i=2020; i< y; i++)
            {
                this.cmbYear.Items.Add(i);
            }
        }


        /// <summary>
        /// Seach Expire Date for year and month
        /// </summary>
        private void SearchMonthYear()
        {
            try
            {
                _month = Convert.ToInt32(this.cmbMonth.SelectedItem);
                _year = Convert.ToInt32(this.cmbYear.SelectedItem);

                this.dgvProductExpirar.DataSource = ProductosBO.ExpireDate(this.Month, this.Year);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dgvProductExpirar.DataSource = ProductosBO.GetAll();
                return;
            }
        }

        /// <summary>
        /// Search Expire only year
        /// </summary>
        private void SearchYear()
        {
            try
            {
                _year = Convert.ToInt32(this.cmbYear.SelectedItem);

                this.dgvProductExpirar.DataSource = ProductosBO.ExpireYear(this.Year);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dgvProductExpirar.DataSource = ProductosBO.GetAll();
                return;
            }
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            if ((this.cmbMonth.Text != string.Empty) && (this.cmbYear.Text != string.Empty))
            {
                SearchMonthYear();
                
            }
            else
            {
                MessageBox.Show("Indicar Campos validos", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgvProductExpirar.DataSource = ProductosBO.GetAll();
                DesableMonthControls();
                return;
            }
        }

        private void btnSearchYear_Click(object sender, EventArgs e)
        {
            if (this.cmbYear.Text != string.Empty)
            {
                SearchYear();
               
            }
            else
            {
                MessageBox.Show("Indicar Año valido", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgvProductExpirar.DataSource = ProductosBO.GetAll();
                DesableYearControls();
                return;
            }
            
        }
    }
}
