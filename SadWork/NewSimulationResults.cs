using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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

        SqlConnection myConnection = new SqlConnection(@"Data Source=LAPTOP-CHRF1L4J\SQLEXPRESS;Initial Catalog=dbSAD;Integrated Security=True");
        SqlCommand tempCmd;
        SqlDataReader reader;


        public NewSimulationResults()
        {
            InitializeComponent();
            DoubleBuffered = true;

            if (cC != null)
            {
                LastCalculations();

                AddSimulationdb();
            }

        }

        private void AddSimulationdb()
        {
            SqlConnection myConnection = new SqlConnection(@"Data Source=LAPTOP-CHRF1L4J\SQLEXPRESS;Initial Catalog=dbSAD;Integrated Security=True");
            myConnection.Open();

            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Resultado_Simulacao]
               ([id_proposta1]
               ,[id_proposta2]
               ,[id_proposta3]
               ,[id_empresa]
               ,[data])
         VALUES
               ('" + bestPark[0] + "', '" + bestPark2[0] + "', '" + bestPark3[0] + "', '" + LoginPage.currentUserId + "', '" + DateTime.Now.ToString() +  "')", myConnection);

            cmd.ExecuteNonQuery();

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

            PopulateForm(nome, area, localizacao, 0);
            PopulateForm(nome2, area2, localizacao2, 1);
            PopulateForm(nome3, area2, localizacao3, 2);

        }

        private void GetValuesFromParks()
        {
            Console.Out.WriteLine("BEST PARK 1 FINAL: " + bestPark[0]);
            Console.Out.WriteLine("BEST PARK 2 FINAL: " + bestPark2[0]);
            Console.Out.WriteLine("BEST PARK 3 FINAL: " + bestPark3[0]);
            
            myConnection.Open();

            setCamps(bestPark);
            setCamps(bestPark2);
            setCamps(bestPark3);


            setImages("foto_parque1", bestPark, pictureBox1);
            setImages("foto_parque1", bestPark2, pictureBox2);
            setImages("foto_parque1", bestPark3, pictureBox3);

            myConnection.Close();

        }

        private void setCamps(double[] park)
        {

            tempCmd = new SqlCommand("SELECT id_parque, nome_parque, area, localizacao_parque FROM [dbo].[Parque] WHERE id_parque = '" + park[0] +  "'", myConnection);

            reader = tempCmd.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
            }

            reader.Close();
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

        private void setImages(String var, double[] parkArray, PictureBox pc)
        {
            reader.Close();

            tempCmd = new SqlCommand("SELECT " + var + " FROM [dbo].[Parque] Where id_parque = '" + parkArray[0] + "'", myConnection);
            reader = tempCmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                try
                {
                    byte[] img = (byte[])reader[0];
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

        private void PopulateForm(Label nomeFun, Label areaFun, Label localizacaoFun, int index)
        {
            nomeFun.Text = parksList[index].nome.ToString();
            areaFun.Text = parksList[index].area.ToString();
            localizacaoFun.Text = parksList[index].localizacao.ToString();
            localizacaoFun.MaximumSize = new Size(260, 26);
            localizacaoFun.AutoSize = true;
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
