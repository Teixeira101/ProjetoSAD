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
            DoubleBuffered = true;
            loadSimulations();
        }

        private void loadSimulations()
        {
            comboBoxId.Items.Clear();
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

        private void park1_btn_Click(object sender, EventArgs e)
        {
            parkClick = true;
            parkId = park1;
            currentChildForm = new ShowSimulations();
            OpenChildForm(new ParkInfo(), currentChildForm);
        }

        private void park2_btn_Click(object sender, EventArgs e)
        {
            parkClick = true;
            parkId = park2;
            currentChildForm = new ShowSimulations();
            OpenChildForm(new ParkInfo(), currentChildForm);
        }

        private void park3_btn_Click(object sender, EventArgs e)
        {
            parkClick = true;
            parkId = park3;
            currentChildForm = new ShowSimulations();
            OpenChildForm(new ParkInfo(), currentChildForm);
        }

        private void comboBoxId_SelectionChangeCommitted(object sender, EventArgs e)
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


                setImage(park1, pictureBox1);
                setImage(park2, pictureBox2);
                setImage(park3, pictureBox3);

                tituloDate.Visible = true;
                titulopark1.Visible = true;
                titulopark2.Visible = true;
                titulopark3.Visible = true;
                labelData.Visible = true;
                labelPark1.Visible = true;
                labelPark2.Visible = true;
                labelPark3.Visible = true;
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                park1_btn.Visible = true;
                park2_btn.Visible = true;
                park3_btn.Visible = true;
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
                lb.MaximumSize = new Size(150, 40);
                lb.AutoSize = true;
                dr.Close();
            }
        }

        private void setImage(String parkId, PictureBox pc)
        {
            dr.Close();
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
                        pc.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        pc.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception) { }
            }
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