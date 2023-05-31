using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace HastaneOtomasyonProjesi
{
    public partial class yeniHastaKaydı : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null || kontrolCookie.Value.Trim() == "")
            {
                Response.Redirect("/cikis.aspx");
            }

        }

        protected void hastaEkleButon_click(object sender, EventArgs e)
        {
            using (SqlConnection sqlBaglantisi = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                sqlBaglantisi.Open();
                using (SqlCommand kontrol = new SqlCommand("SELECT hasta_Id FROM hasta_kayitlar WHERE hasta_Tc = @tckn", sqlBaglantisi))
                {
                    kontrol.Parameters.AddWithValue("@tckn", Request.Form["hasta_Tc"]);
                    SqlDataReader dr = kontrol.ExecuteReader();
                    if (dr.Read())
                    {
                        sqlBaglantisi.Close();
                        Response.Write("<script>alert('Bu bilgilere sahip bir hasta daha önceden eklenmiş.')</script>");
                    }
                    else
                    {
                        using (SqlCommand hastaEkleme = new SqlCommand("INSERT INTO hasta_kayitlar (hasta_Id, hasta_Tc,hasta_Adi, hasta_Soyadi,hasta_kanGrubu,hasta_BabaAdi,hasta_AnneAdi,hasta_DogumYeri,hasta_DogumTarihi,hasta_Cinsiyet,hasta_Adres,hasta_Eposta,hasta_faxNo,hasta_evTelefonu,hasta_cepTelefonu,hasta_sigortaTuru,hasta_karneNo,hasta_sicilNo,hasta_YakinAdi,hasta_yakinlikDerecesi,hasta_tedaviDurumu,hasta_tedaviTuru) VALUES (@hasta_Id, @hasta_Tc,@hasta_Adi, @hasta_Soyadi,@hasta_kanGrubu,@hasta_BabaAdi,@hasta_AnneAdi,@hasta_DogumYeri,@hasta_DogumTarihi,@hasta_Cinsiyet,@hasta_Adres,@hasta_Eposta,@hasta_faxNo,@hasta_evTelefonu,@hasta_cepTelefonu,@hasta_sigortaTuru,@hasta_karneNo,@hasta_sicilNo,@hasta_YakinAdi,@hasta_yakinlikDerecesi,@hasta_tedaviDurumu,@hasta_tedaviTuru)", sqlBaglantisi))
                        {
                            hastaEkleme.Parameters.AddWithValue("@hasta_Id", new Random().Next(1111111, 9999999));
                            hastaEkleme.Parameters.AddWithValue("@hasta_Tc", Request.Form["hasta_Tc"]);
                            hastaEkleme.Parameters.AddWithValue("@hasta_Adi", Request.Form["hasta_Adi"]);
                            hastaEkleme.Parameters.AddWithValue("@hasta_Soyadi", Request.Form["hasta_Soyadi"]);
                            hastaEkleme.Parameters.AddWithValue("@hasta_kanGrubu", Request.Form["hasta_kanGrubu"]);
                            hastaEkleme.Parameters.AddWithValue("@hasta_BabaAdi", Request.Form["hasta_BabaAdi"]);
                            hastaEkleme.Parameters.AddWithValue("@hasta_AnneAdi", Request.Form["hasta_AnneAdi"]);
                            hastaEkleme.Parameters.AddWithValue("@hasta_DogumYeri", Request.Form["hasta_DogumYeri"]);
                            hastaEkleme.Parameters.AddWithValue("@hasta_DogumTarihi", Request.Form["hasta_DogumTarihi"]);
                            hastaEkleme.Parameters.AddWithValue("@hasta_Cinsiyet", Request.Form["hasta_Cinsiyet"]);
                            hastaEkleme.Parameters.AddWithValue("@hasta_Adres", Request.Form["hasta_Adres"]);
                            hastaEkleme.Parameters.AddWithValue("@hasta_Eposta", Request.Form["hasta_Eposta"]);
                            hastaEkleme.Parameters.AddWithValue("@hasta_faxNo", Request.Form["hasta_faxNo"]);
                            hastaEkleme.Parameters.AddWithValue("@hasta_evTelefonu", Request.Form["hasta_evTelefonu"]);
                            hastaEkleme.Parameters.AddWithValue("@hasta_cepTelefonu", Request.Form["hasta_cepTelefonu"]);
                            hastaEkleme.Parameters.AddWithValue("@hasta_sigortaTuru", Request.Form["hasta_sigortaTuru"]);
                            hastaEkleme.Parameters.AddWithValue("@hasta_karneNo", Request.Form["hasta_karneNo"]);
                            hastaEkleme.Parameters.AddWithValue("@hasta_sicilNo", Request.Form["hasta_sicilNo"]);
                            hastaEkleme.Parameters.AddWithValue("@hasta_YakinAdi", Request.Form["hasta_YakinAdi"]);
                            hastaEkleme.Parameters.AddWithValue("@hasta_yakinlikDerecesi", Request.Form["hasta_yakinlikDerecesi"]);
                            hastaEkleme.Parameters.AddWithValue("@hasta_tedaviDurumu", Request.Form["hasta_tedaviDurumu"]);
                            hastaEkleme.Parameters.AddWithValue("@hasta_tedaviTuru", Request.Form["hasta_tedaviTuru"]);

                            hastaEkleme.ExecuteNonQuery();
                            Response.Write("<script>alert('İşlem başarılı.')</script>");
                            hastaEkleme.Dispose();
                            sqlBaglantisi.Close();
                        }
                    }
                }
            }
        }
    }
}
