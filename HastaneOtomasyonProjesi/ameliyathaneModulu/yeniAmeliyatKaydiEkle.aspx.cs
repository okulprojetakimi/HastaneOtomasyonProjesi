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
    /*
     * BAŞLAMADAN ÖNCE OKUMAN GEREKLİ ;D
     1-) Lütfen veri eklemeden önce seçilen doktorun seçilen tarih için daha önceden ameliyat randevusu varmı yok mu onu kontrol eden fonksiyon da yaz.
     */
    public partial class yeniAmeliyatKaydiEkle : System.Web.UI.Page
    {
        public string hastaTcNum;
        public int hastaId;
        public int ilacId;
        public int personelId;

        /* Bu fonksiyon DropDown list in içine tüm doktorların listesini atar. 
         DataGridView i dolduruken text doktor isim + soyisim, value de doktorun id si olacak. Böylece datagridview selected value ile 
        direk olarak seçilen id yi veritabanına ekleyebileceğiz.
         */
        private void personelListeDoldur(SqlConnection sqlBaglanti)
        {
            using (SqlCommand veriCekmeKomut = new SqlCommand("SELECT personel_Id, personel_Isim, personel_Soyisim FROM personel_tablo WHERE personel_Turu = 'Doktor'"))
            {
                /* Buradan devam et!*/
                SqlDataReader veriOkuyucu = veriCekmeKomut.ExecuteReader();
                while (veriOkuyucu.Read())
                {
                    ameliyatPersonelSecimi.Items.Add(new ListItem(veriOkuyucu.GetString(1) + " " + veriOkuyucu.GetString(2), veriOkuyucu.GetInt32(0).ToString()));
                }
            }
        }

        /* Bu fonksiyon kayıt ekleme butonuun OnClick özelliğine bağlıdır. Tıklandığında bu fonksiyon çalışır. */
        private void kayitEkleButon(object sender, EventArgs e)
        {
            using (SqlConnection vtBaglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                vtBaglan.Open();
                using (SqlCommand AmeliyatKaydıEkleme = new SqlCommand("INSERT INTO ameliyathane_Tablo(ameliyatId,ameliyatGirisTarihi,ameliyatNotu,ameliyatPersonelId,ameliyatAnesteziTuru,ameliyatHastaId) VALUES (@ameliyatId,@ameliyatGirisTarihi,@ameliyatNotu,@ameliyatPersonelId,@ameliyatAnesteziTuru,@ameliyatHastaId)", vtBaglan))
                {
                    AmeliyatKaydıEkleme.Parameters.AddWithValue("@ameliyatId", new Random().Next(11111, 32676));
                    AmeliyatKaydıEkleme.Parameters.AddWithValue("@ameliyatGirisTarihi", DateTime.Parse(ameliyatGirisTarihi.Text));
                    AmeliyatKaydıEkleme.Parameters.AddWithValue("@ameliyatNotu", ameliyatNotu.Text);
                    AmeliyatKaydıEkleme.Parameters.AddWithValue("@ameliyatPersonelId", ameliyatPersonelSecimi.SelectedValue);
                    AmeliyatKaydıEkleme.Parameters.AddWithValue("@ameliyatAnesteziTuru", ameliyatAnesteziTuru.Text);
                    AmeliyatKaydıEkleme.Parameters.AddWithValue("@ameliyatHastaId", hastaId);

                    AmeliyatKaydıEkleme.ExecuteNonQuery();
                    AmeliyatKaydıEkleme.Dispose();
                    vtBaglan.Close();
                }
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
                if (HttpContext.Current.Request.QueryString["hasta"] == null)
                {
                      Response.Redirect("/panel.aspx");
                }
                else
                {
                    hastaTcNum = HttpContext.Current.Request.QueryString["hasta"];
                    using (SqlConnection sqlBaglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                    {
                        personelListeDoldur(sqlBaglan);
                        sqlBaglan.Open();
                        using (SqlCommand komut = new SqlCommand("SELECT hasta_Id, hasta_Adi, hasta_Soyadi FROM hasta_kayitlar WHERE hasta_Tc = @hastatcnum", sqlBaglan))
                        {
                            komut.Parameters.AddWithValue("@hastaTC", hastaTcNum);
                            SqlDataReader veriOkuyucu = komut.ExecuteReader();
                            while (veriOkuyucu.Read())
                            {
                                hastaId = veriOkuyucu.GetInt32(0);                              
                            }
                            veriOkuyucu.Close();
                            sqlBaglan.Close();
                        }

                    }
 
                    }
                }
            }
        }

}