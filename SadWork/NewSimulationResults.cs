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
            } else
            {
                Console.Out.WriteLine("NULO");
            }
        }

        private void LastCalculations()
        {
            Console.Out.WriteLine("ENTROU NO LASTCALCULATIONS");
            double[,] parksFinal = new double[count, 2];

            int x = 0;
            Console.Out.WriteLine("pArrayTf: " + pArrayTf[0, count]);
            Console.Out.WriteLine("pArrayIv: " + pArrayIv[0, count]);
            Console.Out.WriteLine("pArrayPd: " + pArrayPd[0, count]);
            Console.Out.WriteLine("pArrayPt: " + pArrayPt[0, count]);

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

            PopulateForm();

        }

        private void GetValuesFromParks()
        {
            Console.Out.WriteLine("BEST PARK 1: " + bestPark[0]);
            Console.Out.WriteLine("BEST PARK 2: " + bestPark2[0]);
            Console.Out.WriteLine("BEST PARK 3: " + bestPark3[0]);

            SqlConnection myConnection = new SqlConnection(@"Data Source=LAPTOP-CHRF1L4J\SQLEXPRESS;Initial Catalog=dbSAD;Integrated Security=True");
            myConnection.Open();

            SqlCommand tempCmd = new SqlCommand("SELECT id_parque, trained_staff, investments, productivity, partners FROM [dbo].[Parque] WHERE id_parque = 2", myConnection);

            SqlDataReader reader = tempCmd.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
            }

            myConnection.Close();

        }

        private void PopulateForm()
        {
            ID.Text = parksList[0].Id.ToString();
            TF.Text = parksList[0].Tf.ToString();
            IV.Text = parksList[0].Iv.ToString();
            PD.Text = parksList[0].Pd.ToString();
            PT.Text = parksList[0].Pt.ToString();
        }

        private void ReadSingleRow(IDataRecord record)
        {
            parksList.Add(new ParkCriteria{
                Id = Convert.ToInt32(record[0]),
                Tf = Convert.ToInt32(record[1]),
                Iv = Convert.ToInt32(record[2]),
                Pd = Convert.ToInt32(record[3]),
                Pt = Convert.ToInt32(record[4])
            });
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
