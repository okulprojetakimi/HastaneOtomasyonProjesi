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
    public partial class personelData : System.Web.UI.Page
    {
        private string personelTckn = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null || kontrolCookie.Value.Trim() == "")
            {
                Response.Redirect("/cikis.aspx");
            }
            else
            {
                if (HttpContext.Current.Request.QueryString["personelTc"] == null)
                {
                    Response.Redirect("/panel.aspx");
                }
                else
                {
                    personelTckn = HttpContext.Current.Request.QueryString["personelTc"];
                    using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                    {
                        sqlcon.Open();
                        using (SqlCommand sqlcom = new SqlCommand("SELECT personel_Tc, personel_Isim, personel_Soyisim FROM personel_tablo WHERE personel_Tc = @personelTckn", sqlcon))
                        {
                            sqlcom.Parameters.AddWithValue("@personelTckn", personelTckn);
                            SqlDataReader veriOkuyucu = sqlcom.ExecuteReader();
                            DataTable tablo = new DataTable();
                            tablo.Load(veriOkuyucu);
                            string json = JsonConvert.SerializeObject(tablo, Formatting.Indented);
                            veriOkuyucu.Close();
                            sqlcon.Close();
                            Response.Write(json);
                        }
                    }
                }
            }
        }
    }
}