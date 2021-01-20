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
        SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-CHRF1L4J\SQLEXPRESS;Initial Catalog=dbSAD;Integrated Security=True");

        public VerifyCompany()
        {
            InitializeComponent();
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

        private void loadUnVerComp_btn_Click(object sender, EventArgs e)
        {
            bool verificado_empresa = false;
            panelCompVal.Visible = false;
            comboBoxId.Enabled = true;
            comboBoxId.Items.Clear();
            seeUnVerComp_btn.Visible = true;
            seeUnVerComp_btn.Enabled = true;

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

        private void seeUnVerComp_btn_Click(object sender, EventArgs e)
        {
            if(comboBoxId.SelectedIndex != -1) 
            {
                seeUnVerComp_btn.Enabled = false;
                comboBoxId.Enabled = false;
                panelCompVal.Visible = true;
                sqlcon.Open();
                cmd = new SqlCommand("SELECT * FROM [dbo].[Empresa] Where [nome_empresa] = '" + comboBoxId.SelectedItem + "'", sqlcon);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    labelCompName.Text = dr["nome_empresa"].ToString();
                    labelCompName.Location = new Point((panelCompVal.Width - labelCompName.Width) / 2, 27);

                    labelCompArea.Text = dr["area"].ToString();
                    labelCompArea.Location = new Point((panelCompVal.Width - labelCompArea.Width) / 2, 78);

                    labelCompEmail.Text = dr["email_empresa"].ToString();
                    labelCompEmail.Location = new Point((panelCompVal.Width - labelCompEmail.Width) / 2, 139);

                    labelCompLocation.Text = dr["localizacao"].ToString();
                    labelCompLocation.Location = new Point((panelCompVal.Width - labelCompLocation.Width) / 2, 198);

                    dr.Close();
                }
                sqlcon.Close();
            }
        }

        private void verCompany_btn_Click(object sender, EventArgs e)
        {
            seeUnVerComp_btn.Visible = false;
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
            seeUnVerComp_btn.Visible = false;
            comboBoxId.Enabled = true;
            sqlcon.Open();
            using (cmd = new SqlCommand("DELETE FROM [dbo].[Empresa] Where [nome_empresa] = '" + comboBoxId.SelectedItem + "'", sqlcon))
            {
                comboBoxId.Items.Clear();
                panelCompVal.Visible = false;
                seeUnVerComp_btn.Visible = false;

                cmd.ExecuteNonQuery();
            }
            sqlcon.Close();
        }
    }
}
