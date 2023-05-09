using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
namespace HastaneOtomasyonProjesi
{
    public partial class ilacArama : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null || kontrolCookie.Value.Trim() == "")
            {
                Response.Redirect("/cikis.aspx");
            }
            else
            {
                if (HttpContext.Current.Request.QueryString["ilacIsmi"] == null)
                {
                    Response.Redirect("/panel.aspx");
                }
                else
                {
                    string ilacIsmi = HttpContext.Current.Request.QueryString["ilacIsmi"];
                    using (SqlConnection veritabaniBaglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                    {
                        veritabaniBaglanti.Open();
                        using (SqlCommand veriCek = new SqlCommand("SELECT * FROM ilaclar_tablosu WHERE ilacIsmi LIKE @parametre", veritabaniBaglanti))
                        {
                            veriCek.Parameters.AddWithValue("@parametre", "%" + ilacIsmi + "%");
                            SqlDataReader veriOkuyucu = veriCek.ExecuteReader();
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