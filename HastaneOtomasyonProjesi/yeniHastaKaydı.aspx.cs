using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace HastaneOtomasyonProjesi
{
    public partial class yeniHastaKaydı : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button31_Click31(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlBaglantisi = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                {
                    sqlBaglantisi.Open();

                    using (SqlCommand hastaEkleme = new SqlCommand("INSERT INTO hasta_kayitlar (hasta_Adi, hasta_Soyadi) VALUES (@hasta_Adi, @hasta_Soyadi)", sqlBaglantisi))
                    {
                        hastaEkleme.Parameters.AddWithValue("@hasta_Adi", Request.Form["hasta_Adi"]);
                        hastaEkleme.Parameters.AddWithValue("@hasta_Soyadi", Request.Form["hasta_Soyadi"]);
                        hastaEkleme.ExecuteNonQuery();
                        /*
                         * 
                         * Devamkeeeeeeeeeeeeee
                         * 
                         */
                        sqlBaglantisi.Close();
                        /* İşlemler tamamlanırsa başarılı uyarısı çalışacak */
                        Response.Write("<script> alert('Hasta başarıyla eklendi!') </script>");
                    }
                }
            }
           
            catch (Exception)
            {
                Response.Write("<script> alert('Hata mevcut lütfen sistem yöneticisi ile konuşun!') </script>");
            }
        }
    }
}
