using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace HastaneOtomasyonProjesi.personelModulu
{
    public partial class personelDetay : System.Web.UI.Page
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
                // personelTc
                if (HttpContext.Current.Request.QueryString["personelTc"] == null)
                {
                    Response.Redirect("/panel.aspx");
                }
                else
                {
                    // Devam
                    using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                    {
                        sqlcon.Open();
                        using (SqlCommand sqlKomut = new SqlCommand("SELECT * FROM personel_tablo WHERE personel_Tc = @pTc", sqlcon))
                        {
                            sqlKomut.Parameters.AddWithValue("@pTc", HttpContext.Current.Request.QueryString["personelTc"]);
                            SqlDataReader veriOkuyucu = sqlKomut.ExecuteReader();
                            while (veriOkuyucu.Read())
                            {
                                personel_Tc.Text = veriOkuyucu.GetString(12);
                                personel_Isim.Text = veriOkuyucu.GetString(1);
                                personel_Soyisim.Text = veriOkuyucu.GetString(2);

                            }

                        }
                        sqlcon.Close();
                    }
                }
            }
        }

        protected void personel_Guncelle_Click(object sender, EventArgs e)
        {
            Response.Write(personel_Tc.Text);
            Response.Write(personel_Isim.Text);
            Response.Write(personel_Soyisim.Text);
            Response.Write(personel_Telefon.Text);
        }
    }
}