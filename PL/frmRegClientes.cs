using System;
using System.Windows.Forms;
using pjPalmera.BLL;
using pjPalmera.Entities;


namespace pjPalmera.PL
{
    public partial class frmRegClientes : Form
    {
        //
        ClientesEntity clientes = null;

        public frmRegClientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                NewCostumer();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error:"+ ex.Message);
            }

            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
            
        }

        //
        private void NewCostumer()
        {
            if (clientes == null)
            {
                clientes = new ClientesEntity();
                clientes.Cedula = Convert.ToInt32(this.mktCedula.Text);
                clientes.Nombre = this.txtNombre.Text;
                clientes.Apellidos = this.txtApellidos.Text;
                clientes.Direccion = this.txtDireccion.Text;
                clientes.Ciudad = this.cmbCiudad.Text;
                clientes.Provincia = this.cmbProvincia.Text;
                clientes.Telefono = this.mktTelefono.Text;

                clientes = ClientesBO.Save(clientes); 
                
            }

        }
    }
}
