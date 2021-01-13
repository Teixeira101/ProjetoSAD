using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SadWork
{
    public partial class ShowSimulations : Form
    {
        private string idSimulacao, area, park1, park2, park3, data;

        string dbAreas = "Areas";
        string campoIdArea = "id_area";
        string campoArea = "area";

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
                area = dr["area"].ToString();
                data = dr["data"].ToString();
                dr.Close();

                showSimulationDetails(dbAreas, campoIdArea, area, labelArea, campoArea);
                showSimulationDetails(dbParque, campoIdParque, park1, labelPark1, campoNomeParque);
                showSimulationDetails(dbParque, campoIdParque, park2, labelPark2, campoNomeParque);
                showSimulationDetails(dbParque, campoIdParque, park3, labelPark3, campoNomeParque);
                showSimulationDetails(dbResultSimul, campoIdResultSimul, idSimulacao, labelData, campoDataSimul);
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
                dr.Close();
            }
        }
    }
}