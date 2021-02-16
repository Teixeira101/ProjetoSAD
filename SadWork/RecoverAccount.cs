using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace SadWork
{
    public partial class RecoverAccount : Form
    {
        bool existEmail = false;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection sqlcon = new SqlConnection(@"Data Source=46.101.41.99;Initial Catalog=dbSAD;User ID=SA;Password=Grupo1sad");
        public static string resetEmail;
        string randomCode;
        public static string to;

        public RecoverAccount()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SubmitButton.Hide();
            CodeLabel.Hide();
            textBoxCode.Hide();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            string from, pass, messageBody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();

            if (textBoxEmail.Text.ToString() != "") {
                to = (textBoxEmail.Text).ToString();
                MailMessage message = new MailMessage();
                from = "sadworkdm@gmail.com";
                pass = "grupo1sad";
                messageBody = "Your reset code is " + randomCode;
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = messageBody;
                message.Subject = "We Are Decisions Support - Password Reset";
            
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
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        smtp.EnableSsl = true;
                        smtp.Port = 587;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential(from, pass);
                        try
                        {
                            smtp.Send(message);
                            MessageBox.Show("Code sent successfully!");
                            SubmitButton.Show();
                            CodeLabel.Show();
                            textBoxCode.Show();
                            ResetButton.Hide();
                            textBoxEmail.ReadOnly = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                        }
                    
                    }
                    else
                    {
                        MessageBox.Show("The E-mail You Have Provided Doesn't Exist!");
                    }
                }
            } else
            {
                MessageBox.Show("Invalid Email!");
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (randomCode == (textBoxCode.Text).ToString())
            {
                to = textBoxEmail.Text;
                ChangePassword objChangePassword = new ChangePassword();
                this.Hide();
                objChangePassword.Show();
                objChangePassword.TopMost = true;
                resetEmail = textBoxEmail.Text.Trim();
            }
            else
            {
                MessageBox.Show("Wrong Code!");
            }
            
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginPage lp = new LoginPage();
            lp.Show();
            lp.BringToFront();
        }
    }
}
