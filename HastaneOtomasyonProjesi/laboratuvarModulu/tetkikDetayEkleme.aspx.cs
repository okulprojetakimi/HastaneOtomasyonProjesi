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
    public partial class tetkikDetayEkleme : System.Web.UI.Page
    {
        public string tetkikIdNumarasi;
        public string selected;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null || kontrolCookie.Value.Trim() == "")
            {
                Response.Redirect("/cikis.aspx");
            }
            else
            {
                if (HttpContext.Current.Request.QueryString["tetkikId"] == null)
                {
                    Response.Redirect("/panel.aspx");
                }
                else
                {
                    /* Burdan sonra başlar */
                    tetkikIdNumarasi = HttpContext.Current.Request.QueryString["tetkikId"]; // Get ten gelen tetkikId numarasını alır ;D
                }
            }
        }


        protected void labDetayEkleButon_click(object sender, EventArgs e)
        {
            using (SqlConnection vtBaglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                vtBaglan.Open();
                int random = new Random().Next(111111, 999999);
                using (SqlCommand LabDetayEkle = new SqlCommand("INSERT INTO tetkik_DetayTablo (tetkik_detayId,tetkik_Sonuc,tetkikdetay_Durum,tetkik_calisanLab,tetkik_Id,tetkik_TanimId) VALUES (@tetkik_detayId,@tetkik_Sonuc,@tetkikdetay_Durum,@tetkik_calisanLab,@tetkik_Id,@tetkik_TanimId) ", vtBaglan))
                {
                    LabDetayEkle.Parameters.AddWithValue("@tetkik_detayId", random);
                    LabDetayEkle.Parameters.AddWithValue("@tetkik_Sonuc", tetkik_Sonuc.Text);
                    LabDetayEkle.Parameters.AddWithValue("@tetkikdetay_Durum", tetkikdetay_Durum.SelectedValue);
                    LabDetayEkle.Parameters.AddWithValue("@tetkik_calisanLab", PersonelSecimi.SelectedValue);
                    LabDetayEkle.Parameters.AddWithValue("@tetkik_Id", tetkikIdNumarasi);
                    LabDetayEkle.Parameters.AddWithValue("@tetkik_TanimId", labTetkikAdı.SelectedValue);
                    LabDetayEkle.ExecuteNonQuery();
                    vtBaglan.Close();
                }
            }

        }
       
    }
}