using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace SadWork
{
    public partial class ChangePassword : Form
    {
        SqlCommand cmd;
        SqlConnection sqlcon = new SqlConnection(@"Data Source=46.101.41.99;Initial Catalog=dbSAD;User ID=SA;Password=Grupo1sad");
        string email = RecoverAccount.to;

        public ChangePassword()
        {
            InitializeComponent();
            DoubleBuffered = true;

        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            if (equalPwd())
            {
                sqlcon.Open();
                using (cmd = new SqlCommand("UPDATE [dbo].[Empresa] SET [password] = '" + textBoxPwd.Text.Trim() + "' Where [email_empresa] = '" + email + "'", sqlcon))
                {
                    cmd.ExecuteNonQuery();
                }
                sqlcon.Close();

                MessageBox.Show("Password Changed Successfully!");

                LoginPage LP = new LoginPage();
                this.Hide();
                LP.Show();
            }
        }

        private bool equalPwd()
        {
            if(textBoxPwd.Text == textBoxRptPwd.Text) { return true; } else { MessageBox.Show("Password Doesn't Match"); }
            return false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginPage lp = new LoginPage();
            lp.Show();
            lp.BringToFront();
        }
    }
}
