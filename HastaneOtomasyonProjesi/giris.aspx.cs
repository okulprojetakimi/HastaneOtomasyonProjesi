using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi
{
    public partial class giris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            using (SqlConnection sqlBaglantisi = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                sqlBaglantisi.Open();
                using (SqlCommand uyeSorgula = new SqlCommand("SELECT * FROM personel_kullaniciHesap WHERE personelKullaniciAdi = @kadi AND personelKullaniciSifre = @ksifre", sqlBaglantisi))
                {
                    uyeSorgula.Parameters.AddWithValue("@kadi", kullaniciAdi.Text);
                    uyeSorgula.Parameters.AddWithValue("@ksifre", kullaniciSifre.Text);
                    SqlDataReader sqlOku = uyeSorgula.ExecuteReader();
                    if (sqlOku.HasRows)
                    {
                        Response.Redirect("/panel.aspx");
                    }
                    else
                    {
                        Label1.Text = "Kullanıcı adı veya şifre yanlış!";
                    }
                    sqlBaglantisi.Close();
                }
            }
        }
    }
}