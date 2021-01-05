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
    public partial class RecoverAccount : Form
    {

        public RecoverAccount()
        {
            InitializeComponent();
            SubmitButton.Hide();
            CodeLabel.Hide();
            CodeBox.Hide();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            SubmitButton.Show();
            CodeLabel.Show();
            CodeBox.Show();
            ResetButton.Hide();
            EmailBox.ReadOnly = true;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            ChangePassword objChangePassword = new ChangePassword();
            this.Hide();
            objChangePassword.Show();
            objChangePassword.TopMost = true;
        }
    }
}
