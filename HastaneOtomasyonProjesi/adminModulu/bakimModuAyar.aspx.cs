using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi.adminModulu
{
    public partial class bakimModuAyar : System.Web.UI.Page
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
                using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                {
                    sqlcon.Open(); // Bağlantı açılır.

                    if (!IsPostBack)
                    {
                        using (SqlCommand veriCek = new SqlCommand("SELECT * FROM sistem_Tablo", sqlcon))
                        {
                            SqlDataReader veriOkuyucu = veriCek.ExecuteReader();
                            if (veriOkuyucu.Read())
                            {
                                ayar_BakimMesaji.Text = veriOkuyucu.GetString(2);
                                ayar_Title.Text = veriOkuyucu.GetString(3);
                                if (veriOkuyucu.GetBoolean(1))
                                {
                                    bakimDurum.SelectedIndex = 1;
                                }
                                else
                                {
                                    bakimDurum.SelectedIndex = 0;
                                }
                            }
                            veriOkuyucu.Close();
                        }
                    }
                    sqlcon.Close();
                }


            }
        }

        protected void bakim_Kaydet_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                {
                    sqlcon.Open();
                    using (SqlCommand veriGuncelle = new SqlCommand("UPDATE sistem_Tablo SET ayar_BakimModu = @bakimMod, ayar_BakimMesaji = @bakimText, ayar_Title = @title WHERE ayar_Id = 1", sqlcon))
                    {
                        veriGuncelle.Parameters.AddWithValue("@bakimMod", bakimDurum.SelectedIndex);
                        veriGuncelle.Parameters.AddWithValue("@bakimText", ayar_BakimMesaji.Text);
                        veriGuncelle.Parameters.AddWithValue("@title", ayar_Title.Text);

                        veriGuncelle.ExecuteNonQuery();
                    }
                    sqlcon.Close();
                }
            }
            Response.Redirect("/adminModulu/bakimModuAyar");
        }
    }
}