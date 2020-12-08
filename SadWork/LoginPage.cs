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

namespace SadWork
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            pictureBox2.Parent = pictureBox1;
            pictureBox2.BackColor = Color.Transparent;

            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;

            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;

            buttonSignUp.Parent = pictureBox1;
            buttonSignUp.BackColor = SystemColors.ButtonShadow;
            buttonSignUp.FlatAppearance.MouseOverBackColor = SystemColors.ButtonShadow;

            Color mouseOverColor = buttonSignUp.FlatAppearance.MouseOverBackColor;
            buttonSignUp.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, mouseOverColor.R, mouseOverColor.G, mouseOverColor.B);

            Color backColor = buttonSignUp.BackColor;
            buttonSignUp.BackColor = Color.FromArgb(100, backColor.R, backColor.G, backColor.B);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-CHRF1L4J\SQLEXPRESS;Initial Catalog=dbSAD;Integrated Security=True");
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand(@"SELECT [email_empresa] ,[password] FROM [dbo].[Empresa] Where [email_empresa] = @emailEmpresa and password = @pwd", sqlcon);
            cmd.Parameters.Add(new SqlParameter("@emailEmpresa", textBoxEmail.Text.Trim()));
            cmd.Parameters.Add(new SqlParameter("@pwd", textBoxPwd.Text.Trim()));

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                dr.Close();
                cmd = new SqlCommand(@"SELECT [verificado_empresa] FROM [dbo].[Empresa] Where [verificado_empresa] = @verificado_empresa", sqlcon);
                cmd.Parameters.Add(new SqlParameter("@verificado_empresa", true));
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    dr.Close();
                    sqlcon.Close();
                    MainPage objMainPage = new MainPage();
                    this.Hide();
                    objMainPage.Show();
                } else
                {
                    dr.Close();
                    sqlcon.Close();
                    MessageBox.Show("Your Company's Account Hasn't Been Yet Verified By Our Admins \nIf It's Been Too Long Since The Creation Of The Account, \nPlease Contact Us!");
                }
            } else
            {
                textBoxEmail.Clear();
                textBoxPwd.Clear();
                MessageBox.Show("Invalid Credentials");
            }

            //Libertar Recursos
            if (!dr.IsClosed)
                dr.Close();

            if (sqlcon.State == System.Data.ConnectionState.Open)
                sqlcon.Close();
            sqlcon.Dispose();
        }

        private void buttonSkip_Click(object sender, EventArgs e)
        {
            MainPage objMainPage = new MainPage();
            this.Hide();
            objMainPage.Show();
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            SignUpPage objSignUp = new SignUpPage();
            this.Hide();
            objSignUp.Show();
        }
    }
}
