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
    public partial class ScientificParks : Form
    {
        private Form currentChildForm;

        public ScientificParks()
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
            scientificPark_panel.Controls.Add(childForm);
            scientificPark_panel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void learnMore_btn_Click(object sender, EventArgs e)
        {
            currentChildForm = new ScientificParks();
            OpenChildForm(new ParkInfo(), currentChildForm);
        }
    }
}
