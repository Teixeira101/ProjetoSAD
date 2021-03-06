﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace SadWork
{
    public partial class MainPage : Form
    {

        public IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        public MainPage()
        {
            InitializeComponent();

            DoubleBuffered = true;
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 40);
            panel1.Controls.Add(leftBorderBtn);

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;

            if (LoginPage.admin) { admin(); } else if (LoginPage.company) { company(); } else { skip(); }
        }

        public struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(24, 161, 251);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(118, 189, 202);
            public static Color color7 = Color.FromArgb(232, 222, 32);
            public static Color color8 = Color.FromArgb(146, 232, 32);
            public static Color color9 = Color.FromArgb(86, 50, 168);
        }

        private void ActivateButton(object senderbtn, Color color)
        {
            if (senderbtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderbtn;
                currentBtn.BackColor = Color.FromArgb(1, 32, 58);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.Font = new Font(currentBtn.Font, FontStyle.Bold);

                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                iconPictureBox1.IconChar = currentBtn.IconChar;
                iconPictureBox1.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(1, 32, 58);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                currentBtn.Font = new Font(currentBtn.Font, FontStyle.Regular);
            }
        }

        public void OpenChildForm(Form childForm)
        {
            if(currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelHome.Controls.Add(childForm);
            panelHome.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            label2.Text = childForm.Text;
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new Dashboard());
        }

        private void scientificParks_btn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new ScientificParks());
        }

        private void newPark_btn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new NewPark());
        }

        private void newSimulation_btn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new NewSimulationlvl1());
        }

        private void showSimulation_btn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new ShowSimulations());
        }

        private void confirmPark_btn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color7);
            OpenChildForm(new ConfirmPark());
        }

        private void verifyCompany_btn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color8);
            OpenChildForm(new VerifyCompany());
        }

        private void contacts_btn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color9);
            OpenChildForm(new ContactDetails());
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage LP = new LoginPage();
            LP.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {   
            if(currentChildForm != null)
            {
                currentChildForm.Close();
            }
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconPictureBox1.IconChar = IconChar.Home;
            iconPictureBox1.IconColor = RGBColors.color6;
            label2.Text = "Home";
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void admin()
        {
            login_btn.IconChar = IconChar.SignOutAlt;
            login_btn.Text = "Log Out";
            login_btn.TextImageRelation = TextImageRelation.TextBeforeImage;
            login_btn.Width = (int)Size.Width;

            confirmPark_btn.Location = newSimulation_btn.Location;
            verifyCompany_btn.Location = showSimulation_btn.Location;

            newSimulation_btn.Hide();
            showSimulation_btn.Hide();
        }

        private void company()
        {
            login_btn.IconChar = IconChar.SignOutAlt;
            login_btn.Text = "Log Out";
            login_btn.TextImageRelation = TextImageRelation.TextBeforeImage;
            login_btn.Width = (int)Size.Width;

            confirmPark_btn.Hide();
            verifyCompany_btn.Hide();
        }

        private void skip()
        {
            newPark_btn.Hide();
            newSimulation_btn.Hide();
            showSimulation_btn.Hide();
            confirmPark_btn.Hide();
            verifyCompany_btn.Hide();
        }
    }
}