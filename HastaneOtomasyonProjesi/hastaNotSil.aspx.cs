using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace HastaneOtomasyonProjesi
{
    public partial class hastaNotSil : System.Web.UI.Page
    {
        public string notNumarasi = HttpContext.Current.Request.QueryString["notIdNum"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null || kontrolCookie.Value.Trim() == "" || notNumarasi == null)
            {
                Response.Redirect("/panel.aspx");
            }
            else
            {
                using (SqlConnection sqlBaglantisi = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                {
                    sqlBaglantisi.Open();
                    using (SqlCommand notSilmeKomutu = new SqlCommand("DELETE FROM hasta_Notlari WHERE hasta_NotId = @notNumarasi", sqlBaglantisi))
                    {
                        notSilmeKomutu.Parameters.AddWithValue("@notNumarasi", notNumarasi);
                        notSilmeKomutu.ExecuteNonQuery();
                        Response.Redirect("hastaIslemleri.aspx");
                        notSilmeKomutu.Dispose();
                        sqlBaglantisi.Close();
                    }
                }
            }
        }
    }
}