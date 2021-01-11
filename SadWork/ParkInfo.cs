using System;
using System.Windows.Forms;

namespace SadWork
{
    public partial class ParkInfo : Form
    {
        private Form currentChildForm;

        public ParkInfo()
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
            parkInfo_panel.Controls.Add(childForm);
            parkInfo_panel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            currentChildForm = new ParkInfo();
            OpenChildForm(new ScientificParks(), currentChildForm);
        }
    }
}
