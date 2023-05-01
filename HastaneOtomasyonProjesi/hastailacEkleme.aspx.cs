using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi
{
    public partial class hastailacEkleme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }
        protected void hastaIlac_Ekle_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlBaglantisi = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                sqlBaglantisi.Open();
                using (SqlCommand hastaIlacEkleme = new SqlCommand("insert into hastaIlac_tablosu (hastailac_Id,hastailac_hastaId,hastailac_ilacId,hastailac_verilmeTarih) values (@hastailac_Id,@hastailac_hastaId,@hastailac_ilacId,@hastailac_verilmeTarih)", sqlBaglantisi))
                {
                    //hastaIlacEkleme.Parameters.AddWithValue("hastailac_Id",);
                    //hastaIlacEkleme.Parameters.AddWithValue("hastailac_hastaId",);
                    //hastaIlacEkleme.Parameters.AddWithValue("hastailac_ilacId",);
                    hastaIlacEkleme.Parameters.AddWithValue("hastailac_verilmeTarih", DateTime.Parse(DateTime.Now.ToLongDateString()));
                    hastaIlacEkleme.ExecuteNonQuery();
                    hastaIlacEkleme.Dispose();
                    sqlBaglantisi.Close();
                }
            }
        }
    }
}