﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SadWork
{
    public partial class VerifyCompanyS : Form
    {
        public VerifyCompanyS()
        {
            InitializeComponent();

            
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void openFile_Click(object sender, EventArgs e)
        {
            ofd.Filter = "JPG|*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                label7.Text = ofd.SafeFileName;
                label7.Visible = true;
            }
        }
    }
}
