using System.Data.SqlClient;
using System.Diagnostics;
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
        }

        private void loadUnVerPark_btn_Click(object sender, System.EventArgs e)
        {
            //Clear ComboBox
            comboBoxId.Items.Clear();

            //Visible False - botões/panel
            addMoreDetails_btn.Visible = false;
            delete_btn.Visible = false;
            panelParkVal.Visible = false;

            //Visible True - botões
            seeUnVerPark_btn.Visible = true;

            //Ativar botões
            comboBoxId.Enabled = true;
            seeUnVerPark_btn.Enabled = true;

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

        private void seeUnVerPark_btn_Click(object sender, System.EventArgs e)
        {
            if (comboBoxId.SelectedIndex != -1)
            {
                seeUnVerPark_btn.Enabled = false;
                comboBoxId.Enabled = false;
                sqlcon.Open();
                cmd = new SqlCommand("SELECT * FROM [dbo].[Parque] Where [nome_parque] = '" + comboBoxId.SelectedItem + "'", sqlcon);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    panelParkVal.Visible = true;

                    labelParkName.Text = dr["nome_parque"].ToString();
                    labelParkArea.Text = dr["area"].ToString();
                    labelParkEmail.Text = dr["email_parque"].ToString();
                    labelParkLocation.Text = dr["localizacao_parque"].ToString();
                    website = dr["website"].ToString();

                    dr.Close();
                }
                sqlcon.Close();
            }
        }

        private void website_btn_Click(object sender, System.EventArgs e)
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
                panelParkVal.Visible = false;
                seeUnVerPark_btn.Visible = false;

                cmd.ExecuteNonQuery();
            }
            sqlcon.Close();
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
                panelParkVal.Visible = false;
                seeUnVerPark_btn.Visible = false;
                panelParkDetails.Visible = false;
                confirm_btn.Visible = false;

                cmd.Parameters.Add(new SqlParameter("@img1", img1));
                cmd.Parameters.Add(new SqlParameter("@img2", img2));
                cmd.ExecuteNonQuery();
            }
            sqlcon.Close();
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
            ofd2.Filter = "JPEG|*.jfif";
            if (ofd2.ShowDialog() == DialogResult.OK)
            {
                labelImg3.Text = ofd2.SafeFileName;
                labelImg3.Visible = true;
                imgLoc2 = ofd.FileName.ToString();
            }
        }
    }
}
