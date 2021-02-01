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
        public int count { get; set; }
        public int[] cC { get; set; }
        public int[,] critArray { get; set; }
        public int[,] pArrayTf { get; set; }
        public int[,] pArrayIv { get; set; }
        public int[,] pArrayPd { get; set; }
        public int[,] pArrayPt { get; set; }
        int[] bestPark = new int[] { 0, 0 };
        int[] bestPark2 = new int[] { 0, 0 };
        int[] bestPark3 = new int[] { 0, 0 };
        public List<ParkCriteria> parksList = new List<ParkCriteria>();


        public NewSimulationResults()
        {
            InitializeComponent();

            LastCalculations();
        }

        private void LastCalculations()
        {
            int[,] parksFinal = new int[count, 2];
            
            int x = 0;

            if (cC[0] > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    parksFinal[i, 1] = parksFinal[i, 1] + (pArrayTf[i, count + 1] * critArray[x, 4]);
                    parksFinal[i, 0] = pArrayTf[i, count + 2];
                }
                x = x + 1;
            }

            if (cC[1] > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    parksFinal[i, 1] = parksFinal[i, 1] + (pArrayIv[i, count + 1] * critArray[x, 4]);
                    parksFinal[i, 0] = pArrayIv[i, count + 2];
                }
                x = x + 1;
            }

            if (cC[2] > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    parksFinal[i, 1] = parksFinal[i, 1] + (pArrayPd[i, count + 1] * critArray[x, 4]);
                    parksFinal[i, 0] = pArrayPd[i, count + 2];
                }
                x = x + 1;
            }

            if (cC[3] > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    parksFinal[i, 1] = parksFinal[i, 1] + (pArrayPt[i, count + 1] * critArray[x, 4]);
                    parksFinal[i, 0] = pArrayPt[i, count + 2];
                }
            }
            /*
            for (int i = 0; i < count; i++)
            {
                parksFinal[i, 1] = pArrayTf[i, count + 1] * critArray[0, 4] + pArrayIv[i, count + 1] * critArray[1, 4] + pArrayPd[i, count + 1] * critArray[2, 4] + pArrayPt[i, count + 1] * critArray[3, 4];
                parksFinal[i, 0] = pArrayTf[i, count + 2];
            }
            */
            for (int i = 0; i < count; i++)
            {
                if (bestPark[1] < parksFinal[i, 1])
                {
                    bestPark[0] = parksFinal[i, 0];
                    bestPark[1] = parksFinal[i, 1];
                }
                else if (bestPark2[1] < parksFinal[i, 1])
                {
                    bestPark2[0] = parksFinal[i, 0];
                    bestPark2[1] = parksFinal[i, 1];
                }
                else if (bestPark3[1] < parksFinal[i, 1])
                {
                    bestPark3[0] = parksFinal[i, 0];
                    bestPark3[1] = parksFinal[i, 1];
                }
            }


            //Aqui mostra o melhor parque de acordo com o método AHP

            GetValuesFromParks();

        }

        private void GetValuesFromParks()
        {
            SqlConnection myConnection = new SqlConnection(@"Data Source=LAPTOP-CHRF1L4J\SQLEXPRESS;Initial Catalog=dbSAD;Integrated Security=True");
            myConnection.Open();
            

            SqlCommand tempCmd = new SqlCommand("SELECT id_parque, trained_staff, investments, productivity, partners FROM [dbo].[Parque] WHERE id_parque=" + bestPark[1] + " OR id_parque=" + bestPark2[1] + " OR id_parque=" + bestPark3[1], myConnection);

            SqlDataReader reader = tempCmd.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
            }

            myConnection.Close();
            
        }

        private void ReadSingleRow(IDataRecord record)
        {
            parksList[Convert.ToInt32(record[0])].Id = Convert.ToInt32(record[0]);
            parksList[Convert.ToInt32(record[0])].Tf = Convert.ToInt32(record[1]);
            parksList[Convert.ToInt32(record[0])].Iv = Convert.ToInt32(record[2]);
            parksList[Convert.ToInt32(record[0])].Pd = Convert.ToInt32(record[3]);
            parksList[Convert.ToInt32(record[0])].Pt = Convert.ToInt32(record[4]);
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
            public int Tf { get; set; }
            public int Iv { get; set; }
            public int Pd { get; set; }
            public int Pt { get; set; }
        }
    }
}
