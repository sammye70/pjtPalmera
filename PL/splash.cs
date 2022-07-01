using pjPalmera.PL;
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
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }

        private void splash_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.Set_properties();
            this.StartPosition = FormStartPosition.CenterScreen;
            timer1.Start();

            frmlogin log = new frmlogin();
            log.Show();
        }

 
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Interval = 90000;
            this.Hide();
            timer1.Dispose();

        }

        /// <summary>
        /// Set Initial properties at Controls
        /// </summary>
        private void Set_properties() 
        {
            this.lblTest_title.Text = "Welcome to PalmeraSoft";
            this.lblTest_title.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTest_title.ForeColor = Color.Black;
        }
    }
}
