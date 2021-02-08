using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace SadWork
{
    public partial class ChangePassword : Form
    {
        SqlCommand cmd;
        SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-CHRF1L4J\SQLEXPRESS;Initial Catalog=dbSAD;Integrated Security=True");
        string email = RecoverAccount.to;

        public ChangePassword()
        {
            InitializeComponent();
            
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
    }
}
