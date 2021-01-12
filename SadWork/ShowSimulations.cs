using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SadWork
{
    public partial class ShowSimulations : Form
    {
        public ShowSimulations()
        {
            InitializeComponent();

            SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-CHRF1L4J\SQLEXPRESS;Initial Catalog=dbSAD;Integrated Security=True");
            sqlcon.Open();


            SqlCommand cmd = new SqlCommand("SELECT [area],[data] FROM [dbo].[Resultado_Simulacao] Where [area]=@area and [data]=@data", sqlcon);
            cmd.Parameters.AddWithValue("@area", labelArea.Text);
            cmd.Parameters.AddWithValue("@data", labelData.Text);

            sqlcon.Close();


        }
    }
}
