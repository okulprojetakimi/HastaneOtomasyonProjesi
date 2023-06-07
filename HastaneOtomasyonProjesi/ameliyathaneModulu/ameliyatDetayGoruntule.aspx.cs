using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace HastaneOtomasyonProjesi.ameliyathaneModulu
{
    public partial class ameliyatDetayGoruntule : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrol = Request.Cookies["erisimCookie"];
            using (erisimDuzey erisimKontrol = new erisimDuzey())
            {
                if (!erisimKontrol.yetkiKontrol("Hemşire", kontrol.Value))
                {
                    Response.Redirect("/panel.aspx");
                }
                if (HttpContext.Current.Request.QueryString["ameliyatNumarasi"] != null)
                {
                    string ameliyatNumarasi = HttpContext.Current.Request.QueryString["ameliyatNumarasi"];

                    using (SqlConnection sqlBaglanti = new SqlConnection(connectionString))
                    {
                        sqlBaglanti.Open();

                        using (SqlCommand veriCek = new SqlCommand("SELECT personel_Tablo.personel_Isim + ' ' + personel_Tablo.personel_Soyisim AS [doktorIsmi], ameliyathane_Tablo.ameliyatGirisTarihi, ameliyathane_Tablo.ameliyatCikisTarihi, ameliyathane_Tablo.ameliyatNotu, ameliyathane_Tablo.ameliyatAnesteziTuru FROM ameliyathane_Tablo INNER JOIN personel_tablo ON ameliyathane_Tablo.ameliyatPersonelId = personel_tablo.personel_Id WHERE ameliyatId = @parametre", sqlBaglanti))
                        {
                            veriCek.Parameters.AddWithValue("@parametre", ameliyatNumarasi);
                            using (SqlDataReader veriOkuyucu = veriCek.ExecuteReader())
                            {
                                if (veriOkuyucu.Read())
                                {
                                    ameliyatAnesteziTuru.Text = veriOkuyucu.GetString(4);
                                    ameliyat_Doktor.Text = veriOkuyucu.GetString(0);
                                    ameliyat_Not.Text = veriOkuyucu.GetString(3);
                                    ameliyat_GirisT.Text = veriOkuyucu.GetDateTime(1).ToString();
                                    if (!veriOkuyucu.IsDBNull(2))
                                    {
                                        ameliyat_CikisT.Text = veriOkuyucu.GetDateTime(2).ToString();
                                    }
                                    else
                                    {
                                        ameliyat_CikisT.Text = "Bitmedi";
                                    }
                                }
                                else
                                {
                                    Response.Redirect("/panel.aspx");
                                }
                            }
                        }

                        using (SqlCommand ilacCek = new SqlCommand("SELECT ameliyathane_kullanilanIlaclar.k_IlacAmeliyatId AS [Kayıt Numarası], ilaclar_tablosu.ilacIsmi AS [Kullanılan İlaç İsmi], ilaclar_tablosu.ilacreceteTuru AS [İlaç Reçete Türü] FROM ameliyathane_kullanilanIlaclar INNER JOIN ilaclar_tablosu ON ameliyathane_kullanilanIlaclar.k_IlacBilgi = ilaclar_tablosu.ilacId WHERE ameliyathane_kullanilanIlaclar.k_IlacAmeliyatId = @idParametre", sqlBaglanti))
                        {
                            ilacCek.Parameters.AddWithValue("@idParametre", ameliyatNumarasi);
                            DataTable veriTablosu = new DataTable();
                            using (SqlDataAdapter adapter = new SqlDataAdapter(ilacCek))
                            {
                                adapter.Fill(veriTablosu);
                            }
                            ameliyatKullanilan_Tablo.DataSource = veriTablosu;
                            ameliyatKullanilan_Tablo.DataBind();
                        }
                    }
                }
                else
                {
                    Response.Redirect("anasayfa.aspx");
                }
            }
                
        }

        protected void hastaIlac_Ekle_Click(object sender, EventArgs e)
        {
            string ameliyatNumarasi = HttpContext.Current.Request.QueryString["ameliyatNumarasi"];
            int ilacNumarasi = new Random().Next(1111, 9999);

            using (SqlConnection sqlBaglanti = new SqlConnection(connectionString))
            {
                sqlBaglanti.Open();

                using (SqlCommand sqlKomutu = new SqlCommand("INSERT INTO ameliyathane_kullanilanIlaclar (k_IlacId, k_IlacBilgi, k_IlacAmeliyatId) VALUES (@ilacNumarasi, @lacBilgiNumarasi, @ilacAmeliyat)", sqlBaglanti))
                {
                    sqlKomutu.Parameters.AddWithValue("@ilacNumarasi", ilacNumarasi);
                    sqlKomutu.Parameters.AddWithValue("@lacBilgiNumarasi", ilacIdNum.Text);
                    sqlKomutu.Parameters.AddWithValue("@ilacAmeliyat", ameliyatNumarasi);
                    sqlKomutu.ExecuteNonQuery();
                }
            }

            Response.Redirect("/ameliyathaneModulu/ameliyatDetayGoruntule.aspx?ameliyatNumarasi=" + ameliyatNumarasi);
        }

        protected void bitis_Ayarla_Click(object sender, EventArgs e)
        {
            string ameliyatNumarasi = HttpContext.Current.Request.QueryString["ameliyatNumarasi"];

            using (SqlConnection sqlBaglanti = new SqlConnection(connectionString))
            {
                sqlBaglanti.Open();

                using (SqlCommand durumAyarla = new SqlCommand("UPDATE ameliyathane_Tablo SET ameliyatCikisTarihi = @cikisTarih WHERE ameliyatId = @ameliyatNum", sqlBaglanti))
                {
                    durumAyarla.Parameters.AddWithValue("@cikisTarih", DateTime.Now);
                    durumAyarla.Parameters.AddWithValue("@ameliyatNum", ameliyatNumarasi);
                    durumAyarla.ExecuteNonQuery();
                }
            }

            Response.Redirect("/ameliyathaneModulu/ameliyatDetayGoruntule.aspx?ameliyatNumarasi=" + ameliyatNumarasi);
        }
    }
}
