using Microsoft.Ajax.Utilities;
using Microsoft.SqlServer.Server;
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
    public partial class hesapIslem : System.Web.UI.Page
    {
        public SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.QueryString["personelNumarasi"] == null)
            {
                Response.Redirect("/panel.aspx");
            }
            else
            {
                /* İşleme devam */
                if (!IsPostBack)
                {
                    sqlcon.Open();
                    using (SqlCommand veriCekme = new SqlCommand("SELECT * FROM personel_kullaniciHesap WHERE personelId = @pId", sqlcon))
                    {
                        veriCekme.Parameters.AddWithValue("@pId", HttpContext.Current.Request.QueryString["personelNumarasi"]);
                        SqlDataReader veriOkuyucu = veriCekme.ExecuteReader();

                        while (veriOkuyucu.Read())
                        {
                            if (veriOkuyucu.HasRows)
                            {
                                durum_deger.Value = "ok";
                                personelKullaniciAdi.Text = veriOkuyucu.GetString(1);
                                personelKullaniciSifre.Text = veriOkuyucu.GetString(2);
                                personelHOlusturmaTarihi.Text = veriOkuyucu.GetDateTime(3).ToString();
                                personelSonErisim.Text = veriOkuyucu.GetDateTime(4).ToString();
                                personel_ErisimDuzey.SelectedIndex = veriOkuyucu.GetInt32(6);
                                personel_ErisimKodu.Text = veriOkuyucu.GetString(7);
                                if (veriOkuyucu.GetBoolean(8))
                                {
                                    personel_HesapAktiflik.SelectedIndex = 1;
                                }
                                else
                                {
                                    personel_HesapAktiflik.SelectedIndex = 0;
                                }
                            }
                            else
                            {
                                durum_deger.Value = "no";
                            }
                        }
                        veriOkuyucu.Close();
                    }
                    sqlcon.Close();

                }
            }
        }

        protected void kaydet_Buton_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                sqlcon.Open();
                using (SqlCommand guncelleme = new SqlCommand())
                {
                    if (durum_deger.Value == "ok")
                    {
                        guncelleme.Connection = sqlcon;
                        guncelleme.CommandText = "UPDATE personel_kullaniciHesap SET personelKullaniciAdi = @kullaniciAdi, personelKullaniciSifre = @sifre, personel_ErisimDuzey = @erisimDuzey, personel_ErisimKodu = @erisimKodu, personel_HesapAktiflik = @hesapAktiflik WHERE personelId = @pId";
                        guncelleme.Parameters.AddWithValue("@kullaniciAdi", personelKullaniciAdi.Text);
                        guncelleme.Parameters.AddWithValue("@sifre", personelKullaniciSifre.Text);
                        guncelleme.Parameters.AddWithValue("@erisimDuzey", personel_ErisimDuzey.SelectedIndex);
                        guncelleme.Parameters.AddWithValue("@erisimKodu", personel_ErisimKodu.Text);
                        guncelleme.Parameters.AddWithValue("@hesapAktiflik", personel_HesapAktiflik.SelectedIndex);
                        guncelleme.Parameters.AddWithValue("@pId", HttpContext.Current.Request.QueryString["personelNumarasi"]);
                        guncelleme.ExecuteNonQuery();
                        Response.Write("<h1 style='color: Green; font-family: sans-serif;'>Hesap Başarıyla Güncellendi!</h1>");
                    }
                    else
                    {
                        DateTime tarih = DateTime.Now;
                        string birlesikTarihSaat = tarih.ToString("yyyy-MM-dd HH:mm:ss");
                        guncelleme.Connection = sqlcon;
                        guncelleme.CommandText = "INSERT INTO personel_kullaniciHesap (personelKId, personelKullaniciAdi, personelKullaniciSifre, personelHOlusturmaTarihi, personelSonErisim, personelId, personel_ErisimDuzey, personel_ErisimKodu, personel_HesapAktiflik) VALUES (@personelKId, @personelKullaniciAdi, @personelKullaniciSifre, @personelHOlusturmaTarihi, @personelSonErisim, @personelId, @personel_ErisimDuzey, @personel_ErisimKodu, @personel_HesapAktiflik)";
                        //@personelKId, @personelKullaniciAdi, @personelKullaniciSifre, @personelHOlusturmaTarihi, @personelSonErisim, @personelId, @personel_ErisimDuzey, @personel_ErisimKodu, @personel_HesapAktiflik
                        guncelleme.Parameters.AddWithValue("@personelKId", new Random().Next(11111, 99999));
                        guncelleme.Parameters.AddWithValue("@personelKullaniciAdi", personelKullaniciAdi.Text);
                        guncelleme.Parameters.AddWithValue("@personelKullaniciSifre", personelKullaniciSifre.Text);
                        guncelleme.Parameters.AddWithValue("@personelHOlusturmaTarihi", tarih);
                        guncelleme.Parameters.AddWithValue("@personelSonErisim", tarih);
                        guncelleme.Parameters.AddWithValue("@personelId", HttpContext.Current.Request.QueryString["personelNumarasi"]);
                        guncelleme.Parameters.AddWithValue("@personel_ErisimDuzey", personel_ErisimDuzey.SelectedIndex);
                        guncelleme.Parameters.AddWithValue("@personel_ErisimKodu", "123123123");
                        guncelleme.Parameters.AddWithValue("@personel_HesapAktiflik", personel_HesapAktiflik.SelectedIndex);
                        guncelleme.ExecuteNonQuery();
                        Response.Write("<h1 style='color: Green; font-family: sans-serif;'>Personel Hesabı Başarıyla Eklendi!</h1>");
                    }

                }
                sqlcon.Close();
            }
        }
    }
}