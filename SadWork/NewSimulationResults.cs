using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static SadWork.MainPage;

namespace SadWork
{
    public partial class NewSimulationResults : Form
    {
        private Form currentChildForm;
        public static int count { get; set; }
        public static int cUsed { get; set; }
        public static int[] cC { get; set; }
        public static double[,] critArray { get; set; }
        public static double[,] pArrayTf { get; set; }
        public static double[,] pArrayIv { get; set; }
        public static double[,] pArrayPd { get; set; }
        public static double[,] pArrayPt { get; set; }
        double[] bestPark = new double[] { 0, 0 };
        double[] bestPark2 = new double[] { 0, 0 };
        double[] bestPark3 = new double[] { 0, 0 };
        public List<ParkCriteria> parksList = new List<ParkCriteria>();


        public NewSimulationResults()
        {
            InitializeComponent();

            if (cC != null)
            {
                LastCalculations();
            }
        }

        private void LastCalculations()
        {
            double[,] parksFinal = new double[count, 2];

            int x = 0;

            if (cC[0] > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    parksFinal[i, 1] = parksFinal[i, 1] + (pArrayTf[i, count] * critArray[x, cUsed]);
                    parksFinal[i, 0] = pArrayTf[i, count + 1];
                }
                x = x + 1;
            }

            if (cC[1] > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    parksFinal[i, 1] = parksFinal[i, 1] + (pArrayIv[i, count] * critArray[x, cUsed]);
                    parksFinal[i, 0] = pArrayIv[i, count + 1];
                }
                x = x + 1;
            }

            if (cC[2] > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    parksFinal[i, 1] = parksFinal[i, 1] + (pArrayPd[i, count] * critArray[x, cUsed]);
                    parksFinal[i, 0] = pArrayPd[i, count + 1];
                }
                x = x + 1;
            }

            if (cC[3] > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    parksFinal[i, 1] = parksFinal[i, 1] + (pArrayPt[i, count] * critArray[x, cUsed]);
                    parksFinal[i, 0] = pArrayPt[i, count + 1];
                }
            }

            //Best Park 1
            for (int i = 0; i < count; i++)
            {

                if (bestPark[1] < parksFinal[i, 1])
                {
                    bestPark[0] = parksFinal[i, 0];
                    bestPark[1] = parksFinal[i, 1];
                }
            }

            //Best Park 2
            for (int i = 0; i < count; i++)
            {

                if (bestPark2[1] < parksFinal[i, 1])
                {
                    if (parksFinal[i, 0] != bestPark[0])
                    {
                        bestPark2[0] = parksFinal[i, 0];
                        bestPark2[1] = parksFinal[i, 1];
                    }
                }
            }

            //Best Park 3
            for (int i = 0; i < count; i++)
            {

                if (bestPark3[1] < parksFinal[i, 1])
                {
                    if (parksFinal[i, 0] != bestPark[0] && parksFinal[i, 0] != bestPark2[0])
                    {
                        bestPark3[0] = parksFinal[i, 0];
                        bestPark3[1] = parksFinal[i, 1];
                    }
                }
            }


            //Aqui mostra o melhor parque de acordo com o método AHP

            GetValuesFromParks();

            PopulateForm(area, nome, localizacao, 0);
            PopulateForm(area2, nome2, localizacao2, 1);
            PopulateForm(area3, nome3, localizacao3, 2);

        }

        private void GetValuesFromParks()
        {
            Console.Out.WriteLine("BEST PARK 1 FINAL: " + bestPark[0]);
            Console.Out.WriteLine("BEST PARK 2 FINAL: " + bestPark2[0]);
            Console.Out.WriteLine("BEST PARK 3 FINAL: " + bestPark3[0]);

            SqlConnection myConnection = new SqlConnection(@"Data Source=LAPTOP-CHRF1L4J\SQLEXPRESS;Initial Catalog=dbSAD;Integrated Security=True");
            myConnection.Open();

            SqlCommand tempCmd = new SqlCommand("SELECT id_parque, nome_parque, area, localizacao_parque FROM [dbo].[Parque] WHERE id_parque = '" + bestPark[0] + "' OR id_parque = '" + bestPark2[0] + "' OR id_parque = '" + bestPark3[0] + "'", myConnection);

            SqlDataReader reader = tempCmd.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
            }

            myConnection.Close();

        }

        private void ReadSingleRow(IDataRecord record)
        {
            parksList.Add(new ParkCriteria
            {
                Id = Convert.ToInt32(record[0]),
                nome = Convert.ToString(record[1]),
                area = Convert.ToString(record[2]),
                localizacao = Convert.ToString(record[3])
            });
        }

        private void PopulateForm(Label nomeFun, Label areaFun, Label localizacaoFun, int index)
        {
            nomeFun.Text = parksList[index].nome.ToString();
            areaFun.Text = parksList[index].area.ToString();
            localizacaoFun.Text = parksList[index].localizacao.ToString();
        }

        private void OpenChildForm(Form childForm, Form currentChildForm)
        {
            currentChildForm.Close();
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelNewSimulResults.Controls.Add(childForm);
            panelNewSimulResults.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void iconButtonLearnMore1_Click(object sender, EventArgs e)
        {
            currentChildForm = new NewSimulationResults();
            OpenChildForm(new ParkInfo(), currentChildForm);
        }

        private void iconButtonLearnMore2_Click(object sender, EventArgs e)
        {
            currentChildForm = new NewSimulationResults();
            OpenChildForm(new ParkInfo(), currentChildForm);
        }

        private void iconButtonLearnMore3_Click(object sender, EventArgs e)
        {
            currentChildForm = new NewSimulationResults();
            OpenChildForm(new ParkInfo(), currentChildForm);
        }

        public class ParkCriteria
        {
            public int Id { get; set; }
            public String nome { get; set; }
            public String area { get; set; }
            public String localizacao { get; set; }
        }
    }
}
