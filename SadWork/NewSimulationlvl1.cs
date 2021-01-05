using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void button1_Click(object sender, EventArgs e)
        {
            currentChildForm = new NewSimulationlvl1();
            OpenChildForm(new NewSimulationResults(), currentChildForm);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
