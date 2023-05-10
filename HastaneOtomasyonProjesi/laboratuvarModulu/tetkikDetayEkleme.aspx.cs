using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi
{
    public partial class tetkikDetayEkleme : System.Web.UI.Page
    {
        public string tetkikIdNumarasi;
        public string selected;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null || kontrolCookie.Value.Trim() == "")
            {
                Response.Redirect("/cikis.aspx");
            }
            else
            {
                if (HttpContext.Current.Request.QueryString["tetkikId"] == null)
                {
                    Response.Redirect("/panel.aspx");
                }
                else
                {
                    /* Burdan sonra başlar */
                    tetkikIdNumarasi = HttpContext.Current.Request.QueryString["tetkikId"]; // Get ten gelen tetkikId numarasını alır ;D

                    using (SqlConnection sqlBaglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                    {
                        personelCek(sqlBaglan);
                        tetkikAdı(sqlBaglan);

                    }

                }
            }
        }


        protected void labDetayEkleButon_click(object sender, EventArgs e)
        {
            //using (SqlConnection vtBaglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            //{
            //    vtBaglan.Open();
            //    int random = new Random().Next(111111, 999999);
            //    using (SqlCommand LabDetayEkle = new SqlCommand("INSERT INTO tetkik_DetayTablo (tetkik_detayId,tetkik_Sonuc,tetkikdetay_Durum,tetkik_calisanLab,tetkik_Id,tetkik_TanimId) VALUES (@tetkik_detayId,@tetkik_Sonuc,@tetkikdetay_Durum,@tetkik_calisanLab,@tetkik_Id,@tetkik_TanimId) ", vtBaglan))
            //    {
            //        LabDetayEkle.Parameters.AddWithValue("@tetkik_detayId", random);
            //        LabDetayEkle.Parameters.AddWithValue("@tetkik_Sonuc", tetkik_Sonuc.Text);
            //        LabDetayEkle.Parameters.AddWithValue("@tetkikdetay_Durum", tetkikdetay_Durum.SelectedValue);
            //        LabDetayEkle.Parameters.AddWithValue("@tetkik_calisanLab", secim.SelectedValue);
            //        LabDetayEkle.Parameters.AddWithValue("@tetkik_Id", tetkikIdNumarasi);
            //        LabDetayEkle.Parameters.AddWithValue("@tetkik_TanimId", labTetkikAdı.SelectedValue);
            //        LabDetayEkle.ExecuteNonQuery();
            //        vtBaglan.Close();
            //    }
            //}
            Response.Write(labTetkikAdi.SelectedValue);
        }
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
                    secim.Items.Add(yeniItem);
                }
                veriOkuyucu.Close();
            }
            baglanti.Close();
        }
        private void tetkikAdı(SqlConnection vB)
        {
            using (SqlCommand tetkikAdı = new SqlCommand("SELECT tanim_Id,tanim_tahlilIsmi,tanim_SonucBirim,tanim_referansAralik FROM tetkik_Tanimlari", vB))
            {
                vB.Open();
                SqlDataReader taOku = tetkikAdı.ExecuteReader();
                {
                    while (taOku.Read())
                    {
                        ListItem yta = new ListItem();
                        yta.Text = taOku.GetString(1) + taOku.GetString(2) + taOku.GetString(3);
                        yta.Value = taOku.GetInt32(0).ToString();
                        labTetkikAdi.Items.Add(yta);
                    }
                    taOku.Close();
                }
                vB.Close();
            }
        }
        //zz

        //protected void labTetkikAdi_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    selected = labTetkikAdi.SelectedItem.Value;
        //}
    }
}