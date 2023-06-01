using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace HastaneOtomasyonProjesi
{
    public partial class hastaIlacGoruntuleme : System.Web.UI.Page
    {
        public string gelenKayitId = HttpContext.Current.Request.QueryString["vIlacId"];
        public bool durum;
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.QueryString["vIlacId"] == null)
            {
                Response.Redirect("/panel.aspx");
            }
            else
            {
                using (SqlCommand vCek = new SqlCommand("SELECT hasta_IlacDevamDurumu FROM hastaIlac_tablosu WHERE hastailac_Id = @hId", con))
                {
                    con.Open();
                    vCek.Parameters.AddWithValue("@hId", gelenKayitId);
                    using (SqlDataReader oku = vCek.ExecuteReader())
                    {
                        while (oku.Read())
                        {
                            durum = oku.GetBoolean(0);
                        }
                        oku.Close();
                        con.Close();
                    }
                }
            }
        }

        protected void hasta_IlacDuzenle_Click(object sender, EventArgs e)
        {
            
            using (SqlCommand ilacKaydiDuzenle = new SqlCommand("UPDATE hastaIlac_tablosu SET hasta_IlacDevamDurumu = @deger WHERE hastailac_Id = @IDparametre", con))
            {
                con.Open();
                ilacKaydiDuzenle.Parameters.AddWithValue("@deger", ilacDurum.SelectedValue.ToString());
                ilacKaydiDuzenle.Parameters.AddWithValue("@IDparametre", gelenKayitId);
                ilacKaydiDuzenle.ExecuteNonQuery();
                ilacKaydiDuzenle.Dispose();
                con.Close();
            }
        }
    }
}