using System;
using System.Windows.Forms;
using static SadWork.MainPage;

namespace SadWork
{
    public partial class NewSimulationResults : Form
    {
        private Form currentChildForm;
        public int count { get; set; }
        public int[,] critArray { get; set; }
        public int[,] pArrayTf { get; set; }
        public int[,] pArrayIv { get; set; }
        public int[,] pArrayPd { get; set; }
        public int[,] pArrayPt { get; set; }
        

        public NewSimulationResults()
        {
            InitializeComponent();

            LastCalculations();
        }

        private void LastCalculations()
        {
            int[,] parksFinal = new int[count, 2];
            int[] bestPark = new int[] { 0, 0};

            for (int i = 0; i < count; i++)
            {
                parksFinal[i, 1] = pArrayTf[i, count + 1] * critArray[0, 4] + pArrayIv[i, count + 1] * critArray[1, 4] + pArrayPd[i, count + 1] * critArray[2, 4] + pArrayPt[i, count + 1] * critArray[3, 4];
                parksFinal[i, 0] = pArrayTf[i, count + 2];
            }

            for (int i = 0; i < count; i++)
            {
                if (bestPark[1] < parksFinal[i, 1])
                {
                    bestPark[0] = parksFinal[i, 0];
                    bestPark[1] = parksFinal[i, 1];
                }
            }

            //Aqui mostra o melhor parque de acordo com o método AHP

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
    }
}
