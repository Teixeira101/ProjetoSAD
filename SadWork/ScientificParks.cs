using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SadWork
{
    public partial class ScientificParks : Form
    {
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
            bool verificado_parque = true;
            seePark_btn.Visible = true;
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
            sqlcon.Open();
            cmd = new SqlCommand("SELECT * FROM [dbo].[Parque] Where [nome_parque] = '" + comboBoxId.SelectedItem + "'", sqlcon);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                panelPark.Visible = true;
                labelNomePark.Text = dr["nome_parque"].ToString();
                labelParkBriefDesc.Text = dr["descricao_parque_parcial"].ToString();
                dr.Close();
            }
            sqlcon.Close();
        }
    }
}
