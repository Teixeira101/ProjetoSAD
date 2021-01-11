using System;
using System.Windows.Forms;

namespace SadWork
{
    public partial class NewSimulationlvl2 : Form
    {
        private Form currentChildForm;

        public NewSimulationlvl2()
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
            panelSimulationlvl2.Controls.Add(childForm);
            panelSimulationlvl2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void endSimul_btn_Click(object sender, EventArgs e)
        {
            currentChildForm = new NewSimulationlvl2();
            OpenChildForm(new NewSimulationResults(), currentChildForm);
        }
    }
}
