using System;
using System.Windows.Forms;

namespace SadWork
{
    public partial class NewSimulationlvl1 : Form
    {
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
            currentChildForm = new NewSimulationlvl1();
            OpenChildForm(new NewSimulationlvl2(), currentChildForm);
        }
    }
}
