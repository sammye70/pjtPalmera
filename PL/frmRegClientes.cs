﻿using System;
using System.Windows.Forms;
using _DAL;
using BLL;



namespace PL
{
    public partial class frmRegClientes : Form
    {
        clsSettings dbCon = new clsSettings();

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            dbCon.Connect();    
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dbCon.Desconnect();
        }
    }
}
