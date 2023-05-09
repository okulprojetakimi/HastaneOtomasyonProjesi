﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi.laboratuvarModulu
{
    public partial class laboratuvarModulEkle : System.Web.UI.Page
    {
        public int hastaId;
        public int personelId;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlBaglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                personelCek(sqlBaglan);
            }

            using (SqlConnection sqlBaglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                sqlBaglan.Open();
                using (SqlCommand komut = new SqlCommand("SELECT hasta_Id FROM hasta_kayitlar", sqlBaglan))
                {
                    SqlDataReader okuyucu = komut.ExecuteReader();
                    while (okuyucu.Read())
                    {
                        hastaId = okuyucu.GetInt32(0);
                    }
                    okuyucu.Close();
                    komut.Dispose();
                    sqlBaglan.Close();
                }

            }

            using (SqlConnection Baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                Baglan.Open();
                using (SqlCommand komut = new SqlCommand("SELECT personel_Id FROM personel_tablo", Baglan))
                {
                    SqlDataReader okuyucu = komut.ExecuteReader();
                    while (okuyucu.Read())
                    {
                        personelId = okuyucu.GetInt32(0);
                    }
                    Baglan.Close();
                    komut.Dispose();
                    okuyucu.Close();

                }
            }
        }
        protected void labEkleButon_click(object sender, EventArgs e)
        {
            using (SqlConnection vtBaglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                vtBaglan.Open();
                int random = new Random().Next(1111, 9999);
                using (SqlCommand LabEkle = new SqlCommand("INSERT INTO laboratuvar_modul (tetkik_Id,tetkik_istekTarih,tetkik_isteyenDoktorID,tetkik_durum,hasta_IdNumarasi)  VALUES (@tetkik_Id,@tetkik_istekTarih,@tetkik_isteyenDoktorID,@tetkik_durum,@hasta_IdNumarasi)", vtBaglan))
                {
                    LabEkle.Parameters.AddWithValue("@tetkik_Id", random);
                    LabEkle.Parameters.AddWithValue("@tetkik_istekTarih", Request.Form["tetkik_istekTarih"]);
                    LabEkle.Parameters.AddWithValue("@tetkik_isteyenDoktorID", labPersonelSecimi.SelectedValue);
                    LabEkle.Parameters.AddWithValue("@tetkik_durum", Request.Form["tetkik_durum"]);
                    LabEkle.Parameters.AddWithValue("@hasta_IdNumarasi", hastaId);
                    LabEkle.ExecuteNonQuery();

                    LabEkle.Dispose();
                    vtBaglan.Close();
                } 
            }
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
                    labPersonelSecimi.Items.Add(yeniItem);
                }
                veriOkuyucu.Close();
            }
            baglanti.Close();
        }
       


    }
}