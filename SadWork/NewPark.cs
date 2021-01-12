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
using System.Data.SqlClient;

namespace SadWork
{
    public partial class NewPark : Form
    {
        private Form currentChildForm;

        public NewPark()
        {
            InitializeComponent();

            comboBoxArea.Items.Add("Telecomunicações");
            comboBoxArea.Items.Add("Comércio Digital");
            comboBoxArea.Items.Add("Ensino");
            comboBoxArea.Items.Add("Automóveis");
            comboBoxArea.Items.Add("Fitness");
            comboBoxArea.Items.Add("Produtos Alimentares");
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void openFile_Click(object sender, EventArgs e)
        {
            ofd.Filter = "JPEG|*.jfif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                labelPDF.Text = ofd.SafeFileName;
                labelPDF.Visible = true;
            }
        }

        private void iconButtonReset_Click(object sender, EventArgs e)
        {
            textBoxName.Clear();
            comboBoxArea.SelectedIndex = -1;
            textBoxEmail.Clear();
            textBoxLocation.Clear();
            labelPDF.Visible = false;
            textBoxBriefDesc.Clear();
            checkBoxColab.Checked = false;
        }

        private void iconButtonAdd_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-CHRF1L4J\SQLEXPRESS;Initial Catalog=dbSAD;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Parque]
           ([nome_parque]
           ,[area]
           ,[email_parque]
           ,[localizacao_parque]
           ,[foto_parque]
           ,[descricao_parque_total]
           ,[descricao_parque_parcial]
           ,[colaboradores_parque]
           ,[verificado_parque])
     VALUES
           ('" + textBoxName.Text.Trim() + "', '" + comboBoxArea.SelectedItem.ToString() + "', '" + textBoxEmail.Text.Trim() + "', '" + textBoxEmail.Text.Trim() + "', '" + ofd.FileName + "', '" + "" + "', '" + textBoxBriefDesc.Text.Trim() + "', '" + checkBoxColab.Checked + "', '0')");
            sqlcon.Open();
            cmd.Connection = sqlcon;
            cmd.ExecuteNonQuery();
            sqlcon.Close();

            currentChildForm = new NewPark();
            OpenChildForm(new Dashboard(), currentChildForm);
        }

        private void OpenChildForm(Form childForm, Form currentChildForm)
        {
            currentChildForm.Close();
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelNewPark.Controls.Add(childForm);
            panelNewPark.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
