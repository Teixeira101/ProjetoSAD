using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SadWork
{
    public partial class ParkInfo : Form
    {
        private Form currentChildForm;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-CHRF1L4J\SQLEXPRESS;Initial Catalog=dbSAD;Integrated Security=True");

        public ParkInfo()
        {
            InitializeComponent();

            sqlcon.Open();
            /*if (ShowSimulations.parkClick)
            {
                cmd = new SqlCommand("SELECT * FROM [dbo].[Parque] Where [id_parque] = '" + ShowSimulations.parkId + "' AND [verificado_parque] = '" + true + "'", sqlcon);
            } else
            {
                cmd = new SqlCommand("SELECT * FROM [dbo].[Parque] Where [id_parque] = '" + ScientificParks.learnMoreParkId + "' AND [verificado_parque] = '" + true + "'", sqlcon);
            }*/

            cmd = new SqlCommand("SELECT * FROM [dbo].[Parque] Where [id_parque] = '" + ScientificParks.learnMoreParkId + "' AND [verificado_parque] = '" + true + "'", sqlcon);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                labelNomePark.Text = dr["nome_parque"].ToString();
                labelParkArea.Text = dr["area"].ToString();
                labelParkSlogan.Text = dr["slogan"].ToString();
                labelParkSlogan.MaximumSize = new Size(366, 75);
                labelParkSlogan.AutoSize = true;
                labelDescTotalPark.Text = dr["descricao_parque_total"].ToString();
                labelDescTotalPark.MaximumSize = new Size(510, 150);
                labelDescTotalPark.AutoSize = true;
                labelParkWebsite.Text = dr["website"].ToString();

                dr.Close();
            }

            sqlcon.Close();

            convertByteArrayToImage("foto_parque2", pictureBox1);
            convertByteArrayToImage("foto_parque3", pictureBox2);
        }

        private void OpenChildForm(Form childForm, Form currentChildForm)
        {
            Console.Out.WriteLine("OPEN CHILD FORM: " + ShowSimulations.parkClick);
            if (!ShowSimulations.parkClick)
            {
                currentChildForm.Close();
                currentChildForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                parkInfo_panel.Controls.Add(childForm);
                parkInfo_panel.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            } else {
                ShowSimulations.parkClick = false;
                this.Close();
            }
            
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            currentChildForm = new ParkInfo();
            OpenChildForm(new ScientificParks(), currentChildForm);
        }

        private void labelParkWebsite_Click(object sender, EventArgs e)
        {
            Process.Start(labelParkWebsite.Text);
        }

        private void convertByteArrayToImage(string foto_parqueId, PictureBox pictureBox)
        {
            Console.Out.WriteLine("CONVERT TO IMAGE: " + ScientificParks.learnMoreParkId);
            sqlcon.Open();
            if (ShowSimulations.parkClick)
            {
                cmd = new SqlCommand("SELECT " + foto_parqueId + " FROM [dbo].[Parque] Where [nome_parque] = '" + ShowSimulations.parkId + "'", sqlcon);
            }
            else
            {
                cmd = new SqlCommand("SELECT " + foto_parqueId + " FROM [dbo].[Parque] Where [id_parque] = '" + ScientificParks.learnMoreParkId + "'", sqlcon);
            }
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                try
                {
                    byte[] img = (byte[])dr[0];
                    if (img == null)
                    {
                        pictureBox.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        pictureBox.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception) { }
            }
            sqlcon.Close();
        }
    }
}