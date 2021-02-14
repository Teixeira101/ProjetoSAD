using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SadWork
{
    public partial class VerifyCompany : Form
    {
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DatabaseSAD.mdf;Integrated Security=True");

        public VerifyCompany()
        {
            InitializeComponent();
            DoubleBuffered = true;
            loadUnverifiedParks();
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            verCompany_btn.Visible = true;
            delete_btn.Visible = true;

            sqlcon.Open();
            cmd = new SqlCommand("SELECT * FROM [dbo].[Empresa] Where [nome_empresa] = '" + labelCompName.Text + "'", sqlcon);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                FileStream fs;
                byte[] pdfByte;

                pdfByte = (byte[])dr["comprovativo"];
                string filepath = @"D:\" + labelCompName.Text + ".pdf";

                fs = new FileStream(filepath, FileMode.Create);

                fs.Write(pdfByte, 0, pdfByte.Length);

                fs.Close();

                Process Proc = new Process();
                Proc.StartInfo.FileName = filepath;
                Proc.Start();
            }
            dr.Close();
            sqlcon.Close();
        }

        private void loadUnverifiedParks()
        {
            bool verificado_empresa = false;
            comboBoxId.Enabled = true;
            comboBoxId.Items.Clear();

            sqlcon.Open();
            cmd = new SqlCommand("SELECT * FROM [dbo].[Empresa] Where [verificado_empresa] = '" + verificado_empresa + "'", sqlcon);

            using (dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    comboBoxId.Items.Add(dr["nome_empresa"].ToString());
                }

                dr.Close();
            }
            sqlcon.Close();
        }

        private void verCompany_btn_Click(object sender, EventArgs e)
        {
            sqlcon.Open();
            using (cmd = new SqlCommand("UPDATE [dbo].[Empresa] SET [verificado_empresa] = '1' Where [nome_empresa] = '" + comboBoxId.SelectedItem + "'", sqlcon))
            {
                comboBoxId.Items.Clear();
                comboBoxId.Enabled = true;
                panelCompVal.Visible = false;

                cmd.ExecuteNonQuery();
            }
            sqlcon.Close();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            comboBoxId.Enabled = true;
            sqlcon.Open();
            using (cmd = new SqlCommand("DELETE FROM [dbo].[Empresa] Where [nome_empresa] = '" + comboBoxId.SelectedItem + "'", sqlcon))
            {
                comboBoxId.Items.Clear();
                panelCompVal.Visible = false;

                cmd.ExecuteNonQuery();
            }
            sqlcon.Close();
        }

        private void comboBoxId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBoxId.SelectedIndex != -1)
            {
                openFile.Visible = true;
                labelCompName.Visible = true;
                labelCompEmail.Visible = true;
                labelCompArea.Visible = true;
                labelCompLocation.Visible = true;
                sqlcon.Open();
                cmd = new SqlCommand("SELECT * FROM [dbo].[Empresa] Where [nome_empresa] = '" + comboBoxId.SelectedItem + "'", sqlcon);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    labelCompName.Text = dr["nome_empresa"].ToString();

                    labelCompArea.Text = dr["area"].ToString();

                    labelCompEmail.Text = dr["email_empresa"].ToString();

                    labelCompLocation.Text = dr["localizacao"].ToString();
                    labelCompLocation.MaximumSize = new Size(200, 32);

                    dr.Close();
                }
                sqlcon.Close();
            }
        }
    }
}
