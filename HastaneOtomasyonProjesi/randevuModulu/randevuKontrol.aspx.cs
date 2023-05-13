using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace HastaneOtomasyonProjesi.randevuModulu
{
    public partial class randevuKontrol : System.Web.UI.Page
    {
        private string randevuKontrolu(string personelId, string randevuTarih)
        {
            /* Saat Dilimleri :( */
            List<string> zamanListesi = new List<string>() {"09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30"};
            /*  */
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                sqlCon.Open();
                using (SqlCommand komut = new SqlCommand("SELECT kRandevu_Saat FROM kayitsizHasta_Randevu WHERE kRandevu_Tarih = @tarihVerisi AND kRandevu_Doktor = @doktorNum", sqlCon))
                {
                    int indeks = 0;
                    komut.Parameters.AddWithValue("@tarihVerisi", randevuTarih);
                    komut.Parameters.AddWithValue("@doktorNum", personelId);
                    SqlDataReader veriOkuyucu = komut.ExecuteReader();
                    while (veriOkuyucu.Read())
                    {
                        indeks = zamanListesi.IndexOf(veriOkuyucu.GetString(0));
                        if (indeks != -1)
                        {
                            zamanListesi.RemoveAt(indeks);
                        }
                    }
                    sqlCon.Close();
                    veriOkuyucu.Close();
                }
            }
            return JsonConvert.SerializeObject(zamanListesi, Formatting.Indented).ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null || kontrolCookie.Value.Trim() == "")
            {
                Response.Redirect("/cikis.aspx");
            }
            else
            {
                string pNum = HttpContext.Current.Request.QueryString["personelNumarasi"];
                string rTarih = HttpContext.Current.Request.QueryString["randevuTarihi"];
                Response.Write(randevuKontrolu(pNum, rTarih));
            }
        }
    }
}