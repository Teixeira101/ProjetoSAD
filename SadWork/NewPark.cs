using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace SadWork
{
    public partial class NewPark : Form
    {
        string imgLoc = "";
        public NewPark()
        {
            InitializeComponent();
            DoubleBuffered = true;

            comboBoxArea.Items.Add("Ciências e Tecnologias");
            comboBoxArea.Items.Add("Tecnologia Alimentar");
            comboBoxArea.Items.Add("Biotecnologia");
            comboBoxArea.Items.Add("Empreendedorismo");
            comboBoxArea.Items.Add("Comércio");
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void openFile_Click(object sender, EventArgs e)
        {
            ofd.Filter = "JPG Files|*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                labelPDF.Text = ofd.SafeFileName;
                labelPDF.Visible = true;
                imgLoc = ofd.FileName.ToString();
            }
        }

        private void iconButtonReset_Click(object sender, EventArgs e)
        {
            clearCamps();
        }

        private void iconButtonAdd_Click(object sender, EventArgs e)
        {
            byte[] img = null;
            if (imgLoc != "")
            {
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);

                SqlConnection sqlcon = new SqlConnection(@"Data Source=46.101.41.99;Initial Catalog=dbSAD;User ID=SA;Password=Grupo1sad");
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Parque]
           ([nome_parque]
           ,[area]
           ,[email_parque]
           ,[localizacao_parque]
           ,[foto_parque1]
           ,[descricao_parque_total]
           ,[descricao_parque_parcial]
           ,[colaboradores_parque]
           ,[verificado_parque]
           ,[slogan]
           ,[website]
           ,[foto_parque2]
           ,[foto_parque3]
           ,[trained_staff]
           ,[investments]
           ,[productivity]
           ,[partners])
     VALUES
           ('" + textBoxName.Text.Trim() + "', '" + comboBoxArea.SelectedItem.ToString() + "', '" + textBoxEmail.Text.Trim() + "', '" + textBoxLocation.Text.Trim() + "', @img, '" + null + "', '" + textBoxBriefDesc.Text.Trim() + "', '" + checkBoxColab.Checked + "', '0', '" + textBoxSlogan.Text.Trim() + "', '" + textBoxWebsite.Text.Trim() + "', '" + null + "', '" + null + "', '" + null + "', '" + null + "', '" + null + "', '" + null + "')", sqlcon);
                sqlcon.Open();
                cmd.Parameters.Add(new SqlParameter("@img", img));
                cmd.ExecuteNonQuery();
                sqlcon.Close();

                clearCamps();
            } else
            {
                MessageBox.Show("É necessária a inserção de uma imagem.");
            }
        }

        private void clearCamps()
        {
            textBoxName.Clear();
            comboBoxArea.SelectedIndex = -1;
            textBoxEmail.Clear();
            textBoxLocation.Clear();
            labelPDF.Visible = false;
            textBoxWebsite.Clear();
            textBoxSlogan.Clear();
            textBoxBriefDesc.Clear();
            checkBoxColab.Checked = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}