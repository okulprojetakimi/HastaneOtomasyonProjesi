using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi.randevuModulu
{
    public partial class hastaRandevuEkle : System.Web.UI.Page
    {
        public int hastaId;

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            using (erisimDuzey erisim = new erisimDuzey())
            {
                if (!erisim.yetkiKontrol("Danýþman", kontrolCookie.Value) || kontrolCookie == null || kontrolCookie.Value.Trim() == "")
                {
                    Response.Redirect("/panel.aspx");
                }
            }
        }
        protected void randevuEklemeButon_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                connection.Open();
                string tcNo = tcNumara.Text;

                using (SqlCommand komut = new SqlCommand("SELECT hasta_Id FROM hasta_kayitlar WHERE hasta_Tc = @hasta_Tc", connection))
                {
                    komut.Parameters.AddWithValue("@hasta_Tc", tcNo);
                    SqlDataReader okuyucu = komut.ExecuteReader();
                    while (okuyucu.Read())
                    {
                        hastaId = okuyucu.GetInt32(0);
                    }
                    komut.Dispose();
                    okuyucu.Close();

                }
                int random = new Random().Next(1111, 9999);
                using (SqlCommand randevuEkle = new SqlCommand("INSERT INTO randevu_modulu (randevuId,hastaId,randevuPoliklinik,randevuTarih,randevuSaat,randevuNot,randevuDurumu,randevuDoktor) VALUES (@randevuId,@hastaId,@randevuPoliklinik,@randevuTarih,@randevuSaat,@randevuNot,@randevuDurumu,@randevuDoktor)", connection))
                {
                    randevuEkle.Parameters.AddWithValue("@randevuId", random);
                    randevuEkle.Parameters.AddWithValue("@hastaId", hastaId);
                    randevuEkle.Parameters.AddWithValue("@randevuPoliklinik", secilenPoliklinik.Value);
                    randevuEkle.Parameters.AddWithValue("@randevuTarih", DateTime.Parse(randevuTarih.Text).Date);
                    randevuEkle.Parameters.AddWithValue("@randevuSaat", saatVerisi.Value);
                    randevuEkle.Parameters.AddWithValue("@randevuNot", randevuNot.Text);
                    randevuEkle.Parameters.AddWithValue("@randevuDurumu", true);
                    randevuEkle.Parameters.AddWithValue("@randevuDoktor", secilenDoktor.Value);

                    randevuEkle.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
