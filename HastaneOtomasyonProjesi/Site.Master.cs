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
    public partial class SiteMaster : MasterPage
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
                    /* Bakım Kontrolü */
                    using (SqlCommand bakimKontrol = new SqlCommand("SELECT ayar_BakimModu FROM sistem_tablo WHERE ayar_Id = 1 ", sqlCon))
                    {
                        if ((Boolean)bakimKontrol.ExecuteScalar())
                        {
                            sqlCon.Close();
                            Response.Redirect("/bakim.aspx");
                        }
                        else
                        {
                            /* Oturum kodu ve hesap aktiflik kontrolü */
                            using (SqlCommand HesapKontrol = new SqlCommand("SELECT personel_ErisimKodu, personel_HesapAktiflik FROM personel_kullaniciHesap WHERE personel_ErisimKodu = @pKod", sqlCon))
                            {
                                HesapKontrol.Parameters.AddWithValue("@pKod", kontrolCookie.Value);
                                using (SqlDataReader veriOkuyucu = HesapKontrol.ExecuteReader())
                                {
                                    if (veriOkuyucu.HasRows)
                                    {
                                        while (veriOkuyucu.Read())
                                        {
                                            if (veriOkuyucu.GetString(0) != kontrolCookie.Value)
                                            {
                                                sqlCon.Close();
                                                Response.Redirect("/giris.aspx");
                                            }
                                            else
                                            {
                                                if (!veriOkuyucu.GetBoolean(1))
                                                {
                                                    sqlCon.Close();
                                                    Response.Redirect("/bloklandi.html");
                                                }
                                            }
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
    }
}