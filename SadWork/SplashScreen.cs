using System;
using System.Windows.Forms;

namespace SadWork
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 5;

            if(panel2.Width >= 1024)
            {
                timer1.Stop();
                LoginPage LP = new LoginPage();
                this.Hide();
                LP.Show();
            }
        }
    }
}
