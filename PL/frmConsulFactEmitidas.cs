using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjPalmera.PL
{
    public partial class frmConsulFactEmitidas : Form
    {
        public frmConsulFactEmitidas()
        {
            InitializeComponent();
        }

        private void rbNumFact_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbNumFact.Checked == true)
            {
                Habilitar();
                this.label1.Text = "Numero";
                Limpiar();
                this.txtValorCriterio1.Focus();
                this.txtValorCriterio2.Visible = false;
                this.label2.Visible = false;
            }
        }


        private void Limpiar()
        {
            this.txtValorCriterio1.Clear();
            this.txtValorCriterio2.Clear();
        }

        private void Deshabilitar()
        {
            this.label1.Visible = false;
            this.label2.Visible = false;
            this.txtValorCriterio1.Visible = false;
            this.txtValorCriterio2.Visible = false;

        }

        private void Habilitar()
        {

            this.label1.Visible = true;
            this.txtValorCriterio1.Visible = true;
        }

        private void rbFecha_CheckedChanged(object sender, EventArgs e)
        {
            
            this.txtValorCriterio2.Visible = true;
            this.label2.Visible = true;
            this.label1.Text = "Desde";
            this.label2.Text = "Hasta";
            Limpiar();
            this.txtValorCriterio1.Focus();
        }



        private void frmConsulFactEmitidas_Load(object sender, EventArgs e)
        {
            Deshabilitar();
        }


    }
}
