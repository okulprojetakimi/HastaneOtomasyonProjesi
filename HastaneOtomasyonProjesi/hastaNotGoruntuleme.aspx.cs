using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi
{
    public partial class hastaNotGoruntuleme : System.Web.UI.Page
    {
        public int notIdNumarasi;
        public int hastaIdNumarasi;
        public string hastaNotVerisi;
        public DateTime hastaNotTarih;
        public string hastaAdi = "";
        public string hastaSoyadi = "";
        public string hastaTcNumarasi = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null || kontrolCookie.Value.Trim() == "")
            {
                Response.Redirect("/cikis.aspx");
            }
            else
            {
                if (HttpContext.Current.Request.QueryString["notIdNum"] == null)
                {
                    Response.Redirect("/panel.aspx");
                }
               notIdNumarasi  = Int32.Parse(HttpContext.Current.Request.QueryString["notIdNum"].ToString());
                using (SqlConnection hastaVeriCek = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                {
                    hastaVeriCek.Open();
                    using (SqlCommand hastaIdGetir = new SqlCommand("SELECT hasta_Notlari.hasta_Not AS [Hasta Not], hasta_Notlari.hasta_Id AS [Hasta Id], hasta_Notlari.hasta_notTarihi AS [Hasta Not Tarihi], hasta_kayitlar.hasta_Adi AS [Hasta Adı], hasta_kayitlar.hasta_Soyadi AS [Hasta Soyadı], hasta_kayitlar.hasta_Tc AS [Hasta Tc] FROM hasta_Notlari, hasta_kayitlar WHERE hasta_notlari.hasta_NotId = @hNId AND hasta_Notlari.hasta_Id = hasta_kayitlar.hasta_Id;", hastaVeriCek))
                    {
                        hastaIdGetir.Parameters.AddWithValue("@hNId", notIdNumarasi);
                        SqlDataReader idOku = hastaIdGetir.ExecuteReader();
                        if (!idOku.HasRows)
                        {
                            Response.Redirect("/panel.aspx");
                        }
                        else
                        {
                            while (idOku.Read())
                            {
                                hastaNotVerisi = idOku.GetString(0);
                                hastaIdNumarasi = idOku.GetInt32(1);
                                hastaNotTarih = idOku.GetDateTime(2);
                                hastaAdi = idOku.GetString(3);
                                hastaSoyadi = idOku.GetString(4);
                                hastaTcNumarasi = idOku.GetString(5);
                            }
                        }
                        idOku.Close();
                        hastaIdGetir.Dispose();
                    }
                }
                hasta_TcLabel.Text = hastaTcNumarasi;
                hasta_IsimSoyisim.Text = hastaAdi + " " + hastaSoyadi;
                eski_Veri.Text = hastaNotVerisi;
            }
        }
        /* Not güncelle buton */
        protected void hastaNot_Duzenle_Click(object sender, EventArgs e)
        {
            try
            {
                string sonHali = hastaNotu.Text;
                using (SqlConnection sqlBaglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                {
                    sqlBaglanti.Open();
                    using (SqlCommand notDuzenleme = new SqlCommand("UPDATE hasta_Notlari SET hasta_Not = @hastaNotInput WHERE hasta_NotId = @hNotId", sqlBaglanti))
                    {
                        notDuzenleme.Parameters.AddWithValue("@hastaNotInput", sonHali);
                        notDuzenleme.Parameters.AddWithValue("@hNotId", notIdNumarasi);
                        notDuzenleme.ExecuteNonQuery();
                        notDuzenleme.Dispose();
                        sqlBaglanti.Close();
                    }
                }
            }
            catch (Exception damnError)
            {
                Response.Write(damnError.Message);
            }
        }

        protected void hasta_NotSil_butonu_Click(object sender, EventArgs e)
        {
            Response.Redirect("hastaNotSil.aspx?notIdNum="+notIdNumarasi);
        }
    }
}