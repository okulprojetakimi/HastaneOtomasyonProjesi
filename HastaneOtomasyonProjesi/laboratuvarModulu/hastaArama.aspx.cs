using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web;

namespace HastaneOtomasyonProjesi.laboratuvarModulu
{
    public partial class hastaArama : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null || kontrolCookie.Value.Trim() == "" || HttpContext.Current.Request.QueryString["isim"] == null || HttpContext.Current.Request.QueryString["soyisim"] == null)
            {
                Response.Redirect("/cikis.aspx");
            }
            else
            {
                using (SqlConnection veritabaniBaglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                {
                    veritabaniBaglanti.Open();
                    using (SqlCommand veriCek = new SqlCommand("SELECT hasta_Id, hasta_Tc, hasta_Adi, hasta_Soyadi FROM hasta_kayitlar WHERE hasta_Adi LIKE @hAd AND hasta_Soyadi LIKE @hSoyad", veritabaniBaglanti))
                    {
                        veriCek.Parameters.AddWithValue("@hAd", "%" + HttpContext.Current.Request.QueryString["isim"] + "%");
                        veriCek.Parameters.AddWithValue("@hSoyad", "%" + HttpContext.Current.Request.QueryString["soyisim"] + "%");
                        SqlDataReader veriOkuyucu = veriCek.ExecuteReader();
                        DataTable tablo = new DataTable();
                        tablo.Load(veriOkuyucu);
                        string json = JsonConvert.SerializeObject(tablo, Formatting.Indented);
                        veriOkuyucu.Close();
                        veritabaniBaglanti.Close();
                        Response.Write(json);
                    }
                }
            }
        }
    }
}