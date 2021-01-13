using System;
using System.Data.SqlClient;
using System.Diagnostics;
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
            cmd = new SqlCommand("SELECT * FROM [dbo].[Parque] ", sqlcon);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                labelNomePark.Text = dr["nome_parque"].ToString();
                labelParkArea.Text = dr["area"].ToString();
                labelParkSlogan.Text = dr["slogan"].ToString();
                labelParkSlogan.MaximumSize = new System.Drawing.Size(366, 75);
                labelParkSlogan.AutoSize = true;
                labelDescTotalPark.Text = dr["descricao_parque_total"].ToString();
                labelDescTotalPark.MaximumSize = new System.Drawing.Size(510, 150);
                labelDescTotalPark.AutoSize = true;
                labelParkWebsite.Text = dr["website"].ToString();
                dr.Close();
            }
            sqlcon.Close();
        }

        private void OpenChildForm(Form childForm, Form currentChildForm)
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
    }
}
