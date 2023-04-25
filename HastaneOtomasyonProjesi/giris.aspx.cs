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
    public partial class giris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sonErisimTarihi = DateTime.Now.ToLongTimeString().ToString(); /* Erişim Tarihi*/
            /* Kullanıcı arama  */
            string kullaniciSorgula = "SELECT COUNT(*) FROM personel_kullaniciHesap WHERE personelKullaniciAdi = @kadi AND personelKullaniciSifre = @ksifre";
            
            using (SqlConnection sqlBaglantisi = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                sqlBaglantisi.Open();
                using (SqlCommand uyeSorgula = new SqlCommand(kullaniciSorgula, sqlBaglantisi))
                {
                    uyeSorgula.Parameters.AddWithValue("@kadi", Request.Form["kullaniciAdi_Input"]);
                    uyeSorgula.Parameters.AddWithValue("@ksifre", Request.Form["kullaniciSifre_Input"]);
                    /* Sorgulama yapılır */
                    SqlDataReader uyeSorgulama = uyeSorgula.ExecuteReader();
                    uyeSorgulama.Read();
                    int uyeSonuc = (int)uyeSorgulama[0];

                    if (uyeSonuc != 0)
                    {

                    }
                    sqlBaglantisi.Close();
                }
            }
        }
    }
}