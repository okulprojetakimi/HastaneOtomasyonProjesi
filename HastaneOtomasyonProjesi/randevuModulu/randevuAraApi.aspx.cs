using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace HastaneOtomasyonProjesi.randevuModulu
{
    public partial class randevuAraApi : System.Web.UI.Page
    {
        public int hastaId;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                connection.Open();
                /* Tc den id çeken kod */
                using (SqlCommand tcToId = new SqlCommand("SELECT hasta_Id FROM hasta_kayitlar WHERE hasta_Tc = @tcknno", connection))
                {
                    tcToId.Parameters.AddWithValue("@tcknno", HttpContext.Current.Request.QueryString["tckn"]);
                    hastaId = (int)tcToId.ExecuteScalar();
                }

                /* Randevu Listesibi Çeken Kod */
                using (SqlCommand sqlcom = new SqlCommand("SELECT randevu_modulu.randevuId, randevu_modulu.randevuTarih, randevu_modulu.randevuSaat, hasta_kayitlar.hasta_Adi, hasta_kayitlar.hasta_Soyadi, personel_tablo.personel_Isim, personel_tablo.personel_Soyisim FROM randevu_modulu, hasta_kayitlar, personel_tablo WHERE randevu_modulu.hastaId = hasta_kayitlar.hasta_Id AND randevu_modulu.randevuDoktor = personel_tablo.personel_Id AND randevu_modulu.hastaId = @hastaNumarasi AND randevu_modulu.randevuTarih = @randevuTarihi", connection))
                {
                    sqlcom.Parameters.AddWithValue("@hastaNumarasi", hastaId);
                    sqlcom.Parameters.AddWithValue("@randevuTarihi", DateTime.Parse(HttpContext.Current.Request.QueryString["rTarih"]).Date);
                    SqlDataReader veriOkuyucu = sqlcom.ExecuteReader();
                    DataTable tablo = new DataTable();
                    tablo.Load(veriOkuyucu);
                    string json = JsonConvert.SerializeObject(tablo, Formatting.Indented);
                    veriOkuyucu.Close();
                    connection.Close();
                    Response.Write(json);
                }
            }
        }
    }
}