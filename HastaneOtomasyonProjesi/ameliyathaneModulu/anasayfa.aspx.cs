using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi.ameliyathaneModulu
{
    public partial class anasayfa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null || kontrolCookie.Value.Trim() == "")
            {
                Response.Redirect("/cikis.aspx");
            }
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                {
                    sqlCon.Open();
                    using (SqlCommand veriCek = new SqlCommand("SELECT hasta_kayitlar.hasta_Tc AS [Hasta TCKN], ameliyathane_Tablo.ameliyatId AS [Ameliyat Numarası], ameliyathane_Tablo.ameliyatGirisTarihi AS [Ameliyata Giriş Tarihi], ameliyathane_Tablo.ameliyatCikisTarihi AS [Ameliyatın Bitiş Tarihi], personel_tablo.personel_Isim AS [Doktor Ismi],personel_tablo.personel_Soyisim AS [Doktor Soyismi], hasta_kayitlar.hasta_Adi AS [Hasta Adı],hasta_kayitlar.hasta_Soyadi AS [Hasta Soyadı] FROM ameliyathane_Tablo, hasta_kayitlar, personel_tablo WHERE ameliyathane_Tablo.ameliyatPersonelId = personel_tablo.personel_Id AND ameliyathane_Tablo.ameliyatHastaId = hasta_kayitlar.hasta_Id AND CAST(ameliyathane_Tablo.ameliyatGirisTarihi AS DATE) = @tarih", sqlCon))
                    {
                        veriCek.Parameters.AddWithValue("@tarih", DateTime.Parse(DateTime.Now.ToLongDateString()));
                        SqlDataReader veriOkuyucu = veriCek.ExecuteReader();
                        if (!veriOkuyucu.HasRows)
                        {
                            Response.Write("Listelenecek bir ameliyat yok!");
                        }
                        else
                        {
                            bugunku_ameliyatlarListesi.DataSource = veriOkuyucu;
                            bugunku_ameliyatlarListesi.DataBind();
                        }
                        
                        veriOkuyucu.Close();
                        sqlCon.Close();
                    }
                }
            }

            
        }

        protected void detayButon_Click(object sender, EventArgs e)
        {
            Response.Redirect("ameliyatDetayGoruntule.aspx?ameliyatNumarasi=" + ameliyat_Numarasi.Text);
        }
    }
}