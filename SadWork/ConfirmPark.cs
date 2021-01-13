using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace SadWork
{
    public partial class ConfirmPark : Form
    {
        private string website;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-CHRF1L4J\SQLEXPRESS;Initial Catalog=dbSAD;Integrated Security=True");

        public ConfirmPark()
        {
            InitializeComponent();
        }

        private void loadUnVerPark_btn_Click(object sender, System.EventArgs e)
        {
            comboBoxId.Enabled = true;
            comboBoxId.Items.Clear();
            bool verificado_parque = false;
            seeUnVerPark_btn.Visible = true;
            sqlcon.Open();

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
            comboBoxId.Enabled = false;
            sqlcon.Open();
            cmd = new SqlCommand("SELECT * FROM [dbo].[Parque] Where [nome_parque] = '" + comboBoxId.SelectedItem + "'", sqlcon);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                delete_btn.Visible = true;
                addMoreDetails_btn.Visible = true;
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

        private void website_btn_Click(object sender, System.EventArgs e)
        {
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
            confirm_btn.Visible = true;
            panelParkDetails.Visible = true;
        }

        private void confirm_btn_Click(object sender, System.EventArgs e)
        {
            sqlcon.Open();
            using (cmd = new SqlCommand("UPDATE [dbo].[Parque] SET [descricao_parque_total] = '" + textBoxCompleteDesc.Text.Trim() + "', [verificado_parque] = '1', [foto_parque2] = '" + ofd.FileName + "', [foto_parque3] = '" + ofd2.FileName + "' Where [nome_parque] = '" + comboBoxId.SelectedItem + "'", sqlcon))
            {
                comboBoxId.Items.Clear();
                comboBoxId.Enabled = true;
                delete_btn.Visible = false;
                addMoreDetails_btn.Visible = false;
                panelParkVal.Visible = false;
                seeUnVerPark_btn.Visible = false;
                panelParkDetails.Visible = false;
                confirm_btn.Visible = false;

                cmd.ExecuteNonQuery();
            }
            sqlcon.Close();
        }

        OpenFileDialog ofd = new OpenFileDialog();
        private void img2_btn_Click(object sender, System.EventArgs e)
        {
            ofd.Filter = "JPEG|*.jfif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                labelImg2.Text = ofd.SafeFileName;
                labelImg2.Visible = true;
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
            }
        }
    }
}
