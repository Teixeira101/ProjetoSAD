using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SadWork
{
    public partial class ConfirmPark : Form
    {
        private string website;
        string imgLoc1 = "";
        string imgLoc2 = "";
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-CHRF1L4J\SQLEXPRESS;Initial Catalog=dbSAD;Integrated Security=True");

        public ConfirmPark()
        {
            InitializeComponent();
            DoubleBuffered = true;
            loadParks();
        }

        private void loadParks()
        {
            //Clear ComboBox
            comboBoxId.Items.Clear();

            //Visible False - botões
            addMoreDetails_btn.Visible = false;
            delete_btn.Visible = false;

            //Ativar botões
            comboBoxId.Enabled = true;

            sqlcon.Open();
            bool verificado_parque = false;
            cmd = new SqlCommand("SELECT * FROM [dbo].[Parque] Where [verificado_parque] = '" + verificado_parque + "'", sqlcon);

            using (dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    comboBoxId.Items.Add(dr["nome_parque"].ToString());
                }

                dr.Close();
            }
            sqlcon.Close();
        }

        private void website_btn_Click(object sender, EventArgs e)
        {
            addMoreDetails_btn.Enabled = true;
            addMoreDetails_btn.Visible = true;
            delete_btn.Visible = true;
            Process.Start(website);
        }

        private void delete_btn_Click(object sender, System.EventArgs e)
        {
            comboBoxId.Enabled = true;
            cmd.ExecuteNonQuery();
            using (cmd = new SqlCommand("DELETE FROM [dbo].[Parque] Where [nome_parque] = '" + comboBoxId.SelectedItem + "'", sqlcon))
            {
                comboBoxId.Items.Clear();
                delete_btn.Visible = false;
                addMoreDetails_btn.Visible = false;
                confirm_btn.Visible = false;

                labelImg2.Visible = false;
                labelImg3.Visible = false;

                comboBoxTf.Items.Clear();
                comboBoxInv.Items.Clear();
                comboBoxTf.Items.Clear();
                comboBoxPn.Items.Clear();
                textBoxCompleteDesc.Clear();

                cmd.ExecuteNonQuery();
            }
            sqlcon.Close();
            MessageBox.Show("Parque Removido!");
            loadParks();
        }

        private void addMoreDetails_btn_Click(object sender, System.EventArgs e)
        {
            addMoreDetails_btn.Enabled = false;
            confirm_btn.Visible = true;
            panelParkDetails.Visible = true;
        }

        private void confirm_btn_Click(object sender, System.EventArgs e)
        {
            FileStream fs1 = new FileStream(imgLoc1, FileMode.Open, FileAccess.Read);
            FileStream fs2 = new FileStream(imgLoc2, FileMode.Open, FileAccess.Read);
            Console.Out.WriteLine(imgLoc1);
            Console.Out.WriteLine(imgLoc2);
            BinaryReader br1 = new BinaryReader(fs1);
            BinaryReader br2 = new BinaryReader(fs2);
            byte[] img1 = br1.ReadBytes((int)fs1.Length);
            byte[] img2 = br2.ReadBytes((int)fs2.Length);

            sqlcon.Open();
            using (cmd = new SqlCommand("UPDATE [dbo].[Parque] SET [descricao_parque_total] = '" + textBoxCompleteDesc.Text.Trim() + "', [verificado_parque] = '1', [foto_parque2] = @img1, [foto_parque3] = @img2, [trained_staff] = '" + comboBoxTf.SelectedItem + "', [investments] = '" + comboBoxInv.SelectedItem + "', [productivity] = '" + comboBoxProd.SelectedItem + "', [partners] = '" + comboBoxPn.SelectedItem + "' Where [nome_parque] = '" + comboBoxId.SelectedItem + "'", sqlcon))
            {
                comboBoxId.Items.Clear();
                comboBoxId.Enabled = true;
                delete_btn.Visible = false;
                addMoreDetails_btn.Visible = false;
                panelParkDetails.Visible = false;
                confirm_btn.Visible = false;
                labelImg2.Visible = false;
                labelImg3.Visible = false;
                labelParkName.Visible = false;
                labelParkEmail.Visible = false;
                labelParkLocation.Visible = false;
                labelParkArea.Visible = false;

                comboBoxTf.Items.Clear();
                comboBoxInv.Items.Clear();
                comboBoxTf.Items.Clear();
                comboBoxPn.Items.Clear();
                textBoxCompleteDesc.Clear();

                cmd.Parameters.Add(new SqlParameter("@img1", img1));
                cmd.Parameters.Add(new SqlParameter("@img2", img2));
                cmd.ExecuteNonQuery();
            }
            sqlcon.Close();
            MessageBox.Show("Parque Confirmado!");
            loadParks();

        }

        OpenFileDialog ofd = new OpenFileDialog();
        private void img2_btn_Click(object sender, System.EventArgs e)
        {
            ofd.Filter = "JPG|*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                labelImg2.Text = ofd.SafeFileName;
                labelImg2.Visible = true;
                imgLoc1 = ofd.FileName.ToString();
            }
        }

        OpenFileDialog ofd2 = new OpenFileDialog();
        private void img3_btn_Click(object sender, System.EventArgs e)
        {
            ofd2.Filter = "JPG|*.jpg";
            if (ofd2.ShowDialog() == DialogResult.OK)
            {
                labelImg3.Text = ofd2.SafeFileName;
                labelImg3.Visible = true;
                imgLoc2 = ofd2.FileName.ToString();
            }
        }

        private void comboBoxId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBoxId.SelectedIndex != -1)
            {
                comboBoxId.Enabled = false;
                sqlcon.Open();
                cmd = new SqlCommand("SELECT * FROM [dbo].[Parque] Where [nome_parque] = '" + comboBoxId.SelectedItem + "'", sqlcon);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    labelParkName.Text = dr["nome_parque"].ToString();
                    labelParkName.Visible = true;
                    labelParkArea.Text = dr["area"].ToString();
                    labelParkArea.Visible = true;
                    labelParkEmail.Text = dr["email_parque"].ToString();
                    labelParkEmail.Visible = true;
                    labelParkLocation.Text = dr["localizacao_parque"].ToString();
                    labelParkLocation.MaximumSize = new Size(260, 32);
                    labelParkLocation.AutoSize = true;
                    labelParkLocation.Visible = true;
                    website = dr["website"].ToString();
                    website_btn.Visible = true;

                    dr.Close();
                }
                sqlcon.Close();
            }
        }
    }
}
