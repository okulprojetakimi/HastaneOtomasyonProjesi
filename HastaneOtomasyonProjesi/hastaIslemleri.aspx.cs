using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi
{
    public partial class hastaIslemleri : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolEt = Request.Cookies["erisimCookie"];
            if (kontrolEt == null)
            {
                Response.Redirect("/giris.aspx");
            }

            /* Arama için post işlemi yapılırsa */
            if (IsPostBack)
            {
                string hastaIsim = Request.Form["hastaIsmi"];
                string hastaSoyismi = Request.Form["hastaSoyismi"];

                using (SqlConnection vtBagla = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                {
                    vtBagla.Open();
                    using (SqlCommand hastaCek = new SqlCommand("SELECT hasta_Tc, hasta_Adi, hasta_Soyadi, hasta_YakinAdi, hasta_tedaviDurumu FROM hasta_kayitlar WHERE hasta_Adi = @hastaIsimVerisi AND hasta_Soyadi = @hastaSoyisimVerisi", vtBagla))
                    {
                        hastaCek.Parameters.AddWithValue("@hastaIsimVerisi", hastaIsim);
                        hastaCek.Parameters.AddWithValue("@hastaSoyisimVerisi", hastaSoyismi);

                        using (SqlDataReader veriOkuyucu = hastaCek.ExecuteReader())
                        {
                            /* Veri Tablosuna Ekleme */
                            DataTable hastaTablosu = new DataTable();
                            hastaTablosu.Load(veriOkuyucu);

                        }
                        hastaCek.Dispose();
                        vtBagla.Close();
                        
                    }
                }
            }
        }
    }
}