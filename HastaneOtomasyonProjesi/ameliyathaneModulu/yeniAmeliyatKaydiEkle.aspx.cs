using System;

using System.Collections;

using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

using System.Runtime.Remoting.Messaging;
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

        public int ilacId;
        public int personelId;
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
                    
              
                    using (SqlConnection sqlBaglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                    {
                        sqlBaglan.Open();
                        string query2 = "SELECT hasta_Id FROM hasta_kayitlar";
                        SqlCommand oku = new SqlCommand(query2, sqlBaglan);
                        using (SqlDataReader reader = oku.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                hastaId = reader.GetInt32(0);
                            }
                            reader.Close();
                            sqlBaglan.Close();
                        }
                    }
                    using (SqlConnection sqlBaglan3 = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString)) using (SqlConnection sqlBaglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                    {
                        sqlBaglan.Open();
                        string query1 = "SELECT personel_Id FROM personel_tablo";
                        SqlCommand command1 = new SqlCommand(query1, sqlBaglan);
                        using (SqlDataReader reader = command1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                personelId = reader.GetInt32(0);
                            }
                            reader.Close();
                            sqlBaglan.Close();
                        }
                    }
                    using (SqlConnection sqlBaglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                    {
                        sqlBaglan.Open();
                        string query = "SELECT ilacId FROM ilaclar_tablosu";
                        SqlCommand command = new SqlCommand(query, sqlBaglan);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ilacId = reader.GetInt32(0);
                            }
                            reader.Close();
                            sqlBaglan.Close();
                        }
                    }
     
                }
            }
        }

        protected void AmeliyatKaydıButon_click(object sender, EventArgs e)
        {
            string random = new Random().Next(1, 9).ToString();
            using (SqlConnection vtBaglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                vtBaglan.Open();
                using (SqlCommand AmeliyatKaydıEkleme = new SqlCommand("INSERT INTO ameliyathane_Tablo(ameliyatId,ameliyatGirisTarihi,ameliyatCikisTarihi,ameliyatNotu,ameliyatPersonelId,ameliyatIlacId,ameliyatAnesteziTuru,ameliyatHastaId) VALUES (@ameliyatId,@ameliyatGirisTarihi,@ameliyatCikisTarihi,@ameliyatNotu,@ameliyatPersonelId,@ameliyatIlacId,@ameliyatAnesteziTuru,@ameliyatHastaId)", vtBaglan))
                {
                    AmeliyatKaydıEkleme.Parameters.AddWithValue("@ameliyatId", random);
                    AmeliyatKaydıEkleme.Parameters.AddWithValue("@ameliyatGirisTarihi", Request.Form["ameliyatGirisTarihi"]);
                    AmeliyatKaydıEkleme.Parameters.AddWithValue("@ameliyatCikisTarihi", Request.Form["ameliyatCikisTarihi"]);
                    AmeliyatKaydıEkleme.Parameters.AddWithValue("@ameliyatNotu", Request.Form["ameliyatNotu"]);
                    AmeliyatKaydıEkleme.Parameters.AddWithValue("@ameliyatPersonelId", personelId);
                    AmeliyatKaydıEkleme.Parameters.AddWithValue("@ameliyatIlacId", ilacId);
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
