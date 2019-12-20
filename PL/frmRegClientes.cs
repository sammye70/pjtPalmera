using System;
using System.Windows.Forms;
using BLL;



namespace PL
{
    public partial class frmRegClientes : Form
    {

        public frmRegClientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddProvincia addProv = new frmAddProvincia();
            addProv.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAddCiudad addCiud = new frmAddCiudad();
            addCiud.Show();
        }
    }
}
