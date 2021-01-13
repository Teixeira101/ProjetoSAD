using System;
using System.Windows.Forms;

namespace SadWork
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 5;

            if(panel2.Width >= 1024)
            {
                timer1.Stop();
                ConfirmPark LP = new ConfirmPark();
                this.Hide();
                LP.Show();
            }
        }
    }
}
