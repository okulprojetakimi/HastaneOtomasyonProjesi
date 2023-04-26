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
                using (SqlCommand uyeSorgula = new SqlCommand("SELECT personel_ErisimDuzey, personelKId FROM personel_kullaniciHesap WHERE personelKullaniciAdi = @kadi AND personelKullaniciSifre = @ksifre", sqlBaglantisi))
                {
                    uyeSorgula.Parameters.AddWithValue("@kadi", kullaniciAdi.Text);
                    uyeSorgula.Parameters.AddWithValue("@ksifre", kullaniciSifre.Text);
                    SqlDataReader sqlOku = uyeSorgula.ExecuteReader();
                    sqlOku.Read();
                    int personelErisimDuzeyi = (int)sqlOku["personel_ErisimDuzeyi"];
                    int personelId = (int)sqlOku["personelKId"];
                    string personelErisimKodu = "";
                    
                    /* Personel erişim kodu oluşturma */
                    Random rastgeleSayiUret = new Random();
                    string allCase = "abcdefghijklmnoprstuvwxyzABCDEFGHIJKLMNOPRSTUVWXYZ0123456789=-";
                    for (int index = 0; index < 16; index++)
                    {
                        personelErisimKodu = personelErisimKodu + allCase[rastgeleSayiUret.Next(0, allCase.Length)];
                    }

                    if (sqlOku.HasRows)
                    {
                        using (SqlConnection sqlBagla = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                        {
                            sqlBagla.Open();
                            using (SqlCommand yetkiKoduVer = new SqlCommand("UPDATE personel_kullaniciHesap SET personel_ErisimKodu = @erisimkodu WHERE personelKId = @personelIdsi"))
                            {
                                yetkiKoduVer.Parameters.AddWithValue("@erisimkodu", personelErisimKodu);
                                yetkiKoduVer.Parameters.AddWithValue("@personelIdsi", personelId);
                                yetkiKoduVer.ExecuteNonQuery();
                                yetkiKoduVer.Dispose();
                            }
                            sqlBagla.Close();
                        }
                        /* Cookie tanımlanıyor ! */
                        HttpCookie yetkiDuzeyi = new HttpCookie("yetkiDuzeyi");
                        yetkiDuzeyi.Value = personelErisimKodu;
                        yetkiDuzeyi.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Add(yetkiDuzeyi);

                        /* Son olarak panele yönlendirme yapılıyor! */
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