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
    public partial class hastaIlacGoruntuleme : System.Web.UI.Page
    {
        public string gelenKayitId = "";
        public string durum = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolEt = Request.Cookies["erisimCookie"];
            if (kontrolEt == null)
            {
                Response.Redirect("/giris.aspx");
            }
            else
            {
                if (HttpContext.Current.Request.QueryString["vIlacId"] == null)
                {
                    Response.Redirect("/panel.aspx");
                }
                else
                {
                    gelenKayitId = HttpContext.Current.Request.QueryString["vIlacId"];
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand vCek = new SqlCommand("SELECT hasta_IlacDevamDurumu FROM hastaIlac_tablosu WHERE hastailac_Id = @hId", con))
                        {
                            vCek.Parameters.AddWithValue("@hId", gelenKayitId);
                            SqlDataReader oku = vCek.ExecuteReader();
                            while (oku.Read())
                            {
                                durum = oku.GetString(0);
                            }
                            oku.Close();
                            vCek.Dispose();
                            con.Close();
                        }
                    }
                    if (durum == "1")
                    {
                        devamDurumu.Checked = true;
                    }
                    else
                    {
                        devamDurumu.Checked = false;
                    }
                }
                
            }
        }

        protected void hasta_IlacDuzenle_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                con.Open();
                using (SqlCommand ilacKaydiDuzenle = new SqlCommand("UPDATE hastaIlac_tablosu SET hasta_IlacDevamDurumu = 1 WHERE hastailac_Id = @IDparametre"))
                {
                    if (devamDurumu.Checked)
                    {
                        ilacKaydiDuzenle.Parameters.AddWithValue("@IDparametre", 1);
                    }
                    else
                    {
                        ilacKaydiDuzenle.Parameters.AddWithValue("@IDparametre", 0);
                    }
                    ilacKaydiDuzenle.ExecuteNonQuery();
                    ilacKaydiDuzenle.Dispose();
                    con.Close();
                }

            }
            
        }
    }
}