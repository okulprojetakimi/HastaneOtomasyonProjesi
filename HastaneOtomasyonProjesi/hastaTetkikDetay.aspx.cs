using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace HastaneOtomasyonProjesi
{
    public partial class hastaTetkikDetay : System.Web.UI.Page
    {
        public string tetkikDetayId;
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
                    tetkikDetayId = HttpContext.Current.Request.QueryString["tetkikId"].ToString();
                    // Veritabanı bağlantısını açma
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                    {
                        conn.Open();

                        // Veritabanından veri çekme
                        SqlCommand cmd = new SqlCommand("SELECT * FROM tetkik_DetayTablo WHERE tetkik_Id = @tId", conn);
                        cmd.Parameters.AddWithValue("@tId", tetkikDetayId);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Gridview'i doldurma ve sütunları otomatik oluşturma
                        tetkikDetaylari.DataSource = dt;
                        tetkikDetaylari.DataBind();

                        // Veritabanı bağlantısını kapatma
                        conn.Close();
                    }

                }
            }
        }
    }
}