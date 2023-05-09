using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi.ameliyathaneModulu
{

    public partial class yeniAmeliyatKaydiEkle : System.Web.UI.Page
    {
        public string tcNum;
        public int hastaId;

        /* Doktor tarih kontrolü */
        private bool doktorKontrol(SqlConnection sqlcn, DateTime gelenTarih)
        {
            using (SqlCommand doktorKontrolEt = new SqlCommand("SELECT ameliyatGirisTarihi FROM ameliyathane_Tablo WHERE ameliyatPersonelId = @personelNumarasi AND ameliyatGirisTarihi = @aGiris", sqlcn))
            {
                doktorKontrolEt.Parameters.AddWithValue("@personelNumarasi" ,ameliyatPersonelSecimi.SelectedValue);
                doktorKontrolEt.Parameters.AddWithValue("@aGiris", gelenTarih);
                SqlDataReader veriOkuyucu= doktorKontrolEt.ExecuteReader();
                if (veriOkuyucu.HasRows)
                {
                    veriOkuyucu.Close();
                    return true;
                }
                else
                {
                    veriOkuyucu.Close();
                    return false;
                }
                
            }
        }

        /* Ameliyat Ekleme Fonksiyonu */
        private void ameliyatEkle(SqlConnection sqlbg)
        {
            using (SqlCommand sqlCom = new SqlCommand("INSERT INTO ameliyathane_Tablo (ameliyatId, ameliyatGirisTarihi, ameliyatNotu, ameliyatPersonelId, ameliyatAnesteziTuru, ameliyatHastaId) VALUES (@aId, @aGirisT, @aNot, @aPId, @aAnesteziTuru, @aHastaId)", sqlbg))
            {
                /*(@aId, @aGirisT, @aNot, @aPId, @aAnesteziTuru, @aHastaId*/
                sqlCom.Parameters.AddWithValue("@aId", new Random().Next(11111,32767));
                sqlCom.Parameters.AddWithValue("@aGirisT", DateTime.Parse(ameliyatGirisTarihi.Text));
                sqlCom.Parameters.AddWithValue("@aNot", ameliyatNotu.Text);
                sqlCom.Parameters.AddWithValue("@aPId", ameliyatPersonelSecimi.SelectedValue);
                sqlCom.Parameters.AddWithValue("@aAnesteziTuru", ameliyatAnesteziTuru.Text);
                sqlCom.Parameters.AddWithValue("@aHastaId", hastaId);

                sqlCom.ExecuteNonQuery();
            }
        }

        /* Hasta Tc den ID alma */
        private void tcToId(SqlConnection baglanti, string tcNum)
        {
            using (SqlCommand komut = new SqlCommand("SELECT hasta_Id FROM hasta_kayitlar WHERE hasta_Tc = @hastatcnum", baglanti))
            {
                komut.Parameters.AddWithValue("@hastatcnum", ameliyatTckn.Text);
                SqlDataReader veriOkuyucu = komut.ExecuteReader();
                while (veriOkuyucu.Read())
                {
                    hastaId = veriOkuyucu.GetInt32(0);
                }
                veriOkuyucu.Close();
            }
        }

        /* Personel listesi çek */
        private void personelCek(SqlConnection baglanti)
        {
            baglanti.Open();
            using (SqlCommand veriGetir = new SqlCommand("SELECT personel_Id, personel_Isim, personel_Soyisim FROM personel_Tablo WHERE personel_Turu = 'Doktor'", baglanti))
            {
                SqlDataReader veriOkuyucu = veriGetir.ExecuteReader();
                while (veriOkuyucu.Read())
                {
                    ListItem yeniItem = new ListItem();
                    yeniItem.Text = veriOkuyucu.GetString(1) + veriOkuyucu.GetString(2);
                    yeniItem.Value = veriOkuyucu.GetInt32(0).ToString();
                    ameliyatPersonelSecimi.Items.Add(yeniItem);
                }
                veriOkuyucu.Close();
            }
            baglanti.Close();
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
                using (SqlConnection sqlBaglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                {
                    /* DropDownList e doktor listesini getirme */
                    personelCek(sqlBaglan);
                }
            }
        }

        protected void ameliyatEkle_Buton_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlIslemBaglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                sqlIslemBaglanti.Open();
                if (doktorKontrol(sqlIslemBaglanti, DateTime.Parse(ameliyatGirisTarihi.Text)))
                {
                    Response.Write("<h1 style='color: red;'>Seçilen personelin seçilen tarihte ameliyatı mevcut.</h1>");
                }
                else
                {
                    /* Tc Den ID Alma işlemi */
                    tcToId(sqlIslemBaglanti, ameliyatTckn.Text);
                    ameliyatEkle(sqlIslemBaglanti);
                    sqlIslemBaglanti.Close();
                    Response.Redirect("/ameliyathaneModulu/anasayfa.aspx");
                }
            }
        }
    }

}
