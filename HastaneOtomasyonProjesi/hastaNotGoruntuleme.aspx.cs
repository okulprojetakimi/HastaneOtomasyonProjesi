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
    public partial class hastaNotGoruntuleme : System.Web.UI.Page
    {
        public int notIdNumarasi;
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
               notIdNumarasi  = Int32.Parse(HttpContext.Current.Request.QueryString["notIdNum"].ToString());
                
            }
        }

        protected void hastaNot_Duzenle_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlBaglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                sqlBaglanti.Open();
                using (SqlCommand notDuzenleme = new SqlCommand("UPDATE FROM hasta_Notlari SET hasta_Not"))
                {

                }
            }
        }
    }
}