using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi.personelModulu
{
    public partial class personelApi : System.Web.UI.Page
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
                if (HttpContext.Current.Request.QueryString["isim"] == null || HttpContext.Current.Request.QueryString["soyisim"] == null)
                {
                    Response.Redirect("/panel.aspx");
                }
                else
                {
                    using (SqlConnection sqlcn = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                    {
                        sqlcn.Open();
                        using (SqlCommand komut = new SqlCommand("SELECT personel_Tc, personel_Isim, personel_Soyisim FROM personel_tablo WHERE personel_Isim LIKE @pIsim AND personel_Soyisim LIKE @pSoyisim", sqlcn))
                        {
                            komut.Parameters.AddWithValue("@pIsim", "%" + HttpContext.Current.Request.QueryString["isim"] + "%");
                            komut.Parameters.AddWithValue("@pSoyisim", "%" + HttpContext.Current.Request.QueryString["soyisim"] + "%");
                            SqlDataReader veriOkuyucu = komut.ExecuteReader();
                            DataTable tablo = new DataTable();
                            tablo.Load(veriOkuyucu);
                            string json = JsonConvert.SerializeObject(tablo, Formatting.Indented);
                            sqlcn.Close();
                            Response.Write(json);
                        }
                    }
                }
            }
        }
    }
}