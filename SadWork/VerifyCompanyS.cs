using System;
using System.Windows.Forms;

namespace SadWork
{
    public partial class VerifyCompanyS : Form
    {
        public VerifyCompanyS()
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
    }
}
