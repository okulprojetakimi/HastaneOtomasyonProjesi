using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace HastaneOtomasyonProjesi
{
    public partial class tetkikDetayEkleme : System.Web.UI.Page
    {
        public string tetkikIdNumarasi;
        public string selected;
        public SqlConnection vtBaglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            using (erisimDuzey erisim = new erisimDuzey())
            {
                HttpCookie cookie = Request.Cookies["erisimCookie"];
                if (!erisim.yetkiKontrol("Laboratuvar Teknikeri", cookie.Value) || HttpContext.Current.Request.QueryString["tetkikId"] == null)
                {
                    Response.Redirect("/panel.aspx");
                }
                /* Burdan sonra başlar */
                tetkikIdNumarasi = HttpContext.Current.Request.QueryString["tetkikId"];

                // Veritabanı bağlantısını açma
                // Veritabanından veri çekme
                using (SqlCommand cmd = new SqlCommand("SELECT tetkik_Tanimlari.tanim_tahlilIsmi AS [Tahlil Değer İsmi], tetkik_Tanimlari.tanim_SonucBirim AS [Tahlil Değer Birimi], tetkik_Tanimlari.tanim_referansAralik AS [Referans Aralığı], tetkik_DetayTablo.tetkik_Sonuc AS [Hasta Sonuç Değeri], personel_tablo.personel_Isim AS [Sorumlu Personel İsmi], personel_tablo.personel_Soyisim AS [Sorumlu Personel Soyismi] FROM tetkik_Tanimlari, tetkik_DetayTablo, personel_tablo WHERE tetkik_DetayTablo.tetkik_TanimId = tetkik_Tanimlari.tanim_Id AND personel_tablo.personel_Id = tetkik_DetayTablo.tetkik_calisanLab AND tetkik_Id = @tId;", vtBaglan))
                {
                    vtBaglan.Open();
                    cmd.Parameters.AddWithValue("@tId", tetkikIdNumarasi);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Gridview'i doldurma ve sütunları otomatik oluşturma
                        tetkikDetaylari.DataSource = dt;
                        tetkikDetaylari.DataBind();

                        // Veritabanı bağlantısını kapatma
                        vtBaglan.Close();
                    }
                }
            }
        }

        protected void labDetayEkleButon_click(object sender, EventArgs e)
        {
            string tetkikIdNumarasi = HttpContext.Current.Request.QueryString["tetkikId"];
            int random = new Random().Next(111111, 999999);
            vtBaglan.Open();
            using (SqlCommand kontrol = new SqlCommand("SELECT tetkik_detayId FROM tetkik_DetayTablo WHERE tetkik_Id = @tetkikID AND tetkik_TanimId = @tanimID AND tetkik_calisanLab = @calisanLab", vtBaglan))
            {
                kontrol.Parameters.AddWithValue("@tetkikID", tetkikIdNumarasi);
                kontrol.Parameters.AddWithValue("@tanimID", labTetkikAdı.SelectedValue);
                kontrol.Parameters.AddWithValue("@calisanLab", PersonelSecimi.SelectedValue);
                SqlDataReader d = kontrol.ExecuteReader();
                if (!d.HasRows)
                {
                    d.Close();
                    using (SqlCommand LabDetayEkle = new SqlCommand("INSERT INTO tetkik_DetayTablo (tetkik_detayId, tetkik_Sonuc, tetkikdetay_Durum, tetkik_calisanLab, tetkik_Id, tetkik_TanimId) VALUES (@tetkik_detayId, @tetkik_Sonuc, @tetkikdetay_Durum, @tetkik_calisanLab, @tetkik_Id, @tetkik_TanimId)", vtBaglan))
                    {
                        LabDetayEkle.Parameters.AddWithValue("@tetkik_detayId", random);
                        LabDetayEkle.Parameters.AddWithValue("@tetkik_Sonuc", tetkik_Sonuc.Text);
                        LabDetayEkle.Parameters.AddWithValue("@tetkikdetay_Durum", tetkikdetay_Durum.SelectedValue);
                        LabDetayEkle.Parameters.Add("@tetkik_calisanLab", PersonelSecimi.SelectedValue.ToString());
                        LabDetayEkle.Parameters.AddWithValue("@tetkik_Id", tetkikIdNumarasi);
                        LabDetayEkle.Parameters.AddWithValue("@tetkik_TanimId", labTetkikAdı.SelectedValue);

                        LabDetayEkle.ExecuteNonQuery();
                        vtBaglan.Close();
                    }
                }
                else
                {
                    d.Close();
                    Response.Write("<script>alert('Daha önce eklenmiş.')</script>");
                }
            }
        }
    }
}
