using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi.ameliyathaneModulu
{
    public partial class ameliyatDetayGoruntule : System.Web.UI.Page
    {
        public DateTime gTarih;
        public DateTime cTarih;
        public string anesteziTuru;
        public string girenDoktor;
        public string ameliyatNotu;

        private void kullanilanCek(SqlConnection sqlCon, string id)
        {
            using (SqlCommand kullanilanIlaclar = new SqlCommand("SELECT ameliyathane_kullanilanIlaclar.k_IlacAmeliyatId AS [Kayıt Numarası], ilaclar_tablosu.ilacIsmi AS [Kullanılan İlaç İsmi], ilaclar_tablosu.ilacreceteTuru AS [İlaç Reçete Türü] FROM ameliyathane_kullanilanIlaclar,ilaclar_tablosu WHERE ameliyathane_kullanilanIlaclar.k_IlacAmeliyatId = @aParam AND ameliyathane_kullanilanIlaclar.k_IlacBilgi = ilaclar_tablosu.ilacId", sqlCon))
            {
                kullanilanIlaclar.Parameters.AddWithValue("@aParam", id);
                SqlDataAdapter adapterCom = new SqlDataAdapter(kullanilanIlaclar);
                DataSet ds = new DataSet();
                adapterCom.Fill(ds);

                ameliyatKullanilan_Tablo.DataSource = ds;
                ameliyatKullanilan_Tablo.DataBind();
                kullanilanIlaclar.Dispose();
                sqlCon.Close();
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null)
            {
                Response.Redirect("/panel.aspx");
            }
            else
            {
                // ameliyatNumarasi
                if (HttpContext.Current.Request.QueryString["ameliyatNumarasi"] != null)
                {
                    try
                    {
                        string ameliyatNumarasi = HttpContext.Current.Request.QueryString["ameliyatNumarasi"];
                        using (SqlConnection getDb = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                        {
                            getDb.Open();
                            using (SqlCommand veriCek = new SqlCommand("SELECT personel_Tablo.personel_Isim, ameliyathane_Tablo.ameliyatGirisTarihi,ameliyathane_Tablo.ameliyatCikisTarihi,ameliyathane_Tablo.ameliyatNotu, ameliyathane_Tablo.ameliyatAnesteziTuru FROM ameliyathane_Tablo,personel_tablo WHERE ameliyathane_Tablo.ameliyatPersonelId = personel_tablo.personel_Id AND ameliyatId = @aParam", getDb))
                            {
                                veriCek.Parameters.AddWithValue("@aParam", ameliyatNumarasi);
                                SqlDataReader veriOkuyucu = veriCek.ExecuteReader();
                                while (veriOkuyucu.Read())
                                {
                                    girenDoktor = veriOkuyucu.GetString(0);
                                    gTarih = veriOkuyucu.GetDateTime(1);
                                    cTarih = veriOkuyucu.GetDateTime(2);
                                    ameliyatNotu = veriOkuyucu.GetString(3);
                                    anesteziTuru = veriOkuyucu.GetString(4);
                                    ameliyatAnesteziTuru.Text = anesteziTuru;
                                    ameliyat_Doktor.Text = girenDoktor;
                                    ameliyat_Not.Text = ameliyatNotu;
                                    ameliyat_GirisT.Text = gTarih.ToString();
                                    ameliyat_CikisT.Text = cTarih.ToString();

                                }

                                veriOkuyucu.Close();
                                veriCek.Dispose();
                            }
                            kullanilanCek(getDb, ameliyatNumarasi);
                        }
                    }
                    catch (Exception damnError)
                    {
                        Response.Write("<script>alert("+ damnError.Message+ ")</script>");
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
            using (SqlConnection sqlBaglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                sqlBaglanti.Open();
                int generateId = new Random().Next(1111,9999);
                using (SqlCommand sqlKomutu = new SqlCommand("INSERT INTO ameliyathane_kullanilanIlaclar (k_IlacId, k_IlacBilgi, k_IlacAmeliyatId) VALUES (@ilacNumarasi, @lacBilgiNumarasi,@ilacAmeliyat)",sqlBaglanti))
                {
                    sqlKomutu.Parameters.AddWithValue("@ilacNumarasi", generateId);
                    sqlKomutu.Parameters.AddWithValue("@lacBilgiNumarasi", ilacIdNum.Text);
                    sqlKomutu.Parameters.AddWithValue("@ilacAmeliyat", HttpContext.Current.Request.QueryString["ameliyatNumarasi"]);
                    sqlKomutu.ExecuteNonQuery();
                    sqlKomutu.Dispose();
                    sqlBaglanti.Close();
                    Response.Redirect("/ameliyathaneModulu/ameliyatDetayGoruntule.aspx?ameliyatNumarasi="+ HttpContext.Current.Request.QueryString["ameliyatNumarasi"]);
                }
            }
        }
    }
}