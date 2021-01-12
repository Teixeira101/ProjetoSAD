using System;
using System.Windows.Forms;
using static SadWork.MainPage;

namespace SadWork
{
    public partial class NewSimulationResults : Form
    {
        private Form currentChildForm;

        public NewSimulationResults()
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
            panelNewSimulResults.Controls.Add(childForm);
            panelNewSimulResults.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void iconButtonLearnMore1_Click(object sender, EventArgs e)
        {
            currentChildForm = new NewSimulationResults();
            OpenChildForm(new NewSimulationlvl2(), currentChildForm);
        }

        private void iconButtonLearnMore2_Click(object sender, EventArgs e)
        {
            currentChildForm = new NewSimulationResults();
            OpenChildForm(new NewSimulationlvl2(), currentChildForm);
        }

        private void iconButtonLearnMore3_Click(object sender, EventArgs e)
        {
            currentChildForm = new NewSimulationResults();
            OpenChildForm(new NewSimulationlvl2(), currentChildForm);
        }
    }
}
