using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SadWork
{
    public partial class ScientificParks : Form
    {
        public static string learnMoreParkId;
        private Form currentChildForm;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection sqlcon = new SqlConnection(@"Data Source=46.101.41.99;Initial Catalog=dbSAD;User ID=SA;Password=Grupo1sad");

        public ScientificParks()
        {
            InitializeComponent();
            DoubleBuffered = true;
            loadParks();
        }

        private void OpenChildForm(Form childForm, Form currentChildForm)
        {
            currentChildForm.Close();
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            scientificPark_panel.Controls.Add(childForm);
            scientificPark_panel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void learnMore_btn_Click(object sender, EventArgs e)
        {
            ShowSimulations.parkClick = false;
            currentChildForm = new ScientificParks();
            OpenChildForm(new ParkInfo(), currentChildForm);
        }

        private void loadParks()
        {
            panelPark.Visible = false;
            comboBoxId.Enabled = true;
            comboBoxId.Items.Clear();
            comboBoxId.SelectedIndex = -1;
            bool verificado_parque = true;
            sqlcon.Open();

            cmd = new SqlCommand("SELECT * FROM [dbo].[Parque] Where [verificado_parque] = '" + verificado_parque + "'", sqlcon);

            using (dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    comboBoxId.Items.Add(dr["nome_parque"].ToString());
                }

                dr.Close();
            }
            sqlcon.Close();
        }

        private void comboBoxId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            sqlcon.Open();
            cmd = new SqlCommand("SELECT * FROM [dbo].[Parque] Where [nome_parque] = '" + comboBoxId.SelectedItem + "'", sqlcon);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                panelPark.Visible = true;
                learnMoreParkId = dr["id_parque"].ToString();
                labelNomePark.Text = dr["nome_parque"].ToString();
                int widthCentro = (711 - labelNomePark.Width) / 2;
                labelNomePark.Location = new Point(widthCentro, 8);
                labelParkArea.Text = dr["area"].ToString();
                labelParkBriefDesc.Text = dr["descricao_parque_parcial"].ToString();
                labelParkBriefDesc.MaximumSize = new Size(383, 182);
                labelParkBriefDesc.AutoSize = true;
                int heightCentro = (182 - labelParkBriefDesc.Height) / 2;
                labelParkBriefDesc.Location = new Point(291, heightCentro + 41);
            }
            dr.Close();

            cmd = new SqlCommand("SELECT foto_parque1 FROM [dbo].[Parque] Where [nome_parque] = '" + comboBoxId.SelectedItem + "'", sqlcon);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                try
                {
                    byte[] img = (byte[])dr[0];
                    if (img == null)
                    {
                        pictureBox1.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception) { }
            }
            sqlcon.Close();
        }
    }
}
