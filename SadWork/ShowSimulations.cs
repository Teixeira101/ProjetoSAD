using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SadWork
{
    public partial class ShowSimulations : Form
    {
        private Form currentChildForm;

        public static bool parkClick;
        public static string parkId;

        private string idSimulacao, park1, park2, park3, data;

        string dbParque = "Parque";
        string campoIdParque = "id_parque";
        string campoNomeParque = "nome_parque";

        string dbResultSimul = "Resultado_Simulacao";
        string campoIdResultSimul = "id_resultado_simulacao";
        string campoDataSimul = "data";

        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-CHRF1L4J\SQLEXPRESS;Initial Catalog=dbSAD;Integrated Security=True");

        public ShowSimulations()
        {
            InitializeComponent();
        }

        private void loadData_btn_Click(object sender, EventArgs e)
        {
            comboBoxId.Items.Clear();
            seeSimul_btn.Visible = true;
            sqlcon.Open();

            cmd = new SqlCommand("SELECT * FROM [dbo].[Resultado_Simulacao]", sqlcon);

            using (dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    comboBoxId.Items.Add(dr["data"].ToString());
                }

                dr.Close();
            }
            sqlcon.Close();
        }

        private void labelPark1_Click(object sender, EventArgs e)
        {
            parkClick = true;
            parkId = park1;
            currentChildForm = new ShowSimulations();
            OpenChildForm(new ParkInfo(), currentChildForm);
        }

        private void labelPark2_Click(object sender, EventArgs e)
        {
            parkClick = true;
            parkId = park2;
            currentChildForm = new ShowSimulations();
            OpenChildForm(new ParkInfo(), currentChildForm);
        }

        private void labelPark3_Click(object sender, EventArgs e)
        {
            parkClick = true;
            parkId = park3;
            currentChildForm = new ShowSimulations();
            OpenChildForm(new ParkInfo(), currentChildForm);
        }

        private void seeSimul_btn_Click(object sender, EventArgs e)
        {
            sqlcon.Open();
            cmd = new SqlCommand("SELECT * FROM [dbo].[Resultado_Simulacao] Where [data] = '" + comboBoxId.SelectedItem + "'", sqlcon);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                idSimulacao = dr["id_resultado_simulacao"].ToString();
                dr.Close();
            }

            cmd = new SqlCommand("SELECT * FROM [dbo].[Resultado_Simulacao] Where [id_resultado_simulacao] = '" + idSimulacao + "'", sqlcon);

            dr = cmd.ExecuteReader();
            if (dr.Read())
            {                
                park1 = dr["id_proposta1"].ToString();
                park2 = dr["id_proposta2"].ToString();
                park3 = dr["id_proposta3"].ToString();
                data = dr["data"].ToString();
                dr.Close();

                showSimulationDetails(dbParque, campoIdParque, park1, labelPark1, campoNomeParque);
                showSimulationDetails(dbParque, campoIdParque, park2, labelPark2, campoNomeParque);
                showSimulationDetails(dbParque, campoIdParque, park3, labelPark3, campoNomeParque);
                showSimulationDetails(dbResultSimul, campoIdResultSimul, idSimulacao, labelData, campoDataSimul);

                setImage(park1);
            }
            sqlcon.Close();
        }

        private void showSimulationDetails(string db, string campo, string var, Label lb, string campoLabel)
        {
            cmd = new SqlCommand("SELECT * FROM [dbo].[" + db + "] Where [" + campo + "] = '" + var + "'", sqlcon);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lb.Text = dr[campoLabel].ToString();
                lb.Visible = true;
                lb.MaximumSize = new Size(146, 40);
                lb.AutoSize = true;
                dr.Close();
            }
        }

        private void setImage(String parkId)
        {
            Console.Out.WriteLine(parkId);
            int a = Convert.ToInt32(parkId);
            cmd = new SqlCommand("SELECT foto_parque1 FROM [dbo].[Parque] Where [id_parque] = " + a + "", sqlcon);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                try
                {
                    byte[] img = (byte[]) dr[0];
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

        private void OpenChildForm(Form childForm, Form currentChildForm)
        {
            if (!parkClick)
            {
                currentChildForm.Close();
            }
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelShowSimul.Controls.Add(childForm);
            panelShowSimul.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

    }
}