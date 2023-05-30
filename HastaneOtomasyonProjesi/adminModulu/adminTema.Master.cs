using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi.adminModulu
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
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
                    using (SqlCommand veriCek = new SqlCommand("SELECT personel_kullaniciHesap.personel_ErisimKodu, personel_kullaniciHesap.personel_HesapAktiflik, personel_kullaniciHesap.personel_ErisimDuzey FROM personel_kullaniciHesap, personel_tablo WHERE personel_kullaniciHesap.personel_ErisimKodu = @erisimKodu AND personel_tablo.personel_Id = personel_kullaniciHesap.personelId", sqlCon))
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
                                else if (veriOkuyucu.GetInt32(2) != 1)
                                {
                                    Response.Redirect("/panel.aspx");
                                }
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