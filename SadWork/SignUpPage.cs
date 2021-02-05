using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Google.Apis.Auth.OAuth2;
using System.IO;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Drive.v3;
using Google.Apis.Services;

namespace SadWork
{
    public partial class SignUpPage : Form
    {
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-CHRF1L4J\SQLEXPRESS;Initial Catalog=dbSAD;Integrated Security=True");

        string filename;
        public SignUpPage()
        {
            InitializeComponent();

            comboBoxCompArea.Items.Add("Ciências e Tecnologias");
            comboBoxCompArea.Items.Add("Tecnologia Alimentar");
            comboBoxCompArea.Items.Add("Biotecnologia");
            comboBoxCompArea.Items.Add("Empreendedorismo");
            comboBoxCompArea.Items.Add("Comércio");
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

                filename = ofd.FileName;
            }
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            if (nullCamps())
            {
                MessageBox.Show("Empty Field(s)!");
            } else if (invalidEmailOrPassword() || existingEmaildb())
            {
                textBoxCompName.Clear();
                textBoxCompEmail.Clear();
                textBoxPwd.Clear();
                textBoxCompLocation.Clear();
                comboBoxCompArea.SelectedIndex = -1;
                labelPDF.Visible = false;

                if (sqlcon.State == ConnectionState.Open)
                    sqlcon.Close();
            } else
            {
                sqlcon.Open();

                FileStream fs = File.OpenRead(filename);
                byte[] contents = new byte[fs.Length];
                fs.Read(contents, 0, (int)fs.Length);
                fs.Close();

                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Empresa]
               ([nome_empresa]
               ,[area]
               ,[email_empresa]
               ,[password]
               ,[comprovativo]
               ,[verificado_empresa]
               ,[admin]
               ,[localizacao])
         VALUES
               ('" + textBoxCompName.Text.Trim() + "', '" + comboBoxCompArea.SelectedItem.ToString() + "', '" + textBoxCompEmail.Text.Trim() + "', '" + textBoxPwd.Text.Trim() + "', @pdf, '0', '0','" + textBoxCompLocation.Text.Trim() + "')", sqlcon);
                cmd.Parameters.AddWithValue("@pdf", contents);
                cmd.ExecuteNonQuery();

                LoginPage.admin = false;
                LoginPage.company = true;

                LoginPage MP = new LoginPage();
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
            if(textBoxCompName.Text.Trim() == "" || textBoxCompEmail.Text.Trim() == "" || textBoxPwd.Text.Trim() == "" || textBoxCompLocation.Text.Trim() == "" || comboBoxCompArea.SelectedIndex == -1 || labelPDF.Text.Trim() == "labelPDF")
            {
                return true;
            }
            return false;
        }

        private bool invalidEmailOrPassword()
        {
            bool isEmail = Regex.IsMatch(textBoxCompEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);

            if (!isEmail && textBoxPwd.TextLength < 8)
            {
                MessageBox.Show("Incorrect Email Format and Password Length!");
                return true;
            } else if (!isEmail)
            {
                MessageBox.Show("Incorrect Email Format!");
                return true;
            } else if(textBoxPwd.TextLength < 8)
            {
                MessageBox.Show("Incorrect Password Length!");
                return true;
            }
            return false;
        }

        private bool existingEmaildb()
        {
            sqlcon.Open();

            string oString = "SELECT COUNT(*) FROM [dbo].[Empresa]";
            cmd = new SqlCommand(oString, sqlcon);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            cmd = new SqlCommand("SELECT * FROM [dbo].[Empresa] Where [email_empresa] = '" + textBoxCompEmail.Text + "' OR [nome_empresa] = '" + textBoxCompName.Text + "'", sqlcon);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                for(int i = 0; i < count; i++)
                {
                    if (dr["nome_empresa"].ToString() == textBoxCompName.Text || dr["email_empresa"].ToString() == textBoxCompEmail.Text)
                    {
                        MessageBox.Show("Nome e/ou Email já existentes!");
                        return true;
                    }
                }
            }

            dr.Close();
            
            sqlcon.Close();
            return false;
        }

        private void textBoxCompName_KeyDown(object sender, KeyEventArgs e)
        {
            enterKeyPress(e);
        }

        private void textBoxEmail_KeyDown(object sender, KeyEventArgs e)
        {
            enterKeyPress(e);
        }

        private void textBoxPwd_KeyDown(object sender, KeyEventArgs e)
        {
            enterKeyPress(e);
        }

        private void textBoxLocation_KeyDown(object sender, KeyEventArgs e)
        {
            enterKeyPress(e);
        }

        private void comboBoxArea_KeyDown(object sender, KeyEventArgs e)
        {
            enterKeyPress(e);
        }

        private void buttonProof_KeyDown(object sender, KeyEventArgs e)
        {
            enterKeyPress(e);
        }

        private void enterKeyPress(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSignUp.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}
