using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SadWork
{
    public partial class ConfirmParkS : Form
    {
        public ConfirmParkS()
        {
            InitializeComponent();

           
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void openFile_Click(object sender, EventArgs e)
        {
            ofd.Filter = "JPG|*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                label7.Text = ofd.SafeFileName;
                label7.Visible = true;
            }
        }

        private void ConfirmParkS_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
