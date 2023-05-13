using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi.randevuModulu
{
    public partial class kayitliOlmayanHastaRandevu : System.Web.UI.Page
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

            }
        }

        protected void randevuEkle_Buton_Click(object sender, EventArgs e)
        {
            using (SqlConnection dbCon = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                dbCon.Open();
                using (SqlCommand sqlKomut = new SqlCommand("INSERT INTO kayitsizHasta_randevu (kRandevu_Id, kRandevu_Isim, kRandevu_Soyisim, kRandevu_Tarih, kRandevu_Saat, kRandevu_randevuNot, kRandevu_Durum, kRandevu_poliklinik, kRandevu_Doktor, kRandevu_Tc) VALUES (@idDegeri, @hIsim, @hSoyisim, @rTarihi, @rSaati, @rNot, @rDurum, @rPoliklinik, @rDoktor, @hTc)", dbCon))
                {
                    //@idDegeri, @hIsim, @hSoyisim, @rTarihi, @rSaati, @rNot, @rDurum, @rPoliklinik, @rDoktor, @hTc
                    sqlKomut.Parameters.AddWithValue("@idDegeri", new Random().Next(111111, 999999));
                    sqlKomut.Parameters.AddWithValue("@hIsim", kRandevu_Isim.Text);
                    sqlKomut.Parameters.AddWithValue("@hSoyisim", kRandevu_Soyisim.Text);
                    sqlKomut.Parameters.AddWithValue("@rTarihi", DateTime.Parse(kRandevu_Tarih.Text).Date);
                    sqlKomut.Parameters.AddWithValue("@rSaati", saatVerisi.Value);
                    sqlKomut.Parameters.AddWithValue("@rNot", kRandevu_randevuNot.Text);
                    sqlKomut.Parameters.AddWithValue("@rDurum", true);
                    sqlKomut.Parameters.AddWithValue("rPoliklinik", secilenPoliklinik.Value);
                    sqlKomut.Parameters.AddWithValue("rDoktor", secilenDoktor.Value);
                    sqlKomut.Parameters.AddWithValue("@hTc", kRandevu_Tc.Text);
                    sqlKomut.ExecuteNonQuery();
                    dbCon.Close();

                }
            }
        }


    }
}