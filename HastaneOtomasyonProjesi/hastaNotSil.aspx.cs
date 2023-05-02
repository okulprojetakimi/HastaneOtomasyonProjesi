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
    public partial class hastaNotSil : System.Web.UI.Page
    {
        public string notNumarasi = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null)
            {
                Response.Redirect("/panel.aspx");
            }
            else
            {
                if (HttpContext.Current.Request.QueryString["notIdNum"] == null)
                {
                    Response.Redirect("/hastaIslemleri.aspx");
                }
                else
                {
                    notNumarasi = HttpContext.Current.Request.QueryString["notIdNum"];
                    using (SqlConnection sqlBaglantisi = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                    {
                        sqlBaglantisi.Open();
                        using (SqlCommand notSilmeKomutu = new SqlCommand("DELETE FROM hasta_Notlari WHERE hasta_NotId = @notNumarasi", sqlBaglantisi))
                        {
                            notSilmeKomutu.Parameters.AddWithValue("@notNumarasi", notNumarasi);
                            notSilmeKomutu.ExecuteNonQuery();
                            Response.Redirect("hastaIslemleri.aspx");
                            notSilmeKomutu.Dispose();
                            sqlBaglantisi.Close();
                        }
                    }
                }
            }
        }
    }
}