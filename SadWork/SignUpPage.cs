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
                textBoxCompEmail.Clear();
                textBoxPwd.Clear();
                textBoxPwd.Clear();
                comboBoxCompArea.SelectedIndex = -1;
                labelPDF.Visible = false;
            } else if (invalidEmailOrPassword())
            {
                textBoxCompName.Clear();
                textBoxCompEmail.Clear();
                textBoxPwd.Clear();
                comboBoxCompArea.SelectedIndex = -1;
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
               ,[admin]
               ,[location])
         VALUES
               ('" + textBoxCompName.Text.Trim() + "', '" + comboBoxCompArea.SelectedItem.ToString() + "', '" + textBoxCompEmail.Text.Trim() + "', '" + textBoxPwd.Text.Trim() + "', '" + ofd.FileName + "', '0', '0','" + textBoxCompLocation.Text.Trim() + "')", sqlcon);

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
            if(textBoxCompName.Text == "" || textBoxCompEmail.Text == "" || textBoxPwd.Text == "" || textBoxCompLocation.Text == "" || comboBoxCompArea.SelectedIndex == 0 || labelPDF.Text == "labelPDF")
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
