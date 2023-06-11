using System;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Configuration;

namespace HastaneOtomasyonProjesi
{
    public partial class hastaTetkikDetay : System.Web.UI.Page
    {
        public string tetkikDetayId = HttpContext.Current.Request.QueryString["tetkikId"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            using (erisimDuzey duzeyKontrol = new erisimDuzey())
            {
                if (HttpContext.Current.Request.QueryString["tetkikId"] == null)
                {
                    Response.Redirect("/panel.aspx");
                }
                else
                {
                    // Veritabanı bağlantısını açma
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                    {
                        conn.Open();

                        // Veritabanından veri çekme
                        using (SqlCommand cmd = new SqlCommand("SELECT tetkik_Tanimlari.tanim_tahlilIsmi AS [Tahlil Değer İsmi], tetkik_Tanimlari.tanim_SonucBirim AS [Tahlil Değer Birimi], tetkik_Tanimlari.tanim_referansAralik AS [Referans Aralığı], tetkik_DetayTablo.tetkik_Sonuc AS [Hasta Sonuç Değeri], personel_tablo.personel_Isim AS [Sorumlu Personel İsmi], personel_tablo.personel_Soyisim AS [Sorumlu Personel Soyismi] FROM tetkik_Tanimlari, tetkik_DetayTablo, personel_tablo WHERE tetkik_DetayTablo.tetkik_TanimId = tetkik_Tanimlari.tanim_Id AND personel_tablo.personel_Id = tetkik_DetayTablo.tetkik_calisanLab AND tetkik_Id = @tId;", conn))
                        {
                            cmd.Parameters.AddWithValue("@tId", tetkikDetayId);
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                da.Fill(dt);

                                // Gridview'i doldurma ve sütunları otomatik oluşturma
                                tetkikDetaylari.DataSource = dt;
                                tetkikDetaylari.DataBind();

                                // Veritabanı bağlantısını kapatma
                                conn.Close();
                            }

                        }
                    }
                }
            }
        }
    }
}