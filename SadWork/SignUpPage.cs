using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace SadWork
{
    public partial class SignUpPage : Form
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void buttonProof_Click(object sender, EventArgs e)
        {
            ofd.Filter = "PDF|*.pdf";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                labelPDF.Text = ofd.SafeFileName;
                labelPDF.Visible = true;
            }
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            if (nullCamps())
            {
                MessageBox.Show("Empty Field(s)!");
                textBoxEmail.Clear();
                textBoxPwd.Clear();
                textBoxPwd.Clear();
                comboBoxArea.SelectedIndex = -1;
                labelPDF.Visible = false;
            } else if (invalidEmailOrPassword())
            {
                textBoxCompName.Clear();
                textBoxEmail.Clear();
                textBoxPwd.Clear();
                comboBoxArea.SelectedIndex = -1;
                labelPDF.Visible = false;
            } else
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-CHRF1L4J\SQLEXPRESS;Initial Catalog=dbSAD;Integrated Security=True");
                sqlcon.Open();

                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Empresa]
               ([nome_empresa]
               ,[area]
               ,[email_empresa]
               ,[password]
               ,[comprovativo]
               ,[verificado_empresa]
               ,[admin])
         VALUES
               ('" + textBoxCompName.Text.Trim() + "', '" + comboBoxArea.SelectedItem.ToString() + "', '" + textBoxEmail.Text.Trim() + "', '" + textBoxPwd.Text.Trim() + "', '" + ofd.FileName + "', '0', '0')", sqlcon);

                cmd.ExecuteNonQuery();

                LoginPage.admin = false;
                LoginPage.company = false;

                MainPage MP = new MainPage();
                this.Hide();
                MP.Show();
                sqlcon.Close();

                if (sqlcon.State == ConnectionState.Open)
                    sqlcon.Close();
                sqlcon.Dispose();
            }
        }

        private void backLogin_btn_Click(object sender, EventArgs e)
        {
            LoginPage LP = new LoginPage();
            this.Hide();
            LP.Show();
        }

        private bool nullCamps()
        {
            if(textBoxCompName.Text == "" || textBoxEmail.Text == "" || textBoxPwd.Text == "" || comboBoxArea.SelectedIndex == 0 || labelPDF.Text == "labelPDF")
            {
                return true;
            }
            return false;
        }

        private bool invalidEmailOrPassword()
        {
            bool isEmail = Regex.IsMatch(textBoxEmail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9]){2-3}?)\Z", RegexOptions.IgnoreCase);

            if (!isEmail && textBoxPwd.TextLength < 8)
            {
                MessageBox.Show("Incorrect Email Formate and Password Length!");
                return true;
            } else if (!isEmail)
            {
                MessageBox.Show("Incorrect Email Formate!");
                return true;
            } else if(textBoxPwd.TextLength < 8)
            {
                MessageBox.Show("Incorrect Password Length!");
                return true;
            }
            return false;
        }
    }
}
