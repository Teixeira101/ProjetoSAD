using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SadWork
{
    public partial class RecoverAccount : Form
    {
        bool existEmail = false;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-CHRF1L4J\SQLEXPRESS;Initial Catalog=dbSAD;Integrated Security=True");
        public static string resetEmail;

        public RecoverAccount()
        {
            InitializeComponent();
            SubmitButton.Hide();
            CodeLabel.Hide();
            textBoxCode.Hide();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            if (!invalidEmail()) 
            { 
                sqlcon.Open();
                cmd = new SqlCommand("SELECT * FROM [dbo].[Empresa] Where [email_empresa] = '" + textBoxEmail.Text.Trim() + "'", sqlcon);
                using (dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        existEmail = true;
                    }
                }
                sqlcon.Close();

                if (existEmail)
                {
                    SubmitButton.Show();
                    CodeLabel.Show();
                    textBoxCode.Show();
                    ResetButton.Hide();
                    textBoxEmail.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("The E-mail You Have Provided Doesn't Exist!");
                }
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            ChangePassword objChangePassword = new ChangePassword();
            this.Hide();
            objChangePassword.Show();
            objChangePassword.TopMost = true;
            resetEmail = textBoxEmail.Text.Trim();
        }

        private bool invalidEmail()
        {
            bool isEmail = Regex.IsMatch(textBoxEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);

            if (!isEmail)
            {
                MessageBox.Show("Incorrect Email Formate!");
                return true;
            }
            return false;
        }
    }
}
