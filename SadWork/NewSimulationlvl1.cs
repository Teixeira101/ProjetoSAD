using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SadWork
{
    public partial class NewSimulationlvl1 : Form
    {
        int cUsed = 0;
        double[,] cTable;
        int[] cValues = new int[4];
        public List<ParkCriteria> parksList = new List<ParkCriteria>();
        int count;

        private Form currentChildForm;

        public NewSimulationlvl1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            
            tb1.Orientation = Orientation.Vertical;
        }

        private void OpenChildForm(Form childForm, Form currentChildForm)
        {
            currentChildForm.Close();
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelSimulationlvl1.Controls.Add(childForm);
            panelSimulationlvl1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            GetCriteriaValues();

            CalculateCriteriaValues();

            GetValuesFromParks();

            CompareValuesFromParks();

            currentChildForm = new NewSimulationlvl1();
            OpenChildForm(new NewSimulationResults(), currentChildForm);

        }

        private void GetCriteriaValues()
        {
            if (tb1.Value == 0)
            {
                cValues[0] = tb1.Value;
            }
            else
            {
                cValues[0] = tb1.Value;
                cUsed = cUsed + 1;
            }

            if (tb2.Value == 0)
            {
                cValues[1] = tb2.Value;
            }
            else
            {
                cValues[1] = tb2.Value;
                cUsed = cUsed + 1;
            }

            if (tb3.Value == 0)
            {
                cValues[2] = tb3.Value;
            }
            else
            {
                cValues[2] = tb3.Value;
                cUsed = cUsed + 1;
            }

            if (tb4.Value == 0)
            {
                cValues[3] = tb4.Value;
            }
            else
            {
                cValues[3] = tb4.Value;
                cUsed = cUsed + 1;
            }

            NewSimulationResults.cUsed = cUsed;

        }

        private void CalculateCriteriaValues()
        {
            double[,] cMultiArray = new double[cUsed, cUsed + 1];
            double[] cArray = new double[cUsed];
            int x = 0;
            double diff = 0.0;
            double[] tempValues = new double[cUsed];
            double sum = 0.0;

            for (int i = 0; i < cValues.Length; i++)
            {
                if (cValues[i] != 0)
                {
                    cArray[x] = cValues[i];
                    x = x + 1;
                }
            }

            for (int i = 0; i < cUsed; i++)
            {
                for (int y = 0; y < cUsed; y++)
                {
                    diff = cArray[i] - cArray[y];

                    switch (diff)
                    {
                        case 4:
                            cMultiArray[i, y] = 9;
                            break;
                        case 3:
                            cMultiArray[i, y] = 7;
                            break;
                        case 2:
                            cMultiArray[i, y] = 5;
                            break;
                        case 1:
                            cMultiArray[i, y] = 3;
                            break;
                        case 0:
                            cMultiArray[i, y] = 1;
                            break;
                        case -1:
                            cMultiArray[i, y] = (double)1 / (double)3;
                            break;
                        case -2:
                            cMultiArray[i, y] = (double)1 / (double)5;
                            break;
                        case -3:
                            cMultiArray[i, y] = (double)1 / (double)7;
                            break;
                        case -4:
                            cMultiArray[i, y] = (double)1 / (double)9;
                            break;
                        default:
                            cMultiArray[i, y] = 1;
                            break;
                    }
                }
            }

            for (int i = 0; i < cUsed; i++)
            {
                for (int y = 0; y < cUsed; y++)
                {
                    if (y == 0)
                    {
                        tempValues[i] = cMultiArray[i, y];
                    }
                    else if (y == cUsed - 1)
                    {
                        tempValues[i] = Math.Pow(tempValues[i] * cMultiArray[i, y], (double)1 / (double)cUsed);
                    }
                    else
                    {
                        tempValues[i] = tempValues[i] * cMultiArray[i, y];
                    }
                }
            }

            for (int i = 0; i < cUsed; i++)
            {
                sum = sum + tempValues[i];
            }

            for (int i = 0; i < cUsed; i++)
            {
                cMultiArray[i, cUsed] = tempValues[i] / sum;
            }

            cTable = cMultiArray;
            NewSimulationResults.critArray = cMultiArray;
            NewSimulationResults.cC = cValues;

        }

        private void GetValuesFromParks()
        {
            bool verificado_parque = true;
            SqlConnection myConnection = new SqlConnection(@"Data Source=46.101.41.99;Initial Catalog=dbSAD;User ID=SA;Password=Grupo1sad");
            myConnection.Open();
            string oString = "SELECT COUNT(*) FROM [dbo].[Parque]";
            SqlCommand oCmd = new SqlCommand(oString, myConnection);

            count = Convert.ToInt32(oCmd.ExecuteScalar());

            SqlCommand tempCmd = new SqlCommand("SELECT id_parque, trained_staff, investments, productivity, partners FROM [dbo].[Parque] Where [verificado_parque] = '" + verificado_parque + "'", myConnection);

            SqlDataReader reader = tempCmd.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
            }
            myConnection.Close();

            NewSimulationResults.count = count;
        }


        private void ReadSingleRow(IDataRecord record)
        {
            parksList.Add(new ParkCriteria { 
                Id = Convert.ToInt32(record[0]), 
                Tf = Convert.ToInt32(record[1]), 
                Iv = Convert.ToInt32(record[2]), 
                Pd = Convert.ToInt32(record[3]), 
                Pt = Convert.ToInt32(record[4]) 
            });
        }

        private void CompareValuesFromParks()
        {
            double[,] parksArrayTf = new double[count, count + 2];
            double[,] parksArrayIv = new double[count, count + 2];
            double[,] parksArrayPd = new double[count, count + 2];
            double[,] parksArrayPt = new double[count, count + 2];
            double[] pValueArrayTf = new double[count];
            double[] pValueArrayIv = new double[count];
            double[] pValueArrayPd = new double[count];
            double[] pValueArrayPt = new double[count];
            double sumTf = 0;
            double sumIv = 0;
            double sumPd = 0;
            double sumPt = 0;

            for (int i = 0; i < count; i++)
            {
                parksArrayTf[i, count + 1] = parksList[i].Id;
                parksArrayIv[i, count + 1] = parksList[i].Id;
                parksArrayPd[i, count + 1] = parksList[i].Id;
                parksArrayPt[i, count + 1] = parksList[i].Id;
            }

            for (int i = 0; i < count; i++)
            {
                for (int y = 0; y < count; y++)
                {

                    int difTf = parksList[i].Tf - parksList[y].Tf;
                    int difIv = parksList[i].Iv - parksList[y].Iv;
                    int difPd = parksList[i].Pd - parksList[y].Pd;
                    int difPt = parksList[i].Pt - parksList[y].Pt;

                    switch (difTf)
                    {
                        case 4:
                            parksArrayTf[i, y] = 9;
                            break;
                        case 3:
                            parksArrayTf[i, y] = 7;
                            break;
                        case 2:
                            parksArrayTf[i, y] = 5;
                            break;
                        case 1:
                            parksArrayTf[i, y] = 3;
                            break;
                        case 0:
                            parksArrayTf[i, y] = 1;
                            break;
                        case -1:
                            parksArrayTf[i, y] = (double)1 / (double)3;
                            break;
                        case -2:
                            parksArrayTf[i, y] = (double)1 / (double)5;
                            break;
                        case -3:
                            parksArrayTf[i, y] = (double)1 / (double)7;
                            break;
                        case -4:
                            parksArrayTf[i, y] = (double)1 / (double)9;
                            break;
                        default:
                            parksArrayTf[i, y] = 1;
                            break;
                    }

                    switch (difIv)
                    {
                        case 4:
                            parksArrayIv[i, y] = 9;
                            break;
                        case 3:
                            parksArrayIv[i, y] = 7;
                            break;
                        case 2:
                            parksArrayIv[i, y] = 5;
                            break;
                        case 1:
                            parksArrayIv[i, y] = 3;
                            break;
                        case 0:
                            parksArrayIv[i, y] = 1;
                            break;
                        case -1:
                            parksArrayIv[i, y] = (double)1 / (double)3;
                            break;
                        case -2:
                            parksArrayIv[i, y] = (double)1 / (double)5;
                            break;
                        case -3:
                            parksArrayIv[i, y] = (double)1 / (double)7;
                            break;
                        case -4:
                            parksArrayIv[i, y] = (double)1 / (double)9;
                            break;
                        default:
                            parksArrayTf[i, y] = 1;
                            break;
                    }

                    switch (difPd)
                    {
                        case 4:
                            parksArrayPd[i, y] = 9;
                            break;
                        case 3:
                            parksArrayPd[i, y] = 7;
                            break;
                        case 2:
                            parksArrayPd[i, y] = 5;
                            break;
                        case 1:
                            parksArrayPd[i, y] = 3;
                            break;
                        case 0:
                            parksArrayPd[i, y] = 1;
                            break;
                        case -1:
                            parksArrayPd[i, y] = (double)1 / (double)3;
                            break;
                        case -2:
                            parksArrayPd[i, y] = (double)1 / (double)5;
                            break;
                        case -3:
                            parksArrayPd[i, y] = (double)1 / (double)7;
                            break;
                        case -4:
                            parksArrayPd[i, y] = (double)1 / (double)9;
                            break;
                        default:
                            parksArrayTf[i, y] = 1;
                            break;
                    }

                    switch (difPt)
                    {
                        case 4:
                            parksArrayPt[i, y] = 9;
                            break;
                        case 3:
                            parksArrayPt[i, y] = 7;
                            break;
                        case 2:
                            parksArrayPt[i, y] = 5;
                            break;
                        case 1:
                            parksArrayPt[i, y] = 3;
                            break;
                        case 0:
                            parksArrayPt[i, y] = 1;
                            break;
                        case -1:
                            parksArrayPt[i, y] = (double)1 / (double)3;
                            break;
                        case -2:
                            parksArrayPt[i, y] = (double)1 / (double)5;
                            break;
                        case -3:
                            parksArrayPt[i, y] = (double)1 / (double)7;
                            break;
                        case -4:
                            parksArrayPt[i, y] = (double)1 / (double)9;
                            break;
                        default:
                            parksArrayTf[i, y] = 1;
                            break;
                    }

                }

            }

            double total = 0.0;
            int stop = count - 1;

            //For Tf
            for (int i = 0; i < count; i++)
            {

                total = 0.0;

                for (int y = 0; y < count; y++)
                {

                    if (y == 0)
                    {
                        total = parksArrayTf[i, y];
                    }
                    else if (y == stop)
                    {
                        total = Math.Pow(total * parksArrayTf[i, y], (double)1 / (double)count);
                        pValueArrayTf[i] = total;
                    }
                    else
                    {
                        total = total * parksArrayTf[i, y];
                    }

                }

            }

            //For Iv
            for (int i = 0; i < count; i++)
            {

                total = 0;

                for (int y = 0; y < count; y++)
                {

                    if (y == 0)
                    {
                        total = parksArrayIv[i, y];
                    }
                    else if (y == stop)
                    {
                        total = Math.Pow(total * parksArrayIv[i, y], ((double)1 / (double)count));
                        pValueArrayIv[i] = total;
                    }
                    else
                    {
                        total = total * parksArrayIv[i, y];
                    }

                }

            }

            //For Pd
            for (int i = 0; i < count; i++)
            {

                total = 0;

                for (int y = 0; y < count; y++)
                {

                    if (y == 0)
                    {
                        total = parksArrayPd[i, y];
                    }
                    else if (y == stop)
                    {
                        total = Math.Pow((total * parksArrayPd[i, y]), ((double)1 / (double)count));
                        pValueArrayPd[i] = total;
                    }
                    else
                    {
                        total = total * parksArrayPd[i, y];
                    }

                }

            }

            //For Pt
            for (int i = 0; i < count; i++)
            {

                total = 0;

                for (int y = 0; y < count; y++)
                {

                    if (y == 0)
                    {
                        total = parksArrayPt[i, y];
                    }
                    else if (y == stop)
                    {
                        total = Math.Pow((total * parksArrayPt[i, y]), ((double)1 / (double)count));
                        pValueArrayPt[i] = total;
                    }
                    else
                    {
                        total = total * parksArrayPt[i, y];
                    }

                }

            }

            double sum = 0.0;

            //For Tf Sum
            for (int i = 0; i < count; i++)
            {

                if (i == stop)
                {
                    sum = sum + pValueArrayTf[i];
                    sumTf = sum;
                }
                else
                {
                    sum = sum + pValueArrayTf[i];
                }

            }

            sum = 0.0;
            //For Iv Sum
            for (int i = 0; i < count; i++)
            {

                if (i == stop)
                {
                    sum = sum + pValueArrayIv[i];
                    sumIv = sum;
                }
                else
                {
                    sum = sum + pValueArrayIv[i];
                }

            }

            sum = 0.0;
            //For Pd Sum
            for (int i = 0; i < count; i++)
            {

                if (i == stop)
                {
                    sum = sum + pValueArrayPd[i];
                    sumPd = sum;
                }
                else
                {
                    sum = sum + pValueArrayPd[i];
                }

            }

            sum = 0.0;
            //For Pt Sum
            for (int i = 0; i < count; i++)
            {

                if (i == stop)
                {
                    sum = sum + pValueArrayPt[i];
                    sumPt = sum;
                }
                else
                {
                    sum = sum + pValueArrayPt[i];
                }

            }


            //For Final Values
            for (int i = 0; i < count; i++)
            {
                parksArrayTf[i, count] = pValueArrayTf[i] / sumTf;
                parksArrayIv[i, count] = pValueArrayIv[i] / sumIv;
                parksArrayPd[i, count] = pValueArrayPd[i] / sumPd;
                parksArrayPt[i, count] = pValueArrayPt[i] / sumPt;
            }

            NewSimulationResults.pArrayTf = parksArrayTf;
            NewSimulationResults.pArrayIv = parksArrayIv;
            NewSimulationResults.pArrayPd = parksArrayPd;
            NewSimulationResults.pArrayPt = parksArrayPt;

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
