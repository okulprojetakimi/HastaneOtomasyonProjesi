using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;

namespace HastaneOtomasyonProjesi
{
    public partial class giris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie != null)
            {
                Response.Redirect("/panel.aspx");
            }
        }

        private static string Sifrele(string metin)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] metinBytes = Encoding.ASCII.GetBytes(metin);
                byte[] hashBytes = md5.ComputeHash(metinBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private bool ReCaptchaGecerliMi()
        {
            string response = Request.Form["g-recaptcha-response"];
            bool gecerli = false;

            // reCAPTCHA doğrulamasını burada gerçekleştirin
            // Google reCAPTCHA API'sini kullanarak doğrulama yapabilirsiniz

            // Örnek bir doğrulama kodu
            if (!string.IsNullOrEmpty(response))
            {
                // reCAPTCHA doğrulama kodunu burada doğrulayın
                // Google reCAPTCHA API'sini kullanabilirsiniz
                gecerli = true; // Geçici olarak doğrulama başarılı olarak kabul ediyoruz
            }

            return gecerli;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack)
                {
                    if (ReCaptchaGecerliMi())
                    {
                        using (SqlConnection sqlBaglantisi = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                        {
                            sqlBaglantisi.Open();
                            using (SqlCommand uyeSorgula = new SqlCommand("SELECT personel_ErisimDuzey, personelKId, personel_Turu FROM personel_kullaniciHesap, personel_tablo WHERE personelKullaniciAdi = @kadi AND personelKullaniciSifre = @ksifre AND personel_kullaniciHesap.personelId = personel_tablo.personel_Id", sqlBaglantisi))
                            {
                                uyeSorgula.Parameters.AddWithValue("@kadi", kullaniciAdi.Text);
                                uyeSorgula.Parameters.AddWithValue("@ksifre", Sifrele(kullaniciSifre.Text));
                                SqlDataReader sqlOku = uyeSorgula.ExecuteReader();
                                if (sqlOku.Read())
                                {
                                    string personelErisimKodu = "";

                                    /* Personel erişim kodu oluşturma */
                                    Random rastgeleSayiUretici = new Random();
                                    string tumKarakterler = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789=-";
                                    for (int i = 0; i < 16; i++)
                                    {
                                        personelErisimKodu += tumKarakterler[rastgeleSayiUretici.Next(0, tumKarakterler.Length)];
                                    }

                                    using (SqlConnection sqlBagla = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                                    {
                                        sqlBagla.Open();
                                        using (SqlCommand yetkiKoduVer = new SqlCommand("UPDATE personel_kullaniciHesap SET personel_ErisimKodu = @erisimkodu, personelSonErisim = @sonErisimT WHERE personelKullaniciAdi = @personelKadi AND personelKullaniciSifre = @kSifre", sqlBagla))
                                        {
                                            yetkiKoduVer.Parameters.AddWithValue("@erisimkodu", personelErisimKodu);
                                            yetkiKoduVer.Parameters.AddWithValue("@sonErisimT", DateTime.Now);
                                            yetkiKoduVer.Parameters.AddWithValue("@personelKadi", kullaniciAdi.Text);
                                            yetkiKoduVer.Parameters.AddWithValue("@kSifre", Sifrele(kullaniciSifre.Text));
                                            yetkiKoduVer.ExecuteNonQuery();
                                        }
                                    }

                                    /* Cookie tanımlama */
                                    HttpCookie yetkiDuzeyi = new HttpCookie("erisimCookie");
                                    yetkiDuzeyi.Value = personelErisimKodu;
                                    yetkiDuzeyi.Expires = DateTime.Now.AddDays(1);
                                    Response.Cookies.Add(yetkiDuzeyi);

                                    /* Son olarak panele yönlendirme yapma */
                                    Response.Redirect("/panel.aspx");
                                }
                                else
                                {
                                    Label1.Text = "Kullanıcı adı veya şifre yanlış!";
                                }
                            }
                        }
                    }
                    else
                    {
                        Response.Write("<h1 style='color: Red;'>Lütfen Captcha Doğrulamasını Tamamlayınız.</h1>");
                    }
                }
            }
            catch (Exception hata)
            {
                Label1.Text = "Teknik bir hata oluştu. Lütfen sistem yöneticisi ile iletişime geçin!";
                Label1.Text += "<br>" + hata.Message;
            }
        }
    }
}
