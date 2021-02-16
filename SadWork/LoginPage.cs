using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace SadWork
{
    public partial class LoginPage : Form
    {
        public static string admin_email = "anfisaprata@gmail.com";
        public static string currentUserId = "";

        public static bool admin = false;
        public static bool company = false;

        public LoginPage()
        {
            InitializeComponent();
            DoubleBuffered = true;
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

            btnMin.MouseEnter += OnMouseEnterButtonMin;
            btnMin.MouseLeave += OnMouseLeaveButtonMin;

            btnExit.MouseEnter += OnMouseEnterButtonExit;
            btnExit.MouseLeave += OnMouseLeaveButtonExit;
        }

        private void OnMouseEnterButtonMin(object sender, EventArgs e)
        {
            btnMin.BackColor = SystemColors.ControlLight;
        }

        private void OnMouseLeaveButtonMin(object sender, EventArgs e)
        {
            btnMin.BackColor = SystemColors.ButtonFace;
        }

        private void OnMouseEnterButtonExit(object sender, EventArgs e)
        {
            btnExit.BackColor = SystemColors.ControlLight;
        }

        private void OnMouseLeaveButtonExit(object sender, EventArgs e)
        {
            btnExit.BackColor = SystemColors.ButtonFace;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (nullCamps())
            {
                textBoxEmail.Clear();
                textBoxPwd.Clear();
                MessageBox.Show("Empty Field(s)!");
            }
            else if (invalidEmailOrPassword())
            {
                textBoxEmail.Clear();
                textBoxPwd.Clear();
            }
            else
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=46.101.41.99;Initial Catalog=dbSAD;User ID=SA;Password=Grupo1sad");
                sqlcon.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT [email_empresa], [password] FROM [dbo].[Empresa] Where [email_empresa] = @emailEmpresa and password = @pwd", sqlcon);
                cmd.Parameters.Add(new SqlParameter("@emailEmpresa", textBoxEmail.Text.Trim()));
                cmd.Parameters.Add(new SqlParameter("@pwd", textBoxPwd.Text.Trim()));

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    dr.Close();
                    cmd = new SqlCommand(@"SELECT [id_empresa], [email_empresa], [verificado_empresa] FROM [dbo].[Empresa] Where [email_empresa] = @emailEmpresa and [verificado_empresa] = @verificado_empresa", sqlcon);
                    cmd.Parameters.Add(new SqlParameter("@emailEmpresa", textBoxEmail.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@verificado_empresa", true));
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        currentUserId = dr[0].ToString();
                        dr.Close();
                        sqlcon.Close();
                        if (textBoxEmail.Text.Trim() == admin_email)
                        {
                            admin = true;
                            company = false;
                        }
                        else
                        {
                            admin = false;
                            company = true;
                        }

                        MainPage objMainPage = new MainPage();
                        this.Hide();
                        objMainPage.Show();

                    }
                    else
                    {
                        dr.Close();
                        sqlcon.Close();
                        MessageBox.Show("Your Company's Account Hasn't Been Yet Verified By Our Admins \nIf It's Been Too Long Since The Creation Of It, \nPlease Contact Us!");
                    }
                }
                else
                {
                    textBoxEmail.Clear();
                    textBoxPwd.Clear();
                    MessageBox.Show("Invalid Credentials");
                }

                //Libertar Recursos
                if (!dr.IsClosed)
                    dr.Close();

                if (sqlcon.State == ConnectionState.Open)
                    sqlcon.Close();
                sqlcon.Dispose();
            }
        }

        private void buttonSkip_Click(object sender, EventArgs e)
        {
            admin = false;
            company = false;
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

        private void buttonForgotPwd_Click(object sender, EventArgs e)
        {
            this.Close();
            RecoverAccount objRecoverAccount = new RecoverAccount();
            objRecoverAccount.Show();
            objRecoverAccount.BringToFront();
        }

        private bool nullCamps()
        {
            if (textBoxEmail.Text == "" || textBoxPwd.Text == "")
            {
                return true;
            }
            return false;
        }

        private bool invalidEmailOrPassword()
        {
            bool isEmail = Regex.IsMatch(textBoxEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);

            if (!isEmail && textBoxPwd.TextLength < 8)
            {
                MessageBox.Show("Incorrect Email Formate and Password Length!");
                return true;
            }
            else if (!isEmail)
            {
                MessageBox.Show("Incorrect Email Formate!");
                return true;
            }
            else if (textBoxPwd.TextLength < 8)
            {
                MessageBox.Show("Incorrect Password Length!");
                return true;
            }
            return false;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelLoginPage_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxEmail_KeyDown(object sender, KeyEventArgs e)
        {
            enterKeyPress(e);
        }

        private void textBoxPwd_KeyDown(object sender, KeyEventArgs e)
        {
            enterKeyPress(e);
        }

        private void enterKeyPress(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login_btn.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void panelBlack_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}