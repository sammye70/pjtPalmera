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
            this.StartPosition = FormStartPosition.CenterScreen;
            timer1.Start();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Interval = 60000;
            this.Close();
            
        }
    }
}
