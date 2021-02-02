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
        SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-CHRF1L4J\SQLEXPRESS;Initial Catalog=dbSAD;Integrated Security=True");

        public ScientificParks()
        {
            InitializeComponent();
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
            currentChildForm = new ScientificParks();
            OpenChildForm(new ParkInfo(), currentChildForm);
        }

        private void loadParks_btn_Click(object sender, EventArgs e)
        {
            panelPark.Visible = false;
            comboBoxId.Enabled = true;
            comboBoxId.Items.Clear();
            comboBoxId.SelectedIndex = -1;
            bool verificado_parque = true;
            seePark_btn.Visible = true;
            seePark_btn.Enabled = true;
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

        private void seePark_btn_Click(object sender, EventArgs e)
        {
            seePark_btn.Enabled = false;
            comboBoxId.Enabled = false;
            sqlcon.Open();
            cmd = new SqlCommand("SELECT * FROM [dbo].[Parque] Where [nome_parque] = '" + comboBoxId.SelectedItem + "'", sqlcon);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                panelPark.Visible = true;
                learnMoreParkId = dr["id_parque"].ToString();
                labelNomePark.Text = dr["nome_parque"].ToString();
                labelParkBriefDesc.Text = dr["descricao_parque_parcial"].ToString();
                labelParkBriefDesc.MaximumSize = new Size(458, 28);
                labelParkBriefDesc.AutoSize = true;
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
                    } else
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
