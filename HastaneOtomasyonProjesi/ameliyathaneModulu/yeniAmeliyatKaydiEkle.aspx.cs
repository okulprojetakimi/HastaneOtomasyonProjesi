using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi.ameliyathaneModulu
{
    public partial class yeniAmeliyatKaydiEkle : System.Web.UI.Page
    {
        public string hastaTcNum;
        public int hastaId;
       
       
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null)
            {
                 Response.Redirect("/panel.aspx");
            }
            else
            {
                if (HttpContext.Current.Request.QueryString["hasta"] == null)
                {
                      Response.Redirect("/panel.aspx");
                }
                else
                {
                    hastaTcNum = HttpContext.Current.Request.QueryString["hasta"];
                    using (SqlConnection sqlBaglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                    {
                        sqlBaglan.Open();
                        using (SqlCommand komut = new SqlCommand("SELECT hasta_Id, hasta_Adi, hasta_Soyadi FROM hasta_kayitlar WHERE hasta_Tc = @hastatcnum", sqlBaglan))
                        {
                            komut.Parameters.AddWithValue("@hastaTC", hastaTcNum);
                            SqlDataReader veriOkuyucu = komut.ExecuteReader();
                            while (veriOkuyucu.Read())
                            {
                                hastaId = veriOkuyucu.GetInt32(0);                              
                            }
                            veriOkuyucu.Close();
                            sqlBaglan.Close();
                        }
                      
                    }
               
                }
            }
        }

        protected void AmeliyatKaydıButon_click(object sender, EventArgs e)
        {
            string random = new Random().Next(11111, 99999).ToString();
            using (SqlConnection vtBaglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                vtBaglan.Open();
                using (SqlCommand AmeliyatKaydıEkleme = new SqlCommand("INSERT INTO ameliyathane_Tablo(ameliyatId,ameliyatGirisTarihi,ameliyatCikisTarihi,ameliyatNotu,ameliyatPersonelId,ameliyatIlacId,ameliyatAnesteziTuru,ameliyatHastaId) VALUES (@ameliyatId,@ameliyatGirisTarihi,@ameliyatCikisTarihi,@ameliyatNotu,@ameliyatPersonelId,@ameliyatIlacId,@ameliyatAnesteziTuru,@ameliyatHastaId)", vtBaglan))
                {
                    AmeliyatKaydıEkleme.Parameters.AddWithValue("@ameliyatId", random);
                    AmeliyatKaydıEkleme.Parameters.AddWithValue("@ameliyatGirisTarihi", Request.Form["ameliyatGirisTarihi"]);
                    AmeliyatKaydıEkleme.Parameters.AddWithValue("@ameliyatCikisTarihi", Request.Form["ameliyatCikisTarihi"]);
                    AmeliyatKaydıEkleme.Parameters.AddWithValue("@ameliyatNotu", Request.Form["ameliyatNotu"]);
                    AmeliyatKaydıEkleme.Parameters.AddWithValue("@ameliyatPersonelId", 1);               
                    AmeliyatKaydıEkleme.Parameters.AddWithValue("@ameliyatIlacId", Request.Form["ameliyatIlacId"]);
                    AmeliyatKaydıEkleme.Parameters.AddWithValue("@ameliyatAnesteziTuru", Request.Form["ameliyatAnesteziTuru"]);
                    AmeliyatKaydıEkleme.Parameters.AddWithValue("@ameliyatHastaId", hastaId);

                    AmeliyatKaydıEkleme.ExecuteNonQuery();                   
                    AmeliyatKaydıEkleme.Dispose();
                    vtBaglan.Close();
                }
            }
        }
    }
}