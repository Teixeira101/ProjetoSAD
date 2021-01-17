using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SadWork
{
    public partial class NewSimulationlvl1 : Form
    {
        int[,] criteriaArray = new int[4, 5];
        public List<ParkCriteria> parksList = new List<ParkCriteria>();
        int count;
        NewSimulationResults form = new NewSimulationResults();

        private Form currentChildForm;

        public NewSimulationlvl1()
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
            panelSimulationlvl1.Controls.Add(childForm);
            panelSimulationlvl1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {

            GetValuesFromForm();

            CalculateLastRows();

            GetValuesFromParks();

            CompareValuesFromParks();

            currentChildForm = new NewSimulationlvl1();
            OpenChildForm(new NewSimulationResults(), currentChildForm);
            
        }      

        private void GetValuesFromForm()
        {

            int id1;
            int.TryParse(cb1.SelectedValue.ToString(), out id1);
            int id2;
            int.TryParse(cb2.SelectedValue.ToString(), out id2);
            int id3;
            int.TryParse(cb3.SelectedValue.ToString(), out id3);
            int id4;
            int.TryParse(cb4.SelectedValue.ToString(), out id4);
            int id5;
            int.TryParse(cb5.SelectedValue.ToString(), out id5);
            int id6;
            int.TryParse(cb6.SelectedValue.ToString(), out id6);

            criteriaArray[0, 0] = 1;
            criteriaArray[0, 1] = GetFirst(id1, b1.Checked); 
            criteriaArray[0, 2] = GetFirst(id2, b2.Checked);            
            criteriaArray[0, 3] = GetFirst(id3, b3.Checked);
            criteriaArray[1, 0] = GetSecond(id1, b1.Checked);
            criteriaArray[1, 1] = 1;
            criteriaArray[1, 2] = GetFirst(id4, b4.Checked);
            criteriaArray[1, 3] = GetFirst(id5, b5.Checked);
            criteriaArray[2, 0] = GetSecond(id2, b2.Checked);
            criteriaArray[2, 1] = GetSecond(id4, b4.Checked);
            criteriaArray[2, 2] = 1;            
            criteriaArray[2, 3] = GetFirst(id6, b6.Checked);
            criteriaArray[3, 0] = GetSecond(id3, b3.Checked);
            criteriaArray[3, 1] = GetSecond(id5, b5.Checked);
            criteriaArray[3, 2] = GetSecond(id6, b6.Checked);
            criteriaArray[3, 3] = 1;

        }

        private int GetFirst(int cb, bool b)
        {
            int x;
            if (!b)
            {                             
                switch (cb)
                {
                    case 0:
                        x = 1;                      
                        break;
                    case 1:
                        x = 3;
                        break;
                    case 2:
                        x = 5;
                        break;
                    case 3:
                        x = 7;
                        break;
                    case 4:
                        x = 9;
                        break;
                    default:
                        x = 1;
                        break;
                }
            }
            else
            {
                switch (cb)
                {
                    case 0:
                        x = 1;
                        break;
                    case 1:
                        x = 1 / 3;
                        break;
                    case 2:
                        x = 1 / 5;
                        break;
                    case 3:
                        x = 1 / 7;
                        break;
                    case 4:
                        x = 1 / 9;
                        break;
                    default:
                        x = 1;
                        break;
                }
            }
            return x;
        }

        private int GetSecond(int cb, bool b)
        {
            int x;
            if (!b)
            {
                switch (cb)
                {
                    case 0:
                        x = 1;
                        break;
                    case 1:
                        x = 1 / 3;
                        break;
                    case 2:
                        x = 1 / 5;
                        break;
                    case 3:
                        x = 1 / 7;
                        break;
                    case 4:
                        x = 1 / 9;
                        break;
                    default:
                        x = 1;
                        break;
                }
            }
            else
            {
                switch (cb)
                {
                    case 0:
                        x = 1;
                        break;
                    case 1:
                        x = 3;
                        break;
                    case 2:
                        x = 5;
                        break;
                    case 3:
                        x = 7;
                        break;
                    case 4:
                        x = 9;
                        break;
                    default:
                        x = 1;
                        break;
                }
            }
            return x;
        }

        private void CalculateLastRows()
        {

            int v1 = (criteriaArray[0, 0] * criteriaArray[0, 1] * criteriaArray[0, 2] * criteriaArray[0, 3]) ^ (1 / 4);
            int v2 = (criteriaArray[1, 0] * criteriaArray[1, 1] * criteriaArray[1, 2] * criteriaArray[1, 3]) ^ (1 / 4);
            int v3 = (criteriaArray[2, 0] * criteriaArray[2, 1] * criteriaArray[2, 2] * criteriaArray[2, 3]) ^ (1 / 4);
            int v4 = (criteriaArray[3, 0] * criteriaArray[3, 1] * criteriaArray[3, 2] * criteriaArray[3, 3]) ^ (1 / 4);

            int sum = v1 + v2 + v3 + v4;

            criteriaArray[0, 4] = v1 / sum;
            criteriaArray[1, 4] = v2 / sum;
            criteriaArray[2, 4] = v3 / sum;
            criteriaArray[3, 4] = v4 / sum;

            form.critArray = criteriaArray;

        }

        private int NumberOfParks()
        {
            int x = 0;
            return x;
        }

        private void GetValuesFromParks()
        {
            SqlConnection myConnection = new SqlConnection(@"Data Source=LAPTOP-CHRF1L4J\SQLEXPRESS;Initial Catalog=dbSAD;Integrated Security=True");
            myConnection.Open();
            string oString = "SELECT COUNT(*) FROM Parks";
            SqlCommand oCmd = new SqlCommand(oString, myConnection);

            count = Convert.ToInt32(oCmd.ExecuteScalar());
            
            SqlCommand tempCmd = new SqlCommand("SELECT id, trained_staff, investments, productivity, partners FROM Parks", myConnection);

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
                        total = (total * parksArrayTf[i, y]) * 1 / count;
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
                        total = (total * parksArrayIv[i, y]) * 1 / count;
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
                        total = (total * parksArrayPd[i, y]) * 1 / count;
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
                        total = (total * parksArrayPt[i, y]) * 1 / count;
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

        

        private void panelSimulationlvl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
