﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;

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

        private bool ValidateReCaptcha()
        {
            string response = Request.Form["g-recaptcha-response"];
            bool valid = false;

            // reCAPTCHA doğrulama işlemini burada gerçekleştirin
            // Google reCAPTCHA API'sini kullanarak doğrulama yapabilirsiniz

            // Örnek bir doğrulama kodu
            if (!string.IsNullOrEmpty(response))
            {
                // reCAPTCHA doğrulama kodunu burada doğrulayın
                // Google reCAPTCHA API'sini kullanabilirsiniz
                valid = true; // Geçici olarak doğrulama başarılı olarak kabul ediyoruz
            }

            return valid;
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack)
                {
                    if (ValidateReCaptcha())
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

                                if (sqlOku.HasRows)
                                {
                                    string personelErisimKodu = "";
                                    /* Personel erişim kodu oluşturma */
                                    Random rastgeleSayiUret = new Random();
                                    string allCase = "abcdefghijklmnoprstuvwxyzABCDEFGHIJKLMNOPRSTUVWXYZ0123456789=-";
                                    for (int index = 0; index < 16; index++)
                                    {
                                        personelErisimKodu = personelErisimKodu + allCase[rastgeleSayiUret.Next(0, allCase.Length)];
                                    }

                                    using (SqlConnection sqlBagla = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                                    {
                                        sqlBagla.Open();
                                        using (SqlCommand yetkiKoduVer = new SqlCommand("UPDATE personel_kullaniciHesap SET personel_ErisimKodu = @erisimkodu, personelSonErisim = @sonErisimT WHERE personelKullaniciAdi = @personelKadi AND personelKullaniciSifre = @kSifre", sqlBagla))
                                        {
                                            yetkiKoduVer.Parameters.AddWithValue("@erisimkodu", personelErisimKodu);
                                            yetkiKoduVer.Parameters.AddWithValue("@sonErisimT", DateTime.Parse(DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString()));
                                            yetkiKoduVer.Parameters.AddWithValue("@personelKadi", kullaniciAdi.Text);
                                            yetkiKoduVer.Parameters.AddWithValue("@kSifre", kullaniciSifre.Text);
                                            yetkiKoduVer.ExecuteNonQuery();
                                            yetkiKoduVer.Dispose();
                                        }
                                        sqlBagla.Close();
                                    }
                                    /* Cookie tanımlanıyor ! */
                                    HttpCookie yetkiDuzeyi = new HttpCookie("erisimCookie");
                                    yetkiDuzeyi.Value = personelErisimKodu;
                                    yetkiDuzeyi.Expires = DateTime.Now.AddDays(1);
                                    Response.Cookies.Add(yetkiDuzeyi);

                                    /* Son olarak panele yönlendirme yapılıyor!  */
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
                    else
                    {
                        Response.Write("<h1 style='color: Red;'>Lütfen Captcha Doğrulamasını Tamamlayınız.</h1>");
                    }
                }
                else
                {

                }
            }
            catch (Exception)
            {
                Label1.Text = "Teknik bir hata var Lütfen sistem yöneticisi ile görüşün!";
            }
        }
    }
}