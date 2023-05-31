using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using Newtonsoft.Json;
namespace HastaneOtomasyonProjesi
{
    public partial class ilacArama : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ilac = HttpContext.Current.Request.QueryString["ilacIsmi"];
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null || kontrolCookie.Value.Trim() == "" || ilac == null || ilac == "")
            {
                Response.Redirect("/panel.aspx");
            }
            else
            {
                using (SqlConnection veritabaniBaglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                {
                    veritabaniBaglanti.Open();
                    using (SqlCommand veriCek = new SqlCommand("SELECT * FROM ilaclar_tablosu WHERE ilacIsmi LIKE @parametre", veritabaniBaglanti))
                    {
                        veriCek.Parameters.AddWithValue("@parametre", "%" + ilac + "%");
                        using (SqlDataReader veriOkuyucu = veriCek.ExecuteReader())
                        {
                            DataTable tablo = new DataTable();
                            tablo.Load(veriOkuyucu);
                            string json = JsonConvert.SerializeObject(tablo, Formatting.Indented);
                            veriOkuyucu.Close();
                            veritabaniBaglanti.Close();
                            Response.Write(json);
                        }
                    }
                }
            }
           
            
        }
    }
}