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
    public partial class frmConsUsers : Form
    {


        public frmConsUsers()
        {
            InitializeComponent();
        }

        private int n;

        public int getNumber
        {
            get { return n; }
        }


        private void txtuserName_TextChanged(object sender, EventArgs e)
        {
            if((this.txtuserName.Text == string.Empty) || (this.txtuserName.Text == null))
            {
                this.dgvUsers.DataSource = UsuariosBO.getAllUsers;
            }

            if(this.rbPersona.Checked == true)
            {
                var user = new UsuariosEntity();
                user.LongName = (this.txtuserName.Text);
                this.dgvUsers.DataSource = UsuariosBO.getUserByLongName(user);
                this.hideFields();

            }

            if(this.rbUsuario.Checked == true)
            {
                var user = new UsuariosEntity();
                user.User_name = (this.txtuserName.Text);
                this.dgvUsers.DataSource = UsuariosBO.getUserByName(user);
                this.hideFields();
            }
        }

        /// <summary>
        ///  Describe all controls
        /// </summary>
        private void DetailsControls()
        {
            this.toolTip1.SetToolTip(this.btnEditarProd, "Editar Usuario actualmente seleccionado");
            this.toolTip1.SetToolTip(this.btnRemove, "Eliminar Usuario actualmente seleccionado");
            this.toolTip1.SetToolTip(this.txtuserName, "Indicar criterio de la búsqueda");
            this.toolTip1.SetToolTip(this.btnDisableUser, "Desactivar Usuario actualmente seleccionado");
            this.toolTip1.SetToolTip(this.btnEnable, "Activar Usuario actualmente seleccionado");
        }

        private void hideFields()
        {
            this.dgvUsers.Columns["Id_user"].Visible = false;
            this.dgvUsers.Columns["Firstname"].Visible = false;
            this.dgvUsers.Columns["Lastname"].Visible = false;
            this.dgvUsers.Columns["Password"].Visible = false;
           // this.dgvUsers.Columns["Status"].Visible = false;
            this.dgvUsers.Columns["Createby"].Visible = false;
            this.dgvUsers.Columns["Created"].Visible = false;
            this.dgvUsers.Columns["Privileges"].Visible = false;
            this.dgvUsers.Columns["Email"].Visible = false;
            this.dgvUsers.Columns["Secret_question"].Visible = false;
            this.dgvUsers.Columns["Secret_answer"].Visible = false;
            // this.dgvUsers.Columns[""].Visible = false;
            this.dgvUsers.Columns["Op"].Visible = false;
            this.dgvUsers.ReadOnly = true;

            // Set Header Name
            this.dgvUsers.Columns["User_name"].HeaderText = "Usuario";
            this.dgvUsers.Columns["LongName"].HeaderText = "Persona";
            this.dgvUsers.Columns["Status"].HeaderText = "Estado";

        }



        /// <summary>
        /// Load All Users
        /// </summary>
        private void getUser()
        {
            this.dgvUsers.DataSource = UsuariosBO.getAllUsers;
        }

        private void editUser()
        {
            try
            {
                var user = new UsuariosEntity();
                var user1 = new UsuariosEntity();
                var regUser = new frmRegUsers();
                DataGridViewRow x = this.dgvUsers.CurrentRow;

                n = int.Parse(this.dgvUsers.Rows[x.Index].Cells[0].Value.ToString());

                regUser.Show();

                regUser.btnNuevo.Visible = false;
                regUser.btnGuardar.Visible = false;
                regUser.txtUsername.ReadOnly = true;
                regUser.Text = "Actualizar Datos del Usuario";
                regUser.lblTitle.Text = "Actualizar Datos del Usuario";
                user.Id_user = int.Parse(this.txtUserId.Text);
                regUser.txtidUser.Text = user.Id_user.ToString();

                user1.Id_user = int.Parse(this.getNumber.ToString());

                user1 = UsuariosBO.getUserInfId(user1);

                regUser.txtFirstName.Text = user1.Firstname.ToString();
                regUser.txtLastName.Text = user1.Lastname.ToString();
                regUser.txtUsername.Text = user1.User_name.ToString();
                regUser.txtUserIdMod.Text = user1.Id_user.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void btnEditarProd_Click(object sender, EventArgs e)
        {
            this.editUser();
        }

        private void frmConsUsers_Load(object sender, EventArgs e)
        {
            this.getUser();
            this.hideFields();
            DetailsControls();
            this.rbPersona.Checked = true;
            this.lblCriterial.Text = "Persona";
            this.txtuserName.Focus();
        }

        private void rbPersona_CheckedChanged(object sender, EventArgs e)
        {
            this.lblCriterial.Text = "Persona";
            this.txtuserName.Focus();
            this.dgvUsers.DataSource = UsuariosBO.getAllUsers;
        }

        private void rbUsuario_CheckedChanged(object sender, EventArgs e)
        {
            this.lblCriterial.Text = "Usuario";
            this.txtuserName.Focus();
            this.dgvUsers.DataSource = UsuariosBO.getAllUsers;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            
            DataGridViewRow x = this.dgvUsers.CurrentRow;
            n = int.Parse(this.dgvUsers.Rows[x.Index].Cells[0].Value.ToString());

            var user = new UsuariosEntity();
            user.Id_user = n;

            var q = new DialogResult();
            q = MessageBox.Show("Seguro que desea eliminar el usuario seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if(q == DialogResult.Yes)
            {
                UsuariosBO.RemoveUser(user);
                this.dgvUsers.DataSource = UsuariosBO.getAllUsers;
            }
            else if(q == DialogResult.No)
            {
                this.txtuserName.Focus();
                return;
            }
        }

        private void btnDisableUser_Click(object sender, EventArgs e)
        {
            DataGridViewRow x = this.dgvUsers.CurrentRow;
            n = int.Parse(this.dgvUsers.Rows[x.Index].Cells[0].Value.ToString());

            var user = new UsuariosEntity();
            user.Id_user = n;
            user.Status = "2";

            var q = new DialogResult();
            q = MessageBox.Show("Seguro que desea desactivar el usuario seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (q == DialogResult.Yes)
            {
                UsuariosBO.DisableUser(user);
                this.dgvUsers.DataSource = UsuariosBO.getAllUsers;
            }
            else if (q == DialogResult.No)
            {
                this.txtuserName.Focus();
                return;
            }
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            DataGridViewRow x = this.dgvUsers.CurrentRow;
            n = int.Parse(this.dgvUsers.Rows[x.Index].Cells[0].Value.ToString());

            var user = new UsuariosEntity();
            user.Id_user = n;
            user.Status = "1";

            var q = new DialogResult();
            q = MessageBox.Show("Seguro que desea activar el usuario seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (q == DialogResult.Yes)
            {
                UsuariosBO.EnableUser(user);
                this.dgvUsers.DataSource = UsuariosBO.getAllUsers;
            }
            else if (q == DialogResult.No)
            {
                this.txtuserName.Focus();
                return;
            }
        }
    }
}
