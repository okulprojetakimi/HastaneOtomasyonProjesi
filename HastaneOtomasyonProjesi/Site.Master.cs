﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace HastaneOtomasyonProjesi
{
    public partial class SiteMaster : MasterPage
    {
        public string yetkiDuzey = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Mevcut Oturum Bilgilerini Al */

            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null || kontrolCookie.Value.Trim() == "")
            {
                Response.Redirect("/giris.aspx");
            }
            else
            {
                /* Kontrol İşlemleri Başlar */
                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                {
                    sqlCon.Open();
                    using (SqlCommand veriCek = new SqlCommand("SELECT personel_kullaniciHesap.personel_ErisimKodu, personel_kullaniciHesap.personel_HesapAktiflik, sistem_Tablo.ayar_BakimModu, personel_Tablo.personel_Turu FROM personel_kullaniciHesap, sistem_Tablo, personel_Tablo WHERE personel_kullaniciHesap.personel_ErisimKodu = @erisimKodu AND personel_kullaniciHesap.personelId = personel_Tablo.personel_Id", sqlCon))
                    {
                        veriCek.Parameters.AddWithValue("@erisimKodu", kontrolCookie.Value);
                        using (SqlDataReader veriOkuyucu = veriCek.ExecuteReader())
                        {
                            if (veriOkuyucu.Read())
                            {
                                if (veriOkuyucu.GetString(0) != kontrolCookie.Value)
                                {
                                    Response.Redirect("/cikis.aspx");
                                }
                                else if (!veriOkuyucu.GetBoolean(1))
                                {
                                    Response.Redirect("/bloklandi.html");
                                }
                                else if (veriOkuyucu.GetBoolean(2))
                                {
                                    Response.Redirect("/bakim.aspx");
                                }
                                yetkiDuzey = veriOkuyucu.GetString(3);
                            }
                            else
                            {
                                Response.Redirect("/cikis.aspx");
                            }
                        }
                    }
                }

            }
        }
    }
}