using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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
                int widthCentro = (804 - labelNomePark.Width) / 2;
                labelNomePark.Location = new Point(widthCentro, 19);

                labelParkArea.Text = dr["area"].ToString();
                labelParkArea.Location = new Point(804 - (labelParkArea.Width + 12), 19);

                labelParkSlogan.Text = dr["slogan"].ToString();
                labelParkSlogan.MaximumSize = new Size(320, 75);
                labelParkSlogan.AutoSize = true;
                int widthCentro2 = (804 - labelParkSlogan.Width) / 2;
                labelParkSlogan.Location = new Point(widthCentro2, 57);

                labelDescTotalPark.Text = dr["descricao_parque_total"].ToString();
                labelDescTotalPark.MaximumSize = new Size(500, 240);
                labelDescTotalPark.AutoSize = true;
                int heightCentro = (355 - labelDescTotalPark.Height) / 2;
                labelDescTotalPark.Location = new Point(27, heightCentro + 114);

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