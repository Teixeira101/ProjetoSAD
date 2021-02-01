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
        int[,] cTable;
        int[] cValues = new int[4];
        public List<ParkCriteria> parksList = new List<ParkCriteria>();
        int count;
        NewSimulationResults form = new NewSimulationResults();

        private Form currentChildForm;

        public NewSimulationlvl1()
        {
            InitializeComponent();

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
            } else
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
            
        }

        private void CalculateCriteriaValues()
        {
            int[,] cMultiArray = new int[cUsed, cUsed + 1];
            int[] cArray = new int[cUsed];
            int x = 0;
            int diff = 0;
            int[] tempValues = new int[cUsed];
            int sum = 0;

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
                            cMultiArray[i, y] = 1 / 3;
                            break;
                        case -2:
                            cMultiArray[i, y] = 1 / 5;
                            break;
                        case -3:
                            cMultiArray[i, y] = 1 / 7;
                            break;
                        case -4:
                            cMultiArray[i, y] = 1 / 9;
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
                    if (y == cUsed - 1)
                    {
                        tempValues[i] = (tempValues[i] * cMultiArray[i, y]) ^ (1 / cUsed);
                    } else
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
                cMultiArray[i, cUsed + 1] = tempValues[i] / sum;
            }

            cTable = cMultiArray;
            form.critArray = cMultiArray;

        }

        private void GetValuesFromParks()
        {
            SqlConnection myConnection = new SqlConnection(@"Data Source=LAPTOP-CHRF1L4J\SQLEXPRESS;Initial Catalog=dbSAD;Integrated Security=True");
            myConnection.Open();
            string oString = "SELECT COUNT(*) FROM [dbo].[Parque]";
            SqlCommand oCmd = new SqlCommand(oString, myConnection);

            count = Convert.ToInt32(oCmd.ExecuteScalar());
            
            SqlCommand tempCmd = new SqlCommand("SELECT id_parque, trained_staff, investments, productivity, partners FROM [dbo].[Parque]", myConnection);

            SqlDataReader reader = tempCmd.ExecuteReader();

            while(reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
            }

            myConnection.Close();

            form.count = count;
        }

        private void ReadSingleRow(IDataRecord record)
        {
            parksList[Convert.ToInt32(record[0])].Id = Convert.ToInt32(record[0]);
            parksList[Convert.ToInt32(record[0])].Tf = Convert.ToInt32(record[1]);
            parksList[Convert.ToInt32(record[0])].Iv = Convert.ToInt32(record[2]);
            parksList[Convert.ToInt32(record[0])].Pd = Convert.ToInt32(record[3]);
            parksList[Convert.ToInt32(record[0])].Pt = Convert.ToInt32(record[4]);
        }

        private void CompareValuesFromParks()
        {
            int[,] parksArrayTf = new int[count, count + 2];
            int[,] parksArrayIv = new int[count, count + 2];
            int[,] parksArrayPd = new int[count, count + 2];
            int[,] parksArrayPt = new int[count, count + 2];
            int[] pValueArrayTf = new int[count];
            int[] pValueArrayIv = new int[count];
            int[] pValueArrayPd = new int[count];
            int[] pValueArrayPt = new int[count];
            int sumTf = 0;
            int sumIv = 0;
            int sumPd = 0;
            int sumPt = 0;

            for (int i = 0; i < count; i++)
            {
                parksArrayTf[i, count + 2] = parksList[i].Id;
                parksArrayIv[i, count + 2] = parksList[i].Id;
                parksArrayPd[i, count + 2] = parksList[i].Id;
                parksArrayPt[i, count + 2] = parksList[i].Id;

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
                            parksArrayTf[i, y] = 1 / 3;
                            break;
                        case -2:
                            parksArrayTf[i, y] = 1 / 5;
                            break;
                        case -3:
                            parksArrayTf[i, y] = 1 / 7;
                            break;
                        case -4:
                            parksArrayTf[i, y] = 1 / 9;
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
                            parksArrayIv[i, y] = 1 / 3;
                            break;
                        case -2:
                            parksArrayIv[i, y] = 1 / 5;
                            break;
                        case -3:
                            parksArrayIv[i, y] = 1 / 7;
                            break;
                        case -4:
                            parksArrayIv[i, y] = 1 / 9;
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
                            parksArrayPd[i, y] = 1 / 3;
                            break;
                        case -2:
                            parksArrayPd[i, y] = 1 / 5;
                            break;
                        case -3:
                            parksArrayPd[i, y] = 1 / 7;
                            break;
                        case -4:
                            parksArrayPd[i, y] = 1 / 9;
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
                            parksArrayPt[i, y] = 1 / 3;
                            break;
                        case -2:
                            parksArrayPt[i, y] = 1 / 5;
                            break;
                        case -3:
                            parksArrayPt[i, y] = 1 / 7;
                            break;
                        case -4:
                            parksArrayPt[i, y] = 1 / 9;
                            break;
                    }

                }

            }

            //For Tf
            for (int i = 0; i < count; i++)
            {

                int total = 0;
                int stop = count - 1;

                for (int y = 0; y < count; y++)
                {
                    
                    if (y == 0)
                    {
                        total = parksArrayTf[i, y];
                    } else if (y == stop)
                    {
                        total = (total * parksArrayTf[i, y]) ^ (1 / count);
                        pValueArrayTf[i] = total;
                    } else
                    {
                        total = total * parksArrayTf[i, y];
                    }
                    
                }

            }

            //For Iv
            for (int i = 0; i < count; i++)
            {

                int total = 0;
                int stop = count - 1;

                for (int y = 0; y < count; y++)
                {

                    if (y == 0)
                    {
                        total = parksArrayIv[i, y];
                    }
                    else if (y == stop)
                    {
                        total = (total * parksArrayIv[i, y]) ^ (1 / count);
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

                int total = 0;
                int stop = count - 1;

                for (int y = 0; y < count; y++)
                {

                    if (y == 0)
                    {
                        total = parksArrayPd[i, y];
                    }
                    else if (y == stop)
                    {
                        total = (total * parksArrayPd[i, y]) ^ (1 / count);
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

                int total = 0;
                int stop = count - 1;

                for (int y = 0; y < count; y++)
                {

                    if (y == 0)
                    {
                        total = parksArrayPt[i, y];
                    }
                    else if (y == stop)
                    {
                        total = (total * parksArrayPt[i, y]) ^ (1 / count);
                        pValueArrayPt[i] = total;
                    }
                    else
                    {
                        total = total * parksArrayPt[i, y];
                    }

                }

            }

            //For Tf Sum
            for (int i = 0; i < count; i++)
            {

                int sum = 0;

                if (count - i == 1)
                {
                    sum = sum + pValueArrayTf[i];
                    sumTf = sum;
                }
                else
                {
                    sum = sum + pValueArrayTf[i];                   
                }

            }

            //For Iv Sum
            for (int i = 0; i < count; i++)
            {

                int sum = 0;

                if (count - i == 1)
                {
                    sum = sum + pValueArrayIv[i];
                    sumIv = sum;
                }
                else
                {
                    sum = sum + pValueArrayIv[i];
                }

            }

            //For Pd Sum
            for (int i = 0; i < count; i++)
            {

                int sum = 0;

                if (count - i == 1)
                {
                    sum = sum + pValueArrayPd[i];
                    sumPd = sum;
                }
                else
                {
                    sum = sum + pValueArrayPd[i];
                }

            }

            //For Pt Sum
            for (int i = 0; i < count; i++)
            {

                int sum = 0;

                if (count - i == 1)
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
                parksArrayTf[i, count + 1] = pValueArrayTf[i] / sumTf;
                parksArrayIv[i, count + 1] = pValueArrayIv[i] / sumIv;
                parksArrayPd[i, count + 1] = pValueArrayPd[i] / sumPd;
                parksArrayPt[i, count + 1] = pValueArrayPt[i] / sumPt;
            }

            form.pArrayTf = parksArrayTf;
            form.pArrayIv = parksArrayIv;
            form.pArrayPd = parksArrayPd;
            form.pArrayPt = parksArrayPt;

        }

        public class ParkCriteria
        {
            public int Id { get; set; }
            public int Tf { get; set; }
            public int Iv { get; set; }
            public int Pd { get; set; }
            public int Pt { get; set; }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a1.Visible = true;
            a2.Visible = false;
            a3.Visible = false;
            a4.Visible = false;
            impT.Visible = true;
            t0.Visible = true;
            t1.Visible = true;
            t2.Visible = true;
            t3.Visible = true;
            t4.Visible = true;
            t5.Visible = true;
            tb1.Visible = true;
            tb2.Visible = false;
            tb3.Visible = false;
            tb4.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            a1.Visible = false;
            a2.Visible = true;
            a3.Visible = false;
            a4.Visible = false;
            impT.Visible = true;
            t0.Visible = true;
            t1.Visible = true;
            t2.Visible = true;
            t3.Visible = true;
            t4.Visible = true;
            t5.Visible = true;
            tb1.Visible = false;
            tb2.Visible = true;
            tb3.Visible = false;
            tb4.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            a1.Visible = false;
            a2.Visible = false;
            a3.Visible = true;
            a4.Visible = false;
            impT.Visible = true;
            t0.Visible = true;
            t1.Visible = true;
            t2.Visible = true;
            t3.Visible = true;
            t4.Visible = true;
            t5.Visible = true;
            tb1.Visible = false;
            tb2.Visible = false;
            tb3.Visible = true;
            tb4.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            a1.Visible = false;
            a2.Visible = false;
            a3.Visible = false;
            a4.Visible = true;
            impT.Visible = true;
            t0.Visible = true;
            t1.Visible = true;
            t2.Visible = true;
            t3.Visible = true;
            t4.Visible = true;
            t5.Visible = true;
            tb1.Visible = false;
            tb2.Visible = false;
            tb3.Visible = false;
            tb4.Visible = true;
        }

        private void panelSimulationlvl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
