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
            SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-CHRF1L4J\SQLEXPRESS;Initial Catalog=dbSAD;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Empresa]
           ([nome_empresa]
           ,[area]
           ,[email_empresa]
           ,[password]
           ,[comprovativo]
           ,[verificado_empresa])
     VALUES
           ('" + textBoxCompName.Text.Trim() + "', '" + comboBoxArea.SelectedItem.ToString() + "', '" + textBoxEmail.Text.Trim() + "', '" + textBoxPwd.Text.Trim() + "', '" + ofd.FileName + "', '0')");
            sqlcon.Open();
            cmd.Connection = sqlcon;
            cmd.ExecuteNonQuery();
            sqlcon.Close();
        }
    }
}
